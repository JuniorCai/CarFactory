using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Authorization.Users;
using Abp.Domain.Repositories;
using Abp.IdentityFramework;
using CarFactory.Application.Roles.Dto;
using CarFactory.Application.Users.Dto;
using CarFactory.Core.Authorization;
using CarFactory.Core.Authorization.Roles;
using CarFactory.Core.Authorization.Users;
using Microsoft.AspNet.Identity;

namespace CarFactory.Application.Users
{
    public class UserAppService : AsyncCrudAppService<User, UserDto, long, PagedResultRequestDto, CreateUserDto, UpdateUserDto>, IUserAppService
    {
        private readonly UserManager _userManager;
        private readonly RoleManager _roleManager;
        private readonly IRepository<Role> _roleRepository;

        public UserAppService(
            IRepository<User, long> repository, 
            UserManager userManager, 
            IRepository<Role> roleRepository, 
            RoleManager roleManager)
            : base(repository)
        {
            _userManager = userManager;
            _roleRepository = roleRepository;
            _roleManager = roleManager;
        }

        [AbpAllowAnonymous]
        public override async Task<UserDto> Get(EntityDto<long> input)
        {
            var user = await base.Get(input);
            if (user != null)
            {
                var userRoles = await _userManager.GetRolesAsync(user.Id);
                user.Roles = userRoles.Select(ur => ur).ToArray();
            }
            return user;
        }

        [AbpAuthorize(PermissionNames.Pages_Users)]
        public override async Task<UserDto> Create(CreateUserDto input)
        {
            CheckCreatePermission();

            var user = ObjectMapper.Map<User>(input);
            

            user.TenantId = AbpSession.TenantId;
            user.Password = new PasswordHasher().HashPassword(input.Password);
            user.IsEmailConfirmed = true;

            //Assign roles
            user.Roles = new Collection<UserRole>();
            foreach (var roleName in input.RoleNames)
            {
                var role = await _roleManager.GetRoleByNameAsync(roleName);
                user.Roles.Add(new UserRole(AbpSession.TenantId, user.Id, role.Id));
            }

            CheckErrors(await _userManager.CreateAsync(user));

            return MapToEntityDto(user);
        }

        [AbpAuthorize(PermissionNames.Pages_Users)]
        public async Task<Tuple<bool,string>> ResetUserPwd(long userId)
        {
            var user = await _userManager.GetUserByIdAsync(userId);
            if (user == null)
            {
                return new Tuple<bool, string>(false, "无可用操作对象");
            }

            user.Password = new PasswordHasher().HashPassword(User.DefaultPassword);

            var status = _userManager.UpdateAsync(user);
            return new Tuple<bool, string>(status.Result.Succeeded,status.Result.Errors.ToString());
        }

        [AbpAllowAnonymous]
        public async Task<Tuple<bool, string>> ChangeUserPwd(UserChangePwdDto pwdDto)
        {
            var user = await _userManager.GetUserByIdAsync(pwdDto.Id);
            if (user == null)
            {
                return new Tuple<bool, string>(false, "无可用操作对象");
            }

            if (!_userManager.CheckUserPwd(user,pwdDto.OldPassword))
            {
                return new Tuple<bool, string>(false, "旧密码不正确");
            }

            var result = await _userManager.ChangePasswordAsync(user, pwdDto.Password);


            return new Tuple<bool, string>(result.Succeeded, result.Errors.ToString());
        }


        [AbpAuthorize(PermissionNames.Pages_Users)]
        public override async Task<UserDto> Update(UpdateUserDto input)
        {
            CheckUpdatePermission();

            var user = await _userManager.GetUserByIdAsync(input.Id);

            MapToEntity(input, user);

            CheckErrors(await _userManager.UpdateAsync(user));

            if (input.RoleNames != null)
            {
                CheckErrors(await _userManager.SetRoles(user, input.RoleNames));
            }

            return await Get(input);
        }

        [AbpAuthorize(PermissionNames.Pages_Users)]
        public override async Task Delete(EntityDto<long> input)
        {
            var user = await _userManager.GetUserByIdAsync(input.Id);
            await _userManager.DeleteAsync(user);
        }

        public async Task<ListResultDto<RoleDto>> GetRoles()
        {
            var roles = await _roleRepository.GetAllListAsync();
            return new ListResultDto<RoleDto>(ObjectMapper.Map<List<RoleDto>>(roles));
        }

        protected override User MapToEntity(CreateUserDto createInput)
        {
            var user = ObjectMapper.Map<User>(createInput);
            return user;
        }

        protected override void MapToEntity(UpdateUserDto input, User user)
        {
            ObjectMapper.Map(input, user);
        }

        protected override IQueryable<User> CreateFilteredQuery(PagedResultRequestDto input)
        {
            return Repository.GetAllIncluding(x => x.Roles);
        }

        protected override async Task<User> GetEntityByIdAsync(long id)
        {
            var user = Repository.GetAllIncluding(x => x.Roles).FirstOrDefault(x => x.Id == id);
            return await Task.FromResult(user);
        }

        protected override IQueryable<User> ApplySorting(IQueryable<User> query, PagedResultRequestDto input)
        {
            return query.OrderBy(r => r.UserName);
        }

        protected virtual void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
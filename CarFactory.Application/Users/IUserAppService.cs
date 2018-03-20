using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using CarFactory.Application.Roles.Dto;
using CarFactory.Application.Users.Dto;

namespace CarFactory.Application.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedResultRequestDto, CreateUserDto, UpdateUserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task<Tuple<bool, string>> ResetUserPwd(long userId);

        Task<Tuple<bool, string>> ChangeUserPwd(UserChangePwdDto pwdDto);

    }
}
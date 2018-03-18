using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using Abp.Application.Navigation;
using Abp.Application.Services.Dto;
using Abp.Web.Mvc.Authorization;
using CarFactory.Admin.Models.Users;
using CarFactory.Application.Users;
using CarFactory.Application.Users.Dto;
using CarFactory.Core.Authorization;
using CarFactory.Core.Authorization.Roles;

namespace CarFactory.Admin.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Users)]
    [RoutePrefix("admin")]
    public class UsersController : CarFactoryControllerBase
    {
        private readonly IUserAppService _userAppService;
        private readonly RoleManager _roleManager;

        public UsersController(IUserAppService userAppService, RoleManager roleManager, IUserNavigationManager userNavigationManager) 
            : base(userNavigationManager)
        {
            _userAppService = userAppService;
            _roleManager = roleManager;
        }

        [Route("UserManage")]
        public async Task<ActionResult> Index()
        {
            var users = (await _userAppService.GetAll(new PagedResultRequestDto { MaxResultCount = int.MaxValue })).Items; //Paging not implemented yet
            var roles = (await _userAppService.GetRoles()).Items;

            foreach (UserDto user in users)
            {
                var Info = _userAppService.Get(new EntityDto<long>(user.Id));
                user.Roles = Info.Result.Roles;
            }

            var userMenu = GetUserMenu(PageNames.Users).Result;
            ViewBag.UserMenu = userMenu;

            return View(users);
        }

        [Route("roles/detail/{userId?}")]
        public async Task<ActionResult> EditUser(long userId = 0)
        {
            var user = await _userAppService.Get(new EntityDto<long>(userId));
            if (user == null)
            {
                user = new UserDto();
            }
            var roles = (await _userAppService.GetRoles()).Items;

            ViewBag.Roles = roles;

            var userMenu = GetUserMenu(PageNames.Users).Result;
            ViewBag.UserMenu = userMenu;

            return View(user);
        }


        [Route("roles/detail/create")]
        public async Task<JsonResult> CreateUser(CreateUserDto newModel)
        {
            CheckModelState();
            newModel.IsActive = true;

            bool stauts = false;
            try
            {
                var model = await _userAppService.Create(newModel);
                stauts = true;
            }
            catch (Exception e)
            {
                stauts = false;
            }


            return Json(new { success = stauts});
        }

        [Route("roles/detail/update")]
        public async Task<JsonResult> UpdateUser(UpdateUserDto updateModel)
        {
            CheckModelState();
            //await _userAppService.Create()

            return Json(new { });
        }


        [Route("roles/profile/{id}")]
        public async Task<ActionResult> ProfileInfo(long id = 0)
        {


            var userMenu = GetUserMenu(PageNames.Users).Result;
            ViewBag.UserMenu = userMenu;

            return View();
        }
    }
}
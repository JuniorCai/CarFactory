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


        [Route("users/detail/{userId?}")]
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

        [HttpPost]
        [Route("users/detail/create")]
        public async Task<JsonResult> CreateUser(CreateUserDto newModel)
        {
            CheckModelState();
            newModel.IsActive = true;

            bool stauts = false;
            string message = "";

            try
            {
                var model = await _userAppService.Create(newModel);
                stauts = true;
            }
            catch (Exception e)
            {
                message = e.Message;

                stauts = false;
            }


            return Json(new { success = stauts,message = message});
        }

        [HttpPost]
        [Route("users/detail/update")]
        public async Task<JsonResult> UpdateUser(UpdateUserDto updateModel)
        {
            CheckModelState();


            bool stauts = false;
            string message = "";

            try
            {
                await _userAppService.Update(updateModel);
                stauts = true;

            }
            catch (Exception e)
            {
                message = e.Message;

                stauts = false;
            }

            return Json(new { success = stauts, message = message });
        }

        [Route("users/reset")]
        [HttpPost]
        public async Task<JsonResult> ResetPwd(long userId)
        {
            CheckModelState();


            bool stauts = false;
            string message = "";

            try
            {
                var tupleResult = await _userAppService.ResetUserPwd(userId);
                stauts = tupleResult.Item1;
                message = tupleResult.Item2;

            }
            catch (Exception e)
            {
                message = e.Message;

                stauts = false;
            }

            return Json(new { success = stauts, message = message });
        }

        [Route("users/delUser")]
        [HttpPost]
        public async Task<JsonResult> DelUser(long id)
        {

            bool stauts = false;
            string message = "";

            try
            {
                await _userAppService.Delete(new EntityDto<long>(id));
                stauts = true;
                message = "";

            }
            catch (Exception e)
            {
                message = e.Message;

                stauts = false;
            }

            return Json(new { success = stauts, message = message });
        }



        [Route("users/profile/{id}")]
        public async Task<ActionResult> ProfileInfo(long id = 0)
        {


            var userMenu = GetUserMenu(PageNames.Users).Result;
            ViewBag.UserMenu = userMenu;

            return View();
        }
    }
}
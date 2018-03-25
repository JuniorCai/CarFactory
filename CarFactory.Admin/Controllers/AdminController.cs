using System;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;
using Abp.Application.Navigation;
using Abp.Application.Services.Dto;
using Abp.Web.Mvc.Authorization;
using CarFactory.Application.Users;
using CarFactory.Application.Users.Dto;

namespace CarFactory.Admin.Controllers
{
    [AbpMvcAuthorize()]
    public class AdminController : CarFactoryControllerBase
    {
        private readonly IUserAppService _userAppService;

        public AdminController(IUserAppService userAppService, IUserNavigationManager userNavigationManager) 
            : base(userNavigationManager)
        {
            _userAppService = userAppService;
        }


        // GET: Admin
        public ActionResult Index()
        {
            var userMenu = GetUserMenu("").Result;
            ViewBag.UserMenu = userMenu;



            return View();
        }

        [Route("admin/profile/{id}")]
        public async Task<ActionResult> ProfileInfo(long id = 0)
        {
            var userId = AbpSession.UserId;
            var userInfo = await _userAppService.Get(new EntityDto<long>(userId.Value));


            var userMenu = GetUserMenu(PageNames.Home).Result;
            ViewBag.UserMenu = userMenu;

            return View(userInfo);
        }


        [Route("admin/profile/save")]
        [HttpPost]
        public async Task<JsonResult> SaveProfile(UserChangePwdDto pwdDto)
        {
            CheckModelState();

            bool status = false;
            string message = "";

            try
            {
                var tupleResult = await _userAppService.ChangeUserPwd(pwdDto);
                status = tupleResult.Item1;
                message = tupleResult.Item2;
            }
            catch (Exception e)
            {
                status = false;
                message = e.Message;
            }


            return Json(new {success = status, message = message});
        }

    }
}
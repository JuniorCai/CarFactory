using System.Threading;
using System.Web.Mvc;
using Abp.Application.Navigation;
using Abp.Application.Services.Dto;
using Abp.Web.Mvc.Authorization;
using CarFactory.Application.Users;

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
        [Route("admin")]
        public ActionResult Index()
        {
            var userId = AbpSession.UserId;
            var userMenu = GetUserMenu("").Result;
            ViewBag.UserMenu = userMenu;
            var t = Thread.CurrentThread;

            var userInfo = _userAppService.Get(new EntityDto<long>(userId.Value));

            return View(userInfo.Result);
        }
    }
}
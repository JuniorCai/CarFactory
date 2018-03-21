using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Abp.Application.Navigation;
using CarFactory.Application.Users;

namespace CarFactory.Admin.Controllers
{
    public class SeoController : CarFactoryControllerBase
    {

        public SeoController(IUserNavigationManager userNavigationManager)
            : base(userNavigationManager)
        {
        }

        // GET: Seo
        public ActionResult Index()
        {

            var userMenu = GetUserMenu(PageNames.Users).Result;
            ViewBag.UserMenu = userMenu;


            return View();
        }
    }
}
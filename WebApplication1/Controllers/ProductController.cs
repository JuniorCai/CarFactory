using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Abp.Application.Navigation;

namespace CarFactory.Admin.Controllers
{
    [RoutePrefix("admin")]
    public class ProductController : CarFactoryControllerBase
    {
        private readonly IUserNavigationManager _userNavigationManager;

        public ProductController(IUserNavigationManager userNavigationManager) : base(userNavigationManager)
        {
            _userNavigationManager = userNavigationManager;
        }
        [Route("ProductManage")]
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
    }
}
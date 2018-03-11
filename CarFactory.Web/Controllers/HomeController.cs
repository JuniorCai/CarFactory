using System.Threading;
using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;

namespace CarFactory.Web.Controllers
{
    //[AbpMvcAuthorize]
    public class HomeController : CarFactoryControllerBase
    {
        public ActionResult Index()
        {
            var t = Thread.CurrentThread;

            return View();
        }
	}
}
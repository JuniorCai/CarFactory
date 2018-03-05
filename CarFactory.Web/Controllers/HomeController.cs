using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;

namespace CarFactory.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : CarFactoryControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
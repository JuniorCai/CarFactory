using System.Web.Mvc;

namespace CarFactory.Web.Controllers
{
    public class AboutController : CarFactoryControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
using System.Web.Mvc;

namespace CarFactory.Web.Controllers
{
    public class AboutController : CarFactoryControllerBase
    {
        

        public AboutController()
        {
            
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contact()
        {

            return View();
        }
	}
}
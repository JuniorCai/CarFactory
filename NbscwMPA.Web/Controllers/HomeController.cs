using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;

namespace NbscwMPACarFactory.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : NbscwMPAControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
using System.Threading.Tasks;
using System.Web.Mvc;
using CarFactory.Application.Company;
using CarFactory.Application.Company.Dtos;
using CarFactory.Application.Seo;
using CarFactory.Core.CustomDomain.Company;

namespace CarFactory.Web.Controllers
{
    public class AboutController : CarFactoryControllerBase
    {
        private readonly ICompanyAppService _companyAppService;
        

        public AboutController(ISeoAppService seoAppService, ICompanyAppService companyAppService):base(seoAppService)
        {
            _companyAppService = companyAppService;
        }
        public ActionResult Index()
        {
            CompanyListDto info = _companyAppService.GetDefaultCompanyAsync().Result;
            ViewBag.SeoSetting = GetSeoSetting();

            return View(info);
        }

        public async Task<ActionResult> Contact()
        {
            CompanyListDto info = await _companyAppService.GetDefaultCompanyAsync();
            ViewBag.SeoSetting = GetSeoSetting();

            return View(info);
        }
	}
}
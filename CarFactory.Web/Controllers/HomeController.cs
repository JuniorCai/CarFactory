using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;
using CarFactory.Application.Company;
using CarFactory.Application.Company.Dtos;
using CarFactory.Application.Seo;

namespace CarFactory.Web.Controllers
{
    //[AbpMvcAuthorize]
    public class HomeController : CarFactoryControllerBase
    {

        private readonly ICompanyAppService _companyAppService;


        public HomeController(ISeoAppService seoAppService,ICompanyAppService companyAppService):base(seoAppService)
        {
            _companyAppService = companyAppService;
        }
        public async Task<ActionResult> Index()
        {
            CompanyListDto info = await _companyAppService.GetDefaultCompanyAsync();
            ViewBag.SeoSetting = GetSeoSetting ();
            return View(info);
        }
	}
}
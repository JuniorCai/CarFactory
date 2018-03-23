using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;
using CarFactory.Application.Banner;
using CarFactory.Application.Banner.Dtos;
using CarFactory.Application.Company;
using CarFactory.Application.Company.Dtos;
using CarFactory.Application.Seo;
using CarFactory.Core;

namespace CarFactory.Web.Controllers
{
    //[AbpMvcAuthorize]
    public class HomeController : CarFactoryControllerBase
    {

        private readonly ICompanyAppService _companyAppService;
        private readonly IBannerAppService _bannerAppService;


        public HomeController(IBannerAppService bannerAppService,ISeoAppService seoAppService,ICompanyAppService companyAppService):base(seoAppService)
        {
            _companyAppService = companyAppService;
            _bannerAppService = bannerAppService;
        }
        public async Task<ActionResult> Index()
        {
            GetBannerInput bannerInput = new GetBannerInput()
            {
                FilterText = "",
                MaxResultCount = CarFactoryConsts.MaxPageSize,
                SkipCount = 0,
                Sorting = "Sort"
            };
            ViewBag.BannerList = await _bannerAppService.GetPagedBannersAsync(bannerInput);

            CompanyListDto info = await _companyAppService.GetDefaultCompanyAsync();
            ViewBag.SeoSetting = GetSeoSetting ();
            return View(info);
        }
	}
}
using System.Threading.Tasks;
using System.Web.Mvc;
using CarFactory.Application.Company;
using CarFactory.Application.Company.Dtos;
using CarFactory.Core.CustomDomain.Company;

namespace CarFactory.Web.Controllers
{
    public class AboutController : CarFactoryControllerBase
    {
        private readonly ICompanyAppService _companyAppService;
        

        public AboutController(ICompanyAppService companyAppService)
        {
            _companyAppService = companyAppService;
        }
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Contact()
        {
            CompanyListDto info = await _companyAppService.GetDefaultCompanyAsync();
            return View(info);
        }
	}
}
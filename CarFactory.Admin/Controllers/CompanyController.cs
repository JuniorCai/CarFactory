using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Abp.Application.Navigation;
using CarFactory.Application.Company;
using CarFactory.Application.Company.Dtos;

namespace CarFactory.Admin.Controllers
{
    [RoutePrefix("admin")]
    public class CompanyController : CarFactoryControllerBase
    {

        private readonly ICompanyAppService _companyAppService;

        public CompanyController(ICompanyAppService companyAppService, IUserNavigationManager userNavigationManager) : base(userNavigationManager)
        {
            _companyAppService = companyAppService;
        }

        [Route("company")]
        // GET: Company
        public async Task<ActionResult> Index()
        {

            var companyInfo = await _companyAppService.GetDefaultCompanyAsync();

            var userMenu = GetUserMenu(PageNames.Company).Result;
            ViewBag.UserMenu = userMenu;

            return View(companyInfo);
        }


        [HttpPost]
        [Route("company/save")]
        public async Task<JsonResult> Save(CompanyEditDto editModel)
        {
            CheckModelState();

            bool status = false;
            string message = "";


            try
            {
                await _companyAppService.CreateOrUpdateCompanyAsync(new CreateOrUpdateCompanyInput(){CompanyEditDto = editModel });
                status = true;
            }
            catch (Exception e)
            {
                status = false;
                message = e.Message;
            }


            return Json(new {success = status, message = message});
        }
    }
}
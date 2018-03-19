using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Abp.Application.Navigation;
using CarFactory.Application.Company;

namespace CarFactory.Admin.Controllers
{
    public class CompanyController : CarFactoryControllerBase
    {

        private readonly ICompanyAppService _companyAppService;

        public CompanyController(ICompanyAppService companyAppService, IUserNavigationManager userNavigationManager) : base(userNavigationManager)
        {
            _companyAppService = companyAppService;
        }


        // GET: Company
        public ActionResult Index()
        {
            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Abp.Application.Navigation;

namespace CarFactory.Admin.Controllers
{
    public class ReportController : CarFactoryControllerBase
    {

        public ReportController(IUserNavigationManager userNavigationManager):base(userNavigationManager)
        {
            
        }
        // GET: Report
        public ActionResult Index()
        {
            return View();
        }
    }
}
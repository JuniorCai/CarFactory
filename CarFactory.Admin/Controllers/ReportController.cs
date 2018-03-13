using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Abp.Application.Navigation;
using Abp.AutoMapper;
using Abp.Web.Mvc.Authorization;
using CarFactory.Application.Report;
using CarFactory.Application.Report.Dtos;
using CarFactory.Core;
using X.PagedList;

namespace CarFactory.Admin.Controllers
{
    [RoutePrefix("admin")]
    [AbpMvcAuthorize()]
    public class ReportController : CarFactoryControllerBase
    {
        private readonly IReportAppService _reportAppService;

        public ReportController(IReportAppService reportAppService, IUserNavigationManager userNavigationManager) :
            base(userNavigationManager)
        {
            _reportAppService = reportAppService;
        }


        // GET: Report
        [Route("reportManage")]
        public ActionResult Index(GetReportInput searchInput)
        {
            GetReportInput filterInput = searchInput ?? (new GetReportInput());
            int pageIndex = (filterInput.Page ?? 1) - 1;

            filterInput.MaxResultCount = CarFactoryConsts.MaxPageSize;
            filterInput.SkipCount = pageIndex * CarFactoryConsts.MaxPageSize;
            filterInput.Sorting = "CreateTime";
            filterInput.Page = pageIndex + 1;

          

            var list = _reportAppService.GetPagedReportsAsync(filterInput).Result;

            var pagedProducts = new StaticPagedList<ReportListDto>(list.Items, filterInput.Page.Value, filterInput.MaxResultCount,
                list.TotalCount);

            var userMenu = GetUserMenu(PageNames.ProductCategory).Result;
            ViewBag.UserMenu = userMenu;
            return View();
        }
    }
}
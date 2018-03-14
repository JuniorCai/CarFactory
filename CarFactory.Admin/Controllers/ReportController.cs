using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Abp.Application.Navigation;
using Abp.AutoMapper;
using Abp.Web.Models;
using Abp.Web.Mvc.Authorization;
using CarFactory.Admin.Models.Reports;
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

        [Route("ReportManage")]
        public ActionResult Index()
        {
            var userMenu = GetUserMenu(PageNames.ProductCategory).Result;
            ViewBag.UserMenu = userMenu;
            return View();
        }

        // GET: Report
        [Route("reports/getDataPager")]
        [DontWrapResult]
        public JsonResult GetDataPager(GetReportInput searchInput)
        {
            GetReportInput filterInput = searchInput ?? (new GetReportInput());
            int pageIndex = (filterInput.Page ?? 1) - 1;

            filterInput.MaxResultCount = CarFactoryConsts.MaxPageSize;
            filterInput.SkipCount = pageIndex * filterInput.MaxResultCount;
            filterInput.Sorting = "CreationTime";
            filterInput.Page = pageIndex + 1;

          

            var list = _reportAppService.GetPagedReportsAsync(filterInput).Result;

            var pagedProducts = new StaticPagedList<ReportListDto>(list.Items, filterInput.Page.Value, filterInput.MaxResultCount,
                list.TotalCount);


            var viewModelList = GenerateTablePagerData(pagedProducts, "/admin/detail/");

            return Json(new {draw=Request.Form["draw"], recordsTotal = pagedProducts.TotalItemCount, recordsFiltered = pagedProducts.Count, data = viewModelList },JsonRequestBehavior.AllowGet);
        }

        protected List<ReportTableViewModel> GenerateTablePagerData(StaticPagedList<ReportListDto> pagedList, string detailUrl)
        {
            List<ReportTableViewModel> list = new List<ReportTableViewModel>();

            foreach (var item in pagedList)
            {
                ReportTableViewModel viewModel = new ReportTableViewModel()
                {
                    CheckBoxStrTag =
                        "<label class='mt-checkbox mt-checkbox-single mt-checkbox-outline'><input name='id[]' type='checkbox' class='checkboxes' value='" +
                        item.Id + "'><span></span></label>",
                    Id = item.Id,
                    CreateTime = item.CreationTime.ToString("yyyy-MM-dd HH:mm:ss"),
                    Name = item.ReportName.Length > 28 ? item.ReportName.Substring(0, 28) + "...": item.ReportName,
                    StautsStrTag = "<span class='label label-sm " +
                                   (item.IsShow ? "label-success" : "label-danger")
                                   + "'>" + (item.IsShow ? "展示" : "下架") + "</span>",
                    ViewDetailUrlTag = "<a href='" + detailUrl + item.Id +
                                       "' target='_blank' class='viewData btn btn-sm btn-outline grey-salsa'><i class='fa fa-search'></i> View</a>"
                };
                list.Add(viewModel);
            }
            return list;
        }

    }
}
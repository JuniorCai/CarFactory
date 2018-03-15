using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Abp.Application.Navigation;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Collections.Extensions;
using Abp.Runtime.Validation;
using Abp.Web.Models;
using Abp.Web.Mvc.Authorization;
using CarFactory.Admin.Helpers;
using CarFactory.Admin.Models;
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
            var userMenu = GetUserMenu(PageNames.Reports).Result;
            ViewBag.UserMenu = userMenu;
            return View();
        }

        // GET: Report
        [Route("reports/getDataPager")]
        [DontWrapResult]
        [DisableValidation]
        public JsonResult GetDataPager(DataTableSearchModel searchInput)
        {

            if (searchInput.ActionType == "group_action")
            {
                if (string.IsNullOrEmpty(searchInput.CustomActionValue) || searchInput.id == null ||
                    searchInput.id.Count == 0)
                {
                    return Json(new {actionType=searchInput.ActionType,customActionStatus = false, customActionMsg = "无效参数"});
                }
                try
                {
                    _reportAppService.BatchUpdateStatusAsync(searchInput.id, bool.Parse(searchInput.CustomActionValue));
                    return Json(new { actionType = searchInput.ActionType, customActionStatus = true, customActionMsg = "" });

                }
                catch (Exception e)
                {
                    return Json(new { actionType = searchInput.ActionType, customActionStatus = false, customActionMsg = "无效参数" });
                }
            }


            int pageIndex = 0;

            GetReportInput defaultInput = new GetReportInput()
            {
                MaxResultCount = CarFactoryConsts.MaxPageSize,
                SkipCount = pageIndex * CarFactoryConsts.MaxPageSize,
                Sorting = "CreationTime",
                Page = pageIndex + 1
            };

            if (searchInput != null && searchInput.ActionType == "filter")
            {
                defaultInput.Id = searchInput.FilterId;
                defaultInput.BeginDate = searchInput.FilterDateFrom;
                defaultInput.EndDate = searchInput.FilterDateTo;
                defaultInput.FilterText = searchInput.FilterName??"";
                defaultInput.Status = searchInput.FilterStatus;
            }


            var list = _reportAppService.GetPagedReportsAsync(defaultInput).Result;

            var pagedProducts = new StaticPagedList<ReportListDto>(list.Items, defaultInput.Page.Value, defaultInput.MaxResultCount,
                list.TotalCount);


            var viewModelList = GenerateTablePagerData(pagedProducts, "/admin/reports/detail/");

            return Json(new {draw=Request.Form["draw"], recordsTotal = pagedProducts.TotalItemCount, recordsFiltered = pagedProducts.Count, data = viewModelList },JsonRequestBehavior.AllowGet);
        }

        protected List<ReportAndProductTableViewModel> GenerateTablePagerData(StaticPagedList<ReportListDto> pagedList, string detailUrl)
        {
            List<ReportAndProductTableViewModel> list = new List<ReportAndProductTableViewModel>();

            foreach (var item in pagedList)
            {
                ReportAndProductTableViewModel viewModel = new ReportAndProductTableViewModel()
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

        [Route("reports/detail/{id?}")]
        public ActionResult Detail(int? id)
        {
            ReportListDto info = new ReportListDto();

            if (id != null)
            {
                info = _reportAppService.GetReportByIdAsync(new EntityDto<int>(id.Value)).Result;
            }


            var userMenu = GetUserMenu(PageNames.Reports).Result;
            ViewBag.UserMenu = userMenu;

            return View(info);
        }

        [Route("reports/save")]
        public JsonResult Save(ReportEditDto detail)
        {
            bool status = false;
            string msg = "";

            if (detail.Id > 0)
            {
                try
                {
                    var oldReport = _reportAppService.GetReportByIdAsync(new EntityDto<int>(detail.Id.Value));
                    if (oldReport != null)
                    {
                        detail.Img = oldReport.Result.Img;

                        ImgUploadHelpers uploadHelpers = new ImgUploadHelpers(Request.Files, Server.MapPath("/"));
                        var uploadResult = uploadHelpers.UploadImg();
                        if (uploadResult.Item1 == ImageUploadStatus.Success)
                        {
                            detail.Img = uploadResult.Item2;

                            _reportAppService.CreateOrUpdateReportAsync(
                                new CreateOrUpdateReportInput {ReportEditDto = detail});

                            status = true;
                        }
                        else if (uploadResult.Item1 == ImageUploadStatus.NoFile)
                        {
                            _reportAppService.CreateOrUpdateReportAsync(
                                new CreateOrUpdateReportInput {ReportEditDto = detail});

                            status = true;
                        }
                        else
                        {
                            status = false;
                            msg = uploadResult.Item2;
                        }

                    }
                }
                catch (Exception e)
                {
                    status = false;
                    msg = "运行时出错";
                }

            }
            else
            {
                try
                {
                    ImgUploadHelpers uploadHelpers = new ImgUploadHelpers(Request.Files, Server.MapPath("/"));
                    var uploadResult = uploadHelpers.UploadImg();
                    if (uploadResult.Item1 == ImageUploadStatus.Success)
                    {
                        detail.Img = uploadResult.Item2;
                        detail.IsShow = true;

                        _reportAppService.CreateOrUpdateReportAsync(
                            new CreateOrUpdateReportInput { ReportEditDto = detail });

                        status = true;
                    }
                    else
                    {
                        status = false;
                        msg = uploadResult.Item2;
                    }
                }
                catch (Exception e)
                {
                    status = false;
                    msg = "运行时出错";
                }  
            }
            return Json(new {status = status, message = msg});
        }


       
    }
}
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Abp.Application.Navigation;
using Abp.Domain.Uow;
using Abp.Runtime.Validation;
using Abp.Web.Models;
using CarFactory.Admin.Models;
using CarFactory.Admin.Models.Reports;
using CarFactory.Application.Products;
using CarFactory.Application.Products.Dtos;
using CarFactory.Application.Report.Dtos;
using CarFactory.Core;
using X.PagedList;

namespace CarFactory.Admin.Controllers
{
    [RoutePrefix("admin")]
    public class ProductController : CarFactoryControllerBase
    {
        private readonly IUserNavigationManager _userNavigationManager;

        private readonly IProductAppService _productAppService;

        public ProductController(IProductAppService productAppService,IUserNavigationManager userNavigationManager) : base(userNavigationManager)
        {
            _productAppService = productAppService;
            _userNavigationManager = userNavigationManager;
        }
        [Route("ProductManage")]
        // GET: Product
        public ActionResult Index()
        {
            var userMenu = GetUserMenu(PageNames.Products).Result;
            ViewBag.UserMenu = userMenu;
            return View();
        }


        [Route("products/getDataPager")]
        [DontWrapResult]
        [DisableValidation]
        public JsonResult GetDataPager(DataTableSearchModel searchInput)
        {

            if (searchInput.ActionType == "group_action")
            {
                if (string.IsNullOrEmpty(searchInput.CustomActionValue) || searchInput.id == null ||
                    searchInput.id.Count == 0)
                {
                    return Json(new { actionType = searchInput.ActionType, customActionStatus = false, customActionMsg = "无效参数" });
                }
                try
                {
                    _productAppService.BatchUpdateStatusAsync(searchInput.id, bool.Parse(searchInput.CustomActionValue));
                    return Json(new { actionType = searchInput.ActionType, customActionStatus = true, customActionMsg = "" });

                }
                catch (DbEntityValidationException e)
                {
                    return Json(new { actionType = searchInput.ActionType, customActionStatus = false, customActionMsg = "无效参数" });
                }
            }


            int pageIndex = 0;

            GetProductInput defaultInput = new GetProductInput()
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
                defaultInput.FilterText = searchInput.FilterName ?? "";
                defaultInput.Status = searchInput.FilterStatus;
            }


            var list = _productAppService.GetPagedProductsAsync(defaultInput).Result;

            var pagedProducts = new StaticPagedList<ProductListDto>(list.Items, defaultInput.Page.Value, defaultInput.MaxResultCount,
                list.TotalCount);


            var viewModelList = GenerateTablePagerData(pagedProducts, "/admin/products/detail/");

            return Json(new { draw = Request.Form["draw"], recordsTotal = pagedProducts.TotalItemCount, recordsFiltered = pagedProducts.Count, data = viewModelList }, JsonRequestBehavior.AllowGet);
        }

        protected List<ReportAndProductTableViewModel> GenerateTablePagerData(StaticPagedList<ProductListDto> pagedList, string detailUrl)
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
                    Name = item.Title.Length > 28 ? item.Title.Substring(0, 28) + "..." : item.Title,
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
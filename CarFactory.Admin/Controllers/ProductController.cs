using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Abp.Application.Navigation;
using Abp.Application.Services.Dto;
using Abp.Domain.Uow;
using Abp.Runtime.Validation;
using Abp.Web.Models;
using Abp.Web.Mvc.Authorization;
using CarFactory.Admin.Helpers;
using CarFactory.Admin.Models;
using CarFactory.Admin.Models.Reports;
using CarFactory.Application.Category;
using CarFactory.Application.Products;
using CarFactory.Application.Products.Dtos;
using CarFactory.Core;
using CarFactory.Core.CustomDomain.Products.Authorization;
using X.PagedList;

namespace CarFactory.Admin.Controllers
{
    [AbpMvcAuthorize(ProductAppPermissions.Product)]
    [RoutePrefix("admin")]
    public class ProductController : CarFactoryControllerBase
    {
        private readonly IUserNavigationManager _userNavigationManager;

        private readonly IProductAppService _productAppService;
        private readonly ICategoryAppService _categoryAppService;

        public ProductController(ICategoryAppService categoryAppService,IProductAppService productAppService,IUserNavigationManager userNavigationManager) : base(userNavigationManager)
        {
            _categoryAppService = categoryAppService;
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
                catch (Exception e)
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


        [Route("products/detail/{id?}")]
        public ActionResult Detail(int? id)
        {
            ProductListDto info = new ProductListDto();

            if (id != null)
            {
                info = _productAppService.GetProductByIdAsync(new EntityDto<int>(id.Value)).Result;
            }

            var categoryList = _categoryAppService.GetCategorysOnShowAsync();
            ViewBag.CategoryList = categoryList.Result;

            var userMenu = GetUserMenu(PageNames.Products).Result;
            ViewBag.UserMenu = userMenu;

            return View(info);
        }

        [Route("products/save")]
        [HttpPost]
        public JsonResult Save(ProductEditDto editModel)
        {
            bool status = false;
            string msg = "";

            if (editModel.Id > 0)
            {
                try
                {
                    var oldReport = _productAppService.GetProductByIdAsync(new EntityDto<int>(editModel.Id.Value));
                    if (oldReport != null)
                    {
                        editModel.Img = oldReport.Result.Img;

                        ImgUploadHelpers uploadHelpers = new ImgUploadHelpers(Request.Files, Server.MapPath("/"));
                        var uploadResult = uploadHelpers.UploadImg();
                        if (uploadResult.Item1 == ImageUploadStatus.Success)
                        {
                            editModel.Img = uploadResult.Item2;

                            _productAppService.CreateOrUpdateProductAsync(
                                new CreateOrUpdateProductInput() { ProductEditDto = editModel });

                            status = true;
                        }
                        else if (uploadResult.Item1 == ImageUploadStatus.NoFile)
                        {
                            _productAppService.CreateOrUpdateProductAsync(
                                new CreateOrUpdateProductInput() { ProductEditDto = editModel });

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
                        editModel.Img = uploadResult.Item2;
                        editModel.IsShow = true;

                        _productAppService.CreateOrUpdateProductAsync(
                            new CreateOrUpdateProductInput() { ProductEditDto = editModel });

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
            return Json(new { status = status, message = msg });
        }
    }
}
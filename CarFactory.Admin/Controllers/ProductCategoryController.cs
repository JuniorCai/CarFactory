using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Abp.Application.Navigation;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Runtime.Validation;
using Abp.Web.Models;
using Abp.Web.Mvc.Authorization;
using CarFactory.Application.Category;
using CarFactory.Application.Category.Dtos;
using CarFactory.Core;
using CarFactory.Core.Authorization;
using CarFactory.Core.CustomDomain.Category.Authorization;
using X.PagedList;

namespace CarFactory.Admin.Controllers
{
    [RoutePrefix("admin")]
    [AbpMvcAuthorize(CategoryAppPermissions.Category)]
    public class ProductCategoryController : CarFactoryControllerBase
    {

        private readonly ICategoryAppService _categoryAppService;

        public ProductCategoryController(ICategoryAppService categoryAppService,IUserNavigationManager userNavigationManager) : base(userNavigationManager)
        {
            _categoryAppService = categoryAppService;
        }

        // GET: ProductCategory
        [Route("CategoryManage")]
        public ActionResult Index(int? page)
        {
            int pageIndex = (page ?? 1) - 1;

            GetCategoryInput input = new GetCategoryInput()
            {
                FilterText = "",
                MaxResultCount = CarFactoryConsts.MaxPageSize,
                SkipCount = pageIndex * CarFactoryConsts.MaxPageSize,
                Sorting = "sort"
            };

            var list = _categoryAppService.GetPagedCategorysAsync(input).Result;

            var pagedProducts = new StaticPagedList<CategoryListDto>(list.Items, pageIndex + 1, input.MaxResultCount,
                list.TotalCount);

            var userMenu = GetUserMenu(PageNames.ProductCategory).Result;
            ViewBag.UserMenu = userMenu;

            return View(pagedProducts);
        }


        [HttpPost]
        [Route("CategoryManage/delCategory")]
        public JsonResult DelCategory(int id = 0)
        {
            bool status = false;
            string msg = "";

            try
            {
                if (id > 0)
                {
                    _categoryAppService.DeleteCategoryAsync(new EntityDto(id));
                    status = true;
                }
            }
            catch (Exception e)
            {
                msg = "-1";
                status = false;
            }
            return Json(new {success = status});
        }

        [Route("CategoryManage/updateCategory")]
        public JsonResult UpdateCategory(CategoryEditDto categoryEdit)
        {
            bool status = false;
            string msg = "";

            CheckModelState();

            try
            {
                _categoryAppService.UpdateCategoryAsync(categoryEdit);
                status = true;
            }
            catch (Exception e)
            {
                msg = "-1";
                status = false;
            }
            return Json(new { success = status });
        }

        [Route("CategoryManage/addCategory")]
        public JsonResult AddCategory(CategoryEditDto categoryEdit)
        {
            bool status = false;
            string msg = "";

            CheckModelState();

            try
            {
                _categoryAppService.CreateCategoryAsync(categoryEdit);
                status = true;
            }
            catch (Exception e)
            {
                msg = "-1";
                status = false;
            }
            return Json(new { success = status });
        }
    }
}
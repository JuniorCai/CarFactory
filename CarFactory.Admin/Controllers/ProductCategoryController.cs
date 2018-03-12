using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Abp.Application.Navigation;
using Abp.Web.Mvc.Authorization;
using CarFactory.Application.Category;
using CarFactory.Application.Category.Dtos;
using CarFactory.Core;
using X.PagedList;

namespace CarFactory.Admin.Controllers
{
    [RoutePrefix("admin")]
    [AbpMvcAuthorize()]
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
                Sorting = "Id"
            };

            var list = _categoryAppService.GetPagedCategorysAsync(input).Result;

            var pagedProducts = new StaticPagedList<CategoryListDto>(list.Items, pageIndex + 1, input.MaxResultCount,
                list.TotalCount);

            var userMenu = GetUserMenu(PageNames.ProductCategory).Result;
            ViewBag.UserMenu = userMenu;

            return View(pagedProducts);
        }
    }
}
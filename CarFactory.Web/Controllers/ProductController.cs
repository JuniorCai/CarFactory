using Abp.Application.Services.Dto;
using CarFactory.Application.Category;
using CarFactory.Application.Category.Dtos;
using CarFactory.Application.Products;
using CarFactory.Application.Products.Dtos;
using CarFactory.Web.Models.Common;
using System.Linq;
using System.Web.Mvc;
using X.PagedList;

namespace CarFactory.Web.Controllers
{
    public class ProductController : CarFactoryControllerBase
    {
        private readonly IProductAppService _productAppService;

        private readonly ICategoryAppService _categoryAppService;


        public ProductController(IProductAppService productAppService,ICategoryAppService categoryAppService)
        {
            _productAppService = productAppService;
            _categoryAppService = categoryAppService;
        }


        public ActionResult List(int? page, string activeName = "")
        {
            CategoryListDto activeCategory = null;
            int pageIndex = ((page != null && page.Value >= 1) ? page.Value : 1) - 1;

            var categoryList = _categoryAppService.GetCategorysOnShowAsync().Result;
            activeCategory = categoryList.FirstOrDefault();
            ViewBag.ActiveCategory = activeCategory;

            if (!string.IsNullOrEmpty(activeName))
            {
                activeCategory = categoryList.FirstOrDefault(c => c.ShortName == activeName);
                if (activeCategory != null)
                {
                    ViewBag.ActiveCategory = activeCategory;
                }
            }

            GetProductInput pagedInput = new GetProductInput()
            {
                CategoryId = activeCategory.Id,
                Sorting = "CreationTime"
            };
            pagedInput.SkipCount = pageIndex * pagedInput.MaxResultCount;

            var products = _productAppService.GetPagedProductsAsync(pagedInput).Result;

            var pagedProducts = new StaticPagedList<ProductListDto>(products.Items, pageIndex + 1, pagedInput.MaxResultCount,
                products.TotalCount);


            return View(pagedProducts);
        }

        // GET: Product
        public ActionResult Detail(int id = 0)
        {
            EntityDto<int> input = new EntityDto<int>(){Id = id};
            PreAndNextNavModel<ProductListDto> dtoNavModel = new PreAndNextNavModel<ProductListDto>();

            var currentDto = _productAppService.GetProductByIdAsync(input).Result;

            if (currentDto != null)
            {
                dtoNavModel.CurrentItem = currentDto;
                var preDto = _productAppService.GetFirstOrDefaultAsync(p => p.CreationTime < currentDto.CreationTime)
                    .Result;

                var nextDto = _productAppService.GetFirstOrDefaultAsync(p => p.CreationTime > currentDto.CreationTime)
                    .Result;
                dtoNavModel.PreviousItem = preDto;
                dtoNavModel.NextItem = nextDto;
            }



            return View(dtoNavModel);
        }
    }
}
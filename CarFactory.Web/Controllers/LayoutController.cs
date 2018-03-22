using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Abp.Application.Navigation;
using Abp.Configuration;
using Abp.Configuration.Startup;
using Abp.Localization;
using Abp.Runtime.Session;
using Abp.Threading;
using CarFactory.Application.Category;
using CarFactory.Application.Category.Dtos;
using CarFactory.Application.Company;
using CarFactory.Application.Configuration.Ui;
using CarFactory.Application.Products;
using CarFactory.Application.Products.Dtos;
using CarFactory.Application.Seo;
using CarFactory.Application.Sessions;
using CarFactory.Core;
using CarFactory.Core.Configuration;
using CarFactory.Web.Models;
using CarFactory.Web.Models.Layout;

namespace CarFactory.Web.Controllers
{
    public class LayoutController : CarFactoryControllerBase
    {
        private readonly ICompanyAppService _companyAppService;
        private readonly IProductAppService _productAppService;
        private readonly ICategoryAppService _categoryAppService;

        public LayoutController(IProductAppService productAppService,
            ICategoryAppService categoryAppService,
            ICompanyAppService companyAppService,
            ISeoAppService seoAppService):base(seoAppService)
        {
            _companyAppService = companyAppService;
            _productAppService = productAppService;
            _categoryAppService = categoryAppService;
        }

        [ChildActionOnly]
        public PartialViewResult PartialFooter()
        {
            var company = _companyAppService.GetDefaultCompanyAsync();

            return PartialView("PartialPages/_PartialFooter", company.Result);
        }


        [ChildActionOnly]
        public async Task<PartialViewResult> PartialProducts()
        {
            GetProductInput defaultInput = new GetProductInput()
            {
                Status = true,
                MaxResultCount = CarFactoryConsts.MaxPageSize,
                Page = 1,
                SkipCount = 0
            };
            var products = await _productAppService.GetPagedProductsAsync(defaultInput);
            var categoryList = await _categoryAppService.GetCategorysOnShowAsync();
            foreach (CategoryListDto dto in categoryList)
            {
                var filterProducts = products.Items.Where(p => p.CategoryId == dto.Id).Take(5).ToList();
                dto.Products = filterProducts;
            }


            return PartialView("PartialPages/Home/_PartialProducts", categoryList);
        }



    }
}
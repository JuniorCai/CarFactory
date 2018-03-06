using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Abp.Application.Services.Dto;
using CarFactory.Application.Products;
using CarFactory.Application.Products.Dtos;
using CarFactory.Web.Models.Common;

namespace CarFactory.Web.Controllers
{
    public class ProductController : CarFactoryControllerBase
    {
        private readonly IProductAppService _productAppService;

        public ProductController(IProductAppService productAppService)
        {
            _productAppService = productAppService;
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
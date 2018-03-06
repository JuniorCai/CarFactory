using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Abp.Application.Services.Dto;
using CarFactory.Application.Category;
using CarFactory.Application.Category.Dtos;
using CarFactory.Web.Models.Layout;

namespace CarFactory.Web.Controllers
{
    public class WebLayoutController : CarFactoryControllerBase
    {

        private readonly ICategoryAppService _categoryAppService;

        public WebLayoutController(ICategoryAppService categoryAppService)
        {
            _categoryAppService = categoryAppService;
        }

        // GET: WebLayout
        public async Task<PartialViewResult> CategoryNav(string activeCategory = "")
        {
            
            var list = await _categoryAppService.GetCategorysOnShowAsync();

            RightSideCategoryNavViewModel categoryMenu = new RightSideCategoryNavViewModel()
            {
                ActiveCategoryShortName = activeCategory,
                CategoryMenu = list
            };

            return PartialView("PartialPages/_PartialCategoryList", categoryMenu);
        }
    }
}
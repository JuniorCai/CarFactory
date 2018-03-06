using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarFactory.Application.Category.Dtos;

namespace CarFactory.Web.Models.Layout
{
    public class RightSideCategoryNavViewModel
    {
        public List<CategoryListDto> CategoryMenu { get; set; }


        public string ActiveCategoryShortName { get; set; }
    }
}
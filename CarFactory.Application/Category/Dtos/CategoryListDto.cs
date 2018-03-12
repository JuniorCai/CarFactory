using System;
using System.ComponentModel;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace CarFactory.Application.Category.Dtos
{
    /// <summary>
    /// 产品类别列表Dto
    /// </summary>
    [AutoMapFrom(typeof(Core.CustomDomain.Category.Category))]
    public class CategoryListDto : EntityDto<int>
    {
        public string CategoryName { get; set; }
        public string ShortName { get; set; }
        public bool IsShow { get; set; }

        public int Sort { get; set; }

        //public      Product> Products { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [DisplayName("创建时间")]
        public DateTime CreationTime { get; set; }
    }
}

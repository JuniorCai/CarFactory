using System;
using System.ComponentModel;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using CarFactory.Core.CustomDomain.Products;

namespace CarFactory.Application.Products.Dtos
{
    /// <summary>
    /// 产品信息列表Dto
    /// </summary>
    [AutoMapFrom(typeof(Product))]
    public class ProductListDto : EntityDto<int>
    {
        /// <summary>
        /// 产品名称
        /// </summary>
        [DisplayName("产品名称")]
        public string Title { get; set; }

        /// <summary>
        /// 产品图片
        /// </summary>
        [DisplayName("产品图片")]
        public string Img { get; set; }

        /// <summary>
        /// 产品链接
        /// </summary>
        [DisplayName("产品链接")]
        public string Url { get; set; }

        /// <summary>
        /// 产品类别ID
        /// </summary>
        [DisplayName("产品类别ID")]
        public int CategoryId { get; set; }

        /// <summary>
        /// 产品类别
        /// </summary>
        [DisplayName("产品类别")]
        public Core.CustomDomain.Category.Category ProductCategory { get; set; }

        /// <summary>
        /// 是否可见
        /// </summary>
        [DisplayName("是否可见")]
        public bool IsShow { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [DisplayName("创建时间")]
        public DateTime CreationTime { get; set; }

        [DisplayName("产品详情")]
        public string Detail { get; set; }
    }
}

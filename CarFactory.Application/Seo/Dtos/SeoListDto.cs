using System;
using System.ComponentModel;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;


namespace CarFactory.Application.Seo.Dtos
{
    /// <summary>
    /// SEO设置列表Dto
    /// </summary>
    [AutoMapFrom(typeof(Core.CustomDomain.Seo.Seo))]
    public class SeoListDto : EntityDto<int>
    {
        /// <summary>
        /// 开启水印
        /// </summary>
        [DisplayName("开启水印")]
        public bool WatermarkAble { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [DisplayName("创建时间")]
        public DateTime CreationTime { get; set; }
    }
}

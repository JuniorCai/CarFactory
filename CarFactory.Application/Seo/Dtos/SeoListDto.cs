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
        public virtual string SiteTitle { get; set; }


        public virtual string SiteKeywords { get; set; }

        public virtual string SiteDescription { get; set; }

        public virtual string SiteBannerImgs { get; set; }


        /// <summary>
        /// 开启水印
        /// </summary>
        [DisplayName("开启水印")]
        public bool WatermarkAble { get; set; }

        public virtual string Watermark { get; set; }

        public virtual string IcpNumber { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [DisplayName("创建时间")]
        public DateTime CreationTime { get; set; }
    }
}

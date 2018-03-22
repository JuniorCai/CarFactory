using System;
using System.ComponentModel;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;


namespace CarFactory.Application.Banner.Dtos
{
    /// <summary>
    /// 首页Banner列表Dto
    /// </summary>
    [AutoMapFrom(typeof(Core.CustomDomain.Banner.Banner))]
    public class BannerListDto : EntityDto<int>
    {
        public string Img { get; set; }
        public string ImgAlt { get; set; }
        public string ImgTitle { get; set; }
        public int Sort { get; set; }

        public bool IsShow { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [DisplayName("创建时间")]
        public DateTime CreationTime { get; set; }
    }
}

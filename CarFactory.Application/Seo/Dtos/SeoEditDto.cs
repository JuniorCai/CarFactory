using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Abp.AutoMapper;

namespace CarFactory.Application.Seo.Dtos
{
    /// <summary>
    /// SEO设置编辑用Dto
    /// </summary>
    [AutoMap(typeof(Core.CustomDomain.Seo.Seo))]
    public class SeoEditDto
    {

        /// <summary>
        ///   主键Id
        /// </summary>
        [DisplayName("主键Id")]
        public int? Id { get; set; }

        /// <summary>
        /// 网站名称
        /// </summary>
        [DisplayName("网站名称")]
        [Required]
        [MaxLength(50)]
        public string SiteTitle { get; set; }

        /// <summary>
        /// 网站关键词
        /// </summary>
        [DisplayName("网站关键词")]
        [MaxLength(200)]
        public string SiteKeywords { get; set; }

        /// <summary>
        /// 网站描述
        /// </summary>
        [DisplayName("网站描述")]
        [MaxLength(1000)]
        public string SiteDescription { get; set; }

        /// <summary>
        /// 首页Banner
        /// </summary>
        [DisplayName("首页Banner")]
        [Required]
        [MaxLength(1000)]
        public string SiteBannerImgs { get; set; }

        /// <summary>
        /// 开启水印
        /// </summary>
        [DisplayName("开启水印")]
        [Required]
        public bool WatermarkAble { get; set; }

        /// <summary>
        /// 水印名称
        /// </summary>
        [DisplayName("水印名称")]
        [MaxLength(50)]
        public string Watermark { get; set; }

        /// <summary>
        /// ICP备案序号
        /// </summary>
        [DisplayName("ICP备案序号")]
        [MaxLength(50)]
        public string IcpNumber { get; set; }

    }
}

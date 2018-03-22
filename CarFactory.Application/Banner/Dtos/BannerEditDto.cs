using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Abp.AutoMapper;


namespace CarFactory.Application.Banner.Dtos
{
    /// <summary>
    /// 首页Banner编辑用Dto
    /// </summary>
    [AutoMap(typeof(Core.CustomDomain.Banner.Banner))]
    public class BannerEditDto
    {

        /// <summary>
        ///   主键Id
        /// </summary>
        [DisplayName("主键Id")]
        public int? Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Img { get; set; }

        [Required]
        [MaxLength(50)]
        public string ImgAlt { get; set; }

        [Required]
        [MaxLength(50)]
        public string ImgTitle { get; set; }

        public bool IsShow { get; set; }

        public int Sort { get; set; }

    }
}

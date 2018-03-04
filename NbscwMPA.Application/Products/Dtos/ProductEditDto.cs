using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Abp.AutoMapper;
using NbscwMPACarFactory.CustomDomain.Products;

namespace NbscwMPACarFactory.Products.Dtos
{
    /// <summary>
    /// 产品信息编辑用Dto
    /// </summary>
    [AutoMap(typeof(Product))]
    public class ProductEditDto
    {

        /// <summary>
        ///   主键Id
        /// </summary>
        [DisplayName("主键Id")]
        public int? Id { get; set; }

        /// <summary>
        /// 产品名称
        /// </summary>
        [DisplayName("产品名称")]
        [Required]
        public string Title { get; set; }

        /// <summary>
        /// 产品图片
        /// </summary>
        [DisplayName("产品图片")]
        [Required]
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
        [Required]
        public int CategoryId { get; set; }

        /// <summary>
        /// 是否可见
        /// </summary>
        [DisplayName("是否可见")]
        [Required]
        public bool IsShow { get; set; }

    }
}

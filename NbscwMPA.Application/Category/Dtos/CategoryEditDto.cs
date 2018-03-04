using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Abp.AutoMapper;


namespace NbscwMPACarFactory.Category.Dtos
{
    /// <summary>
    /// 产品类别编辑用Dto
    /// </summary>
    [AutoMap(typeof(CustomDomain.Category.Category))]
    public class CategoryEditDto
    {

        /// <summary>
        ///   主键Id
        /// </summary>
        [DisplayName("主键Id")]
        public int? Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string ShortName { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public int Sort { get; set; }

    }
}

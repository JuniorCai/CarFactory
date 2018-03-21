using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Abp.AutoMapper;

namespace CarFactory.Application.Company.Dtos
{
    /// <summary>
    /// 公司信息编辑用Dto
    /// </summary>
    [AutoMap(typeof(Core.CustomDomain.Company.Company))]
    public class CompanyEditDto
    {

        /// <summary>
        ///   主键Id
        /// </summary>
        [DisplayName("主键Id")]
        public int? Id { get; set; }

        [Required]
        public string CompanyName { get; set; }

        public string LinkMan { get; set; }


        public string Phone { get; set; }

        public string Tel { get; set; }

        public string Email { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Longitude { get; set; }

        [Required]
        public string Latitude { get; set; }

    }
}

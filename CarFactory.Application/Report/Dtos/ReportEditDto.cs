using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Abp.AutoMapper;


namespace CarFactory.Application.Report.Dtos
{
    /// <summary>
    /// 检测报告编辑用Dto
    /// </summary>
    [AutoMap(typeof(Core.CustomDomain.Report.Report))]
    public class ReportEditDto
    {

        /// <summary>
        ///   主键Id
        /// </summary>
        [DisplayName("主键Id")]
        public int? Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string ReportName { get; set; }

        [Required]
        [MaxLength(200)]
        public string Img { get; set; }

        public string RelativeId { get; set; }

    }
}

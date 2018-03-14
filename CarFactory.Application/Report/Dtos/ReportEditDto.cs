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
        [MinLength(2)]
        public string ReportName { get; set; }

        public string Img { get; set; }


        public string RelativeId { get; set; }

    }

    /// <summary>
    /// 图片上传状态枚举
    /// </summary>
    public enum ImageUploadStatus
    {
        WaittingUpload,
        Success,
        Failed
    }
}

using System;
using System.ComponentModel;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;


namespace CarFactory.Application.Report.Dtos
{
    /// <summary>
    /// 检测报告列表Dto
    /// </summary>
    [AutoMapFrom(typeof(Core.CustomDomain.Report.Report))]
    public class ReportListDto : EntityDto<int>
    {
        public string ReportName { get; set; }
        public string Img { get; set; }
        public string RelativeId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [DisplayName("创建时间")]
        public DateTime CreationTime { get; set; }
    }
}

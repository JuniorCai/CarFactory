
namespace CarFactory.Application.Report.Dtos
{
    /// <summary>
    /// 检测报告新增和编辑时用Dto
    /// </summary>

    public class CreateOrUpdateReportInput
    {
        /// <summary>
        /// 检测报告编辑Dto
        /// </summary>
        public ReportEditDto ReportEditDto { get; set; }

    }
}

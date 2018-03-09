using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using CarFactory.Application.Report.Dtos;

namespace CarFactory.Application.Report
{
    /// <summary>
    /// 检测报告服务接口
    /// </summary>
    public interface IReportAppService : IApplicationService
    {
        #region 检测报告管理

        /// <summary>
        /// 根据查询条件获取第一个或默认对象
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<ReportListDto> GetFirstOrDefaultAsync(Expression<Func<Core.CustomDomain.Report.Report, bool>> predicate);


        /// <summary>
        /// 根据查询条件获取检测报告分页列表
        /// </summary>
        Task<PagedResultDto<ReportListDto>> GetPagedReportsAsync(GetReportInput input);

        /// <summary>
        /// 通过Id获取检测报告信息进行编辑或修改 
        /// </summary>
        Task<GetReportForEditOutput> GetReportForEditAsync(NullableIdDto<int> input);

        /// <summary>
        /// 通过指定id获取检测报告ListDto信息
        /// </summary>
        Task<ReportListDto> GetReportByIdAsync(EntityDto<int> input);


        /// <summary>
        /// 新增或更改检测报告
        /// </summary>
        Task CreateOrUpdateReportAsync(CreateOrUpdateReportInput input);


        /// <summary>
        /// 新增检测报告
        /// </summary>
        Task<ReportEditDto> CreateReportAsync(ReportEditDto input);

        /// <summary>
        /// 更新检测报告
        /// </summary>
        Task UpdateReportAsync(ReportEditDto input);

        /// <summary>
        /// 删除检测报告
        /// </summary>
        Task DeleteReportAsync(EntityDto<int> input);

        /// <summary>
        /// 批量删除检测报告
        /// </summary>
        Task BatchDeleteReportAsync(List<int> input);

        #endregion
    }
}

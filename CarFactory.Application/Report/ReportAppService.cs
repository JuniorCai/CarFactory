using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using CarFactory.Application.Report.Dtos;
using CarFactory.Core.CustomDomain.Report;
using CarFactory.Core.CustomDomain.Report.Authorization;


namespace CarFactory.Application.Report
{
    /// <summary>
    /// 检测报告服务实现
    /// </summary>
    //[AbpAuthorize(ReportAppPermissions.Report)]
    public class ReportAppService : CarFactoryAppServiceBase, IReportAppService
    {
        private readonly IRepository<Core.CustomDomain.Report.Report, int> _reportRepository;


        private readonly ReportManage _reportManage;

        /// <summary>
        /// 构造方法
        /// </summary>
        public ReportAppService(IRepository<Core.CustomDomain.Report.Report, int> reportRepository,
            ReportManage reportManage

        )
        {
            _reportRepository = reportRepository;
            _reportManage = reportManage;

        }


        #region 实体的自定义扩展方法

        private IQueryable<Core.CustomDomain.Report.Report> _reportRepositoryAsNoTrack =>
            _reportRepository.GetAll().AsNoTracking();


        #endregion


        #region 检测报告管理


        public async Task<ReportListDto> GetFirstOrDefaultAsync<TOrderKey>(Expression<Func<Core.CustomDomain.Report.Report, bool>> predicate, Func<Core.CustomDomain.Report.Report, TOrderKey> orderPredicate,bool isAsc)
        {
            var entityTask = await _reportRepository.GetAllListAsync(predicate);
            
            Core.CustomDomain.Report.Report entity = isAsc? entityTask.OrderBy(orderPredicate).FirstOrDefault(): entityTask.OrderByDescending(orderPredicate).FirstOrDefault();
            ReportListDto infoDto = entity.MapTo<ReportListDto>();
            return infoDto;

        }


        /// <summary>
        /// 根据查询条件获取检测报告分页列表
        /// </summary>
        public async Task<PagedResultDto<ReportListDto>> GetPagedReportsAsync(GetReportInput input)
        {

            var query = _reportRepositoryAsNoTrack;
            //TODO:根据传入的参数添加过滤条件

            query = query.WhereIf(!string.IsNullOrEmpty(input.FilterText),
                    p => p.ReportName.Contains(input.FilterText))
                .WhereIf(input.Id != null, p => p.Id == input.Id)
                .WhereIf(input.Status != null, p => p.IsShow == input.Status)
                .WhereIf(input.BeginDate != null, p => p.CreationTime >= input.BeginDate)
                .WhereIf(input.EndDate != null, p => p.CreationTime <= input.EndDate);


            var reportCount = await query.CountAsync();

            var reports = await query.OrderBy(input.Sorting).PageBy(input).ToListAsync();

            var reportListDtos = reports.MapTo<List<ReportListDto>>();
            return new PagedResultDto<ReportListDto>(
                reportCount,
                reportListDtos
            );
        }

        /// <summary>
        /// 通过Id获取检测报告信息进行编辑或修改 
        /// </summary>
        public async Task<GetReportForEditOutput> GetReportForEditAsync(NullableIdDto<int> input)
        {
            var output = new GetReportForEditOutput();

            ReportEditDto reportEditDto;

            if (input.Id.HasValue)
            {
                var entity = await _reportRepository.GetAsync(input.Id.Value);
                reportEditDto = entity.MapTo<ReportEditDto>();
            }
            else
            {
                reportEditDto = new ReportEditDto();
            }

            output.Report = reportEditDto;
            return output;
        }


        /// <summary>
        /// 通过指定id获取检测报告ListDto信息
        /// </summary>
        public async Task<ReportListDto> GetReportByIdAsync(EntityDto<int> input)
        {
            var entity = await _reportRepository.GetAsync(input.Id);

            return entity.MapTo<ReportListDto>();
        }



        /// <summary>
        /// 新增或更改检测报告
        /// </summary>
        public async Task CreateOrUpdateReportAsync(CreateOrUpdateReportInput input)
        {
            if (input.ReportEditDto.Id.HasValue && input.ReportEditDto.Id > 0)
            {
                await UpdateReportAsync(input.ReportEditDto);
            }
            else
            {
                await CreateReportAsync(input.ReportEditDto);
            }
        }

        /// <summary>
        /// 新增检测报告
        /// </summary>
        //[AbpAuthorize(ReportAppPermissions.Report_CreateReport)]
        public virtual async Task<ReportEditDto> CreateReportAsync(ReportEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增

            var entity = input.MapTo<Core.CustomDomain.Report.Report>();

            entity = await _reportRepository.InsertAsync(entity);
            return entity.MapTo<ReportEditDto>();
        }

        /// <summary>
        /// 编辑检测报告
        /// </summary>
        //[AbpAuthorize(ReportAppPermissions.Report_EditReport)]
        public virtual async Task UpdateReportAsync(ReportEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新

            var entity = await _reportRepository.GetAsync(input.Id.Value);
            input.MapTo(entity);

            await _reportRepository.UpdateAsync(entity);
        }


        public virtual async Task BatchUpdateStatusAsync(List<int> input,bool status)
        {
            foreach (var report in _reportRepository.GetAll().Where(r=> input.Contains(r.Id)).ToList())
            {
                report.IsShow = status;
                await _reportRepository.UpdateAsync(report);
            }
        }

        /// <summary>
        /// 删除检测报告
        /// </summary>
        [AbpAuthorize(ReportAppPermissions.Report_DeleteReport)]
        public async Task DeleteReportAsync(EntityDto<int> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _reportRepository.DeleteAsync(input.Id);
        }

        /// <summary>
        /// 批量删除检测报告
        /// </summary>
        [AbpAuthorize(ReportAppPermissions.Report_DeleteReport)]
        public async Task BatchDeleteReportAsync(List<int> input)
        {
            //TODO:批量删除前的逻辑判断，是否允许删除
            await _reportRepository.DeleteAsync(s => input.Contains(s.Id));
        }

        #endregion

    }
}

                          
 
using Abp.Domain.Repositories;
using Abp.Domain.Services;
using System;

namespace CarFactory.Core.CustomDomain.Report
{
    /// <summary>
    /// 检测报告业务管理
    /// </summary>
    public class ReportManage : IDomainService
    {
        private readonly IRepository<Report, int> _reportRepository;

        /// <summary>
        /// 构造方法
        /// </summary>
        public ReportManage(IRepository<Report, int> reportRepository)
        {
            _reportRepository = reportRepository;
        }

        //TODO:编写领域业务代码


        /// <summary>
        ///     初始化
        /// </summary>
        private void Init()
        {




        }


    }
}

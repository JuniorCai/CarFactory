using System.Data.Entity.ModelConfiguration;
using CarFactory.Core;
using CarFactory.EntityFramework.EntityFramework;

namespace CarFactory.EntityFramework.EntityMapper.Report
{

    /// <summary>
    /// 检测报告的数据配置文件
    /// </summary>
    public class ReportCfg : EntityTypeConfiguration<Core.CustomDomain.Report.Report>
    {
        /// <summary>
        ///  构造方法[默认链接字符串< see cref = "CarFactoryDbContext" /> ]
        /// </summary>
        public ReportCfg()
        {
            ToTable("Report", CarFactoryConsts.SchemaName.Basic);

            
            // ReportName
            Property(a => a.ReportName).HasMaxLength(50);
            // Img
            Property(a => a.Img).HasMaxLength(100);
            // RelativeId
            Property(a => a.RelativeId).HasMaxLength(11);
        }
    }
}
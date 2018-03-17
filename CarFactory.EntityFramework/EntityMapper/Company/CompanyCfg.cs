using System.Data.Entity.ModelConfiguration;
using CarFactory.Core;
using CarFactory.EntityFramework.EntityFramework;

namespace CarFactory.EntityFramework.EntityMapper.Company
{

    /// <summary>
    /// 公司信息的数据配置文件
    /// </summary>
    public class CompanyCfg : EntityTypeConfiguration<Core.CustomDomain.Company.Company>
    {
        /// <summary>
        ///  构造方法[默认链接字符串< see cref = "CarFactoryDbContext" /> ]
        /// </summary>
        public CompanyCfg()
        {
            ToTable("Company", CarFactoryConsts.SchemaName.Basic);

            // CompanyName
            Property(a => a.CompanyName).HasMaxLength(4000);
            // Phone
            Property(a => a.Phone).HasMaxLength(20);
            // Tel
            Property(a => a.Tel).HasMaxLength(20);
            // Email
            Property(a => a.Email).HasMaxLength(50);
            // Address
            Property(a => a.Address).HasMaxLength(100);
            // Longitude
            Property(a => a.Longitude).HasMaxLength(100);
            // Latitude
            Property(a => a.Latitude).HasMaxLength(100);
        }
    }
}
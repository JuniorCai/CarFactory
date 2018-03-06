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
            Property(a => a.Phone).HasMaxLength(4000);
            // Tel
            Property(a => a.Tel).HasMaxLength(4000);
            // Email
            Property(a => a.Email).HasMaxLength(4000);
            // Address
            Property(a => a.Address).HasMaxLength(4000);
            // Longitude
            Property(a => a.Longitude).HasMaxLength(4000);
            // Latitude
            Property(a => a.Latitude).HasMaxLength(4000);
        }
    }
}
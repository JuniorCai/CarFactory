using System.Data.Entity.ModelConfiguration;
using CarFactory.Core;
using CarFactory.EntityFramework.EntityFramework;


namespace CarFactory.EntityFramework.EntityMapper.Seo
{

    /// <summary>
    /// SEO设置的数据配置文件
    /// </summary>
    public class SeoCfg : EntityTypeConfiguration<Core.CustomDomain.Seo.Seo>
    {
        /// <summary>
        ///  构造方法[默认链接字符串< see cref = "CarFactoryDbContext" /> ]
        /// </summary>
        public SeoCfg()
        {
            ToTable("Seo", CarFactoryConsts.SchemaName.Basic);



            // 网站名称
            Property(a => a.SiteTitle).HasMaxLength(50);
            // 网站关键词
            Property(a => a.SiteKeywords).HasMaxLength(200);
            // 网站描述
            Property(a => a.SiteDescription).HasMaxLength(1000);

            // 水印名称
            Property(a => a.Watermark).HasMaxLength(50);
            // ICP备案序号
            Property(a => a.IcpNumber).HasMaxLength(50);
        }
    }
}
using System.Data.Entity.ModelConfiguration;
using CarFactory.Core;
using CarFactory.EntityFramework.EntityFramework;

namespace CarFactory.EntityFramework.EntityMapper.Banner
{

    /// <summary>
    /// 首页Banner的数据配置文件
    /// </summary>
    public class BannerCfg : EntityTypeConfiguration<Core.CustomDomain.Banner.Banner>
    {
        /// <summary>
        ///  构造方法[默认链接字符串< see cref = "CarFactoryDbContext" /> ]
        /// </summary>
        public BannerCfg()
        {
            ToTable("Banner", CarFactoryConsts.SchemaName.Basic);

            // Img
            Property(a => a.Img).HasMaxLength(50);
            // ImgAlt
            Property(a => a.ImgAlt).HasMaxLength(50);
            // ImgTitle
            Property(a => a.ImgTitle).HasMaxLength(50);
        }
    }
}
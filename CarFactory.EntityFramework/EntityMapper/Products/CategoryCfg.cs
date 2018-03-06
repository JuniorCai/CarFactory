using System.Data.Entity.ModelConfiguration;
using CarFactory.Core;
using CarFactory.Core.CustomDomain.Category;
using CarFactory.EntityFramework.EntityFramework;

namespace CarFactory.EntityFramework.EntityMapper.Products
{

    /// <summary>
    /// 产品类别的数据配置文件
    /// </summary>
    public class CategoryCfg : EntityTypeConfiguration<Category>
    {
        /// <summary>
        ///  构造方法[默认链接字符串< see cref = "CarFactoryDbContext" /> ]
        /// </summary>
        public CategoryCfg()
        {
            ToTable("Category", CarFactoryConsts.SchemaName.Basic);


            // Name
            Property(a => a.CategoryName).HasMaxLength(4000);
            // ShortName
            Property(a => a.ShortName).HasMaxLength(4000);
            // Products - 关系映射
            //HasOptional(a => a.Products).WithMany().HasForeignKey(c => c.ProductsId).WillCascadeOnDelete(true);


        }
    }
}
﻿                          
   using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using Abp.Application.Services.Dto;
using Abp.Extensions;
using NbscwMPACarFactory.CustomDomain.Products;

namespace NbscwMPACarFactory.CustomDomain.Products.EntityMapper.Products
{

    /// <summary>
    /// 产品信息的数据配置文件
    /// </summary>
    public class ProductCfg : EntityTypeConfiguration<Product>
    {
        /// <summary>
        ///  构造方法[默认链接字符串< see cref = "CustomDomainDbContext" /> ]
        /// </summary>
        public ProductCfg()
        {
            ToTable("Product", CarFactoryConsts.SchemaName.Basic);



            // 产品名称
            Property(a => a.Title).HasMaxLength(4000);
            // 产品图片
            Property(a => a.Img).HasMaxLength(4000);
            // 产品链接
            Property(a => a.Url).HasMaxLength(4000);
            // 产品类别 - 关系映射
            HasRequired(a => a.ProductCategory).WithMany().HasForeignKey(c => c.CategoryId).WillCascadeOnDelete(true);


        }
    }
}
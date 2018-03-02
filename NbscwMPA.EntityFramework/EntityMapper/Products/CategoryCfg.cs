                          
   using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using Abp.Application.Services.Dto;
using Abp.Extensions;
using NbscwMPACarFactory.CustomDomain.Products;
 #region 代码生成器相关信息_ABP Code Generator Info
   //你好，我是ABP代码生成器的作者,欢迎您使用该工具，目前接受付费定制该工具，有需要的可以联系我
   //我的邮箱:werltm@hotmail.com
   // 官方网站:"http://www.yoyocms.com"
 // 交流QQ群：104390185  
 //微信公众号：角落的白板报
// 演示地址:"vue版本：http://vue.yoyocms.com angularJs版本:ng1.yoyocms.com"
//博客地址：http://www.cnblogs.com/wer-ltm/
//代码生成器帮助文档：http://www.cnblogs.com/wer-ltm/p/5777190.html
// <Author-作者>梁桐铭 ,微软MVP</Author-作者>
// Copyright © YoYoCms@China.2018-03-02T16:39:09. All Rights Reserved.
//<生成时间>2018-03-02T16:39:09</生成时间>
	#endregion
namespace NbscwMPACarFactory.CustomDomain.Products.EntityMapper.Products
{

	/// <summary>
    /// 产品类别的数据配置文件
    /// </summary>
    public class CategoryCfg : EntityTypeConfiguration<Category>
    {
		/// <summary>
        ///  构造方法[默认链接字符串< see cref = "CustomDomainDbContext" /> ]
        /// </summary>
		public CategoryCfg ()
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
                          
   using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using Abp.Application.Services.Dto;
using Abp.Extensions;
using NbscwMPA.Messages;
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
// Copyright © YoYoCms@China.2018-02-18T12:16:47. All Rights Reserved.
//<生成时间>2018-02-18T12:16:47</生成时间>
	#endregion
namespace NbscwMPA.Messages.EntityMapper.Messages
{

	/// <summary>
    /// 的数据配置文件
    /// </summary>
    public class MessageCfg : EntityTypeConfiguration<Message>
    {
		/// <summary>
        ///  构造方法[默认链接字符串< see cref = "NbscwMPADbContext" /> ]
        /// </summary>
		public MessageCfg ()
		{
		            ToTable("Message", NbscwMPAConsts.SchemaName.Basic);
 
      //todo: 需要将以下文件注入到NbscwMPADbContext中

  //		public IDbSet<Message> Messages { get; set; }
   //		 modelBuilder.Configurations.Add(new MessageCfg());




		    // 消息标题
			Property(a => a.Title).HasMaxLength(4000);
		    // 内容
			Property(a => a.Detail).HasMaxLength(255);
		    // 发件人IP
			Property(a => a.SendIp).HasMaxLength(4000);
		}
    }
}
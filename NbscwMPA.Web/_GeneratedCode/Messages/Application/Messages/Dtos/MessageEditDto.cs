                          
  
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Abp.AutoMapper;
using Abp.Runtime.Validation;
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
// Copyright © YoYoCms@China.2018-02-18T12:16:41. All Rights Reserved.
//<生成时间>2018-02-18T12:16:41</生成时间>
	#endregion
namespace NbscwMPA.Messages.Dtos
{
    [AutoMap(typeof(Message))]
    public class MessageEditDto 
    {

	/// <summary>
    ///   主键Id
    /// </summary>
    [DisplayName("主键Id")]
	public int? Id{get;set;}

        /// <summary>
        /// 消息标题
        /// </summary>
        [DisplayName("消息标题")]
        [Required]
        public   string  Title { get; set; }

        /// <summary>
        /// 消息类型
        /// </summary>
        [DisplayName("消息类型")]
        public   int  TypeId { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        [DisplayName("内容")]
        [Required]
        [MaxLength(255)]
        public   string  Detail { get; set; }

        /// <summary>
        /// 发件人ID
        /// </summary>
        [DisplayName("发件人ID")]
        [Required]
        public   int  SenderId { get; set; }

        /// <summary>
        /// 收件人ID
        /// </summary>
        [DisplayName("收件人ID")]
        [Required]
        public   int  RecipientId { get; set; }

        /// <summary>
        /// 是否已发送
        /// </summary>
        [DisplayName("是否已发送")]
        public   int  IsSend { get; set; }

        /// <summary>
        /// 是否已阅读
        /// </summary>
        [DisplayName("是否已阅读")]
        public   int  IsRead { get; set; }

        /// <summary>
        /// 是否进入回收站
        /// </summary>
        [DisplayName("是否进入回收站")]
        public   int  InRecycle { get; set; }

    }
}

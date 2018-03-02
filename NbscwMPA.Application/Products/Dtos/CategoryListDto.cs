﻿                            
using System;
using System.ComponentModel;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
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
// Copyright © YoYoCms@China.2018-03-02T16:38:58. All Rights Reserved.
//<生成时间>2018-03-02T16:38:58</生成时间>
	#endregion
namespace NbscwMPACarFactory.CustomDomain.Products.Dtos
{
	/// <summary>
    /// 产品类别列表Dto
    /// </summary>
    [AutoMapFrom(typeof(Category))]
    public class CategoryListDto : EntityDto<int>
    {
        public      string Name { get; set; }
        public      string ShortName { get; set; }
        public      bool IsActive { get; set; }
        public      int Sort { get; set; }
        //public      Product> Products { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [DisplayName("创建时间")]
        public      DateTime CreationTime { get; set; }
    }
}

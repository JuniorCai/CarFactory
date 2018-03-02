                           
 
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using NbscwMPACarFactory.CustomDomain.Products.Dtos;
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
// Copyright © YoYoCms@China.2018-03-02T16:39:03. All Rights Reserved.
//<生成时间>2018-03-02T16:39:03</生成时间>
	#endregion
namespace NbscwMPACarFactory.CustomDomain.Products
{
	/// <summary>
    /// 产品类别服务接口
    /// </summary>
    public interface ICategoryAppService : IApplicationService
    {
        #region 产品类别管理

        /// <summary>
        /// 根据查询条件获取产品类别分页列表
        /// </summary>
        //Task<PagedResultDto<CategoryListDto>> GetPagedCategorysAsync(GetCategoryInput input);

        /// <summary>
        /// 通过Id获取产品类别信息进行编辑或修改 
        /// </summary>
        Task<GetCategoryForEditOutput> GetCategoryForEditAsync(NullableIdDto<int> input);

		  /// <summary>
        /// 通过指定id获取产品类别ListDto信息
        /// </summary>
		Task<CategoryListDto> GetCategoryByIdAsync(EntityDto<int> input);



        /// <summary>
        /// 新增或更改产品类别
        /// </summary>
        Task CreateOrUpdateCategoryAsync(CreateOrUpdateCategoryInput input);





        /// <summary>
        /// 新增产品类别
        /// </summary>
        Task<CategoryEditDto> CreateCategoryAsync(CategoryEditDto input);

        /// <summary>
        /// 更新产品类别
        /// </summary>
        Task UpdateCategoryAsync(CategoryEditDto input);

        /// <summary>
        /// 删除产品类别
        /// </summary>
        Task DeleteCategoryAsync(EntityDto<int> input);

        /// <summary>
        /// 批量删除产品类别
        /// </summary>
        Task BatchDeleteCategoryAsync(List<int> input);

        #endregion




    }
}

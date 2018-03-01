                           
 
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using NbscwMPA.Messages.Dtos;
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
// Copyright © YoYoCms@China.2018-02-18T12:16:44. All Rights Reserved.
//<生成时间>2018-02-18T12:16:44</生成时间>
	#endregion
namespace NbscwMPA.Messages
{
	/// <summary>
    /// 服务接口
    /// </summary>
    public interface IMessageAppService : IApplicationService
    {
        #region 管理

        /// <summary>
        /// 根据查询条件获取分页列表
        /// </summary>
        Task<PagedResultDto<MessageListDto>> GetPagedMessagesAsync(GetMessageInput input);

        /// <summary>
        /// 通过Id获取信息进行编辑或修改 
        /// </summary>
        Task<GetMessageForEditOutput> GetMessageForEditAsync(NullableIdDto<int> input);

		  /// <summary>
        /// 通过指定id获取ListDto信息
        /// </summary>
		Task<MessageListDto> GetMessageByIdAsync(EntityDto<int> input);



        /// <summary>
        /// 新增或更改
        /// </summary>
        Task CreateOrUpdateMessageAsync(CreateOrUpdateMessageInput input);





        /// <summary>
        /// 新增
        /// </summary>
        Task<MessageEditDto> CreateMessageAsync(MessageEditDto input);

        /// <summary>
        /// 更新
        /// </summary>
        Task UpdateMessageAsync(MessageEditDto input);

        /// <summary>
        /// 删除
        /// </summary>
        Task DeleteMessageAsync(EntityDto<int> input);

        /// <summary>
        /// 批量删除
        /// </summary>
        Task BatchDeleteMessageAsync(List<int> input);

        #endregion




    }
}

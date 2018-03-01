                                
                            
                                 
     
        

	using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Dynamic;
    using System.Text;
    using System.Threading.Tasks;
    using Abp;
    using Abp.Application.Services.Dto;
    using Abp.Authorization;
    using Abp.AutoMapper;
    using Abp.Configuration;
    using Abp.Domain.Repositories;
    using Abp.Extensions;
    using Abp.Linq.Extensions;
	  using NbscwMPA.Messages.Authorization;  
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
    /// 服务实现
    /// </summary>
          [AbpAuthorize(MessageAppPermissions.Message)]
		 
       
    public class MessageAppService : NbscwMPAAppServiceBase, IMessageAppService
    {
        private readonly IRepository<Message,int> _messageRepository;
		

		private readonly MessageManage _messageManage;
        /// <summary>
        /// 构造方法
        /// </summary>
        public MessageAppService( IRepository<Message,int> messageRepository	,
MessageManage messageManage
	
  )
        {
            _messageRepository = messageRepository;
			 _messageManage = messageManage;
			 
        }


		  #region 实体的自定义扩展方法
        private IQueryable<Message> _messageRepositoryAsNoTrack => _messageRepository.GetAll().AsNoTracking();


        #endregion


    #region 管理

    /// <summary>
    /// 根据查询条件获取分页列表
    /// </summary>
    public async Task<PagedResultDto<MessageListDto>> GetPagedMessagesAsync(GetMessageInput input)
{
			
    var query = _messageRepositoryAsNoTrack;
    //TODO:根据传入的参数添加过滤条件

    var messageCount = await query.CountAsync();

    var messages = await query
    .OrderBy(input.Sorting)
    .PageBy(input)
    .ToListAsync();

    var messageListDtos = messages.MapTo<List<MessageListDto>>();
    return new PagedResultDto<MessageListDto>(
    messageCount,
    messageListDtos
    );
    }

        /// <summary>
    /// 通过Id获取信息进行编辑或修改 
    /// </summary>
    public async Task<GetMessageForEditOutput> GetMessageForEditAsync(NullableIdDto<int> input)
{
    var output=new GetMessageForEditOutput();

    MessageEditDto messageEditDto;

    if(input.Id.HasValue)
	{
    var entity=await _messageRepository.GetAsync(input.Id.Value);
    messageEditDto=entity.MapTo<MessageEditDto>();
    }
	else 
	{
	messageEditDto=new MessageEditDto();	
	}

	output.Message=messageEditDto;
	return output;
    }


    /// <summary>
    /// 通过指定id获取ListDto信息
    /// </summary>
    public async Task<MessageListDto> GetMessageByIdAsync(EntityDto<int> input)
{
    var entity = await _messageRepository.GetAsync(input.Id);

    return entity.MapTo<MessageListDto>();
    }







    /// <summary>
    /// 新增或更改
    /// </summary>
    public async Task CreateOrUpdateMessageAsync(CreateOrUpdateMessageInput input)
{
    if (input.MessageEditDto.Id.HasValue)
{
    await UpdateMessageAsync(input.MessageEditDto);
    }
    else
{
    await CreateMessageAsync(input.MessageEditDto);
    }
    }

    /// <summary>
    /// 新增
    /// </summary>
	        [AbpAuthorize(MessageAppPermissions.Message_CreateMessage)]	 
         public virtual async Task<MessageEditDto> CreateMessageAsync(MessageEditDto input)
{
    //TODO:新增前的逻辑判断，是否允许新增

	var entity = input.MapTo<Message>();
	
    entity = await _messageRepository.InsertAsync(entity);
    return entity.MapTo<MessageEditDto>();
    }

    /// <summary>
    /// 编辑
    /// </summary>
	      [AbpAuthorize(MessageAppPermissions.Message_EditMessage)]
         public virtual async Task UpdateMessageAsync(MessageEditDto input)
{
    //TODO:更新前的逻辑判断，是否允许更新

    var entity = await _messageRepository.GetAsync(input.Id.Value);
	input.MapTo(entity);

    await _messageRepository.UpdateAsync(entity);
    }

    /// <summary>
    /// 删除
    /// </summary>
	    [AbpAuthorize(MessageAppPermissions.Message_DeleteMessage)]
         public async Task DeleteMessageAsync(EntityDto<int> input)
{
    //TODO:删除前的逻辑判断，是否允许删除
    await _messageRepository.DeleteAsync(input.Id);
    }

        /// <summary>
    /// 批量删除
    /// </summary>
	    [AbpAuthorize(MessageAppPermissions.Message_DeleteMessage)]
         public async Task BatchDeleteMessageAsync(List<int> input)
{
    //TODO:批量删除前的逻辑判断，是否允许删除
    await _messageRepository.DeleteAsync(s=>input.Contains(s.Id));
    }

            #endregion
  









    }
    }

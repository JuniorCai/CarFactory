
// 项目展示地址:"http://www.ddxc.org/"
 // 如果你有什么好的建议或者觉得可以加什么功能，请加QQ群：104390185大家交流沟通
// 项目展示地址:"http://www.yoyocms.com/"
//博客地址：http://www.cnblogs.com/wer-ltm/
//代码生成器帮助文档：http://www.cnblogs.com/wer-ltm/p/5777190.html
// <Author-作者>角落的白板笔</Author-作者>
// Copyright © YoYoCms@中国.2018-02-18T12:16:46. All Rights Reserved.
//<生成时间>2018-02-18T12:16:46</生成时间>
namespace NbscwMPA.Messages
{
	
	

		//TODO:多页面后端的导航栏目设计

	/*
	//无次级导航属性
	   var message=new MenuItemDefinition(
                MessageAppPermissions.Message,
                L("Message"),
				url:"Mpa/MessageManage",
				icon:"icon-grid",
				 				 requiredPermissionName: MessageAppPermissions.Message
				 					);

*/
				//有下级菜单
            /*

			   var message=new MenuItemDefinition(
                MessageAppPermissions.Message,
                L("Message"),			
				icon:"icon-grid"				
				);

				message.AddItem(
			new MenuItemDefinition(
			MessageAppPermissions.Message,
			L("Message"),
			"icon-star",
			url:"Mpa/MessageManage",
				 			requiredPermissionName: MessageAppPermissions.Message));
	

			
			*/

	
			
	
          //配置权限模块初始化
 //TODO:★需要到请将以下内容剪切到NbscwMPAApplicationModule
 //   Configuration.Authorization.Providers.Add<MessageAppAuthorizationProvider>();
		 
 	
	


 

//TODO:★请将以下内容剪切到CORE类库的Localization/Source/NbscwMPAzh-cn.xml
//第一次加载建议复制他
// <text name="MustBe_Required" value="不能为空" />


/*
    <!-- 管理 -->
	    <text name="Message" value="" />
	    <text name="MessageHeaderInfo" value="管理列表" />
		    <text name="CreateMessage" value="新增" />
    <text name="EditMessage" value="编辑" />
    <text name="DeleteMessage" value="删除" />

	  
		

		    <text name="MessageDeleteWarningMessage" value="名称: {0} 将被删除,是否确定删除它。" />
<!--//用于表格展示的数据信息的标题-->
					<text name="Title" value="消息标题" />
				 	<text name="TypeId" value="消息类型" />
				 	<text name="Detail" value="内容" />
				 	<text name="SenderId" value="发件人ID" />
				 	<text name="RecipientId" value="收件人ID" />
				 	<text name="SendIp" value="发件人IP" />
				 	<text name="IsSend" value="是否已发送" />
				 	<text name="IsRead" value="是否已阅读" />
				 	<text name="InRecycle" value="是否进入回收站" />
				 	<text name="LastModificationTime" value="最后编辑时间" />
				 	<text name="CreationTime" value="创建时间" />
				 
*/


//TODO:★请将以下内容剪切到CORE类库的Localization/Source/NbscwMPA.xml
/*
    <!-- english管理 -->
		    <text name="	MessageHeaderInfo" value="List" />
			<!--//用于表格展示的数据信息的标题-->
					<text name="Title" value="消息标题" />
				 	<text name="TypeId" value="消息类型" />
				 	<text name="Detail" value="内容" />
				 	<text name="SenderId" value="发件人ID" />
				 	<text name="RecipientId" value="收件人ID" />
				 	<text name="SendIp" value="发件人IP" />
				 	<text name="IsSend" value="是否已发送" />
				 	<text name="IsRead" value="是否已阅读" />
				 	<text name="InRecycle" value="是否进入回收站" />
				 	<text name="LastModificationTime" value="最后编辑时间" />
				 	<text name="CreationTime" value="创建时间" />
				 
    <text name="Message" value="ManagementMessage" />
    <text name="CreateMessage" value="CreateMessage" />
    <text name="EditMessage" value="EditMessage" />
    <text name="DeleteMessage" value="DeleteMessage" />
*/




}
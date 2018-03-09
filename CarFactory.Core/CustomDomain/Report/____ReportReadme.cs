
// 项目展示地址:"http://www.ddxc.org/"
 // 如果你有什么好的建议或者觉得可以加什么功能，请加QQ群：104390185大家交流沟通
// 项目展示地址:"http://www.yoyocms.com/"
//博客地址：http://www.cnblogs.com/wer-ltm/
//代码生成器帮助文档：http://www.cnblogs.com/wer-ltm/p/5777190.html
// <Author-作者>角落的白板笔</Author-作者>
// Copyright © YoYoCms@中国.2018-03-09T10:24:49. All Rights Reserved.
//<生成时间>2018-03-09T10:24:49</生成时间>
namespace CarFactory.Core.CustomDomain.Report
{
	
	

		//TODO:多页面后端的导航栏目设计

	/*
	//无次级导航属性
	   var report=new MenuItemDefinition(
                ReportAppPermissions.Report,
                L("Report"),
				url:"Mpa/ReportManage",
				icon:"icon-grid",
				 				 requiredPermissionName: ReportAppPermissions.Report
				 					);

*/
				//有下级菜单
            /*

			   var report=new MenuItemDefinition(
                ReportAppPermissions.Report,
                L("Report"),			
				icon:"icon-grid"				
				);

				report.AddItem(
			new MenuItemDefinition(
			ReportAppPermissions.Report,
			L("Report"),
			"icon-star",
			url:"Mpa/ReportManage",
				 			requiredPermissionName: ReportAppPermissions.Report));
	

			
			*/

	
			
	
          //配置权限模块初始化
 //TODO:★需要到请将以下内容剪切到CoreApplicationModule
 //   Configuration.Authorization.Providers.Add<ReportAppAuthorizationProvider>();
		 
 	
	


 

//TODO:★请将以下内容剪切到CORE类库的Localization/Source/Corezh-cn.xml
//第一次加载建议复制他
// <text name="MustBe_Required" value="不能为空" />


/*
    <!-- 检测报告管理 -->
	    <text name="Report" value="检测报告" />
	    <text name="ReportHeaderInfo" value="检测报告管理列表" />
		    <text name="CreateReport" value="新增检测报告" />
    <text name="EditReport" value="编辑检测报告" />
    <text name="DeleteReport" value="删除检测报告" />

	  
		

		    <text name="ReportDeleteWarningMessage" value="检测报告名称: {0} 将被删除,是否确定删除它。" />
<!--//用于表格展示的数据信息的标题-->
					<text name="ReportName" value="ReportName" />
				 	<text name="Img" value="Img" />
				 	<text name="RelativeId" value="RelativeId" />
				 	<text name="LastModificationTime" value="最后编辑时间" />
				 	<text name="CreationTime" value="创建时间" />
				 
*/


//TODO:★请将以下内容剪切到CORE类库的Localization/Source/Core.xml
/*
    <!-- 检测报告english管理 -->
		    <text name="	ReportHeaderInfo" value="检测报告List" />
			<!--//用于表格展示的数据信息的标题-->
					<text name="ReportName" value="ReportName" />
				 	<text name="Img" value="Img" />
				 	<text name="RelativeId" value="RelativeId" />
				 	<text name="LastModificationTime" value="最后编辑时间" />
				 	<text name="CreationTime" value="创建时间" />
				 
    <text name="Report" value="ManagementReport" />
    <text name="CreateReport" value="CreateReport" />
    <text name="EditReport" value="EditReport" />
    <text name="DeleteReport" value="DeleteReport" />
*/




}
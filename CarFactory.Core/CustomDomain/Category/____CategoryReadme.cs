﻿
// 项目展示地址:"http://www.ddxc.org/"
 // 如果你有什么好的建议或者觉得可以加什么功能，请加QQ群：104390185大家交流沟通
// 项目展示地址:"http://www.yoyocms.com/"
//博客地址：http://www.cnblogs.com/wer-ltm/
//代码生成器帮助文档：http://www.cnblogs.com/wer-ltm/p/5777190.html
// <Author-作者>角落的白板笔</Author-作者>
// Copyright © YoYoCms@中国.2018-03-02T16:39:07. All Rights Reserved.
//<生成时间>2018-03-02T16:39:07</生成时间>
namespace CarFactory.Core.CustomDomain.Category
{
	
	

		//TODO:多页面后端的导航栏目设计

	/*
	//无次级导航属性
	   var category=new MenuItemDefinition(
                CategoryAppPermissions.Category,
                L("Category"),
				url:"Mpa/CategoryManage",
				icon:"icon-grid",
				 				 requiredPermissionName: CategoryAppPermissions.Category
				 					);

*/
				//有下级菜单
            /*

			   var category=new MenuItemDefinition(
                CategoryAppPermissions.Category,
                L("Category"),			
				icon:"icon-grid"				
				);

				category.AddItem(
			new MenuItemDefinition(
			CategoryAppPermissions.Category,
			L("Category"),
			"icon-star",
			url:"Mpa/CategoryManage",
				 			requiredPermissionName: CategoryAppPermissions.Category));
	

			
			*/

	
			
	
          //配置权限模块初始化
 //TODO:★需要到请将以下内容剪切到CustomDomainApplicationModule
 //   Configuration.Authorization.Providers.Add<CategoryAppAuthorizationProvider>();
		 
 	
	


 




//TODO:★请将以下内容剪切到CORE类库的Localization/Source/CustomDomain.xml
/*
    <!-- 产品类别english管理 -->
		    <text name="	CategoryHeaderInfo" value="产品类别List" />
			<!--//用于表格展示的数据信息的标题-->
					<text name="Name" value="Name" />
				 	<text name="ShortName" value="ShortName" />
				 	<text name="IsActive" value="IsActive" />
				 	<text name="Sort" value="Sort" />
				 	<text name="Products" value="Products" />
				 	<text name="LastModificationTime" value="最后编辑时间" />
				 	<text name="CreationTime" value="创建时间" />
				 
    <text name="Category" value="ManagementCategory" />
    <text name="CreateCategory" value="CreateCategory" />
    <text name="EditCategory" value="EditCategory" />
    <text name="DeleteCategory" value="DeleteCategory" />
*/




}
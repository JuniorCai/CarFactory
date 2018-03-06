namespace CarFactory.Core.CustomDomain.Company
{
	
	

		//TODO:多页面后端的导航栏目设计

	/*
	//无次级导航属性
	   var company=new MenuItemDefinition(
                CompanyAppPermissions.Company,
                L("Company"),
				url:"Mpa/CompanyManage",
				icon:"icon-grid",
				 				 requiredPermissionName: CompanyAppPermissions.Company
				 					);

*/
				//有下级菜单
            /*

			   var company=new MenuItemDefinition(
                CompanyAppPermissions.Company,
                L("Company"),			
				icon:"icon-grid"				
				);

				company.AddItem(
			new MenuItemDefinition(
			CompanyAppPermissions.Company,
			L("Company"),
			"icon-star",
			url:"Mpa/CompanyManage",
				 			requiredPermissionName: CompanyAppPermissions.Company));
	

			
			*/

	
			
	
          //配置权限模块初始化
 //TODO:★需要到请将以下内容剪切到CustomDomainApplicationModule
 //   Configuration.Authorization.Providers.Add<CompanyAppAuthorizationProvider>();
		 
 	
	


 

//TODO:★请将以下内容剪切到CORE类库的Localization/Source/CustomDomainzh-cn.xml
//第一次加载建议复制他
// <text name="MustBe_Required" value="不能为空" />


/*
    <!-- 公司信息管理 -->
	    <text name="Company" value="公司信息" />
	    <text name="CompanyHeaderInfo" value="公司信息管理列表" />
		    <text name="CreateCompany" value="新增公司信息" />
    <text name="EditCompany" value="编辑公司信息" />
    <text name="DeleteCompany" value="删除公司信息" />

	  
		

		    <text name="CompanyDeleteWarningMessage" value="公司信息名称: {0} 将被删除,是否确定删除它。" />
<!--//用于表格展示的数据信息的标题-->
					<text name="CompanyName" value="CompanyName" />
				 	<text name="Phone" value="Phone" />
				 	<text name="Tel" value="Tel" />
				 	<text name="Email" value="Email" />
				 	<text name="Address" value="Address" />
				 	<text name="Longitude" value="Longitude" />
				 	<text name="Latitude" value="Latitude" />
				 	<text name="LastModificationTime" value="最后编辑时间" />
				 	<text name="CreationTime" value="创建时间" />
				 
*/


//TODO:★请将以下内容剪切到CORE类库的Localization/Source/CustomDomain.xml
/*
    <!-- 公司信息english管理 -->
		    <text name="	CompanyHeaderInfo" value="公司信息List" />
			<!--//用于表格展示的数据信息的标题-->
					<text name="CompanyName" value="CompanyName" />
				 	<text name="Phone" value="Phone" />
				 	<text name="Tel" value="Tel" />
				 	<text name="Email" value="Email" />
				 	<text name="Address" value="Address" />
				 	<text name="Longitude" value="Longitude" />
				 	<text name="Latitude" value="Latitude" />
				 	<text name="LastModificationTime" value="最后编辑时间" />
				 	<text name="CreationTime" value="创建时间" />
				 
    <text name="Company" value="ManagementCompany" />
    <text name="CreateCompany" value="CreateCompany" />
    <text name="EditCompany" value="EditCompany" />
    <text name="DeleteCompany" value="DeleteCompany" />
*/




}
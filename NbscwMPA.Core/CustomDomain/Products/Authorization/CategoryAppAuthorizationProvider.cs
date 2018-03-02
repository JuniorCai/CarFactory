                          

   
using System.Linq;
using Abp.Authorization;
using Abp.Localization;

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
// Copyright © YoYoCms@China.2018-03-02T16:39:11. All Rights Reserved.
//<生成时间>2018-03-02T16:39:11</生成时间>
	#endregion


namespace NbscwMPACarFactory.CustomDomain.Products.Authorization
{
	/// <summary>
    /// 权限配置都在这里。
    /// 给权限默认设置服务
    /// See <see cref="CategoryAppPermissions"/> for all permission names.
    /// </summary>
    public class CategoryAppAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
					      //在这里配置了Category 的权限。

            //var pages = context.GetPermissionOrNull(AppPermissions.Pages) ?? context.CreatePermission(AppPermissions.Pages, L("Pages"));

            //  var entityNameModel = pages.Children.FirstOrDefault(p => p.Name == AppPermissions.Pages_Administration) 
            //    ?? pages.CreateChildPermission(AppPermissions.Pages_Administration, L("Administration"));



           

            //var category = entityNameModel.CreateChildPermission(CategoryAppPermissions.Category , L("Category"));
            //category.CreateChildPermission(CategoryAppPermissions.Category_CreateCategory, L("CreateCategory"));
            //category.CreateChildPermission(CategoryAppPermissions.Category_EditCategory, L("EditCategory"));           
            //category.CreateChildPermission(CategoryAppPermissions. Category_DeleteCategory, L("DeleteCategory"));
 

  
            


            
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, NbscwMPAConsts.LocalizationSourceName);
        }
    }




}
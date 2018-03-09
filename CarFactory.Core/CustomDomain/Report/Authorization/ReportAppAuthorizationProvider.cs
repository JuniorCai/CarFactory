using System.Linq;
using Abp.Authorization;
using Abp.Localization;



namespace CarFactory.Core.CustomDomain.Report.Authorization
{
	/// <summary>
    /// 权限配置都在这里。
    /// 给权限默认设置服务
    /// See <see cref="ReportAppPermissions"/> for all permission names.
    /// </summary>
    public class ReportAppAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
					      //在这里配置了Report 的权限。

//            var pages = context.GetPermissionOrNull(AppPermissions.Pages) ?? context.CreatePermission(AppPermissions.Pages, L("Pages"));
//
//              var entityNameModel = pages.Children.FirstOrDefault(p => p.Name == AppPermissions.Pages_Administration) 
//                ?? pages.CreateChildPermission(AppPermissions.Pages_Administration, L("Administration"));
//
//
//
//           
//
//            var report = entityNameModel.CreateChildPermission(ReportAppPermissions.Report , L("Report"));
//            report.CreateChildPermission(ReportAppPermissions.Report_CreateReport, L("CreateReport"));
//            report.CreateChildPermission(ReportAppPermissions.Report_EditReport, L("EditReport"));           
//            report.CreateChildPermission(ReportAppPermissions. Report_DeleteReport, L("DeleteReport"));
 

  
            


            
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, CarFactoryConsts.LocalizationSourceName);
        }
    }




}
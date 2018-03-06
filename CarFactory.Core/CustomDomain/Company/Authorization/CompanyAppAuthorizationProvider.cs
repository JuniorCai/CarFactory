using Abp.Authorization;
using Abp.Localization;

namespace CarFactory.Core.CustomDomain.Company.Authorization
{
    /// <summary>
    /// 权限配置都在这里。
    /// 给权限默认设置服务
    /// See <see cref="CompanyAppPermissions"/> for all permission names.
    /// </summary>
    public class CompanyAppAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            //在这里配置了Company 的权限。

//            var pages = context.GetPermissionOrNull(AppPermissions.Pages) ??
//                        context.CreatePermission(AppPermissions.Pages, L("Pages"));
//
//            var entityNameModel = pages.Children.FirstOrDefault(p => p.Name == AppPermissions.Pages_Administration)
//                                  ?? pages.CreateChildPermission(AppPermissions.Pages_Administration,
//                                      L("Administration"));
//
//
//
//
//
//            var company = entityNameModel.CreateChildPermission(CompanyAppPermissions.Company, L("Company"));
//            company.CreateChildPermission(CompanyAppPermissions.Company_CreateCompany, L("CreateCompany"));
//            company.CreateChildPermission(CompanyAppPermissions.Company_EditCompany, L("EditCompany"));
//            company.CreateChildPermission(CompanyAppPermissions.Company_DeleteCompany, L("DeleteCompany"));

        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, CarFactoryConsts.LocalizationSourceName);
        }
    }
}
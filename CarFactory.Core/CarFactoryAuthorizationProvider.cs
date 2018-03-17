using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;
using CarFactory.Core.Authorization;
using CarFactory.Core.CustomDomain.Category.Authorization;
using CarFactory.Core.CustomDomain.Company.Authorization;
using CarFactory.Core.CustomDomain.Products.Authorization;
using CarFactory.Core.CustomDomain.Report.Authorization;

namespace CarFactory.Core
{
    public class CarFactoryAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {

            var entityNameModel = context.GetPermissionOrNull(PermissionNames.Pages_Administration) ?? context.CreatePermission(PermissionNames.Pages_Administration, L("Administration"), L("Administration"));


            entityNameModel.CreateChildPermission(PermissionNames.Pages_Users, L("Users"), L("Users"));
            entityNameModel.CreateChildPermission(PermissionNames.Pages_Roles, L("Roles"), L("Roles"));
            //entityNameModel.CreateChildPermission(PermissionNames.Pages_Tenants, L("Tenants"), L("Tenants"), multiTenancySides: MultiTenancySides.Host);

            entityNameModel.CreateChildPermission(CompanyAppPermissions.Company, L("Company"), L("Company"));


            var category = entityNameModel.CreateChildPermission(CategoryAppPermissions.Category, L("Category"), L("Category"));
//            category.CreateChildPermission(CategoryAppPermissions.Category_CreateCategory, L("CreateCategory"), L("CreateCategory"));
//            category.CreateChildPermission(CategoryAppPermissions.Category_EditCategory, L("EditCategory"), L("EditCategory"));
//            category.CreateChildPermission(CategoryAppPermissions.Category_DeleteCategory, L("DeleteCategory"), L("DeleteCategory"));


            var product = entityNameModel.CreateChildPermission(ProductAppPermissions.Product , L("Product"), L("Product"));
//            product.CreateChildPermission(ProductAppPermissions.Product_CreateProduct, L("CreateProduct"), L("CreateProduct"));
//            product.CreateChildPermission(ProductAppPermissions.Product_EditProduct, L("EditProduct"), L("EditProduct"));           
//            product.CreateChildPermission(ProductAppPermissions. Product_DeleteProduct, L("DeleteProduct"), L("DeleteProduct"));
            


            var report = entityNameModel.CreateChildPermission(ReportAppPermissions.Report , L("Report"), L("Report"));
//            report.CreateChildPermission(ReportAppPermissions.Report_CreateReport, L("CreateReport"), L("CreateReport"));
//            report.CreateChildPermission(ReportAppPermissions.Report_EditReport, L("EditReport"), L("EditReport"));           
//            report.CreateChildPermission(ReportAppPermissions. Report_DeleteReport, L("DeleteReport"), L("DeleteReport"));


        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, CarFactoryConsts.LocalizationSourceName);
        }
    }
}

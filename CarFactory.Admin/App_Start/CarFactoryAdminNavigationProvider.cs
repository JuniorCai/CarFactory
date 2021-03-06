﻿using Abp.Application.Navigation;
using Abp.Localization;
using CarFactory.Core;
using CarFactory.Core.Authorization;
using CarFactory.Core.CustomDomain.Banner.Authorization;
using CarFactory.Core.CustomDomain.Category.Authorization;
using CarFactory.Core.CustomDomain.Company.Authorization;
using CarFactory.Core.CustomDomain.Products.Authorization;
using CarFactory.Core.CustomDomain.Report.Authorization;

namespace CarFactory.Admin
{
    public class CarFactoryAdminNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
            var homeMenu = new MenuItemDefinition(
                "Home",
                L("HomePage"),
                "icon-layers",
                "/",
                requiresAuthentication:true,
                order:0
                );

            var contentManageMenu = new MenuItemDefinition(
                "ContentManage",
                new LocalizableString("ContentManage", CarFactoryConsts.LocalizationSourceName),
                "icon-layers",
                requiresAuthentication: true,
                order: 1
            );

            var settingsManageMenu = new MenuItemDefinition(
                "Settings",
                new LocalizableString("Settings", CarFactoryConsts.LocalizationSourceName),
                "icon-layers",
                requiresAuthentication: true,
                order: 2);



            var product = new MenuItemDefinition(
                PageNames.Products,
                L(PageNames.Products),
                url: "/admin/ProductManage",
                icon: "icon-grid",
                requiredPermissionName: ProductAppPermissions.Product
            );

            var productCategory = new MenuItemDefinition(
                PageNames.ProductCategory,
                L(PageNames.ProductCategory),
                url: "/admin/CategoryManage",
                icon: "icon-grid",
                requiredPermissionName: CategoryAppPermissions.Category
            );

            var report = new MenuItemDefinition(
                PageNames.Reports,
                L(PageNames.Reports),
                url: "/admin/ReportManage",
                icon: "icon-grid",
                requiredPermissionName: ReportAppPermissions.Report
            );

            var company = new MenuItemDefinition(
                PageNames.Company,
                L(PageNames.Company),
                url: "/admin/company",
                icon: "icon-grid",
                requiredPermissionName: CompanyAppPermissions.Company
                );

            var banner = new MenuItemDefinition(
                PageNames.Banner,
                L(PageNames.Banner),
                url: "/admin/BannerManage",
                icon: "icon-grid",
                requiredPermissionName: BannerAppPermissions.Banner
            );

            var role = new MenuItemDefinition(
                    PageNames.Roles,
                    L(PageNames.Roles),
                    url: "/admin/RoleManage",
                    icon: "icon-grid",
                    requiredPermissionName: PermissionNames.Pages_Roles
                    );

            var user = new MenuItemDefinition(
                PageNames.Users,
                L(PageNames.Users),
                url: "/admin/UserManage",
                icon: "icon-grid",
            requiredPermissionName: PermissionNames.Pages_Users);

            var seo = new MenuItemDefinition(
                PageNames.Seo,
                L(PageNames.Seo),
                url: "/admin/Seo",
                icon: "icon-grid");


            contentManageMenu.AddItem(product).AddItem(productCategory).AddItem(report).AddItem(company).AddItem(banner);
            settingsManageMenu.AddItem(role).AddItem(user).AddItem(seo);

            context.Manager.MainMenu.AddItem(homeMenu).AddItem(contentManageMenu).AddItem(settingsManageMenu);

        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, CarFactoryConsts.LocalizationSourceName);
        }
    }
}
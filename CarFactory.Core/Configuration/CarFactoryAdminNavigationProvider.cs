using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Navigation;
using Abp.Localization;
using CarFactory.Core.CustomDomain.Products.Authorization;

namespace CarFactory.Core.Configuration
{
    public class CarFactoryAdminNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
            var contentManageMenu = new MenuItemDefinition(
                "ContentManage",
                new LocalizableString("ContentManage", CarFactoryConsts.LocalizationSourceName),
                "icon-layers",
                requiresAuthentication : true,
                order:0
                );

            var settingsManageMenu = new MenuItemDefinition(
                "Settings",
                new LocalizableString("Settings", CarFactoryConsts.LocalizationSourceName),
                "icon-layers",
                requiresAuthentication: true,
                order: 1);



            var product = new MenuItemDefinition(
                ProductAppPermissions.Product,
                L("Product"),
                url: "admin/ProductManage",
                icon: "icon-grid"//,
                //requiredPermissionName: ProductAppPermissions.Product
            );

            contentManageMenu.AddItem(product);

            context.Manager.MainMenu.AddItem(contentManageMenu).AddItem(settingsManageMenu);

        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, CarFactoryConsts.LocalizationSourceName);
        }
    }
}

using Abp.Application.Navigation;
using Abp.Localization;
using CarFactory.Core;

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
                "/admin",
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
                url: "admin/ProductManage",
                icon: "icon-grid"//,
                //requiredPermissionName: ProductAppPermissions.Product
            );

            
            contentManageMenu.AddItem(product);

            context.Manager.MainMenu.AddItem(homeMenu).AddItem(contentManageMenu).AddItem(settingsManageMenu);

        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, CarFactoryConsts.LocalizationSourceName);
        }
    }
}
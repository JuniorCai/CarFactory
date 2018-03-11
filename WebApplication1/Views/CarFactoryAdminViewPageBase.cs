using Abp.Web.Mvc.Views;
using CarFactory.Core;

namespace CarFactory.Admin.Views
{
    public abstract class CarFactoryAdminViewPageBase : CarFactoryAdminViewPageBase<dynamic>
    {

    }

    public abstract class CarFactoryAdminViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected CarFactoryAdminViewPageBase()
        {
            LocalizationSourceName = CarFactoryConsts.LocalizationSourceName;
        }
    }
}
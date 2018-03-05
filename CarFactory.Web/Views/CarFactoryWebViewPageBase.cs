using Abp.Web.Mvc.Views;
using CarFactory;

namespace CarFactory.Web.Views
{
    public abstract class CarFactoryWebViewPageBase : CarFactoryWebViewPageBase<dynamic>
    {

    }

    public abstract class CarFactoryWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected CarFactoryWebViewPageBase()
        {
            LocalizationSourceName = CarFactoryConsts.LocalizationSourceName;
        }
    }
}
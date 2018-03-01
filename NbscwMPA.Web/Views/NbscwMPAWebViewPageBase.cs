using Abp.Web.Mvc.Views;

namespace NbscwMPACarFactory.Web.Views
{
    public abstract class NbscwMPAWebViewPageBase : NbscwMPAWebViewPageBase<dynamic>
    {

    }

    public abstract class NbscwMPAWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected NbscwMPAWebViewPageBase()
        {
            LocalizationSourceName = NbscwMPAConsts.LocalizationSourceName;
        }
    }
}
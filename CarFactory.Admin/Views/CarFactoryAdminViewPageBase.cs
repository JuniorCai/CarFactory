using Abp.Application.Services.Dto;
using Abp.Runtime.Session;
using Abp.Web.Mvc.Views;
using CarFactory.Application.Users;
using CarFactory.Application.Users.Dto;
using CarFactory.Core;

namespace CarFactory.Admin.Views
{
    public abstract class CarFactoryAdminViewPageBase : CarFactoryAdminViewPageBase<dynamic>
    {
        public CarFactoryAdminViewPageBase()
        {
        }

        
    }

    public abstract class CarFactoryAdminViewPageBase<TModel> : AbpWebViewPage<TModel>
    {

        protected CarFactoryAdminViewPageBase()
        {
            LocalizationSourceName = CarFactoryConsts.LocalizationSourceName;
        }

    }
}
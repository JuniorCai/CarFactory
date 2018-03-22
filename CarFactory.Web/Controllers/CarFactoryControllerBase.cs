using System.Threading.Tasks;
using Abp.IdentityFramework;
using Abp.UI;
using Abp.Web.Mvc.Controllers;
using Microsoft.AspNet.Identity;
using CarFactory;
using CarFactory.Application.Seo;
using CarFactory.Application.Seo.Dtos;
using CarFactory.Core;

namespace CarFactory.Web.Controllers
{
    /// <summary>
    /// Derive all Controllers from this class.
    /// </summary>
    public abstract class CarFactoryControllerBase : AbpController
    {

        private readonly ISeoAppService _seoAppService;

        protected CarFactoryControllerBase(ISeoAppService seoAppService)
        {
            _seoAppService = seoAppService;
            LocalizationSourceName = CarFactoryConsts.LocalizationSourceName;
        }

        protected virtual void CheckModelState()
        {
            if (!ModelState.IsValid)
            {
                throw new UserFriendlyException(L("FormIsNotValidMessage"));
            }
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }

        protected SeoListDto GetSeoSetting()
        {
            var setting = _seoAppService.GetDefaultSeoAsync().Result;
            return setting;
        }
    }
}
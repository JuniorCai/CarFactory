using System.Threading.Tasks;
using Abp.Application.Navigation;
using Abp.IdentityFramework;
using Abp.Runtime.Session;
using Abp.UI;
using Abp.Web.Mvc.Controllers;
using CarFactory.Admin.Models.Layout;
using CarFactory.Core;
using Microsoft.AspNet.Identity;

namespace CarFactory.Admin.Controllers
{
    /// <summary>
    /// Derive all Controllers from this class.
    /// </summary>
    public abstract class CarFactoryControllerBase : AbpController
    {
        private readonly IUserNavigationManager _userNavigationManager;
        protected CarFactoryControllerBase(IUserNavigationManager userNavigationManager)
        {
            LocalizationSourceName = CarFactoryConsts.LocalizationSourceName;
            _userNavigationManager = userNavigationManager;
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

        protected async Task<SideBarNavViewModel> GetUserMenu(string activeMenu = "")
        {
            var model = new SideBarNavViewModel
            {
                MainMenu = await _userNavigationManager.GetMenuAsync("MainMenu", AbpSession.ToUserIdentifier()),
                ActiveMenuItemName = activeMenu
            };

            return model;
        }
    }
}
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
        private readonly IUserAppService _userAppService;
        public CarFactoryAdminViewPageBase(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        public UserDto GetLoginUserDto()
        {
            UserDto userInfo = null;
            var userId = NullAbpSession.Instance.UserId;
            if (userId != null)
            {
                userInfo = _userAppService.Get(new EntityDto<long>(userId.Value)).Result;
            }
            return userInfo;
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
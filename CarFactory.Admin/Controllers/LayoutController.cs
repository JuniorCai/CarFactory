using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Abp.Application.Navigation;
using Abp.Application.Services.Dto;
using CarFactory.Application.Users;
using CarFactory.Application.Users.Dto;

namespace CarFactory.Admin.Controllers
{
    public class LayoutController : CarFactoryControllerBase
    {
        private readonly IUserAppService _userAppService;


        public LayoutController(IUserAppService userAppService,IUserNavigationManager userNavigationManager)
            : base(userNavigationManager)
        {
            _userAppService = userAppService;
        }

        [ChildActionOnly]
        // GET: Layout
        public PartialViewResult PartialHeader()
        {

            UserDto userInfo = new UserDto();
            long? userId = AbpSession.UserId;

            if (userId != null)
            {
                userInfo = _userAppService.Get(new EntityDto<long>(userId.Value)).Result;
            }


            return PartialView("_PartialHeader", userInfo);
        }
    }
}
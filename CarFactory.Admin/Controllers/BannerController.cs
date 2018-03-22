﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Abp.Application.Navigation;
using Abp.Application.Services.Dto;
using Abp.Web.Mvc.Authorization;
using CarFactory.Application.Banner;
using CarFactory.Application.Banner.Dtos;
using CarFactory.Core;
using CarFactory.Core.CustomDomain.Banner.Authorization;
using X.PagedList;

namespace CarFactory.Admin.Controllers
{
    [RoutePrefix("admin")]
    [AbpMvcAuthorize(BannerAppPermissions.Banner)]
    public class BannerController : CarFactoryControllerBase
    {

        private readonly IBannerAppService _bannerAppService;

        public BannerController(IBannerAppService bannerAppService, IUserNavigationManager userNavigationManager) : base(userNavigationManager)
        {
            _bannerAppService = bannerAppService;
        }


        // GET: Banner
        [Route("BannerManage")]
        public ActionResult Index(int? page)
        {
            int pageIndex = (page ?? 1) - 1;

            GetBannerInput input = new GetBannerInput()
            {
                FilterText = "",
                MaxResultCount = CarFactoryConsts.MaxPageSize,
                SkipCount = pageIndex * CarFactoryConsts.MaxPageSize,
                Sorting = "sort"
            };

            var list = _bannerAppService.GetPagedBannersAsync(input).Result;

            var pagedProducts = new StaticPagedList<BannerListDto>(list.Items, pageIndex + 1, input.MaxResultCount,
                list.TotalCount);

            var userMenu = GetUserMenu(PageNames.Banner).Result;
            ViewBag.UserMenu = userMenu;

            return View(pagedProducts);
        }

        [HttpPost]
        [Route("bannermanage/savebanner")]
        public JsonResult SaveBanner(BannerEditDto editModel)
        {
            bool status = false;
            string msg = "";

            CheckModelState();

            try
            {
                _bannerAppService.CreateOrUpdateBannerAsync(new CreateOrUpdateBannerInput(){BannerEditDto = editModel });
                status = true;
            }
            catch (Exception e)
            {
                msg = e.Message;
                status = false;
            }
            return Json(new {success = status, message = msg});
        }


        [HttpPost]
        [Route("bannermanage/delBanner")]
        public JsonResult DelBanner(int id = 0)
        {
            bool status = false;
            string msg = "";

            try
            {
                if (id > 0)
                {
                    _bannerAppService.DeleteBannerAsync(new EntityDto(id));
                    status = true;
                }
            }
            catch (Exception e)
            {
                msg = "-1";
                status = false;
            }
            return Json(new { success = status });
        }
    }
}
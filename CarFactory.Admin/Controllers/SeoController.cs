using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Abp.Application.Navigation;
using Abp.Application.Services.Dto;
using Abp.Runtime.Validation;
using Abp.Web.Security.AntiForgery;
using CarFactory.Application.Seo;
using CarFactory.Application.Seo.Dtos;
using CarFactory.Application.Users;

namespace CarFactory.Admin.Controllers
{
    [RoutePrefix("admin")]
    public class SeoController : CarFactoryControllerBase
    {
        private readonly ISeoAppService _seoAppService;

        public SeoController(ISeoAppService seoAppService, IUserNavigationManager userNavigationManager)
            : base(userNavigationManager)
        {
            _seoAppService = seoAppService;
        }

        // GET: Seo
        public async  Task<ActionResult> Index()
        {
            var setting = await _seoAppService.GetDefaultSeoAsync();

            var userMenu = GetUserMenu(PageNames.Seo).Result;
            ViewBag.UserMenu = userMenu;


            return View(setting); 
        }

        [Route("seo/saveseo")]
        [HttpPost]
        [DisableValidation]
        public async Task<JsonResult> SaveSeo(SeoEditDto editDto)
        {
            CheckModelState();

            bool status = false;
            string message = "";

            try
            {
                var oldModel = await _seoAppService.GetDefaultSeoAsync();
                if (oldModel != null)
                {
                    editDto.Watermark = oldModel.Watermark;
                    editDto.WatermarkAble = oldModel.WatermarkAble;
                }
                await _seoAppService.CreateOrUpdateSeoAsync(new CreateOrUpdateSeoInput() {SeoEditDto = editDto});
                status = true;
            }
            catch (Exception e)
            {
                status = false;
                message = e.Message;
            }

            return Json(new {success = status, message = message});
        }

        [Route("seo/savewatermark")]
        [HttpPost]
        [DisableValidation]
        public async Task<JsonResult> SaveWatermark(SeoEditDto editDto)
        {
            
            CheckModelState();

            bool status = false;
            string message = "";

            try
            {
                var oldModel = await _seoAppService.GetDefaultSeoAsync();
                if (oldModel != null)
                {
                    editDto.SiteTitle = oldModel.SiteTitle;
                    editDto.SiteKeywords = oldModel.SiteKeywords;
                    editDto.SiteDescription = oldModel.SiteDescription;
                }
                await _seoAppService.CreateOrUpdateSeoAsync(new CreateOrUpdateSeoInput() { SeoEditDto = editDto });
                status = true;
            }
            catch (Exception e)
            {
                status = false;
                message = e.Message;
            }

            return Json(new { success = status, message = message });
        }

        [Route("seo/savebanner")]
        [HttpPost]
        [DisableValidation]
        //[DisableAbpAntiForgeryTokenValidation]
        public async Task<JsonResult> SaveBanner(int id = 0)
        {
            CheckModelState();

            bool status = false;
            string message = "";

            try
            {
                var oldModel = await _seoAppService.GetSeoByIdAsync(new EntityDto(id));
                var defaultModel = await _seoAppService.GetDefaultSeoAsync();
                if (defaultModel == null || defaultModel.Id == oldModel.Id)
                {
                    //await _seoAppService.CreateOrUpdateSeoAsync(new CreateOrUpdateSeoInput() {SeoEditDto = editDto});
                    status = true;
                }
                else
                {
                    status = false;
                    message = "Seo数据对象只可是唯一项，数据中有多余项";
                }
            }
            catch (Exception e)
            {
                status = false;
                message = e.Message;
            }

            return Json(new { success = status, message = message });
        }


    }
}
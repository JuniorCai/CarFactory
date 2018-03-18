using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Abp.Application.Navigation;
using Abp.Application.Services.Dto;
using Abp.Web.Mvc.Authorization;
using CarFactory.Admin.Models.Roles;
using CarFactory.Application.Roles;
using CarFactory.Application.Roles.Dto;
using CarFactory.Core.Authorization;

namespace CarFactory.Admin.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Roles)]
    [RoutePrefix("admin")]
    public class RolesController : CarFactoryControllerBase
    {
        private readonly IRoleAppService _roleAppService;

        public RolesController(IRoleAppService roleAppService,IUserNavigationManager userNavigationManager) : base(userNavigationManager)
        {
            _roleAppService = roleAppService;
        }

        [Route("roleManage")]
        public async Task<ActionResult> Index()
        {
            var roles = (await _roleAppService.GetAll(new PagedAndSortedResultRequestDto())).Items;
            var permissions = (await _roleAppService.GetAllPermissions()).Items;
            var model = new RoleListViewModel
            {
                Roles = roles,
                Permissions = permissions[0].Children.Where(p=>p.Name!=PermissionNames.Pages_Tenants).ToList()
            };
            var userMenu = GetUserMenu(PageNames.Roles).Result;
            ViewBag.UserMenu = userMenu;

            return View(model);
        }

        [Route("roles/saveRole")]
        public JsonResult Save(EditRoleDto editRole)
        {
            CheckModelState();

            bool status = false;
            string msg = "";

            if (editRole.Id > 0)
            {
                try
                {
                    if (_roleAppService.Update(editRole).Result.Id > 0)
                    {
                        status = true;
                        msg = "保存成功";
                    }
                    else
                    {
                        status = false;
                        msg = "保存失败";
                    }
                }
                catch (Exception e)
                {
                    status = false;
                    msg = "运行时出错:"+e.Message;
                }
            }
            else
            {
                try
                {
                    var newModel = _roleAppService.Create(editRole).Result;
                    if (newModel != null && newModel.Id > 0)
                    {
                        status = true;
                        msg = "添加成功";
                    }
                    else
                    {
                        status = false;
                        msg = "角色名称不能重复";
                    }
                }
                catch (Exception e)
                {
                    status = false;
                    msg = "运行时出错:" + e.Message;
                }
            }

            return Json(new {success = status, message = msg});
        }

        [Route("roles/deleteRole")]
        public JsonResult DelRole(int id = 0)
        {
            bool status = false;
            string msg = "";

            try
            {
                if (id > 0)
                {
                    _roleAppService.Delete(new EntityDto(id));
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
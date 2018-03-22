                          
namespace CarFactory.Core.CustomDomain.Banner.Authorization
{
    /// <summary>
    /// 定义系统的权限名称的字符串常量。
    /// <see cref="CarFactoryAuthorizationProvider"/>中对权限的定义.
    /// </summary>
    public static class BannerAppPermissions
    {


        /// <summary>
        /// 首页Banner管理权限
        /// </summary>
        public const string Banner = "Admin.Banner";



        /// <summary>
        /// 首页Banner创建权限
        /// </summary>
        public const string Banner_CreateBanner = "Admin.Banner.CreateBanner";

        /// <summary>
        /// 首页Banner修改权限
        /// </summary>
        public const string Banner_EditBanner = "Admin.Banner.EditBanner";

        /// <summary>
        /// 首页Banner删除权限
        /// </summary>
        public const string Banner_DeleteBanner = "Admin.Banner.DeleteBanner";
    }

}


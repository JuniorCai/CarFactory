                          
namespace CarFactory.Core.CustomDomain.Seo.Authorization
{
    /// <summary>
    /// 定义系统的权限名称的字符串常量。
    /// <see cref="CarFactoryAuthorizationProvider"/>中对权限的定义.
    /// </summary>
    public static class SeoAppPermissions
    {


        /// <summary>
        /// SEO设置管理权限
        /// </summary>
        public const string Seo = "Admin.Seo";



        /// <summary>
        /// SEO设置创建权限
        /// </summary>
        public const string Seo_CreateSeo = "Admin.Seo.CreateSeo";

        /// <summary>
        /// SEO设置修改权限
        /// </summary>
        public const string Seo_EditSeo = "Admin.Seo.EditSeo";

        /// <summary>
        /// SEO设置删除权限
        /// </summary>
        public const string Seo_DeleteSeo = "Admin.Seo.DeleteSeo";
    }

}


                          
namespace CarFactory.Core.CustomDomain.Category.Authorization
{
    /// <summary>
    /// 定义系统的权限名称的字符串常量。
    /// <see cref="CategoryAppAuthorizationProvider"/>中对权限的定义.
    /// </summary>
    public static class CategoryAppPermissions
    {


        /// <summary>
        /// 产品类别管理权限
        /// </summary>
        public const string Category = "Admin.Category";

        /// <summary>
        /// 产品类别创建权限
        /// </summary>
        public const string Category_CreateCategory = "Admin.Category.CreateCategory";

        /// <summary>
        /// 产品类别修改权限
        /// </summary>
        public const string Category_EditCategory = "Admin.Category.EditCategory";

        /// <summary>
        /// 产品类别删除权限
        /// </summary>
        public const string Category_DeleteCategory = "Admin.Category.DeleteCategory";
    }

}


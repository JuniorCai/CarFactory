namespace CarFactory.Core.CustomDomain.Company.Authorization
{
    /// <summary>
    /// 定义系统的权限名称的字符串常量。
    /// <see cref="CompanyAppAuthorizationProvider"/>中对权限的定义.
    /// </summary>
    public static class CompanyAppPermissions
    {


        /// <summary>
        /// 公司信息管理权限
        /// </summary>
        public const string Company = "Admin.Company";
        
        /// <summary>
        /// 公司信息创建权限
        /// </summary>
        public const string Company_CreateCompany = "Admin.Company.CreateCompany";

        /// <summary>
        /// 公司信息修改权限
        /// </summary>
        public const string Company_EditCompany = "Admin.Company.EditCompany";

        /// <summary>
        /// 公司信息删除权限
        /// </summary>
        public const string Company_DeleteCompany = "Admin.Company.DeleteCompany";
    }

}


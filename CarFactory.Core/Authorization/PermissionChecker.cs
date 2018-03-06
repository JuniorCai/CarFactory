using Abp.Authorization;
using CarFactory.Core.Authorization.Roles;
using CarFactory.Core.Authorization.Users;

namespace CarFactory.Core.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}

using Abp.Authorization;
using CarFactory.Authorization.Roles;
using CarFactory.Authorization.Users;

namespace CarFactory.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}

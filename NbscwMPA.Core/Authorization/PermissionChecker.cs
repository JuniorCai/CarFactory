using Abp.Authorization;
using NbscwMPACarFactory.Authorization.Roles;
using NbscwMPACarFactory.Authorization.Users;

namespace NbscwMPACarFactory.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}

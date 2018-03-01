using System.Collections.Generic;
using NbscwMPACarFactory.Roles.Dto;

namespace NbscwMPACarFactory.Web.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<RoleDto> Roles { get; set; }

        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}
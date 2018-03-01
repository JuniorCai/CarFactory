using System.Collections.Generic;
using NbscwMPACarFactory.Roles.Dto;
using NbscwMPACarFactory.Users.Dto;

namespace NbscwMPACarFactory.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<UserDto> Users { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
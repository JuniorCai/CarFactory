using System.Collections.Generic;
using CarFactory.Roles.Dto;
using CarFactory.Users.Dto;

namespace CarFactory.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<UserDto> Users { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
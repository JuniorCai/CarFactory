using System.Collections.Generic;
using CarFactory.Application.Roles.Dto;
using CarFactory.Application.Users.Dto;

namespace CarFactory.Admin.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<UserDto> Users { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
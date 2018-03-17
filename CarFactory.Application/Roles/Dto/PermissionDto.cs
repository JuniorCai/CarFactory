using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;

namespace CarFactory.Application.Roles.Dto
{
    [AutoMapFrom(typeof(Permission))]
    public class PermissionDto : EntityDto<long>
    {
        public PermissionDto Parent { get; set; }

        public string Name { get; set; }

        public string DisplayName { get; set; }

        public string Description { get; set; }

        public IReadOnlyList<PermissionDto> Children { get; set; }
    }
}
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.Authorization.Roles;
using Abp.AutoMapper;
using CarFactory.Core.Authorization.Roles;

namespace CarFactory.Application.Roles.Dto
{
    [AutoMapTo(typeof(Role))]
    public class EditRoleDto : EntityDto<int>
    {
        [Required]
        [StringLength(AbpRoleBase.MaxNameLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(AbpRoleBase.MaxDisplayNameLength)]
        public string DisplayName { get; set; }

        [Required]
        [StringLength(Role.MaxDescriptionLength)]
        public string Description { get; set; }

        [Required]
        public bool IsActive { get; set; }

        public List<string> Permissions { get; set; }
    }
}
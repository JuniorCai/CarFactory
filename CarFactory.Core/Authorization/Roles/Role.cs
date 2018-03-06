using System.ComponentModel.DataAnnotations;
using Abp.Authorization.Roles;
using CarFactory.Core.Authorization.Users;

namespace CarFactory.Core.Authorization.Roles
{
    public class Role : AbpRole<User>
    {
        public const int MaxDescriptionLength = 5000;

        public Role()
        {
        }

        public Role(int? tenantId, string displayName)
            : base(tenantId, displayName)
        {

        }

        public Role(int? tenantId, string name, string displayName)
            : base(tenantId, name, displayName)
        {

        }

        [MaxLength(MaxDescriptionLength)]
        public string Description { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities.Auditing;

namespace CarFactory.Core.CustomDomain.Company
{
    public class Company : FullAuditedEntity
    {
        [Required]
        public virtual string CompanyName { get; set; }

        public virtual string LinkMan { get; set; }

        public virtual string Phone { get; set; }

        public virtual string Tel { get; set; }

        public virtual string Email { get; set; }

        public virtual string Address { get; set; }

        public virtual string Longitude { get; set; }

        public virtual string Latitude { get; set; }

        public virtual string Introduce { get; set; }

    }
}

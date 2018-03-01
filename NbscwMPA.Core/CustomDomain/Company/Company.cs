using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace NbscwMPACarFactory.CustomDomain.Company
{
    public class Company : FullAuditedEntity
    {
        [Required]
        public virtual string CompanyName { get; set; }


        public virtual string Phone { get; set; }

        public virtual string Tel { get; set; }

        public virtual string Email { get; set; }

        public virtual string Address { get; set; }

        public virtual string Longitude { get; set; }

        public virtual string Latitude { get; set; }

    }
}

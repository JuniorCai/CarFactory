using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;

namespace NbscwMPACarFactory.CustomDomain.Information
{
    public class Information : FullAuditedEntity
    {
        [Required]
        public virtual string Title { get; set; }


       // public virtual string Relation { get; set; }

        [Required]
        public virtual string Description { get; set; }

        public virtual string IsShow { get; set; }
       
    }
}

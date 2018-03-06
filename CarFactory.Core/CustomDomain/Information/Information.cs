using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities.Auditing;

namespace CarFactory.Core.CustomDomain.Information
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

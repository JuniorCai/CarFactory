using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;

namespace CarFactory.Core.CustomDomain.Category
{
    [Table("Category")]
    public class Category : FullAuditedEntity
    {
        [Required]
        public virtual string CategoryName { get; set; }

        [Required]
        public virtual string ShortName { get; set; }

        [Required]
        public virtual bool IsShow { get; set; }

        [Required]
        public virtual int Sort { get; set; }

        //public virtual IList<Product> Products{ get; set; }
    }
}

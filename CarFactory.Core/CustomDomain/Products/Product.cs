using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;

namespace CarFactory.Core.CustomDomain.Products
{
    [Table("Product")]
    public class Product : FullAuditedEntity
    {
        [Required]
        public virtual string Title { get; set; }

        [Required]
        public virtual string Img { get; set; }

        public virtual string Url { get; set; }

        [Required]
        public virtual int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category.Category ProductCategory { get; set; }

        //public virtual int Relation { get; set; }

        [Required]
        public virtual bool IsShow { get; set; }

        [Required]
        public virtual string Detail { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;

namespace NbscwMPACarFactory.CustomDomain.Products
{
    [Table("Category")]
    public class Category : FullAuditedEntity
    {
        public virtual string CategoryName { get; set; }

        public virtual string ShortName { get; set; }

        public virtual bool IsActive { get; set; }

        public virtual int Sort { get; set; }

        //public virtual IList<Product> Products{ get; set; }
    }
}

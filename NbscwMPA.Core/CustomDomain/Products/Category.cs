using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;

namespace NbscwMPACarFactory.CustomDomain.Products
{
    public class Category : FullAuditedEntity
    {
        public virtual string Name { get; set; }

        public virtual string ShortName { get; set; }

        public virtual bool IsActive { get; set; }

        public virtual int Sort { get; set; }
    }
}

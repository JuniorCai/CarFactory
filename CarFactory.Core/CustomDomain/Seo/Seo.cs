using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;

namespace CarFactory.Core.CustomDomain.Seo
{
    public class Seo : FullAuditedEntity
    {
        [Required]
        public virtual string SiteTitle { get; set; }


        public virtual string SiteKeywords { get; set; }

        public virtual string SiteDescription { get; set; }

        [Required]
        public virtual bool WatermarkAble { get; set; }

        public virtual string Watermark { get; set; }


        public virtual string IcpNumber { get; set; }
    }
}

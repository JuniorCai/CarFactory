using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;

namespace CarFactory.Core.CustomDomain.Banner
{
    public class Banner : FullAuditedEntity
    {
        public virtual string Img { get; set; }

        public virtual string ImgAlt { get; set; }

        public virtual string ImgTitle { get; set; }

        public virtual bool IsShow { get; set; }

        public virtual int Sort { get; set; }
    }
}

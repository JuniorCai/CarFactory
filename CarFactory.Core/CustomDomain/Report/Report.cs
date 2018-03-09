using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;

namespace CarFactory.Core.CustomDomain.Report
{
    [Table("Report")]
    public class Report:FullAuditedEntity
    {
        public virtual  string ReportName { get; set; }

        public virtual string Img { get; set; }

        public virtual string RelativeId { get; set; }

    }
}

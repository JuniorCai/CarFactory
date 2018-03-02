using System;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Authorization.Users;
using Abp.Domain.Entities.Auditing;
using Abp.Extensions;
using Microsoft.AspNet.Identity;

namespace NbscwMPACarFactory.CustomDomain.Products
{
    public class Product : FullAuditedEntity
    {
        public virtual string Title { get; set; }

        public virtual string Img { get; set; }

        public virtual string Url { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category ProductCategory { get; set; }

        //public virtual int Relation { get; set; }

        public virtual bool IsShow { get; set; }
    }
}
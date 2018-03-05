using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities.Auditing;

namespace CarFactory.Messages
{
    public class Message : FullAuditedEntity
    {
        [Required]
        public virtual string Title { get; set; }

        public virtual int TypeId { get; set; }

        [MaxLength(255)]
        public virtual string Detail { get; set; }

        [Required]
        public virtual int SenderId { get; set; }

        [Required]
        public virtual int RecipientId { get; set; }

        public virtual string SendIp { get; set; }

        public virtual int IsSend { get; set; }

        public virtual int IsRead { get; set; }

        public virtual int InRecycle { get; set; }
    }
}

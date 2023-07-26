using System;
using System.Collections.Generic;

namespace NstuOnline.MessageService.Domain.Entities;

public class Message
{
    public Guid Id { get; set; }
    
    public User User { get; set; }
    public Guid UserId { get; set; }

    public Guid ChatId { get; set; }

    public string Text { get; set; }

    public DateTime CreateDate { get; set; }

    //public ICollection<MessageAttachment> MessageAttachments { get; set; }

    public ICollection<Attachment> Attachments { get; set; }
}
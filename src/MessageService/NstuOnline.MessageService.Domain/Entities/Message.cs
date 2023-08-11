using System;
using System.Collections.Generic;
using Common.Data.Entities;

namespace NstuOnline.MessageService.Domain.Entities;

public class Message : EntityBase
{
    public User User { get; set; }
    public Guid UserId { get; set; }

    public Guid ChatId { get; set; }
    
    public Guid? ParentId { get; set; }
    
    public Message Parent { get; set; }
    
    public string Text { get; set; }

    public DateTime CreateDate { get; set; }

    //public ICollection<MessageAttachment> MessageAttachments { get; set; }

    public ICollection<Attachment> Attachments { get; set; }
    
    public ICollection<Message> Children { get; set; }
}
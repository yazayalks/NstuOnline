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
    
    public DateTime? UpdatedDate { get; set; }
    
    public bool IsDeleted { get; set; }
    
    public byte MessageStatusId { get; set; }

    public MessageStatus MessageStatus { get; set; }
    
    public byte MessageTypeId { get; set; }

    public MessageType MessageType { get; set; }

    //public ICollection<MessageAttachment> MessageAttachments { get; set; }

    public ICollection<Attachment> Attachments { get; set; }
    
    public ICollection<Message> Children { get; set; }
    
    public string ExternalId { get; set; }
}
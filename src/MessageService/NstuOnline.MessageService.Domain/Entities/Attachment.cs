using System;
using System.Collections.Generic;

namespace NstuOnline.MessageService.Domain.Entities;

public class Attachment
{
    public Guid Id { get; set; }
    
    public Guid FileId { get; set; }
    
    public byte AttachmentTypeId { get; set; }
    
    public AttachmentType AttachmentType { get; set; }
    
    //public ICollection<MessageAttachment> MessageAttachments { get; set; } = new List<MessageAttachment>();
    
    public ICollection<Message> Messages { get; set; }
}
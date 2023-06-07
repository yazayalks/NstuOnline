using System;

namespace NstuOnline.MessageService.Domain.Entities;

public class MessageAttachment
{
    public Guid MessageId { get; set; }
    
    public Message Message { get; set; }
    
    public Guid AttachmentId { get; set; }
    
    public Attachment Attachment { get; set; }
}
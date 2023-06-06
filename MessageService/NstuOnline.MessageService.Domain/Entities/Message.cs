using System;

namespace NstuOnline.MessageService.Domain.Entities;

public class Message
{
    public Guid UserId { get; set; }
    
    public Guid ChatId { get; set; }
    
    public string Text { get; set; }
    
    public DateTime CreateDate { get; set; }
}
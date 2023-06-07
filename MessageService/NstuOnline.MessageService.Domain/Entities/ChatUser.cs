using System;

namespace NstuOnline.MessageService.Domain.Entities;

public class ChatUser
{
    public Guid UserId { get; set; }
    
    
    public Chat Chat { get; set; }
    public Guid ChatId { get; set; }
}
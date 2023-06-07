using System;
using System.Collections.Generic;

namespace NstuOnline.MessageService.Domain.Entities;

public class Chat
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public byte ChatTypeId { get; set; }
    
    public ChatType ChatType { get; set; }
    
    public ICollection<Message> Messages { get; set; } = new List<Message>();
    
    public ICollection<ChatUser> ChatUsers { get; set; } = new List<ChatUser>();
}
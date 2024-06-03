using System;
using System.Collections.Generic;
using Common.Data.Entities;

namespace NstuOnline.MessageService.Domain.Entities;

public class Chat : ArchivableEntity
{
    public string Name { get; set; }

    public byte ChatTypeId { get; set; }

    public ChatType ChatType { get; set; }

    public ICollection<Message> Messages { get; set; }

    public ICollection<ChatUser> ChatUsers { get; set; }
    
    /// <summary>
    /// В рамках чего создан чат (дисциплина, беседа группы, лабораторная работа)
    /// </summary>
    public Guid? ParentId { get; set; } 
    
    public string ExternalId { get; set; }
}
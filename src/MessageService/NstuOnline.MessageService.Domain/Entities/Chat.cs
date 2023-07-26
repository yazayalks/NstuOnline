using System;
using System.Collections.Generic;
using Common.Data.Entities;

namespace NstuOnline.MessageService.Domain.Entities;

public class Chat : EntityBase
{
    public string Name { get; set; }

    public byte ChatTypeId { get; set; }

    public ChatType ChatType { get; set; }

    public ICollection<Message> Messages { get; set; }

    public ICollection<ChatUser> ChatUsers { get; set; }
}
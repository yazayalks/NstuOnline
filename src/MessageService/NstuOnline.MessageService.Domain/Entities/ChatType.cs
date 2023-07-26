using System;
using NstuOnline.MessageService.Domain.Enums;

namespace NstuOnline.MessageService.Domain.Entities;

public class ChatType
{
    public byte Id { get; set; }
    
    public string Code { get; set; }
    
    public string Name { get; set; }
}
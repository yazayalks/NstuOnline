using System;
using Common.Data.Entities;
using NstuOnline.MessageService.Domain.Enums;

namespace NstuOnline.MessageService.Domain.Entities;

public class ChatType : DictionaryEntity
{
    public string Code { get; set; }

    public ChatType(byte id, string name, string code) : base(id, name)
    {
        Code = code;
    }
}
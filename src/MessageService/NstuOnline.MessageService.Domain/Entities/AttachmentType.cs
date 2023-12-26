using System;
using Common.Data.Entities;

namespace NstuOnline.MessageService.Domain.Entities;

public class AttachmentType : DictionaryEntity
{
    public string Code { get; set; }

    public AttachmentType(byte id, string name, string code) : base(id, name)
    {
        Code = code;
    }
}
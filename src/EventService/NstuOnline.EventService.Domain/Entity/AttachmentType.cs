using Common.Data.Entities;

namespace NstuOnline.EventService.Domain.Entity;

public class AttachmentType : DictionaryEntity
{
    public string Code { get; set; }

    public AttachmentType(byte id, string code, string name) : base(id, name)
    {
        Code = code;
    }
}
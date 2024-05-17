using Common.Data.Entities;

namespace NstuOnline.WorkCompletion.Domain.Entity;

public class AttachmentType : DictionaryEntity
{
    public string Code { get; set; }

    public AttachmentType(byte id, string name, string code) : base(id, name)
    {
        Code = code;
    }
}
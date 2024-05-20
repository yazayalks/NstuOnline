using Common.Data.Entities;

namespace NstuOnline.EducationalStructure.Domain.Entity;

public class AttachmentType : DictionaryEntity
{
    public string Code { get; set; }

    public AttachmentType(byte id, string code, string name) : base(id, name)
    {
        Code = code;
    }
}
using Common.Data.Entities;

namespace NstuOnline.EducationalStructure.Domain.Entity;

public class AccreditationType : DictionaryEntity
{
    public string Code { get; set; }

    public AccreditationType(byte id, string name, string code) : base(id, name)
    {
        Code = code;
    }
}
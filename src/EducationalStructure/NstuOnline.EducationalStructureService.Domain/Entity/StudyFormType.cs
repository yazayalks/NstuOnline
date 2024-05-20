using Common.Data.Entities;

namespace NstuOnline.EducationalStructure.Domain.Entity;
/// <summary>
/// Форма обучения
/// </summary>
public class StudyFormType : DictionaryEntity
{
    public string Code { get; set; }

    public StudyFormType(byte id, string name, string code) : base(id, name)
    {
        Code = code;
    }
}
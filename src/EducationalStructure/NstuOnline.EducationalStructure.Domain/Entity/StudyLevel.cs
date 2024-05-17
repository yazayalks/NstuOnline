using Common.Data.Entities;

namespace NstuOnline.EducationalStructure.Domain.Entity;
/// <summary>
/// Учёная степень
/// </summary>
public class StudyLevel : DictionaryEntity
{
    public string Code { get; set; }
    
    public byte NbSemester { get; set; }

    public StudyLevel(byte id, string name, string code, byte nbSemester) : base(id, name)
    {
        Code = code;
        NbSemester = nbSemester;
    }
}
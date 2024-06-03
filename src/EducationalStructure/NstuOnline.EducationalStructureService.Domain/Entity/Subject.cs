using Common.Data.Entities;

namespace NstuOnline.EducationalStructure.Domain.Entity;
/// <summary>
/// Предмет (дисциплина)
/// </summary>
public class Subject : EntityBase
{
    public string Name { get; set; }
    
    public string ExternalId { get; set; }
    //LIST TOPIC
}
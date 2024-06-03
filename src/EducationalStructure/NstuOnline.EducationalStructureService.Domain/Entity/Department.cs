using Common.Data.Entities;

namespace NstuOnline.EducationalStructure.Domain.Entity;
/// <summary>
/// Кафедра
/// </summary>
public class Department : EntityBase
{
    public string Name { get; set; }
    
    public Guid FacultyId { get; set; }
    public Faculty Faculty { get; set; }
    
    public string ExternalId { get; set; }
}
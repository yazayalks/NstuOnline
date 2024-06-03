using Common.Data.Entities;

namespace NstuOnline.EducationalStructure.Domain.Entity;
/// <summary>
/// Специализация
/// </summary>
public class Specialization : EntityBase
{
    public string Name { get; set; }
    
    public string Code { get; set; }
    
    public Guid DepartmentId { get; set; }
    public Department Department { get; set; }
    
    public string ExternalId { get; set; }
}
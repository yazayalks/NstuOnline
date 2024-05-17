using Common.Data.Entities;

namespace NstuOnline.EducationalStructure.Domain.Entity;
/// <summary>
/// Преподаватель
/// </summary>
public class Teacher : EntityBase
{
    public Guid UserId { get; set; }
    
    public Guid DepartmentId { get; set; }
    public Department Department { get; set; }
}
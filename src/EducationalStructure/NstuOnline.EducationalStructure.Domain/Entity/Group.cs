using Common.Data.Entities;

namespace NstuOnline.EducationalStructure.Domain.Entity;
/// <summary>
/// Группа
/// </summary>
public class Group : EntityBase
{
    public string Code { get; set; }
    
    public DateOnly StartDate { get; set; }
    
    public byte Semester { get; set; }
    
    public Guid DepartmentId { get; set; }
    public Department Department { get; set; }
}
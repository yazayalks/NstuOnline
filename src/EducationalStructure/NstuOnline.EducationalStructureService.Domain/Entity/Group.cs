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
    
    public bool IsDeleted { get; set; }
    public Department Department { get; set; }
    
    public Guid? FlowId { get; set; }
    
    public Flow Flow { get; set; }
    
    public string ExternalId { get; set; }
}
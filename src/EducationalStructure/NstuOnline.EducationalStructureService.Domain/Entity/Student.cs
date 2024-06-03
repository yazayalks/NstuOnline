using Common.Data.Entities;

namespace NstuOnline.EducationalStructure.Domain.Entity;

public class Student : EntityBase
{
    public Guid UserId { get; set; }
    
    public Guid GroupId { get; set; }
    public Group Group { get; set; }
    
    public Guid SyllabusId { get; set; }
    public Syllabus Syllabus { get; set; }
    
    public string ExternalId { get; set; }
}
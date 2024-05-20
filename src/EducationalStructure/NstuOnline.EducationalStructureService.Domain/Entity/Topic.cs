using Common.Data.Entities;

namespace NstuOnline.EducationalStructure.Domain.Entity;

public class Topic : EntityBase
{
    public Guid SubjectId { get; set; }
    public Subject Subject { get; set; }
    
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public ICollection<Attachment> Attachments { get; set; }
}
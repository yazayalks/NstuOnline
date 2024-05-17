using Common.Data.Entities;

namespace NstuOnline.WorkCompletion.Domain.Entity;

public class Work : ArchivableEntity
{
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public Guid SyllabusSubjectId { get; set; }

    public List<Attachment> Attachments { get; set; }
}
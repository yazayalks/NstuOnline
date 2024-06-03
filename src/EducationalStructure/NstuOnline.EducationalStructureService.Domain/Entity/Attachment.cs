using Common.Data.Entities;

namespace NstuOnline.EducationalStructure.Domain.Entity;

public class Attachment : EntityBase
{
    public Guid FileId { get; set; }

    public byte AttachmentTypeId { get; set; }

    public ICollection<Topic> Topics { get; set; }
    
    public string ExternalId { get; set; }
}
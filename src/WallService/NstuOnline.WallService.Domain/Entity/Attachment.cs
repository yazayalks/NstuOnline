using Common.Data.Entities;

namespace NstuOnline.WallService.Domain.Entity;

public class Attachment : EntityBase
{
    public Guid FileId { get; set; }

    public byte AttachmentTypeId { get; set; }

    public ICollection<AttachmentUser> Users { get; set; }
    
    public ICollection<RecordAttachment> Records { get; set; }
}
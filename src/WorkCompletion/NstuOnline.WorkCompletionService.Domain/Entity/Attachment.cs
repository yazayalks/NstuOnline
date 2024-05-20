using Common.Data.Entities;

namespace NstuOnline.WorkCompletion.Domain.Entity;

public class Attachment : EntityBase
{
    public Guid FileId { get; set; }

    public byte AttachmentTypeId { get; set; }

    public AttachmentType AttachmentType { get; set; }
}
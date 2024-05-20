using Common.Data.Entities;

namespace NstuOnline.AlbumService.Domain.Entity;

public class Attachment : EntityBase
{
    public Guid FileId { get; set; }

    public ICollection<AttachmentUser> Users { get; set; }
}
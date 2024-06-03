using Common.Data.Entities;

namespace NstuOnline.PortfolioService.Domain.Entity;

public class Attachment : EntityBase
{
    public Guid FileId { get; set; }

    public byte AttachmentTypeId { get; set; }

    public ICollection<TopicAttachment> Topics { get; set; }
}
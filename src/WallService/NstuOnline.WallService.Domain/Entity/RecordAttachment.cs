namespace NstuOnline.WallService.Domain.Entity;

public class RecordAttachment
{
    public Guid RecordId { get; set; }
    
    public Record Record { get; set; }
    
    public Guid AttachmentId { get; set; }
    
    public Attachment Attachment { get; set; }
}
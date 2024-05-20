namespace NstuOnline.AlbumService.Domain.Entity;

public class AttachmentUser
{
    public Guid AttachmentId { get; set; }
    
    public Attachment Attachment { get; set; }
    
    public Guid UserId { get; set; }
    
    public User User { get; set; }
}
using Common.Data.Entities;

namespace NstuOnline.AlbumService.Domain.Entity;

public class Album : EntityBase
{
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public Guid UserId { get; set; }
    
    public User User { get; set; }
    
    public List<Attachment> Attachments { get; set; }
}
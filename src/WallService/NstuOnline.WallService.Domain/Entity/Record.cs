using Common.Data.Entities;

namespace NstuOnline.WallService.Domain.Entity;

public class Record : EntityBase
{
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public Guid UserId { get; set; }
    
    public User User { get; set; }
    
    public DateTime CreatedDate { get; set; }
    
    public DateTime? UpdatedDate { get; set; }
    
    public List<RecordAttachment> Attachments { get; set; }
    
    public List<RecordUser> Users { get; set; }
}
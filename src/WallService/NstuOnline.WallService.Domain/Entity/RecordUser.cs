namespace NstuOnline.WallService.Domain.Entity;

public class RecordUser
{
    public Guid RecordId { get; set; }
    
    public Record Record { get; set; }
    
    public Guid UserId { get; set; }
    
    public User User { get; set; }
}
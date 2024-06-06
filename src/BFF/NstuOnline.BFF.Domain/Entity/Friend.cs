namespace NstuOnline.BFF.Domain.Entity;

public class Friend
{
    public Guid UserId { get; set; }
    public User User { get; set; }

    public Guid FriendId { get; set; }
    public User FriendUser { get; set; }
}
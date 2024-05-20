using Common.Data.Entities;

namespace NstuOnline.EventService.Domain.Entity;

public class Member : EntityBase
{
    public Guid UserId { get; set; }
    
    public byte MemberStatusId { get; set; }
    public MemberStatus MemberStatus { get; set; }
    
    public ICollection<Event> Events { get; set; }
}
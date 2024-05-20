using Common.Data.Entities;

namespace NstuOnline.EventService.Domain.Entity;

public class EventMember : EntityBase
{
    public Guid EventId { get; set; }
    
    public Event Event { get; set; }
    
    public Guid MemberId { get; set; }
    
    public Member Member { get; set; }
}
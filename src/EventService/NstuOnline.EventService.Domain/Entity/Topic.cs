using Common.Data.Entities;

namespace NstuOnline.EventService.Domain.Entity;

public class Topic : EntityBase
{
    public Guid EventId { get; set; }
    public Event Event { get; set; }
    
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public ICollection<TopicAttachment> Attachments { get; set; }
}
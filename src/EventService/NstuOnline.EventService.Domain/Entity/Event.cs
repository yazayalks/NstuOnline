using Common.Data.Entities;

namespace NstuOnline.EventService.Domain.Entity;

public class Event : ArchivableEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    
    public bool IsRequired { get; set; }
    
    public byte EventTypeId { get; set; }
    public EventType EventType { get; set; }
    
    public byte EventStatusId { get; set; }
    public EventStatus EventStatus { get; set; }
    
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }

    public List<Topic> Topics { get; set; }
    
    public ICollection<Member> Members { get; set; }
}
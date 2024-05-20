using Common.Data.Entities;

namespace NstuOnline.PortfolioService.Domain.Entity;

public class Topic : EntityBase
{
    public Guid PortfolioId { get; set; }
    public Portfolio Portfolio { get; set; }
    
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public ICollection<TopicAttachment> Attachments { get; set; }
}
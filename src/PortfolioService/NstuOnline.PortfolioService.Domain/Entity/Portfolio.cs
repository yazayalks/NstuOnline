using Common.Data.Entities;

namespace NstuOnline.PortfolioService.Domain.Entity;

public class Portfolio : EntityBase
{
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public bool IsRequired { get; set; }
    
    public byte PortfolioTypeId { get; set; }
    public PortfolioType PortfolioType { get; set; }
    
    public List<Topic> Topics { get; set; }
    
    public ICollection<PortfolioUser> Users { get; set; }
}
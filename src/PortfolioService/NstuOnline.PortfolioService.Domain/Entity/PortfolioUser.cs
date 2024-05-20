namespace NstuOnline.PortfolioService.Domain.Entity;

public class PortfolioUser
{
    public Guid PortfolioId { get; set; }
    
    public Portfolio Portfolio { get; set; }
    
    public Guid UserId { get; set; }
    
    public User User { get; set; }
}
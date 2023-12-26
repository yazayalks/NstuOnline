using Common.Models;

namespace NstuOnline.BFF.Application.Services.Message.Models;

public record SearchMessageRequest : PagedRequest
{
    public string Keyword { get; set; }
    
    public Guid UserId { get; set; }
    
    public Guid ChatId { get; set; }
}
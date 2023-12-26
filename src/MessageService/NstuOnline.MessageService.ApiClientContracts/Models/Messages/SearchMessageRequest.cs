using Common.Models;

namespace NstuOnline.MessageService.ApiClientContracts.Models.Messages;

public record SearchMessageRequest : PagedRequest
{
    public string Keyword { get; set; }
    
    public Guid UserId { get; set; }
    
    public Guid ChatId { get; set; }
}
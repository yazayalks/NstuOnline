using Common.Models;

namespace NstuOnline.MessageService.ApiClientContracts.Models.Chats;

public record SearchChatsRequest : PagedRequest
{
    public Guid UserId { get; set; }
    
    public byte? ChatTypeId { get; set; }
}
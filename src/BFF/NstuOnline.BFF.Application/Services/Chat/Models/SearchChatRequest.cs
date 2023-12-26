using System.Text.Json.Serialization;
using Common.Models;

namespace NstuOnline.BFF.Application.Services.Chat.Models;

public record SearchChatRequest : PagedRequest
{
    [JsonIgnore]
    public Guid UserId { get; set; }
    
    public byte? ChatTypeId { get; set; }
}
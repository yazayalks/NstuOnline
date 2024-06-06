using System;
using Common.Models;

namespace NstuOnline.MessageService.Domain.Models;

public record SearchChatCriteria : PagedRequest
{
    public string Keyword { get; set; }
    public Guid UserId { get; set; }
    
    public byte? ChatTypeId { get; set; }
}
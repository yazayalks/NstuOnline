using System;
using Common.Models;

namespace NstuOnline.MessageService.Domain.Models;

public record SearchChatCriteria : PagedRequest
{
    public Guid UserId { get; set; }
    
    public byte? ChatTypeId { get; set; }
}
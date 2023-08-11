using System;
using Common.Models;

namespace NstuOnline.MessageService.Domain.Models;

public record SearchMessageCriteria : PagedRequest
{
    public string Keyword { get; set; }
    
    public Guid UserId { get; set; }
    
    public Guid ChatId { get; set; }
}
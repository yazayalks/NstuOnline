using System;
using System.Collections.Generic;
using Common.Models;

namespace NstuOnline.MessageService.Domain.Models;

public record SimplifySearchMessageCriteria : PagedRequest
{
    public Guid UserId { get; set; }

    public IEnumerable<Guid> ChatIds { get; set; }

    public bool IsLast { get; set; }
}
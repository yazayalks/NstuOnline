﻿using Common.Models;

namespace NstuOnline.MessageService.ApiClientContracts.Models.Chats;

public record SearchChatRequest : PagedRequest
{
    public Guid UserId { get; set; }
    
    public byte? ChatTypeId { get; set; }
}
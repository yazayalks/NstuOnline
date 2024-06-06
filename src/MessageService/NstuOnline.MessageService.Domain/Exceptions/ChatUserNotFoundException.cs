using System;
using Common.Data.Exceptions;
using NstuOnline.MessageService.Domain.Enums;

namespace NstuOnline.MessageService.Domain.Exceptions;

public class ChatUserNotFoundException  : ValidationException
{
    public ChatUserNotFoundException(Guid userId, Guid chatId, ExceptionEntityTypes exceptionEntityType)
        : base($"Entities of {exceptionEntityType} by userId {userId} and chatId {chatId} not found.",
            nameof(EntitiesNotFoundException),
            new { EntityType = exceptionEntityType.ToString()})
    {
    }
}
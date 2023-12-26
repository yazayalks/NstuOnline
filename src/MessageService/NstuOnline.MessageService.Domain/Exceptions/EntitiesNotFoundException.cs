using System;
using System.Collections.Generic;
using System.Linq;
using Common.Data.Exceptions;
using NstuOnline.MessageService.Domain.Enums;

namespace NstuOnline.MessageService.Domain.Exceptions;

public class EntitiesNotFoundException : ValidationException
{
    public EntitiesNotFoundException(string[] keys, ExceptionEntityTypes exceptionEntityType, string fieldName)
        : base($"Entities of {exceptionEntityType} by field {fieldName} not found: {string.Join(", ", keys)}",
            nameof(EntitiesNotFoundException),
            new { EntityType = exceptionEntityType.ToString(), Keys = keys, FieldName = fieldName })
    {
    }

    public EntitiesNotFoundException(IEnumerable<Guid> keys, ExceptionEntityTypes exceptionEntityType, string fieldName)
        : this(keys.Select(s => s.ToString()).ToArray(), exceptionEntityType, fieldName)
    {
    }

    public EntitiesNotFoundException(byte key, ExceptionEntityTypes exceptionEntityType, string fieldName)
        : this(new[] { key.ToString() }, exceptionEntityType, fieldName)
    {
    }

    public EntitiesNotFoundException(Guid key, ExceptionEntityTypes exceptionEntityType, string fieldName)
        : this(new[] { key.ToString() }, exceptionEntityType, fieldName)
    {
    }

    public EntitiesNotFoundException(long key, ExceptionEntityTypes exceptionEntityType, string fieldName)
        : this(new[] { key.ToString() }, exceptionEntityType, fieldName)
    {
    }
}
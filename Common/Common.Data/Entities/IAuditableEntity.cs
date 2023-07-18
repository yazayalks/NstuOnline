using System;

namespace Common.Data.Entities
{
    public interface IAuditableEntity<TKey> : IAuditableDateTime
        where TKey : struct
    {
        TKey CreatedBy { get; set; }
        TKey? UpdatedBy { get; set; }
    }

    public interface IAuditableEntity : IAuditableEntity<Guid> { }
}

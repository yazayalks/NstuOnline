using System;

namespace Common.Data.Entities
{
    public abstract class AuditableEntity<TKey, TUserKey> : EntityBase<TKey>, IAuditableEntity<TUserKey>
        where TKey : struct
        where TUserKey : struct
    {
        public DateTime CreatedDate { get; set; }
        public TUserKey CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public TUserKey? UpdatedBy { get; set; }
    }

    public abstract class AuditableEntity : AuditableEntity<Guid, Guid>, IAuditableEntity
    {
    }
}
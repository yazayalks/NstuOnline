using System;

namespace Common.Data.Entities
{
    public class ArchivableEntity<TKey, TUserKey> : AuditableEntity<TKey, TUserKey>, IArchivableEntity
        where TKey : struct
        where TUserKey : struct
    {
        public bool IsDeleted { get; set; }
    }

    public class ArchivableEntity : ArchivableEntity<Guid, Guid>
    {
    }
}
using System;

namespace Common.Data.Entities
{
    public abstract class EntityBase<TKey> : IEntity<TKey>
    {
        public TKey Id { get; set; }
    }

    public abstract class EntityBase : EntityBase<Guid>, IEntity { }
}

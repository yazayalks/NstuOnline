using System;

namespace Common.Data.Entities
{
    public interface IEntity<TKey>
    {
        TKey Id { get; set; }
    }

    public interface IEntity
    {
        Guid Id { get; set; }
    }
}

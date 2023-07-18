using System;

namespace Common.Data.Entities
{
    public interface IAuditableDateTime
    {
        DateTime CreatedDate { get; set; }
        DateTime? UpdatedDate { get; set; }
    }
}
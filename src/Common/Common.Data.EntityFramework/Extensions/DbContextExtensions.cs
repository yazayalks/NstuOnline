using System;
using System.Linq;
using Common.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Common.Data.EntityFramework.Extensions
{
    public static class DbContextExtensions
    {
        public static void SetAuditableEntitiesCreateUpdateDates(this DbContext context)
        {
            var entries = context.ChangeTracker
                .Entries()
                .Where(e => e.Entity is IAuditableDateTime &&
                    (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entry in entries)
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        ((IAuditableDateTime) entry.Entity).CreatedDate = DateTime.UtcNow;
                        break;
                    case EntityState.Modified:
                        ((IAuditableDateTime) entry.Entity).UpdatedDate = DateTime.UtcNow;
                        break;
                }
            }
        }
    }
}

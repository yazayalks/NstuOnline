using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NstuOnline.BFF.Domain.Entity;

namespace NstuOnline.BFF.Infrastructure.Database;

public class ApplicationContext : IdentityDbContext<User>
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(
            "Host=host.docker.internal;Port=5433;Database=NstuOnlineIdentityDb;Username=postgres;Password=6969");
    }
}
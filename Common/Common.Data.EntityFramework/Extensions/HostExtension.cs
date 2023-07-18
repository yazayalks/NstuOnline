using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Common.Data.EntityFramework.Extensions
{
    public static class HostExtensions
    {
        public static async Task MigrateDatabase<TContext>(this IHost host, CancellationToken cancellationToken) where TContext : DbContext
        {
            using var serviceScope = host.Services.CreateScope();
            var context = serviceScope.ServiceProvider.GetService<TContext>();

            await context.Database.MigrateAsync(cancellationToken);
        }
    }
}

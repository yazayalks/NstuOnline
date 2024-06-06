using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace NstuOnline.BFF.Infrastructure.Database;

// public class ApplicationContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
// {
//     public ApplicationContext CreateDbContext(string[] args)
//     {
//         var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
//         optionsBuilder.UseNpgsql("User ID=postgres;Password=6969;Host=localhost;Port=5433;Database=NstuOnlineIdentityDb;");
//
//         return new ApplicationContext(optionsBuilder.Options);
//     }
// }
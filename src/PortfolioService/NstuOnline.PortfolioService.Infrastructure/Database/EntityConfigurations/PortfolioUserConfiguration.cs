using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NstuOnline.PortfolioService.Domain.Entity;

namespace NstuOnline.PortfolioService.Infrastructure.Database.EntityConfigurations;

public class PortfolioUserConfiguration : IEntityTypeConfiguration<PortfolioUser>
{
    public void Configure(EntityTypeBuilder<PortfolioUser> builder)
    {
        builder.ToTable("portfolio_user");

        builder
            .HasKey(x => new { x.PortfolioId, x.UserId });

        builder
            .HasOne(x => x.Portfolio)
            .WithMany(x => x.Users)
            .HasForeignKey(x => x.PortfolioId);
        
        builder.HasOne(x => x.User)
            .WithMany()
            .HasForeignKey(x => x.UserId);
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NstuOnline.PortfolioService.Domain.Entity;

namespace NstuOnline.PortfolioService.Infrastructure.Database.EntityConfigurations;

public class PortfolioConfiguration : IEntityTypeConfiguration<Portfolio>
{
    public void Configure(EntityTypeBuilder<Portfolio> builder)
    {
        builder.ToTable("portfolio");
        
        builder
            .HasKey(x => x.Id);
        
        builder
            .Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder
            .Property(x => x.Description)
            .IsRequired()
            .HasMaxLength(100);
        
        builder
            .HasOne(x => x.PortfolioType)
            .WithMany()
            .HasForeignKey(x => x.PortfolioTypeId);
        
        builder
            .HasMany(x => x.Topics)
            .WithOne();
        
        builder
            .HasMany(x => x.Users)
            .WithOne();
    }
}
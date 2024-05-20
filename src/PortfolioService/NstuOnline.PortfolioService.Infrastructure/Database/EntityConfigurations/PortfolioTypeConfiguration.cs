using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NstuOnline.PortfolioService.Domain.Entity;
using NstuOnline.PortfolioService.Domain.Enums;

namespace NstuOnline.PortfolioService.Infrastructure.Database.EntityConfigurations;

public class PortfolioTypeConfiguration : IEntityTypeConfiguration<PortfolioType>
{
    public void Configure(EntityTypeBuilder<PortfolioType> builder)
    {
        builder.ToTable("portfolio_type");
        
        builder
            .HasKey(x => x.Id);

        builder
            .Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder
            .HasIndex(x => x.Code)
            .IsUnique();
        
        builder.HasData(GetDefaultPortfolioTypes());
    }

    private List<PortfolioType> GetDefaultPortfolioTypes()
    {
        return new List<PortfolioType>
        {
            new((byte)PortfolioTypes.Educational, "educational", "Учебное"),
            new((byte)PortfolioTypes.Personal, "personal", "Личное")
        };
    }
}
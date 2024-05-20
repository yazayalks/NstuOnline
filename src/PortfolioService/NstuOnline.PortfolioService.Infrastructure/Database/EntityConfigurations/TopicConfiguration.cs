using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NstuOnline.PortfolioService.Domain.Entity;

namespace NstuOnline.PortfolioService.Infrastructure.Database.EntityConfigurations;

public class TopicConfiguration : IEntityTypeConfiguration<Topic>
{
    public void Configure(EntityTypeBuilder<Topic> builder)
    {
        builder.ToTable("topic");
        
        builder
            .HasKey(x => x.Id);

        builder
            .Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(50);
        
        builder
            .Property(x => x.Description)
            .IsRequired()
            .HasMaxLength(1000);
        
        builder
            .HasOne(x => x.Portfolio)
            .WithMany(x => x.Topics)
            .HasForeignKey(x => x.PortfolioId);
    }
}
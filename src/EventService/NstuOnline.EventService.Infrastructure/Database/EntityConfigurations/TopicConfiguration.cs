using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NstuOnline.EventService.Domain.Entity;

namespace NstuOnline.EventService.Infrastructure.Database.EntityConfigurations;

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
        
        builder.HasOne(x => x.Event)
            .WithMany(x => x.Topics)
            .HasForeignKey(x => x.EventId);

        builder.HasMany(x => x.Attachments)
            .WithOne(x => x.Topic)
            .HasForeignKey(x => x.TopicId);
    }
}
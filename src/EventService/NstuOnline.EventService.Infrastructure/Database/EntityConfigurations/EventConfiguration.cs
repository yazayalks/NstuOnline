using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NstuOnline.EventService.Domain.Entity;

namespace NstuOnline.EventService.Infrastructure.Database.EntityConfigurations;

public class EventConfiguration : IEntityTypeConfiguration<Event>
{
    public void Configure(EntityTypeBuilder<Event> builder)
    {
        builder.ToTable("event");
        
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
            .HasOne(x => x.EventStatus)
            .WithMany()
            .HasForeignKey(x => x.EventStatusId);
        
        builder
            .HasOne(x => x.EventType)
            .WithMany()
            .HasForeignKey(x => x.EventTypeId);
        
        builder
            .HasMany(x => x.Topics)
            .WithOne();
    }
}
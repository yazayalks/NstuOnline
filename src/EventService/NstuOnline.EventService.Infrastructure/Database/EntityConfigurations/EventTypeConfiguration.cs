using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NstuOnline.EventService.Domain.Entity;
using NstuOnline.EventService.Domain.Enums;

namespace NstuOnline.EventService.Infrastructure.Database.EntityConfigurations;

public class EventTypeConfiguration : IEntityTypeConfiguration<EventType>
{
    public void Configure(EntityTypeBuilder<EventType> builder)
    {
        builder.ToTable("event_type");
        
        builder
            .HasKey(x => x.Id);

        builder
            .Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder
            .HasIndex(x => x.Code)
            .IsUnique();
        
        builder.HasData(GetDefaultEventTypes());
    }

    private List<EventType> GetDefaultEventTypes()
    {
        return new List<EventType>
        {
            new((byte)EventTypes.Olympics, "olympics", "Олимпиада"),
            new((byte)EventTypes.Hackathon, "hackathon", "Хакатон"),
            new((byte)EventTypes.Conference, "conference", "Конференция"),
            new((byte)EventTypes.Holiday, "holiday", "Праздник"),
            new((byte)EventTypes.Concert, "concert", "Концерт"),
        };
    }
}
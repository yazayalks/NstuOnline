using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NstuOnline.EventService.Domain.Entity;
using NstuOnline.EventService.Domain.Enums;

namespace NstuOnline.EventService.Infrastructure.Database.EntityConfigurations;

public class EventStatusConfiguration : IEntityTypeConfiguration<EventStatus>
{
    public void Configure(EntityTypeBuilder<EventStatus> builder)
    {
        builder.ToTable("event_status");
        
        builder
            .HasKey(x => x.Id);

        builder
            .Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder
            .HasIndex(x => x.Code)
            .IsUnique();
        
        builder.HasData(GetDefaultEventStatuses());
    }

    private List<EventStatus> GetDefaultEventStatuses()
    {
        return new List<EventStatus>
        {
            new((byte)EventStatuses.Pending, "pending", "В ожидании"),
            new((byte)EventStatuses.Started, "started", "Началось"),
            new((byte)EventStatuses.Ended, "ended", "Закончилось")
        };
    }
}
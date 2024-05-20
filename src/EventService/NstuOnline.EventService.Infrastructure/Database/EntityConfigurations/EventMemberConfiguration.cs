using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NstuOnline.EventService.Domain.Entity;

namespace NstuOnline.EventService.Infrastructure.Database.EntityConfigurations;

public class EventMemberConfiguration : IEntityTypeConfiguration<EventMember>
{
    public void Configure(EntityTypeBuilder<EventMember> builder)
    {
        builder.ToTable("event_member");

        builder
            .HasKey(x => new { x.EventId, x.MemberId });

        builder
            .HasOne(x => x.Event)
            .WithMany()
            .HasForeignKey(x => x.EventId);

        builder
            .HasOne(x => x.Member)
            .WithMany()
            .HasForeignKey(x => x.MemberId);
    }
}
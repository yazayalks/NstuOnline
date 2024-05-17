using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NstuOnline.MessageService.Domain.Entities;
using NstuOnline.MessageService.Domain.Enums;

namespace NstuOnline.MessageService.Infrastructure.Database.EntityConfigurations;

public class MessageStatusConfiguration : IEntityTypeConfiguration<MessageStatus>
{
    public void Configure(EntityTypeBuilder<MessageStatus> builder)
    {
        builder.ToTable("message_status");

        builder
            .Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder
            .HasIndex(x => x.Code)
            .IsUnique();

        builder.HasData(GetDefaultMessageStatuses());
    }

    private List<MessageStatus> GetDefaultMessageStatuses()
    {
        return new List<MessageStatus>
        {
            new((byte)MessageStatuses.Sent, "sent", "Отправленно"),
            new((byte)MessageStatuses.Read, "read", "Прочитанно"),
        };
    }
}
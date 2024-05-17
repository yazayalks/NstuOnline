
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NstuOnline.MessageService.Domain.Entities;
using NstuOnline.MessageService.Domain.Enums;

namespace NstuOnline.MessageService.Infrastructure.Database.EntityConfigurations;

public class MessageTypeConfiguration : IEntityTypeConfiguration<MessageType>
{
    public void Configure(EntityTypeBuilder<MessageType> builder)
    {
        builder.ToTable("message_type");

        builder
            .Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder
            .HasIndex(x => x.Code)
            .IsUnique();

        builder.HasData(GetDefaultMessageTypes());
    }

    private List<MessageType> GetDefaultMessageTypes()
    {
        return new List<MessageType>
        {
            new((byte)MessageTypes.Text, "text", "Текст"),
            new((byte)MessageTypes.Attachments, "attachments", "Вложения"),
            new((byte)MessageTypes.TextAndAttachments, "text_and_attachments", "Текст и вложения"),
            new((byte)MessageTypes.Photo, "photo", "Фото"),
            new((byte)MessageTypes.Voice, "voice", "Голосовое"),
        };
    }
}
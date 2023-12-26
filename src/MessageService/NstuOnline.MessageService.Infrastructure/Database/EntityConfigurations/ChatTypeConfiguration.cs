using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NstuOnline.MessageService.Domain.Entities;
using NstuOnline.MessageService.Domain.Enums;

namespace NstuOnline.MessageService.Infrastructure.Database.EntityConfigurations;

public class ChatTypeConfiguration : IEntityTypeConfiguration<ChatType>
{
    public void Configure(EntityTypeBuilder<ChatType> builder)
    {
        builder.ToTable("chat_type");

        builder
            .Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder
            .HasIndex(x => x.Code)
            .IsUnique();

        builder.HasData(GetDefaultChatTypes());
    }

    private List<ChatType> GetDefaultChatTypes()
    {
        return new List<ChatType>
        {
            new((byte)ChatTypes.Dialog, "dialog", "Диалог"),
            new((byte)ChatTypes.Сonversation, "conversation", "Беседа"),
            new((byte)ChatTypes.SystemСonversation, "system_conversation", "Беседа группы"),
            new((byte)ChatTypes.Favorite, "favorite", "Избранное")
        };
    }
}
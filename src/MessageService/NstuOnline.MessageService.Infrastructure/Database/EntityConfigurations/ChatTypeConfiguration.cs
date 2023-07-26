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
            new()
            {
                Id = (byte)ChatTypes.Dialog,
                Code = "dialog",
                Name = "Диалог"
            },
            new()
            {
                Id = (byte)ChatTypes.Сonversation,
                Code = "conversation",
                Name = "Беседа"
            },
            new()
            {
                Id = (byte)ChatTypes.SystemСonversation,
                Code = "system_conversation",
                Name = "Беседа группы"
            }
        };
    }
}
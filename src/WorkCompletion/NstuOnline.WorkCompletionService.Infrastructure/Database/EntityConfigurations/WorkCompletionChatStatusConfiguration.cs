using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NstuOnline.WorkCompletion.Domain.Entity;
using NstuOnline.WorkCompletion.Domain.Enums;

namespace NstuOnline.WorkCompletion.Infrastructure.Database.EntityConfigurations;

public class WorkCompletionChatStatusConfiguration : IEntityTypeConfiguration<WorkCompletionChatStatus>
{
    public void Configure(EntityTypeBuilder<WorkCompletionChatStatus> builder)
    {
        builder.ToTable("work_completion_chat_status");
        
        builder
            .HasKey(x => x.Id);

        builder
            .Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(50);
        
        builder
            .Property(x => x.Code)
            .IsRequired()
            .HasMaxLength(50);

        builder
            .HasIndex(x => x.Name)
            .IsUnique();
        
        builder
            .HasIndex(x => x.Code)
            .IsUnique();
        
        builder.HasData(GetDefaultWorkCompletionChatStatuses());
    }

    private List<WorkCompletionChatStatus> GetDefaultWorkCompletionChatStatuses()
    {
        return new List<WorkCompletionChatStatus>
        {
            new((byte)WorkCompletionChatStatuses.NoChat, "no_chat", "Нет диалога"),
            new((byte)WorkCompletionChatStatuses.NewMessage, "new_message", "Новое сообщение"),
            new((byte)WorkCompletionChatStatuses.Read, "read", "Прочитано"),
            new((byte)WorkCompletionChatStatuses.Sent, "sent", "Отправлено"),
            new((byte)WorkCompletionChatStatuses.AwaitingResponse, "awaiting_response", "Ожидает ответа"),
        };
    }
}
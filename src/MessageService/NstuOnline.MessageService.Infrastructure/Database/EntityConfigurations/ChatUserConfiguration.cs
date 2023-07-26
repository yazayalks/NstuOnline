using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NstuOnline.MessageService.Domain.Entities;

namespace NstuOnline.MessageService.Infrastructure.Database.EntityConfigurations;

public class ChatUserConfiguration : IEntityTypeConfiguration<ChatUser>
{
    public void Configure(EntityTypeBuilder<ChatUser> builder)
    {
        builder.ToTable("chat_user");

        builder
            .HasKey(x => new { x.ChatId, x.UserId });

        builder
            .HasOne(x => x.Chat)
            .WithMany(x => x.ChatUsers)
            .HasForeignKey(x => x.ChatId);
        
        builder
            .HasOne(x => x.User)
            .WithMany()
            .HasForeignKey(x => x.UserId);
    }
}
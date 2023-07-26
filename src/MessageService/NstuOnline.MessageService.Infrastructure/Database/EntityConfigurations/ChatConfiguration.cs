using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NstuOnline.MessageService.Domain.Entities;

namespace NstuOnline.MessageService.Infrastructure.Database.EntityConfigurations;

public class ChatConfiguration : IEntityTypeConfiguration<Chat>
{
    public void Configure(EntityTypeBuilder<Chat> builder)
    {
        builder.ToTable("chat");

        builder
            .HasKey(x => x.Id);
        
        builder
            .Property(x => x.Name)
            .HasMaxLength(50);
        
        builder
            .HasOne(x => x.ChatType)
            .WithMany()
            .HasForeignKey(x => x.ChatTypeId);
    }
}
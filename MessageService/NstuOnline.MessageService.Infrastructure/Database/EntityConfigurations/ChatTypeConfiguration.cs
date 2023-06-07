using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NstuOnline.MessageService.Domain.Entities;

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
    }
}
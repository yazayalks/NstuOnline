using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NstuOnline.MessageService.Domain.Entities;

namespace NstuOnline.MessageService.Infrastructure.Database.EntityConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("user");
        
        builder
            .HasKey(x => x.UserId);
    }
}
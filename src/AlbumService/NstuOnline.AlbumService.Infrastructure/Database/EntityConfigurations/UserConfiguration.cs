using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NstuOnline.AlbumService.Domain.Entity;

namespace NstuOnline.AlbumService.Infrastructure.Database.EntityConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("user");
        
        builder
            .HasKey(x => x.UserId);
    }
}
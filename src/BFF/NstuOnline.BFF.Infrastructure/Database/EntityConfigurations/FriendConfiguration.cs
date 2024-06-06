using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NstuOnline.BFF.Domain.Entity;

namespace NstuOnline.BFF.Infrastructure.Database.EntityConfigurations;

public class FriendConfiguration : IEntityTypeConfiguration<Friend>
{
    public void Configure(EntityTypeBuilder<Friend> builder)
    {
        builder.ToTable("friend");

        builder
            .HasKey(x => new { x.FriendId, x.UserId });

        builder
            .HasOne(x => x.FriendUser)
            .WithMany(x => x.Friends)
            .HasForeignKey(x => x.FriendId);
        
        builder.HasOne(x => x.User)
            .WithMany()
            .HasForeignKey(x => x.UserId);
    }
}
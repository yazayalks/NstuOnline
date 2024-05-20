using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NstuOnline.WallService.Domain.Entity;

namespace NstuOnline.WallService.Infrastructure.Database.EntityConfigurations;

public class RecordUserConfiguration : IEntityTypeConfiguration<RecordUser>
{
    public void Configure(EntityTypeBuilder<RecordUser> builder)
    {
        builder.ToTable("record_user");
        
        builder
            .HasKey(x => new { x.RecordId, x.UserId });

        builder
            .HasOne(x => x.Record)
            .WithMany(x => x.Users)
            .HasForeignKey(x => x.RecordId);
        
        builder
            .HasOne(x => x.User)
            .WithMany()
            .HasForeignKey(x => x.UserId);
    }
}
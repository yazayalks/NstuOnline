using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NstuOnline.WallService.Domain.Entity;

namespace NstuOnline.WallService.Infrastructure.Database.EntityConfigurations;

public class RecordConfiguration : IEntityTypeConfiguration<Record>
{
    public void Configure(EntityTypeBuilder<Record> builder)
    {
        builder.ToTable("record");
        
        builder
            .HasKey(x => x.Id);
        
        builder
            .Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder
            .Property(x => x.Description)
            .IsRequired()
            .HasMaxLength(100);
        
        builder
            .HasOne(x => x.User)
            .WithMany()
            .HasForeignKey(x => x.UserId);
    }
}
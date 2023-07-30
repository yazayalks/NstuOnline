using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FileDb = NstuOnline.FileService.Domain.Entities.File;

namespace NstuOnline.FileService.Infrastructure.Database.EntityConfigurations;

public class FileConfiguration : IEntityTypeConfiguration<FileDb>
{
    public void Configure(EntityTypeBuilder<FileDb> builder)
    {
        builder.ToTable("file");
        
        builder
            .HasKey(x => x.Id);
        
        builder
            .HasOne(x => x.User)
            .WithMany()
            .HasForeignKey(x => x.UserId);
        
        builder
            .HasOne(x => x.Type)
            .WithMany()
            .HasForeignKey(x => x.TypeId);

        builder
            .Property(x => x.Name)
            .HasMaxLength(100);
        
        builder
            .Property(x => x.ObjectName)
            .HasMaxLength(500);
    }
}
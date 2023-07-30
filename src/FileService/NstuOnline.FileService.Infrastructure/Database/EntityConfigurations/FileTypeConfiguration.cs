using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NstuOnline.FileService.Domain.Entities;
using NstuOnline.FileService.Domain.Enums;

namespace NstuOnline.FileService.Infrastructure.Database.EntityConfigurations;

public class FileTypeConfiguration : IEntityTypeConfiguration<FileType>
{
    public void Configure(EntityTypeBuilder<FileType> builder)
    {
        builder.ToTable("file_type");
        
        builder
            .HasKey(x => x.Id);
        
        builder
            .Property(x => x.Name)
            .HasMaxLength(50);
        
        builder
            .Property(x => x.Code)
            .HasMaxLength(50);

        builder
            .HasData(GetDefaultData());
    }
    
    private static IEnumerable<FileType> GetDefaultData()
    {
        return new List<FileType>
        {
            new((byte)FileTypes.Image, "Изображение", "image"),
            new((byte)FileTypes.Video, "Видео", "video"),
            new((byte)FileTypes.Audio, "Аудио", "audio"),
            new((byte)FileTypes.Document, "Документ", "document")
        };
    }
}
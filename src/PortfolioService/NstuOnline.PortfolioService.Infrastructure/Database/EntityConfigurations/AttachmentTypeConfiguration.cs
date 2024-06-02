﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NstuOnline.PortfolioService.Domain.Entity;
using NstuOnline.PortfolioService.Domain.Enums;

namespace NstuOnline.PortfolioService.Infrastructure.Database.EntityConfigurations;

public class AttachmentTypeConfiguration : IEntityTypeConfiguration<AttachmentType>
{
    public void Configure(EntityTypeBuilder<AttachmentType> builder)
    {
        builder.ToTable("attachment_type");
        
        builder
            .HasKey(x => x.Id);

        builder
            .Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder
            .HasIndex(x => x.Code)
            .IsUnique();
        
        builder.HasData(GetDefaultAttachmentTypes());
    }

    private List<AttachmentType> GetDefaultAttachmentTypes()
    {
        return new List<AttachmentType>
        {
            new((byte)AttachmentTypes.Document, "document", "Документ"),
            new((byte)AttachmentTypes.Photo, "photo", "Фото")
        };
    }
}
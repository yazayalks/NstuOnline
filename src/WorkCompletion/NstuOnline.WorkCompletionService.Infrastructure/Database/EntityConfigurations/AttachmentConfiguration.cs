using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NstuOnline.WorkCompletion.Domain.Entity;

namespace NstuOnline.WorkCompletion.Infrastructure.Database.EntityConfigurations;

public class AttachmentConfiguration : IEntityTypeConfiguration<Attachment>
{
    public void Configure(EntityTypeBuilder<Attachment> builder)
    {
        builder.ToTable("attachment");

        builder
            .HasKey(x => x.Id);
    }
}
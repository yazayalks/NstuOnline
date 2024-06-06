using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NstuOnline.BFF.Domain.Entity;

namespace NstuOnline.BFF.Infrastructure.Database.EntityConfigurations;

public class ContactInfoConfiguration : IEntityTypeConfiguration<ContactInfo>
{
    public void Configure(EntityTypeBuilder<ContactInfo> builder)
    {
        builder.ToTable("contact_info");

        builder
            .HasKey(x => x.Id);
    }
}
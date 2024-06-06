using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NstuOnline.BFF.Domain.Entity;

namespace NstuOnline.BFF.Infrastructure.Database.EntityConfigurations;

public class BasicInfoConfiguration : IEntityTypeConfiguration<BasicInfo>
{
    public void Configure(EntityTypeBuilder<BasicInfo> builder)
    {
        builder.ToTable("basic_info");

        builder
            .HasKey(x => x.Id);
    }
}
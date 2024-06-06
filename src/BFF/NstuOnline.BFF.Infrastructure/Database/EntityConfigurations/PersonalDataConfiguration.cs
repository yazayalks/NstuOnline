using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NstuOnline.BFF.Domain.Entity;

namespace NstuOnline.BFF.Infrastructure.Database.EntityConfigurations;

public class PersonalDataConfiguration : IEntityTypeConfiguration<PersonalData>
{
    public void Configure(EntityTypeBuilder<PersonalData> builder)
    {
        builder.ToTable("personal_data");

        builder
            .HasKey(x => x.Id);
    }
}
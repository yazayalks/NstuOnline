using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NstuOnline.BFF.Domain.Entity;

namespace NstuOnline.BFF.Infrastructure.Database.EntityConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .HasOne(x => x.PersonalData)
            .WithMany()
            .HasForeignKey(x => x.PersonalDataId);

        builder
            .HasOne(x => x.BasicInfo)
            .WithMany()
            .HasForeignKey(x => x.BasicInfoId);

        builder
            .HasOne(x => x.ContactInfo)
            .WithMany()
            .HasForeignKey(x => x.ContactInfoId);
        
        builder
            .HasMany(x => x.Friends)
            .WithOne();
    }
}
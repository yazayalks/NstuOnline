using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NstuOnline.EventService.Domain.Entity;

namespace NstuOnline.EventService.Infrastructure.Database.EntityConfigurations;

public class MemberConfiguration : IEntityTypeConfiguration<Member>
{
    public void Configure(EntityTypeBuilder<Member> builder)
    {
        builder.ToTable("member");
        
        builder
            .HasKey(x => x.Id);
        
        builder
            .HasOne(x => x.MemberStatus)
            .WithMany()
            .HasForeignKey(x => x.MemberStatusId);
        
        builder
            .HasMany(x => x.Events)
            .WithMany(x => x.Members)
            .UsingEntity<EventMember>();
        
        builder
            .HasOne(x => x.User)
            .WithMany()
            .HasForeignKey(x => x.UserId);
    }
}
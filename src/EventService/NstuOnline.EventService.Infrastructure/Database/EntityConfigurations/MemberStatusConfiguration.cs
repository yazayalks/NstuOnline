using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NstuOnline.EventService.Domain.Entity;
using NstuOnline.EventService.Domain.Enums;

namespace NstuOnline.EventService.Infrastructure.Database.EntityConfigurations;

public class MemberStatusConfiguration : IEntityTypeConfiguration<MemberStatus>
{
    public void Configure(EntityTypeBuilder<MemberStatus> builder)
    {
        builder.ToTable("member_status");
        
        builder
            .HasKey(x => x.Id);

        builder
            .Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder
            .HasIndex(x => x.Code)
            .IsUnique();
        
        builder.HasData(GetDefaultMemberStatuses());
    }

    private List<MemberStatus> GetDefaultMemberStatuses()
    {
        return new List<MemberStatus>
        {
            new((byte)MemberStatuses.Go, "go", "Пойду"),
            new((byte)MemberStatuses.MaybeGo, "maybe_go", "Возможно пойду"),
            new((byte)MemberStatuses.Assigned, "assigned", "Назначено"),
            new((byte)MemberStatuses.NotGo, "not_go", "Не пойду")
        };
    }
}
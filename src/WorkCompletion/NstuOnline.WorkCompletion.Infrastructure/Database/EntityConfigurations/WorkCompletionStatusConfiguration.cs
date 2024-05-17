using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NstuOnline.WorkCompletion.Domain.Entity;
using NstuOnline.WorkCompletion.Domain.Enums;

namespace NstuOnline.WorkCompletion.Infrastructure.Database.EntityConfigurations;

public class WorkCompletionStatusConfiguration : IEntityTypeConfiguration<WorkCompletionStatus>
{
    public void Configure(EntityTypeBuilder<WorkCompletionStatus> builder)
    {
        builder.ToTable("work_completion_status");
        
        builder
            .HasKey(x => x.Id);

        builder
            .Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(50);
        
        builder
            .Property(x => x.Code)
            .IsRequired()
            .HasMaxLength(50);

        builder
            .HasIndex(x => x.Name)
            .IsUnique();
        
        builder
            .HasIndex(x => x.Code)
            .IsUnique();
        
        builder.HasData(GetDefaultWorkCompletionStatuses());
    }

    private List<WorkCompletionStatus> GetDefaultWorkCompletionStatuses()
    {
        return new List<WorkCompletionStatus>
        {
            new((byte)WorkCompletionStatuses.NotIssued, "not_issued", "Не выдано"),
            new((byte)WorkCompletionStatuses.Issued, "issued", "Выдано"),
            new((byte)WorkCompletionStatuses.InProgress, "in_progress", "В работе"),
            new((byte)WorkCompletionStatuses.AwaitingReview, "awaiting_review", "Ожидает проверки"),
            new((byte)WorkCompletionStatuses.UnderReview, "under_review", "На проверке"),
            new((byte)WorkCompletionStatuses.Returned, "returned", "Возвращена"),
            new((byte)WorkCompletionStatuses.Completed, "completed", "Выполнена"),
            new((byte)WorkCompletionStatuses.NotCompleted, "not_completed", "Не выполнена"),
        };
    }
}
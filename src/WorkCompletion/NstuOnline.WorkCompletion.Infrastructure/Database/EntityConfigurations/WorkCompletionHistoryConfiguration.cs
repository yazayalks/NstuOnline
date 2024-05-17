using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NstuOnline.WorkCompletion.Domain.Entity;

namespace NstuOnline.WorkCompletion.Infrastructure.Database.EntityConfigurations;

public class WorkCompletionHistoryConfiguration : IEntityTypeConfiguration<WorkCompletionHistory>
{
    public void Configure(EntityTypeBuilder<WorkCompletionHistory> builder)
    {
        builder.ToTable("work_completion_history");
        
        builder
            .HasKey(x => x.Id);
        
        builder
            .HasOne(x => x.Status)
            .WithMany()
            .HasForeignKey(x => x.StatusId);
    }
}
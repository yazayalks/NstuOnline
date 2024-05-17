using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NstuOnline.WorkCompletion.Domain.Entity;

namespace NstuOnline.WorkCompletion.Infrastructure.Database.EntityConfigurations;

public class WorkCompletionResultConfiguration : IEntityTypeConfiguration<WorkCompletionResult>
{
    public void Configure(EntityTypeBuilder<WorkCompletionResult> builder)
    {
        builder.ToTable("work_completion_result");
        
        builder
            .HasKey(x => x.Id);
    }
}
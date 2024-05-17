using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using WorkCompletionDb = NstuOnline.WorkCompletion.Domain.Entity.WorkCompletion;

namespace NstuOnline.WorkCompletion.Infrastructure.Database.EntityConfigurations;

public class WorkCompletionConfiguration : IEntityTypeConfiguration<WorkCompletionDb>
{
    public void Configure(EntityTypeBuilder<WorkCompletionDb> builder)
    {
        builder.ToTable("work_completion");
        
        builder
            .HasKey(x => x.Id);
        
        builder
            .HasOne(x => x.Status)
            .WithMany()
            .HasForeignKey(x => x.StatusId);
        
        builder
            .HasOne(x => x.ChatStatus)
            .WithMany()
            .HasForeignKey(x => x.ChatStatusId);
        
        builder
            .HasOne(x => x.Work)
            .WithMany()
            .HasForeignKey(x => x.WorkId);
        
        builder
            .HasOne(x => x.Result)
            .WithMany()
            .HasForeignKey(x => x.ResultId);
        
        builder
            .HasMany(x => x.Histories)
            .WithOne();
    }
}
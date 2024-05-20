using Common.Data.Entities;

namespace NstuOnline.WorkCompletion.Domain.Entity;

public class WorkCompletionHistory : ArchivableEntity
{
    public Guid WorkCompletionId { get; set; }
    
    public int AttemptNumber { get; set; }
    
    public Guid MessageId { get; set; }
    
    public byte StatusId { get; set; }
    public WorkCompletionStatus Status { get; set; }
    
    public Guid? ResultId { get; set; }
    public WorkCompletionResult Result { get; set; }
}
using Common.Data.Entities;

namespace NstuOnline.WorkCompletion.Domain.Entity;

public class WorkCompletionResult : EntityBase
{
    public string Text { get; set; }
    
    public byte? Percent { get; set; }
    
    public byte? Mark { get; set; }
    
    public bool? IsPassed { get; set; }
}
using Common.Data.Entities;

namespace NstuOnline.WorkCompletion.Domain.Entity;

public class WorkCompletion : EntityBase
{
    public Guid StudentId { get; set; }
    
    public Guid TeacherId { get; set; }
    
    public Guid ChatId { get; set; }
        
    public DateTime? Deadline { get; set; }
    
    public int AttemptNumber { get; set; }
    
    public byte StatusId { get; set; }
    public WorkCompletionStatus Status { get; set; }
    
    public byte ChatStatusId { get; set; }
    public WorkCompletionChatStatus ChatStatus { get; set; }
    
    public byte? FavoritesId { get; set; }
    public Favorites Favorites { get; set; }
    
    public Guid WorkId { get; set; }
    public Work Work { get; set; }

    public Guid? ResultId { get; set; }
    public WorkCompletionResult Result { get; set; }
    
    public List<WorkCompletionHistory> Histories { get; set; }
}
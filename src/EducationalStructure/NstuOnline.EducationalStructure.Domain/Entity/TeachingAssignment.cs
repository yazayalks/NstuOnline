namespace NstuOnline.EducationalStructure.Domain.Entity;
/// <summary>
/// Назначенные преподователю предметы
/// </summary>
public class TeachingAssignment
{
    public Guid SubjectId { get; set; }
    public Subject Subject { get; set; }
    
    public Guid GroupId { get; set; }
    public Group Group { get; set; }
    
    public Guid TeacherId { get; set; }
    public Teacher Teacher { get; set; }
    
    public bool IsMain { get; set; }
}
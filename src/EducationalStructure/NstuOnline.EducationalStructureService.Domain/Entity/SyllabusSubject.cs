namespace NstuOnline.EducationalStructure.Domain.Entity;
/// <summary>
/// Предмет в учебном плане
/// </summary>
public class SyllabusSubject
{
    public Guid SubjectId { get; set; }
    public Subject Subject { get; set; }
    
    public Guid SyllabusId { get; set; }
    public Syllabus Syllabus { get; set; }
        
    public bool WithExam { get; set; }
    
    public bool WithСredit { get; set; }
    
    public bool WithGos { get; set; }
    
    public byte Semester { get; set; }
    
    public byte NbCourseWork { get; set; }
    
    public byte NbSettlementWork { get; set; }
    
    public byte NbControlWork { get; set; }
    
    public byte LectureHours { get; set; }
    
    public byte PractiseHours { get; set; }
    
    public byte LabHours { get; set; }
    
    public byte ConsultationHours { get; set; }
}
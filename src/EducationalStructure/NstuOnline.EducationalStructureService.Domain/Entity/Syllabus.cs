using Common.Data.Entities;

namespace NstuOnline.EducationalStructure.Domain.Entity;
/// <summary>
/// Учебный план
/// </summary>
public class Syllabus : EntityBase
{
    public Guid SpecializationId { get; set; }
    public Specialization Specialization { get; set; }
    
    public byte StudyFormTypeId { get; set; }
    public StudyFormType StudyFormType { get; set; }
    
    public byte AccreditationTypeId { get; set; }
    public AccreditationType AccreditationType { get; set; }
    
    public byte StudyLevelId { get; set; }
    public StudyLevel StudyLevel { get; set; }
}
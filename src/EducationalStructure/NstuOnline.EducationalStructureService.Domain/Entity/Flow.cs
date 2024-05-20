using Common.Data.Entities;

namespace NstuOnline.EducationalStructure.Domain.Entity;
/// <summary>
/// Поток
/// </summary>
public class Flow : EntityBase
{
    public Guid GroupId { get; set; }
    public Group Group { get; set; }
}
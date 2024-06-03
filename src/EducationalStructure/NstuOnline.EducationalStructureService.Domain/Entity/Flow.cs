using Common.Data.Entities;

namespace NstuOnline.EducationalStructure.Domain.Entity;
/// <summary>
/// Поток
/// </summary>
public class Flow : EntityBase
{
    public string Name { get; set; }
    public ICollection<Group> Groups { get; set; }
    
    public string ExternalId { get; set; }
}
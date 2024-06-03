using Common.Data.Entities;

namespace NstuOnline.EducationalStructure.Domain.Entity;
/// <summary>
/// Факультет
/// </summary>
public class Faculty : EntityBase
{
    public string Name { get; set; }
    
    public string Code { get; set; }
    
    public string ExternalId { get; set; }
}
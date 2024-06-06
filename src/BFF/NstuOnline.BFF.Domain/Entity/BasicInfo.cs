using Common.Data.Entities;

namespace NstuOnline.BFF.Domain.Entity;

public class BasicInfo : EntityBase
{
    public int Hometown { get; set; }
    public List<int> LanguageIds { get; set; }

    public Guid UserId { get; set; }
    public User User { get; set; }
}
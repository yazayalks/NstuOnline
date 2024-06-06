using Common.Data.Entities;

namespace NstuOnline.BFF.Domain.Entity;

public class ContactInfo : EntityBase
{
    public int CountryId { get; set; }

    public int City { get; set; }

    public string MobilePhone { get; set; }

    public string AdditionalMobilePhone { get; set; }

    public string PersonalWebsite { get; set; }

    public Guid UserId { get; set; }
    public User User { get; set; }
}
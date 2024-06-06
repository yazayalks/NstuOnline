using Common.Data.Entities;

namespace NstuOnline.BFF.Domain.Entity;

public class PersonalData : EntityBase
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string MiddleName { get; set; }

    public byte Gender { get; set; }

    public DateOnly BirthDate { get; set; }

    public Guid UserId { get; set; }
    public User User { get; set; }
}
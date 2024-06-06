using Microsoft.AspNetCore.Identity;

namespace NstuOnline.BFF.Domain.Entity;

public class User : IdentityUser
{
    public Guid BasicInfoId { get; set; }
    public BasicInfo BasicInfo { get; set; }
    
    public Guid PersonalDataId { get; set; }
    public PersonalData PersonalData { get; set; } 
    
    public Guid ContactInfoId { get; set; }
    public ContactInfo ContactInfo { get; set; }
    
    public ICollection<Friend> Friends { get; set; }
}
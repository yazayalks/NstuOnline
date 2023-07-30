using Common.Data.Entities;
using NstuOnline.FileService.Domain.Enums;

namespace NstuOnline.FileService.Domain.Entities;

public class File : EntityBase
{
    public string Name { get; set; }
    public string ObjectName { get; set; } 
    
    public byte TypeId { get; set; }
    public FileType Type { get; set; }
    
    public DateTime CreateDateTime { get; set; }
    
    public Guid UserId { get; set; }
    public User User { get; set; }
}
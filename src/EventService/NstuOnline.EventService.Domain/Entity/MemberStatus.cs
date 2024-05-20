using Common.Data.Entities;

namespace NstuOnline.EventService.Domain.Entity;

public class MemberStatus : DictionaryEntity
{
    public string Code { get; set; }

    public MemberStatus(byte id, string code, string name) : base(id, name)
    {
        Code = code;
    }
}
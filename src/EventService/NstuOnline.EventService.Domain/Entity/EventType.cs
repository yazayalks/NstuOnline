using Common.Data.Entities;

namespace NstuOnline.EventService.Domain.Entity;

public class EventType : DictionaryEntity
{
    public string Code { get; set; }

    public EventType(byte id, string code, string name) : base(id, name)
    {
        Code = code;
    }
}
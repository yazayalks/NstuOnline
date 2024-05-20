using Common.Data.Entities;

namespace NstuOnline.EventService.Domain.Entity;

public class EventStatus : DictionaryEntity
{
    public string Code { get; set; }

    public EventStatus(byte id, string code, string name) : base(id, name)
    {
        Code = code;
    }
}
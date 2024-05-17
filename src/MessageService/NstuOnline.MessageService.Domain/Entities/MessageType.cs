using Common.Data.Entities;

namespace NstuOnline.MessageService.Domain.Entities;

public class MessageType : DictionaryEntity
{
    public string Code { get; set; }

    public MessageType(byte id, string name, string code) : base(id, name)
    {
        Code = code;
    }
}
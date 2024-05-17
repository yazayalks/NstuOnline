using Common.Data.Entities;

namespace NstuOnline.MessageService.Domain.Entities;

public class MessageStatus : DictionaryEntity
{
    public string Code { get; set; }

    public MessageStatus(byte id, string name, string code) : base(id, name)
    {
        Code = code;
    }
}
using Common.Data.Entities;

namespace NstuOnline.WorkCompletion.Domain.Entity;

public class WorkCompletionChatStatus : DictionaryEntity
{
    public string Code { get; set; }

    public WorkCompletionChatStatus(byte id, string name, string code) : base(id, name)
    {
        Code = code;
    }
}
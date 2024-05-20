using Common.Data.Entities;

namespace NstuOnline.WorkCompletion.Domain.Entity;

public class WorkCompletionStatus : DictionaryEntity
{
    public string Code { get; set; }

    public WorkCompletionStatus(byte id, string code, string name) : base(id, name)
    {
        Code = code;
    }
}
using Common.Data.Entities;

namespace NstuOnline.WorkCompletion.Domain.Entity;

public class Favorites : DictionaryEntity
{
    public string Code { get; set; }

    public Favorites(byte id, string name, string code) : base(id, name)
    {
        Code = code;
    }
}
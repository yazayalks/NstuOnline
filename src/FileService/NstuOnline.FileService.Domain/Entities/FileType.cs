using Common.Data.Entities;

namespace NstuOnline.FileService.Domain.Entities;

public class FileType : DictionaryEntity
{
    public string Code { get; set; }

    public FileType(byte id, string name, string code) : base(id, name)
    {
        Code = code;
    }
}
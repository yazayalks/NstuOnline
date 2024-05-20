using Common.Data.Entities;

namespace NstuOnline.PortfolioService.Domain.Entity;

public class PortfolioType : DictionaryEntity
{
    public string Code { get; set; }

    public PortfolioType(byte id, string code, string name) : base(id, name)
    {
        Code = code;
    }
}
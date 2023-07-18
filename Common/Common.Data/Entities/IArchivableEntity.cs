namespace Common.Data.Entities
{
    public interface IArchivableEntity
    {
        bool IsDeleted { get; set; }
    }
}
namespace Common.Data.Entities
{
    public interface IDictionaryEntity<TKey>
    {
        TKey Id { get; set; }
        
        string Name { get; set; }
    }
}

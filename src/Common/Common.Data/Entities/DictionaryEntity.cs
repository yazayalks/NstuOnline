namespace Common.Data.Entities
{
    public abstract class DictionaryEntity<TKey> : IDictionaryEntity<TKey>
        where TKey : struct
    {
        public TKey Id { get; set; }

        public string Name { get; set; }

        public DictionaryEntity(TKey id, string name)
        {
            Id = id;
            Name = name;
        }
    }

    public abstract class DictionaryEntity : DictionaryEntity<byte>
    {
        public DictionaryEntity(byte id, string name) : base(id, name)
        {
        }
    }
}

namespace Bunting.Abstractions.Kernel
{
    public abstract class UniqueKeyEnumerationClass<TEnum, TValue>
        where TEnum : UniqueKeyEnumerationClass<TEnum, TValue>
        where TValue : notnull
    {
        public string Key { get; }
        public TValue Value { get; }

        private static readonly Dictionary<string, TEnum> _mappings = [];

        protected UniqueKeyEnumerationClass(string key, TValue value)
        {
            Key = key;
            Value = value;

            _mappings.Add(key, (TEnum)this);
        }

        protected static TEnum GetByKey(string key)
        {
            if (_mappings.TryGetValue(key, out var enumClass))
                return enumClass;

            throw new InvalidEnumerationClassException(key);
        }

        private void AddMapping()
        {
            if (_mappings.ContainsKey(Key))
                throw new DuplicatedEnumerationClassException(Key);

            _mappings.Add(Key, (TEnum)this);
        }
    }
}

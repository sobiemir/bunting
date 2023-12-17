namespace Bunting.Abstractions.Kernel
{
    public sealed class DuplicatedEnumerationClassException(string key)
        : Exception($"Enumeration key '{key}' is duplicated.")
    {
        public string Key { get; } = key;
    }
}

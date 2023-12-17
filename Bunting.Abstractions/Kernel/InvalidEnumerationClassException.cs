namespace Bunting.Abstractions.Kernel
{
    public sealed class InvalidEnumerationClassException(string key)
        : Exception($"Enumeration key '{key}' is invalid.")
    {
        public string Key { get; } = key;
    }
}

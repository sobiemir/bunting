namespace Bunting.Abstractions.Media
{
    public sealed class MediaTypeWasAlreadyDefinedException(string mediaType)
        : Exception($"Media type {mediaType} was already defined.")
    {
        public string MediaType { get; } = mediaType;
    }
}

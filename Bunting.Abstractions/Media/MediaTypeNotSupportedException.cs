namespace Bunting.Abstractions.Media
{
    public sealed class MediaTypeNotSupportedException(string mediaType)
        : NotSupportedException($"Media type {mediaType} is not supported.")
    {
        public string MediaType { get; } = mediaType;
    }
}

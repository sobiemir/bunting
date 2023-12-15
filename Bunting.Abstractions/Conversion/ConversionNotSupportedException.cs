using Bunting.Abstractions.Media;

namespace Bunting.Abstractions.Conversion
{
    public sealed class ConversionNotSupportedException(MediaFormat source, MediaFormat target)
        : NotSupportedException($"Conversion from {source.MediaType} to {target.MediaType} is not supported.")
    {
        public string SourceMimeType { get; } = source.MediaType;
        public string TargetMimeType { get; } = target.MediaType;

        public ConversionNotSupportedException(ConversionFormat format)
            : this(format.Source, format.Target)
        {
        }
    }
}

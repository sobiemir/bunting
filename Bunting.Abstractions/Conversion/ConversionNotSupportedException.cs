using Bunting.Abstractions.File;

namespace Bunting.Abstractions.Conversion
{
    public sealed class ConversionNotSupportedException(FileExtension source, FileExtension target)
        : NotSupportedException($"Conversion from '{source.Key}' to '{target.Key}' is not supported.")
    {
        public string SourceMediaType { get; } = source.Key;
        public string TargetMediaType { get; } = target.Key;

        public ConversionNotSupportedException(FileConversionDirection format)
            : this(format.Source, format.Target)
        {
        }
    }
}

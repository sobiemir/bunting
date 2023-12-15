using Bunting.Abstractions.Media;

namespace Bunting.Abstractions.Conversion
{
    public sealed class ConversionAlreadyExistsException(MediaFormat source, MediaFormat target, string oldEngineName, string newEngineName)
        : Exception($"Conversion from {source.MediaType} to {target.MediaType} defined in {newEngineName} already exists in {oldEngineName}.")
    {
        public string SourceMediaType { get; } = source.MediaType;
        public string TargetMediaType { get; } = target.MediaType;
        public string OldEngineName { get; } = oldEngineName;
        public string NewEngineName { get; } = newEngineName;

        public ConversionAlreadyExistsException(ConversionFormat format, string oldEngineName, string newEngineName)
            : this(format.Source, format.Target, oldEngineName, newEngineName)
        {
        }
    }
}

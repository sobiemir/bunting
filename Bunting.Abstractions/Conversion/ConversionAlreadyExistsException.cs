using Bunting.Abstractions.File;

namespace Bunting.Abstractions.Conversion
{
    public sealed class ConversionAlreadyExistsException(FileExtension source, FileExtension target, string oldEngineName, string newEngineName)
        : Exception($"Conversion from {source.Key} to {target.Key} defined in {newEngineName} already exists in {oldEngineName}.")
    {
        public string SourceMediaType { get; } = source.Key;
        public string TargetMediaType { get; } = target.Key;
        public string OldEngineName { get; } = oldEngineName;
        public string NewEngineName { get; } = newEngineName;

        public ConversionAlreadyExistsException(FileConversionDirection format, string oldEngineName, string newEngineName)
            : this(format.Source, format.Target, oldEngineName, newEngineName)
        {
        }
    }
}

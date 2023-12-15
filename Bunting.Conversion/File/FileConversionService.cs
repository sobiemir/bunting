using Bunting.Abstractions.Conversion;
using Bunting.Abstractions.Interfaces;
using Bunting.Abstractions.Media;

namespace Bunting.Conversion.File
{
    internal sealed class FileConversionService : IFileConversionService
    {
        private readonly Guid _fileId;

        private readonly string _temporaryDirectory;
        private readonly string _sourcePath;
        private readonly string _targetPath;

        private readonly ConversionFormat _conversionFormat;

        public FileConversionService(ConversionFormat format, string temporaryDirectory)
        {
            _fileId = Guid.NewGuid();
            _temporaryDirectory = temporaryDirectory;

            var srcExtension = format.Source.Extension;
            var dstExtension = format.Target.Extension;

            _sourcePath = $"{_temporaryDirectory}{Path.PathSeparator}{_fileId}-src.{srcExtension}";
            _targetPath = $"{_temporaryDirectory}{Path.PathSeparator}{_fileId}-dst.{dstExtension}";

            _conversionFormat = format;
        }

        public MediaFormat GetSourceMediaFormat()
        {
            return _conversionFormat.Source;
        }

        public MediaFormat GetTargetMediaFormat()
        {
            return _conversionFormat.Target;
        }

        public ConversionFormat GetConversionFormat()
        {
            return _conversionFormat;
        }

        public string GetSourcePath()
        {
            return _sourcePath;
        }

        public string GetTargetPath()
        {
            return _targetPath;
        }
    }
}

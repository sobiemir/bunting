using Bunting.Abstractions.Environment;
using Bunting.Abstractions.File;
using Bunting.Abstractions.Interfaces;

namespace Bunting.Conversion.File
{
    internal sealed class FileConversionService : IFileConversionService
    {
        private readonly Guid _fileId;

        private readonly EnvironmentVariable _tempDirectory;
        private readonly string _sourcePath;
        private readonly string _sourcePathNoExtension;
        private readonly string _targetPath;
        private readonly string _targetPathNoExtension;

        private readonly FileConversionDirection _conversionDirection;

        public FileConversionService(FileConversionDirection conversionDirection)
        {
            ArgumentNullException.ThrowIfNull(conversionDirection);

            _fileId = Guid.NewGuid();
            _tempDirectory = EnvironmentVariable.TMP_DIRECTORY;

            var sourceExtension = conversionDirection.Source.Value;
            var targetExtension = conversionDirection.Target.Value;

            _sourcePathNoExtension = $"{_tempDirectory.Value}{Path.DirectorySeparatorChar}{_fileId}-src";
            _sourcePath = $"{_sourcePathNoExtension}.{sourceExtension}";
            _targetPathNoExtension = $"{_tempDirectory.Value}{Path.DirectorySeparatorChar}{_fileId}-dst";
            _targetPath = $"{_targetPathNoExtension}.{targetExtension}";

            _conversionDirection = conversionDirection;
        }

        public FileExtension GetSourceMediaFormat()
        {
            return _conversionDirection.Source;
        }

        public FileExtension GetTargetMediaFormat()
        {
            return _conversionDirection.Target;
        }

        public FileConversionDirection GetConversionFormat()
        {
            return _conversionDirection;
        }

        public string GetSourcePath(bool withExtension = true)
        {
            return withExtension
                ? _sourcePath
                : _sourcePathNoExtension;
        }

        public string GetTargetPath(bool withExtension = true)
        {
            return withExtension
                ? _targetPath
                : _targetPathNoExtension;
        }

        public void DeleteSource()
        {
            System.IO.File.Delete(_sourcePath);
        }

        public void DeleteTarget()
        {
            System.IO.File.Delete(_targetPath);
        }

        public async Task<MemoryStream> LoadAndDeleteTargetAsync(CancellationToken cancellationToken)
        {
            MemoryStream? memoryStream = null;

            try
            {
                var fileStream = await System.IO.File.ReadAllBytesAsync(_targetPath, cancellationToken);
                memoryStream = new MemoryStream(fileStream);
                DeleteTarget();
            }
            catch
            {
                memoryStream?.Dispose();
                throw;
            }

            return memoryStream
                ?? throw new NullReferenceException();
        }
    }
}

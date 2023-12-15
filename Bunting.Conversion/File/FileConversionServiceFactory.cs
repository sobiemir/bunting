using Bunting.Abstractions.Conversion;
using Bunting.Abstractions.Environment;
using Bunting.Abstractions.Interfaces;

namespace Bunting.Conversion.File
{
    internal sealed class FileConversionServiceFactory : IFileConversionServiceFactory
    {
        public const string TEMPDIR_ENVVAR_NAME = "DIR_TEMPORARY";

        private readonly string _temporaryDirectory;

        public FileConversionServiceFactory()
        {
            _temporaryDirectory = Environment.GetEnvironmentVariable(TEMPDIR_ENVVAR_NAME)
                ?? throw new EnvironmentVariableNotFoundException(TEMPDIR_ENVVAR_NAME);
        }

        public async Task<IFileConversionService> CreateAsync(Stream sourceStream, ConversionFormat format, CancellationToken cancellationToken)
        {
            var service = new FileConversionService(format, _temporaryDirectory);
            var sourcePath = service.GetSourcePath();

            await SaveSourceAsync(sourceStream, sourcePath, cancellationToken);

            return service;
        }

        private static async Task SaveSourceAsync(Stream sourceStream, string sourcePath, CancellationToken cancellationToken)
        {
            using var fileStream = System.IO.File.Create(sourcePath);
            await fileStream.CopyToAsync(sourceStream, cancellationToken);
        }
    }
}

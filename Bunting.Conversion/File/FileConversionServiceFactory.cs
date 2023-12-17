using Bunting.Abstractions.File;
using Bunting.Abstractions.Interfaces;

namespace Bunting.Conversion.File
{
    internal sealed class FileConversionServiceFactory : IFileConversionServiceFactory
    {
        public FileConversionServiceFactory()
        {
        }

        public async Task<IFileConversionService> CreateAsync(Stream sourceStream, FileConversionDirection format, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(sourceStream);
            ArgumentNullException.ThrowIfNull(format);

            var service = new FileConversionService(format);
            var sourcePath = service.GetSourcePath();

            await SaveSourceAsync(sourceStream, sourcePath, cancellationToken);

            return service;
        }

        private static async Task SaveSourceAsync(Stream sourceStream, string sourcePath, CancellationToken cancellationToken)
        {
            using var fileStream = System.IO.File.Create(sourcePath);
            await sourceStream.CopyToAsync(fileStream, cancellationToken);
        }
    }
}

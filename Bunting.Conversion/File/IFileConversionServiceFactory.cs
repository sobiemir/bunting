using Bunting.Abstractions.File;
using Bunting.Abstractions.Interfaces;

namespace Bunting.Conversion.File
{
    public interface IFileConversionServiceFactory
    {
        Task<IFileConversionService> CreateAsync(Stream sourceStream, FileConversionDirection format, CancellationToken cancellationToken);
    }
}

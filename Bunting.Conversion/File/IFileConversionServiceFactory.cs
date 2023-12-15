using Bunting.Abstractions.Conversion;
using Bunting.Abstractions.Interfaces;

namespace Bunting.Conversion.File
{
    public interface IFileConversionServiceFactory
    {
        Task<IFileConversionService> CreateAsync(Stream sourceStream, ConversionFormat format, CancellationToken cancellationToken);
    }
}

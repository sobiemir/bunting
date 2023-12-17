using Bunting.Abstractions.Common;
using Bunting.Abstractions.Conversion;
using Bunting.Abstractions.File;

namespace Bunting.Conversion.Conversion
{
    public interface IConversionFactory
    {
        Task<IConversionEngine> CreateEngineAsync(
            Stream sourceStream,
            FileExtension source,
            FileExtension target,
            ConversionOptionsDictionary options,
            CancellationToken cancellationToken);

        bool IsConversionSupported(FileExtension source, FileExtension target);
        bool IsConversionSupported(FileConversionDirection format);
    }
}

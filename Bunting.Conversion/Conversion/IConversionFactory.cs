using Bunting.Abstractions.Common;
using Bunting.Abstractions.Conversion;
using Bunting.Abstractions.Media;

namespace Bunting.Conversion.Conversion
{
    public interface IConversionFactory
    {
        Task<IConversionEngine> CreateEngineAsync(Stream sourceStream, ConversionFormat format, ConversionOptionsDictionary options, CancellationToken cancellationToken);
        Task<IConversionEngine> CreateEngineAsync(Stream sourceStream, MediaFormat source, MediaFormat target, ConversionOptionsDictionary options, CancellationToken cancellationToken);

        bool IsConversionSupported(MediaFormat source, MediaFormat target);
        bool IsConversionSupported(ConversionFormat format);
    }
}

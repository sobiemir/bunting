using Bunting.Abstractions.Conversion;
using Bunting.Abstractions.Media;

namespace Bunting.Engines.Poppler
{
    internal sealed class PopplerConfiguration
    {
        public readonly static IList<ConversionFormat> Converters = new List<ConversionFormat>
        {
            new (MediaFormat.PDF, MediaFormat.TIFF),
            new (MediaFormat.PDF, MediaFormat.JPEG),
            new (MediaFormat.PDF, MediaFormat.PNG)
        };
    }
}

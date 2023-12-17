using Bunting.Abstractions.File;

namespace Bunting.Engines.Poppler
{
    internal sealed class PopplerConfiguration
    {
        public readonly static IList<FileConversionDirection> Converters = new List<FileConversionDirection>
        {
            new (FileExtension.PDF, FileExtension.PPM)
        };
    }
}

using Bunting.Abstractions.File;

namespace Bunting.Engines.Poppler
{
    internal sealed class PopplerConfiguration
    {
        public const string CONVERTER_NAME = "poppler";

        public readonly static IList<FileConversionDirection> Converters = new List<FileConversionDirection>
        {
            new (FileExtension.PDF, FileExtension.PPM)
        };
    }
}

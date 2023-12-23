using Bunting.Abstractions.File;

namespace Bunting.Engines.ImageMagick
{
    internal class ImageMagickConfiguration
    {
        public const string CONVERTER_NAME = "imagemagick";

        public readonly static IList<FileConversionDirection> Converters = new List<FileConversionDirection>
        {
            new (FileExtension.PPM, FileExtension.JPEG),
            new (FileExtension.JPEG, FileExtension.JPEG),
            new (FileExtension.PNG, FileExtension.JPEG),
            new (FileExtension.TIFF, FileExtension.JPEG)
        };
    }
}

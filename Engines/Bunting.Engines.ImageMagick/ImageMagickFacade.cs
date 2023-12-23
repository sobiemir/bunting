using Bunting.Abstractions.Common;
using Bunting.Abstractions.Conversion;
using Bunting.Abstractions.File;
using Bunting.Abstractions.Interfaces;

namespace Bunting.Engines.ImageMagick
{
    public sealed class ImageMagickFacade : IConversionFacade
    {
        public IList<FileConversionDirection> GetConverters()
        {
            return ImageMagickConfiguration.Converters;
        }

        public string GetEngineName()
        {
            return ImageMagickConfiguration.CONVERTER_NAME;
        }

        public IConversionEngine CreateEngine(IFileConversionService fcService, ConversionOptionsDictionary options)
        {
            var format = fcService.GetConversionFormat();

            if (!IsConversionSupported(format))
                throw new ConversionNotSupportedException(format);

            return new ImageMagickEngine(fcService, options);
        }

        public bool IsConversionSupported(FileConversionDirection format)
        {
            return ImageMagickConfiguration.Converters.Contains(format);
        }
    }
}

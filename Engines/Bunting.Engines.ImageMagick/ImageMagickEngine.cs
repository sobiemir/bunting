using Bunting.Abstractions.Common;
using Bunting.Abstractions.Conversion;
using Bunting.Abstractions.Interfaces;

namespace Bunting.Engines.ImageMagick
{
    internal class ImageMagickEngine : IConversionEngine
    {
        private readonly IFileConversionService _fcService;
        private readonly ImageMagickOptionsBuilder _optionsBuilder;

        public ImageMagickEngine(
            IFileConversionService fcService,
            ConversionOptionsDictionary options)
        {
            var optionsBuilder = new ImageMagickOptionsBuilder(options);

            _optionsBuilder = optionsBuilder;
            _fcService = fcService;
        }

        public Task ConvertAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}

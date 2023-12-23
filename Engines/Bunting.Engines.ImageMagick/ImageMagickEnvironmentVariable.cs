using Bunting.Abstractions.Environment;

namespace Bunting.Engines.ImageMagick
{
    internal sealed class ImageMagickEnvironmentVariable
        : EnvironmentVariable
    {
        public static readonly ImageMagickEnvironmentVariable BIN_IMAGEMAGICK_CONVERT = new(nameof(BIN_IMAGEMAGICK_CONVERT));

        private ImageMagickEnvironmentVariable(string name)
            : base(name)
        {
        }
    }
}

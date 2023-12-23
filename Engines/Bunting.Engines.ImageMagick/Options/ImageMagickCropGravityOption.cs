using Bunting.Abstractions.Kernel;

namespace Bunting.Engines.ImageMagick.Options
{
    internal sealed class ImageMagickCropGravityOption
        : UniqueKeyEnumerationClass<ImageMagickCropGravityOption, string>
    {
        public static ImageMagickCropGravityOption North = new(nameof(North));
        public static ImageMagickCropGravityOption NorthEast = new(nameof(NorthEast));
        public static ImageMagickCropGravityOption East = new(nameof(East));
        public static ImageMagickCropGravityOption SouthEast = new(nameof(SouthEast));
        public static ImageMagickCropGravityOption South = new(nameof(South));
        public static ImageMagickCropGravityOption SouthWest = new(nameof(SouthWest));
        public static ImageMagickCropGravityOption West = new(nameof(West));
        public static ImageMagickCropGravityOption NorthWest = new(nameof(NorthWest));
        public static ImageMagickCropGravityOption Center = new(nameof(Center));

        private ImageMagickCropGravityOption(string name)
            : base(name, name)
        {
        }

        public static ImageMagickCropGravityOption ByKey(string key)
        {
            return GetByKey(key);
        }
    }
}

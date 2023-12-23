using Bunting.Abstractions.Common;
using Bunting.Abstractions.Conversion;
using Bunting.Engines.ImageMagick.Options;

namespace Bunting.Engines.ImageMagick
{
    internal sealed class ImageMagickOptionsBuilder(ConversionOptionsDictionary options)
        : ConversionOptionsAbstract(options)
    {
        public bool AlphaRemove { get; private set; } = false;
        public bool AutoOrientation { get; private set; } = false;
        public ImageMagickCropGravityOption CropGravity { get; private set; } = ImageMagickCropGravityOption.Center;
        public int CropWidth { get; private set; } = 0;
        public int CropHeight { get; private set; } = 0;
        public bool CropPercentage { get; private set; } = false;
        public int CropXOffset { get; private set; } = 0;
        public int CropYOffset { get; private set; } = 0;
        public int ResizeWidth { get; private set; } = 0;
        public int ResizeHeight { get; private set; } = 0;
        public bool ResizePercentage { get; private set; } = false;
        public bool AllowEnlargement { get; private set; } = false;
        public bool MaintainAspectRatio { get; private set; } = false;

        public IList<string> GetArguments()
        {
            var options = new List<string>();


            //{
            //    "-singlefile",
            //    "-q",

            //    "-f",
            //    $"{Page}",
            //    "-l",
            //    $"{Page}",

            //    "-r",
            //    $"{Resolution}"
            //};

            //if (!string.IsNullOrWhiteSpace(UserPassword))
            //{
            //    options.Add("-upw");
            //    options.Add(UserPassword);
            //}

            //if (!string.IsNullOrWhiteSpace(OwnerPassword))
            //{
            //    options.Add("-opw");
            //    options.Add(OwnerPassword);
            //}

            return options;
        }
    }
}

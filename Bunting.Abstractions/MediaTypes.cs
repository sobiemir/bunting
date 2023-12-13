using System.Net.Mime;

namespace Bunting.Abstractions
{
    public static class MediaTypes
    {
        public const string PDF = MediaTypeNames.Application.Pdf;
        public const string DJVU = "image/vnd.djvu";

        public const string JPEG = MediaTypeNames.Image.Jpeg;
        public const string PNG = MediaTypeNames.Image.Png;
        public const string TIFF = MediaTypeNames.Image.Tiff;
    }
}

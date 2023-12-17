using System.Net.Mime;
using Bunting.Abstractions.Kernel;

namespace Bunting.Abstractions.File
{
    public sealed class FileExtension
        : UniqueKeyEnumerationClass<FileExtension, string>
    {
        public static readonly FileExtension PDF = new(MediaTypeNames.Application.Pdf, "pdf");
        public static readonly FileExtension DJVU = new("image/vnd.djvu", "djvu");

        public static readonly FileExtension PPM = new("image/x-portable-pixmap", "ppm");
        public static readonly FileExtension JPEG = new(MediaTypeNames.Image.Jpeg, "jpg");
        public static readonly FileExtension PNG = new(MediaTypeNames.Image.Png, "png");
        public static readonly FileExtension TIFF = new(MediaTypeNames.Image.Tiff, "tiff");

        private FileExtension(string mediaType, string extension)
            : base(mediaType, extension)
        {
        }

        public static FileExtension ByMediaType(string mediaType)
        {
            return GetByKey(mediaType);
        }
    }
}

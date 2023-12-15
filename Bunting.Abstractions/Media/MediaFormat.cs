using System.Net.Mime;
using System.Reflection;

namespace Bunting.Abstractions.Media
{
    public sealed record MediaFormat(string MediaType, string Extension)
    {
        public static readonly MediaFormat PDF = new(MediaTypeNames.Application.Pdf, "pdf");
        public static readonly MediaFormat DJVU = new("image/vnd.djvu", "djvu");

        public static readonly MediaFormat JPEG = new(MediaTypeNames.Image.Jpeg, "jpg");
        public static readonly MediaFormat PNG = new(MediaTypeNames.Image.Png, "png");
        public static readonly MediaFormat TIFF = new(MediaTypeNames.Image.Tiff, "tiff");

        private static readonly Dictionary<string, MediaFormat> _mappings = [];

        static MediaFormat()
        {
            var properties = typeof(MediaFormat).GetFields(BindingFlags.Public | BindingFlags.Static);

            foreach (var property in properties)
            {
                var value = property.GetValue(null);

                if (value is MediaFormat mediaFormat)
                {
                    if (_mappings.ContainsKey(mediaFormat.MediaType))
                        throw new MediaTypeWasAlreadyDefinedException(mediaFormat.MediaType);

                    _mappings.Add(mediaFormat.MediaType, mediaFormat);
                }
            }
        }

        public static MediaFormat Of(string mediaType)
        {
            if (_mappings.TryGetValue(mediaType, out var mediaFormat))
                return mediaFormat;

            throw new MediaTypeNotSupportedException(mediaType);
        }
    }
}

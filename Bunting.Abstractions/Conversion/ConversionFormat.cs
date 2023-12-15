using Bunting.Abstractions.Media;

namespace Bunting.Abstractions.Conversion
{
    public sealed record ConversionFormat(MediaFormat Source, MediaFormat Target)
    {
        public bool IsTarget(MediaFormat target)
        {
            return target == Target;
        }

        public bool IsSource(MediaFormat source)
        {
            return source == Source;
        }

        public override string ToString()
        {
            return $"({Source}) to ({Target})";
        }
    }
}

namespace Bunting.Abstractions.File
{
    public sealed record FileConversionDirection(FileExtension Source, FileExtension Target)
    {
        public bool IsTarget(FileExtension target)
        {
            return target == Target;
        }

        public bool IsSource(FileExtension source)
        {
            return source == Source;
        }

        public override string ToString()
        {
            return $"({Source}) to ({Target})";
        }
    }
}

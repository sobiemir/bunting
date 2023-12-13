namespace Bunting.Abstractions
{
    public record ConversionFormat(string From, string To)
    {
        public override string ToString()
        {
            return $"({From}) to ({To})";
        }
    }
}

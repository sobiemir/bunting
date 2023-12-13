namespace Bunting.Abstractions.Conversion
{
    public class ConversionNotSupportedException(string from, string to)
        : NotSupportedException($"Conversion from {from} to {to} is not supported.")
    {
        public string From { get; } = from;
        public string To { get; } = to;

        public ConversionNotSupportedException(ConversionFormat format)
            : this(format.From, format.To)
        {
        }
    }
}

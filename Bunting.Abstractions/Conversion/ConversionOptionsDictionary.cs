namespace Bunting.Abstractions.Common
{
    public sealed class ConversionOptionsDictionary : Dictionary<string, object>
    {
        public string? GetString(string name)
        {
            if (!TryGetValue(name, out var value))
                return null;

            if (value is null)
                return null;

            if (value is string strValue)
                return strValue;

            return value.ToString()!;
        }

        public int? GetInt(string name)
        {
            if (!TryGetValue(name, out var value))
                return null;

            if (value is null)
                return null;

            if (value is int intValue)
                return intValue;

            if (!int.TryParse(value.ToString(), out var parsedIntValue))
                return null;

            return parsedIntValue;
        }
    }
}

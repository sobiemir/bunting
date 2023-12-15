using Bunting.Abstractions.Common;
using Bunting.Abstractions.Conversion;

namespace Bunting.Engines.Poppler
{
    internal sealed class PopplerEngineOptionsBuilder(ConversionOptionsDictionary options)
        : ConversionOptionsAbstract(options)
    {
        public int Page { get; private set; } = 1;
        public int Resolution { get; private set; } = 150;
        public string UserPassword { get; private set; } = "";
        public string OwnerPassword { get; private set; } = "";

        public IList<string> GetArguments()
        {
            var options = new List<string>
            {
                "-singlefile",
                "-q",

                "-f",
                $"{Page}",
                "-l",
                $"{Page}",

                "-r",
                $"{Resolution}"
            };

            if (!string.IsNullOrWhiteSpace(UserPassword))
            {
                options.Add("-upw");
                options.Add(UserPassword);
            }

            if (!string.IsNullOrWhiteSpace(OwnerPassword))
            {
                options.Add("-opw");
                options.Add(OwnerPassword);
            }

            return options;
        }
    }
}

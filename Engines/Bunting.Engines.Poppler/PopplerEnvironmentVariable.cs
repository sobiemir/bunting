using Bunting.Abstractions.Environment;

namespace Bunting.Engines.Poppler
{
    internal sealed record PopplerEnvironmentVariable : EnvironmentVariable
    {
        public static readonly PopplerEnvironmentVariable BIN_POPPLER_PDFTOPPM = new(nameof(BIN_POPPLER_PDFTOPPM));

        private PopplerEnvironmentVariable(string name)
            : base(name)
        {
        }
    }
}

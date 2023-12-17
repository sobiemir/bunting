using Bunting.Abstractions.Kernel;

namespace Bunting.Abstractions.Environment
{
    public class EnvironmentVariable
        : UniqueKeyEnumerationClass<EnvironmentVariable, string>
    {
        public static readonly EnvironmentVariable TMP_DIRECTORY = new(nameof(TMP_DIRECTORY));

        protected EnvironmentVariable(string name)
            : base(name, EnvironmentVariableNotSetException.ThrowIfEmpty(name))
        {
        }
    }
}

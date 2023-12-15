namespace Bunting.Abstractions.Environment
{
    public sealed class EnvironmentVariableNotFoundException(string variableName)
        : NullReferenceException($"Environment variable {variableName} is not set.")
    {
        public string EnvironmentVariableName { get; } = variableName;
    }
}

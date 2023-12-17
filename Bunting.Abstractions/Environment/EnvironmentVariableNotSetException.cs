namespace Bunting.Abstractions.Environment
{
    public sealed class EnvironmentVariableNotSetException(string variableName)
        : NullReferenceException($"Environment variable {variableName} is not set.")
    {
        public string EnvironmentVariableName { get; } = variableName;

        public static string ThrowIfEmpty(string variableName)
        {
            var envVar = System.Environment.GetEnvironmentVariable(variableName);

            if (string.IsNullOrWhiteSpace(envVar))
                throw new EnvironmentVariableNotSetException(variableName);

            return envVar;
        }
    }
}

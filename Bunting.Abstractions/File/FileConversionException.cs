namespace Bunting.Abstractions.File
{
    public sealed class FileConversionException(int code, string message, string engine, string command, string arguments)
        : Exception(
            $"Unable to convert file with {engine} engine using command:\n" +
            $"{command} {arguments}\n" +
            $"Command returned {code} code with message:\n" +
            $"{message}")
    {
        public int ResultCode { get; } = code;
        public string ResultMessage { get; } = message;
        public string Engine { get; } = engine;
        public string Command { get; } = command;
        public string Arguments { get; } = arguments;
    }
}

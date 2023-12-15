namespace Bunting.Abstractions.Environment
{
    public record EnvironmentVariable
    {
        public static readonly EnvironmentVariable TMP_DIRECTORY = new(nameof(TMP_DIRECTORY));

        public string Name { get; }
        public string Value { get; }

        protected EnvironmentVariable(string name)
        {
            var envvar = System.Environment.GetEnvironmentVariable(name)
                ?? throw new EnvironmentVariableNotFoundException(name);

            Name = name;
            Value = envvar;
        }
    }
}

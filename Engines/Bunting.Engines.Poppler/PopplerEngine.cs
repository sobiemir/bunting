using System.Text;
using Bunting.Abstractions.Common;
using Bunting.Abstractions.Conversion;
using Bunting.Abstractions.Interfaces;
using CliWrap;

namespace Bunting.Engines.Poppler
{
    internal sealed class PopplerEngine : IConversionEngine
    {
        public const string CONVERTER_NAME = "poppler";
        public const string PDFTOPPM_ENVVAR_NAME = "BIN_POPPLER_PDFTOPPM";

        private readonly IFileConversionService _fileConversionService;
        private readonly PopplerEngineOptionsBuilder _optionsBuilder;

        public PopplerEngine(IFileConversionService fileConversionService, ConversionOptionsDictionary options)
        {
            var optionsBuilder = new PopplerEngineOptionsBuilder(options);

            _optionsBuilder = optionsBuilder;
            _fileConversionService = fileConversionService;
        }

        public async Task ConvertAsync(CancellationToken cancellationToken)
        {
            var command = PopplerEnvironmentVariable.BIN_POPPLER_PDFTOPPM;

            var stdOutBuffer = new StringBuilder();
            var stdErrBuffer = new StringBuilder();

            var arguments = _optionsBuilder.GetArguments();

            var sourceFile = _fileConversionService.GetSourcePath();
            var targetTile = _fileConversionService.GetTargetPath();

            arguments.Add(sourceFile);
            arguments.Add(targetTile);

            var result = await Cli.Wrap(command.Value)
                .WithArguments(arguments)
                .WithStandardOutputPipe(PipeTarget.ToStringBuilder(stdOutBuffer))
                .WithStandardErrorPipe(PipeTarget.ToStringBuilder(stdErrBuffer))
                .ExecuteAsync(cancellationToken);

            if (result.ExitCode != 0)
                ;

            Console.WriteLine(stdOutBuffer);
            Console.WriteLine(stdErrBuffer);
        }
    }
}

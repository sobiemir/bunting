using System.Text;
using Bunting.Abstractions.Common;
using Bunting.Abstractions.Conversion;
using Bunting.Abstractions.File;
using Bunting.Abstractions.Interfaces;
using CliWrap;

namespace Bunting.Engines.Poppler
{
    internal sealed class PopplerEngine : IConversionEngine
    {
        public const string CONVERTER_NAME = "poppler";

        private readonly IFileConversionService _fcService;
        private readonly PopplerOptionsBuilder _optionsBuilder;

        public PopplerEngine(
            IFileConversionService fcService,
            ConversionOptionsDictionary options)
        {
            var optionsBuilder = new PopplerOptionsBuilder(options);

            _optionsBuilder = optionsBuilder;
            _fcService = fcService;
        }

        public async Task ConvertAsync(CancellationToken cancellationToken)
        {
            var command = PopplerEnvironmentVariable.BIN_POPPLER_PDFTOPPM;

            var stdOutBuffer = new StringBuilder();
            var stdErrBuffer = new StringBuilder();

            var arguments = _optionsBuilder.GetArguments();

            var sourceFile = _fcService.GetSourcePath();
            var targetFile = _fcService.GetTargetPath(false);

            arguments.Add(sourceFile);
            arguments.Add(targetFile);

            var preparedCommand = Cli.Wrap(command.Value)
                .WithArguments(arguments)
                .WithStandardOutputPipe(PipeTarget.ToStringBuilder(stdOutBuffer))
                .WithStandardErrorPipe(PipeTarget.ToStringBuilder(stdErrBuffer));

            var result = await preparedCommand
                .ExecuteAsync(cancellationToken);

            if (result.ExitCode != 0)
            {
                _fcService.DeleteSource();
                _fcService.DeleteTarget();

                throw new FileConversionException(
                    code: result.ExitCode,
                    message: stdErrBuffer.ToString(),
                    engine: CONVERTER_NAME,
                    command: command.Value,
                    arguments: preparedCommand.Arguments);
            }

            _fcService.DeleteSource();
            _fcService.DeleteTarget();
        }
    }
}

using Bunting.Abstractions.Common;
using Bunting.Abstractions.Conversion;
using Bunting.Abstractions.File;
using Bunting.Conversion.Conversion;
using Bunting.Conversion.File;
using Bunting.Engines.Poppler;

namespace Bunting.Conversion
{
    internal sealed class ConversionFactory : IConversionFactory
    {
        private readonly Dictionary<FileConversionDirection, IConversionFacade> _converters;
        private readonly IFileConversionServiceFactory _fcsFactory;

        public ConversionFactory(IFileConversionServiceFactory fcsFactory)
        {
            _converters = [];
            _fcsFactory = fcsFactory;

            CollectConverters(new PopplerFacade());
        }

        public async Task<IConversionEngine> CreateEngineAsync(
            Stream sourceStream,
            FileExtension source,
            FileExtension target,
            ConversionOptionsDictionary options,
            CancellationToken cancellationToken)
        {
            var format = new FileConversionDirection(source, target);

            if (!_converters.TryGetValue(format, out IConversionFacade? facade))
                throw new ConversionNotSupportedException(format);

            var service = await _fcsFactory.CreateAsync(sourceStream, format, cancellationToken);
            return facade.CreateEngine(service, options);
        }

        public bool IsConversionSupported(FileExtension source, FileExtension target)
        {
            var format = new FileConversionDirection(source, target);
            return IsConversionSupported(format);
        }

        public bool IsConversionSupported(FileConversionDirection format)
        {
            return _converters.ContainsKey(format);
        }

        private void CollectConverters(IConversionFacade facade)
        {
            foreach (var converter in facade.GetConverters())
            {
                if (_converters.TryGetValue(converter, out IConversionFacade? oldFacade))
                {
                    var oldEngineName = oldFacade.GetEngineName();
                    var newEngineName = facade.GetEngineName();

                    throw new ConversionAlreadyExistsException(converter, oldEngineName, newEngineName);
                }

                _converters.Add(converter, facade);
            }
        }
    }
}

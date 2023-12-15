using Bunting.Abstractions.Common;
using Bunting.Abstractions.Conversion;
using Bunting.Abstractions.Media;
using Bunting.Conversion.Conversion;
using Bunting.Conversion.File;
using Bunting.Engines.Poppler;

namespace Bunting.Conversion
{
    internal sealed class ConversionFactory : IConversionFactory
    {
        private readonly Dictionary<ConversionFormat, IConversionFacade> _converters;
        private readonly IFileConversionServiceFactory _fcsFactory;

        public ConversionFactory(IFileConversionServiceFactory fcsFactory)
        {
            _converters = [];
            _fcsFactory = fcsFactory;

            CollectConverters(new PopplerFacade());
        }

        public async Task<IConversionEngine> CreateEngineAsync(Stream sourceStream, ConversionFormat format, ConversionOptionsDictionary options, CancellationToken cancellationToken)
        {
            if (!_converters.TryGetValue(format, out IConversionFacade? facade))
                throw new ConversionNotSupportedException(format);

            var service = await _fcsFactory.CreateAsync(sourceStream, format, cancellationToken);

            return facade.CreateEngine(service, options);
        }

        public async Task<IConversionEngine> CreateEngineAsync(Stream sourceStream, MediaFormat source, MediaFormat target, ConversionOptionsDictionary options, CancellationToken cancellationToken)
        {
            var format = new ConversionFormat(source, target);
            return await CreateEngineAsync(sourceStream, format, options, cancellationToken);
        }

        public bool IsConversionSupported(MediaFormat source, MediaFormat target)
        {
            var format = new ConversionFormat(source, target);
            return IsConversionSupported(format);
        }

        public bool IsConversionSupported(ConversionFormat format)
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

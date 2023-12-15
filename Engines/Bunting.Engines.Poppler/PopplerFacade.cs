﻿using Bunting.Abstractions.Common;
using Bunting.Abstractions.Conversion;
using Bunting.Abstractions.Interfaces;

namespace Bunting.Engines.Poppler
{
    public sealed class PopplerFacade : IConversionFacade
    {
        public IList<ConversionFormat> GetConverters()
        {
            return PopplerConfiguration.Converters;
        }

        public string GetEngineName()
        {
            return PopplerEngine.CONVERTER_NAME;
        }

        public IConversionEngine CreateEngine(IFileConversionService fcService, ConversionOptionsDictionary options)
        {
            var format = fcService.GetConversionFormat();

            if (!IsConversionSupported(format))
                throw new ConversionNotSupportedException(format);

            return new PopplerEngine(fcService, options);
        }

        public bool IsConversionSupported(ConversionFormat format)
        {
            return PopplerConfiguration.Converters.Contains(format);
        }
    }
}
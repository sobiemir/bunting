using Bunting.Abstractions.Common;
using Bunting.Abstractions.Interfaces;

namespace Bunting.Abstractions.Conversion
{
    public interface IConversionFacade
    {
        IList<ConversionFormat> GetConverters();
        string GetEngineName();
        IConversionEngine CreateEngine(IFileConversionService fcService, ConversionOptionsDictionary options);
        bool IsConversionSupported(ConversionFormat format);
    }
}

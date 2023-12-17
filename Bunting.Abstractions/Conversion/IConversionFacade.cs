using Bunting.Abstractions.Common;
using Bunting.Abstractions.File;
using Bunting.Abstractions.Interfaces;

namespace Bunting.Abstractions.Conversion
{
    public interface IConversionFacade
    {
        IList<FileConversionDirection> GetConverters();
        string GetEngineName();
        IConversionEngine CreateEngine(IFileConversionService fcService, ConversionOptionsDictionary options);
        bool IsConversionSupported(FileConversionDirection format);
    }
}

using Bunting.Abstractions.Conversion;
using Bunting.Abstractions.Media;

namespace Bunting.Abstractions.Interfaces
{
    public interface IFileConversionService
    {
        MediaFormat GetSourceMediaFormat();
        MediaFormat GetTargetMediaFormat();
        
        ConversionFormat GetConversionFormat();

        string GetSourcePath();
        string GetTargetPath();
    }
}

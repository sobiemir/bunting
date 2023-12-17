using Bunting.Abstractions.File;

namespace Bunting.Abstractions.Interfaces
{
    public interface IFileConversionService
    {
        FileExtension GetSourceMediaFormat();
        FileExtension GetTargetMediaFormat();
        
        FileConversionDirection GetConversionFormat();

        string GetSourcePath(bool withExtension = true);
        string GetTargetPath(bool withExtension = true);


        void DeleteSource();
        void DeleteTarget();
        Task<MemoryStream> LoadAndDeleteTargetAsync(CancellationToken cancellationToken);
    }
}

namespace Bunting.Abstractions
{
    public interface IConversionEngine
    {
        Task Run(CancellationToken cancellationToken);
    }
}

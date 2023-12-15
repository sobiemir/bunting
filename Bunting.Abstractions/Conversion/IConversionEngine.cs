namespace Bunting.Abstractions.Conversion
{
    public interface IConversionEngine
    {
        Task ConvertAsync(CancellationToken cancellationToken);
    }
}

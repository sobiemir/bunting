namespace Bunting.Abstractions
{
    public interface IConversionFacade
    {
        public IList<ConversionFormat> GetConverters();
        public string GetEngineName();

        public IConversionEngine CreateEngine(ConversionFormat format);        
        public bool IsConversionSupported(ConversionFormat format);
    }
}

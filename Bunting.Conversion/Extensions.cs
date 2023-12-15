using Bunting.Conversion.Conversion;
using Bunting.Conversion.File;
using Microsoft.Extensions.DependencyInjection;

namespace Bunting.Conversion
{
    public static class Extensions
    {
        public static IServiceCollection AddConversion(this IServiceCollection services)
        {
            services.AddSingleton<IConversionFactory, ConversionFactory>();
            services.AddSingleton<IFileConversionServiceFactory, FileConversionServiceFactory>();

            return services;
        }
    }
}

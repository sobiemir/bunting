using Bunting.Abstractions.Common;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Bunting.Api.Misc
{
    internal sealed class ConversionOptionsBinderProvider : IModelBinderProvider
    {
        public IModelBinder? GetBinder(ModelBinderProviderContext context)
        {
            ArgumentNullException.ThrowIfNull(context);

            var modelType = context.Metadata.UnderlyingOrModelType;
            if (modelType != typeof(ConversionOptionsDictionary))
                return null;

            var binderType = typeof(ConversionOptionsBinder);

            return Activator.CreateInstance(binderType) as IModelBinder;
        }
    }
}

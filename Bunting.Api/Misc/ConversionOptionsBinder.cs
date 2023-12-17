using System.Reflection;
using Bunting.Abstractions.Common;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Bunting.Api.Misc
{
    internal sealed class ConversionOptionsBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            ArgumentNullException.ThrowIfNull(bindingContext);

            if (bindingContext.ValueProvider is not IEnumerableValueProvider enumerableValueProvider)
                return Task.CompletedTask;

            var model = new ConversionOptionsDictionary();
            var prefix = string.Empty;
            var keyValuePairs = enumerableValueProvider.GetKeysFromPrefix(prefix);

            if (keyValuePairs.Count == 0)
                return Task.CompletedTask;

            var excludedProperties = GetExcludedProperties(bindingContext);

            foreach (var keyValuePair in keyValuePairs)
            {
                var key = keyValuePair.Key;

                if (excludedProperties.Contains(key))
                    continue;

                var value = bindingContext.ValueProvider
                    .GetValue(key)
                    .FirstOrDefault(string.Empty);

                model.Add(key, value);
            }

            bindingContext.Result = ModelBindingResult.Success(model);

            return Task.CompletedTask;
        }

        private static List<string> GetExcludedProperties(ModelBindingContext bindingContext)
        {
            var excludedProperties = new List<string>();
            var containerType = bindingContext.ModelMetadata.ContainerType;

            if (containerType is not null)
            {
                var conversionOptionsDictionaryType = typeof(ConversionOptionsDictionary);
                var containerProperties = containerType.GetProperties(BindingFlags.Public | BindingFlags.Instance);

                foreach (var property in containerProperties)
                {
                    if (property.PropertyType == conversionOptionsDictionaryType)
                        continue;

                    var camelCasePropertyName = char.ToLowerInvariant(property.Name[0]) + property.Name[1..];
                    excludedProperties.Add(camelCasePropertyName);
                }
            }

            return excludedProperties;
        }
    }
}

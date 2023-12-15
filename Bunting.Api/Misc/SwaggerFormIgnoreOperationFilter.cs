using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Bunting.Api.Misc
{
    internal sealed class SwaggerFormIgnoreOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation is null || context?.ApiDescription?.ParameterDescriptions is null)
                return;

            var excludedProperties = context.ApiDescription.ParameterDescriptions
                .Where(HasBindRemainingAttribute)
                .ToList();

            if (excludedProperties.Count == 0)
                return;

            foreach (var excludedProperty in excludedProperties)
            {
                foreach (var contentValue in operation.RequestBody.Content.Values)
                {
                    for (var x = 0; x < contentValue.Encoding.Count; ++x)
                    {
                        if (string.Equals(contentValue.Encoding.ElementAt(x).Key, excludedProperty.Name, StringComparison.Ordinal))
                        {
                            contentValue.Encoding.Remove(excludedProperty.Name);
                            contentValue.Schema.Properties.Remove(excludedProperty.Name);
                        }
                    }
                }
            }
        }

        private static bool HasBindRemainingAttribute(ApiParameterDescription parameterDescription)
        {
            if (!parameterDescription.Source.Equals(BindingSource.Form))
                return false;

            if (parameterDescription.ModelMetadata is DefaultModelMetadata metadata)
            {
                var bindRemainingAttributeType = typeof(BindRemainingAttribute);

                var hasAttribute = metadata.Attributes.Attributes
                    .Any(attribute => attribute.GetType() == bindRemainingAttributeType);

                return hasAttribute;
            }
            return false;
        }
    }
}

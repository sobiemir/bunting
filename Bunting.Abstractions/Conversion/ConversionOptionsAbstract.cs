using System.Reflection;
using Bunting.Abstractions.Common;

namespace Bunting.Abstractions.Conversion
{
    public abstract class ConversionOptionsAbstract
    {
        private readonly PropertyInfo[] _properties;

        public ConversionOptionsAbstract(ConversionOptionsDictionary options)
        {
            _properties = GetType().GetProperties(BindingFlags.Public);

            AssignOptions(options);
        }

        public IList<string> GetAvailableOptions()
        {
            return _properties
                .Select(c => c.Name)
                .ToList();
        }

        private void AssignOptions(ConversionOptionsDictionary options)
        {
            foreach (var property in _properties)
            {
                var propertyType = property.GetType();
                var defaultValue = property.GetValue(this);

                if (propertyType == typeof(int))
                    property.SetValue(this, options.GetInt(property.Name) ?? defaultValue);
                else if (propertyType == typeof(string))
                    property.SetValue(this, options.GetString(property.Name) ?? defaultValue);
            }
        }
    }
}

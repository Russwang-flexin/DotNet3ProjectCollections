using System;
using System.Collections.Generic;
using System.Text;
using Frame.EFCore.Interfaces;

namespace Frame.EFCore.Services.OrderBys
{
    public abstract class PropertyMapping<TSource, TDestination> : IPropertyMapping
      where TDestination : IBaseEntity
    {
        public Dictionary<string, List<MappedProperty>> MappingDictionary { get; }

        protected PropertyMapping(Dictionary<string, List<MappedProperty>> mappingDictionary)
        {
            MappingDictionary = mappingDictionary;
            MappingDictionary[nameof(IBaseEntity.Id)] = new List<MappedProperty>
            {
                new MappedProperty { Name = nameof(IBaseEntity.Id), Revert = false}
            };
        }
    }
}

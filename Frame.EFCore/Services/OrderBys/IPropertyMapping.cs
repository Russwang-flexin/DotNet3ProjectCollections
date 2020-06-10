using System;
using System.Collections.Generic;
using System.Text;

namespace Frame.EFCore.Services.OrderBys
{
    public interface IPropertyMapping
    {
        Dictionary<string, List<MappedProperty>> MappingDictionary { get; }
    }
}

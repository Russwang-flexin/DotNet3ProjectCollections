using System;
using System.Collections.Generic;
using System.Text;
using Frame.EFCore.Entity;
using Frame.EFCore.Resources.ViewModel;
using Frame.EFCore.Services.OrderBys;

namespace Frame.EFCore.Resources.OrderByMapping
{
    public class DictPropertyMapping : PropertyMapping<DictionariesViewModel, Dictionaries>
    {
        public DictPropertyMapping() : base(
            new Dictionary<string, List<MappedProperty>>
                (StringComparer.OrdinalIgnoreCase)
            {
                [nameof(DictionariesViewModel.LastTime)] = new List<MappedProperty>
                    {
                        new MappedProperty{ Name = nameof(Dictionaries.LastUpdate), Revert = false}
                    },
                [nameof(DictionariesViewModel.LastTimeBy)] = new List<MappedProperty>
                    {
                        new MappedProperty{ Name = nameof(Dictionaries.LastUpdateBy), Revert = false}
                    },
                [nameof(DictionariesViewModel.CreateTime)] = new List<MappedProperty>
                    {
                        new MappedProperty{ Name = nameof(Dictionaries.CreationDate), Revert = false}
                    },
            })
        {

        }
    }
}

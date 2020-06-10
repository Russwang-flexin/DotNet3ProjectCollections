using System;
using System.Collections.Generic;
using System.Text;
using Frame.EFCore.Entity;
using Frame.EFCore.Resources.ViewModel;
using Frame.EFCore.Services.OrderBys;

namespace Frame.EFCore.Resources.OrderByMapping
{
    public class MenuPropertyMapping : PropertyMapping<MenuViewModel, Menu>
    {
        public MenuPropertyMapping() : base(
            new Dictionary<string, List<MappedProperty>>
                (StringComparer.OrdinalIgnoreCase)
            {
                [nameof(MenuViewModel.Code)] = new List<MappedProperty>
                    {
                        new MappedProperty{ Name = nameof(Menu.MenuCode), Revert = false}
                    },
                [nameof(MenuViewModel.Name)] = new List<MappedProperty>
                    {
                        new MappedProperty{ Name = nameof(Menu.MenuName), Revert = false}
                    },
                [nameof(MenuViewModel.Caption)] = new List<MappedProperty>
                    {
                        new MappedProperty{ Name = nameof(Menu.MenuCaption), Revert = false}
                    },
                [nameof(MenuViewModel.Authorities)] = new List<MappedProperty>
                    {
                        new MappedProperty{ Name = nameof(Menu.MenuAuthorities), Revert = false}
                    },
            })
        {

        }
    }
}

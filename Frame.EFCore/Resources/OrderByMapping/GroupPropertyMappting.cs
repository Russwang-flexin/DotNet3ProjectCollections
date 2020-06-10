using System;
using System.Collections.Generic;
using System.Text;
using Frame.EFCore.Entity;
using Frame.EFCore.Resources.ViewModel;
using Frame.EFCore.Services.OrderBys;

namespace Frame.EFCore.Resources.OrderByMapping
{
    public class GroupPropertyMappting : PropertyMapping<GroupViewModel, Group>
    {
        public GroupPropertyMappting() : base(
            new Dictionary<string, List<MappedProperty>>
                (StringComparer.OrdinalIgnoreCase)
            {
                [nameof(GroupViewModel.Code)] = new List<MappedProperty>
                    {
                        new MappedProperty{ Name = nameof(Group.GroupCode), Revert = false}
                    },
                [nameof(GroupViewModel.Name)] = new List<MappedProperty>
                    {
                        new MappedProperty{ Name = nameof(Group.GroupName), Revert = false}
                    },
            })
        {

        }
    }
}

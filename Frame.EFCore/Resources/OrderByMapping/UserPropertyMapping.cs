using System;
using System.Collections.Generic;
using System.Text;
using Frame.EFCore.Entity;
using Frame.EFCore.Resources.ViewModel;
using Frame.EFCore.Services.OrderBys;

namespace Frame.EFCore.Resources.OrderByMapping
{
    public class UserPropertyMapping : PropertyMapping<UserViewModel, User>
    {
        public UserPropertyMapping() : base(
            new Dictionary<string, List<MappedProperty>>
                (StringComparer.OrdinalIgnoreCase)
            {
                [nameof(UserViewModel.LastTime)] = new List<MappedProperty>
                    {
                        new MappedProperty{ Name = nameof(User.LastLoginTime), Revert = false}
                    },
                [nameof(UserViewModel.EndTime)] = new List<MappedProperty>
                    {
                        new MappedProperty{ Name = nameof(User.LastLogouTime), Revert = false}
                    },
            })
        {

        }
    }
}

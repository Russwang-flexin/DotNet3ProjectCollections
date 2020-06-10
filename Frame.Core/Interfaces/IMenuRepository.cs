using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Frame.EFCore.Common;
using Frame.EFCore.Entity;
using Frame.EFCore.Query;

namespace Frame.EFCore.Interfaces
{
    public interface IMenuRepository 
    {
        Task<PaginatedList<Menu>> GetAllGroupsAsync(MenuParameters parameters);
    }
}

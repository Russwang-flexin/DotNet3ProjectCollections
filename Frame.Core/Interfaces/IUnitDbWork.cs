using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Frame.EFCore.Interfaces
{
    public interface IUnitDbWork
    {
        Task<bool> SaveAsync();
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Frame.EFCore.Interfaces;
using Frame.EFCore.DbFile;

namespace Frame.EFCore.Repositories
{
    public class UnitDbWork : IUnitDbWork
    {
        private readonly ZfsDbContext context;

        public UnitDbWork(ZfsDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> SaveAsync()
        {
            return await context.SaveChangesAsync() > 0;
        }
    }
}

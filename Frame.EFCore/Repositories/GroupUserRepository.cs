using System;
using System.Collections.Generic;
using System.Text;
using Frame.EFCore.Entity;
using Frame.EFCore.Interfaces;
using Frame.EFCore.DbFile;

namespace Frame.EFCore.Repositories
{
    public class GroupUserRepository : BaseRepository, IGroupUserRepository
    {
        public GroupUserRepository(ZfsDbContext context) : base(context)
        {

        }
    }
}

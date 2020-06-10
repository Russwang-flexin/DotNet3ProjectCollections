using System;
using System.Collections.Generic;
using System.Text;
using Frame.EFCore.Entity;
using Frame.EFCore.Interfaces;
using Frame.EFCore.DbFile;

namespace Frame.EFCore.Repositories
{
    public class DictionaryTypeRepository : BaseRepository, IDictionaryTypeRepository
    {
        public DictionaryTypeRepository(ZfsDbContext context) : base(context)
        {

        }
    }
}

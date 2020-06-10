using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frame.EFCore.Common;
using Frame.EFCore.Entity;
using Frame.EFCore.Interfaces;
using Frame.EFCore.Query;
using Frame.EFCore.DbFile;
using Frame.EFCore.Extensions;
using Frame.EFCore.Resources.ViewModel;
using Frame.EFCore.Services.OrderBys;

namespace Frame.EFCore.Repositories
{

    public class DictionaryRepository : BaseRepository, IDictionaryRepository
    {
        private readonly IPropertyMappingContainer propertyMappingContainer;

        public DictionaryRepository(ZfsDbContext context, IPropertyMappingContainer propertyMappingContainer) : base(context)
        {
            this.propertyMappingContainer = propertyMappingContainer;
        }

        public async Task<PaginatedList<Dictionaries>> GetAllDicAsync(DictionariesParameters parameters)
        {
            var query = context.Dictionaries.AsQueryable();
            //搜索,按登录名、用户名
            if (!string.IsNullOrEmpty(parameters.Search))
            {
                var search = parameters.Search.ToLowerInvariant();
                query = query.Where(t => t.DataCode.ToLowerInvariant().Contains(search) ||
                    t.EnglishName.ToLowerInvariant().Contains(search) ||
                    t.NativeName.ToLowerInvariant().Contains(search)
                );
            }

            //自定义排序
            query = query.ApplySort(parameters.OrderBy, propertyMappingContainer.Resolve<DictionariesViewModel, Dictionaries>());
            var count = await query.CountAsync();
            var data = await query.Skip(parameters.PageIndex - 1 * parameters.PageSize).Take(parameters.PageSize).ToListAsync();
            return new PaginatedList<Dictionaries>(parameters.PageIndex - 1, parameters.PageSize, count, data);
        }
    }
}

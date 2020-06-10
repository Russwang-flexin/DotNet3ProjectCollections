using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Frame.EFCore.Entity;
using Frame.EFCore.Interfaces;
using Frame.EFCore.DbFile;
using Microsoft.EntityFrameworkCore;
using Frame.EFCore.Common;
using Frame.EFCore.Query;
using Frame.EFCore.Services.OrderBys;
using Frame.EFCore.Extensions;
using Frame.EFCore.Resources.ViewModel;


namespace Frame.EFCore.Repositories
{
    public class GroupRepository : BaseRepository, IGroupRepository
    {
        private readonly IPropertyMappingContainer propertyMappingContainer;

        public GroupRepository(ZfsDbContext context, IPropertyMappingContainer propertyMappingContainer) : base(context)
        {
            this.propertyMappingContainer = propertyMappingContainer;
        }

        public async Task<PaginatedList<Group>> GetAllGroupsAsync(GroupParameters parameters)
        {
            var query = context.Groups.AsQueryable();
            if (!string.IsNullOrEmpty(parameters.Search))
            {
                var serach = parameters.Search.ToLowerInvariant();
                query = query.Where(t => t.GroupCode.ToLowerInvariant().Contains(serach) || t.GroupName.ToLowerInvariant().Contains(serach));
            }
            
            query = query.ApplySort(parameters.OrderBy, propertyMappingContainer.Resolve<GroupViewModel, Group>());
            var count = await query.CountAsync();
            var data = await query.Skip(parameters.PageIndex - 1 * parameters.PageSize).Take(parameters.PageSize).ToListAsync();
            return new PaginatedList<Group>(parameters.PageIndex - 1, parameters.PageSize, count, data);
        }
    }
}

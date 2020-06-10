﻿using System;
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
    public class UserRepository : BaseRepository, IUserRepository
    {
        private readonly IPropertyMappingContainer propertyMappingContainer;

        public UserRepository(ZfsDbContext context, IPropertyMappingContainer propertyMappingContainer) : base(context)
        {
            this.propertyMappingContainer = propertyMappingContainer;
        }

        public void AddUserAsync(User user)
        {
            context.Users.AddAsync(user);
        }

        public void DeleteAsync(User user)
        {
            context.Remove(user);
        }

        public async Task<PaginatedList<User>> GetAllUsersAsync(UserParameters parameters)
        {
            var query = context.Users.AsQueryable();
            //搜索,按登录名、用户名
            if (!string.IsNullOrEmpty(parameters.Search))
            {
                var serach = parameters.Search.ToLowerInvariant();
                query = query.Where(t => t.Account.ToLowerInvariant().Contains(serach) || t.UserName.ToLowerInvariant().Contains(serach));
            }

            //自定义排序
            query = query.ApplySort(parameters.OrderBy, propertyMappingContainer.Resolve<UserViewModel, User>());
            var count = await query.CountAsync();
            var data = await query.Skip(parameters.PageIndex - 1 * parameters.PageSize).Take(parameters.PageSize).ToListAsync();
            return new PaginatedList<User>(parameters.PageIndex - 1, parameters.PageSize, count, data);
        }

        public async Task<object> GetPermissionByAccountAsync(string account)
        {
            var data = from a in context.GroupFuncs
                       join b in context.GroupUsers on a.GroupCode equals b.GroupCode
                       join c in context.Groups on a.GroupCode equals c.GroupCode
                       join d in context.Menus on a.MenuCode equals d.MenuCode
                       select new
                       {
                           b.Account,
                           c.GroupName,
                           d.MenuName,
                           d.MenuCaption,
                           d.MenuNameSpace,
                           d.ParentName,
                           a.Authorities
                       };
            return await data.ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await context.Users.FindAsync(id);
        }

        public async Task<User> LoginAsync(string account, string passWord)
        {
            var result = await context.Users.FirstOrDefaultAsync(t => t.Account == account && t.Password == passWord);
            return result;
        }

        public void UpdateAsync(User user)
        {
            context.Entry(user).State = EntityState.Modified;
        }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Frame.EFCore.Entity;
using System.Linq;

namespace Frame.EFCore.DbFile
{
    public class ZfsDbContext : DbContext
    {
        public ZfsDbContext(DbContextOptions<ZfsDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        public DbSet<Menu> Menus { get; set; }

        public DbSet<LoginLog> LoginLogs { get; set; }

        public DbSet<GroupUser> GroupUsers { get; set; }

        public DbSet<GroupFunc> GroupFuncs { get; set; }

        public DbSet<Group> Groups { get; set; }

        public DbSet<DictionaryType> DictionaryTypes { get; set; }

        public DbSet<Dictionaries> Dictionaries { get; set; }

        public DbSet<Authorithitem> Authorithitems { get; set; }
    }
}

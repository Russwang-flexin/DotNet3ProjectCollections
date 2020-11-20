using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;
using Microsoft.EntityFrameworkCore;

namespace DotNetScrapy
{
    // 搭建数据库
    public class JsonDataToDB : DbContext
    {
        public DbSet<RowsDataModel> RowsDataModelas { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=StockInfo.db");
        }
    }

    public class RowsDataModel
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string PYSimple { get; set; }
        public string Market { get; set; }
        public string PYWhole { get; set; }
    }
}

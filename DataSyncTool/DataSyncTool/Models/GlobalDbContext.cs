using Microsoft.EntityFrameworkCore;
using Sunny.UI.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSyncTool.Models
{
    public class GlobalDbContext : DbContext
    {
        //private string sourceConnectionString;

        //public GlobalDbContext(string sourceConnectionString)
        //{
        //    this.sourceConnectionString = sourceConnectionString;
        //}
       
        private readonly string _connectionString;

        public GlobalDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}

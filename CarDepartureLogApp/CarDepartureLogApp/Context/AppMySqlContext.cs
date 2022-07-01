using CarDepartureLogApp.Context.Interfaces;
using CarDepartureLogApp.Models;
using CarDepartureLogApp.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDepartureLogApp.Context
{
    public class AppMySqlContext : DbContext, IAppContext
    {
        #region Реализация Singleton

        private static readonly AppMySqlContext? _appMySqlContext;

        public static AppMySqlContext GetAppContext()
        {
            return _appMySqlContext ?? new AppMySqlContext(DbOptions.ConnectionString);
        }

        #endregion

        private readonly string? _connectionString;

        public DbSet<IDepartureRecord> DepartureRecords { get; set; } = null!;
        public DbSet<ICar> Cars { get; set; } = null!;
        public DbSet<IDriver> Drivers { get; set; } = null!;

        private AppMySqlContext()
        {

        }

        private AppMySqlContext(string connectionString)
        {
            _connectionString = connectionString;
            Database.EnsureCreated();
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(_connectionString, new MySqlServerVersion(new Version(8, 0, 27)));
        }
    }
}

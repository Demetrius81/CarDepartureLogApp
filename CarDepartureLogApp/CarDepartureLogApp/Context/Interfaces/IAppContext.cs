using CarDepartureLogApp.Models;
using CarDepartureLogApp.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CarDepartureLogApp.Context.Interfaces
{
    public interface IAppContext
    {
        DbSet<Car> Cars { get; set; }
        DbSet<DepartureRecord> DepartureRecords { get; set; }
        DbSet<Driver> Drivers { get; set; }        
    }
}
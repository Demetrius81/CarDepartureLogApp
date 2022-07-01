using CarDepartureLogApp.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CarDepartureLogApp.Context.Interfaces
{
    public interface IAppContext
    {
        DbSet<ICar> Cars { get; set; }
        DbSet<IDepartureRecord> DepartureRecords { get; set; }
        DbSet<IDriver> Drivers { get; set; }        
    }
}
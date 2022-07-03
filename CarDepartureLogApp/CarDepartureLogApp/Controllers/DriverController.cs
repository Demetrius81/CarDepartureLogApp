using CarDepartureLogApp.Context;
using CarDepartureLogApp.Models;
using CarDepartureLogApp.Models.Interfaces;

namespace CarDepartureLogApp.Controllers
{
    public class DriverController
    {
        //private readonly AppMySqlContext _context;

        //public DriverController()
        //{
        //    _context = AppMySqlContext.GetAppContext();
        //}
        public void Create(string name, string middleName, string surName)
        {
            using (var _context = new AppMySqlContext())
            {
                _context.Drivers.Add(new Driver(name, middleName, surName));

                _context.SaveChanges();
            }
        }

        public Driver Read(int id)
        {
            Driver driver = new Driver();

            using (var _context = new AppMySqlContext())
            {
                driver = _context.Drivers.Where(x => x.Id == id).FirstOrDefault();
            }
            return driver;
        }

        public List<Driver> ReadAll()
        {
            List<Driver> drivers = new List<Driver>();

            using (var _context = new AppMySqlContext())
            {
                drivers = _context.Drivers.ToList();
            }
            return drivers;
        }

        public void Update(Driver driver, string surName)
        {
            using (var _context = new AppMySqlContext())
            {
                _context.Drivers.Where(x => x.Equals(driver)).FirstOrDefault().SurName = surName;

                _context.SaveChanges();
            }
        }

        public void Delete(Driver driver)
        {
            using (var _context = new AppMySqlContext())
            {
                _context.Remove<Driver>(driver);

                _context.SaveChanges();
            }
        }
    }
}

using CarDepartureLogApp.Context;
using CarDepartureLogApp.Models;
using CarDepartureLogApp.Models.Interfaces;

namespace CarDepartureLogApp.Controllers
{
    public class DriverController
    {
        private readonly AppMySqlContext _context;

        public DriverController()
        {
            _context = AppMySqlContext.GetAppContext();
        }
        public void Create(string name, string middleName, string surName)
        {
            using (_context)
            {
                _context.Drivers.Add(new Driver(name, middleName, surName));

                _context.SaveChanges();
            }
        }
        public IDriver Read(int id)
        {
            IDriver driver = new Driver();

            using (_context)
            {
                driver = _context.Drivers.Where(x => x.Id == id).FirstOrDefault();
            }
            return driver;
        }
        public void Update(IDriver driver, string surName)
        {
            using (_context)
            {
                _context.Drivers.Where(x => x.Equals(driver)).FirstOrDefault().SurName = surName;

                _context.SaveChanges();
            }
        }
        public void Delete(IDriver driver)
        {
            using (_context)
            {
                _context.Remove<IDriver>(driver);

                _context.SaveChanges();
            }
        }
    }
}

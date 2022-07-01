using CarDepartureLogApp.Context;
using CarDepartureLogApp.Models;
using CarDepartureLogApp.Models.Interfaces;

namespace CarDepartureLogApp.Controllers
{
    public class CarController
    {
        private readonly AppMySqlContext _context;

        public CarController()
        {
            _context = AppMySqlContext.GetAppContext();
        }

        public void Create(string registrationNumber, string brand, string model)
        {
            using (_context)
            {
                _context.Cars.Add(new Car(registrationNumber, brand, model));

                _context.SaveChanges();
            }
        }
        public ICar Read(int id)
        {
            ICar car = new Car();

            using (_context)
            {
                car = _context.Cars.Where(x => x.Id == id).FirstOrDefault();
            }
            return car;
        }
        public void Update(ICar car, bool away)
        {
            using (_context)
            {
                _context.Cars.Where(x => x.Equals(car)).FirstOrDefault().Away = away;

                _context.SaveChanges();
            }
        }
        public void Delete(ICar car)
        {
            using (_context)
            {
                _context.Remove<ICar>(car);

                _context.SaveChanges();
            }
        }

    }
}

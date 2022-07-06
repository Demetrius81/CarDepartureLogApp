using CarDepartureLogApp.Context;
using CarDepartureLogApp.Models;
using CarDepartureLogApp.Models.Interfaces;

namespace CarDepartureLogApp.Controllers
{
    public class CarController
    {        
        public void Create(string registrationNumber, string brand, string model)
        {
            using (var _context = new AppMySqlContext())
            {
                _context.Cars.Add(new Car(registrationNumber, brand, model));

                _context.SaveChanges();
            }
        }


        public Car Read(int id)
        {
            Car car;

            using (var _context = new AppMySqlContext())
            {
                car = _context.Cars.Where(x => x.Id == id).FirstOrDefault();
            }
            return car;
        }

        public List<Car> ReadAll()
        {
            List<Car> cars = new List<Car>();

            using (var _context = new AppMySqlContext())
            {
                cars = _context.Cars.ToList();
            }
            return cars;
        }

        public void Update(Car car, bool away)
        {
            using (var _context = new AppMySqlContext())
            {
                _context.Cars.Where(x => x.Equals(car)).FirstOrDefault().Away = away;

                _context.SaveChanges();
            }
        }
        public void Delete(Car car)
        {
            using (var _context = new AppMySqlContext())
            {
                _context.Remove<Car>(car);

                _context.SaveChanges();
            }
        }

    }
}

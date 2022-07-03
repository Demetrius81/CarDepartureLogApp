using CarDepartureLogApp.Context;
using CarDepartureLogApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDepartureLogApp.Core
{
    internal class DepartureRecordOperations : BaseMenuOperations
    {
        private readonly AppMySqlContext _context;

        public DepartureRecordOperations()
        {
            _context = AppMySqlContext.GetAppContext();
        }

        internal override void AddToList(ConsoleKeyInfo key)
        {


            Car car = new Car();

            Driver driver = new Driver();

            DepartureRecord lastRecordSelectedCar = null;

            ShowOperationInfo($"{key.KeyChar} Новая запись о выезде");

            CarOperations carOperations = new CarOperations(_context);

            carOperations.ShowAll(key);

            int odometerBeforeLeaving = default;

            while (true)
            {
                RequestToEnter("Введите ID автомобиля", out int carId);

                using (_context)
                {
                    car = _context.Cars.Where(x => x.Id == carId).FirstOrDefault() as Car;
                }

                if (car.Away)
                {
                    Console.WriteLine($"Автомобиль {car.ToString()} на выезде. оформить выезд невозможно. Нажмите любую клавишу чтобы продолжить...");

                    Console.ReadKey(true);

                    continue;
                }

                if (car == null)
                {
                    Console.WriteLine("Автомобиля с введенным ID нет в списке. Нажмите любую клавишу чтобы продолжить...");

                    Console.ReadKey(true);

                    continue;
                }
                break;
            }

            DriverOperations driverOperations = new DriverOperations();

            while (true)
            {
                RequestToEnter("Введите ID водителя", out int driverId);
                using (_context)
                {
                    driver = _context.Drivers.Where(x => x.Id == driverId).FirstOrDefault() as Driver;
                }

                if (driver == null)
                {
                    Console.WriteLine("Водителя с введенным ID нет в списке. Нажмите любую клавишу чтобы продолжить...");

                    Console.ReadKey(true);

                    continue;
                }
                break;
            }

            using (_context)
            {
                lastRecordSelectedCar = _context.DepartureRecords.Where(x => x.Equals(car)).LastOrDefault() as DepartureRecord;
            }

            if (lastRecordSelectedCar == null)
            {
                // TODO: здесь вызываем метод создания новой записи с новым автомобилем
            }
            else
            {
                odometerBeforeLeaving = lastRecordSelectedCar.OdometerAfterLeaving;
            }

            string purposeOfDeparture = RequestToEnter("Введите цель поездки");
            string description = RequestToEnter("Введите примечания");

            bool isIt = RequestToAdd(car.ToString(), $"Показания одометра: {odometerBeforeLeaving}");

            if (isIt)
            {
                using (_context)
                {
                    _context.DepartureRecords.Add(new DepartureRecord
                    {
                        DepartureTime = DateTime.Now,
                        OdometerBeforeLeaving = odometerBeforeLeaving,
                        PurposeOfDeparture = purposeOfDeparture,
                        Description = description,
                        CarId = car.Id,
                        DriverId = driver.Id
                    });

                    _context.Cars.Where(x => x.Equals(car)).FirstOrDefault().Away = true;

                    _context.SaveChanges();

                }
            }
        }

        internal override void Update(ConsoleKeyInfo key) { }

        internal override void RemoveFromList(ConsoleKeyInfo key)
        {
            ShowOperationInfo($"{key.KeyChar} Удаление записи о выезде");

            Console.WriteLine();

            using (_context)
            {
                foreach (var item in _context.DepartureRecords)
                {
                    Console.WriteLine(item.ToString());
                }

                RequestToEnter("Введите ID записи для удаления.", out int id);

                DepartureRecord record = _context.DepartureRecords.FirstOrDefault(x => x.Id == id) as DepartureRecord;

                if (record is not null)
                {
                    _context.DepartureRecords.Remove(record);
                    _context.SaveChanges();
                    return;
                }
                Console.WriteLine("Такой записи нет нет.");
            }
        }

        internal override void ShowAll(ConsoleKeyInfo key)
        {
            ShowOperationInfo($"{key.KeyChar} Записи о выезде за день");

            Console.WriteLine();

            using (_context)
            { 
                var records = _context.DepartureRecords
                    .Where(x => x.DepartureTime > DateTime.Now.AddHours(-24) 
                             && x.DepartureTime <= DateTime.Now)
                    .ToList();

                foreach (DepartureRecord record in records)
                {
                    Console.WriteLine(record.ToString());
                }
            }
        }

        protected override string RequestToEnter(string request)
        {
            Console.Write($"\n{request} >");
            Console.CursorVisible = true;
            string? text = Console.ReadLine();
            Console.CursorVisible = false;
            if (text == null)
            {
                return "";
            }
            return text;
        }
    }
}

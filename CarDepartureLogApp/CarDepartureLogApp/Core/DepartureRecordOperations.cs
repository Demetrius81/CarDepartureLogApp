using CarDepartureLogApp.Context;
using CarDepartureLogApp.Controllers;
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
        private readonly DepartureLogController _logController;

        private readonly DriverController _driverController;

        private readonly CarController _carController;

        public DepartureRecordOperations()
        {
            _logController = new DepartureLogController();

            _driverController = new DriverController();

            _carController = new CarController();
        }

        internal void AddToListNewCar(ConsoleKeyInfo key)
        {
            int odometerBeforeLeaving = default;
            string purposeOfDeparture = default;
            string description = default;
            Car car = new();
            Driver driver = new();

            ShowOperationInfo($"{key.KeyChar} Новая запись о выезде");

            CarOperations carOperations = new CarOperations();

            carOperations.ShowAll(key);

            while (true)
            {
                RequestToEnter("Введите ID автомобиля", out int carId);

                car = _carController.ReadAll().Where(x => x.Id == carId).FirstOrDefault();

                if (car.Away)
                {
                    Console.Write($"Автомобиль {car.ToString()} на выезде. оформить выезд невозможно. Желаете подолжить? Y/N");

                    ConsoleKey userKey = Console.ReadKey(true).Key;

                    if (userKey == ConsoleKey.N)
                    {
                        return;
                    }

                    continue;
                }

                if (car == null)
                {
                    Console.WriteLine("Автомобиля с введенным ID нет в списке. Желаете подолжить? Y/N");

                    ConsoleKey userKey = Console.ReadKey(true).Key;

                    if (userKey == ConsoleKey.N)
                    {
                        return;
                    }

                    continue;
                }
                break;
            }

            DriverOperations driverOperations = new DriverOperations();

            driverOperations.ShowAll(key);

            while (true)
            {
                RequestToEnter("Введите ID водителя", out int driverId);

                driver = _driverController.ReadAll().Where(x => x.Id == driverId).FirstOrDefault();

                if (driver == null)
                {
                    Console.WriteLine("Водителя с введенным ID нет в списке. Желаете подолжить? Y/N");

                    ConsoleKey userKey = Console.ReadKey(true).Key;

                    if (userKey == ConsoleKey.N)
                    {
                        return;
                    }

                    continue;
                }
                break;
            }

            RequestToEnter("Введите показания одометра", out odometerBeforeLeaving);
            purposeOfDeparture = RequestToEnter("Введите цель поездки");
            description = RequestToEnter("Введите примечания");

            bool isIt = RequestToAdd(car.ToString(), driver.ToString(), $"Показания одометра: {odometerBeforeLeaving}");

            if (isIt)
            {
                
                _logController.Create(DateTime.Now, odometerBeforeLeaving, purposeOfDeparture, description, car.Id, driver.Id);

                _carController.Update(car, true);               

            }
        }

        internal void AddToListCarReturn(ConsoleKeyInfo key)
        {
            ShowOperationInfo($"{key.KeyChar} Закрытие записи о выезде");

            List<DepartureRecord> records = _logController.ReadLastAway();

            ShowOperationInfo($"{key.KeyChar} Записи о выезде автомобилей");

            Console.WriteLine();

            foreach (var item in records)
            {
                Console.WriteLine(item.ToStringAway());
            }

            while (true)
            {
                RequestToEnter("Введите номер записи из списка", out int number);

                DepartureRecord record = _logController.ReadLastAway().Where(x => x.Id == number).FirstOrDefault();

                if (record == null)
                {
                    Console.WriteLine("Записи с введенным ID нет в списке. Желаете подолжить? Y/N");

                    ConsoleKey userKey = Console.ReadKey(true).Key;

                    if (userKey == ConsoleKey.N)
                    {
                        return;
                    }

                    continue;
                }                

                RequestToEnter("Введите показания одометра", out int odometerAfterLeaving);

                while (true)
                {
                    if (odometerAfterLeaving > record.OdometerBeforeLeaving)
                    {
                        _logController.Update(record, DateTime.Now, odometerAfterLeaving);

                        _carController.Update(_carController.Read(record.CarId), false);

                        return;
                    }
                    else
                    {
                        Console.WriteLine("Показания одометра по возвращении должно быть больше показаний одометра перед выездом!");

                        Console.Write($"Желаете подолжить? Y/N");

                        ConsoleKey userKey = Console.ReadKey(true).Key;

                        if (userKey == ConsoleKey.N)
                        {
                            return;
                        }
                    }
                }
            }
        }

        internal override void AddToListCarOut(ConsoleKeyInfo key)
        {
            Car car = new Car();

            Driver driver = new Driver();

            DepartureRecord lastRecordSelectedCar = null;

            ShowOperationInfo($"{key.KeyChar} Новая запись о выезде");

            CarOperations carOperations = new CarOperations();

            carOperations.ShowAll(key);

            int odometerBeforeLeaving = default;

            while (true)
            {
                RequestToEnter("Введите ID автомобиля", out int carId);

                car = _carController.ReadAll().Where(x => x.Id == carId).FirstOrDefault();

                if (car.Away)
                {
                    Console.Write($"Автомобиль {car.ToString()} на выезде. оформить выезд невозможно. Желаете подолжить? Y/N");

                    ConsoleKey userKey = Console.ReadKey(true).Key;

                    if (userKey == ConsoleKey.N)
                    {
                        return;
                    }

                    continue;
                }

                if (car == null)
                {
                    Console.WriteLine("Автомобиля с введенным ID нет в списке. Желаете подолжить? Y/N");

                    ConsoleKey userKey = Console.ReadKey(true).Key;

                    if (userKey == ConsoleKey.N)
                    {
                        return;
                    }

                    continue;
                }
                break;
            }

            DriverOperations driverOperations = new DriverOperations();

            driverOperations.ShowAll(key);

            while (true)
            {
                RequestToEnter("Введите ID водителя", out int driverId);

                driver = _driverController.ReadAll().Where(x => x.Id == driverId).FirstOrDefault();

                if (driver == null)
                {
                    Console.WriteLine("Водителя с введенным ID нет в списке. Желаете подолжить? Y/N");

                    ConsoleKey userKey = Console.ReadKey(true).Key;

                    if (userKey == ConsoleKey.N)
                    {
                        return;
                    }

                    continue;
                }
                break;
            }


            lastRecordSelectedCar = _logController.ReadAll().Where(x => x.Equals(car)).LastOrDefault();

            if (lastRecordSelectedCar == null)
            {
                AddToListNewCar(key);
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
                car.Away = true;

                _logController.Create(DateTime.Now, odometerBeforeLeaving, purposeOfDeparture, description, car.Id, driver.Id);

                _carController.Update(car, true);
            }
        }

        internal override void Update(ConsoleKeyInfo key) { }

        internal override void RemoveFromList(ConsoleKeyInfo key)
        {
            ShowOperationInfo($"{key.KeyChar} Удаление записи о выезде");

            Console.WriteLine();

            List<DepartureRecord> records = _logController.ReadAll();

            foreach (var item in records)
            {
                Console.WriteLine(item.ToString());
            }

            RequestToEnter("Введите ID записи для удаления", out int id);

            DepartureRecord record = _logController.ReadAll().Where(x => x.Id == id).FirstOrDefault();

            while (true)
            {
                if (record == null)
                {
                    Console.Write($"Запись с введенным номером отсутствует. Желаете подолжить? Y/N");

                    ConsoleKey userKey = Console.ReadKey(true).Key;

                    if (userKey == ConsoleKey.N)
                    {
                        return;
                    }

                    continue;
                }
            }

            _logController.Delete(record);

        }

        internal override void ShowAll(ConsoleKeyInfo key)
        {
            ShowOperationInfo($"{key.KeyChar} Записи о выезде за день");

            Console.WriteLine();

            List<DepartureRecord> records = _logController.ReadLastDay();

            foreach (var item in records)
            {
                Console.WriteLine(item.ToString());
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

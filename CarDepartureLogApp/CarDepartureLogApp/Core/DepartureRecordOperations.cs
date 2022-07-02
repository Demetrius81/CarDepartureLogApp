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

#if DEBUG

        private List<DepartureRecord> _departures = new List<DepartureRecord>()
        {
            new DepartureRecord
            {
                Id = 1,
                DepartureTime = DateTime.Now,
                ReturnTime =DateTime.Now,
                OdometerBeforeLeaving =1,
                OdometerAfterLeaving = default,
                PurposeOfDeparture = "За апельсинами",
                Description = "На последних парах",
                Car = new Car{Id = 3, RegistrationNumber = "0003 OP-6", Brand = "Audi", Model = "Q7", Away = true },
                Driver = new Driver { Id = 1, Name = "Василий", MiddleName = "Иванович", SurName = "Пупкин" }
            },
            new DepartureRecord
            {
                Id = 2,
                DepartureTime = DateTime.Now,
                ReturnTime =DateTime.Now,
                OdometerBeforeLeaving =12345,
                OdometerAfterLeaving = 12456,
                PurposeOfDeparture = "За ананасами",
                Description = "Без лобового стекла",
                Car = new Car { Id = 1, RegistrationNumber = "0001 AB-6", Brand = "VAZ", Model = "21063", Away = false },
                Driver = new Driver { Id = 2, Name = "Аркадий", MiddleName = "Петрович", SurName = "Пароходов" }
            },
            new DepartureRecord
            {
                Id = 3,
                DepartureTime = DateTime.Now,
                ReturnTime =DateTime.Now,
                OdometerBeforeLeaving =2234,
                OdometerAfterLeaving = 2356,
                PurposeOfDeparture = "На ТО",
                Description = "На последних парах",
                Car = new Car { Id = 2, RegistrationNumber = "0002 MI-7", Brand = "Mazda", Model = "MX7", Away = false },
                Driver = new Driver { Id = 3, Name = "Семен", MiddleName = "Яковлевич", SurName = "Зильберман" }
            }
        };

#endif

        internal override void AddToList(ConsoleKeyInfo key)
        {
            CarOperations carOperations = new CarOperations();

            Car car = new Car();

            ShowOperationInfo($"{key.KeyChar} Новая запись о выезде");

            carOperations.ShowAll(key);

            DateTime departureTime = DateTime.Now;

            int odometerBeforeLeaving;

            while (true)
            {
                Console.CursorVisible = true;

                bool isParse = int.TryParse(RequestToEnter("Введите ID автомобиля"), out int id);

                Console.CursorVisible = false;

                if (!isParse)
                {
                    Console.WriteLine("Вы ввели не цифру. Нажмите любую клавишу чтобы продолжить...");

                    Console.ReadKey(true);

                    continue;
                }

                car = carOperations.Cars.Where(x => x.Id == id).FirstOrDefault();

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

            DepartureRecord lastRecordSelectedCar = _departures.Where(x => x.Equals(car)).LastOrDefault();

            if (lastRecordSelectedCar == null)
            {
                odometerBeforeLeaving = 0;
            }
            else
            {
                odometerBeforeLeaving = lastRecordSelectedCar.OdometerAfterLeaving;
            }

            string purposeOfDeparture = RequestToEnter("Введите цель поездки");
            string description = RequestToEnter("Введите примечания");

            bool isIt = RequestToAdd(departureTime.ToShortTimeString(), car.ToString(), $"Показания одометра: {odometerBeforeLeaving}");

            if (isIt)
            {
#if DEBUG

                int i = _departures.LastOrDefault().Id + 1;

                _departures.Add(new DepartureRecord
                {
                    Id = 3,
                    DepartureTime = DateTime.Now,
                    ReturnTime = DateTime.Now,
                    OdometerBeforeLeaving = 125367,
                    OdometerAfterLeaving = 184257,
                    PurposeOfDeparture = "На ТО",
                    Description = "На последних парах",
                    Car = new Car { Id = 3, RegistrationNumber = "0003 OP-6", Brand = "Audi", Model = "Q7", Away = false },
                    Driver = new Driver { Id = 1, Name = "Василий", MiddleName = "Иванович", SurName = "Пупкин" }
                });

#endif

                // TODO: Добавление водителя в БД

                Console.WriteLine("\nAdd to DataBase");
                Console.ReadKey();
            }
        }

        internal override void Update(ConsoleKeyInfo key) { }

        internal override void RemoveFromList(ConsoleKeyInfo key)
        {
            ShowOperationInfo($"{key.KeyChar} Добавление автомобиля в список");

            Console.WriteLine();

            // TODO: вывод списка водителей

#if DEBUG


            foreach (var item in _departures)
                Console.WriteLine(item.ToString());
            Console.WriteLine();

#endif


            string numberString = RequestToEnter("Введите Номер автомобиля из списка");

            bool isParse = int.TryParse(numberString, out int number);

            // TODO: Удаление водителя из БД

#if DEBUG
            if (isParse)
            {
                DepartureRecord departureRecord = _departures.FirstOrDefault(x => x.Id == number);

                if (departureRecord is not null)
                {



                    _departures.Remove(departureRecord);


                    return;
                }

                throw new Exception($"A Departure Record with ID {number} do not exist in the list!");

            }

            throw new ArgumentException($"\"{numberString}\" is not a number!");
#endif


        }

        internal override void ShowAll(ConsoleKeyInfo key)
        {
            ShowOperationInfo($"{key.KeyChar} Записи о выезде за день");

            Console.WriteLine();

            // TODO: вывод списка водителей

#if DEBUG

            foreach (var item in _departures)
                Console.WriteLine(item.ToString());

            Console.WriteLine();

#endif
            Console.WriteLine("Для продолжения нажмите любую клавишу...");

            Console.ReadKey(true);
        }
    }
}

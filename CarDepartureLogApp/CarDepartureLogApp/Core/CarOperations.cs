using CarDepartureLogApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDepartureLogApp.Core
{
    internal class CarOperations : BaseMenuOperations
    {

#if DEBUG

        private List<Car> _cars = new List<Car>()
        {
            new Car { Id = 1, RegistrationNumber = "0001 AB-6", Brand = "VAZ", Model = "21063", Away = false },
            new Car { Id = 2, RegistrationNumber = "0002 MI-7", Brand = "Mazda", Model = "MX7", Away = false },
            new Car { Id = 3, RegistrationNumber = "0003 OP-6", Brand = "Audi", Model = "Q7", Away = false }
        };

#endif

        internal override void AddToList(ConsoleKeyInfo key)
        {
            ShowOperationInfo($"{key.KeyChar} Добавление автомобиля в список");

            string registrationNumber = RequestToEnter("Введите номер автомобиля");
            string brand = RequestToEnter("Введите марку автомобиля");
            string model = RequestToEnter("Введите модель автомобиля");

            bool isIt = RequestToAdd(registrationNumber, brand, model);

            if (isIt)
            {
#if DEBUG

                int i = _cars.LastOrDefault().Id + 1;

                _cars.Add(new Car { Id = i, RegistrationNumber = registrationNumber, Brand = brand, Model = model, Away = false });

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


            foreach (var driver in _cars)
                Console.WriteLine(driver.ToString());
            Console.WriteLine();

#endif


            string numberString = RequestToEnter("Введите Номер автомобиля из списка");

            bool isParse = int.TryParse(numberString, out int number);

            // TODO: Удаление водителя из БД

#if DEBUG
            if (isParse)
            {
                Car driver = _cars.FirstOrDefault(x => x.Id == number);

                if (driver is not null)
                {



                    _cars.Remove(driver);


                    return;
                }

                throw new Exception($"A car with ID {number} do not exist in the list!");

            }

            throw new ArgumentException($"\"{numberString}\" is not a number!");
#endif


        }

        internal override void ShowAllDrivers(ConsoleKeyInfo key)
        {
            ShowOperationInfo($"{key.KeyChar} Список автомобилей");

            Console.WriteLine();

            // TODO: вывод списка водителей

#if DEBUG

            foreach (var driver in _cars)
                Console.WriteLine(driver.ToString());

            Console.WriteLine();

#endif
            Console.WriteLine("Для продолжения нажмите любую клавишу...");

            Console.ReadKey(true);
        }
    }
}

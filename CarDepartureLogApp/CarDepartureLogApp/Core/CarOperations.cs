using CarDepartureLogApp.Context;
using CarDepartureLogApp.Controllers;
using CarDepartureLogApp.Models;
using CarDepartureLogApp.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDepartureLogApp.Core
{
    internal class CarOperations : BaseMenuOperations
    {
        private readonly CarController _carController;

        public CarOperations()
        {
            _carController = new CarController();
        }

        internal override void AddToListCarOut(ConsoleKeyInfo key)
        {
            ShowOperationInfo($"{key.KeyChar} Добавление автомобиля в список");

            string registrationNumber = RequestToEnter("Введите номер автомобиля");
            string brand = RequestToEnter("Введите марку автомобиля");
            string model = RequestToEnter("Введите модель автомобиля");

            bool isIt = RequestToAdd(registrationNumber, brand, model);

            if (isIt)
            {
                _carController.Create(registrationNumber, brand, model);
            }
        }

        internal override void Update(ConsoleKeyInfo key)
        {

        }

        internal override void RemoveFromList(ConsoleKeyInfo key)
        {
            ShowOperationInfo($"{key.KeyChar} Удаление автомобиля из списка");

            Console.WriteLine();

            List<Car> cars = new List<Car>();

            ShowOperationInfo($"{key.KeyChar} Список автомобилей");

            Console.WriteLine();

            foreach (var item in cars)
            {
                Console.WriteLine(item.ToString());
            }
            
            RequestToEnter("Введите номер автомобиля из списка", out int number);

            Car car = cars.FirstOrDefault(x => x.Id == number);

            if (car is not null)
            {
                _carController.Delete(car);

                return;
            }
            Console.WriteLine("Такого автомобиля в списке нет.");


        }

        internal override void ShowAll(ConsoleKeyInfo key)
        {
            List<Car> cars = new List<Car>();

            ShowOperationInfo($"{key.KeyChar} Список автомобилей");

            Console.WriteLine();

            foreach (var item in cars)
            {
                Console.WriteLine(item.ToString());
            }
        }

    }
}

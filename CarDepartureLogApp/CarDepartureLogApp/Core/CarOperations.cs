using CarDepartureLogApp.Context;
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
        private readonly AppMySqlContext _context;
        
        public CarOperations(AppMySqlContext context = null)
        {
            _context = context == null ? AppMySqlContext.GetAppContext() : context;
        }

        internal override void AddToList(ConsoleKeyInfo key)
        {
            ShowOperationInfo($"{key.KeyChar} Добавление автомобиля в список");

            string registrationNumber = RequestToEnter("Введите номер автомобиля");
            string brand = RequestToEnter("Введите марку автомобиля");
            string model = RequestToEnter("Введите модель автомобиля");

            bool isIt = RequestToAdd(registrationNumber, brand, model);

            if (isIt)
            {
                using (_context)
                {
                    _context.Cars.Add(new Car(registrationNumber, brand, model));
                    _context.SaveChanges();
                }
            }
        }

        internal override void Update(ConsoleKeyInfo key)
        {

        }

        internal override void RemoveFromList(ConsoleKeyInfo key)
        {
            ShowOperationInfo($"{key.KeyChar} Удаление автомобиля из списка");

            Console.WriteLine();

            using (_context)
            {
                foreach (Car item in _context.Cars)
                {
                    Console.WriteLine(item.ToString());
                }

                RequestToEnter("Введите номер автомобиля из списка", out int number);

                Car car = _context.Cars.FirstOrDefault(x => x.Id == number);

                if (car is not null)
                {
                    _context.Cars.Remove(car);
                    _context.SaveChanges();
                    return;
                }
                Console.WriteLine("Такого автомобиля в списке нет.");
            }

        }

        internal override void ShowAll(ConsoleKeyInfo key)
        {
            ShowOperationInfo($"{key.KeyChar} Список автомобилей");

            Console.WriteLine();

            using (_context)
            {
                foreach (Car car in _context.Cars)
                {
                    Console.WriteLine(car.ToString());
                }
            }
        }

    }
}

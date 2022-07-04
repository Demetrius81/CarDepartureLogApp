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
    internal class DriverOperations : BaseMenuOperations
    {
        private readonly DriverController _driverController;

        public DriverOperations()
        {
            _driverController = new DriverController();
        }
        internal override void AddToListCarOut(ConsoleKeyInfo key)
        {
            ShowOperationInfo($"{key.KeyChar} Добавление водителя в список");

            string firstName = RequestToEnter("Введите имя водителя");
            string middleName = RequestToEnter("Введите отчество водителя");
            string surName = RequestToEnter("Введите фамилию водителя");

            bool isIt = RequestToAdd(firstName, middleName, surName);

            if (isIt)
            {
                _driverController.Create(firstName, middleName, surName);
            }
        }

        internal override void RemoveFromList(ConsoleKeyInfo key)
        {
            ShowOperationInfo($"{key.KeyChar} Добавление водителя в список");

            Console.WriteLine();

            List<Driver> drivers = _driverController.ReadAll();

            ShowOperationInfo($"{key.KeyChar} Список водителей");

            Console.WriteLine();

            foreach (var item in drivers)
            {
                Console.WriteLine(item.ToString());
            }

            RequestToEnter("Введите номер водителя из списка", out int number);

            Driver driver = drivers.FirstOrDefault(x => x.Id == number);

            if (driver is not null)
            {
                _driverController.Delete(driver);
                return;
            }
            Console.WriteLine("Такого водителя в списке нет.");

        }

        internal override void Update(ConsoleKeyInfo key)
        {

        }

        internal override void ShowAll(ConsoleKeyInfo key)
        {
            ShowOperationInfo($"{key.KeyChar} Список водителей");

            Console.WriteLine();

            List<Driver> drivers = _driverController.ReadAll();

            foreach (var item in drivers)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}

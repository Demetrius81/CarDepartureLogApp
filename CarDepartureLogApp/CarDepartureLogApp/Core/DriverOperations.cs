using CarDepartureLogApp.Context;
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
        private readonly AppMySqlContext _context;

        public DriverOperations(AppMySqlContext context = null)
        {
            _context = context == null ? AppMySqlContext.GetAppContext() : context;
        }

        internal override void AddToList(ConsoleKeyInfo key)
        {
            ShowOperationInfo($"{key.KeyChar} Добавление водителя в список");

            string firstName = RequestToEnter("Введите имя водителя");
            string middleName = RequestToEnter("Введите отчество водителя");
            string surName = RequestToEnter("Введите фамилию водителя");

            bool isIt = RequestToAdd(firstName, middleName, surName);

            if (isIt)
            {
                using (_context)
                {
                    _context.Drivers.Add(new Driver(firstName, middleName, surName));
                    _context.SaveChanges();
                }
            }
        }

        internal override void RemoveFromList(ConsoleKeyInfo key)
        {
            ShowOperationInfo($"{key.KeyChar} Добавление водителя в список");

            Console.WriteLine();

            using (_context)
            {
                foreach (Driver item in _context.Drivers)
                {
                    Console.WriteLine(item.ToString());
                }

                RequestToEnter("Введите номер водителя из списка", out int number);

                Driver driver = _context.Drivers.FirstOrDefault(x => x.Id == number);

                if (driver is not null)
                {
                    _context.Drivers.Remove(driver);
                    _context.SaveChanges();
                    return;
                }
                Console.WriteLine("Такого водителя в списке нет.");
            }
        }

        internal override void Update(ConsoleKeyInfo key)
        {

        }

        internal override void ShowAll(ConsoleKeyInfo key)
        {
            ShowOperationInfo($"{key.KeyChar} Список водителей");

            Console.WriteLine();

            using (_context)
            {
                foreach (var driver in _context.Drivers)
                {
                    Console.WriteLine(driver.ToString());
                }
            }
        }        
    }
}

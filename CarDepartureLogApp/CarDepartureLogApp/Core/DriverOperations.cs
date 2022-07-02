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
#if DEBUG

        private List<Driver> _drivers = new List<Driver>()
        {
            new Driver { Id = 1, Name = "Василий", MiddleName = "Иванович", SurName = "Пупкин" },
            new Driver { Id = 2, Name = "Аркадий", MiddleName = "Петрович", SurName = "Пароходов" },
            new Driver { Id = 3, Name = "Семен", MiddleName = "Яковлевич", SurName = "Зильберман" }
        };

        public List<Driver> Drivers { get => _drivers; set => _drivers = value; }

#endif

        internal override void AddToList(ConsoleKeyInfo key)
        {
            ShowOperationInfo($"{key.KeyChar} Добавление водителя в список");

            string firstName = RequestToEnter("Введите имя водителя");
            string middleName = RequestToEnter("Введите отчество водителя");
            string surName = RequestToEnter("Введите фамилию водителя");

            bool isIt = RequestToAdd(firstName, middleName, surName);

            if (isIt)
            {
#if DEBUG

                int i = _drivers.LastOrDefault().Id + 1;

                _drivers.Add(new Driver { Id = i, Name = firstName, MiddleName = middleName, SurName = surName });

#endif

                // TODO: Добавление водителя в БД

                Console.WriteLine("\nAdd to DataBase");
                Console.ReadKey();
            }
        }

        internal override void RemoveFromList(ConsoleKeyInfo key)
        {
            ShowOperationInfo($"{key.KeyChar} Добавление водителя в список");

            Console.WriteLine();

            // TODO: вывод списка водителей

#if DEBUG


            foreach (var driver in _drivers)
                Console.WriteLine(driver.ToString());
            Console.WriteLine();

#endif


            string numberString = RequestToEnter("Введите Номер водителя из списка");

            bool isParse = int.TryParse(numberString, out int number);

            // TODO: Удаление водителя из БД

#if DEBUG
            if (isParse)
            {
                Driver driver = _drivers.FirstOrDefault(x => x.Id == number);

                if (driver is not null)
                {



                    _drivers.Remove(driver);


                    return;
                }

                throw new Exception($"Driver with ID {number} do not exist in the list!");

            }

            throw new ArgumentException($"\"{numberString}\" is not a number!");
#endif


        }

        internal override void Update(ConsoleKeyInfo key) { }

        internal override void ShowAll(ConsoleKeyInfo key)
        {
            ShowOperationInfo($"{key.KeyChar} Список водителей");

            Console.WriteLine();

            // TODO: вывод списка водителей

#if DEBUG

            foreach (var driver in _drivers)
                Console.WriteLine(driver.ToString());

            Console.WriteLine();

#endif
            
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

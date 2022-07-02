using CarDepartureLogApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDepartureLogApp.Core
{
    internal class DriverOperations : BaseMenuRequests
    {
        internal static void AddToList(ConsoleKeyInfo key)
        {
            ShowOperationInfo($"{key.KeyChar} Добавление водителя в список");

            string firstName = RequestToEnter("Введите имя водителя");
            string middleName = RequestToEnter("Введите отчество водителя");
            string surName = RequestToEnter("Введите фамилию водителя");

            bool isIt = RequestToAdd(firstName, middleName, surName);

            if (isIt)
            {
                // Вызов метода добавления в БД
                Console.WriteLine("\nAdd to DataBase");
                Console.ReadKey();
            }
        }

        internal static void RemoveFromList(ConsoleKeyInfo key)
        {
            ShowOperationInfo($"{key.KeyChar} Добавление водителя в список");




#if DEBUG
            List<Driver> drivers = new List<Driver>();

            Driver driver1 = new Driver { Id = 1, Name = "Василий", MiddleName = "Иванович", SurName = "Пупкин" };
            Driver driver2 = new Driver { Id = 2, Name = "Аркадий", MiddleName = "Петрович", SurName = "Пароходов" };
            Driver driver3 = new Driver { Id = 3, Name = "Семен", MiddleName = "Яковлевич", SurName = "Зильберман" };

            drivers.Add(driver1);
            drivers.Add(driver2);
            drivers.Add(driver3);

            Console.WriteLine();

            foreach (Driver driver in drivers)
                Console.WriteLine(driver.ToString());
            Console.WriteLine();

#endif




            // Вывод списка водителей из БД

            string numberString = RequestToEnter("Введите Номер водителя из списка");

            bool isParse = int.TryParse(numberString, out int number);

            if (isParse)
            {
                Driver driver = drivers.FirstOrDefault(x => x.Id == number);

                if (driver is not null)
                {
                    // Удаляем водителя из БД

                    drivers.Remove(driver);

                    return;
                }

                throw new Exception($"Driver with ID {number} do not exist in the list!");

            }

            throw new ArgumentException($"\"{numberString}\" is not a number!");
            

        }

        internal static void ShowAllDrivers(ConsoleKeyInfo key)
        {
            ShowOperationInfo($"{key.KeyChar} Список водителей");



#if DEBUG
            List<Driver> drivers = new List<Driver>();

            Driver driver1 = new Driver { Id = 1, Name = "Василий", MiddleName = "Иванович", SurName = "Пупкин" };
            Driver driver2 = new Driver { Id = 2, Name = "Аркадий", MiddleName = "Петрович", SurName = "Пароходов" };
            Driver driver3 = new Driver { Id = 3, Name = "Семен", MiddleName = "Яковлевич", SurName = "Зильберман" };

            drivers.Add(driver1);
            drivers.Add(driver2);
            drivers.Add(driver3);

            Console.WriteLine();

            foreach (Driver driver in drivers)
                Console.WriteLine(driver.ToString());
            Console.WriteLine();

#endif
            Console.WriteLine("Для продолжения нажмите любую клавишу...");

            Console.ReadKey(true);
        }


    }
}

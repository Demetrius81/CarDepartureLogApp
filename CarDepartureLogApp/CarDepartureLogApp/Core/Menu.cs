using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDepartureLogApp.Core
{
    internal class Menu
    {
        internal static void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Главное меню");
            Console.WriteLine("====================================================");

            Console.WriteLine("Для работы с журналом выезда автомашин\tнажмите 1");
            Console.WriteLine("Для работы со списком автомобилей\tнажмите 2");
            Console.WriteLine("Для работы со списком водителей\t\tнажмите 3");
            Console.WriteLine("Для выхода из программы\t\t\tнажмите ESC");

            Console.WriteLine("====================================================");
        }
        internal static void LogDepartureMenu()
        {
            Console.Clear();
            Console.WriteLine("1-Меню работы с журналом выезда автомашин");
            Console.WriteLine("====================================================");

            Console.WriteLine("Для добавления записи о выезде\t\tнажмите 1");
            Console.WriteLine("Для отметки о возвращении\t\tнажмите 2");
            Console.WriteLine("Для просмотра сегодняшних выездов\tнажмите 3");
            Console.WriteLine("Для выхода в главное меню\t\tнажмите ESC");

            Console.WriteLine("====================================================");
        }
        internal static void CarMenu()
        {
            Console.Clear();
            Console.WriteLine("2-Меню работы со списком автомобилей");
            Console.WriteLine("====================================================");

            Console.WriteLine("Для добавления автомобиля в список\tнажмите 1");
            Console.WriteLine("Для удаления автомобиля из списка\tнажмите 2");
            Console.WriteLine("Для просмотра списка автомобилей\tнажмите 3");
            Console.WriteLine("Для выхода в главное меню\t\tнажмите ESC");

            Console.WriteLine("====================================================");
        }
        internal static void DriverMenu()
        {
            Console.Clear();
            Console.WriteLine("3-Меню работы со списком водителей");
            Console.WriteLine("====================================================");

            Console.WriteLine("Для добавления водителя в список\tнажмите 1");
            Console.WriteLine("Для удвления водителя из списка\t\tнажмите 2");
            Console.WriteLine("Для Для просмотра списка водителей\tнажмите 3");
            Console.WriteLine("Для выхода в главное меню\t\tнажмите ESC");

            Console.WriteLine("====================================================");
        }
    }
}

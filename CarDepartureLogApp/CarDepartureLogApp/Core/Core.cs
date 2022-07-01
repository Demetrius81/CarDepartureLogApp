using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDepartureLogApp.Core
{
    internal class Core
    {
        public void Run(string[] args)
        {
            bool execute = true;

            while (execute)
            {
                MainMenu();
                Console.CursorVisible = false;
                ConsoleKey key = Console.ReadKey(true).Key;
                
                switch (key)
                {
                    case ConsoleKey.Escape:
                        {
                            Console.Write("Вы уверены, что хотите выйти? Y/N");
                            ConsoleKey consoleKey = Console.ReadKey(true).Key;
                            execute = consoleKey == ConsoleKey.Y ? false : true;
                            break;
                        }
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.D1:
                        {
                            LogDepartureMenu();
                            Console.ReadKey(true);
                            break;
                        }
                    case ConsoleKey.NumPad2:
                    case ConsoleKey.D2:
                        {
                            CarMenu();
                            Console.ReadKey(true);
                            break;
                        }
                    case ConsoleKey.NumPad3:
                    case ConsoleKey.D3:
                        {
                            DriverMenu();
                            Console.ReadKey(true);
                            break;
                        }
                    default:
                        break;
                }

            }

            Console.ReadKey(true);
        }

        private void MainMenu()
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
        private void LogDepartureMenu()
        {
            Console.Clear();
            Console.WriteLine("Меню работы с журналом выезда автомашин");
            Console.WriteLine("====================================================");

            Console.WriteLine("Для работы с журналом выезда автомашин\tнажмите 1");
            Console.WriteLine("Для работы со списком автомобилей\tнажмите 2");
            Console.WriteLine("Для работы со списком водителей\t\tнажмите 3");
            Console.WriteLine("Для выхода из программы\t\t\tнажмите ESC");

            Console.WriteLine("====================================================");
        }
        private void CarMenu()
        {
            Console.Clear();
            Console.WriteLine("Меню работы со списком автомобилей");
            Console.WriteLine("====================================================");

            Console.WriteLine("Для работы с журналом выезда автомашин\tнажмите 1");
            Console.WriteLine("Для работы со списком автомобилей\tнажмите 2");
            Console.WriteLine("Для работы со списком водителей\t\tнажмите 3");
            Console.WriteLine("Для выхода из программы\t\t\tнажмите ESC");

            Console.WriteLine("====================================================");
        }
        private void DriverMenu()
        {
            Console.Clear();
            Console.WriteLine("Меню работы со списком водителей");
            Console.WriteLine("====================================================");

            Console.WriteLine("Для работы с журналом выезда автомашин\tнажмите 1");
            Console.WriteLine("Для работы со списком автомобилей\tнажмите 2");
            Console.WriteLine("Для работы со списком водителей\t\tнажмите 3");
            Console.WriteLine("Для выхода из программы\t\t\tнажмите ESC");

            Console.WriteLine("====================================================");
        }
    }
}

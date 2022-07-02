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
                Menu.MainMenu();
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
                            Menu.LogDepartureMenu();
                            ConsoleKey consoleKey = Console.ReadKey(true).Key;

                            switch (consoleKey)
                            {
                                case ConsoleKey.Escape:
                                    continue;                                                                        
                                case ConsoleKey.NumPad1:
                                case ConsoleKey.D1:
                                    {
                                        // Добавление записи о выезде
                                        break;
                                    }
                                case ConsoleKey.NumPad2:
                                case ConsoleKey.D2:
                                    {
                                        // Отметка о возвращении
                                        break;
                                    }
                                case ConsoleKey.NumPad3:
                                case ConsoleKey.D3:
                                    {
                                        // Просмотр выездов за сегодня
                                        break;
                                    }
                                default:
                                    break;
                            }

                            break;
                        }
                    case ConsoleKey.NumPad2:
                    case ConsoleKey.D2:
                        {
                            Menu.CarMenu();
                            ConsoleKey consoleKey = Console.ReadKey(true).Key;

                            switch (consoleKey)
                            {
                                case ConsoleKey.Escape:
                                    continue;
                                case ConsoleKey.NumPad1:
                                case ConsoleKey.D1:
                                    {
                                        // Добавление автомобиля в список
                                        break;
                                    }
                                case ConsoleKey.NumPad2:
                                case ConsoleKey.D2:
                                    {
                                        // Удаление автомобиля из списка
                                        break;
                                    }
                                case ConsoleKey.NumPad3:
                                case ConsoleKey.D3:
                                    {
                                        // Просмотр списка автомобилей
                                        break;
                                    }
                                default:
                                    break;
                            }

                            break;
                        }
                    case ConsoleKey.NumPad3:
                    case ConsoleKey.D3:
                        {
                            Menu.DriverMenu();
                            ConsoleKey consoleKey = Console.ReadKey(true).Key;

                            switch (consoleKey)
                            {
                                case ConsoleKey.Escape:
                                    continue;
                                case ConsoleKey.NumPad1:
                                case ConsoleKey.D1:
                                    {
                                        // Добавление водителя в список
                                        break;
                                    }
                                case ConsoleKey.NumPad2:
                                case ConsoleKey.D2:
                                    {
                                        // Удаление водителя из списка
                                        break;
                                    }
                                case ConsoleKey.NumPad3:
                                case ConsoleKey.D3:
                                    {
                                        // Просмотр списка водителей
                                        break;
                                    }
                                default:
                                    break;
                            }

                            break;
                        }
                    default:
                        break;
                }

            }

            Console.ReadKey(true);
        }

       
    }
}

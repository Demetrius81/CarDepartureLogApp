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

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                ConsoleKey key = keyInfo.Key;

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
                            bool isMenuRunning = true;

                            while (isMenuRunning)
                            {
                                Menu.LogDepartureMenu(keyInfo);

                                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey(true);

                                ConsoleKey consoleKey = consoleKeyInfo.Key;

                                switch (consoleKey)
                                {
                                    case ConsoleKey.Escape:
                                        {
                                            isMenuRunning = false;
                                            break;
                                        }
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

                            }


                            break;
                        }
                    case ConsoleKey.NumPad2:
                    case ConsoleKey.D2:
                        {
                            bool isMenuRunning = true;

                            while (isMenuRunning)
                            {
                                Menu.CarMenu(keyInfo);

                                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey(true);

                                ConsoleKey consoleKey = consoleKeyInfo.Key;

                                switch (consoleKey)
                                {
                                    case ConsoleKey.Escape:
                                        {
                                            isMenuRunning = false;
                                            break;
                                        }
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

                            }

                            break;
                        }
                    case ConsoleKey.NumPad3:
                    case ConsoleKey.D3:
                        {
                            bool isMenuRunning = true;

                            while (isMenuRunning)
                            {
                                Menu.DriverMenu(keyInfo);

                                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey(true);

                                ConsoleKey consoleKey = consoleKeyInfo.Key;

                                switch (consoleKey)
                                {
                                    case ConsoleKey.Escape:
                                        {
                                            isMenuRunning = false;
                                            break;
                                        }
                                    case ConsoleKey.NumPad1:
                                    case ConsoleKey.D1:
                                        {
                                            DriverOperations.AddToList(consoleKeyInfo);
                                            
                                            break;
                                        }
                                    case ConsoleKey.NumPad2:
                                    case ConsoleKey.D2:
                                        {
                                            DriverOperations.RemoveFromList(consoleKeyInfo);
                                            
                                            break;
                                        }
                                    case ConsoleKey.NumPad3:
                                    case ConsoleKey.D3:
                                        {
                                            DriverOperations.ShowAllDrivers(consoleKeyInfo);
                                            // Просмотр списка водителей
                                            break;
                                        }
                                    default:
                                        break;
                                }

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

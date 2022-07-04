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
                            DepartureRecordOperations listOfDepartureOperations = new DepartureRecordOperations();

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
                                            listOfDepartureOperations.AddToListCarOut(consoleKeyInfo);

                                            break;
                                        }
                                    case ConsoleKey.NumPad2:
                                    case ConsoleKey.D2:
                                        {
                                            listOfDepartureOperations.Update(consoleKeyInfo);

                                            break;
                                        }
                                    case ConsoleKey.NumPad3:
                                    case ConsoleKey.D3:
                                        {
                                            listOfDepartureOperations.ShowAll(consoleKeyInfo);

                                            listOfDepartureOperations.PressAKey();

                                            break;
                                        }
                                    case ConsoleKey.NumPad4:
                                    case ConsoleKey.D4:
                                        {
                                            listOfDepartureOperations.AddToListNewCar(consoleKeyInfo);

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
                            CarOperations carOperations = new CarOperations();

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
                                            carOperations.AddToListCarOut(consoleKeyInfo);

                                            break;
                                        }
                                    case ConsoleKey.NumPad2:
                                    case ConsoleKey.D2:
                                        {
                                            carOperations.RemoveFromList(consoleKeyInfo);

                                            break;
                                        }
                                    case ConsoleKey.NumPad3:
                                    case ConsoleKey.D3:
                                        {
                                            carOperations.ShowAll(consoleKeyInfo);

                                            carOperations.PressAKey();

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
                            DriverOperations driverOperations = new DriverOperations();

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
                                            driverOperations.AddToListCarOut(consoleKeyInfo);

                                            break;
                                        }
                                    case ConsoleKey.NumPad2:
                                    case ConsoleKey.D2:
                                        {
                                            driverOperations.RemoveFromList(consoleKeyInfo);

                                            break;
                                        }
                                    case ConsoleKey.NumPad3:
                                    case ConsoleKey.D3:
                                        {
                                            driverOperations.ShowAll(consoleKeyInfo);

                                            driverOperations.PressAKey();

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

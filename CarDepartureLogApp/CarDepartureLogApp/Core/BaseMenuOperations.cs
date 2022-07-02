using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDepartureLogApp.Core
{
    internal abstract class BaseMenuOperations
    {
        protected void ShowOperationInfo(string text)
        {
            Console.WriteLine(text);

            Console.WriteLine("====================================================");
        }

        protected bool RequestToAdd(params string[] args)
        {
            if (args.Length != 0)
            {
                Console.WriteLine("\n----------------------------------------------------");
                for (int i = 0; i < args.Length; i++)
                {
                    Console.Write($"{args[i]} ");
                }

                Console.WriteLine("\n----------------------------------------------------");

                Console.Write($"\nДобавить запись? Y/N");

                ConsoleKey consoleKey = Console.ReadKey(true).Key;

                if (consoleKey == ConsoleKey.Y)
                {
                    return true;
                }
            }
            return false;
        }

        protected string RequestToEnter(string request)
        {
            Console.Write($"\n{request} >");
            Console.CursorVisible = true;
            string? text = Console.ReadLine();
            Console.CursorVisible = false;
            if (text == null || text == "")
            {
                throw new Exception("Вы ничего не ввели");
            }
            return text;
        }

        internal abstract void Update(ConsoleKeyInfo key);
        internal abstract void RemoveFromList(ConsoleKeyInfo key);
        internal abstract void AddToList(ConsoleKeyInfo key);
        internal abstract void ShowAllDrivers(ConsoleKeyInfo key);
    }
}

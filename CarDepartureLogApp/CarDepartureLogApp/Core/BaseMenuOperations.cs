using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDepartureLogApp.Core
{
    internal abstract class BaseMenuOperations
    {
        protected virtual void ShowOperationInfo(string text)
        {
            Console.WriteLine(text);

            Console.WriteLine("====================================================");
        }

        protected virtual bool RequestToAdd(params string[] args)
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

        protected virtual string RequestToEnter(string request)
        {
            string? text;

            while (true)
            {
                Console.Write($"\n{request} >");

                Console.CursorVisible = true;

                text = Console.ReadLine();

                Console.CursorVisible = false;

                if (text == null || text.Trim() == "")
                {
                    Console.WriteLine("Вы ничего не ввели. Повторите ввод");

                    PressAKey();

                    continue;
                }
                break;
            }
                return text;
        }

        internal virtual void PressAKey()
        {
            Console.WriteLine("Для продолжения нажмите любую клавишу...");

            Console.ReadKey(true);
        }

        internal abstract void Update(ConsoleKeyInfo key);
        internal abstract void RemoveFromList(ConsoleKeyInfo key);
        internal abstract void AddToList(ConsoleKeyInfo key);
        internal abstract void ShowAll(ConsoleKeyInfo key);
    }
}

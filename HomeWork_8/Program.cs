using System;

namespace CombinedProject
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Выберите вариант:\n");
                Console.ResetColor();

                Console.WriteLine("1. Список случайных чисел");
                Console.WriteLine("2. Телефонная книга");
                Console.WriteLine("3. Проверка повторов");
                Console.WriteLine("4. Записная книжка");
                Console.WriteLine("0. Выход");

                string input = Console.ReadLine();

                if (int.TryParse(input, out int operation))
                {
                    switch (operation)
                    {
                        case 1:
                            RandomNumberList.Run();
                            break;
                        case 2:
                            PhoneBook.Run();
                            break;
                        case 3:
                            NumberChecker.Run();
                            break;
                        case 4:
                            ContactSaver.Run();
                            break;
                        case 0:
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Выход. ");
                            Console.ResetColor();
                            Environment.Exit(0);
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nНеккоректный номер операции. Попробуйте снова.\n");
                            Console.ResetColor();
                            break;
                    }
                }

                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nВведите корректное числовое значение для номера операции.\n");
                    Console.ResetColor();
                }
            }
        }
    }
}
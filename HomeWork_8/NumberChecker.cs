using System;
using System.Collections.Generic;

namespace CombinedProject
{
    public static class NumberChecker
    {
        public static void Run()
        {
            HashSet<int> numbers = new HashSet<int>();
            
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Введите число (или напишите «выход», чтобы закончить): ");
                Console.ResetColor();

                string input = Console.ReadLine();
                
                if (input.ToLower() == "выход")
                    break;

                if (int.TryParse(input, out int number))
                {
                    if (numbers.Add(number))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Число успешно сохранено.");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Чило уже введено.");
                        Console.ResetColor();
                    }
                }
                else
                {
                    Console.WriteLine("Неверный Ввод. Пожалуйста, введите корректное число.");
                }
            }
        }
    }
}

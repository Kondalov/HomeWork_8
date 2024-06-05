using System;
using System.Collections.Generic;

namespace CombinedProject
{
    public static class RandomNumberList
    {
        public static void Run()
        {
            List<int> numbers = GenerateRandomNumbers(100, 0, 100);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Исходный список:");
            Console.ResetColor();

            PrintListAsTable(numbers);

            RemoveNumbersInRange(numbers, 25, 50);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Измененный список:");
            Console.ResetColor();

            PrintListAsTable(numbers);
        }

        /// <summary>
        /// Генерация случайных чисел
        /// </summary>
        /// <param name="count"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        static List<int> GenerateRandomNumbers(int count, int min, int max)
        {
            Random random = new Random();

            List<int> numbers = new List<int>();

            for (int i = 0; i < count; i++)
            {
                numbers.Add(random.Next(min, max + 1));
            }
            return numbers;
        }

        static void RemoveNumbersInRange(List<int> numbers, int min, int max)
        {
            numbers.RemoveAll(x => x > min && x < max);
        }

        static void PrintListAsTable(List<int> numbers)
        {
            const int itemsPerRow = 10;

            for (int i = 0; i < numbers.Count; i++)
            {
                if (i % itemsPerRow == 0 && i != 0)
                {
                    Console.WriteLine();
                }

                Console.Write($"{numbers[i],3} ");
            }

            Console.WriteLine();
        }
    }
}

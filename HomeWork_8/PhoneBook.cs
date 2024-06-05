using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CombinedProject
{
    public static class PhoneBook
    {
        public static void Run()
        {
            Dictionary<string, string> phoneBook = new Dictionary<string, string>();

            FillPhoneBook(phoneBook);

            PrintPhoneBookAsTable(phoneBook);

            SearchOwnerByPhone(phoneBook);
        }

        static void FillPhoneBook(Dictionary<string, string> phoneBook)
        {
            while (true)
            {
                Console.Write("Введите номер телефона (или нажмите Enter, чтобы завершить): ");
                
                string phoneNumber = Console.ReadLine();

                if (string.IsNullOrEmpty(phoneNumber))
                    break;

                if (!IsValidPhoneNumber(phoneNumber))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Неверный формат номера телефона. Попробуйте снова.");
                    Console.ResetColor();
                    continue;
                }

                Console.Write("Введите имя владельца: ");
                
                string ownerName = Console.ReadLine();

                if (!IsValidName(ownerName))
                {
                    Console.WriteLine("Имя владельца не может быть пустым и должно содержать только буквы.");
                    continue;
                }

                phoneBook[phoneNumber] = ownerName;
            }
        }

        static bool IsValidPhoneNumber(string phoneNumber)
        {
            //return Regex.IsMatch(phoneNumber, @"^\+?\d+$");
            return phoneNumber.All(char.IsDigit) && phoneNumber.Length == 10;
        }

        static bool IsValidName(string name)
        {
            return !string.IsNullOrEmpty(name) && name.All(char.IsLetter);
        }

        static void PrintPhoneBookAsTable(Dictionary<string, string> phoneBook)
        {
            Console.WriteLine("\nТелефонная книга: ");

            Console.WriteLine("{0,-20} {1}", "Номер телефона", "Владелец");
            
            Console.WriteLine(new string('-', 30));

            foreach (var entry in phoneBook)
            {
                Console.WriteLine("{0,-20} {1}", entry.Key, entry.Value);
            }
            Console.WriteLine();
        }

        static void SearchOwnerByPhone(Dictionary<string, string> phoneBook)
        {
            Console.Write("Введите номер телефона для поиска: ");

            string phoneNumber = Console.ReadLine();

            if (phoneBook.TryGetValue(phoneNumber, out string ownerName))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Владелец: " + ownerName);
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Владелец не найден.");
                Console.ResetColor();
            }
        }
    }
}

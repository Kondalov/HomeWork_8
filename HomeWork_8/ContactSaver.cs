using System;
using System.Linq;
using System.Xml.Linq;

namespace CombinedProject
{
    public static class ContactSaver
    {
        public static void Run()
        {
            string name = PromptForInput("Введите полное имя: ", IsValidName, "Имя должно содержать только буквы и не должно быть пустым.");
            
            string street = PromptForInput("Введите название улицы: ", IsValidName, "Название улицы должно содержать только буквы и не может быть пустым.");
            
            string houseNumber = PromptForInput("Введите номер дома: ", IsValidNumber, "Номер дома должен быть числом.");
            
            string flatNumber = PromptForInput("Введите номер квартиры: ", IsValidNumber, "Номер квартиры должно быть числом.");
            
            string mobilePhone = PromptForInput("Введите мобильный телефон: ", IsValidPhoneNumber, "Мобильный телефон должен быть числом и содержать 10 символов.");
            
            string flatPhone = PromptForInput("Введите рабочий телефон: ", IsValidPhoneNumber, "Рабочий телефон должен быть числом и содержать 10 символов.");

            XElement personElement = new XElement("Person",
                    new XAttribute("name", name),
                    new XElement("Address",
                    new XElement("Street", street),
                    new XElement("HouseNumber", houseNumber),
                    new XElement("FlatNumber", flatNumber)
                ),
                    new XElement("Phones",
                    new XElement("MobilePhone", mobilePhone),
                    new XElement("FlatPhone", flatPhone)
                )
            );

            personElement.Save("contact.xml");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Контакт сохранен в contact.xml\n");
            Console.ResetColor();
        }

        static string PromptForInput(string prompt, Func<string, bool> validationFunc, string errorMessage)
        {
            while (true)
            {
                Console.Write(prompt);

                string input = Console.ReadLine();

                if (validationFunc(input))
                {
                    return input;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ошибка => " + errorMessage);
                    Console.ResetColor();
                }
            }
        }

        static bool IsValidName(string name)
        {
            return !string.IsNullOrEmpty(name) && name.All(char.IsLetter);
        }

        static bool IsValidNumber(string number)
        {
            return !string.IsNullOrEmpty(number) && number.All(char.IsDigit);
        }

        static bool IsValidPhoneNumber(string phoneNumber)
        {
            return !string.IsNullOrEmpty(phoneNumber) && phoneNumber.All(char.IsDigit) && phoneNumber.Length == 10;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ex27
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CommandAddDossier = "добавить";
            const string CommandWriteAllDossier = "вывести";
            const string CommandDeleteDossier = "удалить";
            const string CommandSearchByLastName = "найти";
            const string CommandExit = "выход";

            string[] namesOfWorkers = new string[0];
            string[] postsOfWorkers = new string[0];
            bool isOpen = true;

            while (isOpen)
            {
                Console.Write($"1 - {CommandAddDossier}\n2 - {CommandWriteAllDossier}\n" +
                    $"3 - {CommandDeleteDossier}\n4 - {CommandSearchByLastName}\n" +
                    $"5 - {CommandExit}\nКакую команду вы хотите выполнить? ");
                string command = Console.ReadLine();
                Console.Clear();

                switch (command.ToLower())
                {
                    case CommandAddDossier:
                        AddDossier(ref namesOfWorkers, ref postsOfWorkers);
                        break;

                    case CommandWriteAllDossier:
                        WriteAllDossier(ref namesOfWorkers, ref postsOfWorkers);
                        break;

                    case CommandDeleteDossier:
                        DeleteDossier(ref namesOfWorkers, ref postsOfWorkers);
                        break;

                    case CommandSearchByLastName:
                        SearchByLastName(namesOfWorkers);
                        break;

                    case CommandExit:
                        isOpen = false;
                        break;

                    default:
                        Console.Write("Неверная команда. Попробуйте еще раз...");
                        break;
                }

                Console.ReadKey();
                Console.Clear();
            }
        }
        static void AddDossier(ref string[] names, ref string[] posts)
        {
            Console.Write("Введите вашу фамилию: ");
            string name = Console.ReadLine();
            Console.Write("Введите вашу должность: ");
            string post = Console.ReadLine();

            names = IncreaseArray(names, name);
            posts = IncreaseArray(posts, post);
            
        }

        static string[] IncreaseArray(string[] array, string enteredValue)
        {
            string[] tempArray = new string[array.Length + 1];

            for (int i = 0; i < array.Length; i++)
            {
                tempArray[i] = array[i];
            }

            tempArray[tempArray.Length - 1] = enteredValue.ToLower();
            array = tempArray;
            return array;
        }

        static void WriteAllDossier(ref string[] names, ref string[] posts)
        {
            if (IsEmpty(names))
            {

            }
            else
            {
                Console.WriteLine("Список всех досье:");

                for (int i = 0; i < names.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {names[i].ToUpper()} - {posts[i].ToUpper()}");
                }
            }
        }

        static void DeleteDossier(ref string[] names, ref string[] posts)
        {
            Console.SetCursorPosition(0, 8);
            WriteAllDossier(ref names, ref posts);
            Console.SetCursorPosition(0, 0);
            Console.Write("Введите номер досье, которое хотите удалить: ");
            int deletedNumberOfDossier = Convert.ToInt32(Console.ReadLine());
            string tempElement;
            string[] tempList = new string[names.Length - 1];

            if (deletedNumberOfDossier < 0 || deletedNumberOfDossier > names.Length)
            {
                Console.Write("Досье под таким номером не существует...");
            }
            else
            {
                for (int i = deletedNumberOfDossier - 1; i < names.Length - 1; i++)
                {
                    tempElement = names[i];
                    names[i] = names[i + 1];
                    names[i + 1] = tempElement;
                }

                for (int i = 0; i < names.Length - 1; i++)
                {
                    tempList[i] = names[i];
                }

                names = tempList;
                Console.Write($"Удаление досье под номером {deletedNumberOfDossier} прошло успешно...");
            }
        }

        static void SearchByLastName(string[] names)
        {
            if (IsEmpty(names))
            {

            }
            else
            {
                Console.Write("Введите искомую фамилию: ");
                string lastName = Console.ReadLine();
                bool isFound = true;

                for (int i = 0; i < names.Length; i++)
                {
                    if (lastName.ToLower() == names[i])
                    {
                        isFound = false;
                        Console.WriteLine($"{i + 1}. {names[i].ToUpper()}");
                    }
                }

                if (isFound)
                {
                    Console.Write("Фамилия не найдена...");
                }
            }

        }

        static bool IsEmpty(string[] names)
        {
            if (names.Length < 1)
            {
                Console.Write("Список досье пуст...");
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

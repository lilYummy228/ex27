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
                        Console.Write("Введите вашу фамилию: ");
                        string enteredName = Console.ReadLine();
                        GetDossier(ref namesOfWorkers, enteredName);
                        Console.Write("Введите вашу должность: ");
                        string enteredPost = Console.ReadLine();
                        GetDossier(ref postsOfWorkers, enteredPost);
                        Console.WriteLine($"{enteredName} на должность {enteredPost} успешно добавлен.");
                        break;

                    case CommandWriteAllDossier:
                        if (SetMessageAboutVoid(ref namesOfWorkers)) break;

                        WriteAllDossier(ref namesOfWorkers, ref postsOfWorkers);
                        break;

                    case CommandDeleteDossier:
                        if (SetMessageAboutVoid(ref namesOfWorkers)) break;

                        Console.SetCursorPosition(0, 8);
                        WriteAllDossier(ref namesOfWorkers, ref postsOfWorkers);
                        Console.SetCursorPosition(0, 0);
                        DeleteDossier(ref namesOfWorkers);
                        break;

                    case CommandSearchByLastName:
                        if (SetMessageAboutVoid(ref namesOfWorkers)) break;

                        SearchByLastName(ref namesOfWorkers, ref postsOfWorkers);
                        break;

                    case CommandExit:
                        isOpen = false;
                        Console.Write("Вы вышли из программы...");
                        break;

                    default:
                        Console.Write("Неверная команда. Попробуйте еще раз...");
                        break;
                }

                Console.ReadKey();
                Console.Clear();
            }
        }

        static void GetDossier(ref string[] tempDossier, string enteredValue)
        {
            string[] tempArray = new string[tempDossier.Length + 1];

            for (int i = 0; i < tempDossier.Length; i++)
            {
                tempArray[i] = tempDossier[i];
            }

            tempArray[tempArray.Length - 1] = enteredValue;
            tempDossier = tempArray;
        }

        static void WriteAllDossier(ref string[] names, ref string[] posts)
        {
            Console.WriteLine("Список досье:");

            for (int i = 0; i < names.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {names[i]} - {posts[i]}");
            }
        }

        static void DeleteDossier(ref string[] tempDossier)
        {
            Console.Write("Введите номер досье, которое хотите удалить: ");
            int deletedNumberOfDossier = Convert.ToInt32(Console.ReadLine());
            string tempElement;
            string[] tempList = new string[tempDossier.Length - 1];

            if (deletedNumberOfDossier < 0 || deletedNumberOfDossier > tempDossier.Length)
            {
                Console.Write("Досье под таким номером не существует...");
            }
            else
            {
                for (int i = deletedNumberOfDossier - 1; i < tempDossier.Length - 1; i++)
                {
                    tempElement = tempDossier[i];
                    tempDossier[i] = tempDossier[i + 1];
                    tempDossier[i + 1] = tempElement;
                }

                for (int i = 0; i < tempDossier.Length - 1; i++)
                {
                    tempList[i] = tempDossier[i];
                }

                tempDossier = tempList;
                Console.Write($"Удаление досье под номером {deletedNumberOfDossier} прошло успешно...");
            }
        }

        static void SearchByLastName(ref string[] names, ref string[] posts)
        {
            Console.Write("Введите искомую фамилию: ");
            string lastName = Console.ReadLine();
            bool isFound = true;

            for (int i = 0; i < names.Length; i++)
            {
                if (lastName == names[i])
                {
                    isFound = false;
                    Console.WriteLine($"{i + 1}. {names[i]} - {posts[i]}");
                }
            }

            if (isFound)
            {
                Console.Write("Фамилия не найдена...");
            }
        }

        static bool SetMessageAboutVoid(ref string[] names)
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

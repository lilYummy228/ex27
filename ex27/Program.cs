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
            string lastName = "фамилию";
            string post = "должность";
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
                        GetDossier(ref namesOfWorkers, lastName);
                        GetDossier(ref postsOfWorkers, post);
                        break;

                    case CommandWriteAllDossier:
                        if (SetMessageAboutVoid(namesOfWorkers))
                        {
                            break;
                        }

                        WriteAllDossier(ref namesOfWorkers, ref postsOfWorkers);
                        break;

                    case CommandDeleteDossier:
                        if (SetMessageAboutVoid(namesOfWorkers))
                        {
                            break;
                        }

                        WriteAllDossier(ref namesOfWorkers, ref postsOfWorkers);
                        DeleteDossier(ref namesOfWorkers);
                        break;

                    case CommandSearchByLastName:
                        if (SetMessageAboutVoid(namesOfWorkers))
                        {
                            break;
                        }

                        SearchByLastName(namesOfWorkers);
                        break;

                    case CommandExit:
                        ExitTheProgram(isOpen);
                        break;

                    default:
                        Console.Write("Неверная команда. Попробуйте еще раз...");
                        break;
                }

                Console.ReadKey();
                Console.Clear();
            }
        }

        static void GetDossier(ref string[] tempDossier, string input)
        {
            Console.Write($"Введите вашу {input}: ");
            string enteredValue = Console.ReadLine();
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
            Console.SetCursorPosition(0, 8);
            Console.WriteLine("Список всех досье:");

            for (int i = 0; i < names.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {names[i]} - {posts[i]}");
            }
        }

        static void DeleteDossier(ref string[] tempDossier)
        {
            Console.SetCursorPosition(0, 0);
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

        static string[] SearchByLastName(string[] names)
        {
            Console.Write("Введите искомую фамилию: ");
            string lastName = Console.ReadLine();
            bool isFound = true;

            for (int i = 0; i < names.Length; i++)
            {
                if (lastName == names[i])
                {
                    isFound = false;
                    Console.WriteLine($"{i + 1}. {names[i]}");
                }
            }

            if (isFound)
            {
                Console.Write("Фамилия не найдена...");
            }

            return names;
        }

        static bool SetMessageAboutVoid(string[] names)
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

        static bool ExitTheProgram(bool isOpen)
        {
            Console.Write("Вы вышли из программы...");
            return false;
        }
    }
}

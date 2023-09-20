using System;

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
                        WriteAllDossier(namesOfWorkers, postsOfWorkers);
                        break;

                    case CommandDeleteDossier:
                        DeleteDossier(ref namesOfWorkers, ref postsOfWorkers);
                        break;

                    case CommandSearchByLastName:
                        SearchByLastName(namesOfWorkers, postsOfWorkers);
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
            Console.Write("Введите ваши ФИО: ");
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

        static void WriteAllDossier(string[] names, string[] posts)
        {
            if (names.Length < 1)
            {
                Console.Write("Список досье пуст...");
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
            WriteAllDossier(names, posts);
            Console.SetCursorPosition(0, 0);
            Console.Write("Введите номер досье, которое хотите удалить: ");
            int deletedDossier = Convert.ToInt32(Console.ReadLine());

            if (deletedDossier < 0 || deletedDossier > names.Length)
            {
                Console.Write("Досье под таким номером не существует...");
            }
            else
            {
                names = DecreaseArray(names, deletedDossier);
                posts = DecreaseArray(posts, deletedDossier);
                Console.Write($"Удаление досье под номером {deletedDossier} прошло успешно...");
            }
        }

        static string[] DecreaseArray(string[] array, int deletedNumber)
        {
            string[] tempArray = new string[array.Length - 1];
            int index = deletedNumber - 1;

            for (int i = 0; i < index; i++)
            {
                tempArray[i] = array[i];
            }

            for (int i = index; i < array.Length - 1; i++)
            {
                tempArray[i] = array[i + 1];
            }

            array = tempArray;
            return array;
        }

        static void SearchByLastName(string[] names, string[] posts)
        {
            if (names.Length < 1)
            {
                Console.Write("Список досье пуст...");
            }
            else
            {
                Console.Write("Введите искомую фамилию: ");
                string lastName = Console.ReadLine();
                bool isFound = false;

                for (int i = 0; i < names.Length; i++)
                {
                    char space = ' ';
                    string[] split = names[i].Split(space);

                    if (split[0].ToLower() == lastName.ToLower())
                    {
                        isFound = true;
                        Console.WriteLine($"{i + 1}. {names[i].ToUpper()} - {posts[i].ToUpper()}");
                    }
                }

                if (isFound == false)
                {
                    Console.Write($"Фамилия '{lastName}' не найдена...");
                }
            }
        }
    }
}


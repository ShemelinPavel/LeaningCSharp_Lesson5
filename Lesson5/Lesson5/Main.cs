using System;
using LeaningCSharp_ClassLibrary;

namespace Lesson5
{
    class Lesson5
    {
        static void Main(string[] args)
        {
            //задачи собраны в отдельный класс
            Tasks tasks = new Tasks();

            MainMenu menu = new MainMenu(new string[] { "Создание файла из символов", "Проверка пароля", "*", "Проверка строки", "Задача ЕГЭ" });

            menu.Show();

            while (true)
            {
                ConsoleKeyInfo userChooseKey = Console.ReadKey(true);
                bool resulTaskCall = menu.GotoTask(tasks, userChooseKey.Key);

                menu.Show();

            }
        }
    }
}
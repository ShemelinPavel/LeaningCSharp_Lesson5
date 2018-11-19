using System;
using LeaningCSharp_ClassLibrary;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Lesson5
{
    class Lesson5
    {

        static void Main(string[] args)
        {

            Tasks tasks = new Tasks();

            MainMenu menu = new MainMenu(new string[] { "задача1", "задача2" });

            menu.Show();

            while (true)
            {
                ConsoleKeyInfo userChooseKey = Console.ReadKey(true);
                menu.GotoTask(tasks, userChooseKey.Key);

            }

        }
    }
}
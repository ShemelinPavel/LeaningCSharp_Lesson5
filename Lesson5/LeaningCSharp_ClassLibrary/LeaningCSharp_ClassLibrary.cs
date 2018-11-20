using System;
using System.Collections.Generic;
using System.Reflection;

namespace LeaningCSharp_ClassLibrary
{
    public static class ServingStaticClass
    {
        /// <summary>
        /// пауза в консоли
        /// </summary>
        public static void Pause()
        {
            Console.ReadKey();
        }

        /// <summary>
        /// пауза в консоли c текстовым сообщением
        /// </summary>
        /// <param name="message">текст сообщения</param>
        public static void Pause(string message)
        {
            Console.WriteLine((message == "") ? "Нажмите любую клавишу." : message);
            Console.ReadKey();
        }

        /// <summary>
        /// вывод строки сообщения в консоль
        /// </summary>
        /// <param name="Text">текст сообщения</param>
        /// <param name="EndOfString"> true - добавляет в конец возврат каретки (по умолчанию)</param>
        public static void Print(string Text, bool EndOfString = true)
        {
            if (EndOfString)
            {
                Console.WriteLine(Text);
            }
            else
            {
                Console.Write(Text);
            }
        }

        /// <summary>
        /// вывод строки сообщения в консоль
        /// </summary>
        /// <param name="Text">текст сообщения</param>
        /// <param name="arg"> массив параметров</param>
        public static void Print(string Text, params object[] arg)
        {
            Console.WriteLine(Text, arg);
        }

        /// <summary>
        /// вывести в консоль текст вопроса и получить ответ
        /// </summary>
        /// <param name="questionText"> текст вопроса в формате "Введите " + questionText + " :"</param>
        /// <returns>возвращает введенный в консоли текст ответа</returns>
        public static string MakeQuestion(string questionText)
        {
            Print("Введите " + questionText + " : ", false);

            return Console.ReadLine();
        }

        /// <summary>
        /// очистка экрана
        /// </summary>
        public static void ClearScreen()
        {
            Console.Clear();
        }

        /// <summary>
        /// очистить экран консоли и вывести сообщение (приветственное)
        /// </summary>
        /// <param name="textMessage"></param>
        public static void PrintTaskWelcomeScreen(string textMessage = "")
        {
            ClearScreen();
            Print(textMessage);
        }

    }

    public class MainMenu
    {

        private string welcometext;
        private Dictionary<ConsoleKey, string[]> menuitems;

        /// <summary>
        /// главное меню
        /// </summary>
        /// <param name="items">пункты меню</param>
        /// <param name="welcome">приветственная строка</param>
        public MainMenu(string[] items, string welcome = "")
        {
            if (welcome == "")
            {
                WelcomeText = "Добрый день, пользователь!\nВыберите чем бы Вы хотели заняться:\nМеню на сегодня:\n";
            }

            CreateMenuItems(items);
        }

        /// <summary>
        /// приветственная строка меню
        /// </summary>
        public string WelcomeText
        {
            get { return this.welcometext; }
            set { this.welcometext = value; }
        }

        private void CreateMenuItems(string[] items)
        {
            if (items.Length > 9) throw new ArgumentException("Пунктов меню не может быть больше 9-ти !");

            this.menuitems = new Dictionary<ConsoleKey, string[]>();

            ushort counter = 0;

            foreach (var item in items)
            {
                counter++;
                switch (counter)
                {
                    //если item == "*" - это заглушка для пустого пункта
                    //описание массива Value: преставление пункта меню / вызываемый метод / видимость при выводе пунктов меню в консоль (чтобы не дублировалось)

                    case 1:
                        this.menuitems.Add(ConsoleKey.D1, new string[] { "1 - " + item, "Task1", (item == "*") ? "false" : "true" });
                        this.menuitems.Add(ConsoleKey.NumPad1, new string[] { "1 - " + item, "Task1", "false" });
                        break;

                    case 2:
                        this.menuitems.Add(ConsoleKey.D2, new string[] { "2 - " + item, "Task2", (item == "*") ? "false" : "true" });
                        this.menuitems.Add(ConsoleKey.NumPad2, new string[] { "2 - " + item, "Task2", "false" });
                        break;

                    case 3:
                        this.menuitems.Add(ConsoleKey.D3, new string[] { "3 - " + item, "Task3", (item == "*") ? "false" : "true" });
                        this.menuitems.Add(ConsoleKey.NumPad3, new string[] { "3 - " + item, "Task3", "false" });
                        break;

                    case 4:
                        this.menuitems.Add(ConsoleKey.D4, new string[] { "4 - " + item, "Task4", (item == "*") ? "false" : "true" });
                        this.menuitems.Add(ConsoleKey.NumPad4, new string[] { "4 - " + item, "Task4", "false" });
                        break;

                    case 5:
                        this.menuitems.Add(ConsoleKey.D5, new string[] { "5 - " + item, "Task5", (item == "*") ? "false" : "true" });
                        this.menuitems.Add(ConsoleKey.NumPad5, new string[] { "5 - " + item, "Task5", "false" });
                        break;

                    case 6:
                        this.menuitems.Add(ConsoleKey.D6, new string[] { "6 - " + item, "Task6", (item == "*") ? "false" : "true" });
                        this.menuitems.Add(ConsoleKey.NumPad6, new string[] { "6 - " + item, "Task6", "false" });
                        break;

                    case 7:
                        this.menuitems.Add(ConsoleKey.D7, new string[] { "7 - " + item, "Task7", (item == "*") ? "false" : "true" });
                        this.menuitems.Add(ConsoleKey.NumPad7, new string[] { "7 - " + item, "Task7", "false" });
                        break;

                    case 8:
                        this.menuitems.Add(ConsoleKey.D8, new string[] { "8 - " + item, "Task8", (item == "*") ? "false" : "true" });
                        this.menuitems.Add(ConsoleKey.NumPad8, new string[] { "8 - " + item, "Task8", "false" });
                        break;

                    case 9:
                        this.menuitems.Add(ConsoleKey.D9, new string[] { "9 - " + item, "Task9", (item == "*") ? "false" : "true" });
                        this.menuitems.Add(ConsoleKey.NumPad9, new string[] { "9 - " + item, "Task9", "false" });
                        break;
                }
            }
            //обязательный пункт
            this.menuitems.Add(ConsoleKey.D0, new string[] { "0 - Выход из программы", "Exit", "true" });
            this.menuitems.Add(ConsoleKey.NumPad0, new string[] { "0 - Выход из программы", "Exit", "false" });
        }

        public Dictionary<ConsoleKey, string[]> MenuItems
        {
            get
            {
                return this.menuitems;
            }
        }

        public bool GotoTask(Object obj, ConsoleKey pressedKey)
        {
            try
            {
                this.menuitems.TryGetValue(pressedKey, out string[] menuItem);

                MethodInfo methodInfo = obj.GetType().GetMethod(menuItem[1]);

                if (methodInfo != null)
                {
                    try
                    {
                        methodInfo.Invoke(obj, null);
                        return true;
                    }
                    catch
                    {
                        //ServingStaticClass.Print($"\nОшибка вызова метода: {menuItem[1]}");
                        return false;
                    }
                }
                else
                {
                    //ServingStaticClass.Print($"\nМетод: {menuItem[1]} не обнаружен!");
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public void Show()
        {
            ServingStaticClass.ClearScreen();
            ServingStaticClass.Print(this.welcometext);

            foreach (var item in this.menuitems)
            {
                if (bool.Parse(item.Value[2])) ServingStaticClass.Print(item.Value[0]);
            }
        }
    }
}
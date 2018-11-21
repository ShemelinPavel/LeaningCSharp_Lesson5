/*

Shemelin Pavel

4. Для двух строк написать метод, определяющий, является ли одна строка перестановкой другой.
Например:
badc являются перестановкой abcd.

*/

using System;
using System.Linq;
using LeaningCSharp_ClassLibrary;

namespace Lesson5
{
    public partial class Tasks
    {

        public enum StringEquelsMethod { CharArray, LINQ}

        private static bool ShuffleStringsEquels(string a, string b, StringEquelsMethod method = StringEquelsMethod.CharArray)
        {
            if (a.Length != b.Length) return false;

            if(method == StringEquelsMethod.CharArray)
            {
                //проверка через массив char
                foreach (Char item in a)
                {
                    int index = b.IndexOf(item);
                    if (index >= 0) b = b.Remove(index, 1);
                }

                if(b.Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                //проверка через LINQ
                return a.OrderBy(i => i).SequenceEqual(b.OrderBy(i => i));
            }
        }

        public static void Task4()
        {
            ServingStaticClass.PrintTaskWelcomeScreen("Вы выбрали задачу проверки является ли одна строка перестановкой другой\nДавайте начнем:\n");

            string userStringA = ServingStaticClass.MakeQuestion("первую строку");
            string userStringB = ServingStaticClass.MakeQuestion("вторую строку");

            //проверка через массив char
            ServingStaticClass.Print("\nПроверка через массив char\n");
            bool result = ShuffleStringsEquels(userStringA, userStringB);
            if(result)
            {
                ServingStaticClass.Print("\nСтроки одинаковы.\n");
            }
            else
            {
                ServingStaticClass.Print("\nСтроки различны.\n");
            }

            //проверка через массив LINQ
            ServingStaticClass.Print("\nПроверка через массив char\n");
            bool result1 = ShuffleStringsEquels(userStringA, userStringB, StringEquelsMethod.LINQ);
            if (result1)
            {
                ServingStaticClass.Print("\nСтроки одинаковы.\n");
            }
            else
            {
                ServingStaticClass.Print("\nСтроки различны.\n");
            }

            ServingStaticClass.Pause("");
        }
    }
}
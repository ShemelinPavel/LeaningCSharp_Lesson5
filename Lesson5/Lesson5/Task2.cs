/*

Shemelin Pavel

2. Создать программу, которая будет проверять корректность ввода логина.Корректным логином будет строка от 2 до 10 символов, содержащая только буквы латинского алфавита или цифры,
при этом цифра не может быть первой:
а) без использования регулярных выражений;
б) ** с использованием регулярных выражений.

*/

using System;
using System.Text.RegularExpressions;
using LeaningCSharp_ClassLibrary;

namespace Lesson5
{
    public partial class Tasks
    {
        public enum RegExpUse { UseRegExp, NotUseRegExp };

        private static bool PasswordVerification(string pass, out string errorMessage, RegExpUse regExpFlag = RegExpUse.NotUseRegExp)
        {

            errorMessage = "";

            if (pass.Length == 0)
            {
                errorMessage = "Пароль не может быть нулевой длины!";
                return false;
            }

            if (regExpFlag == RegExpUse.NotUseRegExp)
            {

                for (int i = 0; i < pass.Length; i++)
                {
                    char curChar = pass[i];

                    if (i == 0 && (curChar >= '0' && curChar <= '9'))
                    {
                        errorMessage = "Пароль не может начинаться с цифры";
                        return false;
                    }
                    else if (!((curChar >= 'a' && curChar <= 'z') || curChar >= 'A' && curChar <= 'Z' || curChar >= '0' && curChar <= '9'))
                    {
                        errorMessage = $"Символ № {i + 1} [{curChar}] не является допустимым для пароля (a-z/A-Z/0-9)";
                        return false;
                    }
                }
                return true;
            }
            else
            {
                Regex pattern = new Regex("^[a-zA-Z][a-zA-Z0-9]+$");

                return pattern.IsMatch(pass);
            }
        }

        public static void Task2()
        {

            ServingStaticClass.PrintTaskWelcomeScreen("Вы выбрали задачу проверки пароля\nДавайте начнем:\n");

            string userPassword = ServingStaticClass.MakeQuestion("пароль");

            // без регулярок
            ServingStaticClass.Print("\nПроверка пароля без импользования механизма регулярных выражений:");

            bool verificationResult = PasswordVerification(userPassword, out string errorMessage);

            if(verificationResult)
            {
                ServingStaticClass.Print("Проверка пароля успешна!");
            }
            else
            {
                ServingStaticClass.Print($"Предложенный пароль не подходит.\nОписание ошибки: {errorMessage}");
            }

            //регулярки
            ServingStaticClass.Print("\nПроверка пароля с импользованием механизма регулярных выражений:\n");

            bool verificationResult1 = PasswordVerification(userPassword, out string errorMessage1, RegExpUse.UseRegExp);

            if (verificationResult1)
            {
                ServingStaticClass.Print("Проверка пароля успешна!\n");
            }
            else
            {
                ServingStaticClass.Print($"Предложенный пароль не подходит.\n");
            }
            
            ServingStaticClass.Pause("");
        }
    }
}
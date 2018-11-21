/*

Shemelin Pavel

1. Написать статический метод void CreateCharsFile(string filename, int start, int finish), который
создает файл содержащий символы из заданного диапазона (от start до finish). Обработать корректно
исключения связанные с невозможностью создания файла.
*/

using System;
using System.IO;
using LeaningCSharp_ClassLibrary;

namespace Lesson5
{
    public partial class Tasks
    {
       private static bool CreateCharsFile(string fileName, uint beginCode, uint finishCode)
        {
            uint bC = beginCode;
            uint fC = finishCode;

            if (beginCode > finishCode)
            {
                bC = finishCode;
                fC = beginCode;
            }

            StreamWriter stream = null;
            try
            {
                stream = new StreamWriter(fileName);
                for (uint currentCode = bC; currentCode <= fC; currentCode++)
                {
                    stream.WriteLine(Convert.ToChar(currentCode));
                }

                stream.Close();

                return true;
            }
            catch (Exception ex)
            {
                ServingStaticClass.Print($"\nЧто-то пошло не так: {ex.Message}");
                return false;
            }
        }

        public static void Task1()
        {

            ServingStaticClass.PrintTaskWelcomeScreen("Вы выбрали задачу создания файла символов\nДавайте начнем:\n");

            string path = ServingStaticClass.MakeQuestion("имя файла");
            string charStartCode = ServingStaticClass.MakeQuestion("код начального символа");
            string charFihishCode = ServingStaticClass.MakeQuestion("код конечного символа");

            try
            {
                bool result = CreateCharsFile(path, UInt32.Parse(charStartCode), UInt32.Parse(charFihishCode));
                if (result)
                {
                    ServingStaticClass.Pause("\nЗапись файла завершена.\nНажмите любую клавишу.");
                }
                else
                {
                    ServingStaticClass.Pause("\nОшибка выполнения задачи.\nДля возврата в главное меню нажмите любую клавишу.");
                }

            }
            catch (Exception ex)
            {
                ServingStaticClass.Print($"Что-то пошло не так: {ex.Message}");
                ServingStaticClass.Pause("\nОшибка выполнения задачи.\nДля возврата в главное меню нажмите любую клавишу.");
            }
        }
    }
}
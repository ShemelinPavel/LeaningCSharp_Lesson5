/*

Shemelin Pavel

Задача ЕГЭ.
На вход программе подаются сведения о сдаче экзаменов учениками 9-х классов некоторой средней школы.
В первой строке сообщается количество учеников N, которое не меньше 10, но не превосходит 100, каждая из следующих N строк имеет следующий формат:
<Фамилия> <Имя> <оценки>,
где <Фамилия> — строка, состоящая не более чем из 20 символов, <Имя> — строка, состоящая не более чем из 15 символов, <оценки> — через пробел три целых числа, соответствующие оценкам по пятибалльной системе. <Фамилия> и <Имя>, а также <Имя> и <оценки> разделены одним пробелом. Пример входной строки:
Иванов Петр 4 5 3
Требуется написать как можно более эффективную программу, которая будет выводить на экран фамилии и имена трёх худших по среднему баллу учеников. Если среди остальных есть ученики, набравшие тот же средний балл, что и один из трёх худших, следует вывести и их фамилии и имена.
 
*/

using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using LeaningCSharp_ClassLibrary;

namespace Lesson5
{
    public partial class Tasks
    {

        public class Student: IComparer
        {

            private string lastname;
            private string firstname;
            private int[] grades;

            /// <summary>
            /// студент
            /// </summary>
            /// <param name="lastN">фамилия</param>
            /// <param name="firstN">имя</param>
            /// <param name="grArr">массив с оценками</param>
            public Student(string lastN, string firstN, int[] grArr)
            {
                LastName = lastN;
                FirstName = firstN;

                Grades = grArr;

            }
            public string LastName
            {
                get { return this.lastname; }
                set { this.lastname = value; }
            }

            public string FirstName
            {
                get { return this.firstname; }
                set { this.firstname = value; }
            }

            public int[] Grades
            {
                get { return this.grades; }
                set { this.grades = value; }
            }

            /// <summary>
            /// средняя оценка
            /// </summary>
            /// <returns>значение средней оценки</returns>
            public double AverageGrade()
            {
                if (this.grades == null)
                {
                    return 0;
                }
                else
                {
                    return this.grades.Average();
                }
            }

            //реализация интерфейса IComparer
            public int Compare(object x, object y)
            {

                if((x is Student && x != null) && (y is Student && y != null))
                {
                    Student xStudent = (Student)x;
                    Student yStudent = (Student)y;

                    //реализация сравнения не совсен корректная, но мы в задаче по ключу не сортируем - сойдет пока так

                    return (string.Compare(xStudent.LastName + xStudent.FirstName, yStudent.LastName + yStudent.FirstName));
                }
                else
                {
                    throw new ArgumentException("Неверное значение аргументов функции");
                }
            }

            #region переопределяем Equals и GetHashCode для определения дублей - полные тезки, вам не повезло
            public override bool Equals(object obj)
            {
                if(obj is Student && obj != null)
                {

                    Student anotherStud = (Student)obj;

                    if (anotherStud.lastname == this.lastname && anotherStud.firstname == this.firstname)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                return false;
            }

            public override int GetHashCode()
            {
                return (this.lastname + this.firstname).GetHashCode();
            }
            #endregion переопределяем Equals и GetHashCode для определения дублей

            //переопредение представления объекта
            public override string ToString()
            {
                return $"{this.lastname} {this.firstname}";
            }
        }

        private static Student[] ReadStudentsFromFile(string filename)
        {

            string[] allStudentsTxt = null;

            try
            {
                allStudentsTxt = File.ReadAllLines(filename);
            }
            catch(Exception ex)
            {
                ServingStaticClass.Print($"\nЧто-то пошло не так: {ex.Message}");
                return null;
            }

            Student[] students = new Student[allStudentsTxt.Length];

            for (int i = 0; i < allStudentsTxt.Length; i++)
            {

                int[] arrayGrades;

                string[] currentStudentData = allStudentsTxt[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (currentStudentData.Length > 2)
                {
                    ushort counter = 0;
                    arrayGrades = new int[currentStudentData.Length - 2];
                    for (int countGrades = 2; countGrades < currentStudentData.Length; countGrades++)
                    {
                        arrayGrades[counter] = Int32.Parse(currentStudentData[countGrades]);
                        counter++;
                    }
                }
                else
                {
                    arrayGrades = new int[] { 0 };
                }
                students[i] = new Student(currentStudentData[0], currentStudentData[1], arrayGrades);
            }
            return students;
        }

        public static void Task5()
        {
            //решается на словаре и LINQ - массивами не интересно

            ServingStaticClass.PrintTaskWelcomeScreen("Вы выбрали задачу ЕГЭ\nДавайте начнем:\n");

            string path = ServingStaticClass.MakeQuestion("имя файла с оценками студентов");

            Student[] students = ReadStudentsFromFile(path);

            if (students != null)
            {
                //количество разных значений оценок которые нужно вывести
                const int countMinGrades = 3;

                Dictionary<Student, double> listStudents = new Dictionary<Student, double>();

                foreach (Student item in students)
                {
                    listStudents.Add(item, item.AverageGrade());
                }

                //первые 3 (countMinGrades) значения средней оценки
                IEnumerable<double> distinctMinGrades = listStudents.Values.ToArray().Distinct().OrderBy(i => i).Take(countMinGrades);

                foreach (KeyValuePair<Student, double> item in listStudents.OrderBy(key => key.Value))
                {
                    if (distinctMinGrades.Contains(item.Value))
                    {
                        Console.WriteLine($"{item.Key} {item.Value}");
                    }
                    else break; // список за пределами нужных значений дальше не интересует
                }
                ServingStaticClass.Pause("");
            }
            else
            {
                ServingStaticClass.Pause("\nОшибка выполнения.\nДля перехода в главное меню нажмите любую клавишу.");
            }
        }
    }
}

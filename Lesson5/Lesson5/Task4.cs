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

        //выход из программы
        public static void Exit()
        {
            Environment.Exit(0);
        }

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

            if (!File.Exists(filename))
            {
                ServingStaticClass.Print($"Файл: {filename} не существует!");
                return null;
            }

            string[] allStudentsTxt = File.ReadAllLines(filename);

            Student[] students = new Student[allStudentsTxt.Length];

            for (int i = 0; i < allStudentsTxt.Length; i++)
            {

                int[] arrayGrades;

                string[] currentStudentData = allStudentsTxt[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (currentStudentData.Length > 2)
                {
                    ushort counter = 0;
                    arrayGrades = new int[currentStudentData.Length - 2];
                    for (int countGrades = 2; countGrades < currentStudentData.Length - 1; countGrades++)
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

        public static void Task4()
        {

            string path = ServingStaticClass.MakeQuestion("имя файла с оценками студентов");

            Student[] students = ReadStudentsFromFile(path);

            if(students != null)
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
        }
    }
}

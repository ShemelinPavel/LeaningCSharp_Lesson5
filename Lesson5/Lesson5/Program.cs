using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Lesson5
{
    class Program
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

            #region реализация интерфейса IComparer
            public int Compare(object x, object y)
            {
                try
                {
                    Student xStudent = (Student)x;
                    Student yStudent = (Student)y;

                    //реализация сравнения не совсен корректная, но мы в задаче по ключу не сортируем - сойдет пока так

                    return (string.Compare(xStudent.LastName + xStudent.FirstName, yStudent.LastName + yStudent.FirstName));
                }
                catch
                {
                    throw new NotImplementedException();
                }
            }
            #endregion реализация интерфейса IComparer

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

            #region переопредение представления объекта
            public override string ToString()
            {
                return $"{this.lastname} {this.firstname}";
            }
            #endregion переопредение представления объекта
        }

        static void Main(string[] args)
        {

            //количество разных значений оценок которые нужно вывести
            const int countMinGrades = 3;

            Dictionary<Student, double> lstSt = new Dictionary<Student, double>();

            Student st1 = new Student("Иванов", "Иван", new int[]{ 3, 3, 3 });
            lstSt.Add(st1, st1.AverageGrade());

            Student st2 = new Student("Петров", "Иван", new int[] { 5, 2, 3 });
            lstSt.Add(st2, st2.AverageGrade());

            Student st5 = new Student("Петров1", "Иван", new int[] { 5, 2, 3 });
            lstSt.Add(st5, st5.AverageGrade());


            Student st3 = new Student("Петров2", "Иван", new int[] { 3, 3, 3 });
            lstSt.Add(st3, st3.AverageGrade());

            Student st4 = new Student("Петров3", "Иван", new int[] { 30, 60, 3 });
            lstSt.Add(st4, st4.AverageGrade());

            Student st6 = new Student("Петров4", "Иван", new int[] { 30, 60, 30 });
            lstSt.Add(st6, st6.AverageGrade());

            //первые 3 (countMinGrades) значения средней оценки
            IEnumerable<double> distinctMinGrades = lstSt.Values.ToArray().Distinct().OrderBy(i => i).Take(countMinGrades);

            foreach (KeyValuePair<Student, double> item in lstSt.OrderBy(key => key.Value))
            {
                if (distinctMinGrades.Contains(item.Value))
                {
                    Console.WriteLine($"{item.Key} {item.Value}");
                }
                else break; // список за пределами нужных значений дальше не интересует
            }

            Console.ReadKey();
        }
    }
}

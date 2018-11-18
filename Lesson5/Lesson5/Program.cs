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

            public Student(string lastN, string firstN, int[] grArr)
            {
                lastname = lastN;
                firstname = firstN;

                grades = grArr;

            }
            public string LastName
            { get { return this.lastname; } }

            public string FirstName
            { get { return this.firstname; } }

            public int[] Grades
            { get { return this.grades; } }

            public double AverageGrade()
            {
                return this.grades.Average();
            }

            public override string ToString()
            {
                return $"{this.lastname} {this.firstname}";
            }

            public int Compare(object x, object y)
            {

                try
                {
                    Student xStudent = (Student)x;
                    Student yStudent = (Student)y;

                    return (string.Compare(xStudent.LastName + xStudent.FirstName, yStudent.LastName + yStudent.FirstName));
                }
                catch
                {
                    throw new NotImplementedException();
                }
            }
        }

        static void Main(string[] args)
        {

            Dictionary<Student, double> lstSt = new Dictionary<Student, double>();

            Student st1 = new Student("Иванов", "Иван", new int[]{ 3, 3, 10 });
            lstSt.Add(st1, st1.AverageGrade());

            Student st2 = new Student("Петров", "Иван", new int[] { 5, 2, 3 });
            lstSt.Add(st2, st2.AverageGrade());

            Student st5 = new Student("Петров", "Иван", new int[] { 5, 2, 3 });
            lstSt.Add(st5, st5.AverageGrade());


            Student st3 = new Student("Петров", "Иван", new int[] { 3, 3, 3 });
            lstSt.Add(st3, st3.AverageGrade());

            Student st4 = new Student("Петров", "Иван", new int[] { 30, 60, 3 });
            lstSt.Add(st4, st4.AverageGrade());

            List<double> l = lstSt.Values.ToList();
            l.Sort();

            IEnumerable<double> dist = l.Distinct();
            dist = dist.Take(2);

            foreach (KeyValuePair<Student, double> item in lstSt.OrderBy(key => key.Value))
            {
                if (dist.Contains(item.Value))
                {
                    Console.WriteLine($"{item.Key} {item.Value}");
                }
                else break; // список за пределами нужных значений дальше не интересует
            }

            Console.ReadKey();
        }
    }
}

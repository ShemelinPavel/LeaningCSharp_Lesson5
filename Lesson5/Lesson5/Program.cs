using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5
{
    class Program
    {
        public struct Student
        {

            public string LastName;
            public string FirstName;
            public int Mark1;
            public int Mark2;
            public int Mark3;

            public Student(string lastN, string firstN, int m1, int m2, int m3)
            {
                LastName = lastN;
                FirstName = firstN;

                Mark1 = m1;
                Mark2 = m2;
                Mark3 = m3;
            }

            public double AverageMark()
            {
                return (Mark1 + Mark2 + Mark3) / 3;
            }

        }



        static void Main(string[] args)
        {

            SortedList<Student, double> lstStudents = new SortedList<Student, double>();

            Student st1 = new Student("Иванов", "Иван", 3, 3, 3);
            lstStudents.Add(st1, st1.AverageMark());

            Student st2 = new Student("Петров", "Иван", 3, 3, 3);
            lstStudents.Add(st2, st2.AverageMark());


            IList<double> valList = lstStudents.Values;



        }
    }
}

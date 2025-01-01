using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace StudentAdmin
{
    internal class Karakter
    {
        public Student Student { get; private set; }
        public Fag Fag { get; private set; } 
        public int Degree { get; private set; }

        public Karakter(Student student, Fag fag, int degree)
        {
            Student = student;
            Fag = fag;
            Degree = degree;
        }

        public static List<Karakter> Degrees(List<Student> students, List<Fag> courses)
        {
            var degrees = new List<Karakter>
            {
                new Karakter(students[0], courses[0], 5),
                new Karakter(students[1], courses[1], 3),
                new Karakter(students[2], courses[3], 6),
                new Karakter(students[0], courses[2], 4),
            };
            return degrees;
        }
        public static Karakter CreateDegree(List<Student> students, List<Fag> courses)
        {
            Console.Clear();

            Console.WriteLine("Gi karakter");
            Console.WriteLine("Navnet på eleven?");
            for (var i = 0; i < students.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {students[i].Name}");
            }
            var inputName = Convert.ToInt32(Console.ReadLine()) - 1;
            Console.WriteLine(students[inputName].Name);

            Console.WriteLine("Hvilket fag?");
            for (var i = 0; i < courses.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {courses[i].StudyName}");
            }
            var inputCourse = Convert.ToInt32(Console.ReadLine()) - 1;
            Console.WriteLine(courses[inputCourse].StudyName);

            Console.WriteLine("Hvilken karakter?");
            var degree = Convert.ToInt32(Console.ReadLine());

            students[inputName].Grades.Add(degree);

            return new Karakter(students[inputName], courses[inputCourse], degree);
        }

        public void SkrivUtInfo()
        {
            Console.WriteLine($"Student: {Student.Name}, Fag: {Fag.StudyName}, Karakter: {Degree}");
        }
    }
}

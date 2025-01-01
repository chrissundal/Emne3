using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAdmin
{
    internal class Student
    {
        private static int counter = 0;
        public string Name { get; private set; }
        public int Age { get; private set; }
        public List<Fag> Course { get; private set; }
        public int Id { get; private set; }

        public List<int> Grades { get; private set; }

        public Student(string name, int age, List<Fag> course, List<int> grades)
        {
            Name = name;
            Age = age;
            Course = course;
            Id = counter++;
            Grades = grades;
        }

        public Student()
        {

        }

        public void SkrivUtInfo()
        {
            var sum = 0;
            var sumPoints = 0;
            foreach (var grade in Grades)
            {
                sum += grade;
            }

            var avgGrade = (float)sum / Grades.Count;
            Console.WriteLine($"Navn: {Name}");
            Console.WriteLine($"Alder: {Age}");
            Console.WriteLine($"StudentId: {Id}");
            Console.WriteLine($"Gjennomsnitt karakterer: {avgGrade}");
            Console.WriteLine("Fag:");
            for (var i = 0; i < Course.Count; i++)
            {
                Console.WriteLine(Course[i].StudyName);
                sumPoints += Course[i].StudyPoints;
            }
            Console.WriteLine($"Studiepoeng: {sumPoints}");
        }

        public static List<Student> StudentList()
        {
            var courses = Fag.FagList();
            var students = new List<Student>
            {
                new Student("Lisa", 21, [courses[0],courses[2],courses[3],courses[4]],[5,4]), 
                new Student("Tom", 26, [courses[1],courses[3]],[3]), 
                new Student("Svein", 19, [courses[1],courses[2],courses[3],courses[0],courses[4]], [6]),
            };
            return students;
        }

        public static Student CreateStudent()
        {
            Console.Clear();
            Console.WriteLine("Legg til student");
            Console.WriteLine("Hva er ditt navn?");
            var name = Console.ReadLine();
            Console.WriteLine("Hvor gammel er du?");
            var age = Convert.ToInt32(Console.ReadLine());
            var fagList = Fag.FagList();
            var selectedCourses = new List<Fag>();

            Console.WriteLine("Velg ett eller to fag (skriv 0 for å avslutte):");
            while (true)
            {
                for (var i = 0; i < fagList.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {fagList[i].StudyName}");

                }
                var fagselect = Convert.ToInt32(Console.ReadLine()) - 1;
                if (fagselect == -1)
                {
                    break;
                }
                if (fagselect >= 0 && fagselect < fagList.Count)
                {
                    selectedCourses.Add(fagList[fagselect]);
                    if (selectedCourses.Count == 2)
                    {
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Ugyldig valg, prøv igjen.");
                }
            }
            return new Student(name, age, selectedCourses, []);
        }
    }
}

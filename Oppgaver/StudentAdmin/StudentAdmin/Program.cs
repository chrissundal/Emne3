namespace StudentAdmin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var students = Student.StudentList();
            var courses = Fag.FagList();
            var degrees = Karakter.Degrees(students, courses);

            var selectedStudent = new Student();
            bool exit = false;
            while (!exit)
            {
                GetMenu();
                var menuChoice = Console.ReadLine();
                
                    if (menuChoice == "1")
                    {
                        Console.WriteLine("Velg student");
                        
                        for (var i = 0; i < students.Count; i++)
                        {
                            Console.WriteLine($"{i+1}. {students[i].Name}");
                        }
                        var selectStudent = Convert.ToInt32(Console.ReadLine()) -1;
                        selectedStudent = students[selectStudent];
                        Console.WriteLine($"Du valgte {students[selectStudent].Name}");
                        selectedStudent.SkrivUtInfo();
                    }
                    else if (menuChoice == "2")
                    {
                        Console.WriteLine("Fag");
                        for (var i = 0; i < courses.Count; i++)
                        {
                            Console.WriteLine($"{i+1}. {courses[i].StudyName}");
                        }

                        var inputCourse = Convert.ToInt32(Console.ReadLine()) - 1;
                        courses[inputCourse].SkrivUtInfo();
                    }
                    else if (menuChoice == "3")
                    {
                    bool isDegree = true;
                    Console.Clear();
                        while (isDegree)
                        {
                            Console.WriteLine("Karakterer");
                            Console.WriteLine("Trykk 0 for å gå til hovedmeny");
                            for (var i = 0; i < degrees.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. {degrees[i].Fag.StudyName} {degrees[i].Student.Name}");
                            }

                            var inputDegree = Console.ReadLine();
                            if(inputDegree == "0")
                            {
                                Console.Clear();
                                isDegree = false;
                            }
                            else
                            {
                                Console.Clear();
                                var correctedDegree = Convert.ToInt32(inputDegree);
                                degrees[correctedDegree - 1].SkrivUtInfo();
                            }
                        }
                    }
                    else if (menuChoice == "4")
                    {
                        Console.WriteLine("Legg til ny student");
                        var newStudent = Student.CreateStudent(); 
                        Console.Clear();
                        students.Add(newStudent); 
                        Console.WriteLine($"Ny student lagt til: {newStudent.Name}");
                    }
                    else if (menuChoice == "5")
                    {
                        Console.WriteLine("Legg til ny karakter");
                        var newDegree = Karakter.CreateDegree(students, courses);
                        degrees.Add(newDegree);
                        Console.WriteLine($"Ny karakter gitt til: {newDegree.Student.Name} i faget {newDegree.Fag.StudyName} med karakteren {newDegree.Degree}");

                    }
                    else if (menuChoice == "6")
                    {
                        Console.WriteLine("Legg til nytt fag");
                    }
                    else if (menuChoice == "7")
                    {
                        exit = true;
                    }
                    else
                    {
                        Console.WriteLine("Tast inn ett gyldig valg");
                    }
            }
        }

        private static void GetMenu()
        {
            Console.WriteLine("\nVelkommen til StudentPortal");
            Console.WriteLine("Velg ett alternativ");
            Console.WriteLine("1. Student");
            Console.WriteLine("2. Fag");
            Console.WriteLine("3. Karakterer");
            Console.WriteLine("4. Legg til student");
            Console.WriteLine("5. Legg til karakter");
            Console.WriteLine("6. Legg til nytt fag");
            Console.WriteLine("7. Avslutt\n");
        }
    }
}

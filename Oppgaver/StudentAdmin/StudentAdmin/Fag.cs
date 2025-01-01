using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace StudentAdmin
{
    internal class Fag
    {
        private static int _counter = 0;
        public string StudyName { get; private set; }
        public int StudyPoints { get; private set; }
        public int StudyId { get; private set; }
        

        public Fag(string studyName, int studyPoints)
        {
            StudyName = studyName;
            StudyPoints = studyPoints;
            StudyId = _counter++;
            
        }

        
        public void SkrivUtInfo()
        {
            Console.Clear();
            Console.WriteLine($"StudieNavn {StudyName}");
            Console.WriteLine($"Studie id: {StudyId}");
            Console.WriteLine($"Studiepoeng: {StudyPoints}");
        }

        
        public static List<Fag> FagList()
        {
            
            var courses = new List<Fag>
            {
                new Fag("Matte", 15),
                new Fag("Norsk", 10),
                new Fag("Naturfag", 15),
                new Fag("Gym", 10),
                new Fag("Historie", 10),
            };
            return courses;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendFace
{
    internal class Login
    {
        public void StartLogin()
        {
            var users = Person.GetUsers();
            while (true)
            {
                Logo();
                Console.WriteLine("Velkommen til FriendFace");
                Console.WriteLine("Vennligst logg inn med brukernavn og passord");
                Console.WriteLine("Skriv inn brukernavn");
                var username = Console.ReadLine();
                Console.WriteLine("Skriv inn passord");
                var password = Console.ReadLine();
                bool found = false;
                foreach (var user in users)
                {
                    if (username == user.UserName && password == user.Password)
                    {
                        found = true;
                        Console.WriteLine("Vellykket innlogging");
                        Timer();
                        Console.Clear();
                        var view = new View();
                        view.SetLoggedInPerson(user);
                        user.RemoveUser(user);
                        view.Run();
                        user.AddUser(user);
                        break;
                    }
                }

                if (found == false)
                {
                    Console.Clear();
                    Console.WriteLine("Brukernavnet og passordet stemmer ikke");
                }
            }
        }

        private void Timer()
        {
            Console.WriteLine("Logger inn...");
            Thread.Sleep(2000);
        }

        public void Logo()
        {
            string logo = @"                                                                
                        ,------.       ,--.                  ,--.,------.                     
                        |  .---',--.--.`--' ,---. ,--,--,  ,-|  ||  .---',--,--. ,---. ,---.  
                        |  `--, |  .--',--.| .-. :|      \' .-. ||  `--,' ,-.  || .--'| .-. : 
                        |  |`   |  |   |  |\   --.|  ||  |\ `-' ||  |`  \ '-'  |\ `--.\   --. 
                        `--'    `--'   `--' `----'`--''--' `---' `--'    `--`--' `---' `----'                                                                    
            ";
            Console.WriteLine(logo);
        }
    }
}

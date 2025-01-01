using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendFace
{
    internal class View
    {
        private Person loggedInPerson; 
        private Person _selectedFriend;
        private Person _selectedUser;
        private string[] MainMenu;
        
        
        public void SetLoggedInPerson(Person selected)
        {
            loggedInPerson = selected;
        }
        private void GetMenu()
        {
            MainMenu = ["Søk etter venn","Venneliste","Logg ut","Avslutt"];
        }

        public void Run()
        {
            var AllUsers = Person.GetUsers();
            var friends = loggedInPerson.GetFriends();
            GetMenu();
            Console.WriteLine($"Velkommen til FriendFace");
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine($"{loggedInPerson.FirstName} {loggedInPerson.LastName}");
                Console.WriteLine(loggedInPerson.UserImage);
                for (int i = 0; i < MainMenu.Length; i++)
                {
                    Console.WriteLine($"{i+1}. {MainMenu[i]}");
                }

                var InputMenu = Convert.ToInt32(Console.ReadLine()) -1;
                Console.Clear();
                if (InputMenu < MainMenu.Length && InputMenu >= 0)
                {
                    if (InputMenu == 0)
                    {
                        if (AllUsers.Count > 0)
                        {
                            ShowAllUsers(AllUsers);
                            Console.Clear();
                            ShowOptionsUser();
                            Console.Clear();
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Her var det ingen");
                            Thread.Sleep(2000);
                            Console.Clear();
                        }
                    }
                    else if (InputMenu == 1)
                    {
                        Console.Clear();
                        ShowFriends(friends);
                        Thread.Sleep(3000);
                        Console.Clear();
                    }
                    else if (InputMenu == 2)
                    {
                        Console.Clear();
                        loggedInPerson.AddUser(loggedInPerson);
                        exit = true;
                    }
                    else if (InputMenu == 3)
                    {
                        Environment.Exit(0);
                    }
                    else
                    {
                        WrongAnswer();
                    }
                }
            }
        }

        private void WrongAnswer()
        {
            Console.Clear();
            Console.WriteLine("Ikke ett gyldig valg");
            Thread.Sleep(2000);
            Console.Clear();
        }

        private void ShowOptionsUser()
        {
            while (true)
            {
                if (_selectedUser != null)
                {
                    Console.WriteLine($"1. Legg til venn.");
                    Console.WriteLine($"2. Info om person.");
                    Console.WriteLine($"3. Avslutt");
                    var input = Console.ReadLine();
                    if (input == "1")
                    {
                        Console.Clear();
                        loggedInPerson.AddFriend(_selectedUser);
                        break;
                    }
                    else if (input == "2")
                    {
                        Console.Clear();
                        _selectedUser.ShowInfo();
                        Thread.Sleep(5000);
                        Console.Clear();
                    }
                    else if (input == "3")
                    {
                        Console.Clear();
                        break;
                    }
                    else
                    {
                        WrongAnswer();
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Person ikke valgt");
                    Thread.Sleep(2000);
                    Console.Clear();
                }
            }
        }

        private void ShowAllUsers(List<Person> AllUsers)
        {
            while (true)
            {
                for (int i = 0; i < AllUsers.Count; i++)
                {
                    Console.WriteLine($"{i+1}. {AllUsers[i].FirstName} {AllUsers[i].LastName}");
                }
                var selectUser = Convert.ToInt32(Console.ReadLine()) -1;
                if (selectUser < AllUsers.Count && selectUser >= 0)
                {
                    _selectedUser = AllUsers[selectUser];
                    break;
                }
                else
                {
                    WrongAnswer();
                }
            }
        }

        private void ShowFriends(List<Person> friends)
        {
            if (friends.Count > 0)
            {
                while (true)
                {
                    Console.WriteLine("FriendList");
                    for (int i = 0; i < friends.Count; i++)
                    {
                        Console.WriteLine($"{i+1} {friends[i].FirstName} {friends[i].LastName}");
                    }
                    var InputFriends = Convert.ToInt32(Console.ReadLine()) - 1;
                    if (InputFriends < friends.Count && InputFriends >= 0)
                    {
                        _selectedFriend = friends[InputFriends];
                        Console.Clear();
                        break;
                    }
                    else
                    {
                        WrongAnswer();
                    }
                }
                ShowSelectedFriend();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Usjda du har visst ingen venner");
                Thread.Sleep(2000);
                Console.Clear();
            }
        }

        private void ShowSelectedFriend()
        {
            while (true)
            {
                _selectedFriend.ShowSelectedFriendName();
                Console.WriteLine("Hva vil du gjøre?");
                Console.WriteLine("1. Se info");
                Console.WriteLine("2. Fjerne venn");
                Console.WriteLine("3. Send Melding");
                Console.WriteLine("4. HovedMeny");
                var input = Convert.ToInt32(Console.ReadLine());
                if (input == 1)
                {
                    Console.Clear();
                    _selectedFriend.ShowInfo();
                    Thread.Sleep(5000);
                    Console.Clear();
                }
                else if (input == 2)
                {
                    loggedInPerson.RemoveFriend(_selectedFriend);
                    Console.Clear();
                    Console.WriteLine($"Du har fjernet {_selectedFriend.FirstName} {_selectedFriend.LastName}");
                    break;
                }
                else if (input == 3)
                {
                    while (true)
                    {
                        Console.Clear();
                        loggedInPerson.ShowMessages(_selectedFriend);
                        Console.WriteLine("Send en Melding. Skriv 'lukk' for å gå tilbake");
                        var message = Console.ReadLine();
                        if (message.ToLower() == "lukk")
                        {
                            break;
                        }
                        else
                        {
                            loggedInPerson.SendMessage(_selectedFriend, message);
                        }
                    }
                    Console.Clear();
                }
                else if (input == 4)
                {
                    Console.Clear();
                    break;
                }
                else
                {
                    WrongAnswer();
                }
            }
        }
    }
}

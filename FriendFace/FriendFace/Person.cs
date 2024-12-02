using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace FriendFace
{
    internal class Person
    {
        public string UserName { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Password { get; private set; }
        public int Age { get; private set; }
        public string UserImage { get; private set; }

        private static List<Person> _users;
        private List<Person> _friends;
        private List<Message> _messageList;


        public Person(string userName, string firstName, string lastName, int age, List<Person> friends,
            string password, string userimage)
        {
            UserName = userName;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            _friends = friends;
            _messageList = [];
            Password = password;
            UserImage = userimage;
        }

        static Person()
        {
            var profileImage = new ProfilBilder();
            var newImage = profileImage.GetImage();
            _users =
            [
                new Person("chris123", "Chris", "Jacobsen", 37, [], "Chris123", newImage[0]),
                new Person("alice123", "Alice", "Wonderland", 28, [], "Alice123", newImage[1]),
                new Person("bob456", "Byggmester", "Bob", 30, [], "Bob15", newImage[2]),
                new Person("mikke789", "Mikke", "Mus", 35, [], "mikke123", newImage[1]),
                new Person("dave101", "Dave", "Grohl", 40, [], "DaveGrohl10", newImage[3]),
                new Person("donald202", "Donald", "Duck", 25, [], "donaldduck154", newImage[4])
            ];
            SetFriends();
        }

        private static void SetFriends()
        {
            _users[0]._friends.Add(_users[2]);
            _users[2]._friends.Add(_users[0]);
            var message = new Message(DateTime.Now, _users[2], _users[0], "Hey, Hey, Hey. Kommet deg inn her du også?");
            _users[0]._messageList.Add(message);
            _users[2]._messageList.Add(message);
        }

        public List<Person> GetFriends()
        {
            return _friends;
        }

        public static List<Person> GetUsers()
        {
            return _users;
        }

        public void SendMessage(Person receiver, string content)
        {
            var message = new Message(DateTime.Now, this, receiver, content);
            _messageList.Add(message);
            receiver._messageList.Add(message);
        }

        public void ShowSelectedFriendName()
        {
            Console.WriteLine($"Du har valgt {FirstName} {LastName}");
        }

        public void ShowMessages(Person friend)
        {
            bool hasMessages = false;
            int lineWidth = 30;
            foreach (var message in _messageList)
            {
                if (message.Sender == friend)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(String.Empty.PadLeft(lineWidth) + $"{message.Sender.FirstName} skriver:");
                    Console.WriteLine(String.Empty.PadLeft(lineWidth) + message.Content);
                    Console.WriteLine(String.Empty.PadLeft(lineWidth) + $"{message.Date}\n");
                    hasMessages = true;
                    Console.ResetColor();
                }
                else if (message.Receiver == friend)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Du skriver:");
                    Console.WriteLine(message.Content);
                    Console.WriteLine($"{message.Date}\n");
                    hasMessages = true;
                    Console.ResetColor();
                }
            }

            if (!hasMessages)
            {
                Console.WriteLine($"Ingen meldinger mellom deg og {friend.FirstName} {friend.LastName}.");
            }
        }

        public void AddFriend(Person friend)
        {
            if (!_friends.Contains(friend))
            {
                _friends.Add(friend);
                friend._friends.Add(this);
                Console.Clear();
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"{friend.FirstName} {friend.LastName} er allerede din venn");
            }
        }

        public void RemoveFriend(Person friend)
        {
            _friends.Remove(friend);
            friend._friends.Remove(this);
        }

        internal void ShowInfo()
        {
            Console.WriteLine(UserImage);
            Console.WriteLine($"Fullt navn: {FirstName} {LastName}");
            Console.WriteLine($"Brukernavn: {UserName}");
            Console.WriteLine($"Alder: {Age}");
            if (_friends.Count > 0)
            {
                Console.WriteLine("Venner:");
                foreach (var friend in _friends)
                {
                    Console.WriteLine(friend.FirstName + " " + friend.LastName);
                }
            }
            else
            {
                Console.WriteLine("Har ingen venner");
            }
        }

        public void RemoveUser(Person user)
        {
            _users.Remove(user);
        }

        public void AddUser(Person user)
        {
            _users.Add(user);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendFace
{
    internal class Message
    {
        public DateTime Date { get; private set; }
        public Person Sender { get; private set; }
        public Person Receiver { get; private set; }
        public string Content { get; private set; }

        public Message(DateTime date, Person sender, Person receiver, string content)
        {
            Date = date; 
            Sender = sender; 
            Receiver = receiver; 
            Content = content;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppMarie
{
    internal class Bill
    {
        public int Id { get; private set; }
        public int Amount { get; private set; }
        public string AccountNumber { get; private set; }
        public string Sender { get; private set; }
        public string KidNr { get; private set; }
        public DateTime PayDate { get; private set; }

        public Bill(int id,int billAmount, string billNum, DateTime timeToPay)
        {
            Id = id;
            Amount = billAmount;
            KidNr = billNum;
            PayDate = timeToPay;
        }
    }
}

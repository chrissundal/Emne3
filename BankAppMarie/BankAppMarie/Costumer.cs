using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppMarie
{
    internal class Costumer
    {
        private string _customerName;
        private string _socialSecurityNumber;
        private Account _savingsAccount;
        private Account _currentAccount;
        private List<Bill> _bills;
        

        public Costumer(string customerName)
        {
            _customerName = customerName;
            _savingsAccount = new Account(true, "Savings");
            _currentAccount = new Account(false, "Current");
            _bills = new List<Bill>(); //tom liste
        }
        public Costumer(string customerName,bool hasBills)
        {
            _customerName = customerName;
            _savingsAccount = new Account(true, "Savings");
            _currentAccount = new Account(false, "Current");
            _bills = new List<Bill>()
            {
                new Bill(1,7320,"000064166",new DateTime(2024,12,24)), 
                new Bill(2,2500, "0000665366", new DateTime(2024, 12, 17)), 
                new Bill(3,15,"00054414166",new DateTime(2024,12,15)), 
                new Bill(4,835,"0000451466",new DateTime(2024,12,18))
            };
        }
        public string GetCustomerName()
        {
            return _customerName;
        }

       
        public void withdrawMoney(int sum, bool fromSavingsAccount)
        {
            if (fromSavingsAccount)
            {
                _savingsAccount.Withdraw(sum);
            }
            else
            {
                _currentAccount.Withdraw(sum);
            }
        }

        public void DepositToSavingsAccount(int amount)
        {
            _savingsAccount.DepositMoney(amount);
        }

        public void DepositToCurrentAccount()
        {

        }
        public void PrintBills()
        {
            var num = 1;
            foreach (var bill in _bills)
            {
                Console.WriteLine($"{num} Billnr: {bill.KidNr} Amount: {bill.Amount} DueDate: {bill.PayDate.ToShortDateString()}");
            }
        }

        public void Paybill(int billId)
        {
            var bill = GetBill(billId);
            _currentAccount.Withdraw(bill.Amount);
            _bills.Remove(bill);
            _currentAccount.AddNewTransaction("Paid bill " + bill.KidNr);
        }

        public Bill GetBill(int billId)
        {
            Bill foundBill = _bills.First(bill => bill.Id == billId);
            return foundBill;
        }
    }
}

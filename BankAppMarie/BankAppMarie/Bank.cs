using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppMarie
{
    internal class Bank
    {
        private Costumer _currentCustomer;

        public Bank()
        {
            _currentCustomer = new Costumer("Kåre Knutsen");
            BankMenu();
        }
        void BankMenu()
        {
            Console.WriteLine($"Welcome to the bank {_currentCustomer.GetCustomerName()}");
            Console.WriteLine("1. Deposit money");
            Console.WriteLine("2. Withdraw money");
            Console.WriteLine("3. Pay bill");
            Console.WriteLine("4. Transfer money to savings");
            Console.WriteLine("5. Check account balance");

            var userInput = Console.ReadLine();
            int input = 0;
            switch (userInput)
            {
                case "1":
                    Console.WriteLine();
                    Console.WriteLine("How much money do you want to deposit?");
                    input = Convert.ToInt32(Console.ReadLine());
                    _currentCustomer.DepositToSavingsAccount(input);
                    break;
                case "2":
                    Console.WriteLine();
                    Console.WriteLine("How much money do you want to withdraw?");
                    input = Convert.ToInt32(Console.ReadLine());
                    _currentCustomer.withdrawMoney(input,true);
                    break;
                case "3":
                    Console.WriteLine();
                    break;
                case "4":
                    Console.WriteLine();
                    break;
                default:
                    Console.WriteLine();
                    break;
            }
        }
    }
}

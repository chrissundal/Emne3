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
        

        public Costumer(string customerName)
        {
            
            _customerName = customerName;
            _savingsAccount = new Account(true, "Savings");
            _currentAccount = new Account(false, "Current");
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
    }
}

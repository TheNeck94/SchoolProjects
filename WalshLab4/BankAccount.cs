using System;
using System.Collections.Generic;
using System.Text;

namespace WalshLab4
{
    class BankAccount
    {
        public int AccountNumer { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public DateTime DateOpen { get; set; }
        private static int nextNumber = 1000;


        private void SetDefaults()
        {
            AccountNumer = nextNumber;
            nextNumber += 100;
            Balance = 50;
            DateOpen = DateTime.Today;

        }

        public BankAccount()
        {
            SetDefaults();
        }

        public BankAccount(string inName) : this() => Name = inName;

        public BankAccount(string inName, DateTime date) : this(inName)
        {


            DateTime dateCheck = new DateTime(2010, 1, 1);

            if (date < dateCheck)
            {
                date = DateTime.Today;
                DateOpen = date;
            }
            else
            {
                DateOpen = date;
            }
        }
        public string DisplayAccount() => string.Format("{0, -16}{1, -21}{2, -10:c2}{3, 8}", AccountNumer, Name, Balance, DateOpen);

        public bool Withdraw(decimal amount)
        {
            if (amount > 0 && amount > Balance)
            {
                Balance -= amount;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Deposit(decimal amount)
        {
            if (amount >0)
            {
                Balance += amount;
                return true;
            }
            else
            {
                return false;
            }
        }
        

    }
}

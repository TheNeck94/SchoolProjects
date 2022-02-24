using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime;
namespace WalshLab4
{
    //Name: Brady Walsh
    //Date: 2022/02/09
    //Lab: Lab4
    class Program
    {   //class level list of objects named accounts
        static List<BankAccount> accounts = new List<BankAccount>();
        //Main Function, system args passed in
        static void Main(string[] args)
        {
            BankAccount account1 = new BankAccount() { Name = "Brady Walsh" }; //default custructor
            BankAccount account2 = new BankAccount("Betty White"); // Custom Constructor
            BankAccount account3 = new BankAccount("Tom Selleck", DateTime.Today); //Custom Constructor

            accounts.Add(account1); //adds the first account to the list "accounts"
            accounts.Add(account2); //adds the second account to the list "accounts"
            accounts.Add(account3); //adds the third account to the list "accounts"
            WithdrawAndDeposit();   //Takes string input from user to determine how much money to either deposit or withdraw from an account
        }
        //name: Display all
        //data in: none
        //data out: none
        //description: DisplayAll() runs a foreach loop to display each acocunt in a formatted string
        static private void DisplayAll()
        {
            Console.WriteLine(""); //empty string
            Console.WriteLine("{0, -5}{1, -20}{2, -10}{3, 8}", "Account Number ", " Name ", " Balance ", " Date Opened "); // string format for the Headers of DisplayAll()
            foreach(BankAccount account in accounts) // a foreach loop that loops through the "accounts" list
            {
                Console.WriteLine(account.DisplayAccount()); //calls class method DisplayAccount() to format each account
            }
            Console.WriteLine(""); // empty string
        }
        //name: GetTxnType
        //data in: txnNumber (int)
        //data out: String
        //Description: returns either a "W" for withdrawl or "D" for deposit
        public static string GetTxnType(int txnNumber)
        {
            bool datacheck = true; //part of Extra1: a function level bool to validate data
            string txnType =""; //empty string for output concatination
            DisplayAll(); //calls the DisplayAll() method
            while (datacheck == true) //part of Extra1: a while loop to ensure data validation in the function
            {
                Console.WriteLine("\n Txn " + txnNumber + ": Withdraw(W) or Deposit(D)"); //concatinated string asking the user for input
                
                string input = (Console.ReadKey().KeyChar).ToString();// reads the key pressed and converts it to string for comparisson
                

                if (input.ToUpper() == "W") //if the user input is "W" do this.
                {
                    txnType = "W";
                    datacheck = true; //maintains the while loop for data validation
                    break;//must break, otherwise will always be TxnNumber 1
                }
                else if (input.ToUpper() == "D")//if the user input is "D" do this.
                {
                    txnType = "D";
                    datacheck = true;//maintains the while loop for data validation
                    break;//must break, otherwise will always be TxnNumber 1
                }
                else
                {
                    datacheck = false; //if no valid input detected, switch to false
                }
                
            }return txnType; //returns formatted string

        }
        //name: SelectCustomer()
        //data in: none
        //data out: int
        //description: a static function that returns the user selected input for customer
        public static int SelectCustomer()
        {
            int i; //counter for for loop
            int j = 1; //counter for foreach loop
            for ( i =1; i > 3; i++) //iterates through the existing accounts and displays information
            {
                Console.WriteLine((i).ToString() + accounts[i -1].DisplayAccount());
            }
            Console.WriteLine("");
            Console.WriteLine("{0, -5}{1, -20}{2, -10}{3, 8}", "Account Number ", " Name ", " Balance ", " Date Opened ");
            foreach (BankAccount account in accounts)//a foreach loop that shows just the account name
            {
                Console.WriteLine( j + "  : " + account.Name);
                j++;
            }
            Console.WriteLine("");
            Console.WriteLine("Select Customer Account(enter number)");
            
            int input = Convert.ToInt32(Console.ReadLine()); //converting the readline output into an Int
            return input;
        }
        //name: WithdrawAndDepost
        //data in: none
        //data out: none
        //description: within a for loop, calls SelectCustomer() for input, calls GetTxnType() for input, makes appropriate alterations to .Balance for the corrisponding object
        public static void WithdrawAndDeposit()
        {
            for (int i =1; i <= 5; i++) //a for loop that iterates 5 times, simulating 5 transactions
            {
                int customer = SelectCustomer(); //assigning the value of use input from SelectCustomer() to var Customer

                switch (GetTxnType(i)) //switch statement to determine action based on GetTxnType() return
                {
                    case "W":
                        accounts[customer -1].Balance -= 10 * i; //assigns a new value to .Balance
                        break;
                    case "D":
                        accounts[customer -1].Balance += 10 * i; //assigns a new value to .Balance
                        break;
                    case null:
                        Console.WriteLine("Invalid input Detected, Please try again");
                        break;
                    default:
                        Console.WriteLine("Invalid input Detected, Please try again");
                        break;


                }
            }

            
        }
    }
}

using System;
using System.IO;
using System.Collections.Generic;

namespace WalshLab6
{
    class Program
    {
        static void Main(string[] args)
        {
            //Attempt to create a Package called p1. Code and comment issues. Leave comment for marking.
            //Package p1 = new Package; //Cannot create instanced object from abstract class
            //Create a list of packages called deliveries in main set to an empty list. Create a method called DisplayPackages in the Program class that will display all packages. Send the list of packages to the method.
            List<Package> deliveries = new List<Package>();
            //Create a Weekly delivery using default constructor. Add to the list. Change the From information to name as “NBCC”, address as “100 Grand Avenue”, City to “Saint John”. Set the Weight to 0 to test set of Weight. Set the discount to 0 to test set of Discount. Both should get reset. See screenshots.
            Weekly w1 = new Weekly();
            w1.From.Name = "NBCC";
            w1.From.Address = "100 Grand Avenue";
            w1.From.City = "Saint John";
            w1.Weight = 0;
            w1.Discount = 0;
            deliveries.Add(w1);
            //Create a Weekly delivery using custom constructor sending in From: “Bob Barker”, “2 Apple Road”; To: “Mario Luigi”, “80 Orange Street”, weight of 450.25 and discount of 0.15 (all valid data). Add to the list.
            Client BB = new Client("Bob Barker", "2 Apple Road");
            Client ML = new Client("Mario Luigi", "80 Orange Street");
            Weekly w2 = new Weekly(BB, ML, 450.25m, 0.5m);
            deliveries.Add(w2);
            //Create a Speedy delivery using default constructor. Add to the list. Change the From information to name as “Greco”, address as “8 Pizza Slices”, City to “Fredericton”. Set the Weight to 5000.2 to test set of Weight. Set the extra cost to 0 to test set of Extra. Both should get reset. See screenshots.
            Speedy s1 = new Speedy();
            s1.From.Name = "Greco";
            s1.From.Address = "8 Pizza Slices";
            s1.From.City = "Fredericton";
            s1.Weight = 5000.2m;
            s1.Extra = 0;
            deliveries.Add(s1);
            //Create a Speedy delivery using custom constructor sending in From: “Haresh Komali”, “17 Grape Juice”; To: “Amazon”, “22 Cloud”, weight of 899.9 and extra cost of 0.035 (all valid data). Add to the list.
            Client HK = new Client("Haresh Komali", "17 Grape Juice");
            Client A = new Client("Amazon", "22 Cloud");
            Speedy s2 = new Speedy(HK, A, 899.9m, 0.0m);
            deliveries.Add(s2);
            // Call DisplayPackages sending in the list of packages (only called once at end). All formatting of display is done in ToString() methods. Update DisplayPackages to sum the total cost of all and display on screen.
            DisplayPackages(deliveries);


            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        public static void DisplayPackages(List<Package> del) //public static method for displaying data
        {
            Console.WriteLine("Enter File Path: "); //asks the user for input, asks for path
            string path = Console.ReadLine(); //reads in user input
            Console.WriteLine("Enter File Name: "); //asks the user for input, asks for file name
            string file = Console.ReadLine(); //reads in use input
            if (file == "WalshLab6.txt" && path == "c:\\OOP\\") //validates the path and file name
            {
                StreamWriter outputfile = new StreamWriter(@"c:\OOP\WalshLab6.txt"); //creates new streawriter object at file path c:\OOP\WalshLab6.txt
                outputfile.WriteLine("Brady Walsh " + " 2022/03/17"); //adds headers before iteration loop
                decimal total = 0m; //initializes decimal total to value 0
                for (int i = 0; i < del.Count; i++) //iterates through the input list
                {
                    Console.WriteLine(del[i].ToString()); //does really cool genius stuff i built
                    outputfile.WriteLine(del[i].ToString()); //does the same genius stuff but does it in the output file #genius
                    total += del[i].CalculateCost(); //sums the total value
                }
                string output = "Total Value of Packages: " + total.ToString(); //displays the total value
                Console.WriteLine(output); 
                outputfile.WriteLine(output);
                outputfile.Close(); //closes the file super high level tactic. pro gamer move
            }
            else
            {
                Console.WriteLine("Please enter valid File & Path"); //if invalid path or file is given
            }
        }

    }
    public class Client
    {   //Q1: Create a console application called LastnameLab6. Create the class called Client using the UML diagram:
        public string Name; //String Variable named Name, a public property that can be accessed anywhere
        public string Address; //String Variable name Address, a public property that can be accessed anywhere
        public string City = "Ottawa"; //String Variable name City, a public property that can be accessed anywhere, initialized as "Ottawa" 

        public Client() { } //Default Constructor
        public Client(string inName, string inAddress) //Custom Constructor, assigns Name and Address to custom values
        {
            Name = inName; //assigns the class property to the value of the in variable
            Address = inAddress; //assigns the class property to the value of the in variable
        }
        public override string ToString() //Method Overide to return all data in a formatted string
        {
            string output; //initialize a string with no value
            output = string.Format("{0,-9}{1,-20}{2,-18}", Name, Address, City); //Format the string
            
            return output; //return the string
        }
    }
    public abstract class Package
    { //Q2: Create an abstract class Package using the UML diagram with explanation in comments:
        private decimal weight; //private decimal value stored for assignment to public Property
        protected int TrackingNumer; //protected int Tracking number, can only be accessed through the class and derived classes
        public Client From; //un-initialized Class object property
        public Client To; //un-initialized Class object property
        public decimal Weight // public decimal with custom get and set accesors 
        {
            get
            {
                return weight;
            }
            set
            {
                weight = Validate(value, 5000, 450); //calls to a public class method that vlaidates the input as within range
            }
        }
        public abstract decimal Price {get;} //effectively a read only property

        private static int next = 1000; //static int to denote the tracking number

        public Package()
        {
            TrackingNumer = next; //assigns value based on the current value of "next"
            next += 10; //incriments "next" for the next call of the constructor
            From = new Client(); //calls default constructor
            To = new Client("Brady", "123 Elm Street"); //calls custom constructor
        }
        public Package(Client from, Client to, decimal inWeight) :this() //creates the custom constructor taking in values or objects for from, to and weight. also calls the base constructor
        {
            From = from; //assigns the value of the from variable to the From property
            To = to; //assigns the value of the to variable to the To property
            Weight = inWeight; //assigns the value of the inWeight variable to the Weight property

        }
        public abstract decimal CalculateCost(); //an abstract method with no body (filled in derrived class)
        public override string ToString() //public method overide, ovverides the ToString() method to return a formatted string with all data
        {
            string output; //initialized variable with no value
            output = "*************************************************\n" + string.Format("{0,-8}{1,-12}{2,-40}", "Type:", "Tracking#:", "From:") + "\n" + //basically pure genius and determination to make this work
                string.Format("{0,-10}{1,-10}{2,-18}", this.GetType().Name, TrackingNumer, From) + "\n"
                + string.Format("{0,-20}{1, 15}", "Ship To: ", To) + "\n"
                + string.Format("{0,-20}{1,-15}{2, 15}{3, 15}", "", "Weight: ", "Price: ", "Cost: ") + "\n"
                + string.Format("{0,-20}{1,-15}{2, 15:c2}{3, 15:c2}", "", Weight, Price, this.CalculateCost()) + "\n";
            return output; //return variable with value equal to the formatted string
        }
        public decimal Validate(decimal cls, decimal max, decimal min) //class level function to validate set accessors input
        {
            if (cls < max && cls > min) //if input is within range do this...
            {
                return cls;
            }
            else                        //otherwise set to max
            {
                return max;
            }
        }

    }
    sealed class Weekly : Package //deriving a sealed class from the abstract class Package
    {
        private decimal discount; //private decimal, used to hold the current value of a property
        public decimal Discount //the get and set accessors for the public discount property
        {
            get
            {
                return discount; //returns the value of the discount variable to the Discount property
            }
            set
            {
               discount = Validate(value, 25, 10); //calls the validate function to make sure the input is within range
            }
        }
        public override decimal Price //derrived property from the Package class, overides the Property value
        {
            get
            {
                return 0.4m; //returns new property value
            }
        }

        public Weekly() : base() { } //default constructor, calls the base constructor
        public Weekly(Client from, Client to, decimal weight, decimal discount) : base(from, to, weight) //custom constructor, takes in value/object from , to, weight and discount. calls the base constructor and passes in "from", "to", and "weight"
        {
            Discount = discount; //assigns the value of the variable to the Discount property
        }
        public override decimal CalculateCost() //static method overide derrived from the base class
        {
            decimal cost = 0; //strangely structing it with the assignment to 0 and then calculating removed a syntax error
            cost = (Price * Weight) * (Discount / 100); //calculates the cost of a package based on property values
            return cost; //returns the variable with the value equal to the cost of the package

        }
        public override string ToString() => //static method overide derrived from the base class
            base.ToString() + "*************************************************\n" + TrackingNumer.ToString() + " has discount: " + Discount.ToString() + "\n*************************************************\n";
           
        
    }
    sealed class Speedy : Package //sealed class derrived from the base class Package
    {
        private decimal extra; //private decimal variable
        public decimal Extra //public property 
        {
            get
            {
                return extra; //returns the value of the variable
            }
            set
            {
                extra = Validate(value, 0.04m, 0.01m); //calls the static method to validate
            }
        }
        public decimal DeliveryFee //public decimal property for delivery fee
        {
            get
            {
                return (decimal)10.00; //explicit cast of decimal, returned
            }
        }
        public override decimal Price
        {
            get
            {
                return .12m;
            }
        }
        public Speedy() :base() { } //default constructor calls the base constructor
        public Speedy(Client from, Client to, decimal weight, decimal extra) :base(from, to, weight) //custom cunstroctor that calls the base constructor
        {
            Extra = extra; //assigns the value of the variable to the property
        }
        public override decimal CalculateCost() //derrived static method overide from the base class
        {
            decimal //does my formatting scare you?
            cost = ((Price + Extra) * Weight) + DeliveryFee;
            return cost;
        }
        public override string ToString() => //derrived static method overide from the base class
        
            
            base.ToString() + "*************************************************\n" + TrackingNumer.ToString() + " has extra cost per Gram: " + Extra.ToString() + "and deliver fee of " + DeliveryFee.ToString() + "\n*************************************************\n";
            
        
    }
}

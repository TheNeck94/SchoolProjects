using System;
using System.IO;
namespace WalshLab1
{
    class Program
    {
        const int SIZE = 12;
        static void Main(string[] args)
        {
            Console.WriteLine("Try");
            string[] companiesArray = new string[SIZE];
            int[] listingsArray = new int[SIZE];

            if (ReadCompanies(companiesArray) == true && ReadListings(listingsArray) == true)
            {
                try
                {
                    


                    StreamWriter outputfile = new StreamWriter(@"c:\OOP\WalshLab1.txt");
                    for (int i = 0; i < companiesArray.Length; i++)
                    {
                            outputfile.WriteLine(companiesArray[i]);
                            outputfile.WriteLine(listingsArray[i]);
                            
                    }Console.WriteLine("output");
                    outputfile.WriteLine("Average Number of Listings: " + CalcAvg(listingsArray).ToString("n2"));
                    outputfile.WriteLine("High Performers: " + CountHighPerfomers(listingsArray));
                    outputfile.Close();
                    
                    Console.WriteLine("calc avg start");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + "\n" + ex.GetType() + "\n" + ex.StackTrace);
                }
            }
        }
        /*Name: ReadCompanies
         * Description: iterates through a text file assigning each line to an array index position
         * Sent: string[] companiesArray
         * Returned: bool
         */
        public static bool ReadCompanies(string[] companiesArray) 
        {
            string dir = @"C:\Users\brady\source\repos\WalshLab1\";
            string path = dir + "Companies.txt";
            int i = 1;
            try
            {
                StreamReader inputFile = new StreamReader(path);

                while (i < companiesArray.Length)
                {
                    companiesArray[i] = inputFile.ReadLine();
                    i++;
                    
                }inputFile.Close();
                return true;
                
            }
            catch (Exception ex)
            {
               
                Console.WriteLine(ex.Message + "\n" + ex.GetType() + "\n" + ex.StackTrace);
                 return false;
            }
        
        
        }
        /*Name: ReadCompanies
         * Description: iterates through a text file assigning each line to an array index position
         * Sent: int[] listingsArray
         * Returned: bool
         */
        public static bool ReadListings(int[] listingsArray)
        {
            Console.WriteLine("start of ReadListings");
            string dir = @"C:\Users\brady\source\repos\WalshLab1\";
            string path = dir + "Listings.txt";
            int i = 0;
            try
            {   StreamReader inputFile = new StreamReader(path);
                
                
                while (i < listingsArray.Length)
                {
                    
                    listingsArray[i] = int.Parse(inputFile.ReadLine());
                    i++;

                }
                Console.WriteLine("end of ReadListings");
                return true;
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\n" + ex.GetType() + "\n" + ex.StackTrace);
                return false;
            }
        }
        /*Name: CalcAvg
         * Description: iterates through the listings array to calculate the average
         * Sent: int[] listingsArray
         * Returned: double
         */
        public static double CalcAvg(int[] listingsArray)
        {
            double res =0;
            
            foreach (int thing in listingsArray)
            {
                res += thing;
                   
            }res = res / SIZE; 
            return res;

        }
        /*Name: CountHighPerformers
         * Description: iterates through the listings array to calculate listings that are 500 or more
         * Sent: int[] listingsArray
         * Returned: int
         */
        public static int CountHighPerfomers(int[] listingArray)
        {
            const int LEVEL = 500;
            int hp = 0;
            foreach (int value in listingArray)
            {
                if (value >= LEVEL)
                {
                    hp++;
                }
            }
            return hp;
        }

    }
}

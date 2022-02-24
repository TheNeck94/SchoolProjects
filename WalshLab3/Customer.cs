using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalshLab3
{
    class Customer
    {
         private static int nextID = 1000;

        public int ID
        { get; set; }
        public string Name
        { get; set; }
        public bool Active
        { get; set; }
        public decimal Credit
        { get; set; }
        public Customer() 
        {
            SetID();
            Active = true;
            Credit = 3000;
        }

        public Customer(string inName, bool inActive, decimal inCredit)
        {
            SetID();
            Name = inName;
            Active = inActive;
            Credit = inCredit;
        }
        private void SetID()
        {
           ID = nextID++;            
            
        }
        public string DisplayData() =>

            string.Format("{0, -6}{1, -15}{2, -3}{3, -10:c0}", ID, Name, (Active ? "Y" : "N"), Credit);
        
    }
}

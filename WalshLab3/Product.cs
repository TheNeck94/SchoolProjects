using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WalshLab3
{
    class Product
    {
        //fields - private - lowercase
        private string code;
        private string description;
        private decimal price;

        //create properties - uppercase
        public string Code
        {
            get
            {
                return code;
            }
            set
            { //data validation
                code = value;
            }
        } // end property Code
        public string Description
        {
            get
            {
                return description;
            }
            set
            { //data validation
                description = value;
            }
        } // end property Description
        public decimal Price
        {
            get
            {
                return price;
            }
            set
            { //data validation
                price = value;
            }
        } // end property Price

        //default constructor
        public Product()
        {
            //MessageBox.Show("Default constructor ran");
        } // default constructor

        //other constructor
        public Product(string inCode, string inDescription,
            decimal inPrice)
        {
            //set properties
            Code = inCode;
            Description = inDescription;
            Price = inPrice;
        } // end default constructor

        //method - send back all data - access fields
        public string GetDisplayText(string sep)
        {
            return code + sep + price.ToString("c") 
                + sep + description;
        } // end method


    }
}

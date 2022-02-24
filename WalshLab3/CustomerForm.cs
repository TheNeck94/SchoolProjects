using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WalshLab3
{
    public partial class CustomerForm : Form
    {
        public CustomerForm()
        {
            InitializeComponent();
        }

        List<Customer> customers = new List<Customer>();

        private void CustomerForm_Load(object sender, EventArgs e)
        {
            Customer customer;
            customer = new Customer();
            customer.Name = "Brady";
            Customer sally;
            sally = new Customer("Sally", false, 0);
            customers.Add(customer);
            customers.Add(sally);
            DisplayList();
        }
        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtInput.Text.Length <= 5)
            {
                MessageBox.Show("Invalid Input Detected", "Invalid Input!");
            }
            else
            {
                string input = txtInput.Text;
                Customer newcustomer;
                newcustomer = new Customer()
                {
                    Name = input
                };
                customers.Add(newcustomer);
                DisplayList();
                txtInput.Clear();
                txtInput.Focus();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void DisplayList()
        {
            lstCustomers.Items.Clear();
                foreach (Customer customer in customers)
            {
                lstCustomers.Items.Add(customer.DisplayData());
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            string message = "Are you sure?";
            string title = "Clear List";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                lstCustomers.Items.Clear();
                txtInput.Text = "";
                txtInput.Focus();

            }
            else
            {
                // Do Nothing
            }
        }

        private void btnReadCust_Click(object sender, EventArgs e)
        {
            
            if (lstCustomers.Items.Count == 0)
            {
                DialogResult userInput = ofdCustomers.ShowDialog();
                if (userInput != DialogResult.Cancel)
                {
                    StreamReader customerFile = new StreamReader(ofdCustomers.FileName);
                    string line1 = customerFile.ReadLine();
                    string line2 = customerFile.ReadLine();
                    string line3 = customerFile.ReadLine();

                    Customer cust1;
                    cust1 = new Customer
                    {
                        Name = line1
                    };
                    customers.Add(cust1);
                    Customer cust2;
                    cust2 = new Customer
                    {
                        Name = line2
                    };
                    customers.Add(cust2);
                    Customer cust3;
                    cust3 = new Customer
                    {
                        Name = line3
                    };
                    customers.Add(cust3);
                    DisplayList();

                    

                    
                }
            }
            else
            {
                MessageBox.Show("Customers already in list");
            }
        }
    }
}

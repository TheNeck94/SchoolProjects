using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WalshLab3
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            CustomerForm customerForm = new CustomerForm();

            customerForm.ShowDialog();
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            ProductForm productForm = new ProductForm();

            productForm.ShowDialog();
        }
    }
}

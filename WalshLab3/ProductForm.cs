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
    public partial class ProductForm : Form
    {
        public ProductForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //create a default product
            //calls the default constructor
            Product p1 = new Product();

            //set properties
            p1.Code = "FIT1000";
            p1.Description = "Ultra FitBit";
            p1.Price = 169.99m;

            //display using msgbox
            MessageBox.Show(p1.GetDisplayText(", "));

            //create p2 calling other constructor
            //must have data in textboxes or runtime error
            Product p2 = new Product(txtCode.Text,
                txtDescription.Text, decimal.Parse(txtPrice.Text));
            //display data
            MessageBox.Show(p2.GetDisplayText("\n"));

        }
    }
}

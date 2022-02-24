using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/// <summary>
/// ITPA:1B -WalshLab5 (TryMath) DueDate: Oct 21, 2021 8:30 AM
/// Description: This program takes in two user input values, converts them to doubles and calculates output using a pre-determined formula (Mortgage Rate)
/// </summary>
namespace WalshLab5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //Establish RATE as constant double with the value of 0.0299, this represents the mortgage rate
        const double RATE = 0.0299;
        //Reset button Clears text fields and outputs, hides picture and sets focus to the first text input
        private void btnReset_Click(object sender, EventArgs e)
        {
            txtPrincipal.Clear();
            txtPrincipal.Focus();
            txtYears.Clear();
            lblOutput.Text = " ";
            pboxHouse.Visible = false;

        }
        //Exit Button closes the program and any processes
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        // on form load, the Rate text box is assigned the value of the RATE var
        private void Form1_Load(object sender, EventArgs e)
        {
            lblRate.Text = RATE.ToString();

        }
        // on click, if statement check validates the input, then calculates the output and displays a formatted string
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtPrincipal.Text) < 5000)
            { MessageBox.Show("Invalid Principal amount, try again"); }
            else if (Convert.ToInt32(txtYears.Text) > 30)
            { MessageBox.Show("Invalid Years amount, try again"); }
            else
            {
                try
                {
                    double N = (Convert.ToDouble(txtYears.Text) / 12);
                    double R = RATE;
                    double V = (1 / R);
                    double Output = (((Convert.ToDouble(txtPrincipal.Text) * Math.Pow((R * V), (N)))) / Math.Pow(V, N)) - 1;
                    double Result = (Math.Round(Output, 2));
                    lblOutput.Text = Result.ToString("C");
                    pboxHouse.Visible = true;
                }
                catch
                {
                    string message = "Incorrect ionput encountered";
                    string title = "Error";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    MessageBox.Show(message, title, buttons);
                }
            }
        }
    }
}

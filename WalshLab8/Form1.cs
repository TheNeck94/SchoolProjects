using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WalshLab8
{/* Name: Brady Walsh
Description: Lab8 Random Looping Functions
Sent:
Returned: */
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /*CLASS LEVEL VARS*/
        const string MYNAME = " Brady Walsh ";
        int GenCount = 0;
        int CalcCount = 0;
        /* Name: Form1_Load
        Description: the logic that takes place when the program loads the form
        Sent: none
        Returned: Form1*/
        private void Form1_Load(object sender, EventArgs e)
        {
            grpAnalysis.Visible = false;
            grpFormula.Visible = false;
            this.Text = this.Text + MYNAME;
        }
        /* Name: chkFomula_CheckedChanged
        Description: the event that takes place when the radio check button for formula is clicked
        Sent: none
        Returned: none*/
        private void chkFormula_CheckedChanged(object sender, EventArgs e)
        {
            switch (chkFormula.Checked)
            {
                case true: grpFormula.Visible = true;
                    ResetFormula();
                    break;
                case false: grpFormula.Visible = false;
                    break;
            }
        }
        /* Name: Reset Formula
        Description: Resets the formula
        Sent: none
        Returned: none*/
        public void ResetFormula()
        {
            radPermutation.Checked = true;
            lblAnswerOutput.Text = "";
            nudSelect.Value = 0;
            nudTotal.Value = 0;
        }
        /* Name: chkAnalysis_CheckedChanged
         Description: displays the Analysis group box when selected
         Sent: none
         Returned: none*/
        private void chkAnalysis_CheckedChanged(object sender, EventArgs e)
        {
            switch (chkAnalysis.Checked)
            {
                case true:
                    grpAnalysis.Visible = true;
                    ResetAnalysis();
                    break;
                case false:
                    grpAnalysis.Visible = false;
                    break;
            }
        } /* Name: Reset Analysis
        Description: Resets the Analysis
        Sent: none
        Returned: none*/
        public void ResetAnalysis()
        {
            txtClassroom.Text = "";
            lblSumOutput.Text = "";
            lblAverageOutput.Text = "";
            txtClassroom.Focus();
            lstClassSize.Items.Clear();
        }
        /* Name: radPermutation_CheckChanged 
        Description: checks if the radio button "radPermutation" is checked, then displays the appropriate picture
        Sent: e
        Returned: picbox.imagelocation */
        private void radPermutation_CheckedChanged(object sender, EventArgs e)
        {
            switch (radPermutation.Checked)
            {
                case true:
                    this.picbox.ImageLocation = "Perm Formula.jpg";
                    picbox.SizeMode = PictureBoxSizeMode.Zoom;
                    break;
                case false:
                    this.picbox.ImageLocation = "Comb Formula.jpg";
                    picbox.SizeMode = PictureBoxSizeMode.Zoom;
                    break;
            }
        }
        /* Name: btnCalculate_Click
        Description: takes in data from NUD oobjects and iterates through a formula based on "radPermutation" check status
        Sent: string, int
        Returned: variable increment, int*/
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            int answer;
            int select = (int)nudSelect.Value;                       
            int total = (int)nudTotal.Value;
            int s = (total - select);
            switch (radPermutation.Checked)
            {

                case true:
                    if (select < total)
                    {
                        if (select == total) 
                        {
                            MessageBox.Show("Invalid Input Detected, please ensure Select is less than Total" + "\n(Cannot be equal to)");
                            break;
                        }
                        else
                        {

                            answer = (Multiply(total) / Multiply(s));
                            lblAnswerOutput.Text = answer.ToString("#,###");
                            CalcCounter();
                            break;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid Input Detected, please ensure Select is less than Total");
                        break;
                    }
                case false:
                    if (select < total)
                    {
                        if (select == total)
                        {
                            MessageBox.Show("Invalid Input Detected, please ensure Select is less than Total" + "\n(Cannot be equal to)");
                            break;
                        }
                        else
                        {
                            answer = Multiply(total) / (Multiply(select) * (Multiply(s)));
                            lblAnswerOutput.Text = answer.ToString("#,###");
                            CalcCounter();
                            break;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid Input Detected, please ensure Select is less than Total");
                        break;
                    }
                    
            }
        }
        /* Name: Multiply
        Description: finds the factorial of int "f" through recursion
        Sent: int f
        Returned: int*/
        public int Multiply(int f)
        {
            if (f == 1)
                return 1;
            else
                return f * Multiply(f - 1);
        }
        /* Name: Display Error
        Description: Takes string and displays it in an error message
        Sent: string a
        Returned: message box event arg*/
        private void DisplayError(string a)
        {
            MessageBox.Show("Incorrect inpute detected  \n" + a + "\n is not a valis input", MYNAME);
            txtClassroom.Select();
            txtClassroom.Focus();
        }
        /* Name: btnGenerate_Click
        Description: 
        Sent:
        Returned: */
        public void btnGenerate_Click(object sender, EventArgs e)
        {
            try {
                int R = Convert.ToInt32(txtClassroom.Text);
                
                if (R >= 5 || R <=12)
                {
                    GenerateNumbers(R);
                    Console.WriteLine(lstClassSize.Items.Count);
                    int Sum = GetSum(lstClassSize.Items.Count);
                    lblSumOutput.Text = Sum.ToString("");
                    lblAverageOutput.Text = (Sum / lstClassSize.Items.Count).ToString("##.##");
                    GenCounter();
                }
                else
                {
                    DisplayError(txtClassroom.Text);
                }
            }
            catch {
                DisplayError("trycatch: " + txtClassroom.Text);
                    }
        }
        /* Name: GenerateNumbers
        Description: Creates a series of random numbers based on the seed valueL: 55
        Sent: int x
        Returned:  new.rand * x*/
        public void GenerateNumbers(int x)
        {
            lstClassSize.Items.Clear();
            Random rand = new Random(55);
            int i;
            for(i=0;i<x; i++)
            {
                
                lstClassSize.Items.Add(rand.Next(15,31));
            }
        }
        /* Name: GetSum
        Description: interates through list "lstClassSize" and sums values then assigns summed value to int y
        Sent: intx
        Returned: int y*/
        public int GetSum(int x)
        {
            int i;
            int y = 0;
                for(i=0; i<x; i++)
            {
                y += Convert.ToInt32(lstClassSize.Items[i]);

               
            }
             return y;
        }
        /* Name: CalcCounter
        Description: incremenets global "CalcCount"
        Sent: none
        Returned: none*/
        public void CalcCounter()
        {
            CalcCount++;
        }
        /* Name: GenCounter
        Description: increments global "GenCount"
        Sent:none
        Returned:none */
        public void GenCounter()
        {
            GenCount++;
        }
        /* Name: Form1_FormClosing
        Description: displays a message box on form close
        Sent: e
        Returned: none*/
        private void Form1_FormClosing(Object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Generations: " + GenCount + "\nCalculations: " + CalcCount, "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
        /* Name: btnReset_Click
        Description: Resets the Form for both analysis and formula group boxes
        Sent: none
        Returned: none */
        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetAnalysis();
            ResetFormula();
        }
    }
}

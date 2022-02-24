using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Walsh_Lab2
{// name : Brady Walsh
 // date : 2022-01-20
 // description : a program that adds objects created form the Pet class and adds them to a list box with some formating
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent(); //this function initializes the compenent in the formspace
        }

        private void button1_Click(object sender, EventArgs e) // 
        {
            txtPetName.Text = "";
            nudAge.Value = 0;
            radBird.Checked = false;
            radCat.Checked = false;
            radDog.Checked = false;
            lstOutput.Items.Clear(); //this method clears the current values in the list box
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtPetName.Text;
            int age = (int)nudAge.Value;
            string type;
            Pet firstPet;
            firstPet = new Pet();
            firstPet.Age = 4;
            firstPet.Type = "dog";
            firstPet.Name = "spot";
            lstOutput.Items.Add(firstPet.DisplayPet()); //returns string via labda expression including class values
            if (radBird.Checked)
            {
                type = "Bird";
            }
            else if (radCat.Checked)
            {
                type = "Cat";
            }
            else
            {
                type = "Dog";
            }
            if (txtPetName.Text == "")
            {
                MessageBox.Show("Empty name detected, please enter a name"); // shows a message box explaining that the text input is empty
            }
            else
            {
                Pet secondPet = new Pet(name, age, type);
                secondPet.Age++;
                lstOutput.Items.Add(secondPet.DisplayPet());//returns string via labda expression including class values
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5
{/* Name: Brady Walsh
  * Date: 2022-02-28
  */
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //makes an empty list of employees
        private List<Employee> workers = new List<Employee>();
        //functions and methods that take place during the form load
        private void Form1_Load(object sender, EventArgs e)
        {
            //list of random names to be added
            List<string> Names = new List<string>();
            Names.Add("Brady");
            Names.Add("John");
            Names.Add("Hank");
            //list of random dates to be added
            List<DateTime> dateTimes = new List<DateTime>();
            dateTimes.Add(new DateTime(2019, 01, 01));
            dateTimes.Add(new DateTime(2021, 11, 01));
            dateTimes.Add(new DateTime(2020, 06, 06));
            radEmployee.Checked = true; //sets the Employee button to checked on load
            for (int i =0; i<=2; i++)
            {
                workers.Add(new Employee(Names[i], dateTimes[i])); //creats 3 new employees and adds them to list
            }
            updateList(); 
        }
        /* name: add
         * sent: none
         * return: none
         * description: Checks type to be added, then adds the corrisponding record type to the list
         */
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string userName = txtName.Text;
            DateTime startDate = dtpStarted.Value;
            if (userName.Length >= 5)
            {
                switch (radEmployee.Checked) // checks to see which button is checked
                {
                    case true: //if Employee button is checked do this....
                        Employee newEmployee = new Employee(userName, startDate);
                        workers.Add(newEmployee);
                        lstEmployees.Items.Add(newEmployee.DisplayData());
                        cboNames.Items.Add(newEmployee.Name);
                        updateList();
                        break;
                    case false: //otherwise if the supervisor button is checked, do this....
                        Supervisor newSupervisor = new Supervisor(userName, startDate, 10);
                        workers.Add(newSupervisor);
                        lstEmployees.Items.Add(newSupervisor.DisplayData());
                        cboNames.Items.Add(newSupervisor.Name);
                        updateList();
                        break;
                    default: break;
                }
            }
        }
        /* name: delete
         * sent: none
         * return: none
         * description: Deletes selected Record from the list
         */
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstEmployees.SelectedIndex == -1) //if no record is selected
            {
                MessageBox.Show("No Record Selected \nPlease select a record to Delete", "No Record to delete");
            }
            else //if a record is selected, do this...
            {
                workers.RemoveAt(lstEmployees.SelectedIndex);
                updateList();
            }
        }
        /* name: updatelist
         * sent: none
         * return: none
         * description: adds items to both the combo box and the list box via the workers list of objects
         */
        public void updateList()
        {
            lstEmployees.Items.Clear();
            cboNames.Items.Clear();
            for (int i = 0; i < workers.Count; i++)
            {
                lstEmployees.Items.Add(workers[i].DisplayData());
                cboNames.Items.Add(workers[i].Name);
            }
        }
        /* name: lstEmployees_DoubleClick
         * sent: none
         * return: none
         * description: opens a dialog box upon double clicking a record, gives option to add or subtract $100 or cancel
         */
        private void lstEmployees_DoubleClick(object sender, EventArgs e)
        {
            int select = lstEmployees.SelectedIndex;
            Random random = new Random();
            if (select == -1) //if no record is selected
            {
                MessageBox.Show("No Employee Selected \nPlease select a valid Emlpoyee ", "No Employee Selected");
            }
            else if (lstEmployees.SelectedItem.GetType() == typeof(Employee))//if an Employee record is selected
            {
                try
                {
                    workers[select].Pay((decimal)random.Next(125, 600));
                    updateList();
                }
                catch
                {
                    string outname = workers[select].Name;
                    MessageBox.Show(outname + "'s payment not completed");
                }
            }
            else if (lstEmployees.SelectedItem.GetType() == typeof(Supervisor))//if a Supervisor record is selected
            {
                try
                {
                    ((Supervisor)workers[select]).Pay();
                    updateList();
                }
                catch
                {
                    string outname = workers[select].Name;
                    MessageBox.Show(outname + "'s payment not completed");
                }
                
            }
        }
        /* name: btnBonus_Click
         * sent: none
         * return: none
         * description: when clicked, if supervisor record selected, will add $100 or subtract $100 based on user input
         */
        private void btnBonus_Click(object sender, EventArgs e)
        {
            int index =lstEmployees.SelectedIndex;
            Employee select = workers[index];
            if (select.GetType() == typeof(Supervisor))
            {
                string body = "Unit of change is $100\nSelect \'Yes\' to add to bonus\nSelec \'No\' to subtract from bonus\nSelect \'Cancel\' or close the window to cancel change";
                string title = "Change Bonus";
                MessageBoxButtons buttons = MessageBoxButtons.YesNoCancel;
                DialogResult result = MessageBox.Show(body, title, buttons);
                if (result == DialogResult.Yes)
                {
                    Supervisor check = ((Supervisor)select);
                    check++;
                }
                if (result == DialogResult.No)
                {
                    Supervisor check = ((Supervisor)select);
                    check--;
                }
                if (result == DialogResult.Cancel)
                {
                    this.Close();
                }
                updateList();
            }
            else
            {
                MessageBox.Show("Must Select Type: Supervisor for bonus function", "Supervisor not selected");
            }
        }
        /* name: btnCompare_Click
         * sent: none
         * return: none
         * description: Compares two balances based on user input
         */
        private void btnCompare_Click(object sender, EventArgs e)
        {
            int comboIndex = cboNames.SelectedIndex;
            Employee comboSelect = workers[comboIndex]; //selects the employee class object based on selected index
            int listIndex = lstEmployees.SelectedIndex;
            Employee listSelect = workers[listIndex];//selects the employee class object based on selected index
            if (comboIndex != listIndex)
            {
                if (listSelect > comboSelect) //if the first selection is greater than the second selection
                {
                    string oN1 = listSelect.Name;
                    string oN2 = comboSelect.Name;
                    string body = oN1 + " has more earnings than " + oN2;
                    string title = "Compare Earnings";
                    MessageBox.Show(body, title);
                }
                else
                {
                    string oN1 = listSelect.Name;
                    string oN2 = comboSelect.Name;
                    string body = oN2 + " has more earnings than " + oN1;
                    string title = "Compare Earnings";
                    MessageBox.Show(body, title);
                }
            }

        }
        /* name: Form1_FormClosing
         * sent: none
         * return: none
         * description: events that take place when the form is closed
         */
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            string title = "Confirm Close";
            string body = "Are you sure?";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(body, title, buttons);
            if (result == DialogResult.Yes)
            {
                this.Dispose();
            }
            else if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    } // end class
    public class Employee
    {
        //properties for the class
        public int ID;
        public string Name;
        public List<decimal> Earnings;
        public int PayCount;
        public DateTime StartDate;
        private static int nextID = 3000;
        protected const int MAXPAYS = 4;

        //default constructor - set default settings
        //called by custom in class and def from derived
        public Employee()
        {
            ID = nextID;
            nextID += 5;
            Earnings = new List<decimal>();
            PayCount = 0;
        }

        //custom constructor - calls base
        public Employee(string inName, DateTime inStartDate) : this()
        {
            //sets the properties
            Name = inName;
            StartDate = inStartDate;
            //makes variable or validating the Date
            DateTime Validation = new DateTime(2020, 01, 01);

            // sets date to a default if it is below 01-01-2020
            if (inStartDate < Validation)
                StartDate = Validation;
        }

        /* Name: DisplayData
        * Sent: None
        * Returned: String
        * Description: Sends object data formatted as a string in Columns */
        public virtual string DisplayData() =>
            // Returns a string formatted to fit columns
            string.Format("{0,-9}{1,-20}{2,-18:dd-MMM-yyyy}{3,-14}{4,-3}{5,13:c}",
                ID, Name, StartDate, GetType().Name, PayCount, Earnings.Sum());

        /* Name: Pay
         * Sent: Decimal
         * Returned: Boolean
         * Description: Receives an amount of money and checks to see if it is over a
         * certain amount and adds that money to earnings if true is returned, and
         * returns false if its under */
        public bool Pay(decimal amount)
        {
            //declares bool for validation
            bool validPay = false;
            const decimal MIN = 150M;

            //checks if amout sent is over 150
            if (amount > MIN && PayCount < MAXPAYS)
            {
                //adds amount to total earnings
                Earnings.Add(amount);
                //increases paycount
                PayCount += 1;
                //returns true 
                validPay = true;
            }
            //returns the validation result
            return validPay;
        }
        public static bool operator > (Employee A, Employee B)
        {
            if (A > B)
            {return true;}
            else
            {return false;}
        }
        public static bool operator < (Employee A, Employee B)
        {
            return !(A > B);
        }


    } // end Employee Class

    public class Supervisor : Employee   //create derived class form base
    {
        //property - initialized
        public decimal Bonus = 250M;

        //default - empty (calls base automatically)
        public Supervisor() { }

        //custom - calls base custom
        public Supervisor(string inName, DateTime inStartDate, decimal inBonus)
            : base(inName, inStartDate)
         => Bonus = inBonus < 100M ? 100M : inBonus;
            //use conditional operator to reset bonus

        public virtual bool Pay()
        {
            const int SupervisorPay = 875;
            if (PayCount < (MAXPAYS +2))
            {
                Earnings.Add(SupervisorPay);
                PayCount++;
                return true;
            }
            else
            {
                return false;
            }
            
        }

        /* Name: DisplayData
         * Sent: None
         * Returned: String
         * Description: Sends object data formatted as a string in Columns */
        public override string DisplayData() =>
            // calls base first then adds property from this class
            base.DisplayData() + String.Format("{0,10:c0}", Bonus);
        public static Supervisor operator ++ (Supervisor A)
        {
            A.Bonus += 100;
            return A;
        }
        public static Supervisor operator --(Supervisor A)
        {
            if (A.Bonus >=100)
            A.Bonus -= 100;
            return A;
        }
    } // end Supervisor
}

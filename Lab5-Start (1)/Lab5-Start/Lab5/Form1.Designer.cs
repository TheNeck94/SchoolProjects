
namespace Lab5
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.dtpStarted = new System.Windows.Forms.DateTimePicker();
            this.radSupervisor = new System.Windows.Forms.RadioButton();
            this.radEmployee = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboNames = new System.Windows.Forms.ComboBox();
            this.lstEmployees = new System.Windows.Forms.ListBox();
            this.btnBonus = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCompare = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.dtpStarted);
            this.groupBox1.Controls.Add(this.radSupervisor);
            this.groupBox1.Controls.Add(this.radEmployee);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(479, 159);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add Employee";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(312, 106);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(142, 40);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "&Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(121, 67);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(333, 36);
            this.txtName.TabIndex = 0;
            // 
            // dtpStarted
            // 
            this.dtpStarted.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStarted.Location = new System.Drawing.Point(121, 109);
            this.dtpStarted.Name = "dtpStarted";
            this.dtpStarted.Size = new System.Drawing.Size(171, 36);
            this.dtpStarted.TabIndex = 1;
            // 
            // radSupervisor
            // 
            this.radSupervisor.AutoSize = true;
            this.radSupervisor.Location = new System.Drawing.Point(312, 25);
            this.radSupervisor.Name = "radSupervisor";
            this.radSupervisor.Size = new System.Drawing.Size(158, 32);
            this.radSupervisor.TabIndex = 4;
            this.radSupervisor.TabStop = true;
            this.radSupervisor.Text = "Supervisor";
            this.radSupervisor.UseVisualStyleBackColor = true;
            // 
            // radEmployee
            // 
            this.radEmployee.AutoSize = true;
            this.radEmployee.Location = new System.Drawing.Point(21, 25);
            this.radEmployee.Name = "radEmployee";
            this.radEmployee.Size = new System.Drawing.Size(144, 32);
            this.radEmployee.TabIndex = 3;
            this.radEmployee.TabStop = true;
            this.radEmployee.Text = "Employee";
            this.radEmployee.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 28);
            this.label2.TabIndex = 1;
            this.label2.Text = "Started:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // cboNames
            // 
            this.cboNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNames.FormattingEnabled = true;
            this.cboNames.Location = new System.Drawing.Point(20, 41);
            this.cboNames.Name = "cboNames";
            this.cboNames.Size = new System.Drawing.Size(248, 36);
            this.cboNames.TabIndex = 1;
            // 
            // lstEmployees
            // 
            this.lstEmployees.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lstEmployees.Font = new System.Drawing.Font("Courier New", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstEmployees.FormattingEnabled = true;
            this.lstEmployees.ItemHeight = 23;
            this.lstEmployees.Location = new System.Drawing.Point(13, 203);
            this.lstEmployees.Name = "lstEmployees";
            this.lstEmployees.Size = new System.Drawing.Size(765, 257);
            this.lstEmployees.TabIndex = 2;
            this.lstEmployees.DoubleClick += new System.EventHandler(this.lstEmployees_DoubleClick);
            // 
            // btnBonus
            // 
            this.btnBonus.Location = new System.Drawing.Point(13, 497);
            this.btnBonus.Name = "btnBonus";
            this.btnBonus.Size = new System.Drawing.Size(142, 40);
            this.btnBonus.TabIndex = 3;
            this.btnBonus.Text = "&Bonus";
            this.btnBonus.UseVisualStyleBackColor = true;
            this.btnBonus.Click += new System.EventHandler(this.btnBonus_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(324, 497);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(142, 40);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCompare
            // 
            this.btnCompare.Location = new System.Drawing.Point(635, 497);
            this.btnCompare.Name = "btnCompare";
            this.btnCompare.Size = new System.Drawing.Size(142, 40);
            this.btnCompare.TabIndex = 5;
            this.btnCompare.Text = "&Compare";
            this.btnCompare.UseVisualStyleBackColor = true;
            this.btnCompare.Click += new System.EventHandler(this.btnCompare_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.groupBox2.Controls.Add(this.cboNames);
            this.groupBox2.Location = new System.Drawing.Point(497, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(296, 159);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Employee Names";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(676, 177);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 28);
            this.label9.TabIndex = 19;
            this.label9.Text = "Bonus";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(567, 177);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(109, 28);
            this.label8.TabIndex = 18;
            this.label8.Text = "Earnings";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(487, 177);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 28);
            this.label7.TabIndex = 17;
            this.label7.Text = "Paid";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(394, 177);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 28);
            this.label6.TabIndex = 16;
            this.label6.Text = "Type";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(250, 177);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 28);
            this.label5.TabIndex = 15;
            this.label5.Text = "Start Date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(103, 177);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 28);
            this.label4.TabIndex = 14;
            this.label4.Text = "Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 28);
            this.label3.TabIndex = 13;
            this.label3.Text = "ID";
            // 
            // Form1
            // 
            this.AcceptButton = this.btnAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 558);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnCompare);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnBonus);
            this.Controls.Add(this.lstEmployees);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lab5 by Brady Walsh";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.DateTimePicker dtpStarted;
        private System.Windows.Forms.RadioButton radSupervisor;
        private System.Windows.Forms.RadioButton radEmployee;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboNames;
        private System.Windows.Forms.ListBox lstEmployees;
        private System.Windows.Forms.Button btnBonus;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCompare;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}



namespace Walsh_Lab2
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
            this.lblPetName = new System.Windows.Forms.Label();
            this.txtPetName = new System.Windows.Forms.TextBox();
            this.lblAge = new System.Windows.Forms.Label();
            this.nudAge = new System.Windows.Forms.NumericUpDown();
            this.grpbxType = new System.Windows.Forms.GroupBox();
            this.radBird = new System.Windows.Forms.RadioButton();
            this.radCat = new System.Windows.Forms.RadioButton();
            this.radDog = new System.Windows.Forms.RadioButton();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lstOutput = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudAge)).BeginInit();
            this.grpbxType.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblPetName
            // 
            this.lblPetName.AutoSize = true;
            this.lblPetName.Location = new System.Drawing.Point(20, 19);
            this.lblPetName.Name = "lblPetName";
            this.lblPetName.Size = new System.Drawing.Size(80, 19);
            this.lblPetName.TabIndex = 0;
            this.lblPetName.Text = "Pet Name:";
            // 
            // txtPetName
            // 
            this.txtPetName.Location = new System.Drawing.Point(108, 19);
            this.txtPetName.Name = "txtPetName";
            this.txtPetName.Size = new System.Drawing.Size(116, 27);
            this.txtPetName.TabIndex = 1;
            // 
            // lblAge
            // 
            this.lblAge.AutoSize = true;
            this.lblAge.Location = new System.Drawing.Point(24, 55);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(43, 19);
            this.lblAge.TabIndex = 2;
            this.lblAge.Text = "Age: ";
            // 
            // nudAge
            // 
            this.nudAge.Location = new System.Drawing.Point(106, 61);
            this.nudAge.Name = "nudAge";
            this.nudAge.Size = new System.Drawing.Size(117, 27);
            this.nudAge.TabIndex = 3;
            // 
            // grpbxType
            // 
            this.grpbxType.Controls.Add(this.radDog);
            this.grpbxType.Controls.Add(this.radCat);
            this.grpbxType.Controls.Add(this.radBird);
            this.grpbxType.Location = new System.Drawing.Point(25, 118);
            this.grpbxType.Name = "grpbxType";
            this.grpbxType.Size = new System.Drawing.Size(81, 119);
            this.grpbxType.TabIndex = 4;
            this.grpbxType.TabStop = false;
            this.grpbxType.Text = "Type";
            // 
            // radBird
            // 
            this.radBird.AutoSize = true;
            this.radBird.Location = new System.Drawing.Point(6, 26);
            this.radBird.Name = "radBird";
            this.radBird.Size = new System.Drawing.Size(55, 23);
            this.radBird.TabIndex = 0;
            this.radBird.TabStop = true;
            this.radBird.Text = "Bird";
            this.radBird.UseVisualStyleBackColor = true;
            // 
            // radCat
            // 
            this.radCat.AutoSize = true;
            this.radCat.Location = new System.Drawing.Point(6, 58);
            this.radCat.Name = "radCat";
            this.radCat.Size = new System.Drawing.Size(49, 23);
            this.radCat.TabIndex = 1;
            this.radCat.TabStop = true;
            this.radCat.Text = "Cat";
            this.radCat.UseVisualStyleBackColor = true;
            // 
            // radDog
            // 
            this.radDog.AutoSize = true;
            this.radDog.Location = new System.Drawing.Point(6, 90);
            this.radDog.Name = "radDog";
            this.radDog.Size = new System.Drawing.Size(54, 23);
            this.radDog.TabIndex = 2;
            this.radDog.TabStop = true;
            this.radDog.Text = "Dog";
            this.radDog.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(124, 132);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(108, 26);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(124, 204);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(108, 26);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "&Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.button1_Click);
            // 
            // lstOutput
            // 
            this.lstOutput.FormattingEnabled = true;
            this.lstOutput.ItemHeight = 19;
            this.lstOutput.Location = new System.Drawing.Point(277, 20);
            this.lstOutput.Name = "lstOutput";
            this.lstOutput.Size = new System.Drawing.Size(314, 213);
            this.lstOutput.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 254);
            this.Controls.Add(this.lstOutput);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.grpbxType);
            this.Controls.Add(this.nudAge);
            this.Controls.Add(this.lblAge);
            this.Controls.Add(this.txtPetName);
            this.Controls.Add(this.lblPetName);
            this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.nudAge)).EndInit();
            this.grpbxType.ResumeLayout(false);
            this.grpbxType.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPetName;
        private System.Windows.Forms.TextBox txtPetName;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.NumericUpDown nudAge;
        private System.Windows.Forms.GroupBox grpbxType;
        private System.Windows.Forms.RadioButton radDog;
        private System.Windows.Forms.RadioButton radCat;
        private System.Windows.Forms.RadioButton radBird;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ListBox lstOutput;
    }
}


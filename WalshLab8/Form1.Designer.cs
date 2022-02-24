
namespace WalshLab8
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
            this.grpSelect = new System.Windows.Forms.GroupBox();
            this.chkFormula = new System.Windows.Forms.CheckBox();
            this.chkAnalysis = new System.Windows.Forms.CheckBox();
            this.grpFormula = new System.Windows.Forms.GroupBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.nudTotal = new System.Windows.Forms.NumericUpDown();
            this.lblSelect = new System.Windows.Forms.Label();
            this.nudSelect = new System.Windows.Forms.NumericUpDown();
            this.radPermutation = new System.Windows.Forms.RadioButton();
            this.radCombo = new System.Windows.Forms.RadioButton();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.lblAnswer = new System.Windows.Forms.Label();
            this.lblAnswerOutput = new System.Windows.Forms.Label();
            this.grpAnalysis = new System.Windows.Forms.GroupBox();
            this.lblClassrooms = new System.Windows.Forms.Label();
            this.lblSum = new System.Windows.Forms.Label();
            this.lblSumOutput = new System.Windows.Forms.Label();
            this.lblAverage = new System.Windows.Forms.Label();
            this.lblAverageOutput = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.lstClassSize = new System.Windows.Forms.ListBox();
            this.txtClassroom = new System.Windows.Forms.TextBox();
            this.picbox = new System.Windows.Forms.PictureBox();
            this.grpSelect.SuspendLayout();
            this.grpFormula.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSelect)).BeginInit();
            this.grpAnalysis.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbox)).BeginInit();
            this.SuspendLayout();
            // 
            // grpSelect
            // 
            this.grpSelect.Controls.Add(this.chkAnalysis);
            this.grpSelect.Controls.Add(this.chkFormula);
            this.grpSelect.Location = new System.Drawing.Point(17, 18);
            this.grpSelect.Name = "grpSelect";
            this.grpSelect.Size = new System.Drawing.Size(646, 105);
            this.grpSelect.TabIndex = 0;
            this.grpSelect.TabStop = false;
            this.grpSelect.Text = "Select From...";
            // 
            // chkFormula
            // 
            this.chkFormula.AutoSize = true;
            this.chkFormula.Location = new System.Drawing.Point(67, 46);
            this.chkFormula.Name = "chkFormula";
            this.chkFormula.Size = new System.Drawing.Size(84, 23);
            this.chkFormula.TabIndex = 1;
            this.chkFormula.Text = "Formula";
            this.chkFormula.UseVisualStyleBackColor = true;
            this.chkFormula.CheckedChanged += new System.EventHandler(this.chkFormula_CheckedChanged);
            // 
            // chkAnalysis
            // 
            this.chkAnalysis.AutoSize = true;
            this.chkAnalysis.Location = new System.Drawing.Point(437, 43);
            this.chkAnalysis.Name = "chkAnalysis";
            this.chkAnalysis.Size = new System.Drawing.Size(83, 23);
            this.chkAnalysis.TabIndex = 2;
            this.chkAnalysis.Text = "Analysis";
            this.chkAnalysis.UseVisualStyleBackColor = true;
            this.chkAnalysis.CheckedChanged += new System.EventHandler(this.chkAnalysis_CheckedChanged);
            // 
            // grpFormula
            // 
            this.grpFormula.Controls.Add(this.picbox);
            this.grpFormula.Controls.Add(this.lblAnswerOutput);
            this.grpFormula.Controls.Add(this.lblAnswer);
            this.grpFormula.Controls.Add(this.btnReset);
            this.grpFormula.Controls.Add(this.btnCalculate);
            this.grpFormula.Controls.Add(this.radCombo);
            this.grpFormula.Controls.Add(this.radPermutation);
            this.grpFormula.Controls.Add(this.nudSelect);
            this.grpFormula.Controls.Add(this.lblSelect);
            this.grpFormula.Controls.Add(this.nudTotal);
            this.grpFormula.Controls.Add(this.lblTotal);
            this.grpFormula.Location = new System.Drawing.Point(20, 137);
            this.grpFormula.Name = "grpFormula";
            this.grpFormula.Size = new System.Drawing.Size(317, 268);
            this.grpFormula.TabIndex = 25;
            this.grpFormula.TabStop = false;
            this.grpFormula.Text = "Formula";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(22, 51);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(43, 19);
            this.lblTotal.TabIndex = 25;
            this.lblTotal.Text = "Total";
            // 
            // nudTotal
            // 
            this.nudTotal.Location = new System.Drawing.Point(92, 48);
            this.nudTotal.Name = "nudTotal";
            this.nudTotal.Size = new System.Drawing.Size(92, 27);
            this.nudTotal.TabIndex = 3;
            // 
            // lblSelect
            // 
            this.lblSelect.AutoSize = true;
            this.lblSelect.Location = new System.Drawing.Point(20, 91);
            this.lblSelect.Name = "lblSelect";
            this.lblSelect.Size = new System.Drawing.Size(50, 19);
            this.lblSelect.TabIndex = 25;
            this.lblSelect.Text = "Select";
            // 
            // nudSelect
            // 
            this.nudSelect.Location = new System.Drawing.Point(92, 91);
            this.nudSelect.Name = "nudSelect";
            this.nudSelect.Size = new System.Drawing.Size(91, 27);
            this.nudSelect.TabIndex = 4;
            // 
            // radPermutation
            // 
            this.radPermutation.AutoSize = true;
            this.radPermutation.Location = new System.Drawing.Point(15, 146);
            this.radPermutation.Name = "radPermutation";
            this.radPermutation.Size = new System.Drawing.Size(113, 23);
            this.radPermutation.TabIndex = 5;
            this.radPermutation.TabStop = true;
            this.radPermutation.Text = "Permutation";
            this.radPermutation.UseVisualStyleBackColor = true;
            this.radPermutation.CheckedChanged += new System.EventHandler(this.radPermutation_CheckedChanged);
            // 
            // radCombo
            // 
            this.radCombo.AutoSize = true;
            this.radCombo.Location = new System.Drawing.Point(15, 192);
            this.radCombo.Name = "radCombo";
            this.radCombo.Size = new System.Drawing.Size(119, 23);
            this.radCombo.TabIndex = 6;
            this.radCombo.TabStop = true;
            this.radCombo.Text = "Combonation";
            this.radCombo.UseVisualStyleBackColor = true;
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(14, 228);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(94, 27);
            this.btnCalculate.TabIndex = 7;
            this.btnCalculate.Text = "&Calculate";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(176, 227);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(108, 27);
            this.btnReset.TabIndex = 8;
            this.btnReset.Text = "&Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // lblAnswer
            // 
            this.lblAnswer.AutoSize = true;
            this.lblAnswer.Location = new System.Drawing.Point(173, 151);
            this.lblAnswer.Name = "lblAnswer";
            this.lblAnswer.Size = new System.Drawing.Size(60, 19);
            this.lblAnswer.TabIndex = 85;
            this.lblAnswer.Text = "Answer";
            // 
            // lblAnswerOutput
            // 
            this.lblAnswerOutput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAnswerOutput.Location = new System.Drawing.Point(169, 183);
            this.lblAnswerOutput.Name = "lblAnswerOutput";
            this.lblAnswerOutput.Size = new System.Drawing.Size(114, 31);
            this.lblAnswerOutput.TabIndex = 95;
            // 
            // grpAnalysis
            // 
            this.grpAnalysis.Controls.Add(this.txtClassroom);
            this.grpAnalysis.Controls.Add(this.lstClassSize);
            this.grpAnalysis.Controls.Add(this.btnGenerate);
            this.grpAnalysis.Controls.Add(this.lblAverageOutput);
            this.grpAnalysis.Controls.Add(this.lblAverage);
            this.grpAnalysis.Controls.Add(this.lblSumOutput);
            this.grpAnalysis.Controls.Add(this.lblSum);
            this.grpAnalysis.Controls.Add(this.lblClassrooms);
            this.grpAnalysis.Location = new System.Drawing.Point(359, 140);
            this.grpAnalysis.Name = "grpAnalysis";
            this.grpAnalysis.Size = new System.Drawing.Size(303, 251);
            this.grpAnalysis.TabIndex = 25;
            this.grpAnalysis.TabStop = false;
            this.grpAnalysis.Text = "Analysis";
            // 
            // lblClassrooms
            // 
            this.lblClassrooms.AutoSize = true;
            this.lblClassrooms.Location = new System.Drawing.Point(17, 30);
            this.lblClassrooms.Name = "lblClassrooms";
            this.lblClassrooms.Size = new System.Drawing.Size(84, 19);
            this.lblClassrooms.TabIndex = 50;
            this.lblClassrooms.Text = "Classrooms";
            // 
            // lblSum
            // 
            this.lblSum.AutoSize = true;
            this.lblSum.Location = new System.Drawing.Point(27, 107);
            this.lblSum.Name = "lblSum";
            this.lblSum.Size = new System.Drawing.Size(39, 19);
            this.lblSum.TabIndex = 50;
            this.lblSum.Text = "Sum";
            // 
            // lblSumOutput
            // 
            this.lblSumOutput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSumOutput.Location = new System.Drawing.Point(110, 105);
            this.lblSumOutput.Name = "lblSumOutput";
            this.lblSumOutput.Size = new System.Drawing.Size(93, 20);
            this.lblSumOutput.TabIndex = 25;
            // 
            // lblAverage
            // 
            this.lblAverage.AutoSize = true;
            this.lblAverage.Location = new System.Drawing.Point(15, 155);
            this.lblAverage.Name = "lblAverage";
            this.lblAverage.Size = new System.Drawing.Size(65, 19);
            this.lblAverage.TabIndex = 45;
            this.lblAverage.Text = "Average";
            // 
            // lblAverageOutput
            // 
            this.lblAverageOutput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAverageOutput.Location = new System.Drawing.Point(111, 148);
            this.lblAverageOutput.Name = "lblAverageOutput";
            this.lblAverageOutput.Size = new System.Drawing.Size(91, 25);
            this.lblAverageOutput.TabIndex = 55;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(80, 206);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(132, 29);
            this.btnGenerate.TabIndex = 10;
            this.btnGenerate.Text = "&Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // lstClassSize
            // 
            this.lstClassSize.FormattingEnabled = true;
            this.lstClassSize.ItemHeight = 19;
            this.lstClassSize.Location = new System.Drawing.Point(217, 28);
            this.lstClassSize.Name = "lstClassSize";
            this.lstClassSize.Size = new System.Drawing.Size(76, 194);
            this.lstClassSize.TabIndex = 7;
            this.lstClassSize.TabStop = false;
            // 
            // txtClassroom
            // 
            this.txtClassroom.Location = new System.Drawing.Point(117, 29);
            this.txtClassroom.Name = "txtClassroom";
            this.txtClassroom.Size = new System.Drawing.Size(84, 27);
            this.txtClassroom.TabIndex = 9;
            // 
            // picbox
            // 
            this.picbox.Location = new System.Drawing.Point(201, 59);
            this.picbox.Name = "picbox";
            this.picbox.Size = new System.Drawing.Size(96, 58);
            this.picbox.TabIndex = 96;
            this.picbox.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 411);
            this.Controls.Add(this.grpAnalysis);
            this.Controls.Add(this.grpFormula);
            this.Controls.Add(this.grpSelect);
            this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Last Lab by";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grpSelect.ResumeLayout(false);
            this.grpSelect.PerformLayout();
            this.grpFormula.ResumeLayout(false);
            this.grpFormula.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSelect)).EndInit();
            this.grpAnalysis.ResumeLayout(false);
            this.grpAnalysis.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpSelect;
        private System.Windows.Forms.CheckBox chkAnalysis;
        private System.Windows.Forms.CheckBox chkFormula;
        private System.Windows.Forms.GroupBox grpFormula;
        private System.Windows.Forms.Label lblAnswerOutput;
        private System.Windows.Forms.Label lblAnswer;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.RadioButton radCombo;
        private System.Windows.Forms.RadioButton radPermutation;
        private System.Windows.Forms.NumericUpDown nudSelect;
        private System.Windows.Forms.Label lblSelect;
        private System.Windows.Forms.NumericUpDown nudTotal;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.GroupBox grpAnalysis;
        private System.Windows.Forms.TextBox txtClassroom;
        private System.Windows.Forms.ListBox lstClassSize;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Label lblAverageOutput;
        private System.Windows.Forms.Label lblAverage;
        private System.Windows.Forms.Label lblSumOutput;
        private System.Windows.Forms.Label lblSum;
        private System.Windows.Forms.Label lblClassrooms;
        private System.Windows.Forms.PictureBox picbox;
    }
}


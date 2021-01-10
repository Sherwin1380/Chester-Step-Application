namespace Heart_Rate_Krzysztof_Oko
{
    partial class Form2
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
            this.BTNAdd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TesterName = new System.Windows.Forms.TextBox();
            this.StepHeight = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // BTNAdd
            // 
            this.BTNAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.BTNAdd.Location = new System.Drawing.Point(147, 203);
            this.BTNAdd.Name = "BTNAdd";
            this.BTNAdd.Size = new System.Drawing.Size(75, 35);
            this.BTNAdd.TabIndex = 0;
            this.BTNAdd.Text = "Start";
            this.BTNAdd.UseVisualStyleBackColor = true;
            this.BTNAdd.Click += new System.EventHandler(this.BTNAdd_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(58, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Step Height :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(47, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tester Name :";
            // 
            // TesterName
            // 
            this.TesterName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.TesterName.Location = new System.Drawing.Point(182, 49);
            this.TesterName.Name = "TesterName";
            this.TesterName.Size = new System.Drawing.Size(137, 29);
            this.TesterName.TabIndex = 3;
            this.TesterName.Text = "Sherwin";
            // 
            // StepHeight
            // 
            this.StepHeight.AutoCompleteCustomSource.AddRange(new string[] {
            "15",
            "20"});
            this.StepHeight.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.StepHeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.StepHeight.FormattingEnabled = true;
            this.StepHeight.Items.AddRange(new object[] {
            "15",
            "20",
            "25",
            "30"});
            this.StepHeight.Location = new System.Drawing.Point(182, 99);
            this.StepHeight.Name = "StepHeight";
            this.StepHeight.Size = new System.Drawing.Size(55, 32);
            this.StepHeight.TabIndex = 4;
            this.StepHeight.Text = "25";
            this.StepHeight.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 269);
            this.Controls.Add(this.StepHeight);
            this.Controls.Add(this.TesterName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BTNAdd);
            this.Name = "Form2";
            this.Text = "Step Calculator - Krzysztof Oko";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BTNAdd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TesterName;
        private System.Windows.Forms.ComboBox StepHeight;
    }
}
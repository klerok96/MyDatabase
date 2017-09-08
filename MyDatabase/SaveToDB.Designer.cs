namespace MyDatabase
{
    partial class SaveToDB
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.TextBoxCarName = new System.Windows.Forms.TextBox();
            this.TextBoxCost = new System.Windows.Forms.TextBox();
            this.TextBoxPower = new System.Windows.Forms.TextBox();
            this.TextBoxConsumption = new System.Windows.Forms.TextBox();
            this.ComboBoxColor = new System.Windows.Forms.ComboBox();
            this.ComboBoxDiskName = new System.Windows.Forms.ComboBox();
            this.BtnSaveToDB = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(68, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Cost";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(57, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Power";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Consumption";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(63, 148);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Color";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(69, 178);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 17);
            this.label6.TabIndex = 5;
            this.label6.Text = "Disk";
            // 
            // TextBoxCarName
            // 
            this.TextBoxCarName.Location = new System.Drawing.Point(110, 29);
            this.TextBoxCarName.Name = "TextBoxCarName";
            this.TextBoxCarName.Size = new System.Drawing.Size(100, 22);
            this.TextBoxCarName.TabIndex = 6;
            // 
            // TextBoxCost
            // 
            this.TextBoxCost.Location = new System.Drawing.Point(110, 57);
            this.TextBoxCost.Name = "TextBoxCost";
            this.TextBoxCost.Size = new System.Drawing.Size(100, 22);
            this.TextBoxCost.TabIndex = 7;
            // 
            // TextBoxPower
            // 
            this.TextBoxPower.Location = new System.Drawing.Point(110, 89);
            this.TextBoxPower.Name = "TextBoxPower";
            this.TextBoxPower.Size = new System.Drawing.Size(100, 22);
            this.TextBoxPower.TabIndex = 8;
            // 
            // TextBoxConsumption
            // 
            this.TextBoxConsumption.Location = new System.Drawing.Point(110, 117);
            this.TextBoxConsumption.Name = "TextBoxConsumption";
            this.TextBoxConsumption.Size = new System.Drawing.Size(100, 22);
            this.TextBoxConsumption.TabIndex = 9;
            // 
            // ComboBoxColor
            // 
            this.ComboBoxColor.FormattingEnabled = true;
            this.ComboBoxColor.Location = new System.Drawing.Point(110, 145);
            this.ComboBoxColor.Name = "ComboBoxColor";
            this.ComboBoxColor.Size = new System.Drawing.Size(121, 24);
            this.ComboBoxColor.TabIndex = 10;
            // 
            // ComboBoxDiskName
            // 
            this.ComboBoxDiskName.FormattingEnabled = true;
            this.ComboBoxDiskName.Location = new System.Drawing.Point(110, 175);
            this.ComboBoxDiskName.Name = "ComboBoxDiskName";
            this.ComboBoxDiskName.Size = new System.Drawing.Size(121, 24);
            this.ComboBoxDiskName.TabIndex = 11;
            // 
            // BtnSaveToDB
            // 
            this.BtnSaveToDB.Location = new System.Drawing.Point(123, 233);
            this.BtnSaveToDB.Name = "BtnSaveToDB";
            this.BtnSaveToDB.Size = new System.Drawing.Size(75, 23);
            this.BtnSaveToDB.TabIndex = 12;
            this.BtnSaveToDB.Text = "Save";
            this.BtnSaveToDB.UseVisualStyleBackColor = true;
            this.BtnSaveToDB.Click += new System.EventHandler(this.BtnSaveToDB_Click);
            // 
            // SaveToDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 310);
            this.Controls.Add(this.BtnSaveToDB);
            this.Controls.Add(this.ComboBoxDiskName);
            this.Controls.Add(this.ComboBoxColor);
            this.Controls.Add(this.TextBoxConsumption);
            this.Controls.Add(this.TextBoxPower);
            this.Controls.Add(this.TextBoxCost);
            this.Controls.Add(this.TextBoxCarName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "SaveToDB";
            this.Text = "Save to DB";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TextBoxCarName;
        private System.Windows.Forms.TextBox TextBoxCost;
        private System.Windows.Forms.TextBox TextBoxPower;
        private System.Windows.Forms.TextBox TextBoxConsumption;
        private System.Windows.Forms.ComboBox ComboBoxColor;
        private System.Windows.Forms.ComboBox ComboBoxDiskName;
        private System.Windows.Forms.Button BtnSaveToDB;
    }
}
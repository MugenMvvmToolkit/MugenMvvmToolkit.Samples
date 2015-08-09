namespace Validation.WinForms.Views
{
    partial class DataAnnotationView
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
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.customErrorTextBox = new System.Windows.Forms.TextBox();
            this.validLabel = new System.Windows.Forms.Label();
            this.notValidLabel = new System.Windows.Forms.Label();
            this.nameErrorLabel = new System.Windows.Forms.Label();
            this.descErrorLabel = new System.Windows.Forms.Label();
            this.summaryLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nameTextBox.Location = new System.Drawing.Point(12, 25);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(414, 20);
            this.nameTextBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Description";
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(263, 69);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(163, 17);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "Disable description validation";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.descriptionTextBox.Location = new System.Drawing.Point(12, 86);
            this.descriptionTextBox.Multiline = true;
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(414, 81);
            this.descriptionTextBox.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 190);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(232, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Enter a custom error for the Description property";
            // 
            // customErrorTextBox
            // 
            this.customErrorTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.customErrorTextBox.Location = new System.Drawing.Point(12, 206);
            this.customErrorTextBox.Name = "customErrorTextBox";
            this.customErrorTextBox.Size = new System.Drawing.Size(414, 20);
            this.customErrorTextBox.TabIndex = 6;
            // 
            // validLabel
            // 
            this.validLabel.AutoSize = true;
            this.validLabel.ForeColor = System.Drawing.Color.Green;
            this.validLabel.Location = new System.Drawing.Point(12, 238);
            this.validLabel.Name = "validLabel";
            this.validLabel.Size = new System.Drawing.Size(96, 13);
            this.validLabel.TabIndex = 8;
            this.validLabel.Text = "View model is valid";
            // 
            // notValidLabel
            // 
            this.notValidLabel.AutoSize = true;
            this.notValidLabel.ForeColor = System.Drawing.Color.Red;
            this.notValidLabel.Location = new System.Drawing.Point(12, 238);
            this.notValidLabel.Name = "notValidLabel";
            this.notValidLabel.Size = new System.Drawing.Size(114, 13);
            this.notValidLabel.TabIndex = 9;
            this.notValidLabel.Text = "View model is not valid";
            // 
            // nameErrorLabel
            // 
            this.nameErrorLabel.AutoSize = true;
            this.nameErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.nameErrorLabel.Location = new System.Drawing.Point(12, 48);
            this.nameErrorLabel.Name = "nameErrorLabel";
            this.nameErrorLabel.Size = new System.Drawing.Size(35, 13);
            this.nameErrorLabel.TabIndex = 10;
            this.nameErrorLabel.Text = "label4";
            // 
            // descErrorLabel
            // 
            this.descErrorLabel.AutoSize = true;
            this.descErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.descErrorLabel.Location = new System.Drawing.Point(12, 170);
            this.descErrorLabel.Name = "descErrorLabel";
            this.descErrorLabel.Size = new System.Drawing.Size(35, 13);
            this.descErrorLabel.TabIndex = 11;
            this.descErrorLabel.Text = "label5";
            // 
            // summaryLabel
            // 
            this.summaryLabel.AutoSize = true;
            this.summaryLabel.ForeColor = System.Drawing.Color.Red;
            this.summaryLabel.Location = new System.Drawing.Point(12, 263);
            this.summaryLabel.Name = "summaryLabel";
            this.summaryLabel.Size = new System.Drawing.Size(35, 13);
            this.summaryLabel.TabIndex = 12;
            this.summaryLabel.Text = "label4";
            // 
            // DataAnnotationView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 316);
            this.Controls.Add(this.summaryLabel);
            this.Controls.Add(this.descErrorLabel);
            this.Controls.Add(this.nameErrorLabel);
            this.Controls.Add(this.notValidLabel);
            this.Controls.Add(this.validLabel);
            this.Controls.Add(this.customErrorTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.descriptionTextBox);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.label1);
            this.Name = "DataAnnotationView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mugen MVVM Application";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox customErrorTextBox;
        private System.Windows.Forms.Label validLabel;
        private System.Windows.Forms.Label notValidLabel;
        private System.Windows.Forms.Label descErrorLabel;
        private System.Windows.Forms.Label nameErrorLabel;
        private System.Windows.Forms.Label summaryLabel;
    }
}
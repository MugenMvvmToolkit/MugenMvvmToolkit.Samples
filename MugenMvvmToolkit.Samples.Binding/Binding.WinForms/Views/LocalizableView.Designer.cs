namespace Binding.WinForms.Views
{
    partial class LocalizableView
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
            this.addLabel = new System.Windows.Forms.Label();
            this.editLabel = new System.Windows.Forms.Label();
            this.delLabel = new System.Windows.Forms.Label();
            this.cultureComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // addLabel
            // 
            this.addLabel.AutoSize = true;
            this.addLabel.Location = new System.Drawing.Point(12, 9);
            this.addLabel.Name = "addLabel";
            this.addLabel.Size = new System.Drawing.Size(35, 13);
            this.addLabel.TabIndex = 0;
            this.addLabel.Text = "label1";
            // 
            // editLabel
            // 
            this.editLabel.AutoSize = true;
            this.editLabel.Location = new System.Drawing.Point(12, 31);
            this.editLabel.Name = "editLabel";
            this.editLabel.Size = new System.Drawing.Size(35, 13);
            this.editLabel.TabIndex = 1;
            this.editLabel.Text = "label2";
            // 
            // delLabel
            // 
            this.delLabel.AutoSize = true;
            this.delLabel.Location = new System.Drawing.Point(12, 55);
            this.delLabel.Name = "delLabel";
            this.delLabel.Size = new System.Drawing.Size(35, 13);
            this.delLabel.TabIndex = 2;
            this.delLabel.Text = "label3";
            // 
            // cultureComboBox
            // 
            this.cultureComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cultureComboBox.FormattingEnabled = true;
            this.cultureComboBox.Location = new System.Drawing.Point(15, 83);
            this.cultureComboBox.Name = "cultureComboBox";
            this.cultureComboBox.Size = new System.Drawing.Size(305, 21);
            this.cultureComboBox.TabIndex = 3;
            // 
            // LocalizableView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 144);
            this.Controls.Add(this.cultureComboBox);
            this.Controls.Add(this.delLabel);
            this.Controls.Add(this.editLabel);
            this.Controls.Add(this.addLabel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LocalizableView";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mugen MVVM Application";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label addLabel;
        private System.Windows.Forms.Label editLabel;
        private System.Windows.Forms.Label delLabel;
        private System.Windows.Forms.ComboBox cultureComboBox;
    }
}
namespace Validation.WinForms.Views
{
    partial class MainView
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
            this.dataAnnotButton = new System.Windows.Forms.Button();
            this.validatorButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dataAnnotButton
            // 
            this.dataAnnotButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataAnnotButton.Location = new System.Drawing.Point(12, 12);
            this.dataAnnotButton.Name = "dataAnnotButton";
            this.dataAnnotButton.Size = new System.Drawing.Size(435, 23);
            this.dataAnnotButton.TabIndex = 0;
            this.dataAnnotButton.Text = "Validation using data annotations";
            this.dataAnnotButton.UseVisualStyleBackColor = true;
            // 
            // validatorButton
            // 
            this.validatorButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.validatorButton.Location = new System.Drawing.Point(12, 41);
            this.validatorButton.Name = "validatorButton";
            this.validatorButton.Size = new System.Drawing.Size(435, 23);
            this.validatorButton.TabIndex = 1;
            this.validatorButton.Text = "Validation using validators";
            this.validatorButton.UseVisualStyleBackColor = true;
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 321);
            this.Controls.Add(this.validatorButton);
            this.Controls.Add(this.dataAnnotButton);
            this.Name = "MainView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mugen MVVM Application";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button dataAnnotButton;
        private System.Windows.Forms.Button validatorButton;
    }
}


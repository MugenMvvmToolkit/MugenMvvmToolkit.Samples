namespace Navigation.WinForms.Views
{
    partial class MainForm
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
            this.dialogBtn = new System.Windows.Forms.Button();
            this.resultBtn = new System.Windows.Forms.Button();
            this.tabsBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dialogBtn
            // 
            this.dialogBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dialogBtn.Location = new System.Drawing.Point(12, 12);
            this.dialogBtn.Name = "dialogBtn";
            this.dialogBtn.Size = new System.Drawing.Size(560, 23);
            this.dialogBtn.TabIndex = 0;
            this.dialogBtn.Text = "Dialog Navigation";
            this.dialogBtn.UseVisualStyleBackColor = true;
            // 
            // resultBtn
            // 
            this.resultBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resultBtn.Location = new System.Drawing.Point(12, 41);
            this.resultBtn.Name = "resultBtn";
            this.resultBtn.Size = new System.Drawing.Size(560, 23);
            this.resultBtn.TabIndex = 1;
            this.resultBtn.Text = "View Model With Result";
            this.resultBtn.UseVisualStyleBackColor = true;
            // 
            // tabsBtn
            // 
            this.tabsBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabsBtn.Location = new System.Drawing.Point(12, 70);
            this.tabsBtn.Name = "tabsBtn";
            this.tabsBtn.Size = new System.Drawing.Size(560, 23);
            this.tabsBtn.TabIndex = 2;
            this.tabsBtn.Text = "Tabs Navigation";
            this.tabsBtn.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 313);
            this.Controls.Add(this.tabsBtn);
            this.Controls.Add(this.resultBtn);
            this.Controls.Add(this.dialogBtn);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mugen MVVM Application";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button dialogBtn;
        private System.Windows.Forms.Button resultBtn;
        private System.Windows.Forms.Button tabsBtn;
    }
}


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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.navigationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.firstViewModelWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.firstViewModelTabToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.secondViewModelWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.secondViewModelTabToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Location = new System.Drawing.Point(0, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(584, 284);
            this.tabControl1.TabIndex = 4;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.navigationToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(584, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // navigationToolStripMenuItem
            // 
            this.navigationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.firstViewModelWindowToolStripMenuItem,
            this.firstViewModelTabToolStripMenuItem,
            this.secondViewModelWindowToolStripMenuItem,
            this.secondViewModelTabToolStripMenuItem});
            this.navigationToolStripMenuItem.Name = "navigationToolStripMenuItem";
            this.navigationToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.navigationToolStripMenuItem.Text = "Navigation";
            // 
            // firstViewModelWindowToolStripMenuItem
            // 
            this.firstViewModelWindowToolStripMenuItem.Name = "firstViewModelWindowToolStripMenuItem";
            this.firstViewModelWindowToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.firstViewModelWindowToolStripMenuItem.Text = "First view model (Window)";
            // 
            // firstViewModelTabToolStripMenuItem
            // 
            this.firstViewModelTabToolStripMenuItem.Name = "firstViewModelTabToolStripMenuItem";
            this.firstViewModelTabToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.firstViewModelTabToolStripMenuItem.Text = "First view model (Tab)";
            // 
            // secondViewModelWindowToolStripMenuItem
            // 
            this.secondViewModelWindowToolStripMenuItem.Name = "secondViewModelWindowToolStripMenuItem";
            this.secondViewModelWindowToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.secondViewModelWindowToolStripMenuItem.Text = "Second view model (Window)";
            // 
            // secondViewModelTabToolStripMenuItem
            // 
            this.secondViewModelTabToolStripMenuItem.Name = "secondViewModelTabToolStripMenuItem";
            this.secondViewModelTabToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.secondViewModelTabToolStripMenuItem.Text = "Second view model (Tab)";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 313);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mugen MVVM Application";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem navigationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem firstViewModelWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem firstViewModelTabToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem secondViewModelWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem secondViewModelTabToolStripMenuItem;
    }
}


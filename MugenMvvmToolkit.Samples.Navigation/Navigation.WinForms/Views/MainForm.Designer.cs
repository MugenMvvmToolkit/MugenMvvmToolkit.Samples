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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.viewBinder = new Navigation.WinForms.ViewBinder(this.components);
            this.firstWindowBtn = new System.Windows.Forms.Button();
            this.secondWindowBtn = new System.Windows.Forms.Button();
            this.firstTabBtn = new System.Windows.Forms.Button();
            this.secondTabBtn = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            ((System.ComponentModel.ISupportInitialize)(this.viewBinder)).BeginInit();
            this.SuspendLayout();
            // 
            // viewBinder
            // 
            this.viewBinder.Bindings = resources.GetString("viewBinder.Bindings");
            this.viewBinder.ContainerControl = this;
            this.viewBinder.IgnoreControlException = true;
            this.viewBinder.RootTagName = "Bindings";
            // 
            // firstWindowBtn
            // 
            this.firstWindowBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.firstWindowBtn.Location = new System.Drawing.Point(12, 21);
            this.firstWindowBtn.Name = "firstWindowBtn";
            this.firstWindowBtn.Size = new System.Drawing.Size(560, 23);
            this.firstWindowBtn.TabIndex = 0;
            this.firstWindowBtn.Text = "First view model (Window)";
            this.firstWindowBtn.UseVisualStyleBackColor = true;
            // 
            // secondWindowBtn
            // 
            this.secondWindowBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.secondWindowBtn.Location = new System.Drawing.Point(12, 79);
            this.secondWindowBtn.Name = "secondWindowBtn";
            this.secondWindowBtn.Size = new System.Drawing.Size(560, 23);
            this.secondWindowBtn.TabIndex = 1;
            this.secondWindowBtn.Text = "Second view model (Window)";
            this.secondWindowBtn.UseVisualStyleBackColor = true;
            // 
            // firstTabBtn
            // 
            this.firstTabBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.firstTabBtn.Location = new System.Drawing.Point(12, 50);
            this.firstTabBtn.Name = "firstTabBtn";
            this.firstTabBtn.Size = new System.Drawing.Size(560, 23);
            this.firstTabBtn.TabIndex = 2;
            this.firstTabBtn.Text = "First view model (Tab)";
            this.firstTabBtn.UseVisualStyleBackColor = true;
            // 
            // secondTabBtn
            // 
            this.secondTabBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.secondTabBtn.Location = new System.Drawing.Point(12, 108);
            this.secondTabBtn.Name = "secondTabBtn";
            this.secondTabBtn.Size = new System.Drawing.Size(560, 23);
            this.secondTabBtn.TabIndex = 3;
            this.secondTabBtn.Text = "Second view model (Tab)";
            this.secondTabBtn.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Location = new System.Drawing.Point(12, 137);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(560, 164);
            this.tabControl1.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 313);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.secondTabBtn);
            this.Controls.Add(this.firstTabBtn);
            this.Controls.Add(this.secondWindowBtn);
            this.Controls.Add(this.firstWindowBtn);
            this.Name = "MainForm";
            this.Text = "Mugen MVVM Application";
            ((System.ComponentModel.ISupportInitialize)(this.viewBinder)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Navigation.WinForms.ViewBinder viewBinder;
        private System.Windows.Forms.Button secondWindowBtn;
        private System.Windows.Forms.Button firstWindowBtn;
        private System.Windows.Forms.Button secondTabBtn;
        private System.Windows.Forms.Button firstTabBtn;
        private System.Windows.Forms.TabControl tabControl1;
    }
}


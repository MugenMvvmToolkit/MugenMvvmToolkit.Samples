namespace Binding.WinForms.Views
{
    partial class RelativeBindingView
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
            this.trackBar = new System.Windows.Forms.TrackBar();
            this.trackBarTb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.titleTb = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.selfLabel = new System.Windows.Forms.Label();
            this.viewBinder = new Binding.WinForms.ViewBinder(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewBinder)).BeginInit();
            this.SuspendLayout();
            // 
            // trackBar
            // 
            this.trackBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBar.Location = new System.Drawing.Point(12, 12);
            this.trackBar.Maximum = 1000;
            this.trackBar.Name = "trackBar";
            this.trackBar.Size = new System.Drawing.Size(441, 45);
            this.trackBar.TabIndex = 0;
            // 
            // trackBarTb
            // 
            this.trackBarTb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarTb.Location = new System.Drawing.Point(12, 50);
            this.trackBarTb.Name = "trackBarTb";
            this.trackBarTb.Size = new System.Drawing.Size(441, 20);
            this.trackBarTb.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "The current title:";
            // 
            // titleTb
            // 
            this.titleTb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.titleTb.Location = new System.Drawing.Point(12, 101);
            this.titleTb.Name = "titleTb";
            this.titleTb.Size = new System.Drawing.Size(441, 20);
            this.titleTb.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Self binding (Width):";
            // 
            // selfLabel
            // 
            this.selfLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.selfLabel.AutoSize = true;
            this.selfLabel.ForeColor = System.Drawing.Color.Green;
            this.selfLabel.Location = new System.Drawing.Point(120, 133);
            this.selfLabel.Name = "selfLabel";
            this.selfLabel.Size = new System.Drawing.Size(23, 13);
            this.selfLabel.TabIndex = 5;
            this.selfLabel.Text = "self";
            // 
            // viewBinder
            // 
            this.viewBinder.Bindings = "<Bindings>\n  <trackBarTb Text=\"$Element(trackBar).Value, Mode=TwoWay\" />\n  <title" +
    "Tb Text=\"$Relative(Form).Text, Mode=TwoWay\" />\n  <selfLabel Text=\"$self.Width\" /" +
    ">\n</Bindings>";
            this.viewBinder.ContainerControl = this;
            this.viewBinder.IgnoreControlException = true;
            this.viewBinder.RootTagName = "Bindings";
            // 
            // RelativeBindingView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 167);
            this.Controls.Add(this.selfLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.titleTb);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trackBarTb);
            this.Controls.Add(this.trackBar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RelativeBindingView";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mugen MVVM Application";
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewBinder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar trackBar;
        private System.Windows.Forms.TextBox trackBarTb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox titleTb;
        private Binding.WinForms.ViewBinder viewBinder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label selfLabel;
    }
}
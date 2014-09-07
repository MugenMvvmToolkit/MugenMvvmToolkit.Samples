namespace Binding.WinForms.Views
{
    partial class PerformanceView
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
            this.nativeLabel = new System.Windows.Forms.Label();
            this.mugenLabel = new System.Windows.Forms.Label();
            this.mugenExpLabel = new System.Windows.Forms.Label();
            this.noBindingLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.IterationsTb = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Native binding:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mugen binding:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(303, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mugen binding ((Property ?? $string.Empty).Count() + Property):";
            // 
            // nativeLabel
            // 
            this.nativeLabel.AutoSize = true;
            this.nativeLabel.Location = new System.Drawing.Point(336, 13);
            this.nativeLabel.Name = "nativeLabel";
            this.nativeLabel.Size = new System.Drawing.Size(52, 13);
            this.nativeLabel.TabIndex = 3;
            this.nativeLabel.Text = "no results";
            // 
            // mugenLabel
            // 
            this.mugenLabel.AutoSize = true;
            this.mugenLabel.Location = new System.Drawing.Point(336, 39);
            this.mugenLabel.Name = "mugenLabel";
            this.mugenLabel.Size = new System.Drawing.Size(52, 13);
            this.mugenLabel.TabIndex = 4;
            this.mugenLabel.Text = "no results";
            // 
            // mugenExpLabel
            // 
            this.mugenExpLabel.AutoSize = true;
            this.mugenExpLabel.Location = new System.Drawing.Point(336, 65);
            this.mugenExpLabel.Name = "mugenExpLabel";
            this.mugenExpLabel.Size = new System.Drawing.Size(52, 13);
            this.mugenExpLabel.TabIndex = 5;
            this.mugenExpLabel.Text = "no results";
            // 
            // noBindingLabel
            // 
            this.noBindingLabel.AutoSize = true;
            this.noBindingLabel.Location = new System.Drawing.Point(336, 90);
            this.noBindingLabel.Name = "noBindingLabel";
            this.noBindingLabel.Size = new System.Drawing.Size(52, 13);
            this.noBindingLabel.TabIndex = 7;
            this.noBindingLabel.Text = "no results";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "No binding:";
            // 
            // IterationsTb
            // 
            this.IterationsTb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.IterationsTb.Location = new System.Drawing.Point(16, 115);
            this.IterationsTb.Name = "IterationsTb";
            this.IterationsTb.Size = new System.Drawing.Size(502, 20);
            this.IterationsTb.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(16, 141);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(502, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button_Click);
            // 
            // PerformanceView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 185);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.IterationsTb);
            this.Controls.Add(this.noBindingLabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.mugenExpLabel);
            this.Controls.Add(this.mugenLabel);
            this.Controls.Add(this.nativeLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PerformanceView";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mugen MVVM Application";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label nativeLabel;
        private System.Windows.Forms.Label mugenLabel;
        private System.Windows.Forms.Label mugenExpLabel;
        private System.Windows.Forms.Label noBindingLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox IterationsTb;
        private System.Windows.Forms.Button button1;
    }
}
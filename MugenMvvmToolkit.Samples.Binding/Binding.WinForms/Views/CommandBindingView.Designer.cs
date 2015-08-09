namespace Binding.WinForms.Views
{
    partial class CommandBindingView
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
            this.event4Tb = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.event3Tb = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.event2Tb = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.event1Tb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.canExecuteCheckBox = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // event4Tb
            // 
            this.event4Tb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.event4Tb.Location = new System.Drawing.Point(12, 273);
            this.event4Tb.Name = "event4Tb";
            this.event4Tb.Size = new System.Drawing.Size(511, 20);
            this.event4Tb.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 257);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(420, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Binding to method with several parameters (EventMethodMultiParams($self.Text, $ar" +
    "gs))";
            // 
            // event3Tb
            // 
            this.event3Tb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.event3Tb.Location = new System.Drawing.Point(12, 233);
            this.event3Tb.Name = "event3Tb";
            this.event3Tb.Size = new System.Drawing.Size(511, 20);
            this.event3Tb.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 217);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(322, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Binding to method with event args parameter (EventMethod($args))";
            // 
            // event2Tb
            // 
            this.event2Tb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.event2Tb.Location = new System.Drawing.Point(12, 194);
            this.event2Tb.Name = "event2Tb";
            this.event2Tb.Size = new System.Drawing.Size(511, 20);
            this.event2Tb.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 178);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(289, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Binding to method with parameter (EventMethod($self.Text))";
            // 
            // event1Tb
            // 
            this.event1Tb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.event1Tb.Location = new System.Drawing.Point(12, 152);
            this.event1Tb.Name = "event1Tb";
            this.event1Tb.Size = new System.Drawing.Size(511, 20);
            this.event1Tb.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 136);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(279, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Binding to method without parameters (EventMethod(null))";
            // 
            // canExecuteCheckBox
            // 
            this.canExecuteCheckBox.AutoSize = true;
            this.canExecuteCheckBox.Location = new System.Drawing.Point(12, 12);
            this.canExecuteCheckBox.Name = "canExecuteCheckBox";
            this.canExecuteCheckBox.Size = new System.Drawing.Size(135, 17);
            this.canExecuteCheckBox.TabIndex = 20;
            this.canExecuteCheckBox.Text = "Can execute command";
            this.canExecuteCheckBox.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Binding to command";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 84);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(240, 13);
            this.label7.TabIndex = 23;
            this.label7.Text = "Binding to command(ToggleEnabledState = false)";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(12, 51);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(511, 23);
            this.button1.TabIndex = 24;
            this.button1.Text = "Click binding";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(12, 100);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(511, 23);
            this.button2.TabIndex = 25;
            this.button2.Text = "Click binding";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // CommandBindingView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 328);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.canExecuteCheckBox);
            this.Controls.Add(this.event4Tb);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.event3Tb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.event2Tb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.event1Tb);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CommandBindingView";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mugen MVVM Application";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox event4Tb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox event3Tb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox event2Tb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox event1Tb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox canExecuteCheckBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}
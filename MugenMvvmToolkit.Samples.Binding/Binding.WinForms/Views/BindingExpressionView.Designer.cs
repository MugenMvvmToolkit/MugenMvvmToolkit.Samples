namespace Binding.WinForms.Views
{
    partial class BindingExpressionView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BindingExpressionView));
            this.textTb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.linqCountLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.extMethodLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.linqSecondCharLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.conditionLabel = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.arithmeticLabel = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.viewBinder = new Binding.WinForms.ViewBinder(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.viewBinder)).BeginInit();
            this.SuspendLayout();
            // 
            // textTb
            // 
            this.textTb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textTb.Location = new System.Drawing.Point(12, 27);
            this.textTb.Name = "textTb";
            this.textTb.Size = new System.Drawing.Size(433, 20);
            this.textTb.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "One time binding: ";
            // 
            // linqCountLabel
            // 
            this.linqCountLabel.AutoSize = true;
            this.linqCountLabel.ForeColor = System.Drawing.Color.Green;
            this.linqCountLabel.Location = new System.Drawing.Point(12, 87);
            this.linqCountLabel.Name = "linqCountLabel";
            this.linqCountLabel.Size = new System.Drawing.Size(35, 13);
            this.linqCountLabel.TabIndex = 7;
            this.linqCountLabel.Text = "label3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(250, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "LINQ-count of \'a\' symbols (Text.Count(x => x == \'a\'))";
            // 
            // extMethodLabel
            // 
            this.extMethodLabel.AutoSize = true;
            this.extMethodLabel.ForeColor = System.Drawing.Color.Green;
            this.extMethodLabel.Location = new System.Drawing.Point(12, 139);
            this.extMethodLabel.Name = "extMethodLabel";
            this.extMethodLabel.Size = new System.Drawing.Size(35, 13);
            this.extMethodLabel.TabIndex = 9;
            this.extMethodLabel.Text = "label4";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 117);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(352, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Custom extension method with args (Text.ExtensionMethod(Text.Count()))";
            // 
            // linqSecondCharLabel
            // 
            this.linqSecondCharLabel.AutoSize = true;
            this.linqSecondCharLabel.ForeColor = System.Drawing.Color.Green;
            this.linqSecondCharLabel.Location = new System.Drawing.Point(12, 194);
            this.linqSecondCharLabel.Name = "linqSecondCharLabel";
            this.linqSecondCharLabel.Size = new System.Drawing.Size(35, 13);
            this.linqSecondCharLabel.TabIndex = 11;
            this.linqSecondCharLabel.Text = "label6";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 172);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(319, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "LINQ-show second symbol or default (Text.Skip(1).FirstOrDefault())";
            // 
            // conditionLabel
            // 
            this.conditionLabel.AutoSize = true;
            this.conditionLabel.ForeColor = System.Drawing.Color.Green;
            this.conditionLabel.Location = new System.Drawing.Point(12, 246);
            this.conditionLabel.Name = "conditionLabel";
            this.conditionLabel.Size = new System.Drawing.Size(35, 13);
            this.conditionLabel.TabIndex = 13;
            this.conditionLabel.Text = "label8";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 224);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(443, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "Condition expression ($string.IsNullOrEmpty(Text) ? \\\'String is empty\\\' : \\\'Strin" +
    "g is not empty\\\')";
            // 
            // arithmeticLabel
            // 
            this.arithmeticLabel.AutoSize = true;
            this.arithmeticLabel.ForeColor = System.Drawing.Color.Green;
            this.arithmeticLabel.Location = new System.Drawing.Point(12, 298);
            this.arithmeticLabel.Name = "arithmeticLabel";
            this.arithmeticLabel.Size = new System.Drawing.Size(41, 13);
            this.arithmeticLabel.TabIndex = 15;
            this.arithmeticLabel.Text = "label10";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 276);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(312, 13);
            this.label11.TabIndex = 14;
            this.label11.Text = "Arithmetic expression (Text.Count() + 100 + Text.GetHashCode())";
            // 
            // viewBinder
            // 
            this.viewBinder.Bindings = resources.GetString("viewBinder.Bindings");
            this.viewBinder.ContainerControl = this;
            this.viewBinder.IgnoreControlException = true;
            this.viewBinder.RootTagName = "Bindings";
            // 
            // BindingExpressionView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 360);
            this.Controls.Add(this.arithmeticLabel);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.conditionLabel);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.linqSecondCharLabel);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.extMethodLabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.linqCountLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textTb);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BindingExpressionView";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mugen MVVM Application";
            ((System.ComponentModel.ISupportInitialize)(this.viewBinder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textTb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label linqCountLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label extMethodLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label linqSecondCharLabel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label conditionLabel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label arithmeticLabel;
        private System.Windows.Forms.Label label11;
        private Binding.WinForms.ViewBinder viewBinder;
    }
}
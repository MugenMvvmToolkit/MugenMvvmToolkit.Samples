namespace Binding.WinForms.Views
{
    partial class DynamicObjectView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DynamicObjectView));
            this.label2 = new System.Windows.Forms.Label();
            this.dynamicTb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dynamicLabel = new System.Windows.Forms.Label();
            this.viewBinder = new Binding.WinForms.ViewBinder(this.components);
            this.methodLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.indexLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.viewBinder)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Dynamic value:";
            // 
            // dynamicTb
            // 
            this.dynamicTb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dynamicTb.Location = new System.Drawing.Point(15, 26);
            this.dynamicTb.Name = "dynamicTb";
            this.dynamicTb.Size = new System.Drawing.Size(433, 20);
            this.dynamicTb.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Binding to dynamic property: ";
            // 
            // dynamicLabel
            // 
            this.dynamicLabel.AutoSize = true;
            this.dynamicLabel.ForeColor = System.Drawing.Color.Green;
            this.dynamicLabel.Location = new System.Drawing.Point(126, 52);
            this.dynamicLabel.Name = "dynamicLabel";
            this.dynamicLabel.Size = new System.Drawing.Size(35, 13);
            this.dynamicLabel.TabIndex = 7;
            this.dynamicLabel.Text = "label3";
            // 
            // viewBinder
            // 
            this.viewBinder.Bindings = resources.GetString("viewBinder.Bindings");
            this.viewBinder.ContainerControl = this;
            this.viewBinder.IgnoreControlException = true;
            this.viewBinder.RootTagName = "Bindings";
            // 
            // methodLabel
            // 
            this.methodLabel.AutoSize = true;
            this.methodLabel.ForeColor = System.Drawing.Color.Green;
            this.methodLabel.Location = new System.Drawing.Point(126, 74);
            this.methodLabel.Name = "methodLabel";
            this.methodLabel.Size = new System.Drawing.Size(35, 13);
            this.methodLabel.TabIndex = 9;
            this.methodLabel.Text = "label3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Dynamic method call:";
            // 
            // indexLabel
            // 
            this.indexLabel.AutoSize = true;
            this.indexLabel.ForeColor = System.Drawing.Color.Green;
            this.indexLabel.Location = new System.Drawing.Point(126, 98);
            this.indexLabel.Name = "indexLabel";
            this.indexLabel.Size = new System.Drawing.Size(35, 13);
            this.indexLabel.TabIndex = 11;
            this.indexLabel.Text = "label3";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 98);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Dynamic index call:";
            // 
            // DynamicObjectView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 137);
            this.Controls.Add(this.indexLabel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.methodLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dynamicLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dynamicTb);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DynamicObjectView";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mugen MVVM Application";
            ((System.ComponentModel.ISupportInitialize)(this.viewBinder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox dynamicTb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label dynamicLabel;
        private Binding.WinForms.ViewBinder viewBinder;
        private System.Windows.Forms.Label indexLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label methodLabel;
        private System.Windows.Forms.Label label4;
    }
}
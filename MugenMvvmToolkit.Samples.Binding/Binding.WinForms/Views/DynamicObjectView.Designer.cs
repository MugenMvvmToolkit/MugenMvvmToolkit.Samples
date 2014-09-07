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
            this.label2 = new System.Windows.Forms.Label();
            this.dynamicTb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dynamicLabel = new System.Windows.Forms.Label();
            this.viewBinder = new Binding.WinForms.ViewBinder(this.components);
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
            this.dynamicLabel.Location = new System.Drawing.Point(98, 52);
            this.dynamicLabel.Name = "dynamicLabel";
            this.dynamicLabel.Size = new System.Drawing.Size(35, 13);
            this.dynamicLabel.TabIndex = 7;
            this.dynamicLabel.Text = "label3";
            // 
            // viewBinder
            // 
            this.viewBinder.Bindings = "<Bindings>\n  <DynamicObjectView />\n  <dynamicTb Text=\"DynamicModel.DynamicPropert" +
    "y, Mode=TwoWay\" />\n  <dynamicLabel Text=\"DynamicModel.DynamicProperty\" />\n</Bind" +
    "ings>";
            this.viewBinder.ContainerControl = this;
            this.viewBinder.IgnoreControlException = true;
            this.viewBinder.RootTagName = "Bindings";
            // 
            // DynamicObjectView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 106);
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
    }
}
namespace Binding.WinForms.Views
{
    partial class AttachedMemberView
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
            this.customPropLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.autoPropLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox = new System.Windows.Forms.TextBox();
            this.viewBinder = new Binding.WinForms.ViewBinder(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.viewBinder)).BeginInit();
            this.SuspendLayout();
            // 
            // customPropLabel
            // 
            this.customPropLabel.AutoSize = true;
            this.customPropLabel.ForeColor = System.Drawing.Color.Green;
            this.customPropLabel.Location = new System.Drawing.Point(12, 138);
            this.customPropLabel.Name = "customPropLabel";
            this.customPropLabel.Size = new System.Drawing.Size(35, 13);
            this.customPropLabel.TabIndex = 23;
            this.customPropLabel.Text = "label6";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 116);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(128, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "Attached custom property";
            // 
            // autoPropLabel
            // 
            this.autoPropLabel.AutoSize = true;
            this.autoPropLabel.ForeColor = System.Drawing.Color.Green;
            this.autoPropLabel.Location = new System.Drawing.Point(12, 83);
            this.autoPropLabel.Name = "autoPropLabel";
            this.autoPropLabel.Size = new System.Drawing.Size(35, 13);
            this.autoPropLabel.TabIndex = 21;
            this.autoPropLabel.Text = "label4";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Attached auto property";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "The current text:";
            // 
            // textBox
            // 
            this.textBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox.Location = new System.Drawing.Point(15, 25);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(439, 20);
            this.textBox.TabIndex = 24;
            // 
            // viewBinder
            // 
            this.viewBinder.Bindings = "<Bindings>\n  <textBox Text=\"Text, Mode=TwoWay\" />\n  <autoPropLabel TextExt=\"Text\"" +
    " />\n  <customPropLabel FormattedText=\"Text\" />\n</Bindings>";
            this.viewBinder.ContainerControl = this;
            this.viewBinder.IgnoreControlException = true;
            this.viewBinder.RootTagName = "Bindings";
            // 
            // AttachedMemberView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 255);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.customPropLabel);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.autoPropLabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AttachedMemberView";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mugen MVVM Application";
            ((System.ComponentModel.ISupportInitialize)(this.viewBinder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label customPropLabel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label autoPropLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private ViewBinder viewBinder;
        private System.Windows.Forms.TextBox textBox;
    }
}
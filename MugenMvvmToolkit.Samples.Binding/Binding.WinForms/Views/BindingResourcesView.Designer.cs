namespace Binding.WinForms.Views
{
    partial class BindingResourcesView
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
            this.typeLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.methodLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.objLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.updateResBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // typeLabel
            // 
            this.typeLabel.AutoSize = true;
            this.typeLabel.ForeColor = System.Drawing.Color.Green;
            this.typeLabel.Location = new System.Drawing.Point(12, 138);
            this.typeLabel.Name = "typeLabel";
            this.typeLabel.Size = new System.Drawing.Size(35, 13);
            this.typeLabel.TabIndex = 17;
            this.typeLabel.Text = "label6";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 116);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(246, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Type from resources($CustomType.StaticMethod())";
            // 
            // methodLabel
            // 
            this.methodLabel.AutoSize = true;
            this.methodLabel.ForeColor = System.Drawing.Color.Green;
            this.methodLabel.Location = new System.Drawing.Point(12, 83);
            this.methodLabel.Name = "methodLabel";
            this.methodLabel.Size = new System.Drawing.Size(35, 13);
            this.methodLabel.TabIndex = 15;
            this.methodLabel.Text = "label4";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(169, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Method from resources($Method())";
            // 
            // objLabel
            // 
            this.objLabel.AutoSize = true;
            this.objLabel.ForeColor = System.Drawing.Color.Green;
            this.objLabel.Location = new System.Drawing.Point(12, 31);
            this.objLabel.Name = "objLabel";
            this.objLabel.Size = new System.Drawing.Size(35, 13);
            this.objLabel.TabIndex = 13;
            this.objLabel.Text = "label3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Object from resources($obj)";
            // 
            // updateResBtn
            // 
            this.updateResBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.updateResBtn.Location = new System.Drawing.Point(12, 171);
            this.updateResBtn.Name = "updateResBtn";
            this.updateResBtn.Size = new System.Drawing.Size(453, 23);
            this.updateResBtn.TabIndex = 18;
            this.updateResBtn.Text = "Update resource";
            this.updateResBtn.UseVisualStyleBackColor = true;
            // 
            // BindingResourcesView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 206);
            this.Controls.Add(this.updateResBtn);
            this.Controls.Add(this.typeLabel);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.methodLabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.objLabel);
            this.Controls.Add(this.label2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BindingResourcesView";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mugen MVVM Application";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label typeLabel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label methodLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label objLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button updateResBtn;
    }
}
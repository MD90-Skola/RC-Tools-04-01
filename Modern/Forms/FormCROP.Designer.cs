namespace Modern.Forms
{
    partial class FormCROP
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
            this.webViewCROP = new Microsoft.Web.WebView2.WinForms.WebView2();
            ((System.ComponentModel.ISupportInitialize)(this.webViewCROP)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "This is CROP";
            // 
            // webViewCROP
            // 
            this.webViewCROP.AllowExternalDrop = true;
            this.webViewCROP.CreationProperties = null;
            this.webViewCROP.DefaultBackgroundColor = System.Drawing.Color.White;
            this.webViewCROP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webViewCROP.Location = new System.Drawing.Point(0, 0);
            this.webViewCROP.Name = "webViewCROP";
            this.webViewCROP.Size = new System.Drawing.Size(1052, 541);
            this.webViewCROP.TabIndex = 2;
            this.webViewCROP.ZoomFactor = 1D;
            this.webViewCROP.Click += new System.EventHandler(this.webViewCROP_Click);
            // 
            // FormCROP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1052, 541);
            this.Controls.Add(this.webViewCROP);
            this.Controls.Add(this.label1);
            this.Name = "FormCROP";
            this.Text = "FormCROP";
            ((System.ComponentModel.ISupportInitialize)(this.webViewCROP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private Microsoft.Web.WebView2.WinForms.WebView2 webViewCROP;
    }
}
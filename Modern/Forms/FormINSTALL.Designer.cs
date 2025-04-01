namespace Modern.Forms
{
    partial class FormINSTALL
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Button buttonInstall;
        private System.Windows.Forms.Button buttonAll;
        private System.Windows.Forms.Button buttonDelete;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.buttonInstall = new System.Windows.Forms.Button();
            this.buttonAll = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.Location = new System.Drawing.Point(711, 11);
            this.checkedListBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(239, 327);
            this.checkedListBox1.TabIndex = 0;
            // 
            // buttonInstall
            // 
            this.buttonInstall.Location = new System.Drawing.Point(878, 342);
            this.buttonInstall.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonInstall.Name = "buttonInstall";
            this.buttonInstall.Size = new System.Drawing.Size(72, 32);
            this.buttonInstall.TabIndex = 1;
            this.buttonInstall.Text = "Installera";
            this.buttonInstall.UseVisualStyleBackColor = true;
            this.buttonInstall.Click += new System.EventHandler(this.buttonInstall_Click);
            // 
            // buttonAll
            // 
            this.buttonAll.Location = new System.Drawing.Point(711, 342);
            this.buttonAll.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonAll.Name = "buttonAll";
            this.buttonAll.Size = new System.Drawing.Size(83, 32);
            this.buttonAll.TabIndex = 2;
            this.buttonAll.Text = "Välj alla";
            this.buttonAll.UseVisualStyleBackColor = true;
            this.buttonAll.Click += new System.EventHandler(this.buttonAll_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(800, 342);
            this.buttonDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(72, 32);
            this.buttonDelete.TabIndex = 3;
            this.buttonDelete.Text = "Ta bort";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // FormINSTALL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(937, 473);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonAll);
            this.Controls.Add(this.buttonInstall);
            this.Controls.Add(this.checkedListBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormINSTALL";
            this.Text = "Installera program";
            this.Load += new System.EventHandler(this.FormINSTALL_Load);
            this.ResumeLayout(false);

        }
    }
}

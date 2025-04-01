using System.Windows.Forms;

namespace Modern.Forms.FolderFunctions
{
    partial class FunctionAudioSource
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FunctionAudioSource));
            this.checkedListBoxAudioOptions = new System.Windows.Forms.CheckedListBox();
            this.buttonOption1 = new System.Windows.Forms.Button();
            this.buttonOption2 = new System.Windows.Forms.Button();
            this.buttonOption3 = new System.Windows.Forms.Button();
            this.SuspendLayout();





            // 
            // checkedListBoxAudioOptions
            // 
            this.checkedListBoxAudioOptions.FormattingEnabled = true;
            this.checkedListBoxAudioOptions.Location = new System.Drawing.Point(12, 47);
            this.checkedListBoxAudioOptions.Name = "checkedListBoxAudioOptions";
            this.checkedListBoxAudioOptions.Size = new System.Drawing.Size(431, 361);
            this.checkedListBoxAudioOptions.TabIndex = 1;
            this.checkedListBoxAudioOptions.SelectedIndexChanged += new System.EventHandler(this.checkedListBoxAudioOptions_SelectedIndexChanged);
            // 
            // buttonOption1
            // 
            this.buttonOption1.Location = new System.Drawing.Point(161, 414);
            this.buttonOption1.Name = "buttonOption1";
            this.buttonOption1.Size = new System.Drawing.Size(75, 23);
            this.buttonOption1.TabIndex = 2;
            this.buttonOption1.Text = "Option 1";
            this.buttonOption1.UseVisualStyleBackColor = true;
            this.buttonOption1.Click += new System.EventHandler(this.buttonOption1_Click);
            // 
            // buttonOption2
            // 
            this.buttonOption2.Location = new System.Drawing.Point(242, 414);
            this.buttonOption2.Name = "buttonOption2";
            this.buttonOption2.Size = new System.Drawing.Size(75, 23);
            this.buttonOption2.TabIndex = 3;
            this.buttonOption2.Text = "Option 2";
            this.buttonOption2.UseVisualStyleBackColor = true;
            this.buttonOption2.Click += new System.EventHandler(this.buttonOption2_Click);
            // 
            // buttonOption3
            // 
            this.buttonOption3.Location = new System.Drawing.Point(323, 414);
            this.buttonOption3.Name = "buttonOption3";
            this.buttonOption3.Size = new System.Drawing.Size(75, 23);
            this.buttonOption3.TabIndex = 4;
            this.buttonOption3.Text = "Option 3";
            this.buttonOption3.UseVisualStyleBackColor = true;
            this.buttonOption3.Click += new System.EventHandler(this.buttonOption3_Click);
            // 
            // FunctionAudioSource
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 495);
            this.Controls.Add(this.buttonOption3);
            this.Controls.Add(this.buttonOption2);
            this.Controls.Add(this.buttonOption1);
            this.Controls.Add(this.checkedListBoxAudioOptions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FunctionAudioSource";
            this.Text = "Audio Source Options";
            this.Load += new System.EventHandler(this.FunctionAudioSource_Load);
            this.ResumeLayout(false);

            this.checkedListBoxAudioOptions.ItemHeight = 30;
            checkedListBoxAudioOptions.DrawMode = DrawMode.OwnerDrawFixed;
            checkedListBoxAudioOptions.ItemHeight = 45;





        }






        #endregion

        private System.Windows.Forms.CheckedListBox checkedListBoxAudioOptions;
        private System.Windows.Forms.Button buttonOption1;
        private System.Windows.Forms.Button buttonOption2;
        private System.Windows.Forms.Button buttonOption3;
    }
}
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Drawing;


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
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // checkedListBoxAudioOptions
            // 
            this.checkedListBoxAudioOptions.ColumnWidth = 22;
            this.checkedListBoxAudioOptions.FormattingEnabled = true;
            this.checkedListBoxAudioOptions.Location = new System.Drawing.Point(12, 82);
            this.checkedListBoxAudioOptions.Name = "checkedListBoxAudioOptions";
            this.checkedListBoxAudioOptions.Size = new System.Drawing.Size(467, 344);
            this.checkedListBoxAudioOptions.TabIndex = 1;
            this.checkedListBoxAudioOptions.SelectedIndexChanged += new System.EventHandler(this.checkedListBoxAudioOptions_SelectedIndexChanged);
            // 
            // buttonOption1
            // 
            this.buttonOption1.Location = new System.Drawing.Point(56, 432);
            this.buttonOption1.Name = "buttonOption1";
            this.buttonOption1.Size = new System.Drawing.Size(103, 42);
            this.buttonOption1.TabIndex = 2;
            this.buttonOption1.Text = "Option 1";
            this.buttonOption1.UseVisualStyleBackColor = true;
            this.buttonOption1.Click += new System.EventHandler(this.buttonOption1_Click);
            // 
            // buttonOption2
            // 
            this.buttonOption2.Location = new System.Drawing.Point(188, 432);
            this.buttonOption2.Name = "buttonOption2";
            this.buttonOption2.Size = new System.Drawing.Size(103, 42);
            this.buttonOption2.TabIndex = 3;
            this.buttonOption2.Text = "Option 2";
            this.buttonOption2.UseVisualStyleBackColor = true;
            this.buttonOption2.Click += new System.EventHandler(this.buttonOption2_Click);
            // 
            // buttonOption3
            // 
            this.buttonOption3.Location = new System.Drawing.Point(315, 432);
            this.buttonOption3.Name = "buttonOption3";
            this.buttonOption3.Size = new System.Drawing.Size(103, 42);
            this.buttonOption3.TabIndex = 4;
            this.buttonOption3.Text = "Option 3";
            this.buttonOption3.UseVisualStyleBackColor = true;
            this.buttonOption3.Click += new System.EventHandler(this.buttonOption3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(180, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Select only one !!!";
            // 
            // FunctionAudioSource
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 495);
            this.Controls.Add(this.label1);
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
            this.PerformLayout();

        }






        #endregion

        private System.Windows.Forms.CheckedListBox checkedListBoxAudioOptions;
        private System.Windows.Forms.Button buttonOption1;
        private System.Windows.Forms.Button buttonOption2;
        private System.Windows.Forms.Button buttonOption3;
        private Label label1;
    }
}
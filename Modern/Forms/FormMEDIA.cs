using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Microsoft.VisualBasic; // Required for InputBox
using Microsoft.Web.WebView2.WinForms;

namespace Modern.Forms
{
    public partial class FormMEDIA : Form
    {
        public FormMEDIA()
        {
            InitializeComponent();
            this.Load += FormMEDIA_Load;
        }

        private void FormMEDIA_Load(object sender, EventArgs e)
        {
            // Set the default URL for WebView2
            webView21.Source = new Uri("https://crop-circle.imageonline.co/");

            // Make buttonRund circular
            GraphicsPath rundPath = new GraphicsPath();
            rundPath.AddEllipse(0, 0, buttonRund.Width, buttonRund.Height);
            buttonRund.Region = new Region(rundPath);

            // Make buttonHalvRund with rounded corners
            GraphicsPath halvPath = new GraphicsPath();
            int radius = 30;
            halvPath.AddArc(0, 0, radius, radius, 180, 90);
            halvPath.AddArc(buttonHalvRund.Width - radius, 0, radius, radius, 270, 90);
            halvPath.AddArc(buttonHalvRund.Width - radius, buttonHalvRund.Height - radius, radius, radius, 0, 90);
            halvPath.AddArc(0, buttonHalvRund.Height - radius, radius, radius, 90, 90);
            halvPath.CloseAllFigures();
            buttonHalvRund.Region = new Region(halvPath);
        }

        private void buttonRund_Click(object sender, EventArgs e)
        {
            // Open URL in WebView2
            webView21.Source = new Uri("https://crop-circle.imageonline.co/");
        }

        private void buttonHalvRund_Click(object sender, EventArgs e)
        {
            // Open URL in WebView2
            webView21.Source = new Uri("https://round-corner.imageonline.co/");
        }

        private void buttonCrop_Click(object sender, EventArgs e)
        {
            // Open URL in WebView2
            webView21.Source = new Uri("https://imageresizer.com/crop-image");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Open Canva URL in WebView2
            webView21.Source = new Uri("https://www.canva.com");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Open Davinci Resolve URL in WebView2
            webView21.Source = new Uri("https://www.blackmagicdesign.com/products/davinciresolve");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Password-protected download
            string correctPassword = "1";
            string inputPassword = Interaction.InputBox("Ange lösenord:", "Lösenord", "");

            if (inputPassword == correctPassword)
            {
                MessageBox.Show("Arise");
                Process.Start("https://www.mediafire.com/file/eaolcve6cytq1qz/101010123123123ps.rar");
            }
            else
            {
                MessageBox.Show("Not for you");
                string filePath = System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "Resources", "Arise2.wav");

                if (System.IO.File.Exists(filePath))
                {
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer(filePath);
                    player.Play();
                }
            }
        }

        private void webView21_Click(object sender, EventArgs e)
        {

        }
    }
}

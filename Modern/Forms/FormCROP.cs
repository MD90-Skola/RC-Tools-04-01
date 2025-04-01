using System;
using System.Windows.Forms;

namespace Modern.Forms
{
    public partial class FormCROP : Form
    {
        public FormCROP()
        {
            InitializeComponent();
            this.Load += FormCROP_Load;
        }

        private async void FormCROP_Load(object sender, EventArgs e)
        {
            await webViewCROP.EnsureCoreWebView2Async(null);

            webViewCROP.CoreWebView2.NavigationCompleted += (s, args) =>
            {
                // Du kan lägga till något här efter laddning om du vill
            };

            webViewCROP.CoreWebView2.Navigate("https://imageresizer.com/crop-image");
        }


        private void webViewCROP_Click(object sender, EventArgs e)
        {

        }
    }
}

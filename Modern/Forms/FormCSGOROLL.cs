using Modern.Forms.FolderFunctions;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Modern.Forms
{
    public partial class FormCSGOROLL : Form
    {
        public FormCSGOROLL()
        {
            InitializeComponent();
        }

        private async void FormCSGOROLL_Load(object sender, EventArgs e)
        {
            await webView21.EnsureCoreWebView2Async(null);
            webView21.CoreWebView2.Navigate("https://www.csgoroll.com/withdraw/csgo/p2p");

            webView21.CoreWebView2.NavigationCompleted += async (s, args) =>
            {
                await FunctionCsgoRoll.ApplyFilters(webView21);
            };
        }

        private void webView21_Click(object sender, EventArgs e)
        {

        }



        private async void button2_Click(object sender, EventArgs e)
        {



            if (webView21.CoreWebView2 != null)
            {
                await webView21.ExecuteScriptAsync(@"
            const buttons = Array.from(document.querySelectorAll('button.mat-flat-button'));
            const loginBtn = buttons.find(btn => btn.textContent.includes('LOGIN') || btn.textContent.includes('REGISTER'));
            if (loginBtn) loginBtn.click();
        ");
            }
        }
















    }




    }


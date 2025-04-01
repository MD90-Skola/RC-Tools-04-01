using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Windows.Media;
using FontAwesome.Sharp;
using Color = System.Drawing.Color;
using Point = System.Drawing.Point;
using Size = System.Drawing.Size;
using System.Runtime.InteropServices;
using Modern.Forms;
using System.Drawing.Drawing2D;
using Modern.Forms.FolderFunctions;
using System.Management; // ✅ Denna är absolut nödvändig!
using System.Diagnostics;
using System.IO;
using System.Media;












namespace Modern
{
    public partial class Form1: Form
    {

        // Fields
        private IconButton currentBtn;
        private Panel leftBoarderBtn;
        private Form currentChildForm;
        



        // test zone
        private Panel panelSubMedia;
        private FontAwesome.Sharp.IconButton iconButtonCrop;
        private FontAwesome.Sharp.IconButton iconButtonVideo;


        // START   // START   // START   // START   // START   // START   // START   // START   // START 

        //constructor      / START 


        public Form1()
        {
            InitializeComponent();
            leftBoarderBtn = new Panel();
            leftBoarderBtn.Size = new Size(7, 60);
            panelMenu.Controls.Add(leftBoarderBtn);
            currentBtn = new IconButton();
            currentBtn.BackColor = Color.FromArgb(31, 30, 68);
            iconButton6CROP.Visible = false;
            iconButtonMEDIA2.Visible = false;
            buttonAPI.Visible = false;
            buttonRollOPEN.Visible = false;



        }



        // START   // START   // START   // START   // START   // START   // START   // START   // START   // START   // START   // START 


        //structure

        private struct RGBColors
        {
            //  186; 225; 255

          //  (172, 126, 241); purple



            // färger för knapparna på menu 



            public static Color color1 = Color.FromArgb(186, 225, 225);
            public static Color color2 = Color.FromArgb(26, 0, 230);
            public static Color color3 = Color.FromArgb(51, 0, 204);
            public static Color color4 = Color.FromArgb(77, 0, 179);
            public static Color color5 = Color.FromArgb(102, 0, 153);
            public static Color color6 = Color.FromArgb(128, 0, 128);


            // orginal färger 
            //   public static Color color1 = Color.FromArgb(186, 225, 225);
            //   public static Color color2 = Color.FromArgb(172, 169, 223);
            //   public static Color color3 = Color.FromArgb(253, 138, 114);
            //   public static Color color4 = Color.FromArgb(95, 77, 221);
            //   public static Color color5 = Color.FromArgb(249, 88, 155);
            //   public static Color color6 = Color.FromArgb(24, 161, 251);




        }
















        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {



                DisableButton();

                //button
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb (37, 36, 81);   // ändrar knappens färg / inte panelens
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
                // left boarder
                leftBoarderBtn.BackColor = color;
                leftBoarderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBoarderBtn.Visible = true;
                leftBoarderBtn.BringToFront();
                //
                iconCurrentChildForm0.IconChar = currentBtn.IconChar;
                iconCurrentChildForm0.IconColor = color;








            }

        }


        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(31, 30, 68);
                currentBtn.ForeColor = Color.Gainsboro;
                currentBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.Gainsboro;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;

            }
        }




        private void OpenChildForm(Form childForm)
        {
            //open only form
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            //End
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelDesktop.Controls.Add(childForm);
            panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitleChildform1.Text = childForm.Text;
        }










        ////////////////////////////////////////////////////////////////////////
        ///////         Home nav menu                                     ///////
        ///////                  FLIKAR                                  ///////
        //////////////////////////////////////////////////////////////////////






        // home
        private void iconButton1_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new FormHOME());


            iconButton6CROP.Visible = false;
            iconButtonMEDIA2.Visible = false;
            buttonAPI.Visible = false;
            buttonRollOPEN.Visible = false;


        }


        //install
        private void iconButton2_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color2);
            OpenChildForm(new FormINSTALL());


            iconButton6CROP.Visible = false;
            iconButtonMEDIA2.Visible = false;
            buttonAPI.Visible = false;
            buttonRollOPEN.Visible = false;
        }


        // CLEAN 
        private void iconButton4_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color4);
            OpenChildForm(new FormCONFIG());

            buttonAPI.Visible = false;
            iconButton6CROP.Visible = false;
            iconButtonMEDIA2.Visible = false;
            buttonRollOPEN.Visible = false;
        }


        // CSGOROLL
        private void iconButton3_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color3);
            OpenChildForm(new FormCSGOROLL());

            iconButton6CROP.Visible = false;
            iconButtonMEDIA2.Visible = false;

            buttonAPI.Visible = true;
            buttonRollOPEN.Visible = true;





        }

        private void panelMenu_Paint(object sender, PaintEventArgs e)
        {
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {      
            ActivateButton(iconButton1, RGBColors.color1);
            OpenChildForm(new FormHOME());
        }


        // ARISE EASTER EGG "rigthklick logo"

        private void btnHome_Click(object sender, EventArgs e)
        {
            string filePath = System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "Resources", "Arise2.wav");

            if (System.IO.File.Exists(filePath))
            {
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(filePath);
                player.Play();
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Ljudfilen hittades inte: " + filePath);
            }

            Reset();

        }

        private void Reset()
        {
            DisableButton();
            leftBoarderBtn.Visible = false;
            iconCurrentChildForm0.IconChar = IconChar.Home;
            iconCurrentChildForm0.IconColor = Color.MediumPurple;
            lblTitleChildform1.Text = "Home";




        }





        private void iconCurrentChildForm_Click(object sender, EventArgs e)
        {

        }

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panelTitleBar_Paint(object sender, PaintEventArgs e)
        {

        }





















        ////////////////////////////////////////////////////////////////////////
        ///////           Drag windows                                   ///////
        ///////                                                         ///////
        //////////////////////////////////////////////////////////////////////

        public static class NativeMethods
        {
            public const int WM_NCLBUTTONDOWN = 0xA1;
            public const int HT_CAPTION = 0x2;

            [System.Runtime.InteropServices.DllImport("user32.dll")]
            public static extern bool ReleaseCapture();

            [System.Runtime.InteropServices.DllImport("user32.dll")]
            public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        }

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            // drag form 

            NativeMethods.ReleaseCapture();
            NativeMethods.SendMessage(this.Handle, NativeMethods.WM_NCLBUTTONDOWN, NativeMethods.HT_CAPTION, 0);

        }




        private void panelMenu_MouseDown(object sender, MouseEventArgs e)
        {
            // drag form 
            NativeMethods.ReleaseCapture();
            NativeMethods.SendMessage(this.Handle, NativeMethods.WM_NCLBUTTONDOWN, NativeMethods.HT_CAPTION, 0);

        }




        private void panelLogo_MouseDown(object sender, MouseEventArgs e)
        {
            // drag form 
            NativeMethods.ReleaseCapture();
            NativeMethods.SendMessage(this.Handle, NativeMethods.WM_NCLBUTTONDOWN, NativeMethods.HT_CAPTION, 0);
        }

        private void btnHome_MouseDown(object sender, MouseEventArgs e)
        {
            // DENNA BRÅKAR !!! går inte klicka nu !!! men går att DRAG
            NativeMethods.ReleaseCapture();
            NativeMethods.SendMessage(this.Handle, NativeMethods.WM_NCLBUTTONDOWN, NativeMethods.HT_CAPTION, 0);
        }

        private void panelDesktop_Paint(object sender, PaintEventArgs e)
        {

        }

        private void iconPictureBox1_Click_1(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void panelLogo_Paint(object sender, PaintEventArgs e)
        {

        }


        // TEST ZONE 


    















        private void iconPictureBoxYouTube_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.youtube.com/@Doctor9Raccoon");
        }

        private void iconPictureBoxGithub_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/MD90-Skola/MD90-Skola");
        }





        private void buttonAPI_Click(object sender, EventArgs e)
        {
            // 1. Öppna första URL
            string url1 = "https://www.csgoroll.com/player/VXNlcjo2ODU5NTc2/summary";
            Process.Start(new ProcessStartInfo(url1) { UseShellExecute = true });

            // 2. Öppna andra URL
            string url2 = "https://steamcommunity.com/id/me/edit/info";
            Process.Start(new ProcessStartInfo(url2) { UseShellExecute = true });

            // 3. Kopiera script till urklipp
            string script = "document.getElementById(\"application_config\").getAttribute('data-loyalty_webapi_token');";

            // Specifiera att vi använder System.Windows.Forms.Clipboard
            System.Windows.Forms.Clipboard.SetText(script);
        }






        private void iconButton5_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormMEDIA());
            buttonAPI.Visible = false;
            buttonRollOPEN.Visible = false;

            // Öppna sub-menyn för Media om den inte redan är synlig
            if (!iconButton6CROP.Visible && !iconButtonMEDIA2.Visible)
            {
                iconButton6CROP.Visible = true;
                iconButtonMEDIA2.Visible = true;
            }

            // Aktivera Media-knappen
            ActivateButton(sender, RGBColors.color5);
        }


        private void iconButton6CROP_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormCROP());
            buttonAPI.Visible = false;
            buttonRollOPEN.Visible = false;

        }


        private void iconButtonMEDIA2_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormMEDIA2());
            buttonAPI.Visible = false;
        }

        private void buttonRollLogin_Click(object sender, EventArgs e)
        {
            string url1 = "https://www.csgoroll.com/withdraw/csgo/p2p";
            Process.Start(new ProcessStartInfo(url1) { UseShellExecute = true });
        }




        private void iconButtonMEDIA2_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(new FormMEDIA2());
            buttonAPI.Visible = false;
            buttonRollOPEN.Visible = false;
            


        }










        ////////////////////////////////////////////////////////////////////////
        ///////           Drag windows                                   ///////
        ///////                                                         ///////
        //////////////////////////////////////////////////////////////////////






    }


}

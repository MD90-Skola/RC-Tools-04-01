using System;
using System.Windows.Forms;
using Modern.Forms.Functions;
using Modern.Forms.FolderFunctions;

namespace Modern.Forms
{
    public partial class FormHOME : Form
    {
        private Timer klockaTimer;

        public FormHOME()
        {
            InitializeComponent();
        }

        private void FormHOME_Load(object sender, EventArgs e)
        {
            StartKlockaActive();
            VisaDatorSpec();
            VisaAvanceradSpec();
            LoadSavedSettings();
        }

        private void LoadSavedSettings()
        {
            radioButtonOption1.Text = Properties.Settings.Default.AudioOption1?.ToString() ?? "Option 1";
            radioButtonOption2.Text = Properties.Settings.Default.AudioOption2?.ToString() ?? "Option 2";
            radioButtonOption3.Text = Properties.Settings.Default.AudioOption3?.ToString() ?? "Option 3";
        }

        private void OpenAudioSourcePopup()
        {
            var popup = new FunctionAudioSource();
            popup.OnAudioSourceSelected = (deviceName, option) =>
            {
                switch (option)
                {
                    case 1: radioButtonOption1.Text = deviceName; break;
                    case 2: radioButtonOption2.Text = deviceName; break;
                    case 3: radioButtonOption3.Text = deviceName; break;
                }

                Properties.Settings.Default[$"AudioOption{option}"] = deviceName;
                Properties.Settings.Default.Save();
            };

            popup.ShowDialog();
        }

        private void VisaDatorSpec()
        {
            textBox1.Text = FunctionsDatorSpecs.HämtaCPU();
            var gpuLista = FunctionsDatorSpecs.HämtaGPUer();
            textBox2.Text = gpuLista.Length > 0 ? gpuLista[0] : "Ingen GPU";
            textBox3.Text = gpuLista.Length > 1 ? gpuLista[1] : "Ingen extra GPU";
            textBox4.Text = FunctionsDatorSpecs.HämtaRAM();
        }

        private void VisaAvanceradSpec()
        {
            textBox5.Text = FunctionsDatorSpecs.HämtaModerkort();
            textBox6.Text = FunctionsDatorSpecs.HämtaDisk();
            textBox7.Text = FunctionsDatorSpecs.HämtaCputemp();
        }

        private void StartKlockaActive()
        {
            klockaTimer = new Timer();
            klockaTimer.Interval = 1000;
            klockaTimer.Tick += (s, e) =>
            {
                label3.Text = FunctionsKlocka.HämtaManad();
                label4.Text = FunctionsKlocka.HämtaVecka();
                label17.Text = DateTime.Now.ToString("dddd");
                label18.Text = DateTime.Now.ToString("dd");
                label19.Text = DateTime.Now.ToString("MM");
            };
            klockaTimer.Start();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            klockaTimer?.Stop();
            klockaTimer?.Dispose();
            base.OnFormClosing(e);
        }

        // Eventhandlers du redan använder
        private void button1_Click(object sender, EventArgs e) => FunctionPortableTools.StartPortableTool("RidNacs-3.0.zip", "RidNacs.exe");
        private void button2_Click(object sender, EventArgs e) => FunctionPortableTools.StartPortableTool("openhardwaremonitor.zip", "OpenHardwareMonitor.exe");
        private void button3_Click(object sender, EventArgs e) => FunctionPortableTools.StartPortableTool("CrystalDiskInfo.zip", "DiskInfo64A.exe");
        private void button4_Click(object sender, EventArgs e) => FunctionPortableTools.StartPortableTool("Autoruns.zip", "Autoruns.exe");

        // Tomma events du kan använda senare om du behöver
        private void label1_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }
        private void label9_Click(object sender, EventArgs e) { }
        private void label10_Click(object sender, EventArgs e) { }
        private void label17_Click(object sender, EventArgs e) { }
        private void label19_Click(object sender, EventArgs e) { }
        private void pictureBox1_Click(object sender, EventArgs e) { }
        private void label9_Click_1(object sender, EventArgs e) { }
        private void label1_Click_1(object sender, EventArgs e) { }
        private void textBox7_TextChanged(object sender, EventArgs e) { }

        private void radioButtonOption1_CheckedChanged(object sender, EventArgs e) { }
        private void radioButtonOption2_CheckedChanged(object sender, EventArgs e) { }
        private void radioButtonOption3_CheckedChanged(object sender, EventArgs e) { }

        private void iconPictureBoxAudioSettings_Click(object sender, EventArgs e)
        {
            OpenAudioSourcePopup();
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }
    }
}
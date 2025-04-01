// FormHOME.cs – full fix för korrekt ljudväxling med FriendlyName till NirCmd

using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Modern.Forms.FolderFunctions;

namespace Modern.Forms
{
    public partial class FormHOME : Form
    {
        private string audioId1, audioId2, audioId3;

        public FormHOME()
        {
            InitializeComponent();
        }

        private void FormHOME_Load(object sender, EventArgs e)
        {
            radioButtonOption1.Text = Properties.Settings.Default.AudioOption1;
            radioButtonOption2.Text = Properties.Settings.Default.AudioOption1;
            radioButtonOption3.Text = Properties.Settings.Default.AudioOption2;

            audioId1 = Properties.Settings.Default.AudioOption1;
            audioId2 = Properties.Settings.Default.AudioOption2;
            audioId3 = Properties.Settings.Default.AudioOption3;


            textBoxAudioTextBox1.Text = Properties.Settings.Default.AudioTextBox1;
            textBoxAudioTextBox2.Text = Properties.Settings.Default.AudioTextBox2;
            textBoxAudioTextBox3.Text = Properties.Settings.Default.AudioTextBox3;


        }

        private void iconPictureBoxAudioSettings_Click(object sender, EventArgs e)
        {
            var popup = new FunctionAudioSource();
            popup.OnAudioSourceSelected = (name, id, option) =>
            {
                switch (option)
                {
                    case 1:
                        radioButtonOption1.Text = name;
                        audioId1 = name;
                        Properties.Settings.Default.AudioOption1 = name;
                        Properties.Settings.Default.AudioOption1 = name;
                        break;
                    case 2:
                        radioButtonOption2.Text = name;
                        audioId2 = name;
                        Properties.Settings.Default.AudioOption1 = name;
                        Properties.Settings.Default.AudioOption2 = name;
                        break;
                    case 3:
                        radioButtonOption3.Text = name;
                        audioId3 = name;
                        Properties.Settings.Default.AudioOption2 = name;
                        Properties.Settings.Default.AudioOption3 = name;
                        break;
                }
                Properties.Settings.Default.Save();
            };
            popup.ShowDialog();
        }

        private void radioButtonOption1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonOption1.Checked)
            {
                MessageBox.Show($"Byter till: {audioId1}", "Ljudväxling");
                BytLjudenhet(audioId1);
            }
        }

        private void radioButtonOption2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonOption2.Checked)
            {
                MessageBox.Show($"Byter till: {audioId2}", "Ljudväxling");
                BytLjudenhet(audioId2);
            }
        }
















        private void textBoxAudioTextBox1_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.AudioTextBox1 = textBoxAudioTextBox1.Text;
            Properties.Settings.Default.Save();
        }

        private void textBoxAudioTextBox2_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.AudioTextBox2 = textBoxAudioTextBox2.Text;
            Properties.Settings.Default.Save();
        }

        private void textBoxAudioTextBox3_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.AudioTextBox3 = textBoxAudioTextBox3.Text;

            Properties.Settings.Default.Save();
        }












        private void radioButtonOption3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonOption3.Checked)
            {
                MessageBox.Show($"Byter till: {audioId3}", "Ljudväxling");
                BytLjudenhet(audioId3);
            }
        }

        private void BytLjudenhet(string deviceName)
        {
            try
            {
                string exePath = Path.Combine(Application.StartupPath, "nircmd.exe");

                if (!File.Exists(exePath))
                {
                    string zipPath = Path.Combine(Application.StartupPath, "Resources", "Program", "nircmd.zip");
                    if (File.Exists(zipPath))
                        System.IO.Compression.ZipFile.ExtractToDirectory(zipPath, Application.StartupPath);
                }

                if (!File.Exists(exePath))
                {
                    MessageBox.Show("nircmd.exe saknas och kunde inte packas upp.");
                    return;
                }

                Process.Start(new ProcessStartInfo
                {
                    FileName = exePath,
                    Arguments = $"setdefaultsounddevice \"{deviceName}\"",
                    CreateNoWindow = true,
                    UseShellExecute = false
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fel vid byte av ljudenhet: " + ex.Message);
            }
        }
    }
}
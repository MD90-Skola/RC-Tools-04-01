using System;
using System.Collections.Generic;
using System.Windows.Forms;
using NAudio.CoreAudioApi;

namespace Modern.Forms.FolderFunctions
{
    public partial class FunctionAudioSource : Form
    {
        public Action<string, int> OnAudioSourceSelected;

        public FunctionAudioSource()
        {
            InitializeComponent();
        }

        private void FunctionAudioSource_Load(object sender, EventArgs e)
        {
            LoadAudioDevices();


        }

        private void LoadAudioDevices()
        {
            try
            {
                var enumerator = new MMDeviceEnumerator();
                var devices = enumerator.EnumerateAudioEndPoints(DataFlow.Render, DeviceState.Active);

                checkedListBoxAudioOptions.Items.Clear();
                foreach (var device in devices)
                {
                    checkedListBoxAudioOptions.Items.Add(device.FriendlyName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kunde inte läsa ljudenheter: " + ex.Message);
            }
        }

        private void buttonOption1_Click(object sender, EventArgs e)
        {
            SendSelectedDevice(1);
        }

        private void buttonOption2_Click(object sender, EventArgs e)
        {
            SendSelectedDevice(2);
        }

        private void buttonOption3_Click(object sender, EventArgs e)
        {
            SendSelectedDevice(3);
        }

        private void SendSelectedDevice(int option)
        {
            if (checkedListBoxAudioOptions.SelectedItem != null)
            {
                string selectedDevice = checkedListBoxAudioOptions.SelectedItem.ToString();
                OnAudioSourceSelected?.Invoke(selectedDevice, option);
                this.Close();
            }
            else
            {
                MessageBox.Show("Välj en ljudenhet först.");
            }
        }

        private void checkedListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Valfri: du kan lägga till logik här om du vill reagera direkt på val
        }

        private void checkedListBoxAudioOptions_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

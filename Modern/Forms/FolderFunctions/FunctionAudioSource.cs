// Popup-ljudkällor med korrekt spacing i CheckedListBox

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using NAudio.CoreAudioApi;

namespace Modern.Forms.FolderFunctions
{
    public partial class FunctionAudioSource : Form
    {
        public Action<string, int> OnAudioSourceSelected;

        public FunctionAudioSource()
        {
            InitializeComponent();

            // Flyttat hit från Designer – här funkar det!
            checkedListBoxAudioOptions.DrawMode = DrawMode.OwnerDrawFixed;
            checkedListBoxAudioOptions.ItemHeight = 42;
            checkedListBoxAudioOptions.DrawItem += CheckedListBoxAudioOptions_DrawItem;
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

        private void buttonOption1_Click(object sender, EventArgs e) => SendSelectedDevice(1);
        private void buttonOption2_Click(object sender, EventArgs e) => SendSelectedDevice(2);
        private void buttonOption3_Click(object sender, EventArgs e) => SendSelectedDevice(3);

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

        private void checkedListBoxAudioOptions_SelectedIndexChanged(object sender, EventArgs e) { }

        private void CheckedListBoxAudioOptions_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            var listBox = (CheckedListBox)sender;
            var item = listBox.Items[e.Index];
            bool isChecked = listBox.GetItemChecked(e.Index);

            e.DrawBackground();

            CheckBoxState state = isChecked ? CheckBoxState.CheckedNormal : CheckBoxState.UncheckedNormal;
            Point checkBoxLocation = new Point(e.Bounds.Left + 5, e.Bounds.Top + (e.Bounds.Height - 16) / 2);
            CheckBoxRenderer.DrawCheckBox(e.Graphics, checkBoxLocation, state);

            Rectangle textRect = new Rectangle(e.Bounds.Left + 26, e.Bounds.Top + 10, e.Bounds.Width - 26, e.Bounds.Height);
            TextRenderer.DrawText(e.Graphics, item.ToString(), e.Font, textRect, e.ForeColor, TextFormatFlags.Left);

            e.DrawFocusRectangle();
        }
    }
}

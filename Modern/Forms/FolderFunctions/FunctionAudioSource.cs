using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using NAudio.CoreAudioApi;

namespace Modern.Forms.FolderFunctions
{
    public partial class FunctionAudioSource : Form
    {
        public Action<string, string, int> OnAudioSourceSelected;
        private List<AudioDeviceInfo> ljudEnheter = new List<AudioDeviceInfo>();

        public FunctionAudioSource()
        {
            InitializeComponent();
            this.Load += FunctionAudioSource_Load;
        }

        private void FunctionAudioSource_Load(object sender, EventArgs e)
        {
            checkedListBoxAudioOptions.DrawMode = DrawMode.OwnerDrawFixed;
            checkedListBoxAudioOptions.ItemHeight = 40;
            checkedListBoxAudioOptions.DrawItem += CheckedListBoxAudioOptions_DrawItem;
            LaddaLjudEnheter();
        }

        private void LaddaLjudEnheter()
        {
            checkedListBoxAudioOptions.Items.Clear();
            ljudEnheter.Clear();

            var enumerator = new MMDeviceEnumerator();
            var devices = enumerator.EnumerateAudioEndPoints(DataFlow.Render, DeviceState.Active);

            foreach (var d in devices)
            {
                var info = new AudioDeviceInfo { Name = d.FriendlyName, ID = d.ID };
                ljudEnheter.Add(info);
                checkedListBoxAudioOptions.Items.Add(info);
            }
        }

        private void buttonOption1_Click(object sender, EventArgs e) => Välj(1);
        private void buttonOption2_Click(object sender, EventArgs e) => Välj(2);
        private void buttonOption3_Click(object sender, EventArgs e) => Välj(3);

        private void Välj(int val)
        {
            if (checkedListBoxAudioOptions.SelectedItem is AudioDeviceInfo selected)
            {
                OnAudioSourceSelected?.Invoke(selected.Name, selected.ID, val);
                this.Close();
            }
            else
            {
                MessageBox.Show("Välj en ljudkälla först.");
            }
        }

        private void CheckedListBoxAudioOptions_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;
            var listBox = (CheckedListBox)sender;
            var item = (AudioDeviceInfo)listBox.Items[e.Index];
            bool isChecked = listBox.GetItemChecked(e.Index);

            e.DrawBackground();
            CheckBoxRenderer.DrawCheckBox(
                e.Graphics,
                new Point(e.Bounds.Left + 5, e.Bounds.Top + (e.Bounds.Height - 16) / 2),
                isChecked ? System.Windows.Forms.VisualStyles.CheckBoxState.CheckedNormal : System.Windows.Forms.VisualStyles.CheckBoxState.UncheckedNormal);

            var textRect = new Rectangle(e.Bounds.Left + 26, e.Bounds.Top + 10, e.Bounds.Width - 26, e.Bounds.Height);
            TextRenderer.DrawText(e.Graphics, item.Name, e.Font, textRect, e.ForeColor, TextFormatFlags.Left);

            e.DrawFocusRectangle();
        }
    }

    public class AudioDeviceInfo
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public override string ToString() => Name;
    }
}

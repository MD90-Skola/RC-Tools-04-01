using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Modern.Forms
{
    public partial class FormINSTALL : Form
    {
        private bool allSelected = false;

        public FormINSTALL()
        {
            InitializeComponent();
        }

        private void FormINSTALL_Load(object sender, EventArgs e)
        {
            checkedListBox1.DrawMode = DrawMode.OwnerDrawFixed;
            checkedListBox1.FormattingEnabled = false;
            checkedListBox1.ItemHeight = 80;

            checkedListBox1.DrawItem += checkedListBox_DrawItem;
            checkedListBox1.MouseDown += checkedListBox_MouseDown;

            var programList = FunctionBloatWare.GetProgramList();
            foreach (var app in programList.OrderBy(p => p.DisplayName))
            {
                checkedListBox1.Items.Add($"{app.DisplayName}");
            }
        }

        private void checkedListBox_MouseDown(object sender, MouseEventArgs e)
        {
            int index = checkedListBox1.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches)
            {
                bool current = checkedListBox1.GetItemChecked(index);
                checkedListBox1.SetItemChecked(index, !current);
            }
        }

        private void checkedListBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            e.DrawBackground();
            bool isChecked = checkedListBox1.GetItemChecked(e.Index);
            string text = checkedListBox1.Items[e.Index].ToString();

            CheckBoxState state = isChecked ? CheckBoxState.CheckedNormal : CheckBoxState.UncheckedNormal;
            Size checkBoxSize = CheckBoxRenderer.GetGlyphSize(e.Graphics, state);
            Point checkBoxLocation = new Point(e.Bounds.Left + 5, e.Bounds.Top + (e.Bounds.Height - checkBoxSize.Height) / 2);
            CheckBoxRenderer.DrawCheckBox(e.Graphics, checkBoxLocation, state);

            Rectangle textRect = new Rectangle(e.Bounds.Left + 30, e.Bounds.Top, e.Bounds.Width - 35, e.Bounds.Height);
            TextRenderer.DrawText(e.Graphics, text, e.Font, textRect, e.ForeColor,
    TextFormatFlags.Left | TextFormatFlags.WordBreak | TextFormatFlags.LeftAndRightPadding);


            e.DrawFocusRectangle();
        }

        private void buttonAll_Click(object sender, EventArgs e)
        {
            allSelected = !allSelected;
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, allSelected);
            }
            buttonAll.Text = allSelected ? "Avmarkera alla" : "Välj alla";
        }

        private void buttonInstall_Click(object sender, EventArgs e)
        {
            List<string> selected = new List<string>();

            foreach (string item in checkedListBox1.CheckedItems)
            {
                string packageName = item.Split('(', ')')[1];
                selected.Add(packageName);
            }

            if (selected.Count > 0)
            {
                FunctionBloatWare.InstallApps(selected);
                MessageBox.Show("Valda program installeras.");
            }
            else
            {
                MessageBox.Show("Välj minst ett program att installera.");
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tredjepartsprogram kan inte tas bort automatiskt via denna funktion.");
        }
    }
}

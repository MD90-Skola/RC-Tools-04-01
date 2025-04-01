using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Modern.Forms
{
    public partial class FormCONFIG : Form
    {
        private bool allSelected = false;

        public FormCONFIG()
        {
            InitializeComponent();
           
        }

        private void FormCONFIG_Load(object sender, EventArgs e)
        {
            checkedListBox1.DrawMode = DrawMode.OwnerDrawFixed;
            checkedListBox1.ItemHeight = 45;
            checkedListBox1.DrawItem += checkedListBox_DrawItem;
            checkedListBox1.MouseDown += checkedListBox_MouseDown;

            var bloatwareList = FunctionBloatWare.GetBloatwareList();
            foreach (var app in bloatwareList)
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

            Rectangle textRect = new Rectangle(e.Bounds.Left + 30, e.Bounds.Top, e.Bounds.Width - 30, e.Bounds.Height);
            TextRenderer.DrawText(e.Graphics, text, e.Font, textRect, e.ForeColor, TextFormatFlags.Left | TextFormatFlags.VerticalCenter);

            e.DrawFocusRectangle();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> selected = new List<string>();

            foreach (string item in checkedListBox1.CheckedItems)
            {
                string packageName = item.Split('(', ')')[1];
                selected.Add(packageName);
            }

            if (selected.Count > 0)
            {
                FunctionBloatWare.RemoveApps(selected);
                MessageBox.Show("Valda appar tas bort.");
            }
            else
            {
                MessageBox.Show("Välj minst en app att ta bort.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            allSelected = !allSelected;
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, allSelected);
            }
            button2.Text = allSelected ? "Avmarkera" : "Välj alla";
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

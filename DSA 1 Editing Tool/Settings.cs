using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DSA_1_Editing_Tool
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void Settings_Shown(object sender, EventArgs e)
        {
            cbData.Checked = Properties.Settings.Default.loadData;
            cbAnimations.Checked = Properties.Settings.Default.loadAnims;
            cbImages.Checked = Properties.Settings.Default.loadImages;
            tbFolder.Text = Properties.Settings.Default.DefaultExportPath;
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.loadData = cbData.Checked;
            Properties.Settings.Default.loadAnims = cbAnimations.Checked;
            Properties.Settings.Default.loadImages = cbImages.Checked;
            Properties.Settings.Default.loadImages = cbImages.Checked;
            Properties.Settings.Default.DefaultExportPath = tbFolder.Text;
            Properties.Settings.Default.Save();
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            folderBrowser.SelectedPath = tbFolder.Text;
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                tbFolder.Text = folderBrowser.SelectedPath;
            }
        }
    }
}

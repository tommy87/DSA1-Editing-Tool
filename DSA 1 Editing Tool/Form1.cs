using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using DSA_1_Editing_Tool.File_Loader;

namespace DSA_1_Editing_Tool
{
    public partial class Form1 : Form
    {
        CDSAFileLoader itsDSAFileLoader = new CDSAFileLoader();

        public Form1()
        {
            InitializeComponent();
            folderBrowserDialog1.SelectedPath = "C:\\";

            CDebugger.IncommingMessage += HandleDebugMessage;

            if (CHelpFunctions.IsRunningOnMono())
                this.prepaireItemsForMono();
        }
        private void Form1_Shown(object sender, EventArgs e)
        {
            if ((System.IO.File.Exists(Properties.Settings.Default.DefaultDSAPath + "\\SCHICKM.EXE")) || (System.IO.File.Exists(Properties.Settings.Default.DefaultDSAPath + "/SCHICKM.EXE")))
            {
                CDebugger.addDebugLine("---Lade Default Pfad---");
                this.openFile(Properties.Settings.Default.DefaultDSAPath);
            }
            else if (System.IO.File.Exists("C:\\dosgames\\DSA1\\SCHICKM.EXE"))
            {
                CDebugger.addDebugLine("---Lade Default Pfad---");
                this.openFile("C:\\dosgames\\DSA1");
            }
        }   
        private void HandleDebugMessage(object sender, CDebugger.DebugEventArgs e)
        {
            switch (e.messageTyp)
            {
                case CDebugger.DebugMessageTyp.newLine:
                    this.rTB_Debug.AppendText(e.newLine + Environment.NewLine);
                    break;
                case CDebugger.DebugMessageTyp.error:
                    this.rTB_Debug.SelectionStart = this.rTB_Debug.TextLength;
                    this.rTB_Debug.SelectionLength = 0;
                    this.rTB_Debug.SelectionColor = Color.Red;
                    this.rTB_Debug.AppendText(e.newLine + Environment.NewLine);
                    this.rTB_Debug.SelectionColor = this.rTB_Debug.ForeColor;
                    break;
                case CDebugger.DebugMessageTyp.clearMessage:
                    this.rTB_Debug.ResetText();
                    break;
            }
        }

        private void tSBOpenFile_Click(object sender, EventArgs e)
        {
            this.openFile(null);
        }
        private void openFile(string filename)
        {
            if (filename == null)
            {
                DialogResult objResult = folderBrowserDialog1.ShowDialog();

                if (objResult == System.Windows.Forms.DialogResult.OK)
                {
                    if (this.itsDSAFileLoader.loadFiles(folderBrowserDialog1.SelectedPath))
                    {
                        this.entpackenNachToolStripMenuItem.Enabled = true;
                        this.bilderExportierenNachToolStripMenuItem.Enabled = true;
                    }
                    else
                    {
                        this.entpackenNachToolStripMenuItem.Enabled = false;
                        this.bilderExportierenNachToolStripMenuItem.Enabled = false;
                    }

                    this.loadAllTabs();
                }
            }
            else
            {
                if (this.itsDSAFileLoader.loadFiles(filename))
                {
                    this.entpackenNachToolStripMenuItem.Enabled = true;
                    this.bilderExportierenNachToolStripMenuItem.Enabled = true;
                    folderBrowserDialog1.SelectedPath = filename;
                }
                else
                {
                    this.entpackenNachToolStripMenuItem.Enabled = false;
                    this.bilderExportierenNachToolStripMenuItem.Enabled = false;
                }
                this.loadAllTabs();
            }
        }

        private void prepaireItemsForMono()
        {
            //---------Items----------
            this.Item_dgvList.Visible = false;
            this.Item_lbList.Location = this.Item_dgvList.Location;
            this.Item_lbList.Size = this.Item_dgvList.Size;
            this.Item_lbList.Visible = true;

            //---------Dialoge----------
            this.Dialoge_dgvList.Visible = false;
            this.Dialoge_lbList.Location = this.Dialoge_dgvList.Location;
            this.Dialoge_lbList.Size = this.Dialoge_dgvList.Size;
            this.Dialoge_lbList.Visible = true;

            this.Dialoge_dgvTexte.Visible = false;
            this.Dialoge_lbTexte.Location = this.Dialoge_dgvTexte.Location;
            this.Dialoge_lbTexte.Size = this.Dialoge_dgvTexte.Size;
            this.Dialoge_lbTexte.Visible = true;

            this.Dialoge_dgvLayout.Visible = false;
            this.Dialoge_lbLayout.Location = this.Dialoge_dgvLayout.Location;
            this.Dialoge_lbLayout.Size = this.Dialoge_dgvLayout.Size;
            this.Dialoge_lbLayout.Visible = true;

            this.Dialoge_dgvGesprächspartner.Visible = false;
            this.Dialoge_lbGesprächspartner.Location = this.Dialoge_dgvGesprächspartner.Location;
            this.Dialoge_lbGesprächspartner.Size = this.Dialoge_dgvGesprächspartner.Size;
            this.Dialoge_lbGesprächspartner.Visible = true;

            //---------Texte----------
            this.Texte_Filenames_dgvList.Visible = false;
            this.Texte_Filenames_lbList.Location = this.Texte_Filenames_dgvList.Location;
            this.Texte_Filenames_lbList.Size = this.Texte_Filenames_dgvList.Size;
            this.Texte_Filenames_lbList.Visible = true;

            this.Texte_dgvTexte.Visible = false;
            this.Texte_lbTexte.Location = this.Texte_dgvTexte.Location;
            this.Texte_lbTexte.Size = this.Texte_dgvTexte.Size;
            this.Texte_lbTexte.Visible = true;

            //---------Monster----------
            this.Monster_dgvList.Visible = false;
            this.Monster_lbList.Location = this.Monster_dgvList.Location;
            this.Monster_lbList.Size = this.Monster_dgvList.Size;
            this.Monster_lbList.Visible = true;

            //---------Kämpfe----------
            this.Fight_dgvList.Visible = false;
            this.Fight_lbList.Location = this.Fight_dgvList.Location;
            this.Fight_lbList.Size = this.Fight_dgvList.Size;
            this.Fight_lbList.Visible = true;

            this.Fight_Items_dgvList.Visible = false;
            this.Fight_Items_lbList.Location = this.Fight_Items_dgvList.Location;
            this.Fight_Items_lbList.Size = this.Fight_Items_dgvList.Size;
            this.Fight_Items_lbList.Visible = true;

            this.Fight_Monster_dgvList.Visible = false;
            this.Fight_Monster_lbList.Location = this.Fight_Monster_dgvList.Location;
            this.Fight_Monster_lbList.Size = this.Fight_Monster_dgvList.Size;
            this.Fight_Monster_lbList.Visible = true;

            //---------Städte----------
            this.Städte_dgvList.Visible = false;
            this.Städte_lbList.Location = this.Städte_dgvList.Location;
            this.Städte_lbList.Size = this.Städte_dgvList.Size;
            this.Städte_lbList.Visible = true;

            this.Städte_dgvStadtEventList.Visible = false;
            this.Städte_lbStadtEventList.Location = this.Städte_dgvStadtEventList.Location;
            this.Städte_lbStadtEventList.Size = this.Städte_dgvStadtEventList.Size;
            this.Städte_lbStadtEventList.Visible = true;

            //---------Dungeons----------
            this.Dungeons_dgvList.Visible = false;
            this.Dungeons_lbList.Location = this.Dungeons_dgvList.Location;
            this.Dungeons_lbList.Size = this.Dungeons_dgvList.Size;
            this.Dungeons_lbList.Visible = true;

            this.Dungeons_dgvDoors.Visible = false;
            this.Dungeons_lbDoors.Location = this.Dungeons_dgvDoors.Location;
            this.Dungeons_lbDoors.Size = this.Dungeons_dgvDoors.Size;
            this.Dungeons_lbDoors.Visible = true;

            this.Dungeons_dgvDungeonFloors.Visible = false;
            this.Dungeons_lbDungeonFloors.Location = this.Dungeons_dgvDungeonFloors.Location;
            this.Dungeons_lbDungeonFloors.Size = this.Dungeons_dgvDungeonFloors.Size;
            this.Dungeons_lbDungeonFloors.Visible = true;

            this.Dungeons_dgvFights.Visible = false;
            this.Dungeons_lbFights.Location = this.Dungeons_dgvFights.Location;
            this.Dungeons_lbFights.Size = this.Dungeons_dgvFights.Size;
            this.Dungeons_lbFights.Visible = true;

            this.Dungeons_dgvStairs.Visible = false;
            this.Dungeons_lbStairs.Location = this.Dungeons_dgvStairs.Location;
            this.Dungeons_lbStairs.Size = this.Dungeons_dgvStairs.Size;
            this.Dungeons_lbStairs.Visible = true;

            //---------Bilder----------
            this.Bilder_dgvList.Visible = false;
            this.Bilder_lbList.Location = this.Bilder_dgvList.Location;
            this.Bilder_lbList.Size = this.Bilder_dgvList.Size;
            this.Bilder_lbList.Visible = true;

            this.Bilder_dgvBildnummer.Visible = false;
            this.Bilder_lbBildnummer.Location = this.Bilder_dgvBildnummer.Location;
            this.Bilder_lbBildnummer.Size = this.Bilder_dgvBildnummer.Size;
            this.Bilder_lbBildnummer.Visible = true;

        }

        private void loadAllTabs()
        {
            this.loadItemTab();
            this.loadDialoge();
            this.loadTextTab();
            this.loadMonsterTab();
            this.loadKampfTab();
            this.loadStädteTab();
            this.loadDungeonsTab();
            this.loadBilderTab();
            this.loadRouts();
        }
        private void loadItemTab()
        {
            if (CHelpFunctions.IsRunningOnMono())
            {
                this.Item_lbList.Items.Clear();

                this.Item_lbList.Items.AddRange(this.itsDSAFileLoader.itemList.itsItemNames.ToArray());
                for (int i = this.itsDSAFileLoader.itemList.itsItemNames.Count; i < this.itsDSAFileLoader.itemList.itsItems.Count; i++)
                {
                    this.Item_lbList.Items.Add("???");
                }

                if (this.Item_lbList.Items.Count > 0)
                    this.Item_lbList.SelectedIndex = 0;
            }
            else
            {
                this.Item_dgvList.Rows.Clear();

                for (int i = 0; i < this.itsDSAFileLoader.itemList.itsItems.Count; i++)
                {
                    if (i < this.itsDSAFileLoader.itemList.itsItemNames.Count)
                        this.Item_dgvList.Rows.Add(i.ToString("D3"), this.itsDSAFileLoader.itemList.itsItemNames[i]);
                    else
                        this.Item_dgvList.Rows.Add(i.ToString("D3"), "???");
                }
            }
        }
        private void loadDialoge()
        {
            if (CHelpFunctions.IsRunningOnMono())
            {
                this.Dialoge_lbList.Items.Clear();

                string[] items = new string[this.itsDSAFileLoader.dialoge.itsDialoge.Count];
                for (int i = 0; i < this.itsDSAFileLoader.dialoge.itsDialoge.Count; i++)
                    items[i] = this.itsDSAFileLoader.dialoge.itsDialoge[i].Key;

                this.Dialoge_lbList.Items.AddRange(items);

                if (this.Dialoge_lbList.Items.Count > 0)
                    this.Dialoge_lbList.SelectedIndex = 0;
            }
            else
            {
                this.Dialoge_dgvList.Rows.Clear();

                for (int i = 0; i < this.itsDSAFileLoader.dialoge.itsDialoge.Count; i++)
                {
                    this.Dialoge_dgvList.Rows.Add(i.ToString("D3"), this.itsDSAFileLoader.dialoge.itsDialoge[i].Key);
                }
            }

        }
        private void loadTextTab()
        {
            if (CHelpFunctions.IsRunningOnMono())
            {
                this.Texte_Filenames_lbList.Items.Clear();

                if (this.rB_Texte_LTX.Checked)
                {
                    string[] items = new string[this.itsDSAFileLoader.texte.LTX_Texte.Count];
                    for (int i = 0; i < this.itsDSAFileLoader.texte.LTX_Texte.Count; i++)
                        items[i] = this.itsDSAFileLoader.texte.LTX_Texte[i].Key;

                    this.Texte_Filenames_lbList.Items.AddRange(items);
                }
                else
                {
                    string[] items = new string[this.itsDSAFileLoader.texte.DTX_Texte.Count];
                    for (int i = 0; i < this.itsDSAFileLoader.texte.DTX_Texte.Count; i++)
                        items[i] = this.itsDSAFileLoader.texte.DTX_Texte[i].Key;

                    this.Texte_Filenames_lbList.Items.AddRange(items);
                }

                if (this.Texte_Filenames_lbList.Items.Count > 0)
                    this.Texte_Filenames_lbList.SelectedIndex = 0;
            }
            else
            {
                this.Texte_Filenames_dgvList.Rows.Clear();

                if (this.rB_Texte_LTX.Checked)
                {
                    for (int i = 0; i < this.itsDSAFileLoader.texte.LTX_Texte.Count; i++)
                    {
                        this.Texte_Filenames_dgvList.Rows.Add(i.ToString("D3"), this.itsDSAFileLoader.texte.LTX_Texte[i].Key);
                    }
                }
                else
                {
                    for (int i = 0; i < this.itsDSAFileLoader.texte.DTX_Texte.Count; i++)
                    {
                        this.Texte_Filenames_dgvList.Rows.Add(i.ToString("D3"), this.itsDSAFileLoader.texte.DTX_Texte[i].Key);
                    }
                }
            }
        }
        private void loadMonsterTab()
        {
            if (CHelpFunctions.IsRunningOnMono())
            {
                this.Monster_lbList.Items.Clear();

                this.Monster_lbList.Items.AddRange(this.itsDSAFileLoader.monster.itsMonsterNames.ToArray());
                for (int i = this.itsDSAFileLoader.monster.itsMonsterNames.Count; i < this.itsDSAFileLoader.monster.itsMonsterStats.Count; i++)
                    this.Monster_lbList.Items.Add("???");

                if (this.Monster_lbList.Items.Count > 0)
                    this.Monster_lbList.SelectedIndex = 0;
            }
            else
            {
                this.Monster_dgvList.Rows.Clear();

                for (int i = 0; i < this.itsDSAFileLoader.monster.itsMonsterStats.Count; i++)
                {
                    if (i < this.itsDSAFileLoader.monster.itsMonsterNames.Count)
                        this.Monster_dgvList.Rows.Add(i.ToString("D3"), this.itsDSAFileLoader.monster.itsMonsterNames[i]);
                    else
                        this.Monster_dgvList.Rows.Add(i.ToString("D3"), "???");
                }
            }
        }
        private void loadKampfTab()
        {
            if (CHelpFunctions.IsRunningOnMono())
            {
                this.Fight_lbList.Items.Clear();

                string[] items = new string[this.itsDSAFileLoader.kampf.itsFight_LST.Count];
                for (int i = 0; i < this.itsDSAFileLoader.kampf.itsFight_LST.Count; i++)
                    items[i] = this.itsDSAFileLoader.kampf.itsFight_LST[i].name;

                this.Fight_lbList.Items.AddRange(items);

                if (this.Fight_lbList.Items.Count > 0)
                    this.Fight_lbList.SelectedIndex = 0;
            }
            else
            {
                this.Fight_dgvList.Rows.Clear();

                for (int i = 0; i < this.itsDSAFileLoader.kampf.itsFight_LST.Count; i++)
                {
                    CFight_LST fight = this.itsDSAFileLoader.kampf.itsFight_LST[i];
                    this.Fight_dgvList.Rows.Add(i.ToString("D3"), fight.nummerDesScenarios.ToString("D3"), fight.name);     //D3 ->Decimal 3
                }
            }
        }
        private void loadStädteTab()
        {
            if (CHelpFunctions.IsRunningOnMono())
            {
                this.Städte_lbList.Items.Clear();

                string[] items = new string[this.itsDSAFileLoader.städte.itsTowns.Count];
                for (int i = 0; i < this.itsDSAFileLoader.städte.itsTowns.Count; i++)
                    items[i] = this.itsDSAFileLoader.städte.itsTowns[i].Key;

                this.Städte_lbList.Items.AddRange(items);

                if (this.Städte_lbList.Items.Count > 0)
                    this.Städte_lbList.SelectedIndex = 0;
            }
            else
            {
                this.Städte_dgvList.Rows.Clear();

                for (int i = 0; i < this.itsDSAFileLoader.städte.itsTowns.Count; i++)
                {
                    this.Städte_dgvList.Rows.Add(i.ToString("D3"), this.itsDSAFileLoader.städte.itsTowns[i].Key);
                }
            }
        }
        private void loadDungeonsTab()
        {
            if (CHelpFunctions.IsRunningOnMono())
            {
                this.Dungeons_lbList.Items.Clear();

                string[] items = new string[this.itsDSAFileLoader.dungeons.itsDungeons.Count];
                for (int i = 0; i < this.itsDSAFileLoader.dungeons.itsDungeons.Count; i++)
                    items[i] = this.itsDSAFileLoader.dungeons.itsDungeons[i].Key;

                this.Dungeons_lbList.Items.AddRange(items);

                if (this.Dungeons_lbList.Items.Count > 0)
                    this.Dungeons_lbList.SelectedIndex = 0;
            }
            else
            {
                this.Dungeons_dgvList.Rows.Clear();

                for (int i = 0; i < this.itsDSAFileLoader.dungeons.itsDungeons.Count; i++)
                {
                    this.Dungeons_dgvList.Rows.Add(i.ToString("D3"), this.itsDSAFileLoader.dungeons.itsDungeons[i].Key);
                }
            }
        }
        private void loadBilderTab()
        {
            if (CHelpFunctions.IsRunningOnMono())
            {
                this.Bilder_lbList.Items.Clear();

                string[] items = new string[this.itsDSAFileLoader.bilder.itsImages.Count];
                for (int i = 0; i < this.itsDSAFileLoader.bilder.itsImages.Count; i++)
                    items[i] = this.itsDSAFileLoader.bilder.itsImages[i].Key;

                this.Bilder_lbList.Items.AddRange(items);

                if (this.Bilder_lbList.Items.Count > 0)
                    this.Bilder_lbList.SelectedIndex = 0;
            }
            else
            {
                this.Bilder_dgvList.Rows.Clear();

                for (int i = 0; i < this.itsDSAFileLoader.bilder.itsImages.Count; i++)
                {
                    this.Bilder_dgvList.Rows.Add(i.ToString("D3"), this.itsDSAFileLoader.bilder.itsImages[i].Key);
                };
            }
        }
        private void loadRouts()
        {
            Image image = this.itsDSAFileLoader.bilder.getWoldMap();

            if (image == null)
                image = new Bitmap(320, 200);

            Graphics g = Graphics.FromImage(image);

            Pen p_red = new Pen(Color.Red, 1);
            Pen p_blue = new Pen(Color.Blue, 1);
            Pen p_green = new Pen(Color.GreenYellow, 1);

            foreach (List<Point> points in this.itsDSAFileLoader.routen.itsLRout)
            {
                for (int i = 0; i < (points.Count - 1); i++)
                {
                    g.DrawLine(p_red, points[i], points[i + 1]);
                }
            }

            foreach (List<Point> points in this.itsDSAFileLoader.routen.itsSRout)
            {
                for (int i = 0; i < (points.Count - 1); i++)
                {
                    g.DrawLine(p_green, points[i], points[i + 1]);
                }
            }

            foreach (List<Point> points in this.itsDSAFileLoader.routen.itsHSRout)
            {
                for (int i = 0; i < (points.Count - 1); i++)
                {
                    g.DrawLine(p_blue, points[i], points[i + 1]);
                }
            }

            //this.Rout_pictureBox.Image = image;
            this.Rout_pictureBox.BackgroundImage = image;

        }

        //------------Items-----------------------------
        private void Item_dgvList_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                DataGridViewSelectedRowCollection items = Item_dgvList.SelectedRows;
                if (items.Count <= 0)
                {
                    return;
                }

                ItemTab_loadSelectedItem(Convert.ToInt32(items[0].Cells[0].Value));
                
            }
            catch (SystemException e2)
            {
                CDebugger.addErrorLine("Fehler beim laden des Items:");
                CDebugger.addErrorLine(e2.ToString());
            }
        }
        private void Item_lbList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Item_lbList.SelectedIndex < 0)
                return;

            this.ItemTab_loadSelectedItem(this.Item_lbList.SelectedIndex);
        }
        private void ItemTab_loadSelectedItem(int index)
        {
            if ((index >= 0) && (index < this.itsDSAFileLoader.itemList.itsItems.Count))
            {
                CItemList.CItem item = this.itsDSAFileLoader.itemList.itsItems[index];
                this.tB_Item_IconID.Text = item.IconID.ToString();
                this.tB_Item_Gewicht.Text = item.Gewicht.ToString();
                this.tB_Item_Magisch.Text = item.MagischToString();//item.Magisch.ToString();
                this.tB_Item_Position.Text = item.AnziehbarAnPositionToString();//item.AnziehbarAnPosition.ToString();
                this.tB_Item_Price.Text = item.PreisToString(); //item.Preis.ToString();
                this.tB_Item_PriceBase.Text = item.Preis_GrundeinheitToString();//item.Preis_Grundeinheit.ToString();
                this.tB_Item_SortimentsID.Text = item.SortimentsID.ToString();

                this.loadItemTyp(item.ItemTyp);

                this.Item_PictureBox.BackgroundImage = this.itsDSAFileLoader.bilder.getItemImageByID(item.IconID);


            }
            else
                CDebugger.addDebugLine("loadSelectedItem: index is out if Range");
        }
        private void loadItemTyp(byte itemTyp)
        {
            if ((itemTyp & 0x01) != 0)
                this.Items_cBItemTypBit_.Checked = true;
            else
                this.Items_cBItemTypBit_.Checked = false;

            if ((itemTyp & 0x02) != 0)
                this.Items_cBItemTypBit_2.Checked = true;
            else
                this.Items_cBItemTypBit_2.Checked = false;

            if ((itemTyp & 0x04) != 0)
                this.Items_cBItemTypBit_3.Checked = true;
            else
                this.Items_cBItemTypBit_3.Checked = false;

            if ((itemTyp & 0x08) != 0)
                this.Items_cBItemTypBit_4.Checked = true;
            else
                this.Items_cBItemTypBit_4.Checked = false;


            if ((itemTyp & 0x10) != 0)
                this.Items_cBItemTypBit_5.Checked = true;
            else
                this.Items_cBItemTypBit_5.Checked = false;

            if ((itemTyp & 0x20) != 0)
                this.Items_cBItemTypBit_6.Checked = true;
            else
                this.Items_cBItemTypBit_6.Checked = false;

            if ((itemTyp & 0x40) != 0)
                this.Items_cBItemTypBit_7.Checked = true;
            else
                this.Items_cBItemTypBit_7.Checked = false;

            if ((itemTyp & 0x80) != 0)
                this.Items_cBItemTypBit_8.Checked = true;
            else
                this.Items_cBItemTypBit_8.Checked = false;
        }

        //------------Dialoge---------------------------
        private void Dialoge_dgvList_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                DataGridViewSelectedRowCollection dialogFile = Dialoge_dgvList.SelectedRows;

                if (dialogFile.Count <= 0)
                    return;

                this.Dialoge_dgvGesprächspartner.Rows.Clear();
                this.Dialoge_dgvLayout.Rows.Clear();
                this.Dialoge_dgvTexte.Rows.Clear();

                int index = Convert.ToInt32(dialogFile[0].Cells[0].Value);
                if (index >= this.itsDSAFileLoader.dialoge.itsDialoge.Count)
                    return;

                CDialoge.CDialog dialog = this.itsDSAFileLoader.dialoge.itsDialoge[index].Value;
                for (int i = 0; i < dialog.itsPartner.Count; i++)
                {
                    this.Dialoge_dgvGesprächspartner.Rows.Add(i.ToString(), dialog.itsPartner[i].name);
                }

                for (int i = 0; i < dialog.itsDialogZeile.Count; i++)
                {
                    this.Dialoge_dgvLayout.Rows.Add(i.ToString());
                }

                for (int i = 0; i < dialog.itsTexte.Count; i++)
                {
                    this.Dialoge_dgvTexte.Rows.Add(i.ToString(), dialog.itsTexte[i]);
                }

            }
            catch (SystemException)
            {
                CDebugger.addErrorLine("Fehler beim Laden der Dialoge");
            }
        }
        private void Dialoge_dgvGesprächspartner_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                DataGridViewSelectedRowCollection dialogFile = Dialoge_dgvList.SelectedRows;
                DataGridViewSelectedRowCollection selectedPartner = Dialoge_dgvGesprächspartner.SelectedRows;

                if (dialogFile.Count <= 0 || selectedPartner.Count <= 0)
                {
                    this.Dialoge_btStartTestDialog.Enabled = false;
                    this.disableTestDialoge();
                    return;
                }

                int index_1 = Convert.ToInt32(dialogFile[0].Cells[0].Value);
                int index_2 = Convert.ToInt32(selectedPartner[0].Cells[0].Value);

                if (index_1 >= this.itsDSAFileLoader.dialoge.itsDialoge.Count || index_2 >= this.itsDSAFileLoader.dialoge.itsDialoge[index_1].Value.itsPartner.Count)
                {
                    this.Dialoge_btStartTestDialog.Enabled = false;
                    this.disableTestDialoge();
                    return;
                }

                CDialoge.CGesprächspartner partner = this.itsDSAFileLoader.dialoge.itsDialoge[index_1].Value.itsPartner[index_2];
                this.Dialoge_pictureBox.BackgroundImage = this.itsDSAFileLoader.bilder.getIn_HeadsImageByID(partner.BildID_IN_HEADS_NVF);

                this.Dialoge_Gesprächspartner_tbBildID.Text = partner.BildID_IN_HEADS_NVF.ToString();
                this.Dialoge_Gesprächspartner_tbIndexStartLayout.Text = partner.offsetStartLayoutZeile.ToString();
                this.Dialoge_Gesprächspartner_tbIndexStartText.Text = partner.offsetStartString.ToString();
                this.Dialoge_Gesprächspartner_tbName.Text = partner.name;

                this.Dialoge_btStartTestDialog.Enabled = true;

            }
            catch (SystemException)
            {
                CDebugger.addErrorLine("Fehler beim Laden des Gesprächspartners(Dialoge)");
            }
        }
        private void Dialoge_dgvTexte_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                DataGridViewSelectedRowCollection dialogFile = Dialoge_dgvList.SelectedRows;
                DataGridViewSelectedRowCollection selectedText = Dialoge_dgvTexte.SelectedRows;

                if (dialogFile.Count <= 0 || selectedText.Count <= 0)
                    return;

                int index_1 = Convert.ToInt32(dialogFile[0].Cells[0].Value);
                int index_2 = Convert.ToInt32(selectedText[0].Cells[0].Value);

                if (index_1 >= this.itsDSAFileLoader.dialoge.itsDialoge.Count || index_2 >= this.itsDSAFileLoader.dialoge.itsDialoge[index_1].Value.itsTexte.Count)
                    return;

                this.Dialoge_rtbCurrenText.Text = this.itsDSAFileLoader.dialoge.itsDialoge[index_1].Value.itsTexte[index_2];

            }
            catch (SystemException)
            {
                CDebugger.addErrorLine("Fehler beim Laden des Textes(Dialoge)");
            }
        }
        private void Dialoge_dgvLayout_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                DataGridViewSelectedRowCollection dialogFile = Dialoge_dgvList.SelectedRows;
                DataGridViewSelectedRowCollection selectedLayout = Dialoge_dgvLayout.SelectedRows;

                if (dialogFile.Count <= 0 || selectedLayout.Count <= 0)
                    return;

                int index_1 = Convert.ToInt32(dialogFile[0].Cells[0].Value);
                int index_2 = Convert.ToInt32(selectedLayout[0].Cells[0].Value);

                if (index_1 >= this.itsDSAFileLoader.dialoge.itsDialoge.Count || index_2 >= this.itsDSAFileLoader.dialoge.itsDialoge[index_1].Value.itsDialogZeile.Count)
                    return;

                CDialoge.CDialogLayoutZeile layout = this.itsDSAFileLoader.dialoge.itsDialoge[index_1].Value.itsDialogZeile[index_2];

                this.Dialoge_Layout_tbTextIndex.Text = layout.offsetHaupttext.ToString();
                this.Dialoge_Layout_tbUnbekannt.Text = layout.unbekannterWert.ToString();
                this.Dialoge_Layout_tbTextIndexAntwort1.Text = layout.Antwort1.ToString();
                this.Dialoge_Layout_tbTextIndexAntwort2.Text = layout.Antwort2.ToString();
                this.Dialoge_Layout_tbTextIndexAntwort3.Text = layout.Antwort3.ToString();
                this.Dialoge_Layout_tbLayoutIndexAntwort1.Text = layout.FolgeLayoutBeiAntwort1.ToString();
                this.Dialoge_Layout_tbLayoutIndexAntwort2.Text = layout.FolgeLayoutBeiAntwort2.ToString();
                this.Dialoge_Layout_tbLayoutIndexAntwort3.Text = layout.FolgeLayoutBeiAntwort3.ToString();

            }
            catch (SystemException)
            {
                CDebugger.addErrorLine("Fehler beim Laden des Textes(Dialoge)");
            }
        }

        private void Dialoge_lbList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Dialoge_lbList.SelectedIndex < 0 || this.Dialoge_lbList.SelectedIndex >= this.itsDSAFileLoader.dialoge.itsDialoge.Count)
                return;

            this.Dialoge_lbLayout.Items.Clear();
            this.Dialoge_lbGesprächspartner.Items.Clear();
            this.Dialoge_lbTexte.Items.Clear();

            CDialoge.CDialog dialog = this.itsDSAFileLoader.dialoge.itsDialoge[this.Dialoge_lbList.SelectedIndex].Value;
            
            string[] items = new string[dialog.itsDialogZeile.Count];
            for (int i = 0; i < dialog.itsDialogZeile.Count; i++)
                items[i] = i.ToString();
            this.Dialoge_lbLayout.Items.AddRange(items);

            items = new string[dialog.itsPartner.Count];
            for (int i = 0; i < dialog.itsPartner.Count; i++)
                items[i] = dialog.itsPartner[i].name;
            this.Dialoge_lbGesprächspartner.Items.AddRange(items);

            this.Dialoge_lbTexte.Items.AddRange(dialog.itsTexte.ToArray());

            if (this.Dialoge_lbLayout.Items.Count > 0)
                this.Dialoge_lbLayout.SelectedIndex = 0;

            if (this.Dialoge_lbGesprächspartner.Items.Count > 0)
                this.Dialoge_lbGesprächspartner.SelectedIndex = 0;

            if (this.Dialoge_lbTexte.Items.Count > 0)
                this.Dialoge_lbTexte.SelectedIndex = 0;

        }
        private void Dialoge_lbGesprächspartner_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Dialoge_lbList.SelectedIndex < 0 || Dialoge_lbGesprächspartner.SelectedIndex < 0)
            {
                this.Dialoge_btStartTestDialog.Enabled = false;
                this.disableTestDialoge();
                return;
            }

            int index_1 = Dialoge_lbList.SelectedIndex;
            int index_2 = Dialoge_lbGesprächspartner.SelectedIndex;

            if (index_1 >= this.itsDSAFileLoader.dialoge.itsDialoge.Count || index_2 >= this.itsDSAFileLoader.dialoge.itsDialoge[index_1].Value.itsPartner.Count)
            {
                this.Dialoge_btStartTestDialog.Enabled = false;
                this.disableTestDialoge();
                return;
            }

            CDialoge.CGesprächspartner partner = this.itsDSAFileLoader.dialoge.itsDialoge[index_1].Value.itsPartner[index_2];
            this.Dialoge_pictureBox.BackgroundImage = this.itsDSAFileLoader.bilder.getIn_HeadsImageByID(partner.BildID_IN_HEADS_NVF);

            this.Dialoge_Gesprächspartner_tbBildID.Text = partner.BildID_IN_HEADS_NVF.ToString();
            this.Dialoge_Gesprächspartner_tbIndexStartLayout.Text = partner.offsetStartLayoutZeile.ToString();
            this.Dialoge_Gesprächspartner_tbIndexStartText.Text = partner.offsetStartString.ToString();
            this.Dialoge_Gesprächspartner_tbName.Text = partner.name;

            this.Dialoge_btStartTestDialog.Enabled = true;
        }
        private void Dialoge_lbTexte_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.Dialoge_lbTexte.SelectedIndex < 0 || this.Dialoge_lbList.SelectedIndex < 0)
                    return;

                int index_1 = this.Dialoge_lbList.SelectedIndex;
                int index_2 = this.Dialoge_lbTexte.SelectedIndex;

                if (index_1 >= this.itsDSAFileLoader.dialoge.itsDialoge.Count || index_2 >= this.itsDSAFileLoader.dialoge.itsDialoge[index_1].Value.itsTexte.Count)
                    return;

                this.Dialoge_rtbCurrenText.Text = this.itsDSAFileLoader.dialoge.itsDialoge[index_1].Value.itsTexte[index_2];

            }
            catch (SystemException)
            {
                CDebugger.addErrorLine("Fehler beim Laden des Textes(Dialoge)");
            }
        }
        private void Dialoge_lbLayout_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.Dialoge_lbList.SelectedIndex < 0 || this.Dialoge_lbLayout.SelectedIndex < 0)
                    return;

                int index_1 = this.Dialoge_lbList.SelectedIndex;
                int index_2 = this.Dialoge_lbLayout.SelectedIndex;

                if (index_1 >= this.itsDSAFileLoader.dialoge.itsDialoge.Count || index_2 >= this.itsDSAFileLoader.dialoge.itsDialoge[index_1].Value.itsDialogZeile.Count)
                    return;

                CDialoge.CDialogLayoutZeile layout = this.itsDSAFileLoader.dialoge.itsDialoge[index_1].Value.itsDialogZeile[index_2];

                this.Dialoge_Layout_tbTextIndex.Text = layout.offsetHaupttext.ToString();
                this.Dialoge_Layout_tbUnbekannt.Text = layout.unbekannterWert.ToString();
                this.Dialoge_Layout_tbTextIndexAntwort1.Text = layout.Antwort1.ToString();
                this.Dialoge_Layout_tbTextIndexAntwort2.Text = layout.Antwort2.ToString();
                this.Dialoge_Layout_tbTextIndexAntwort3.Text = layout.Antwort3.ToString();
                this.Dialoge_Layout_tbLayoutIndexAntwort1.Text = layout.FolgeLayoutBeiAntwort1.ToString();
                this.Dialoge_Layout_tbLayoutIndexAntwort2.Text = layout.FolgeLayoutBeiAntwort2.ToString();
                this.Dialoge_Layout_tbLayoutIndexAntwort3.Text = layout.FolgeLayoutBeiAntwort3.ToString();
            }
            catch (SystemException)
            {
                CDebugger.addErrorLine("Fehler beim Laden des Textes(Dialoge)");
            }
        }

        private void disableTestDialoge()
        {
            this.Dialoge_btTestDialogAntwort1.Text = "";
            this.Dialoge_btTestDialogAntwort2.Text = "";
            this.Dialoge_btTestDialogAntwort3.Text = "";

            this.Dialoge_btTestDialogAntwort1.Enabled = false;
            this.Dialoge_btTestDialogAntwort2.Enabled = false;
            this.Dialoge_btTestDialogAntwort3.Enabled = false;
        }
        private void Dialoge_btStartTestDialog_Click(object sender, EventArgs e)
        {
            try
            {
                int index_1;
                int index_2;

                if (CHelpFunctions.IsRunningOnMono())
                {
                    if (this.Dialoge_lbList.SelectedIndex < 0 || this.Dialoge_lbGesprächspartner.SelectedIndex < 0)
                    {
                        this.Dialoge_btStartTestDialog.Enabled = false;
                        this.disableTestDialoge();
                        return;
                    }

                    index_1 = this.Dialoge_lbList.SelectedIndex;
                    index_2 = this.Dialoge_lbGesprächspartner.SelectedIndex;
                }
                else
                {
                    DataGridViewSelectedRowCollection dialogFile = Dialoge_dgvList.SelectedRows;
                    DataGridViewSelectedRowCollection selectedPartner = Dialoge_dgvGesprächspartner.SelectedRows;

                    if (dialogFile.Count <= 0 || selectedPartner.Count <= 0)
                    {
                        this.Dialoge_btStartTestDialog.Enabled = false;
                        this.disableTestDialoge();
                        return;
                    }

                    index_1 = Convert.ToInt32(dialogFile[0].Cells[0].Value);
                    index_2 = Convert.ToInt32(selectedPartner[0].Cells[0].Value);
                }

                

                if (index_1 >= this.itsDSAFileLoader.dialoge.itsDialoge.Count || index_2 >= this.itsDSAFileLoader.dialoge.itsDialoge[index_1].Value.itsPartner.Count)
                {
                    this.Dialoge_btStartTestDialog.Enabled = false;
                    this.disableTestDialoge();
                    return;
                }

                CDialoge.CDialog dialog = this.itsDSAFileLoader.dialoge.itsDialoge[index_1].Value;
                CDialoge.CGesprächspartner partner = this.itsDSAFileLoader.dialoge.itsDialoge[index_1].Value.itsPartner[index_2];

                if (partner.offsetStartString == 255 || partner.offsetStartString >= dialog.itsTexte.Count)
                    this.Dialoge_rtbTestDialog.Text = "";
                else
                    this.Dialoge_rtbTestDialog.Text = dialog.itsTexte[partner.offsetStartString];

                this.currentDialog = dialog;
                this.offsetCurrentLayout = partner.offsetStartLayoutZeile;
                this.offsetCurrentText = partner.offsetStartString;

                this.loadLayoutForTestDialog(0);
            }
            catch (SystemException)
            {
                CDebugger.addErrorLine("Fehler beim Laden des Gesprächspartners(Dialoge)");
                this.disableTestDialoge();
            }
        }
        private CDialoge.CDialog currentDialog = null;
        private CDialoge.CDialogLayoutZeile currentLayout = null;
        private int offsetCurrentLayout = 0;
        private int offsetCurrentText = 0;
        private void loadLayoutForTestDialog(int layoutIndex)
        {
            this.Dialoge_btTestDialogAntwort1.Enabled = false;
            this.Dialoge_btTestDialogAntwort2.Enabled = false;
            this.Dialoge_btTestDialogAntwort3.Enabled = false;

            if (layoutIndex == 255)
            {
                this.Dialoge_rtbTestDialog.Text = "ende des Dialoges";
                this.disableTestDialoge();
                return;
            }

            layoutIndex += offsetCurrentLayout;

            if (currentDialog == null || layoutIndex >= currentDialog.itsDialogZeile.Count)
            {
                this.Dialoge_rtbTestDialog.Text = "Fehler beim laden des Dialoges";
                this.disableTestDialoge();
                return;
            } 

            this.currentLayout = currentDialog.itsDialogZeile[layoutIndex];

            if (CHelpFunctions.IsRunningOnMono())
                this.Dialoge_lbLayout.SelectedIndex = layoutIndex;
            else
                this.Dialoge_dgvLayout.Rows[layoutIndex].Selected = true;

            if (currentLayout.offsetHaupttext == 255)
                this.Dialoge_rtbTestDialog.Text = "";
            else if ((currentLayout.offsetHaupttext + offsetCurrentText) >= currentDialog.itsTexte.Count)
                this.Dialoge_rtbTestDialog.Text = "Fehler";
            else
                this.Dialoge_rtbTestDialog.Text = currentDialog.itsTexte[currentLayout.offsetHaupttext + offsetCurrentText];

            if (currentLayout.Antwort1 == 0 && currentLayout.FolgeLayoutBeiAntwort1 == 0)
                this.Dialoge_btTestDialogAntwort1.Text = "";
            else if ((currentLayout.Antwort1 + offsetCurrentText) >= currentDialog.itsTexte.Count)
            {
                this.Dialoge_btTestDialogAntwort1.Text = "Fehler";
            }
            else
            {
                this.Dialoge_btTestDialogAntwort1.Enabled = true;
                if (currentLayout.Antwort1 == 0)
                    this.Dialoge_btTestDialogAntwort1.Text = "weiter";
                else
                    this.Dialoge_btTestDialogAntwort1.Text = currentDialog.itsTexte[currentLayout.Antwort1 + offsetCurrentText];
            }

            if (currentLayout.Antwort2 == 0 && currentLayout.FolgeLayoutBeiAntwort2 == 0)
                this.Dialoge_btTestDialogAntwort2.Text = "";
            else if ((currentLayout.Antwort2 + offsetCurrentText) >= currentDialog.itsTexte.Count)
            {
                this.Dialoge_btTestDialogAntwort2.Text = "Fehler";
            }
            else
            {
                this.Dialoge_btTestDialogAntwort2.Enabled = true;
                if (currentLayout.Antwort2 == 0)
                    this.Dialoge_btTestDialogAntwort2.Text = "weiter";
                else
                    this.Dialoge_btTestDialogAntwort2.Text = currentDialog.itsTexte[currentLayout.Antwort2 + offsetCurrentText];
            }

            if (currentLayout.Antwort3 == 0 && currentLayout.FolgeLayoutBeiAntwort3 == 0)
                this.Dialoge_btTestDialogAntwort3.Text = "";
            else if ((currentLayout.Antwort3 + offsetCurrentText) >= currentDialog.itsTexte.Count)
            {
                this.Dialoge_btTestDialogAntwort3.Text = "Fehler";
            }
            else
            {
                this.Dialoge_btTestDialogAntwort3.Enabled = true;
                if (currentLayout.Antwort3 == 0)
                    this.Dialoge_btTestDialogAntwort3.Text = "weiter";
                else
                    this.Dialoge_btTestDialogAntwort3.Text = currentDialog.itsTexte[currentLayout.Antwort3 + offsetCurrentText];
            }               

        }

        private void Dialoge_btTestDialogAntwort1_Click(object sender, EventArgs e)
        {
            if (currentLayout == null)
                return;

            this.loadLayoutForTestDialog(currentLayout.FolgeLayoutBeiAntwort1);
        }
        private void Dialoge_btTestDialogAntwort2_Click(object sender, EventArgs e)
        {
            if (currentLayout == null)
                return;

            this.loadLayoutForTestDialog(currentLayout.FolgeLayoutBeiAntwort2);
        }
        private void Dialoge_btTestDialogAntwort3_Click(object sender, EventArgs e)
        {
            if (currentLayout == null)
                return;

            this.loadLayoutForTestDialog(currentLayout.FolgeLayoutBeiAntwort3);
        } 

        //------------Texte-----------------------------
        private void rB_Texte_CheckedChanged(object sender, EventArgs e)
        {
            this.loadTextTab();
        }

        private void Texte_Filenames_dgvList_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection texte = Texte_Filenames_dgvList.SelectedRows;
            if (texte.Count <= 0)
            {
                return;
            }
            
            try
            {
                int index = Convert.ToInt32(texte[0].Cells[0].Value);

                if (this.rB_Texte_LTX.Checked)
                {
                    this.Texte_dgvTexte.Rows.Clear();

                    if (this.itsDSAFileLoader.texte.LTX_Texte.Count <= index)
                        return;

                    for (int i = 0; i < this.itsDSAFileLoader.texte.LTX_Texte[index].Value.Count; i++)
                    {
                        this.Texte_dgvTexte.Rows.Add(i.ToString("D3"), this.itsDSAFileLoader.texte.LTX_Texte[index].Value[i]);
                    }
                }
                else
                {
                    this.Texte_dgvTexte.Rows.Clear();

                    if (this.itsDSAFileLoader.texte.DTX_Texte.Count <= index)
                        return;

                    for (int i = 0; i < this.itsDSAFileLoader.texte.DTX_Texte[index].Value.Count; i++)
                    {
                        this.Texte_dgvTexte.Rows.Add(i.ToString("D3"), this.itsDSAFileLoader.texte.DTX_Texte[index].Value[i]);
                    }
                }
            }
            catch (SystemException e2)
            {
                CDebugger.addErrorLine("Fehler beim laden der Texte:");
                CDebugger.addErrorLine(e2.ToString());
            }
        }
        private void dGV_Texte_Texte_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection texte = this.Texte_dgvTexte.SelectedRows;
            if (texte.Count <= 0)
            {
                return;
            }

            if (texte[0].Cells[1].Value != null)
            {
                this.rTB_Texte_text.Clear();
                this.rTB_Texte_text.Text = texte[0].Cells[1].Value.ToString();

                List<Int32> startvaluesRed = new List<int>();
                List<Int32> startvaluesYellow = new List<int>();
                List<Int32> startvaluesBlue = new List<int>();
                List<Int32> endvalues = new List<int>();

                for (int i = 0; i < this.rTB_Texte_text.Text.Length; i++)
                {
                    if (this.rTB_Texte_text.Text[i] == (char)241)
                        startvaluesRed.Add(i);
                    else if (this.rTB_Texte_text.Text[i] == (char)242)
                        startvaluesYellow.Add(i);
                    else if (this.rTB_Texte_text.Text[i] == (char)243)
                        startvaluesBlue.Add(i);
                    else if (this.rTB_Texte_text.Text[i] == (char)240)
                        endvalues.Add(i);
                }

                foreach (int start in startvaluesRed)
                {
                    foreach (int end in endvalues)
                    {
                        if (end > start)
                        {
                            this.rTB_Texte_text.SelectionStart = start;
                            this.rTB_Texte_text.SelectionLength = end - start + 1;
                            this.rTB_Texte_text.SelectionColor = Color.Red;
                            break;
                        }
                    }
                }
                foreach (int start in startvaluesYellow)
                {
                    foreach (int end in endvalues)
                    {
                        if (end > start)
                        {
                            this.rTB_Texte_text.SelectionStart = start;
                            this.rTB_Texte_text.SelectionLength = end - start + 1;
                            this.rTB_Texte_text.SelectionColor = Color.Gold;
                            break;
                        }
                    }
                }
                foreach (int start in startvaluesBlue)
                {
                    foreach (int end in endvalues)
                    {
                        if (end > start)
                        {
                            this.rTB_Texte_text.SelectionStart = start;
                            this.rTB_Texte_text.SelectionLength = end - start + 1;
                            this.rTB_Texte_text.SelectionColor = Color.Blue;
                            break;
                        }
                    }
                }
            }


            //for
            //if (this.rTB_Texte_text.Text.Contains(((char)240).ToString()))
            //{

            //}
        }

        private void Texte_Filenames_lbList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Texte_Filenames_lbList.SelectedIndex < 0)
            {
                return;
            }

            try
            {
                int index = this.Texte_Filenames_lbList.SelectedIndex;
                this.Texte_lbTexte.Items.Clear();

                if (this.rB_Texte_LTX.Checked)
                {
                    if (this.itsDSAFileLoader.texte.LTX_Texte.Count <= index)
                        return;

                    this.Texte_lbTexte.Items.AddRange(this.itsDSAFileLoader.texte.LTX_Texte[index].Value.ToArray());
                    
                }
                else
                {
                    if (this.itsDSAFileLoader.texte.DTX_Texte.Count <= index)
                        return;

                    this.Texte_lbTexte.Items.AddRange(this.itsDSAFileLoader.texte.DTX_Texte[index].Value.ToArray());
                }

                if (this.Texte_lbTexte.Items.Count > 0)
                    this.Texte_lbTexte.SelectedIndex = 0;
            }
            catch (SystemException e2)
            {
                CDebugger.addErrorLine("Fehler beim laden der Texte:");
                CDebugger.addErrorLine(e2.ToString());
            }
        }
        private void Texte_lbTexte_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Texte_lbTexte.SelectedIndex < 0 || this.Texte_Filenames_lbList.SelectedIndex < 0)
            {
                return;
            }

            int index_1 = this.Texte_Filenames_lbList.SelectedIndex;
            int index_2 = this.Texte_lbTexte.SelectedIndex;

            try
            {
                this.rTB_Texte_text.Clear();
                if (this.rB_Texte_LTX.Checked)
                    this.rTB_Texte_text.Text = this.itsDSAFileLoader.texte.LTX_Texte[index_1].Value[index_2];
                else
                    this.rTB_Texte_text.Text = this.itsDSAFileLoader.texte.DTX_Texte[index_1].Value[index_2];

                List<Int32> startvaluesRed = new List<int>();
                List<Int32> startvaluesYellow = new List<int>();
                List<Int32> startvaluesBlue = new List<int>();
                List<Int32> endvalues = new List<int>();

                for (int i = 0; i < this.rTB_Texte_text.Text.Length; i++)
                {
                    if (this.rTB_Texte_text.Text[i] == (char)241)
                        startvaluesRed.Add(i);
                    else if (this.rTB_Texte_text.Text[i] == (char)242)
                        startvaluesYellow.Add(i);
                    else if (this.rTB_Texte_text.Text[i] == (char)243)
                        startvaluesBlue.Add(i);
                    else if (this.rTB_Texte_text.Text[i] == (char)240)
                        endvalues.Add(i);
                }

                foreach (int start in startvaluesRed)
                {
                    foreach (int end in endvalues)
                    {
                        if (end > start)
                        {
                            this.rTB_Texte_text.SelectionStart = start;
                            this.rTB_Texte_text.SelectionLength = end - start + 1;
                            this.rTB_Texte_text.SelectionColor = Color.Red;
                            break;
                        }
                    }
                }
                foreach (int start in startvaluesYellow)
                {
                    foreach (int end in endvalues)
                    {
                        if (end > start)
                        {
                            this.rTB_Texte_text.SelectionStart = start;
                            this.rTB_Texte_text.SelectionLength = end - start + 1;
                            this.rTB_Texte_text.SelectionColor = Color.Gold;
                            break;
                        }
                    }
                }
                foreach (int start in startvaluesBlue)
                {
                    foreach (int end in endvalues)
                    {
                        if (end > start)
                        {
                            this.rTB_Texte_text.SelectionStart = start;
                            this.rTB_Texte_text.SelectionLength = end - start + 1;
                            this.rTB_Texte_text.SelectionColor = Color.Blue;
                            break;
                        }
                    }
                }
            }
            catch (SystemException e2)
            {
                CDebugger.addErrorLine("Fehler beim Laden der Texte");
                CDebugger.addErrorLine(e2.ToString());
            }
        } 

        //------------Monster-----------------------------
        private void Monster_dgvList_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                DataGridViewSelectedRowCollection monsters = this.Monster_dgvList.SelectedRows;
                if (monsters.Count <= 0)
                {
                    return;
                }

                this.MonsterTab_loadSelectedMonster(Convert.ToInt32(monsters[0].Cells[0].Value));
            }
            catch (SystemException e2)
            {
                CDebugger.addErrorLine("Fehler beim laden des Monster:");
                CDebugger.addErrorLine(e2.ToString());
            }
        }
        private void Monster_lbList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.Monster_lbList.SelectedIndex < 0)
                {
                    return;
                }

                this.MonsterTab_loadSelectedMonster(this.Monster_lbList.SelectedIndex);
            }
            catch (SystemException e2)
            {
                CDebugger.addErrorLine("Fehler beim laden des Monster:");
                CDebugger.addErrorLine(e2.ToString());
            }
        } 
        private void MonsterTab_loadSelectedMonster(int index)
        {
            if (index >= 0 && index < this.itsDSAFileLoader.monster.itsMonsterStats.Count)
            {
                CMonster.CMonsterStats monster = this.itsDSAFileLoader.monster.itsMonsterStats[index];
                this.tB_Monster_AE.Text = CHelpFunctions.dsaWürfelwertToString(monster.AE_Würfel);
                this.tB_Monster_AnzahlAttacken.Text = monster.Anzahl_Attacken.ToString();
                this.tB_Monster_AnzahlSchussattacken.Text = monster.Anzahl_Geschosse.ToString();
                this.tB_Monster_AnzahlWurfattacken.Text = monster.Anzahl_Wurfwaffen.ToString();
                this.tB_Monster_AT.Text = monster.AT.ToString();
                this.tB_Monster_BildID.Text = BitConverter.ToString(new byte[]{monster.MonsterGraphicID});//monster.MonsterGraphicID.ToString();
                this.tB_Monster_BP.Text = monster.BP.ToString();
                this.tB_Monster_CH.Text = CHelpFunctions.dsaWürfelwertToString(monster.CH_Würfel);
                this.tB_Monster_ErstAP.Text = monster.erstAP.ToString();
                this.tB_Monster_FF.Text = CHelpFunctions.dsaWürfelwertToString(monster.FF_Würfel);
                this.tB_Monster_FluchtBeiXXLP.Text = monster.Flucht_Bei_XX_LP.ToString();
                this.tB_Monster_GE.Text = CHelpFunctions.dsaWürfelwertToString(monster.GE_Würfel);
                this.tB_Monster_Größenklasse.Text = monster.Größenklasse.ToString();
                this.tB_Monster_IDMagierklasse.Text = monster.ID_Magierklasse.ToString();
                this.tB_Monster_ImmunitätNormaleWaffen.Text = monster.Immunität_gegen_Normale_Waffen.ToString();
                this.tB_Monster_IN.Text = CHelpFunctions.dsaWürfelwertToString(monster.IN_Würfel);
                this.tB_Monster_KK.Text = CHelpFunctions.dsaWürfelwertToString(monster.KK_Würfel);
                this.tB_Monster_KL.Text = CHelpFunctions.dsaWürfelwertToString(monster.KL_Würfel);
                this.tB_Monster_LE.Text = CHelpFunctions.dsaWürfelwertToString(monster.LE_Würfel);
                this.tB_Monster_MonsterID.Text = monster.MonsterID.ToString();
                this.tB_Monster_MonsterTyp.Text = monster.MonsterTyp.ToString();
                this.tB_Monster_MR.Text = CHelpFunctions.dsaWürfelwertToString(monster.MR_Würfel);
                this.tB_Monster_MU.Text = CHelpFunctions.dsaWürfelwertToString(monster.MU_Würfel);
                this.tB_Monster_PA.Text = monster.PA.ToString();
                this.tB_Monster_RS.Text = monster.RS.ToString();
                this.tB_Monster_SchadeGeschosse.Text = CHelpFunctions.dsaWürfelwertToString(monster.Schaden_Schusswaffen_Würfel);
                this.tB_Monster_Schaden1Angriff.Text = CHelpFunctions.dsaWürfelwertToString(monster.Schaden_1_Angriff_Würfel);
                this.tB_Monster_Schaden2Angriff.Text = CHelpFunctions.dsaWürfelwertToString(monster.Schaden_2_Angriff_Würfel);
                this.tB_Monster_SchadenWurfwaffen.Text = CHelpFunctions.dsaWürfelwertToString(monster.Schaden_Wurfwaffen_Würfel);
                this.tB_Monster_Stufe.Text = monster.Stufe.ToString();

                //this.Monster_pictureBox.BackgroundImage = this.itsDSAFileLoader.bilder.getMonsterImageByID(monster.MonsterGraphicID);
                this.Monster_pictureBox.BackgroundImage = this.itsDSAFileLoader.bilder.getMonsterImageByID(monster.MonsterID - 1);
                
            }
            else
                CDebugger.addErrorLine("loadSelectedMonster: index is out if Range");
        }

        //------------Kämpfe-----------------------------
        private void dGV_FightList_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection kämpfe = this.Fight_dgvList.SelectedRows;
            if (kämpfe.Count <= 0)
            {
                return;
            }


            try
            {
                int i = Convert.ToInt32(kämpfe[0].Cells[0].Value);

                if (i < this.itsDSAFileLoader.kampf.itsFight_LST.Count)
                {
                    CFight_LST fight = this.itsDSAFileLoader.kampf.itsFight_LST[i];

                    this.Fight_Monster_dgvList.Rows.Clear();
                    for (int j = 0; j < fight.itsMonsterInfos.Count; j++)
                    {
                        this.Fight_Monster_dgvList.Rows.Add(j.ToString("D2"), fight.itsMonsterInfos[j].GegnerID.ToString("D3"), this.itsDSAFileLoader.monster.getMonsterNameByID(fight.itsMonsterInfos[j].GegnerID));
                    }

                    this.Fight_Items_dgvList.Rows.Clear();
                    for (int j = 0; j < fight.itsBeute.Count; j++)
                    {
                        this.Fight_Items_dgvList.Rows.Add(j.ToString("D2"), fight.itsBeute[j].ItemID.ToString("D3"), this.itsDSAFileLoader.itemList.getItemNameByID(fight.itsBeute[j].ItemID));
                    }

                    this.lB_Fight_Spieler.SelectedIndex = -1;
                    this.lB_Fight_Spieler.SelectedIndex = 0;

                    this.tB_Fight_Silberlinge.Text = fight.Beute_Silberstücke.ToString();
                    this.tB_Fight_Dukaten.Text = fight.Beute_Dukaten.ToString();
                    this.tB_Fight_Heller.Text = fight.Beute_Heller.ToString();
                }
            }
            catch (SystemException e2)
            {
                CDebugger.addErrorLine("Fehler beim laden der Kämpfe:");
                CDebugger.addErrorLine(e2.ToString());
            }
        }
        private void Fight_Monster_dgvList_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection kämpfe = this.Fight_dgvList.SelectedRows;
            DataGridViewSelectedRowCollection monsterFigths = this.Fight_Monster_dgvList.SelectedRows;
            if (kämpfe.Count <= 0 ||monsterFigths.Count <= 0)
            {
                return;
            }
   

            try
            {
                int i = Convert.ToInt32(kämpfe[0].Cells[0].Value);
                int j = Convert.ToInt32(monsterFigths[0].Cells[0].Value);

                if (this.itsDSAFileLoader.kampf.itsFight_LST.Count <= i)
                    return;

                if (this.itsDSAFileLoader.kampf.itsFight_LST[i].itsMonsterInfos.Count <= j)
                    return;

                CFight_MonsterInfo monster = this.itsDSAFileLoader.kampf.itsFight_LST[i].itsMonsterInfos[j];
                this.tB_Fight_Monster_Blickrichtung.Text = monster.Blickrichtung.ToString();
                this.tB_Fight_Monster_ID.Text = monster.GegnerID.ToString();
                this.tB_Fight_Monster_Startrunde.Text = monster.Startrunde.ToString();
                this.tB_Fight_Monster_XPos.Text = monster.Position_X.ToString();
                this.tB_Fight_Monster_YPos.Text = monster.Position_Y.ToString();
            }
            catch (SystemException e2)
            {
                CDebugger.addErrorLine("Fehler beim laden der Kämpfe(Monster):");
                CDebugger.addErrorLine(e2.ToString());

                this.tB_Fight_Monster_Blickrichtung.Text = "";
                this.tB_Fight_Monster_ID.Text = "";
                this.tB_Fight_Monster_Startrunde.Text = "";
                this.tB_Fight_Monster_XPos.Text = "";
                this.tB_Fight_Monster_YPos.Text = "";
            }
        }
        private void Fight_Items_dgvList_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection kämpfe = this.Fight_dgvList.SelectedRows;
            DataGridViewSelectedRowCollection itemFigths = this.Fight_Items_dgvList.SelectedRows;
            if (kämpfe.Count <= 0 || itemFigths.Count <= 0)
            {
                return;
            }

            try
            {
                int i = Convert.ToInt32(kämpfe[0].Cells[0].Value);
                int j = Convert.ToInt32(itemFigths[0].Cells[0].Value);

                if (this.itsDSAFileLoader.kampf.itsFight_LST.Count <= 0)
                    return;

                if (this.itsDSAFileLoader.kampf.itsFight_LST[i].itsBeute.Count <= 0)
                    return;

                this.tB_Fight_Item_Menge.Text = this.itsDSAFileLoader.kampf.itsFight_LST[i].itsBeute[j].Menge.ToString();
            }
            catch (SystemException e2)
            {
                CDebugger.addErrorLine("Fehler beim laden der Kämpfe(Items):");
                CDebugger.addErrorLine(e2.ToString());
                this.tB_Fight_Item_Menge.Text = "";
            }
        }  

        private void Fight_lbList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Fight_lbList.SelectedIndex < 0)
            {
                return;
            }


            try
            {
                int index = this.Fight_lbList.SelectedIndex;

                if (index < this.itsDSAFileLoader.kampf.itsFight_LST.Count)
                {
                    CFight_LST fight = this.itsDSAFileLoader.kampf.itsFight_LST[index];

                    this.Fight_Monster_lbList.Items.Clear();
                    string[] items = new string[fight.itsMonsterInfos.Count];
                    for (int j = 0; j < fight.itsMonsterInfos.Count; j++)
                    {
                        //this.Fight_Monster_dgvList.Rows.Add(j.ToString("D2"), fight.itsMonsterInfos[j].GegnerID.ToString("D3"), this.itsDSAFileLoader.monster.getMonsterNameByID(fight.itsMonsterInfos[j].GegnerID));
                        items[j] = this.itsDSAFileLoader.monster.getMonsterNameByID(fight.itsMonsterInfos[j].GegnerID);
                    }
                    this.Fight_Monster_lbList.Items.AddRange(items);

                    this.Fight_Items_lbList.Items.Clear();
                    items = new string[fight.itsBeute.Count];
                    for (int j = 0; j < fight.itsBeute.Count; j++)
                    {
                        //this.Fight_Items_dgvList.Rows.Add(j.ToString("D2"), fight.itsBeute[j].ItemID.ToString("D3"), this.itsDSAFileLoader.itemList.getItemNameByID(fight.itsBeute[j].ItemID));
                        items[j] = this.itsDSAFileLoader.itemList.getItemNameByID(fight.itsBeute[j].ItemID);
                    }
                    this.Fight_Items_lbList.Items.AddRange(items);

                    if (this.Fight_Monster_lbList.Items.Count > 0)
                        this.Fight_Monster_lbList.SelectedIndex = 0;

                    if (this.Fight_Items_lbList.Items.Count > 0)
                        this.Fight_Items_lbList.SelectedIndex = 0;

                    this.lB_Fight_Spieler.SelectedIndex = -1;
                    this.lB_Fight_Spieler.SelectedIndex = 0;

                    this.tB_Fight_Silberlinge.Text = fight.Beute_Silberstücke.ToString();
                    this.tB_Fight_Dukaten.Text = fight.Beute_Dukaten.ToString();
                    this.tB_Fight_Heller.Text = fight.Beute_Heller.ToString();
                }
            }
            catch (SystemException e2)
            {
                CDebugger.addErrorLine("Fehler beim laden der Kämpfe:");
                CDebugger.addErrorLine(e2.ToString());
            }
        }
        private void Fight_Monster_lbList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Fight_lbList.SelectedIndex < 0 || this.Fight_Monster_lbList.SelectedIndex < 0)
            {
                return;
            }


            try
            {
                int index_1 = this.Fight_lbList.SelectedIndex;
                int index_2 = this.Fight_Monster_lbList.SelectedIndex;

                if (this.itsDSAFileLoader.kampf.itsFight_LST.Count <= index_1)
                    return;

                if (this.itsDSAFileLoader.kampf.itsFight_LST[index_1].itsMonsterInfos.Count <= index_2)
                    return;

                CFight_MonsterInfo monster = this.itsDSAFileLoader.kampf.itsFight_LST[index_1].itsMonsterInfos[index_2];
                this.tB_Fight_Monster_Blickrichtung.Text = monster.Blickrichtung.ToString();
                this.tB_Fight_Monster_ID.Text = monster.GegnerID.ToString();
                this.tB_Fight_Monster_Startrunde.Text = monster.Startrunde.ToString();
                this.tB_Fight_Monster_XPos.Text = monster.Position_X.ToString();
                this.tB_Fight_Monster_YPos.Text = monster.Position_Y.ToString();
            }
            catch (SystemException e2)
            {
                CDebugger.addErrorLine("Fehler beim laden der Kämpfe(Monster):");
                CDebugger.addErrorLine(e2.ToString());

                this.tB_Fight_Monster_Blickrichtung.Text = "";
                this.tB_Fight_Monster_ID.Text = "";
                this.tB_Fight_Monster_Startrunde.Text = "";
                this.tB_Fight_Monster_XPos.Text = "";
                this.tB_Fight_Monster_YPos.Text = "";
            }
        }
        private void Fight_Items_lbList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Fight_lbList.SelectedIndex < 0 || this.Fight_Items_lbList.SelectedIndex < 0)
            {
                return;
            }

            try
            {
                int index_1 = this.Fight_lbList.SelectedIndex;
                int index_2 = this.Fight_Items_lbList.SelectedIndex;

                if (this.itsDSAFileLoader.kampf.itsFight_LST.Count <= 0)
                    return;

                if (this.itsDSAFileLoader.kampf.itsFight_LST[index_1].itsBeute.Count <= 0)
                    return;

                this.tB_Fight_Item_Menge.Text = this.itsDSAFileLoader.kampf.itsFight_LST[index_1].itsBeute[index_2].Menge.ToString();
            }
            catch (SystemException e2)
            {
                CDebugger.addErrorLine("Fehler beim laden der Kämpfe(Items):");
                CDebugger.addErrorLine(e2.ToString());
                this.tB_Fight_Item_Menge.Text = "";
            }
        } 

        private void lB_Fight_Spieler_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int index_1;
                int index_2;

                if (CHelpFunctions.IsRunningOnMono())
                {
                    if (this.lB_Fight_Spieler.SelectedIndex < 0 || this.Fight_lbList.SelectedIndex < 0)
                        return;

                    index_1 = this.Fight_lbList.SelectedIndex;
                    index_2 = this.lB_Fight_Spieler.SelectedIndex;
                }
                else
                {
                    DataGridViewSelectedRowCollection kämpfe = this.Fight_dgvList.SelectedRows;
                    if (kämpfe.Count <= 0 || lB_Fight_Spieler.SelectedIndex < 0)
                    {
                        return;
                    }

                    index_1 = Convert.ToInt32(kämpfe[0].Cells[0].Value);
                    index_2 = this.lB_Fight_Spieler.SelectedIndex;

                    if (this.itsDSAFileLoader.kampf.itsFight_LST.Count <= 0)
                        return;
                }

                CFight_SpielerInfo spieler = this.itsDSAFileLoader.kampf.itsFight_LST[index_1].itsSpielerInfos[index_2];
                this.tB_Fight_Spieler_Blickrichtung.Text = CHelpFunctions.dsaRichtungToString(spieler.Blickrichtung);
                this.tB_Fight_Spieler_Startrunde.Text = spieler.Startrunde.ToString();
                this.tB_Fight_Spieler_XPos.Text = spieler.Position_X.ToString();
                this.tB_Fight_Spieler_YPos.Text = spieler.Position_Y.ToString();
            }
            catch (SystemException e2)
            {
                CDebugger.addErrorLine("Fehler beim laden der Kämpfe(Spielerinfos):");
                CDebugger.addErrorLine(e2.ToString());

                this.tB_Fight_Spieler_Blickrichtung.Text = "";
                this.tB_Fight_Spieler_Startrunde.Text = "";
                this.tB_Fight_Spieler_XPos.Text = "";
                this.tB_Fight_Spieler_YPos.Text = "";
            }
        }

        //------------Städte-----------------------------
        public int currentTown = -1;
        public int selectedEvent = -1;
        Bitmap TownImage;

        private void Städte_dgvList_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection towns = this.Städte_dgvList.SelectedRows;
            if (towns.Count <= 0)
            {
                this.currentTown = -1;
                this.selectedEvent = -1;
                this.drawCity();

                return;
            }

            try
            {
                int i = Convert.ToInt32(towns[0].Cells[0].Value);

                if (i < this.itsDSAFileLoader.städte.itsTowns.Count)
                {
                    this.currentTown = i;
                    CTown town = this.itsDSAFileLoader.städte.itsTowns[i].Value;

                    this.Städte_dgvStadtEventList.Rows.Clear();
                    for (int j = 0; j < town.townEvents.Count; j++)
                    {
                        this.Städte_dgvStadtEventList.Rows.Add(j.ToString("D3"), town.townEvents[j].Typ.ToString());
                    }
                }
                this.drawCity();
            }
            catch (SystemException e2)
            {
                CDebugger.addErrorLine("Fehler beim laden der Städte:");
                CDebugger.addErrorLine(e2.ToString());

                this.currentTown = -1;
                this.selectedEvent = -1;
                this.drawCity();
            }
        }
        private void Städte_dgvStadtEventList_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection towns = this.Städte_dgvList.SelectedRows;
            DataGridViewSelectedRowCollection events = this.Städte_dgvStadtEventList.SelectedRows;

            if (towns.Count <= 0 || events.Count <= 0)
            {
                this.selectedEvent = -1;
                this.drawCity();

                return;
            }

            try
            {
                int i = Convert.ToInt32(towns[0].Cells[0].Value);
                int j = Convert.ToInt32(events[0].Cells[0].Value);

                if (this.itsDSAFileLoader.städte.itsTowns.Count < i)
                {
                    this.selectedEvent = -1;
                    return;
                }

                if (this.itsDSAFileLoader.städte.itsTowns[i].Value.townEvents.Count < j)
                {
                    this.selectedEvent = -1;
                    return;
                }

                this.selectedEvent = j;
                this.drawCity();

                CTownEvent townEvent = this.itsDSAFileLoader.städte.itsTowns[i].Value.townEvents[j];
                this.Städte_Event_tbIndex_Global.Text = townEvent.Index_Global.ToString();
                this.Städte_Event_tbIndex_Lokal.Text = townEvent.Index_Lokal.ToString();
                this.Städte_Event_tbPosX.Text = townEvent.Position_X.ToString();
                this.Städte_Event_tbPosY.Text = townEvent.Position_Y.ToString();
                this.Städte_Event_tbTyp.Text = townEvent.Typ.ToString();
                this.Städte_Event_tbUnbekannt.Text = townEvent.unbekannt.ToString();
            }
            catch (SystemException e2)
            {
                CDebugger.addErrorLine("Fehler beim laden der Stadtevents:");
                CDebugger.addErrorLine(e2.ToString());

                this.selectedEvent = -1;
                this.Städte_Event_tbIndex_Global.Text = "";
                this.Städte_Event_tbIndex_Lokal.Text = "";
                this.Städte_Event_tbPosX.Text = "";
                this.Städte_Event_tbPosY.Text = "";
                this.Städte_Event_tbTyp.Text = "";
                this.Städte_Event_tbUnbekannt.Text = "";
            }
        }

        private void Städte_lbList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Städte_lbList.SelectedIndex < 0)
            {
                this.currentTown = -1;
                this.selectedEvent = -1;
                this.drawCity();

                return;
            }

            try
            {
                int index = this.Städte_lbList.SelectedIndex;

                if (index < this.itsDSAFileLoader.städte.itsTowns.Count)
                {
                    this.currentTown = index;
                    CTown town = this.itsDSAFileLoader.städte.itsTowns[index].Value;

                    this.Städte_lbStadtEventList.Items.Clear();
                    string[] items = new string[town.townEvents.Count];
                    for (int j = 0; j < town.townEvents.Count; j++)
                    {
                        //this.Städte_dgvStadtEventList.Rows.Add(j.ToString("D3"), town.townEvents[j].Typ.ToString());
                        items[j] = j.ToString();
                    }
                    this.Städte_lbStadtEventList.Items.AddRange(items);

                    if (this.Städte_lbStadtEventList.Items.Count > 0)
                        this.Städte_lbStadtEventList.SelectedIndex = 0;

                }
                this.drawCity();
            }
            catch (SystemException e2)
            {
                CDebugger.addErrorLine("Fehler beim laden der Städte:");
                CDebugger.addErrorLine(e2.ToString());

                this.currentTown = -1;
                this.selectedEvent = -1;
                this.drawCity();
            }
        }
        private void Städte_lbStadtEventList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Städte_lbList.SelectedIndex < 0 || this.Städte_lbStadtEventList.SelectedIndex < 0)
            {
                this.selectedEvent = -1;
                this.drawCity();

                return;
            }

            try
            {
                int index_1 = this.Städte_lbList.SelectedIndex;
                int index_2 = this.Städte_lbStadtEventList.SelectedIndex;

                if (this.itsDSAFileLoader.städte.itsTowns.Count < index_1)
                {
                    this.selectedEvent = -1;
                    return;
                }

                if (this.itsDSAFileLoader.städte.itsTowns[index_1].Value.townEvents.Count < index_2)
                {
                    this.selectedEvent = -1;
                    return;
                }

                this.selectedEvent = index_2;
                this.drawCity();

                CTownEvent townEvent = this.itsDSAFileLoader.städte.itsTowns[index_1].Value.townEvents[index_2];
                this.Städte_Event_tbIndex_Global.Text = townEvent.Index_Global.ToString();
                this.Städte_Event_tbIndex_Lokal.Text = townEvent.Index_Lokal.ToString();
                this.Städte_Event_tbPosX.Text = townEvent.Position_X.ToString();
                this.Städte_Event_tbPosY.Text = townEvent.Position_Y.ToString();
                this.Städte_Event_tbTyp.Text = townEvent.Typ.ToString();
                this.Städte_Event_tbUnbekannt.Text = townEvent.unbekannt.ToString();
            }
            catch (SystemException e2)
            {
                CDebugger.addErrorLine("Fehler beim laden der Stadtevents:");
                CDebugger.addErrorLine(e2.ToString());

                this.selectedEvent = -1;
                this.Städte_Event_tbIndex_Global.Text = "";
                this.Städte_Event_tbIndex_Lokal.Text = "";
                this.Städte_Event_tbPosX.Text = "";
                this.Städte_Event_tbPosY.Text = "";
                this.Städte_Event_tbTyp.Text = "";
                this.Städte_Event_tbUnbekannt.Text = "";
            }
        }

        private void drawCity()
        {
            if ((this.currentTown < 0) || (this.itsDSAFileLoader.städte.itsTowns.Count < this.currentTown))
            {
                this.Citys_PictureBox.Image = null;
                return;
            }

            if (TownImage == null)
                TownImage = new Bitmap(this.Citys_PictureBox.Width, this.Citys_PictureBox.Height);

            CTown town = this.itsDSAFileLoader.städte.itsTowns[this.currentTown].Value;

            //Graphics g = this.Städte_TownPanel.CreateGraphics();
            Graphics g = Graphics.FromImage(TownImage);
            g.FillRectangle(new SolidBrush(Color.Black), new Rectangle(0, 0, TownImage.Width, TownImage.Height));

            int PanelBlock_Y = TownImage.Height / 16;
            int PanelBlock_X = TownImage.Width / 32;

            for (int y = 0; y < town.townLängeSN; y++)
            {
                for (int x = 0; x < town.townLängeWO; x++)
                {
                    Color color = getColorFromTownByte(town.townData[x, y]);
                    g.FillRectangle(new SolidBrush(color), new Rectangle(PanelBlock_X * x + 1, PanelBlock_Y * y + 1, PanelBlock_X - 2, PanelBlock_Y - 2));
                }
            }

            if (this.selectedEvent != -1 && this.selectedEvent < town.townEvents.Count)
            {
                CTownEvent townEvent = town.townEvents[selectedEvent];
                g.DrawRectangle(new Pen(Color.Red, 3.0f), new Rectangle(PanelBlock_X * townEvent.Position_X, PanelBlock_Y * townEvent.Position_Y, PanelBlock_X - 1, PanelBlock_Y - 1));
            }

            this.Citys_PictureBox.Image = TownImage;
        }
        private Color getColorFromTownByte(byte value)
        {
            value = (byte)((value & 0xF0) >> 4);
            switch (value)
            {
                case 0:
                    return Color.FromArgb(29, 27, 29);    //Straße
                case 1:
                    return Color.FromArgb(255, 127, 0);   //Tempel
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                    return Color.FromArgb(131, 4, 0);     //haus
                case 10:
                    return Color.FromArgb(0, 0, 255);     //Wasser
                case 11:
                    return Color.FromArgb(0, 206, 0);     //gras
                case 12:
                    return Color.FromArgb(255, 0, 0);     //wegweiser
                case 14:
                case 15:
                    return Color.FromArgb(52, 50, 125);    //Leuchtturm
                case 16:
                    return Color.Lavender;

                default:
                    return Color.FloralWhite;
            }
        }

        //------------Dungeons-----------------------------
        public int currentDungeon = -1;
        public int currentDungeonFloor = -1;
        Bitmap DungeonImage = null;

        private void Dungeons_dgvList_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection dungeons = this.Dungeons_dgvList.SelectedRows;
           
            if (dungeons.Count <= 0)
            {
                this.currentDungeon = -1;
                this.currentDungeonFloor = -1;

                return;
            }

            try
            {
                int i = Convert.ToInt32(dungeons[0].Cells[0].Value);

                if (i < this.itsDSAFileLoader.dungeons.itsDungeons.Count)
                {
                    this.currentDungeon = i;

                    CDungeons.CDungeon dungeon = this.itsDSAFileLoader.dungeons.itsDungeons[i].Value;

                    //--------Ebenen----------
                    this.Dungeons_dgvDungeonFloors.Rows.Clear();
                    for (int j = 0; j < dungeon.floors.Count; j++)
                    {
                        this.Dungeons_dgvDungeonFloors.Rows.Add(j.ToString());
                    }

                    //--------Kämpfe----------
                    this.Dungeons_dgvFights.Rows.Clear();
                    for (int j = 0; j < dungeon.fights.Count; j++)
                    {
                        if (this.itsDSAFileLoader.kampf.itsFight_LST.Count > dungeon.fights[j].KampfID)
                            this.Dungeons_dgvFights.Rows.Add(j.ToString("D3"), this.itsDSAFileLoader.kampf.itsFight_LST[dungeon.fights[j].KampfID].name);
                        else
                            this.Dungeons_dgvFights.Rows.Add(j.ToString("D3"), "???");
                    }

                    //--------Treppen----------
                    this.Dungeons_dgvStairs.Rows.Clear();
                    for (int j = 0; j < dungeon.stairs.Count; j++)
                    {
                        this.Dungeons_dgvStairs.Rows.Add(j.ToString("D3"));
                    }

                    //--------Türen----------
                    this.Dungeons_dgvDoors.Rows.Clear();
                    for (int j = 0; j < dungeon.doors.Count; j++)
                    {
                        this.Dungeons_dgvDoors.Rows.Add(j.ToString("D3"));
                    }
                }
                this.drawDungeon();
            }
            catch (SystemException e2)
            {
                CDebugger.addErrorLine("Fehler beim laden der Dungeons:");
                CDebugger.addErrorLine(e2.ToString());

                this.currentDungeon = -1;
                this.currentDungeonFloor = -1;
            }
        }
        private void Dungeons_dgvDungeonFloors_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection dungeons = this.Dungeons_dgvList.SelectedRows;
            DataGridViewSelectedRowCollection dungeonFloors = this.Dungeons_dgvDungeonFloors.SelectedRows;

            if (dungeons.Count <= 0 || dungeonFloors.Count <= 0)
            {
                this.currentDungeonFloor = -1;
                return;
            }

            try
            {
                int i = Convert.ToInt32(dungeons[0].Cells[0].Value);
                int j = Convert.ToInt32(dungeonFloors[0].Cells[0].Value);

                if ((i < this.itsDSAFileLoader.dungeons.itsDungeons.Count) && (j < this.itsDSAFileLoader.dungeons.itsDungeons[i].Value.floors.Count))
                {
                    this.currentDungeonFloor = j;
                    CDungeons.CDungeon.CFloor floor = this.itsDSAFileLoader.dungeons.itsDungeons[i].Value.floors[j];
                }
                this.drawDungeon();
            }
            catch (SystemException e2)
            {
                CDebugger.addErrorLine("Fehler beim laden der Dungeon ebene:");
                CDebugger.addErrorLine(e2.ToString());

                this.currentDungeonFloor = -1;
                this.drawDungeon();
            }
        }
        private void Dungeons_dgvFights_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection dungeons = this.Dungeons_dgvList.SelectedRows;
            DataGridViewSelectedRowCollection dungeonFights = this.Dungeons_dgvFights.SelectedRows;

            if (dungeons.Count <= 0 || dungeonFights.Count <= 0)
            {
                return;
            }

            try
            {
                int i = Convert.ToInt32(dungeons[0].Cells[0].Value);
                int j = Convert.ToInt32(dungeonFights[0].Cells[0].Value);

                if ((i < this.itsDSAFileLoader.dungeons.itsDungeons.Count) && (j < this.itsDSAFileLoader.dungeons.itsDungeons[i].Value.fights.Count))
                {
                    CDungeons.CDungeon.CDungeonFight fight = this.itsDSAFileLoader.dungeons.itsDungeons[i].Value.fights[j];

                    this.Dungeons_Fights_tBEbene.Text = fight.Ebene.ToString();
                    this.Dungeons_Fights_tBErstAP.Text = fight.extraAP.ToString();
                    this.Dungeons_Fights_tBID.Text = fight.KampfID.ToString();
                    this.Dungeons_Fights_tBPosX.Text = fight.PositionX.ToString();
                    this.Dungeons_Fights_tBPosY.Text = fight.PositionY.ToString();

                    this.Dungeons_Fights_tBFluchtBlickrichtung_1.Text = CHelpFunctions.dsaRichtungToString(fight.Flucht_Blickrichtung[0]);
                    this.Dungeons_Fights_tBFluchtEbene_1.Text = fight.Flucht_Ebene[0].ToString();
                    this.Dungeons_Fights_tBFluchtPosX_1.Text = fight.Flucht_PosX[0].ToString();
                    this.Dungeons_Fights_tBFluchtPosY_1.Text = fight.Flucht_PosY[0].ToString();

                    this.Dungeons_Fights_tBFluchtBlickrichtung_2.Text = CHelpFunctions.dsaRichtungToString(fight.Flucht_Blickrichtung[1]);
                    this.Dungeons_Fights_tBFluchtEbene_2.Text = fight.Flucht_Ebene[1].ToString();
                    this.Dungeons_Fights_tBFluchtPosX_2.Text = fight.Flucht_PosX[1].ToString();
                    this.Dungeons_Fights_tBFluchtPosY_2.Text = fight.Flucht_PosY[1].ToString();

                    this.Dungeons_Fights_tBFluchtBlickrichtung_3.Text = CHelpFunctions.dsaRichtungToString(fight.Flucht_Blickrichtung[2]);
                    this.Dungeons_Fights_tBFluchtEbene_3.Text = fight.Flucht_Ebene[2].ToString();
                    this.Dungeons_Fights_tBFluchtPosX_3.Text = fight.Flucht_PosX[2].ToString();
                    this.Dungeons_Fights_tBFluchtPosY_3.Text = fight.Flucht_PosY[2].ToString();

                    this.Dungeons_Fights_tBFluchtBlickrichtung_4.Text = CHelpFunctions.dsaRichtungToString(fight.Flucht_Blickrichtung[3]);
                    this.Dungeons_Fights_tBFluchtEbene_4.Text = fight.Flucht_Ebene[3].ToString();
                    this.Dungeons_Fights_tBFluchtPosX_4.Text = fight.Flucht_PosX[3].ToString();
                    this.Dungeons_Fights_tBFluchtPosY_4.Text = fight.Flucht_PosY[3].ToString();
                }
                else
                {
                    this.Dungeons_Fights_tBEbene.Text = "";
                    this.Dungeons_Fights_tBErstAP.Text = "";
                    this.Dungeons_Fights_tBID.Text = "";
                    this.Dungeons_Fights_tBPosX.Text = "";
                    this.Dungeons_Fights_tBPosY.Text = "";

                    this.Dungeons_Fights_tBFluchtBlickrichtung_1.Text = "";
                    this.Dungeons_Fights_tBFluchtEbene_1.Text = "";
                    this.Dungeons_Fights_tBFluchtPosX_1.Text = "";
                    this.Dungeons_Fights_tBFluchtPosY_1.Text = "";

                    this.Dungeons_Fights_tBFluchtBlickrichtung_2.Text = "";
                    this.Dungeons_Fights_tBFluchtEbene_2.Text = "";
                    this.Dungeons_Fights_tBFluchtPosX_2.Text = "";
                    this.Dungeons_Fights_tBFluchtPosY_2.Text = "";

                    this.Dungeons_Fights_tBFluchtBlickrichtung_3.Text = "";
                    this.Dungeons_Fights_tBFluchtEbene_3.Text = "";
                    this.Dungeons_Fights_tBFluchtPosX_3.Text = "";
                    this.Dungeons_Fights_tBFluchtPosY_3.Text = "";

                    this.Dungeons_Fights_tBFluchtBlickrichtung_4.Text = "";
                    this.Dungeons_Fights_tBFluchtEbene_4.Text = "";
                    this.Dungeons_Fights_tBFluchtPosX_4.Text = "";
                    this.Dungeons_Fights_tBFluchtPosY_4.Text = "";
                }
            }
            catch (SystemException e2)
            {
                CDebugger.addErrorLine("Fehler beim laden der Dungeon kämpfe:");
                CDebugger.addErrorLine(e2.ToString());

                this.Dungeons_Fights_tBEbene.Text = "";
                this.Dungeons_Fights_tBErstAP.Text = "";
                this.Dungeons_Fights_tBID.Text = "";
                this.Dungeons_Fights_tBPosX.Text = "";
                this.Dungeons_Fights_tBPosY.Text = "";

                this.Dungeons_Fights_tBFluchtBlickrichtung_1.Text = "";
                this.Dungeons_Fights_tBFluchtEbene_1.Text = "";
                this.Dungeons_Fights_tBFluchtPosX_1.Text = "";
                this.Dungeons_Fights_tBFluchtPosY_1.Text = "";

                this.Dungeons_Fights_tBFluchtBlickrichtung_2.Text = "";
                this.Dungeons_Fights_tBFluchtEbene_2.Text = "";
                this.Dungeons_Fights_tBFluchtPosX_2.Text = "";
                this.Dungeons_Fights_tBFluchtPosY_2.Text = "";

                this.Dungeons_Fights_tBFluchtBlickrichtung_3.Text = "";
                this.Dungeons_Fights_tBFluchtEbene_3.Text = "";
                this.Dungeons_Fights_tBFluchtPosX_3.Text = "";
                this.Dungeons_Fights_tBFluchtPosY_3.Text = "";

                this.Dungeons_Fights_tBFluchtBlickrichtung_4.Text = "";
                this.Dungeons_Fights_tBFluchtEbene_4.Text = "";
                this.Dungeons_Fights_tBFluchtPosX_4.Text = "";
                this.Dungeons_Fights_tBFluchtPosY_4.Text = "";
            }
        }
        private void Dungeons_dgvStairs_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection dungeons = this.Dungeons_dgvList.SelectedRows;
            DataGridViewSelectedRowCollection dungeonStairs = this.Dungeons_dgvStairs.SelectedRows;

            if (dungeons.Count <= 0 || dungeonStairs.Count <= 0)
            {
                return;
            }

            try
            {
                int i = Convert.ToInt32(dungeons[0].Cells[0].Value);
                int j = Convert.ToInt32(dungeonStairs[0].Cells[0].Value);

                if ((i < this.itsDSAFileLoader.dungeons.itsDungeons.Count) && (j < this.itsDSAFileLoader.dungeons.itsDungeons[i].Value.stairs.Count))
                {
                    CDungeons.CDungeon.CDungeonStair stair = this.itsDSAFileLoader.dungeons.itsDungeons[i].Value.stairs[j];

                    this.Dungeons_Stairs_tBEbene.Text = stair.Ebene.ToString();
                    this.Dungeons_Stairs_tBPosX.Text = stair.PositionX.ToString();
                    this.Dungeons_Stairs_tBPosY.Text = stair.PositionY.ToString();
                    this.Dungeons_Stairs_tBZielebeneBlickrichtung.Text = CHelpFunctions.dsaRichtungToString(stair.Blickrichtung);
                    this.Dungeons_Stairs_tBZielebeneEbene.Text = stair.getZielebeneString();
                    this.Dungeons_Stairs_tBZielebeneRelPosX.Text = stair.relXPos.ToString();
                    this.Dungeons_Stairs_tBZielebeneRelPosY.Text = stair.relYPos.ToString();
                }
                else
                {
                    this.Dungeons_Stairs_tBEbene.Text = "";
                    this.Dungeons_Stairs_tBPosX.Text = "";
                    this.Dungeons_Stairs_tBPosY.Text = "";
                    this.Dungeons_Stairs_tBZielebeneBlickrichtung.Text = "";
                    this.Dungeons_Stairs_tBZielebeneEbene.Text = "";
                    this.Dungeons_Stairs_tBZielebeneRelPosX.Text = "";
                    this.Dungeons_Stairs_tBZielebeneRelPosY.Text = "";
                }
            }
            catch (SystemException e2)
            {
                CDebugger.addErrorLine("Fehler beim laden der Dungeon Treppen:");
                CDebugger.addErrorLine(e2.ToString());

                this.Dungeons_Stairs_tBEbene.Text = "";
                this.Dungeons_Stairs_tBPosX.Text = "";
                this.Dungeons_Stairs_tBPosY.Text = "";
                this.Dungeons_Stairs_tBZielebeneBlickrichtung.Text = "";
                this.Dungeons_Stairs_tBZielebeneEbene.Text = "";
                this.Dungeons_Stairs_tBZielebeneRelPosX.Text = "";
                this.Dungeons_Stairs_tBZielebeneRelPosY.Text = "";     
            }
        }
        private void Dungeons_dgvDoors_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection dungeons = this.Dungeons_dgvList.SelectedRows;
            DataGridViewSelectedRowCollection dungeonDoors = this.Dungeons_dgvDoors.SelectedRows;

            if (dungeons.Count <= 0 || dungeonDoors.Count <= 0)
            {
                return;
            }

            try
            {
                int i = Convert.ToInt32(dungeons[0].Cells[0].Value);
                int j = Convert.ToInt32(dungeonDoors[0].Cells[0].Value);

                if ((i < this.itsDSAFileLoader.dungeons.itsDungeons.Count) && (j < this.itsDSAFileLoader.dungeons.itsDungeons[i].Value.doors.Count))
                {
                    CDungeons.CDungeon.CDungeonDoor door = this.itsDSAFileLoader.dungeons.itsDungeons[i].Value.doors[j];

                    this.Dungeons_Doors_tBEbene.Text = door.Ebene.ToString();
                    this.Dungeons_Doors_tBID.Text = door.TürID.ToString();
                    this.Dungeons_Doors_tBPosX.Text = door.PositionX.ToString();
                    this.Dungeons_Doors_tBPosY.Text = door.PositionY.ToString();
                    this.Dungeons_Doors_tBStatus.Text = door.Status.ToString();
                }
                else
                {
                    this.Dungeons_Doors_tBEbene.Text = "";
                    this.Dungeons_Doors_tBID.Text = "";
                    this.Dungeons_Doors_tBPosX.Text = "";
                    this.Dungeons_Doors_tBPosY.Text = "";
                    this.Dungeons_Doors_tBStatus.Text = "";
                }
            }
            catch (SystemException e2)
            {
                CDebugger.addErrorLine("Fehler beim laden der Dungeon Türen:");
                CDebugger.addErrorLine(e2.ToString());

                this.Dungeons_Doors_tBEbene.Text = "";
                this.Dungeons_Doors_tBID.Text = "";
                this.Dungeons_Doors_tBPosX.Text = "";
                this.Dungeons_Doors_tBPosY.Text = "";
                this.Dungeons_Doors_tBStatus.Text = "";
            }
        }

        private void Dungeons_lbList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Dungeons_lbList.SelectedIndex < 0)
            {
                this.currentDungeon = -1;
                this.currentDungeonFloor = -1;

                return;
            }

            try
            {
                int index = this.Dungeons_lbList.SelectedIndex;

                if (index < this.itsDSAFileLoader.dungeons.itsDungeons.Count)
                {
                    this.currentDungeon = index;

                    CDungeons.CDungeon dungeon = this.itsDSAFileLoader.dungeons.itsDungeons[index].Value;

                    //--------Ebenen----------
                    this.Dungeons_lbDungeonFloors.Items.Clear();
                    string[] items = new string[dungeon.floors.Count];
                    for (int j = 0; j < dungeon.floors.Count; j++)
                    {
                        //this.Dungeons_dgvDungeonFloors.Rows.Add(j.ToString());
                        items[j] = j.ToString();
                    }
                    this.Dungeons_lbDungeonFloors.Items.AddRange(items);

                    //--------Kämpfe----------
                    this.Dungeons_lbFights.Items.Clear();
                    items = new string[dungeon.fights.Count];
                    for (int j = 0; j < dungeon.fights.Count; j++)
                    {
                        if (this.itsDSAFileLoader.kampf.itsFight_LST.Count > dungeon.fights[j].KampfID)
                            //this.Dungeons_dgvFights.Rows.Add(j.ToString("D3"), this.itsDSAFileLoader.kampf.itsFight_LST[dungeon.fights[j].KampfID].name);
                            items[j] = this.itsDSAFileLoader.kampf.itsFight_LST[dungeon.fights[j].KampfID].name;
                        else
                            //this.Dungeons_dgvFights.Rows.Add(j.ToString("D3"), "???");
                            items[j] = "???";
                    }
                    this.Dungeons_lbFights.Items.AddRange(items);

                    //--------Treppen----------
                    this.Dungeons_lbStairs.Items.Clear();
                    items = new string[dungeon.stairs.Count];
                    for (int j = 0; j < dungeon.stairs.Count; j++)
                    {
                        //this.Dungeons_dgvStairs.Rows.Add(j.ToString("D3"));
                        items[j] = j.ToString();
                    }
                    this.Dungeons_lbStairs.Items.AddRange(items);

                    //--------Türen----------
                    this.Dungeons_lbDoors.Items.Clear();
                    items = new string[dungeon.doors.Count];
                    for (int j = 0; j < dungeon.doors.Count; j++)
                    {
                        //this.Dungeons_dgvDoors.Rows.Add(j.ToString("D3"));
                        items[j] = j.ToString();
                    }
                    this.Dungeons_lbDoors.Items.AddRange(items);

                    if (this.Dungeons_lbDungeonFloors.Items.Count > 0)
                        this.Dungeons_lbDungeonFloors.SelectedIndex = 0;

                    if (this.Dungeons_lbFights.Items.Count > 0)
                        this.Dungeons_lbFights.SelectedIndex = 0;

                    if (this.Dungeons_lbStairs.Items.Count > 0)
                        this.Dungeons_lbStairs.SelectedIndex = 0;

                    if (this.Dungeons_lbDoors.Items.Count > 0)
                        this.Dungeons_lbDoors.SelectedIndex = 0;
                }
                this.drawDungeon();
            }
            catch (SystemException e2)
            {
                CDebugger.addErrorLine("Fehler beim laden der Dungeons:");
                CDebugger.addErrorLine(e2.ToString());

                this.currentDungeon = -1;
                this.currentDungeonFloor = -1;
            }
        }
        private void Dungeons_lbDungeonFloors_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Dungeons_lbList.SelectedIndex < 0 || this.Dungeons_lbDungeonFloors.SelectedIndex < 0)
            {
                this.currentDungeonFloor = -1;
                return;
            }

            try
            {
                int index_1 = this.Dungeons_lbList.SelectedIndex;
                int index_2 = this.Dungeons_lbDungeonFloors.SelectedIndex;

                if ((index_1 < this.itsDSAFileLoader.dungeons.itsDungeons.Count) && (index_2 < this.itsDSAFileLoader.dungeons.itsDungeons[index_1].Value.floors.Count))
                {
                    this.currentDungeonFloor = index_2;
                    CDungeons.CDungeon.CFloor floor = this.itsDSAFileLoader.dungeons.itsDungeons[index_1].Value.floors[index_2];
                }
                this.drawDungeon();
            }
            catch (SystemException e2)
            {
                CDebugger.addErrorLine("Fehler beim laden der Dungeon ebene:");
                CDebugger.addErrorLine(e2.ToString());

                this.currentDungeonFloor = -1;
                this.drawDungeon();
            }
        }
        private void Dungeons_lbFights_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Dungeons_lbList.SelectedIndex < 0 || this.Dungeons_lbFights.SelectedIndex < 0)
            {
                return;
            }

            try
            {
                int index_1 = this.Dungeons_lbList.SelectedIndex;
                int index_2 = this.Dungeons_lbFights.SelectedIndex;

                if ((index_1 < this.itsDSAFileLoader.dungeons.itsDungeons.Count) && (index_2 < this.itsDSAFileLoader.dungeons.itsDungeons[index_1].Value.fights.Count))
                {
                    CDungeons.CDungeon.CDungeonFight fight = this.itsDSAFileLoader.dungeons.itsDungeons[index_1].Value.fights[index_2];

                    this.Dungeons_Fights_tBEbene.Text = fight.Ebene.ToString();
                    this.Dungeons_Fights_tBErstAP.Text = fight.extraAP.ToString();
                    this.Dungeons_Fights_tBID.Text = fight.KampfID.ToString();
                    this.Dungeons_Fights_tBPosX.Text = fight.PositionX.ToString();
                    this.Dungeons_Fights_tBPosY.Text = fight.PositionY.ToString();

                    this.Dungeons_Fights_tBFluchtBlickrichtung_1.Text = CHelpFunctions.dsaRichtungToString(fight.Flucht_Blickrichtung[0]);
                    this.Dungeons_Fights_tBFluchtEbene_1.Text = fight.Flucht_Ebene[0].ToString();
                    this.Dungeons_Fights_tBFluchtPosX_1.Text = fight.Flucht_PosX[0].ToString();
                    this.Dungeons_Fights_tBFluchtPosY_1.Text = fight.Flucht_PosY[0].ToString();

                    this.Dungeons_Fights_tBFluchtBlickrichtung_2.Text = CHelpFunctions.dsaRichtungToString(fight.Flucht_Blickrichtung[1]);
                    this.Dungeons_Fights_tBFluchtEbene_2.Text = fight.Flucht_Ebene[1].ToString();
                    this.Dungeons_Fights_tBFluchtPosX_2.Text = fight.Flucht_PosX[1].ToString();
                    this.Dungeons_Fights_tBFluchtPosY_2.Text = fight.Flucht_PosY[1].ToString();

                    this.Dungeons_Fights_tBFluchtBlickrichtung_3.Text = CHelpFunctions.dsaRichtungToString(fight.Flucht_Blickrichtung[2]);
                    this.Dungeons_Fights_tBFluchtEbene_3.Text = fight.Flucht_Ebene[2].ToString();
                    this.Dungeons_Fights_tBFluchtPosX_3.Text = fight.Flucht_PosX[2].ToString();
                    this.Dungeons_Fights_tBFluchtPosY_3.Text = fight.Flucht_PosY[2].ToString();

                    this.Dungeons_Fights_tBFluchtBlickrichtung_4.Text = CHelpFunctions.dsaRichtungToString(fight.Flucht_Blickrichtung[3]);
                    this.Dungeons_Fights_tBFluchtEbene_4.Text = fight.Flucht_Ebene[3].ToString();
                    this.Dungeons_Fights_tBFluchtPosX_4.Text = fight.Flucht_PosX[3].ToString();
                    this.Dungeons_Fights_tBFluchtPosY_4.Text = fight.Flucht_PosY[3].ToString();
                }
                else
                {
                    this.Dungeons_Fights_tBEbene.Text = "";
                    this.Dungeons_Fights_tBErstAP.Text = "";
                    this.Dungeons_Fights_tBID.Text = "";
                    this.Dungeons_Fights_tBPosX.Text = "";
                    this.Dungeons_Fights_tBPosY.Text = "";

                    this.Dungeons_Fights_tBFluchtBlickrichtung_1.Text = "";
                    this.Dungeons_Fights_tBFluchtEbene_1.Text = "";
                    this.Dungeons_Fights_tBFluchtPosX_1.Text = "";
                    this.Dungeons_Fights_tBFluchtPosY_1.Text = "";

                    this.Dungeons_Fights_tBFluchtBlickrichtung_2.Text = "";
                    this.Dungeons_Fights_tBFluchtEbene_2.Text = "";
                    this.Dungeons_Fights_tBFluchtPosX_2.Text = "";
                    this.Dungeons_Fights_tBFluchtPosY_2.Text = "";

                    this.Dungeons_Fights_tBFluchtBlickrichtung_3.Text = "";
                    this.Dungeons_Fights_tBFluchtEbene_3.Text = "";
                    this.Dungeons_Fights_tBFluchtPosX_3.Text = "";
                    this.Dungeons_Fights_tBFluchtPosY_3.Text = "";

                    this.Dungeons_Fights_tBFluchtBlickrichtung_4.Text = "";
                    this.Dungeons_Fights_tBFluchtEbene_4.Text = "";
                    this.Dungeons_Fights_tBFluchtPosX_4.Text = "";
                    this.Dungeons_Fights_tBFluchtPosY_4.Text = "";
                }
            }
            catch (SystemException e2)
            {
                CDebugger.addErrorLine("Fehler beim laden der Dungeon kämpfe:");
                CDebugger.addErrorLine(e2.ToString());

                this.Dungeons_Fights_tBEbene.Text = "";
                this.Dungeons_Fights_tBErstAP.Text = "";
                this.Dungeons_Fights_tBID.Text = "";
                this.Dungeons_Fights_tBPosX.Text = "";
                this.Dungeons_Fights_tBPosY.Text = "";

                this.Dungeons_Fights_tBFluchtBlickrichtung_1.Text = "";
                this.Dungeons_Fights_tBFluchtEbene_1.Text = "";
                this.Dungeons_Fights_tBFluchtPosX_1.Text = "";
                this.Dungeons_Fights_tBFluchtPosY_1.Text = "";

                this.Dungeons_Fights_tBFluchtBlickrichtung_2.Text = "";
                this.Dungeons_Fights_tBFluchtEbene_2.Text = "";
                this.Dungeons_Fights_tBFluchtPosX_2.Text = "";
                this.Dungeons_Fights_tBFluchtPosY_2.Text = "";

                this.Dungeons_Fights_tBFluchtBlickrichtung_3.Text = "";
                this.Dungeons_Fights_tBFluchtEbene_3.Text = "";
                this.Dungeons_Fights_tBFluchtPosX_3.Text = "";
                this.Dungeons_Fights_tBFluchtPosY_3.Text = "";

                this.Dungeons_Fights_tBFluchtBlickrichtung_4.Text = "";
                this.Dungeons_Fights_tBFluchtEbene_4.Text = "";
                this.Dungeons_Fights_tBFluchtPosX_4.Text = "";
                this.Dungeons_Fights_tBFluchtPosY_4.Text = "";
            }
        }
        private void Dungeons_lbStairs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Dungeons_lbList.SelectedIndex < 0 || this.Dungeons_lbStairs.SelectedIndex < 0)
            {
                return;
            }

            try
            {
                int index_1 = this.Dungeons_lbList.SelectedIndex;
                int index_2 = this.Dungeons_lbStairs.SelectedIndex;

                if ((index_1 < this.itsDSAFileLoader.dungeons.itsDungeons.Count) && (index_2 < this.itsDSAFileLoader.dungeons.itsDungeons[index_1].Value.stairs.Count))
                {
                    CDungeons.CDungeon.CDungeonStair stair = this.itsDSAFileLoader.dungeons.itsDungeons[index_1].Value.stairs[index_2];

                    this.Dungeons_Stairs_tBEbene.Text = stair.Ebene.ToString();
                    this.Dungeons_Stairs_tBPosX.Text = stair.PositionX.ToString();
                    this.Dungeons_Stairs_tBPosY.Text = stair.PositionY.ToString();
                    this.Dungeons_Stairs_tBZielebeneBlickrichtung.Text = CHelpFunctions.dsaRichtungToString(stair.Blickrichtung);
                    this.Dungeons_Stairs_tBZielebeneEbene.Text = stair.Zielebene.ToString();
                    this.Dungeons_Stairs_tBZielebeneRelPosX.Text = stair.relXPos.ToString();
                    this.Dungeons_Stairs_tBZielebeneRelPosY.Text = stair.relYPos.ToString();
                }
                else
                {
                    this.Dungeons_Stairs_tBEbene.Text = "";
                    this.Dungeons_Stairs_tBPosX.Text = "";
                    this.Dungeons_Stairs_tBPosY.Text = "";
                    this.Dungeons_Stairs_tBZielebeneBlickrichtung.Text = "";
                    this.Dungeons_Stairs_tBZielebeneEbene.Text = "";
                    this.Dungeons_Stairs_tBZielebeneRelPosX.Text = "";
                    this.Dungeons_Stairs_tBZielebeneRelPosY.Text = "";
                }
            }
            catch (SystemException e2)
            {
                CDebugger.addErrorLine("Fehler beim laden der Dungeon Treppen:");
                CDebugger.addErrorLine(e2.ToString());

                this.Dungeons_Stairs_tBEbene.Text = "";
                this.Dungeons_Stairs_tBPosX.Text = "";
                this.Dungeons_Stairs_tBPosY.Text = "";
                this.Dungeons_Stairs_tBZielebeneBlickrichtung.Text = "";
                this.Dungeons_Stairs_tBZielebeneEbene.Text = "";
                this.Dungeons_Stairs_tBZielebeneRelPosX.Text = "";
                this.Dungeons_Stairs_tBZielebeneRelPosY.Text = "";
            }
        }
        private void Dungeons_lbDoors_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Dungeons_lbList.SelectedIndex < 0 || this.Dungeons_lbDoors.SelectedIndex < 0)
            {
                return;
            }

            try
            {
                int index_1 = this.Dungeons_lbList.SelectedIndex;
                int index_2 = this.Dungeons_lbDoors.SelectedIndex;

                if ((index_1 < this.itsDSAFileLoader.dungeons.itsDungeons.Count) && (index_2 < this.itsDSAFileLoader.dungeons.itsDungeons[index_1].Value.doors.Count))
                {
                    CDungeons.CDungeon.CDungeonDoor door = this.itsDSAFileLoader.dungeons.itsDungeons[index_1].Value.doors[index_2];

                    this.Dungeons_Doors_tBEbene.Text = door.Ebene.ToString();
                    this.Dungeons_Doors_tBID.Text = door.TürID.ToString();
                    this.Dungeons_Doors_tBPosX.Text = door.PositionX.ToString();
                    this.Dungeons_Doors_tBPosY.Text = door.PositionY.ToString();
                    this.Dungeons_Doors_tBStatus.Text = door.Status.ToString();
                }
                else
                {
                    this.Dungeons_Doors_tBEbene.Text = "";
                    this.Dungeons_Doors_tBID.Text = "";
                    this.Dungeons_Doors_tBPosX.Text = "";
                    this.Dungeons_Doors_tBPosY.Text = "";
                    this.Dungeons_Doors_tBStatus.Text = "";
                }
            }
            catch (SystemException e2)
            {
                CDebugger.addErrorLine("Fehler beim laden der Dungeon Türen:");
                CDebugger.addErrorLine(e2.ToString());

                this.Dungeons_Doors_tBEbene.Text = "";
                this.Dungeons_Doors_tBID.Text = "";
                this.Dungeons_Doors_tBPosX.Text = "";
                this.Dungeons_Doors_tBPosY.Text = "";
                this.Dungeons_Doors_tBStatus.Text = "";
            }
        } 

        private void drawDungeon()
        {
            if (this.currentDungeon == -1 || this.currentDungeonFloor == -1)
            {
                this.Dungeons_PictureBox.Image = null;
                return;
            }

            if (this.itsDSAFileLoader.dungeons.itsDungeons.Count < this.currentDungeon || this.itsDSAFileLoader.dungeons.itsDungeons[this.currentDungeon].Value.floors.Count < this.currentDungeonFloor)
            {
                this.Dungeons_PictureBox.Image = null;
                return;
            }

            CDungeons.CDungeon.CFloor dungeonFloor = this.itsDSAFileLoader.dungeons.itsDungeons[this.currentDungeon].Value.floors[this.currentDungeonFloor];

            if (DungeonImage == null)
                DungeonImage = new Bitmap(this.Dungeons_PictureBox.Width, this.Dungeons_PictureBox.Height);

            Graphics g = Graphics.FromImage(DungeonImage);
            g.FillRectangle(new SolidBrush(Color.Black), new Rectangle(0, 0, DungeonImage.Width, DungeonImage.Height));

            int PanelBlock_Y = DungeonImage.Height / 16;
            int PanelBlock_X = DungeonImage.Width / 16;

            for (int y = 0; y < 16; y++)
            {
                for (int x = 0; x < 16; x++)
                {
                    Color color = getColorFromDungeonByte(dungeonFloor.dungeonData[x, y]);
                    g.FillRectangle(new SolidBrush(color), new Rectangle(PanelBlock_X * x + 1, PanelBlock_Y * y + 1, PanelBlock_X - 2, PanelBlock_Y - 2));
                }
            }

            //if (this.selectedEvent != -1 && town.townEvents.Count > this.selectedEvent)
            //{
            //    CTownEvent townEvent = town.townEvents[selectedEvent];
            //    g.DrawRectangle(new Pen(Color.Red, 3.0f), new Rectangle(PanelBlock_X * townEvent.Position_X, PanelBlock_Y * townEvent.Position_Y, PanelBlock_X - 1, PanelBlock_Y - 1));
            //}

            this.Dungeons_PictureBox.Image = DungeonImage;
        }
        private Color getColorFromDungeonByte(byte value)
        {
            value = (byte)((value & 0xF0) >> 4);
            switch (value)
            {
                case 0:
                    return Color.FromArgb(40, 40, 40);      //normaler Boden
                case 1:
                case 2:
                    return Color.FromArgb(128, 20, 0);      //Illusionswand
                case 3:
                    return Color.DarkBlue;                  //Treppe runter
                case 4:
                    return Color.FromArgb(0, 253, 253);     //Treppe rauf
                //case 5:
                //case 6:
                //case 7:
                case 8:
                    return Color.FromArgb(156, 76, 0);      //Schatztruhe

                case 15:
                    return Color.FromArgb(253, 0, 0);   //Wand

                default:
                    return Color.GreenYellow;
            }
        }

        //------------Bilder-----------------------------
        private void Bilder_dgvList_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection bilder = this.Bilder_dgvList.SelectedRows;

            if (bilder.Count <= 0)
            {
                //this.Bilder_pictureBox.Image = null;
                this.Bilder_pictureBox.BackgroundImage = null;
                CDebugger.addErrorLine("Keine Bilddatei ausgewählt");
                return;
            }


            try
            {
                int i = Convert.ToInt32(this.Bilder_dgvList.SelectedRows[0].Cells[0].Value);

                if (i < this.itsDSAFileLoader.bilder.itsImages.Count)
                {
                    this.Bilder_dgvBildnummer.ClearSelection();
                    this.Bilder_dgvBildnummer.Rows.Clear();

                    //DataGridViewRow[] values = new DataGridViewRow[this.itsDSAFileLoader.bilder.itsImages[i].Value.Count];

                    for (int j = 0; j < this.itsDSAFileLoader.bilder.itsImages[i].Value.Count; j++)
                    {
                        this.Bilder_dgvBildnummer.Rows.Add(j.ToString());                        
                    }
                    //this.Bilder_dgvBildnummer.Rows.AddRange(values);       

                    this.Bilder_dgvBildnummer.ClearSelection();
                    if (this.Bilder_dgvBildnummer.Rows.Count > 0)
                        this.Bilder_dgvBildnummer.Rows[0].Selected = true;
                }
            }
            catch (SystemException e2)
            {
                this.Bilder_dgvBildnummer.ClearSelection();
                this.Bilder_dgvBildnummer.Rows.Clear();
                CDebugger.addErrorLine("Bilder: Fehler beim laden der Bildlisten");
                CDebugger.addErrorLine(e2.ToString());
            }
        }
        private void Bilder_dgvBildnummer_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection bilder = this.Bilder_dgvList.SelectedRows;
            DataGridViewSelectedRowCollection bildnummer = this.Bilder_dgvBildnummer.SelectedRows;

            if (bilder.Count <= 0 || bildnummer.Count <= 0)
            {
                //this.Bilder_pictureBox.Image = null;
                this.Bilder_pictureBox.BackgroundImage = null;
                return;
            }

            try
            {
                int i = Convert.ToInt32(bilder[0].Cells[0].Value);
                int j = Convert.ToInt32(bildnummer[0].Cells[0].Value);

                if ((i < this.itsDSAFileLoader.bilder.itsImages.Count) && (j < this.itsDSAFileLoader.bilder.itsImages[i].Value.Count))
                {
                    Image image = this.itsDSAFileLoader.bilder.itsImages[i].Value[j];

                    if (image == null)
                    {
                        //this.Bilder_pictureBox.Image = null;
                        this.Bilder_pictureBox.BackgroundImage = null;
                    }
                    else
                    {
                        //this.Bilder_pictureBox.Width = image.Width;
                        //this.Bilder_pictureBox.Height = image.Height;
                        //this.Bilder_pictureBox.Image = new Bitmap(image);
                        this.Bilder_pictureBox.BackgroundImage = new Bitmap(image);
                    }
                }
            }
            catch (SystemException e2)
            {
                this.Bilder_dgvBildnummer.Rows.Clear();
                CDebugger.addErrorLine("Bilder: Fehler beim laden des Bildes");
                CDebugger.addErrorLine(e2.ToString());
            }
        }

        private void Bilder_lbList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Bilder_lbList.SelectedIndex < 0)
            {
                //this.Bilder_pictureBox.Image = null;
                this.Bilder_pictureBox.BackgroundImage = null;
                CDebugger.addErrorLine("Keine Bilddatei ausgewählt");
                return;
            }


            try
            {
                int index = this.Bilder_lbList.SelectedIndex;

                if (index < this.itsDSAFileLoader.bilder.itsImages.Count)
                {
                    this.Bilder_lbBildnummer.Items.Clear();
                    string[] items = new string[this.itsDSAFileLoader.bilder.itsImages[index].Value.Count];
                    for (int j = 0; j < this.itsDSAFileLoader.bilder.itsImages[index].Value.Count; j++)
                    {
                        //this.Bilder_dgvBildnummer.Rows.Add(j.ToString());
                        items[j] = j.ToString();
                    }
                    this.Bilder_lbBildnummer.Items.AddRange(items);

                    if (this.Bilder_lbBildnummer.Items.Count > 0)
                        this.Bilder_lbBildnummer.SelectedIndex = 0;
                }
            }
            catch (SystemException e2)
            {
                this.Bilder_dgvBildnummer.ClearSelection();
                this.Bilder_dgvBildnummer.Rows.Clear();
                CDebugger.addErrorLine("Bilder: Fehler beim laden der Bildlisten");
                CDebugger.addErrorLine(e2.ToString());
            }
        }
        private void Bilder_lbBildnummer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Bilder_lbList.SelectedIndex < 0 || this.Bilder_lbBildnummer.SelectedIndex < 0)
            {
                //this.Bilder_pictureBox.Image = null;
                this.Bilder_pictureBox.BackgroundImage = null;
                return;
            }

            try
            {
                int index_1 = this.Bilder_lbList.SelectedIndex;
                int index_2 = this.Bilder_lbBildnummer.SelectedIndex;

                if ((index_1 < this.itsDSAFileLoader.bilder.itsImages.Count) && (index_2 < this.itsDSAFileLoader.bilder.itsImages[index_1].Value.Count))
                {
                    Image image = this.itsDSAFileLoader.bilder.itsImages[index_1].Value[index_2];

                    if (image == null)
                    {
                        //this.Bilder_pictureBox.Image = null;
                        this.Bilder_pictureBox.BackgroundImage = null;
                    }
                    else
                    {
                        //this.Bilder_pictureBox.Width = image.Width;
                        //this.Bilder_pictureBox.Height = image.Height;
                        //this.Bilder_pictureBox.Image = new Bitmap(image);
                        this.Bilder_pictureBox.BackgroundImage = new Bitmap(image);
                    }
                }
            }
            catch (SystemException e2)
            {
                this.Bilder_dgvBildnummer.Rows.Clear();
                CDebugger.addErrorLine("Bilder: Fehler beim laden des Bildes");
                CDebugger.addErrorLine(e2.ToString());
            }
        }

        //------------Hyperlinks-----------------------------
        private void lL_ItemInfos_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://freedsa.schattenkind.net/index.php/DAT");
        }
        private void lL_Monster_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://freedsa.schattenkind.net/index.php/DSA1_Kampfsystem#MONSTER.DAT");
        }
        private void lL_Kämpfe_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://freedsa.schattenkind.net/index.php/DSA1_Kampfsystem#MONSTER.DAT");
        }
        private void lL_Städte_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://freedsa.schattenkind.net/index.php/DAT");
        }
        private void ll_Dialoge_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://freedsa.schattenkind.net/index.php/TLK");
        } 

        //-----------Menü-----------------------------------
        private void öffnenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.openFile(null);
        } 
        private void beendenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void entpackenNachToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult objResult = folderBrowserDialog1.ShowDialog();
            if (objResult == System.Windows.Forms.DialogResult.OK)
            {
                this.itsDSAFileLoader.exportFiles(folderBrowserDialog1.SelectedPath);
            }
        }
        private void bilderExportierenNachToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult objResult = folderBrowserDialog1.ShowDialog();
            if (objResult == System.Windows.Forms.DialogResult.OK)
            {
                this.itsDSAFileLoader.exportPictures(folderBrowserDialog1.SelectedPath);
            }
        }   
    }
}

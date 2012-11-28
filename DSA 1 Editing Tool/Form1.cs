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
        Settings setdlg;

        public Form1()
        {
            InitializeComponent();
            folderBrowserDialog1.SelectedPath = "C:\\";
            setdlg = new Settings();
            setdlg.Hide();

            CDebugger.IncommingMessage += HandleDebugMessage;

            this.initKeyColors();
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
            this.rTB_Debug.ScrollToCaret();
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

        private void initKeyColors()
        {
            this.Dungeons_KeyColor_Door.BackColor = Colors.keyColor_Door;
            this.Dungeons_KeyColor_Fight.BackColor = Colors.keyColor_Fight;
            this.Dungeons_KeyColor_Stair.BackColor = Colors.keyColor_Stair;
            this.Dungeons_KeyColor_DungeonField.BackColor = Colors.keyColor_DungeonField;
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
            this.loadAnimationenTab();
            this.loadRouts();
        }
        private void loadItemTab()
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
        private void loadDialoge()
        {
            this.Dialoge_dgvList.Rows.Clear();

            for (int i = 0; i < this.itsDSAFileLoader.dialoge.itsDialoge.Count; i++)
            {
                this.Dialoge_dgvList.Rows.Add(i.ToString("D3"), this.itsDSAFileLoader.dialoge.itsDialoge[i].Key);
            }
        }
        private void loadTextTab()
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
        private void loadMonsterTab()
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
        private void loadKampfTab()
        {
            this.Fight_dgvList.Rows.Clear();

            for (int i = 0; i < this.itsDSAFileLoader.kampf.itsFight_LST.Count; i++)
            {
                CFight_LST fight = this.itsDSAFileLoader.kampf.itsFight_LST[i];
                this.Fight_dgvList.Rows.Add(i.ToString("D3"), fight.nummerDesScenarios.ToString("D3"), fight.name);     //D3 ->Decimal 3
            }
        }
        private void loadStädteTab()
        {
            this.Städte_dgvList.Rows.Clear();

            for (int i = 0; i < this.itsDSAFileLoader.städte.itsTowns.Count; i++)
            {
                this.Städte_dgvList.Rows.Add(i.ToString("D3"), this.itsDSAFileLoader.städte.itsTowns[i].Key);
            }
        }
        private void loadDungeonsTab()
        {
            this.Dungeons_dgvList.Rows.Clear();

            for (int i = 0; i < this.itsDSAFileLoader.dungeons.itsDungeons.Count; i++)
            {
                this.Dungeons_dgvList.Rows.Add(i.ToString("D3"), this.itsDSAFileLoader.dungeons.itsDungeons[i].Key);
            }
        }
        private void loadBilderTab()
        {
            this.Bilder_dgvList.Rows.Clear();

            for (int i = 0; i < this.itsDSAFileLoader.bilder.itsImages.Count; i++)
            {
                this.Bilder_dgvList.Rows.Add(i.ToString("D3"), this.itsDSAFileLoader.bilder.itsImages[i].Key);
            };
        }
        private void loadAnimationenTab()
        {
            this.Animationen_dgvList.Rows.Clear();

            for (int i = 0; i < this.itsDSAFileLoader.bilder.itsAnimations.Count; i++)
            {
                this.Animationen_dgvList.Rows.Add(i.ToString("D3"), this.itsDSAFileLoader.bilder.itsAnimations[i].Key);
            };
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
                this.tB_Monster_Größenklasse.Text = monster.größenklasseToString();//monster.Größenklasse.ToString();
                this.tB_Monster_IDMagierklasse.Text = monster.ID_Magierklasse.ToString();
                this.tB_Monster_ImmunitätNormaleWaffen.Text = monster.immunitätGegenNormaleWaffenToString();//monster.Immunität_gegen_Normale_Waffen.ToString();
                this.tB_Monster_IN.Text = CHelpFunctions.dsaWürfelwertToString(monster.IN_Würfel);
                this.tB_Monster_KK.Text = CHelpFunctions.dsaWürfelwertToString(monster.KK_Würfel);
                this.tB_Monster_KL.Text = CHelpFunctions.dsaWürfelwertToString(monster.KL_Würfel);
                this.tB_Monster_LE.Text = CHelpFunctions.dsaWürfelwertToString(monster.LE_Würfel);
                this.tB_Monster_MonsterID.Text = monster.MonsterID.ToString();
                this.tB_Monster_MonsterTyp.Text = monster.monsterTypToString();//monster.MonsterTyp.ToString();
                this.tB_Monster_MR.Text = CHelpFunctions.dsaWürfelwertToString(monster.MR_Würfel);
                this.tB_Monster_MU.Text = CHelpFunctions.dsaWürfelwertToString(monster.MU_Würfel);
                this.tB_Monster_PA.Text = monster.PA.ToString();
                this.tB_Monster_RS.Text = monster.RS.ToString();
                this.tB_Monster_SchadeGeschosse.Text = CHelpFunctions.dsaWürfelwertToString(monster.Schaden_Schusswaffen_Würfel);
                this.tB_Monster_Schaden1Angriff.Text = CHelpFunctions.dsaWürfelwertToString(monster.Schaden_1_Angriff_Würfel);
                this.tB_Monster_Schaden2Angriff.Text = CHelpFunctions.dsaWürfelwertToString(monster.Schaden_2_Angriff_Würfel);
                this.tB_Monster_SchadenWurfwaffen.Text = CHelpFunctions.dsaWürfelwertToString(monster.Schaden_Wurfwaffen_Würfel);
                this.tB_Monster_Stufe.Text = monster.Stufe.ToString();

                this.Monster_pictureBox.BackgroundImage = this.itsDSAFileLoader.bilder.getMonsterImageByID(monster.MonsterGraphicID);
                //this.Monster_pictureBox.BackgroundImage = this.itsDSAFileLoader.bilder.getMonsterImageByID(monster.MonsterID - 1);
                
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

                    this.Kämpfe_Item_pictureBox.BackgroundImage = null;
                    this.Kämpfe_Monster_pictureBox.BackgroundImage = null;

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

                CFight_MonsterInfo monsterInfo = this.itsDSAFileLoader.kampf.itsFight_LST[i].itsMonsterInfos[j];
                this.tB_Fight_Monster_Blickrichtung.Text = CHelpFunctions.dsaRichtungToString(monsterInfo.Blickrichtung);
                this.tB_Fight_Monster_ID.Text = monsterInfo.GegnerID.ToString();
                this.tB_Fight_Monster_Startrunde.Text = monsterInfo.Startrunde.ToString();
                this.tB_Fight_Monster_XPos.Text = monsterInfo.Position_X.ToString();
                this.tB_Fight_Monster_YPos.Text = monsterInfo.Position_Y.ToString();

                try
                {
                    CMonster.CMonsterStats monster = this.itsDSAFileLoader.monster.itsMonsterStats[monsterInfo.GegnerID];
                    this.Kämpfe_Monster_pictureBox.BackgroundImage = new Bitmap(this.itsDSAFileLoader.bilder.getMonsterImageByID(monster.MonsterGraphicID));
                }
                catch (SystemException)
                {
                    this.Kämpfe_Monster_pictureBox.BackgroundImage = null;
                }
                
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

                try
                {
                    short imageID = this.itsDSAFileLoader.itemList.itsItems[this.itsDSAFileLoader.kampf.itsFight_LST[i].itsBeute[j].ItemID].IconID;
                    this.Kämpfe_Item_pictureBox.BackgroundImage = new Bitmap(this.itsDSAFileLoader.bilder.getItemImageByID(imageID));
                }
                catch (SystemException)
                {
                    this.Kämpfe_Item_pictureBox.BackgroundImage = null;
                }
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

                DataGridViewSelectedRowCollection kämpfe = this.Fight_dgvList.SelectedRows;
                if (kämpfe.Count <= 0 || lB_Fight_Spieler.SelectedIndex < 0)
                {
                    return;
                }

                index_1 = Convert.ToInt32(kämpfe[0].Cells[0].Value);
                index_2 = this.lB_Fight_Spieler.SelectedIndex;

                if (this.itsDSAFileLoader.kampf.itsFight_LST.Count <= 0)
                    return;

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
        private int Townmarker_currentTown = -1;
        private int Townmarker_selectetPos_X = -1;
        private int Townmarker_selectetPos_Y = -1;

        private Bitmap TownImage = null;

        private void Städte_dgvList_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection towns = this.Städte_dgvList.SelectedRows;
            if (towns.Count <= 0)
            {
                this.Townmarker_currentTown = -1;
                this.drawCity();

                return;
            }

            this.Townmarker_selectetPos_X = -1;
            this.Townmarker_selectetPos_Y = -1;
            this.Städte_SelectedField_tbPosX.Text = "";
            this.Städte_SelectedField_tbPosY.Text = "";
            this.Städte_SelectedField_FieldTyp.Text = "";
            this.Städte_SelectedField_EventNr.Text = "";

            try
            {
                int i = Convert.ToInt32(towns[0].Cells[0].Value);

                if (i < this.itsDSAFileLoader.städte.itsTowns.Count)
                {
                    this.Townmarker_currentTown = i;
                    CTown town = this.itsDSAFileLoader.städte.itsTowns[i].Value;

                    this.Städte_dgvStadtEventList.Rows.Clear();
                    for (int j = 0; j < town.townEvents.Count; j++)
                    {
                        this.Städte_dgvStadtEventList.Rows.Add(j.ToString("D3"), town.townEvents[j].EventTypToString());
                    }
                }
                this.drawCity();
            }
            catch (SystemException e2)
            {
                CDebugger.addErrorLine("Fehler beim laden der Städte:");
                CDebugger.addErrorLine(e2.ToString());

                this.Townmarker_currentTown = -1;
                this.drawCity();
            }
        }
        private void Städte_dgvStadtEventList_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection towns = this.Städte_dgvList.SelectedRows;
            DataGridViewSelectedRowCollection events = this.Städte_dgvStadtEventList.SelectedRows;

            if (towns.Count <= 0 || events.Count <= 0)
            {
                this.drawCity();

                return;
            }

            try
            {
                int i = Convert.ToInt32(towns[0].Cells[0].Value);
                int j = Convert.ToInt32(events[0].Cells[0].Value);

                if (this.itsDSAFileLoader.städte.itsTowns.Count < i)
                {
                    return;
                }

                if (this.itsDSAFileLoader.städte.itsTowns[i].Value.townEvents.Count < j)
                {
                    return;
                }

                CTown town = this.itsDSAFileLoader.städte.itsTowns[i].Value;
                CTownEvent townEvent = town.townEvents[j];

                this.Townmarker_selectetPos_X = townEvent.Position_X;
                this.Townmarker_selectetPos_Y = townEvent.Position_Y;

                this.Städte_SelectedField_tbPosX.Text = this.Townmarker_selectetPos_X.ToString();
                this.Städte_SelectedField_tbPosY.Text = this.Townmarker_selectetPos_Y.ToString();
                this.Städte_SelectedField_FieldTyp.Text = town.TownByteToString(this.Townmarker_selectetPos_X, this.Townmarker_selectetPos_Y);
                this.Städte_SelectedField_EventNr.Text = "Event Nr. " + j.ToString() + "   (" + townEvent.EventTypToString() + ")";

                this.Städte_Event_tbIndex_Global.Text = townEvent.Untertyp_2_unbekannte_Parameter.ToString();
                this.Städte_Event_tbIndex_Lokal.Text = townEvent.Untertyp_1_Name_Icons_Angebot.ToString();
                this.Städte_Event_tbPosX.Text = townEvent.Position_X.ToString();
                this.Städte_Event_tbPosY.Text = townEvent.Position_Y.ToString();
                this.Städte_Event_tbTyp.Text = townEvent.EventTypToString();
                this.Städte_Event_tbUnbekannt.Text = townEvent.Untertyp_3_Reisen.ToString();

                this.drawCity();
            }
            catch (SystemException e2)
            {
                CDebugger.addErrorLine("Fehler beim laden der Stadtevents:");
                CDebugger.addErrorLine(e2.ToString());

                this.Townmarker_selectetPos_X = -1;
                this.Townmarker_selectetPos_Y = -1;

                this.Städte_SelectedField_tbPosX.Text = "";
                this.Städte_SelectedField_tbPosY.Text = "";
                this.Städte_SelectedField_FieldTyp.Text = "";
                this.Städte_SelectedField_EventNr.Text = "";

                this.Städte_Event_tbIndex_Global.Text = "";
                this.Städte_Event_tbIndex_Lokal.Text = "";
                this.Städte_Event_tbPosX.Text = "";
                this.Städte_Event_tbPosY.Text = "";
                this.Städte_Event_tbTyp.Text = "";
                this.Städte_Event_tbUnbekannt.Text = "";
            }
        }
        private void Citys_PictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            int factorX = this.Citys_PictureBox.Width / 32;
            int factorY = this.Citys_PictureBox.Height / 16;
            //CDebugger.addDebugLine("Box at X:" + e.X/factorX + " Y:" + e.Y/factorY);

            this.Townmarker_selectetPos_X = e.X / factorX;
            this.Townmarker_selectetPos_Y = e.Y / factorY;

            CTown town = this.itsDSAFileLoader.städte.itsTowns[this.Townmarker_currentTown].Value;
            
            bool bigcity = town.townData.Length == 16*32;
            if (bigcity || (!bigcity && this.Townmarker_selectetPos_X < 16))
            {
                this.Städte_SelectedField_tbPosX.Text = this.Townmarker_selectetPos_X.ToString();
                this.Städte_SelectedField_tbPosY.Text = this.Townmarker_selectetPos_Y.ToString();
                this.Städte_SelectedField_FieldTyp.Text = town.TownByteToString(this.Townmarker_selectetPos_X, this.Townmarker_selectetPos_Y);
                this.Städte_SelectedField_EventNr.Text = "kein Event";

                for (int i = 0; i <town.townEvents.Count; i++)
                {
                    CTownEvent townEvent = town.townEvents[i];
                    if ((townEvent.Position_X == this.Townmarker_selectetPos_X) && (townEvent.Position_Y == this.Townmarker_selectetPos_Y))
                    {
                        this.Städte_SelectedField_EventNr.Text = "Event Nr. " + i.ToString() + "   (" + townEvent.EventTypToString() + ")";
                        this.Städte_dgvStadtEventList.Rows[i].Selected = true;
                        this.Städte_dgvStadtEventList.FirstDisplayedScrollingRowIndex = i;
                        break;
                    }
                }
            }

            this.drawCity();
        }

        private void drawCity()
        {
            if ((this.Townmarker_currentTown < 0) || (this.itsDSAFileLoader.städte.itsTowns.Count < this.Townmarker_currentTown))
            {
                this.Citys_PictureBox.Image = null;
                return;
            }

            if (TownImage == null)
                TownImage = new Bitmap(this.Citys_PictureBox.Width, this.Citys_PictureBox.Height);

            CTown town = this.itsDSAFileLoader.städte.itsTowns[this.Townmarker_currentTown].Value;

            //Graphics g = this.Städte_TownPanel.CreateGraphics();
            Graphics g = Graphics.FromImage(TownImage);
            g.FillRectangle(new SolidBrush(Color.Black), new Rectangle(0, 0, TownImage.Width, TownImage.Height));

            int PanelBlock_Y = TownImage.Height / 16;
            int PanelBlock_X = TownImage.Width / 32;

            //////////////////////
            //  Stadt zeichen   //
            //////////////////////
            for (int y = 0; y < town.townLängeSN; y++)
            {
                for (int x = 0; x < town.townLängeWO; x++)
                {
                    Color color = getColorFromTownByte(town.townData[x, y]);
                    g.FillRectangle(new SolidBrush(color), new Rectangle(PanelBlock_X * x + 1, PanelBlock_Y * y + 1, PanelBlock_X - 2, PanelBlock_Y - 2));

                    int value = ((town.townData[x, y] & 0xF0) >> 4);
                    if (value != 0 && value != 10 && value != 11 && value != 12)
                        switch (town.townData[x, y] & 0x0F)
                        {
                            case 0: //N
                                g.FillRectangle(new SolidBrush(Color.Black), new Rectangle(PanelBlock_X * x + 3, PanelBlock_Y * y + 1, PanelBlock_X - 6, 2));
                                break;
                            case 1: //O
                                g.FillRectangle(new SolidBrush(Color.Black), new Rectangle(PanelBlock_X * x + 1 + PanelBlock_X - 4, PanelBlock_Y * y + 3, 2, PanelBlock_Y - 6));
                                break;
                            case 2: //S
                                g.FillRectangle(new SolidBrush(Color.Black), new Rectangle(PanelBlock_X * x + 3, PanelBlock_Y * y + 1 + PanelBlock_Y - 4, PanelBlock_X - 6, 2));
                                break;
                            case 3: //W
                                g.FillRectangle(new SolidBrush(Color.Black), new Rectangle(PanelBlock_X * x + 1, PanelBlock_Y * y + 3, 2, PanelBlock_Y - 6));
                                break;
                        }
                }
            }
            ////////////////////////////
            //   Stadtevents zeichen  //
            ////////////////////////////
            foreach (CTownEvent townEvent in town.townEvents)
            {
                try
                {
                    byte townByte = town.townData[townEvent.Position_X, townEvent.Position_Y];
                    Color color = getOverrideColorFromTownByteAndEventID(townByte, townEvent.Typ);
                    g.FillRectangle(new SolidBrush(color), new Rectangle(PanelBlock_X * townEvent.Position_X + 1, PanelBlock_Y * townEvent.Position_Y + 1, PanelBlock_X - 2, PanelBlock_Y - 2));

                    int x = townEvent.Position_X;
                    int y = townEvent.Position_Y;
                    int value = ((town.townData[x, y] & 0xF0) >> 4);
                    if (value != 0 && value != 10 && value != 11 && value != 12 && townEvent.Typ != 9 && townEvent.Typ != 11 && townEvent.Typ != 12)
                        switch (town.townData[x, y] & 0x0F)
                        {
                            case 0: //N
                                g.FillRectangle(new SolidBrush(Color.Black), new Rectangle(PanelBlock_X * x + 3, PanelBlock_Y * y + 1, PanelBlock_X - 6, 2));
                                break;
                            case 1: //O
                                g.FillRectangle(new SolidBrush(Color.Black), new Rectangle(PanelBlock_X * x + 1 + PanelBlock_X - 4, PanelBlock_Y * y + 3, 2, PanelBlock_Y - 6));
                                break;
                            case 2: //S
                                g.FillRectangle(new SolidBrush(Color.Black), new Rectangle(PanelBlock_X * x + 3, PanelBlock_Y * y + 1 + PanelBlock_Y - 4, PanelBlock_X - 6, 2));
                                break;
                            case 3: //W
                                g.FillRectangle(new SolidBrush(Color.Black), new Rectangle(PanelBlock_X * x + 1, PanelBlock_Y * y + 3, 2, PanelBlock_Y - 6));
                                break;
                        }
                }
                catch(SystemException)
                {
                    CDebugger.addErrorLine("Fehler beim Laden der Stadtevents");
                }
            }

            //////////////////////
            //    Eventmarker   //
            //////////////////////
            if (this.Townmarker_selectetPos_X != -1 && this.Townmarker_selectetPos_Y != -1)
            {
                g.DrawRectangle(new Pen(Color.RoyalBlue, 3.0f), new Rectangle(PanelBlock_X * this.Townmarker_selectetPos_X, PanelBlock_Y * this.Townmarker_selectetPos_Y, PanelBlock_X - 1, PanelBlock_Y - 1));
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
                case 13:
                    return Color.FromArgb(52, 50, 125);     //Quest NPC
                case 14:
                case 15:
                    return Color.FromArgb(52, 50, 125);    //Leuchtturm
                case 16:
                    return Color.Lavender;                 //	Straße/Unsichtbare Wand???

                default:
                    return Color.FloralWhite;   
            }
        }
        private Color getOverrideColorFromTownByteAndEventID(byte townByte, byte eventID)
        {
            townByte = (byte)((townByte & 0xF0) >> 4);

            switch (eventID)
            {
                case 2: return Color.FromArgb(255, 127, 0);     //Tempel
                case 3: return Color.Aquamarine;                //Taverne    
                case 4: return Color.FromArgb(255, 0, 255);     //Heiler    
                case 5: return Color.FromArgb(128, 128, 128);   //Geschäft
                //case 6:
                //    return ("Wildnislager (" + this.Typ.ToString() + ")");
                case 7: return Color.Aquamarine;                //Herberge
                case 8: return Color.FromArgb(52, 126, 52);     //Schmied
                case 9: return Color.FromArgb(0, 0, 0, 0);  //Markt
                    
                //case 10:
                //    return ("normales Haus? (" + this.Typ.ToString() + ")");
                case 11:    //Hafen
                case 12:    //Wegweiser
                    return Color.FromArgb(255, 0, 0);     //wegweiser
                //case 13:
                //    return ("QuestNPC? (" + this.Typ.ToString() + ")");
                //case 14:
                //    return ("Dungeon (" + this.Typ.ToString() + ")");
                //case 16:
                //    return ("Haus zum einbrechen? (" + this.Typ.ToString() + ")");
                case 17: 
                    if (townByte == 4)
                        return Color.Aquamarine;                //Herberge
                    else
                        return Color.FromArgb(0, 0, 0, 0);       //Besondere Gebäude
                //case 18:
                //    return ("Lager? (" + this.Typ.ToString() + ")");

                default:
                    return Color.FromArgb(0, 0, 0, 0);
            }
        }

        //------------Dungeons-----------------------------
        private int Dungeonmarker_currentDungeon = -1;
        private int Dungeonmarker_currentDungeonFloor = -1;
        private int Dungeonmarker_selectetFight = -1;
        private int Dungeonmarker_selectetDoor = -1;
        private int Dungeonmarker_selectetStair = -1;
        private int Dungeonmarker_selectedPosX = -1;
        private int Dungeonmarker_selectedPosY = -1;
        private Bitmap DungeonImage = null;

        private void Dungeons_dgvList_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection dungeons = this.Dungeons_dgvList.SelectedRows;
           
            if (dungeons.Count <= 0)
            {
                this.Dungeonmarker_currentDungeon = -1;
                this.Dungeonmarker_currentDungeonFloor = -1;

                return;
            }

            this.Dungeonmarker_selectetFight = -1;
            this.Dungeonmarker_selectetDoor = -1;
            this.Dungeonmarker_selectetStair = -1;

            this.Dungeonmarker_selectedPosX = -1;
            this.Dungeonmarker_selectedPosY = -1;

            this.Dungeons_SelectedField_tbPosX.Text = "";
            this.Dungeons_SelectedField_tbPosY.Text = "";
            this.Dungeons_SelectedField_tbFieldTyp.Text = "";

            try
            {
                int i = Convert.ToInt32(dungeons[0].Cells[0].Value);

                if (i < this.itsDSAFileLoader.dungeons.itsDungeons.Count)
                {
                    this.Dungeonmarker_currentDungeon = i;

                    CDungeons.CDungeon dungeon = this.itsDSAFileLoader.dungeons.itsDungeons[i].Value;

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

                    //--------Ebenen----------
                    this.Dungeons_dgvDungeonFloors.Rows.Clear();
                    for (int j = 0; j < dungeon.floors.Count; j++)
                    {
                        this.Dungeons_dgvDungeonFloors.Rows.Add(j.ToString());
                    }
                }
                this.drawDungeon();
            }
            catch (SystemException e2)
            {
                CDebugger.addErrorLine("Fehler beim laden der Dungeons:");
                CDebugger.addErrorLine(e2.ToString());

                this.Dungeonmarker_currentDungeon = -1;
                this.Dungeonmarker_currentDungeonFloor = -1;
            }
        }
        private void Dungeons_dgvDungeonFloors_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection dungeons = this.Dungeons_dgvList.SelectedRows;
            DataGridViewSelectedRowCollection dungeonFloors = this.Dungeons_dgvDungeonFloors.SelectedRows;

            if (dungeons.Count <= 0 || dungeonFloors.Count <= 0)
            {
                this.Dungeonmarker_currentDungeonFloor = -1;
                return;
            }

            this.Dungeonmarker_selectedPosX = -1;
            this.Dungeonmarker_selectedPosY = -1;

            this.Dungeons_SelectedField_tbPosX.Text = "";
            this.Dungeons_SelectedField_tbPosY.Text = "";
            this.Dungeons_SelectedField_tbFieldTyp.Text = "";

            try
            {
                int i = Convert.ToInt32(dungeons[0].Cells[0].Value);
                int j = Convert.ToInt32(dungeonFloors[0].Cells[0].Value);

                if ((i < this.itsDSAFileLoader.dungeons.itsDungeons.Count) && (j < this.itsDSAFileLoader.dungeons.itsDungeons[i].Value.floors.Count))
                {
                    this.Dungeonmarker_currentDungeonFloor = j;
                }
                this.drawDungeon();
            }
            catch (SystemException e2)
            {
                CDebugger.addErrorLine("Fehler beim laden der Dungeon ebene:");
                CDebugger.addErrorLine(e2.ToString());

                this.Dungeonmarker_currentDungeonFloor = -1;
                this.drawDungeon();
            }
        }
        private void Dungeons_dgvFights_SelectionChanged(object sender, EventArgs e)
        {
            this.Dungeonmarker_selectetFight = -1;

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
                    this.Dungeonmarker_selectetFight = j;

                    CDungeons.CDungeon.CDungeonFight fight = this.itsDSAFileLoader.dungeons.itsDungeons[i].Value.fights[j];

                    if (this.Dungeons_dgvDungeonFloors.Rows.Count > fight.Ebene)
                        this.Dungeons_dgvDungeonFloors.Rows[fight.Ebene].Selected = true;

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

            this.drawDungeon();
        }
        private void Dungeons_dgvStairs_SelectionChanged(object sender, EventArgs e)
        {
            this.Dungeonmarker_selectetStair = -1;

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

                this.Dungeonmarker_selectetStair = j;

                if ((i < this.itsDSAFileLoader.dungeons.itsDungeons.Count) && (j < this.itsDSAFileLoader.dungeons.itsDungeons[i].Value.stairs.Count))
                {
                    CDungeons.CDungeon.CDungeonStair stair = this.itsDSAFileLoader.dungeons.itsDungeons[i].Value.stairs[j];

                    if (this.Dungeons_dgvDungeonFloors.Rows.Count > stair.Ebene)
                        this.Dungeons_dgvDungeonFloors.Rows[stair.Ebene].Selected = true;

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

            this.drawDungeon();
        }
        private void Dungeons_dgvDoors_SelectionChanged(object sender, EventArgs e)
        {
            this.Dungeonmarker_selectetDoor = -1;

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

                this.Dungeonmarker_selectetDoor = j;

                if ((i < this.itsDSAFileLoader.dungeons.itsDungeons.Count) && (j < this.itsDSAFileLoader.dungeons.itsDungeons[i].Value.doors.Count))
                {
                    CDungeons.CDungeon.CDungeonDoor door = this.itsDSAFileLoader.dungeons.itsDungeons[i].Value.doors[j];

                    if (this.Dungeons_dgvDungeonFloors.Rows.Count > door.Ebene)
                        this.Dungeons_dgvDungeonFloors.Rows[door.Ebene].Selected = true;

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

            this.drawDungeon();
        }
        private void Dungeons_PictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            this.Dungeons_SelectedField_tbEvent.Text = "kein Event";

            if (this.Dungeonmarker_currentDungeon != -1 && this.Dungeonmarker_currentDungeonFloor != -1)
            {

                int factorX = this.Dungeons_PictureBox.Width / 16;
                int factorY = this.Dungeons_PictureBox.Height / 16;
                //CDebugger.addDebugLine("Dungeon_PictureBox at X:" + e.X/factorX + " Y:" + e.Y/factorY);

                this.Dungeonmarker_selectedPosX = e.X / factorX;
                this.Dungeonmarker_selectedPosY = e.Y / factorY;

                CDungeons.CDungeon dungeon = this.itsDSAFileLoader.dungeons.itsDungeons[this.Dungeonmarker_currentDungeon].Value;

                this.Dungeons_SelectedField_tbPosX.Text = this.Dungeonmarker_selectedPosX.ToString();
                this.Dungeons_SelectedField_tbPosY.Text = this.Dungeonmarker_selectedPosY.ToString();
                this.Dungeons_SelectedField_tbFieldTyp.Text = dungeon.floors[this.Dungeonmarker_currentDungeonFloor].FieldToString(this.Dungeonmarker_selectedPosX, this.Dungeonmarker_selectedPosY);

                bool found = false;
                for (int i = 0; i < dungeon.doors.Count; i++)
                {
                    CDungeons.CDungeon.CDungeonDoor door = dungeon.doors[i];
                    if (door.Ebene == this.Dungeonmarker_currentDungeonFloor && door.PositionX == this.Dungeonmarker_selectedPosX && door.PositionY == this.Dungeonmarker_selectedPosY)
                    {
                        this.Dungeons_SelectedField_tbEvent.Text = "Tür Nr. " + i.ToString();
                        if (this.Dungeons_dgvDoors.Rows.Count > i)
                            this.Dungeons_dgvDoors.Rows[i].Selected = true;
                        
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    for (int i = 0; i < dungeon.fights.Count; i++)
                    {
                        CDungeons.CDungeon.CDungeonFight fight = dungeon.fights[i];
                        if (fight.Ebene == this.Dungeonmarker_currentDungeonFloor && fight.PositionX == this.Dungeonmarker_selectedPosX && fight.PositionY == this.Dungeonmarker_selectedPosY)
                        {
                            this.Dungeons_SelectedField_tbEvent.Text = "Kampf Nr. " + i.ToString();
                            if (this.Dungeons_dgvFights.Rows.Count > i)
                                this.Dungeons_dgvFights.Rows[i].Selected = true;

                            found = true;
                            break;
                        }
                    }
                }

                if (!found)
                {
                    for (int i = 0; i < dungeon.stairs.Count; i++)
                    {
                        CDungeons.CDungeon.CDungeonStair stair = dungeon.stairs[i];
                        if (stair.Ebene == this.Dungeonmarker_currentDungeonFloor && stair.PositionX == this.Dungeonmarker_selectedPosX && stair.PositionY == this.Dungeonmarker_selectedPosY)
                        {
                            this.Dungeons_SelectedField_tbEvent.Text = "Treppe Nr. " + i.ToString();
                            if (this.Dungeons_dgvStairs.Rows.Count > i)
                                this.Dungeons_dgvStairs.Rows[i].Selected = true;

                            found = true;
                            break;
                        }
                    }
                }

            }
            else
            {
                this.Dungeonmarker_selectedPosX = -1;
                this.Dungeonmarker_selectedPosY = -1;

                this.Dungeons_SelectedField_tbPosX.Text = "";
                this.Dungeons_SelectedField_tbPosY.Text = "";
                this.Dungeons_SelectedField_tbFieldTyp.Text = "";
            }

            this.drawDungeon();
        }  

        private void drawDungeon()
        {
            if (this.Dungeonmarker_currentDungeon == -1 || this.Dungeonmarker_currentDungeonFloor == -1)
            {
                this.Dungeons_PictureBox.Image = null;
                return;
            }

            if (this.itsDSAFileLoader.dungeons.itsDungeons.Count < this.Dungeonmarker_currentDungeon || this.itsDSAFileLoader.dungeons.itsDungeons[this.Dungeonmarker_currentDungeon].Value.floors.Count < this.Dungeonmarker_currentDungeonFloor)
            {
                this.Dungeons_PictureBox.Image = null;
                return;
            }

            CDungeons.CDungeon.CFloor dungeonFloor = this.itsDSAFileLoader.dungeons.itsDungeons[this.Dungeonmarker_currentDungeon].Value.floors[this.Dungeonmarker_currentDungeonFloor];

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

            //////////////////
            //  Eventmarker //
            //////////////////
            CDungeons.CDungeon dungeon = this.itsDSAFileLoader.dungeons.itsDungeons[this.Dungeonmarker_currentDungeon].Value;
            
            //-----Doors------
            if (this.Dungeonmarker_selectetDoor != -1 && dungeon.doors.Count > this.Dungeonmarker_selectetDoor)
            {
                CDungeons.CDungeon.CDungeonDoor door = dungeon.doors[this.Dungeonmarker_selectetDoor];
                if (door.Ebene == this.Dungeonmarker_currentDungeonFloor)
                {
                    g.DrawRectangle(new Pen(Colors.keyColor_Door, 3), new Rectangle(door.PositionX * PanelBlock_X, door.PositionY * PanelBlock_Y, PanelBlock_X - 1, PanelBlock_Y - 1));
                }
            }

            //-----stairs------
            if (this.Dungeonmarker_selectetStair != -1 && dungeon.stairs.Count > this.Dungeonmarker_selectetStair)
            {
                CDungeons.CDungeon.CDungeonStair stair = dungeon.stairs[this.Dungeonmarker_selectetStair];
                if (stair.Ebene == this.Dungeonmarker_currentDungeonFloor)
                {
                    g.DrawRectangle(new Pen(Colors.keyColor_Stair, 3), new Rectangle(stair.PositionX * PanelBlock_X, stair.PositionY * PanelBlock_Y, PanelBlock_X - 1, PanelBlock_Y - 1));
                }
            }

            //-----fights------
            if (this.Dungeonmarker_selectetFight != -1 && dungeon.fights.Count > this.Dungeonmarker_selectetFight)
            {
                CDungeons.CDungeon.CDungeonFight fight = dungeon.fights[this.Dungeonmarker_selectetFight];
                if (fight.Ebene == this.Dungeonmarker_currentDungeonFloor)
                {
                    g.DrawRectangle(new Pen(Colors.keyColor_Fight, 3), new Rectangle(fight.PositionX * PanelBlock_X, fight.PositionY * PanelBlock_Y, PanelBlock_X - 1, PanelBlock_Y - 1));
                }
            }

            //-----field------
            if (this.Dungeonmarker_selectedPosX != -1 && this.Dungeonmarker_selectedPosY != -1)
            {
                g.DrawRectangle(new Pen(Colors.keyColor_DungeonField, 3), new Rectangle(this.Dungeonmarker_selectedPosX * PanelBlock_X, this.Dungeonmarker_selectedPosY * PanelBlock_Y, PanelBlock_X - 1, PanelBlock_Y - 1));
            }

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
                    Image image = new Bitmap(this.itsDSAFileLoader.bilder.itsImages[i].Value[j]);

                    if (image == null)
                    {
                        this.Bilder_pictureBox.Image = null;
                    }
                    else
                    {
                        if (this.Bilder_cBZoom.Checked)
                        {
                            float faktor_X = (float)Bilder_pictureBox.Width / (float)image.Width;
                            float faktor_Y = (float)Bilder_pictureBox.Height / (float)image.Height;
                            Bitmap bmp2;
                            if (faktor_X > faktor_Y)
                                bmp2 = new Bitmap((int)(image.Width * faktor_Y), (int)(image.Height * faktor_Y));
                            else
                                bmp2 = new Bitmap((int)(image.Width * faktor_X), (int)(image.Height * faktor_X));

                            Graphics g = Graphics.FromImage(bmp2);

                            if (this.Bilder_rBInterpolationMode_NearestNeighbor.Checked)
                                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                            else if (this.Bilder_rBInterpolationMode_Biliniear.Checked)
                                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Bilinear;
                            else if (this.Bilder_rBInterpolationMode_Bikubisch.Checked)
                                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Bicubic;

                            g.DrawImage(image, new Rectangle(Point.Empty, bmp2.Size));
                            Bilder_pictureBox.BackgroundImage = bmp2;
                        }
                        else
                            Bilder_pictureBox.BackgroundImage = image;
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

        //------------Animationen-----------------------------
        private void Animationen_dgvList_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection animationen = this.Animationen_dgvList.SelectedRows;

            if (animationen.Count <= 0)
            {
                //this.Bilder_pictureBox.Image = null;
                this.Animationen_pictureBox.BackgroundImage = null;
                return;
            }


            try
            {
                int i = Convert.ToInt32(this.Animationen_dgvList.SelectedRows[0].Cells[0].Value);

                if (i < this.itsDSAFileLoader.bilder.itsAnimations.Count)
                {
                    this.Animationen_Einzelbild.ClearSelection();
                    this.Animationen_Animationsnummer.ClearSelection();
                    this.Animationen_Einzelbild.Rows.Clear();
                    this.Animationen_Animationsnummer.Rows.Clear();

                    for (int j = 0; j < this.itsDSAFileLoader.bilder.itsAnimations[i].Value.Count; j++)
                    {
                        this.Animationen_Animationsnummer.Rows.Add(j.ToString());
                    }

                    this.Animationen_Animationsnummer.ClearSelection();
                    if (this.Animationen_Animationsnummer.Rows.Count > 0)
                        this.Animationen_Animationsnummer.Rows[0].Selected = true;
                }
            }
            catch (SystemException e2)
            {
                this.Animationen_Einzelbild.ClearSelection();
                this.Animationen_Animationsnummer.ClearSelection();
                this.Animationen_Einzelbild.Rows.Clear();
                this.Animationen_Animationsnummer.Rows.Clear();
                CDebugger.addErrorLine("Animationen: Fehler beim laden der einzel Animationen");
                CDebugger.addErrorLine(e2.ToString());
            }
        }
        private void Animationen_Animationsnummer_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection animationen = this.Animationen_dgvList.SelectedRows;
            DataGridViewSelectedRowCollection animationsnummern = this.Animationen_Animationsnummer.SelectedRows;

            if (animationen.Count <= 0 || animationsnummern.Count <= 0)
            {
                //this.Bilder_pictureBox.Image = null;
                this.Animationen_pictureBox.BackgroundImage = null;
                return;
            }


            try
            {
                int index_1 = Convert.ToInt32(this.Animationen_dgvList.SelectedRows[0].Cells[0].Value);
                int index_2 = Convert.ToInt32(this.Animationen_Animationsnummer.SelectedRows[0].Cells[0].Value);

                if (index_1 < this.itsDSAFileLoader.bilder.itsAnimations.Count && index_2 < this.itsDSAFileLoader.bilder.itsAnimations[index_1].Value.Count)
                {
                    this.Animationen_Einzelbild.ClearSelection();
                    this.Animationen_Einzelbild.Rows.Clear();

                    for (int j = 0; j < this.itsDSAFileLoader.bilder.itsAnimations[index_1].Value[index_2].Count; j++)
                    {
                        this.Animationen_Einzelbild.Rows.Add(j.ToString());
                    }

                    this.Animationen_Einzelbild.ClearSelection();
                    if (this.Animationen_Einzelbild.Rows.Count > 0)
                        this.Animationen_Einzelbild.Rows[0].Selected = true;
                }
            }
            catch (SystemException e2)
            {
                this.Animationen_Animationsnummer.ClearSelection();
                this.Animationen_Animationsnummer.Rows.Clear();
                CDebugger.addErrorLine("Animationen: Fehler beim laden der einzelbilder");
                CDebugger.addErrorLine(e2.ToString());
            }
        }
        private void Animationen_Einzelbild_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection animationen = this.Animationen_dgvList.SelectedRows;
            DataGridViewSelectedRowCollection animationsnummern = this.Animationen_Animationsnummer.SelectedRows;
            DataGridViewSelectedRowCollection einzelbild = this.Animationen_Einzelbild.SelectedRows;

            if (animationen.Count <= 0 || animationsnummern.Count <= 0 || einzelbild.Count <= 0)
            {
                this.Animationen_pictureBox.BackgroundImage = null;
                return;
            }


            try
            {
                int index_1 = Convert.ToInt32(this.Animationen_dgvList.SelectedRows[0].Cells[0].Value);
                int index_2 = Convert.ToInt32(this.Animationen_Animationsnummer.SelectedRows[0].Cells[0].Value);
                int index_3 = Convert.ToInt32(this.Animationen_Einzelbild.SelectedRows[0].Cells[0].Value);

                if (index_1 < this.itsDSAFileLoader.bilder.itsAnimations.Count && index_2 < this.itsDSAFileLoader.bilder.itsAnimations[index_1].Value.Count && index_3 < this.itsDSAFileLoader.bilder.itsAnimations[index_1].Value[index_2].Count)
                {
                    Bitmap image = new Bitmap(this.itsDSAFileLoader.bilder.itsAnimations[index_1].Value[index_2][index_3]);
                    if (this.Animationen_cBZoom.Checked)
                    {
                        float faktor_X = (float)Animationen_pictureBox.Width / (float)image.Width;
                        float faktor_Y = (float)Animationen_pictureBox.Height / (float)image.Height;
                        Bitmap bmp2;
                        if (faktor_X > faktor_Y)
                            bmp2 = new Bitmap((int)(image.Width * faktor_Y), (int)(image.Height * faktor_Y));
                        else
                            bmp2 = new Bitmap((int)(image.Width * faktor_X), (int)(image.Height * faktor_X));

                        Graphics g = Graphics.FromImage(bmp2);

                        if (this.Animationen_rBInterpolationMode_NearestNeighbor.Checked)
                            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                        else if (this.Animationen_rBInterpolationMode_Bilinear.Checked)
                            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Bilinear;
                        else if (this.Animationen_rBInterpolationMode_Bikubisch.Checked)
                            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Bicubic;

                        g.DrawImage(image, new Rectangle(Point.Empty, bmp2.Size));
                        this.Animationen_pictureBox.BackgroundImage = bmp2;
                    }
                    else
                        this.Animationen_pictureBox.BackgroundImage = image;
                }
                else
                    this.Animationen_pictureBox.BackgroundImage = null;
            }
            catch (SystemException e2)
            {
                Animationen_pictureBox.BackgroundImage = null;
                CDebugger.addErrorLine("Animationen: Fehler beim laden der einzelbilder");
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

        private void einstellungenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setdlg.ShowDialog(this);
        }

        private void monsterXMLExportierenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult objResult = saveXMLDialog.ShowDialog();
            if (objResult == System.Windows.Forms.DialogResult.OK)
            {
                this.itsDSAFileLoader.monster.exportMonsterXML(saveXMLDialog.FileName);
            }
        }      
    }
}

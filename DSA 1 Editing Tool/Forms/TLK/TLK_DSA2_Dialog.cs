using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using DSA_1_Editing_Tool.File_Loader;

namespace DSA_1_Editing_Tool.Forms.TLK
{
    //public partial class TLK_DSA2_Dialog : UserControl
    public partial class TLK_DSA2_Dialog : TLK_Form
    {
        private CDialoge _dialog = null;
        private CBilder _bilder = null;

        private int selectedFileIndex = -1;

        public TLK_DSA2_Dialog(ref CDialoge dialog, ref CBilder bilder)
        {
            this._dialog = dialog;
            this._bilder = bilder;

            InitializeComponent();
        }

        public override void loadIndex(int index)
        {
            this.selectedFileIndex = index;

            this.Dialoge_dgvGesprächspartner.Rows.Clear();
            this.Dialoge_dgvLayout.Rows.Clear();
            this.Dialoge_dgvTexte.Rows.Clear();

            if (index == -1 || index >= this._dialog.itsDialoge.Count)
                return;

            CDialoge.CDialog dialog = this._dialog.itsDialoge[index].Value;
            for (int i = 0; i < dialog.itsDSA2Dialog.Count; i++)
            {
                int value = dialog.itsDSA2Dialog[i].Key.DSA2_IndexToName;
                if (value == -1)
                    this.Dialoge_dgvGesprächspartner.Rows.Add(i, "Fehler(-1)");
                else if (value < dialog.itsTexte.Count)
                    this.Dialoge_dgvGesprächspartner.Rows.Add(i, dialog.itsTexte[value] + "(" + value.ToString() + ")");
                else
                    this.Dialoge_dgvGesprächspartner.Rows.Add(i, "???(" + value.ToString() + ")" );
            }

            for (int i = 0; i < dialog.itsTexte.Count; i++)
            {
                this.Dialoge_dgvTexte.Rows.Add(i, dialog.itsTexte[i]);
            }
        }
        public override Type getType()
        {
            return typeof(TLK_DSA2_Dialog);
        }

        private void Dialoge_dgvGesprächspartner_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                DataGridViewSelectedRowCollection selectedPartner = Dialoge_dgvGesprächspartner.SelectedRows;

                if (this.selectedFileIndex < 0 || selectedPartner.Count <= 0)
                {
                    this.Dialoge_btStartTestDialog.Enabled = false;
                    this.disableTestDialoge();
                    return;
                }

                int index_1 = this.selectedFileIndex;
                int index_2 = Convert.ToInt32(selectedPartner[0].Cells[0].Value);

                if (index_1 >= this._dialog.itsDialoge.Count || index_2 >= this._dialog.itsDialoge[index_1].Value.itsDSA2Dialog.Count)
                {
                    this.Dialoge_btStartTestDialog.Enabled = false;
                    this.disableTestDialoge();
                    return;
                }

                CDialoge.CDialog dialog = this._dialog.itsDialoge[index_1].Value;
                CDialoge.CGesprächspartner partner = dialog.itsDSA2Dialog[index_2].Key;

                this.Dialoge_dgvLayout.Rows.Clear();
                for (int i = 0; i < dialog.itsDSA2Dialog[index_2].Value.Count; i++)
                {
                    this.Dialoge_dgvLayout.Rows.Add((object)i); //als object konvertieren um die richtige add Funktion zu benutzen
                }

                this.Dialoge_pictureBox.BackgroundImage = this._bilder.getHeadsImageByID_DSA2(partner.DSA2_PictureID);
                this.Dialoge_Gesprächspartner_Bytes.Text = BitConverter.ToString(partner.DSA2_unknownBytes);
                this.Dialoge_Gesprächspartner_tbBildID.Text = partner.DSA2_PictureID.ToString();
                this.Dialoge_Gesprächspartner_tbIndexStartText.Text = partner.DSA2_IndexToText.ToString();
                
                int value = dialog.itsDSA2Dialog[index_2].Key.DSA2_IndexToName;
                if (value == -1)
                    this.Dialoge_Gesprächspartner_tbName.Text = "Fehler(-1)";
                else if (value < dialog.itsTexte.Count)
                    this.Dialoge_Gesprächspartner_tbName.Text = dialog.itsTexte[value] + "(" + value.ToString() + ")";
                else
                    this.Dialoge_Gesprächspartner_tbName.Text = "???(" + value.ToString() + ")";

                this.Dialoge_Gesprächspartner_tbUnknown.Text = partner.DSA2_StartLayout.ToString();

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
                DataGridViewSelectedRowCollection selectedText = Dialoge_dgvTexte.SelectedRows;

                if (this.selectedFileIndex < 0 || this.selectedFileIndex >= this._dialog.itsDialoge.Count || selectedText.Count <= 0)
                    return;

                int index_1 = this.selectedFileIndex;
                int index_2 = Convert.ToInt32(selectedText[0].Cells[0].Value);

                if (index_1 >= this._dialog.itsDialoge.Count || index_2 >= this._dialog.itsDialoge[index_1].Value.itsTexte.Count)
                    return;

                this.Dialoge_rtbCurrenText.Text = this._dialog.itsDialoge[index_1].Value.itsTexte[index_2];

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
                DataGridViewSelectedRowCollection selectedPartner = Dialoge_dgvGesprächspartner.SelectedRows;
                DataGridViewSelectedRowCollection selectedLayout = Dialoge_dgvLayout.SelectedRows;

                if (this.selectedFileIndex < 0 || selectedLayout.Count <= 0 || selectedPartner.Count <= 0)
                    return;

                int index_1 = this.selectedFileIndex;
                int index_2 = Convert.ToInt32(selectedPartner[0].Cells[0].Value); 
                int index_3 = Convert.ToInt32(selectedLayout[0].Cells[0].Value);

                if (index_1 >= this._dialog.itsDialoge.Count || 
                    index_2 >= this._dialog.itsDialoge[index_1].Value.itsDSA2Dialog.Count || 
                    index_3 >= this._dialog.itsDialoge[index_1].Value.itsDSA2Dialog[index_2].Value.Count)
                    return;

                CDialoge.CDialogLayoutZeile layout = this._dialog.itsDialoge[index_1].Value.itsDSA2Dialog[index_2].Value[index_3];

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
                DataGridViewSelectedRowCollection selectedPartner = Dialoge_dgvGesprächspartner.SelectedRows;
                DataGridViewSelectedRowCollection selectedLayout = Dialoge_dgvLayout.SelectedRows;

                if (this.selectedFileIndex < 0 || selectedLayout.Count <= 0 || selectedPartner.Count <= 0)
                    return;

                int index_1 = this.selectedFileIndex;
                int index_2 = Convert.ToInt32(selectedPartner[0].Cells[0].Value);

                if (index_1 >= this._dialog.itsDialoge.Count ||
                    index_2 >= this._dialog.itsDialoge[index_1].Value.itsDSA2Dialog.Count)
                {
                    this.Dialoge_btStartTestDialog.Enabled = false;
                    this.disableTestDialoge();
                    return;
                }

                CDialoge.CDialog dialog = this._dialog.itsDialoge[index_1].Value;
                CDialoge.CGesprächspartner partner = this._dialog.itsDialoge[index_1].Value.itsDSA2Dialog[index_2].Key;

                if (partner.DSA2_StartLayout >= this._dialog.itsDialoge[index_1].Value.itsDSA2Dialog[index_2].Value.Count)
                {
                    this.Dialoge_btStartTestDialog.Enabled = false;
                    this.disableTestDialoge();
                    return;
                }      

                if (partner.offsetStartString == 255 || partner.DSA2_IndexToText >= dialog.itsTexte.Count)
                    this.Dialoge_rtbTestDialog.Text = "";
                else
                    this.Dialoge_rtbTestDialog.Text = dialog.itsTexte[partner.offsetStartString];

                this.currentDialog = dialog;
                this.currentLayoutLines = this._dialog.itsDialoge[index_1].Value.itsDSA2Dialog[index_2].Value;
                this.offsetCurrentText = partner.DSA2_IndexToText;

                this.loadLayoutForTestDialog(partner.DSA2_StartLayout);
            }
            catch (SystemException)
            {
                CDebugger.addErrorLine("Fehler beim Laden des Gesprächspartners(Dialoge)");
                this.disableTestDialoge();
            }
        }
        private CDialoge.CDialog currentDialog = null;
        private List<CDialoge.CDialogLayoutZeile> currentLayoutLines = null;
        private CDialoge.CDialogLayoutZeile currentLayout = null;
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

            if (currentDialog == null || layoutIndex >= currentLayoutLines.Count)
            {
                this.Dialoge_rtbTestDialog.Text = "Fehler beim laden des Dialoges";
                this.disableTestDialoge();
                return;
            }

            this.currentLayout = currentLayoutLines[layoutIndex];

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

        private void ll_Dialoge_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://freedsa.schattenkind.net/index.php/TLK");
        } 
    }
}

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
    //public partial class TLK_DSA_1 : UserControl
    public partial class TLK_DSA_1 : TLK_Form
    {
        private CDialoge _dialog = null;
        private CBilder _bilder = null;

        private int selectedFileIndex = -1;

        public TLK_DSA_1(ref CDialoge dialog, ref CBilder bilder)
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
            for (int i = 0; i < dialog.itsPartner.Count; i++)
            {
                this.Dialoge_dgvGesprächspartner.Rows.Add(i, dialog.itsPartner[i].name);
            }

            for (int i = 0; i < dialog.itsDialogZeile.Count; i++)
            {
                this.Dialoge_dgvLayout.Rows.Add(i.ToString());
            }

            for (int i = 0; i < dialog.itsTexte.Count; i++)
            {
                this.Dialoge_dgvTexte.Rows.Add(i, dialog.itsTexte[i]);
            }
        }
        public override Type getType()
        {
            return typeof(TLK_DSA_1);
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

                if (index_1 >= this._dialog.itsDialoge.Count || index_2 >= this._dialog.itsDialoge[index_1].Value.itsPartner.Count)
                {
                    this.Dialoge_btStartTestDialog.Enabled = false;
                    this.disableTestDialoge();
                    return;
                }

                CDialoge.CGesprächspartner partner = this._dialog.itsDialoge[index_1].Value.itsPartner[index_2];
                this.Dialoge_pictureBox.BackgroundImage = this._bilder.getIn_HeadsImageByID(partner.BildID_IN_HEADS_NVF);

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
                DataGridViewSelectedRowCollection selectedText = Dialoge_dgvTexte.SelectedRows;

                if (this.selectedFileIndex < 0 || selectedText.Count <= 0)
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
                DataGridViewSelectedRowCollection selectedLayout = Dialoge_dgvLayout.SelectedRows;

                if (this.selectedFileIndex < 0 || selectedLayout.Count <= 0)
                    return;

                int index_1 = this.selectedFileIndex;
                int index_2 = Convert.ToInt32(selectedLayout[0].Cells[0].Value);

                if (index_1 >= this._dialog.itsDialoge.Count || index_2 >= this._dialog.itsDialoge[index_1].Value.itsDialogZeile.Count)
                    return;

                CDialoge.CDialogLayoutZeile layout = this._dialog.itsDialoge[index_1].Value.itsDialogZeile[index_2];

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

                DataGridViewSelectedRowCollection selectedPartner = Dialoge_dgvGesprächspartner.SelectedRows;

                if (this.selectedFileIndex < 0 || selectedPartner.Count <= 0)
                {
                    this.Dialoge_btStartTestDialog.Enabled = false;
                    this.disableTestDialoge();
                    return;
                }

                index_1 = this.selectedFileIndex;
                index_2 = Convert.ToInt32(selectedPartner[0].Cells[0].Value);



                if (index_1 >= this._dialog.itsDialoge.Count || index_2 >= this._dialog.itsDialoge[index_1].Value.itsPartner.Count)
                {
                    this.Dialoge_btStartTestDialog.Enabled = false;
                    this.disableTestDialoge();
                    return;
                }

                CDialoge.CDialog dialog = this._dialog.itsDialoge[index_1].Value;
                CDialoge.CGesprächspartner partner = this._dialog.itsDialoge[index_1].Value.itsPartner[index_2];

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

        private void ll_Dialoge_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://freedsa.schattenkind.net/index.php/TLK");
        } 
    }
}

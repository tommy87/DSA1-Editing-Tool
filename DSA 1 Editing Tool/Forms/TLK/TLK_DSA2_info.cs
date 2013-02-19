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
    public partial class TLK_DSA2_info : TLK_Form
    //public partial class TLK_DSA2_info : UserControl
    {
        private CDialoge _dialog = null;
        private CBilder _bilder = null;

        private int selectedFileIndex = -1;

        public TLK_DSA2_info(ref CDialoge dialog, ref CBilder bilder)
        {
            InitializeComponent();

            this._dialog = dialog;
            this._bilder = bilder;
        }

        public override void loadIndex(int index)
        {
            this.selectedFileIndex = index;

            this.tB_Allgemein_TOLERANCE.Text = String.Empty;
            this.tB_Allgemein_PIC.Text = String.Empty;
            this.tB_Allgemein_NAME.Text = String.Empty;
            this.Allgemein_pB_DialogPartner.Image = null;

            this.dGV_SelectedTOPIC.Rows.Clear();
            this.dgvTOPICs.Rows.Clear();
            this.rTB_Text.Clear();

            if (this._dialog == null)
                return;

            if (index == -1 || index >= this._dialog.itsDialoge.Count)
                return;

            CDialoge.DSA2InfoDialog infoDialog = this._dialog.itsDialoge[index].Value.itsDSA2InfoDialog;

            this.tB_Allgemein_NAME.Text = infoDialog.Name;
            this.tB_Allgemein_PIC.Text = infoDialog.PIC.ToString();
            this.tB_Allgemein_TOLERANCE.Text = infoDialog.TOLERANCE.ToString();

            if (this._bilder != null)
                this.Allgemein_pB_DialogPartner.Image = _bilder.getHeadsImageByID_DSA2(infoDialog.PIC - 1);

            for (int i = 0; i < infoDialog.itsTopics.Count; i++)
            {
                this.dgvTOPICs.Rows.Add(i, infoDialog.itsTopics[i].NAME);
            }
        }
        public override Type getType()
        {
            return typeof(TLK_DSA2_info);
        }

        private void dgvTOPICs_SelectionChanged(object sender, EventArgs e)
        {
            this.dGV_SelectedTOPIC.Rows.Clear();

            if (this.selectedFileIndex == -1 || this.selectedFileIndex >= this._dialog.itsDialoge.Count)
                return;

            CDialoge.DSA2InfoDialog infoDialog = this._dialog.itsDialoge[this.selectedFileIndex].Value.itsDSA2InfoDialog;

            DataGridViewSelectedRowCollection selectedTOPIC = this.dgvTOPICs.SelectedRows;
            if (selectedTOPIC.Count <= 0)
                return;

            int index = Convert.ToInt32(selectedTOPIC[0].Cells[0].Value);
            if (index < 0 || index >= infoDialog.itsTopics.Count)
                return;

            CDialoge.DSA2InfoDialog.TOPIC topic = infoDialog.itsTopics[index];

            for (int i = 0; i < topic.itsTopics.Count; i++)
            {
                CDialoge.DSA2InfoDialog.TOPIC.TOPICLine topicLine = topic.itsTopics[i];
                this.dGV_SelectedTOPIC.Rows.Add(i, topicLine.value_1, topicLine.valie_2, topicLine.text);
            }
            
        }

        private void dGV_SelectedTOPIC_SelectionChanged(object sender, EventArgs e)
        {
            this.rTB_Text.Clear();

            DataGridViewSelectedRowCollection selectedTOPICLine = this.dGV_SelectedTOPIC.SelectedRows;
            if (selectedTOPICLine.Count <= 0)
                return;

            this.rTB_Text.Text = Convert.ToString(dGV_SelectedTOPIC.SelectedRows[0].Cells[3].Value);
        }
    }
}

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

            this.dgvTOPICs.Rows.Clear();

            if (this._dialog == null)
                return;

            if (index == -1 || index >= this._dialog.itsDialoge.Count)
                return;

            CDialoge.DSA2InfoDialog infoDialog = this._dialog.itsDialoge[index].Value.itsDSA2InfoDialog;

            this.tB_Allgemein_NAME.Text = infoDialog.Name;
            this.tB_Allgemein_PIC.Text = infoDialog.PIC.ToString();
            this.tB_Allgemein_TOLERANCE.Text = infoDialog.TOLERANCE.ToString();

            if (this._bilder != null)
                this.Allgemein_pB_DialogPartner.Image = _bilder.getHeadsImageByID_DSA2(infoDialog.PIC);

            for (int i = 0; i < infoDialog.itsTopics.Count; i++)
            {
                this.dgvTOPICs.Rows.Add(i, infoDialog.itsTopics[i].NAME);
            }
        }
        public override Type getType()
        {
            return typeof(TLK_DSA2_info);
        }
    }
}

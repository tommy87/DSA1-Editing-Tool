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
    {
        private CDialoge _dialog = null;
        private CBilder _bilder = null;

        private int selectedFileIndex = -1;

        public TLK_DSA2_info(ref CDialoge dialog, ref CBilder bilder)
        {
            InitializeComponent();
        }

        public override void loadIndex(int index)
        {
            this.selectedFileIndex = index;
        }
        public override Type getType()
        {
            return typeof(TLK_DSA2_info);
        }
    }
}

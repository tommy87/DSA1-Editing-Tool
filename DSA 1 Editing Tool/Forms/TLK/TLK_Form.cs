using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace DSA_1_Editing_Tool.Forms.TLK
{
    public abstract partial class TLK_Form : UserControl
    {
        public TLK_Form()
        {
            InitializeComponent();
        }

        public abstract void loadIndex(int index);

        public abstract Type getType();
    }
}

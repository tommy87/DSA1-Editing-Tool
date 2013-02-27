using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DSA_1_Editing_Tool
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
            catch (Exception)
            {
                //mono workaround:
                //index = dataGridView.SelcetedRows[0].Index
                //wenn dataGridView neue Rows bekommt und der RowCount < index ist -->crash
            }

        }
    }
}

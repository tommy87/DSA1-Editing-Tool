using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace DSA_1_Editing_Tool.File_Loader
{
    public class CDialoge
    {
        public List<KeyValuePair<string, CDialog>> itsDialoge = new List<KeyValuePair<string, CDialog>>();

        public CDialoge()
        {
        }

        public void loadDialoge(ref byte[] data, List<CDSAFileLoader.CFileSet> TLKs)
        {
            this.itsDialoge.Clear();

            foreach (CDSAFileLoader.CFileSet set in TLKs)
            {
                this.itsDialoge.Add(new KeyValuePair<string, CDialog>(set.filename, new CDialog(ref data, set)));
            }

            CDebugger.addDebugLine("Dialoge wurden erfolgreich geladen");
        }

        public class CDialog
        {
            public List<CGesprächspartner> itsPartner = new List<CGesprächspartner>();
            public List<CDialogLayoutZeile> itsDialogZeile = new List<CDialogLayoutZeile>();
            public List<string> itsTexte = new List<string>();

            public CDialog(ref byte[] data, CDSAFileLoader.CFileSet TLK)
            {
                this.itsDialogZeile.Clear();
                this.itsPartner.Clear();
                this.itsTexte.Clear();

                int position = TLK.startOffset;

                Int32 offsetTextBlock = TLK.startOffset + CHelpFunctions.byteArrayToInt32(ref data, position) + 6; //warum +6--> weil header genau 6 bytes hat
                position += 4;
                Int16 anzahlGesprächspartner = CHelpFunctions.byteArrayToInt16(ref data, position);
                position += 2;

                for (int i = 0; i < anzahlGesprächspartner; i++)
                {
                    this.itsPartner.Add(new CGesprächspartner(ref data, position));
                    position += 38;
                }

                while (position < offsetTextBlock)
                {
                    this.itsDialogZeile.Add(new CDialogLayoutZeile(ref data, position));
                    position += 8;
                }

                position = offsetTextBlock;

                do
                {
                    string text = CHelpFunctions.readDSAString(ref data, position, 0);
                    this.itsTexte.Add(text);
                    position += text.Length + 1;
                }
                while (position < TLK.endOffset);
            }
        }

        public class CGesprächspartner
        {
            public UInt16 offsetStartLayoutZeile = 0;
            public UInt16 offsetStartString = 0;
            public string name = "";
            public UInt16 BildID_IN_HEADS_NVF = 0;
            public byte[] unbekannteBytes = null;

            public CGesprächspartner(ref byte[] data, Int32 position)
            {
                this.offsetStartLayoutZeile = (UInt16)(CHelpFunctions.byteArrayToInt32(ref data, position) / 8);
                position += 4;
                this.offsetStartString = (UInt16)CHelpFunctions.byteArrayToInt16(ref data, position);
                position += 2;
                this.name = CHelpFunctions.readDSAString(ref data, position, 30);
                position += 30;
                this.BildID_IN_HEADS_NVF = (UInt16)CHelpFunctions.byteArrayToInt16(ref data, position);
            }
        }

        public class CDialogLayoutZeile
        {
            public byte offsetHaupttext = 0;
            public byte unbekannterWert = 0;
            public byte Antwort1 = 0;
            public byte Antwort2 = 0;
            public byte Antwort3 = 0;
            public byte FolgeLayoutBeiAntwort1 = 0;
            public byte FolgeLayoutBeiAntwort2 = 0;
            public byte FolgeLayoutBeiAntwort3 = 0;

            public CDialogLayoutZeile(ref byte[] data, Int32 position)
            {
                this.offsetHaupttext = data[position++];
                this.unbekannterWert = data[position++];
                this.Antwort1 = data[position++];
                this.Antwort2 = data[position++];
                this.Antwort3 = data[position++];
                this.FolgeLayoutBeiAntwort1 = data[position++];
                this.FolgeLayoutBeiAntwort2 = data[position++];
                this.FolgeLayoutBeiAntwort3 = data[position++];
            }
        }
    }
}

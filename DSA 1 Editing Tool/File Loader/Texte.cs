using System;
using System.Collections.Generic;
using System.Text;

using System.IO;

namespace DSA_1_Editing_Tool.File_Loader
{
    public class CTextList
    {
        public List<KeyValuePair<string, List<string>>> LTX_Texte = new List<KeyValuePair<string, List<string>>>();   //Liste von Dateinamen und einer Liste mit den zugehörigen Texten
        public List<KeyValuePair<string, List<string>>> DTX_Texte = new List<KeyValuePair<string, List<string>>>();   //Liste von Dateinamen und einer Liste mit den zugehörigen Texten

        public void loadTexte(ref byte[] data, List<CDSAFileLoader.CFileSet> LTX, List<CDSAFileLoader.CFileSet> DTX)
        {
            this.loadLTX(ref data, LTX);
            this.loadDTX(ref data, DTX);
        }

        private void loadLTX(ref byte[] data, List<CDSAFileLoader.CFileSet> LTX)
        {
            this.LTX_Texte.Clear();

            if (data == null)
                return;

            if (LTX.Count == 0)
                CDebugger.addDebugLine("Texte: keine LTX Dateien gefunden");
            else
                CDebugger.addDebugLine("Texte: es wurden " + LTX.Count.ToString() + " LTX Dateien gefunden");

            foreach (CDSAFileLoader.CFileSet fileSet in LTX)
            {
                // alle Texte der Datei auslesen
                Int32 position = fileSet.startOffset;
                List<string> textList = new List<string>();

                string text = CHelpFunctions.readDSAString(ref data, position, 0);
                textList.Add(text);
                position += (text.Length + 1);

                while ((position + text.Length + 2) < fileSet.endOffset)
                {
                    text = CHelpFunctions.readDSAString(ref data, position, 0);
                    textList.Add(text);
                    position += (text.Length + 1);
                }

                //dateinamen auslesen
                //int pos = s.LastIndexOf("\\");
                //string filename = s.Substring(pos + 1);

                this.LTX_Texte.Add(new KeyValuePair<string, List<string>>(fileSet.filename, textList));
            }
        }
        private void loadDTX(ref byte[] data, List<CDSAFileLoader.CFileSet> DTX)
        {
            this.DTX_Texte.Clear();

            if (data == null)
                return;

            if (DTX.Count == 0)
                CDebugger.addDebugLine("Texte: keine DTX Dateien gefunden");
            else
                CDebugger.addDebugLine("Texte: es wurden " + DTX.Count.ToString() + " DTX Dateien gefunden");

            foreach (CDSAFileLoader.CFileSet fileSet in DTX)
            {
                // alle Texte der Datei auslesen
                Int32 position = fileSet.startOffset;
                List<string> textList = new List<string>();

                string text = CHelpFunctions.readDSAString(ref data, position, 0);
                textList.Add(text);
                position += (text.Length + 1);

                while ((position + text.Length + 2) < fileSet.endOffset)
                {
                    text = CHelpFunctions.readDSAString(ref data, position, 0);
                    textList.Add(text);
                    position += (text.Length + 1);
                }

                //dateinamen auslesen
                this.DTX_Texte.Add(new KeyValuePair<string, List<string>>(fileSet.filename, textList));
            }
        }
    }
}

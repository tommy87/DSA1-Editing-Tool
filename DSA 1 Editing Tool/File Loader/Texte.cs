using System;
using System.Collections.Generic;
using System.Text;

using System.Xml;
using System.IO;

namespace DSA_1_Editing_Tool.File_Loader
{
    public class CTextList
    {
        public List<KeyValuePair<string, List<string>>> LTX_Texte = new List<KeyValuePair<string, List<string>>>();   //Liste von Dateinamen und einer Liste mit den zugehörigen Texten
        public List<KeyValuePair<string, List<string>>> DTX_Texte = new List<KeyValuePair<string, List<string>>>();   //Liste von Dateinamen und einer Liste mit den zugehörigen Texten

        public void addTexte(ref byte[] data, List<CDSAFileLoader.CFileSet> LTX, List<CDSAFileLoader.CFileSet> DTX)
        {
            this.addLTX(ref data, LTX);
            this.addDTX(ref data, DTX);
        }
        public void clear()
        {
            this.LTX_Texte.Clear();
            this.DTX_Texte.Clear();
        }

        private void addLTX(ref byte[] data, List<CDSAFileLoader.CFileSet> LTX)
        {
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
        private void addDTX(ref byte[] data, List<CDSAFileLoader.CFileSet> DTX)
        {
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

        //////////////////
        //  XML export  //
        //////////////////
        private void writeTextgroup(XmlTextWriter wr, List<string> list, string prefix)
        {
            for (int i = 0; i < list.Count; i++)
            {
                wr.WriteStartElement("text");
                wr.WriteAttributeString("key", prefix + "_" + i.ToString());
                wr.WriteCData(prepareText(list[i]));
                wr.WriteEndElement();
            }
        }
        private void writeTextlist( XmlTextWriter wr, List<KeyValuePair<string, List<string>>> list, string prefix ) {
            for (int i = 0; i < list.Count; i++)
            {
                string idkey = list[i].Key.ToLower();
                idkey = prefix + idkey.Substring(0, idkey.Length - 4);
                writeTextgroup(wr, list[i].Value, idkey);
            }
        }
        public void exportXML(string filename, CItemList itl, CDialoge dlg)
        {
            XmlTextWriter wr = new XmlTextWriter(filename, Encoding.UTF8);
            wr.WriteStartDocument();
            wr.WriteStartElement("texts");
            wr.WriteStartElement("alltexts");

            writeTextlist( wr, this.LTX_Texte, "" );
            writeTextlist( wr, this.DTX_Texte, "d" );

            itl.exportTextXML(wr);
            dlg.exportUnrefTexts(wr);

            wr.WriteEndElement();
            wr.WriteEndDocument();
            wr.Close();
        }

        //////////////////
        //  CSV export  //
        //////////////////
        private string prepareText(string text, bool forcsv = false)
        {
            string ret = text.Replace("ñ", "[hl]").Replace("ð", "[/hl]");
            // if (forcsv)
            {
                ret = ret.Replace("\r\n", " ").Replace("\r", " ").Replace("\n", " ");
            }
            return ret.Trim();
        }
        public void exportCSV(string filename)
        {
            StreamWriter tw = new StreamWriter(filename);

            tw.WriteLine("Filename;Key;Text");
            string fn;
            int i, j;
            List<string> val;
            string str;

            for (i = 0; i < LTX_Texte.Count; i++)
            {
                fn = LTX_Texte[i].Key.ToLower().Replace(".ltx","");
                val = LTX_Texte[i].Value;
                for (j = 0; j < val.Count; j++)
                {
                    str = prepareText(val[j], true);
                    if( str != "" )
                        tw.WriteLine(fn + ";" + j.ToString() + ";" + str);
                }
            }
            for (i = 0; i < DTX_Texte.Count; i++)
            {
                fn = DTX_Texte[i].Key.ToLower().Replace(".dtx","");
                val = DTX_Texte[i].Value;
                for (j = 0; j < val.Count; j++)
                {
                    str = prepareText(val[j], true);
                    if (str != "")
                        tw.WriteLine(fn + ";" + j.ToString() + ";" + str);
                }
            }

            tw.Close();
        }
    }
}

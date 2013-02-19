using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

using System.Data;
using System.IO;
using System.Text.RegularExpressions;

namespace DSA_1_Editing_Tool.File_Loader
{
    public class CDialoge
    {
        public List<KeyValuePair<string, CDialog>> itsDialoge = new List<KeyValuePair<string, CDialog>>();

        public CDialoge()
        {
        }

        public void addDialoge(ref byte[] data, List<CDSAFileLoader.CFileSet> TLKs, DSAVersion version)
        {
            foreach (CDSAFileLoader.CFileSet set in TLKs)
            {
                this.itsDialoge.Add(new KeyValuePair<string, CDialog>(set.filename, new CDialog(ref data, set, version)));
            }

            CDebugger.addDebugLine("Dialoge wurden erfolgreich geladen");
        }

        public void clear()
        {
            this.itsDialoge.Clear();
        }

        //////////////////
        //  XML export  //
        //////////////////

        public void exportUnrefTexts( XmlTextWriter wr ) {
            foreach (KeyValuePair<string, CDialog> dlgstore in itsDialoge)
            {
                CDialog dlg = dlgstore.Value;

                int i, j;
                List<int> unused = new List<int>();
                for (i = 0; i < dlgstore.Value.itsTexte.Count; i++)
                {
                    unused.Add(i);
                }

                string cap = "dlg" + dlgstore.Key.Substring(0, dlgstore.Key.Length - 4).ToLower();
                CDebugger.addDebugLine("initial "+unused.Count.ToString()+" Texte in "+cap+" vorhanden");

                for (i = 0; i < dlg.itsDSA1Partner.Count; i++ )
                {
                    CGesprächspartner p = dlg.itsDSA1Partner[i];
                    int layoutstart = p.offsetStartLayoutZeile;
                    int stringstart = p.offsetStartString;

                    int layoutende;
                    if( i == dlg.itsDSA1Partner.Count - 1 )
                        layoutende = dlg.itsDSA1DialogZeile.Count;
                    else
                        layoutende = dlg.itsDSA1Partner[i+1].offsetStartLayoutZeile;

                    for( j = layoutstart; j < layoutende; j++ )
                    {
                        CDialogLayoutZeile lay = dlg.itsDSA1DialogZeile[j];
                        // CDebugger.addDebugLine("Entferne " + lay.Antwort1.ToString());
                        try { unused.Remove(lay.Antwort1 + stringstart); }
                        catch (Exception) { }
                        // CDebugger.addDebugLine("Entferne " + lay.Antwort2.ToString());
                        try { unused.Remove(lay.Antwort2 + stringstart); }
                        catch (Exception) { }
                        // CDebugger.addDebugLine("Entferne " + lay.Antwort3.ToString());
                        try { unused.Remove(lay.Antwort3 + stringstart); }
                        catch (Exception) { }

                        // CDebugger.addDebugLine("Entferne Haupttext " + lay.offsetHaupttext.ToString());
                        try { unused.Remove(lay.offsetHaupttext + stringstart); }
                        catch (Exception) { }
                    }
                }

                CDebugger.addDebugLine("Noch " + unused.Count.ToString() + " Texte vorhanden");
                foreach (int uid in unused)
                {
                    wr.WriteStartElement("text");
                    wr.WriteAttributeString("key", cap + "_" + uid.ToString());
                    if( dlg.itsTexte[uid] != "" )
                        wr.WriteCData(dlg.itsTexte[uid]);
                    wr.WriteEndElement();
                }
            }
        }
        private void writeResponse( XmlTextWriter wr, int id, int aid, string text, int nextgoto ) {
            if( (aid != 0) || (nextgoto != 0) )
            {
                wr.WriteStartElement("response" + id.ToString());
                wr.WriteAttributeString("goto", nextgoto.ToString());
                if( aid != 0 )
                    wr.WriteCData(text);
                wr.WriteEndElement();
            }
        }
        public void exportXML(string path)
        {
            XmlTextWriter wp = new XmlTextWriter(path + "\\de_dlgpartner.xml", Encoding.UTF8);
            XmlTextWriter wr = new XmlTextWriter(path + "\\de_dlgtext.xml", Encoding.UTF8);

            wp.WriteStartDocument();
            wp.WriteStartElement("dialogpartner");

            wr.WriteStartDocument();
            wr.WriteStartElement("dialog");

            foreach (KeyValuePair<string, CDialog> dlgstore in itsDialoge)
            {
                CDialog dlg = dlgstore.Value;

                int i, j;
                string cap = dlgstore.Key.Substring(0, dlgstore.Key.Length - 4).ToLower();
                // CDebugger.addDebugLine("initial " + unused.Count.ToString() + " Texte in " + cap + " vorhanden");

                for (i = 0; i < dlg.itsDSA1Partner.Count; i++)
                {
                    CGesprächspartner p = dlg.itsDSA1Partner[i];
                    wp.WriteStartElement("partner");

                    string pid = cap + "_" + (i+1).ToString();
                    wp.WriteElementString("id", pid);
                    wp.WriteElementString("name", p.name);
                    wp.WriteElementString("bildid", p.BildID_IN_HEADS_NVF.ToString());
                    wp.WriteEndElement();

                    int layoutstart = p.offsetStartLayoutZeile;
                    int stringstart = p.offsetStartString;

                    int layoutende;
                    if (i == dlg.itsDSA1Partner.Count - 1)
                        layoutende = dlg.itsDSA1DialogZeile.Count;
                    else
                        layoutende = dlg.itsDSA1Partner[i + 1].offsetStartLayoutZeile;

                    for (j = layoutstart; j < layoutende; j++)
                    {
                        CDialogLayoutZeile lay = dlg.itsDSA1DialogZeile[j];

                        wr.WriteStartElement("text");
                        wr.WriteElementString("partner", pid);
                        wr.WriteElementString("id", (j - layoutstart + 1).ToString() );
                        wr.WriteElementString("adddata",lay.unbekannterWert.ToString());
                        if (lay.offsetHaupttext == 255)
                        {
                            wr.WriteElementString("empty", "true");
                        }
                        else
                        {
                            wr.WriteElementString("request", dlg.itsTexte[lay.offsetHaupttext + stringstart]);
                        }

                        int folge = lay.FolgeLayoutBeiAntwort1;
                        if ((folge != 0) && (folge != 255)) folge = lay.FolgeLayoutBeiAntwort1 + 1;
                        writeResponse(wr, 1, lay.Antwort1, dlg.itsTexte[lay.Antwort1 + stringstart], folge);

                        folge = lay.FolgeLayoutBeiAntwort2;
                        if ((folge != 0) && (folge != 255)) folge = lay.FolgeLayoutBeiAntwort2 + 1;
                        writeResponse(wr, 2, lay.Antwort2, dlg.itsTexte[lay.Antwort2 + stringstart], folge);
                        
                        folge = lay.FolgeLayoutBeiAntwort3;
                        if ((folge != 0) && (folge != 255)) folge = lay.FolgeLayoutBeiAntwort3 + 1;
                        writeResponse(wr, 3, lay.Antwort3, dlg.itsTexte[lay.Antwort3 + stringstart], folge);
                        wr.WriteEndElement();
                    }
                }
            }

            wr.WriteEndElement();
            wr.WriteEndDocument();
            wr.Close();
            wp.WriteEndElement();
            wp.WriteEndDocument();
            wp.Close();
        }

        //----------------------------------------

        public class CDialog
        {
            public List<string> itsTexte = new List<string>();

            //DSA 1 
            public List<CGesprächspartner> itsDSA1Partner = new List<CGesprächspartner>();
            public List<CDialogLayoutZeile> itsDSA1DialogZeile = new List<CDialogLayoutZeile>();

            //DSA 2
            public bool isDSA2InfoDialog = false;
            //DSA 2 - Dialog
            public List<KeyValuePair<CGesprächspartner, List<CDialogLayoutZeile>>> itsDSA2Dialog = new List<KeyValuePair<CGesprächspartner, List<CDialogLayoutZeile>>>();
            //DSA 2 - info 
            public DSA2InfoDialog itsDSA2InfoDialog = new DSA2InfoDialog();

            //-----------------------------------------

            public CDialog(ref byte[] data, CDSAFileLoader.CFileSet TLK, DSAVersion version)
            {
                this.itsDSA1DialogZeile.Clear();
                this.itsDSA1Partner.Clear();
                this.itsTexte.Clear();

                if (data == null || TLK == null)
                    return;

                switch (version)
                {
                    case DSAVersion.Blade:
                    case DSAVersion.Schick:
                        this.loadDSA1(ref data, TLK);
                        break;

                    case DSAVersion.Schweif:
                        bool found = false;
                        for (int i = TLK.startOffset; i < (TLK.endOffset - 3); i++)
                        {
                            if (data[i] == 'P' && data[i + 1] == 'I' && data[i + 2] == 'C')
                            {
                                found = true;
                                break;
                            }
                        }
                        if (found)
                            this.loadDSA2_info(ref data, TLK);
                        else
                            this.loadDSA2_dialog(ref data, TLK);

                        break;
                }
            }
            private void loadDSA1(ref byte[] data, CDSAFileLoader.CFileSet TLK)
            {
                int position = TLK.startOffset;

                Int32 offsetTextBlock = TLK.startOffset + CHelpFunctions.byteArrayToInt32(ref data, position) + 6; //warum +6--> weil header genau 6 bytes hat
                position += 4;
                Int16 anzahlGesprächspartner = CHelpFunctions.byteArrayToInt16(ref data, position);
                position += 2;

                for (int i = 0; i < anzahlGesprächspartner; i++)
                {
                    this.itsDSA1Partner.Add(new CGesprächspartner(ref data, position, DSAVersion.Schick));
                    position += 38;
                }

                while (position < offsetTextBlock)
                {
                    this.itsDSA1DialogZeile.Add(new CDialogLayoutZeile(ref data, position));
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
            private void loadDSA2_dialog(ref byte[] data, CDSAFileLoader.CFileSet TLK)
            {
                int position = TLK.startOffset;

                Int16 numberDialogs = CHelpFunctions.byteArrayToInt16(ref data, position);
                position += 2;

                List<CGesprächspartner> partner = new List<CGesprächspartner>(numberDialogs);

                for (int i = 0; i < numberDialogs; i++)
                {
                    partner.Add(new CGesprächspartner(ref data, position, DSAVersion.Schweif));
                    position += 12;
                }

                

                for (int i = 0; i < numberDialogs; i++)
                {
                    int numberLayouts = CHelpFunctions.byteArrayToInt16(ref data, position);
                    position += 2;

                    List<CDialogLayoutZeile> layout = new List<CDialogLayoutZeile>(numberLayouts);

                    for (int j = 0; j < numberLayouts; j++)
                    {
                        layout.Add(new CDialogLayoutZeile(ref data, position));
                        position += 8;
                    }

                    this.itsDSA2Dialog.Add(new KeyValuePair<CGesprächspartner, List<CDialogLayoutZeile>>(partner[i], layout));
                }

                position += 4;

                do
                {
                    string text = CHelpFunctions.readDSAString(ref data, position, 0);
                    this.itsTexte.Add(text);
                    position += text.Length + 1;
                }
                while (position < TLK.endOffset);
            }
            private void loadDSA2_info(ref byte[] data, CDSAFileLoader.CFileSet TLK)
            {
                int length = TLK.endOffset - TLK.startOffset;
                if (length <= 0)
                {
                    CDebugger.addErrorLine("Fehler beim Laden des Info Dialogs " + TLK.filename + " (offset Problem)");
                    return;
                }

                Byte[] bytes = new byte[TLK.endOffset - TLK.startOffset];
                Array.Copy(data, TLK.startOffset, bytes, 0, length);

                DSA2InfoDialog infoDialog = new DSA2InfoDialog();
                DSA2InfoDialog.TOPIC topic = null;

                try
                {
                    using (StreamReader reader = new StreamReader(new MemoryStream(bytes)))
                    {
                        string line;
                        bool currentlyReadingATopic = false;

                        while ((line = reader.ReadLine()) != null)
                        {
                            string[] values;
                            if (line.Contains("#"))
                                values = getSubStringsFromStringLine(line.Substring(0, line.IndexOf('#')));
                            else
                                values = getSubStringsFromStringLine(line);

                            if (values.Length <= 0)
                                continue;

                            if (currentlyReadingATopic)
                            {
                                if (values[0] == "TOPIC")
                                {
                                    if (topic != null)
                                        infoDialog.itsTopics.Add(topic);

                                    topic = new DSA2InfoDialog.TOPIC();
                                    topic.NAME = values[1];
                                }
                                else if (values[0] == "END")
                                {
                                    if (topic != null)
                                        infoDialog.itsTopics.Add(topic);

                                    topic = null;
                                    break;
                                }
                                else if (values.Length == 3)
                                {
                                    DSA2InfoDialog.TOPIC.TOPICLine topicLine = new DSA2InfoDialog.TOPIC.TOPICLine();
                                    topicLine.value_1 = Convert.ToInt32(values[0]);
                                    topicLine.valie_2 = Convert.ToInt32(values[1]);
                                    topicLine.text = values[2];

                                    topic.itsTopics.Add(topicLine);
                                }
                                else if (values.Length == 1)
                                {
                                    topic.itsTopics[topic.itsTopics.Count - 1].text += Environment.NewLine + values[0];
                                }
                                else
                                {
                                    CDebugger.addErrorLine("Fehler beim laden des Dialogs " + TLK.filename + " (Unerwarteter Zustand beim lesen eines TOPICS)");
                                    break;
                                }
                            }
                            else
                            {
                                if (values[0] == "PIC")
                                {
                                    infoDialog.PIC = Convert.ToInt32(values[1]);
                                }
                                else if (values[0] == "TOLERANCE")
                                {
                                    infoDialog.TOLERANCE = Convert.ToInt32(values[1]);
                                }
                                else if (values[0] == "NAME")
                                {
                                    infoDialog.Name = values[1];
                                }
                                else if (values[0] == "TOPIC")
                                {
                                    currentlyReadingATopic = true;
                                    if (topic != null)
                                        infoDialog.itsTopics.Add(topic);

                                    topic = new DSA2InfoDialog.TOPIC();
                                    topic.NAME = values[1];
                                }
                                else
                                {
                                    CDebugger.addErrorLine("Fehler beim laden des Dialogs " + TLK.filename + " (Unbekannte Konstante " + values[0] + ")");
                                    continue;
                                }

                            }
                        }
                        if (topic != null)
                            infoDialog.itsTopics.Add(topic);

                        this.itsDSA2InfoDialog = infoDialog;
                    }
                }
                catch (SystemException e)
                {
                    CDebugger.addErrorLine("Fehler beim Laden des Dialogs " + TLK.filename + Environment.NewLine + e.ToString());
                }

                this.isDSA2InfoDialog = true;
            }

            static Regex regEx = new Regex("[A-Za-z0-9_äÄöÖüÜß]");
            private static string[] getSubStringsFromStringLine(string line)
            {
                List<string> subStrings = new List<string>(3);

                int start = 0;
                int length = 0;

                for (int position = 0; position < line.Length; position++)
                {
                    if (line[position] == '/')
                        position++; //zählt insgessamt 2 Zeichen weiter
                    else if (line[position] == '"' && line.Length > (position + 1))
                    {
                        position++;

                        start = position;
                        length = 0;

                        do
                        {
                            position++;
                            length++;
                        }
                        while (position < line.Length && line[position] != '"');

                        subStrings.Add(line.Substring(start, length));
                    }
                    else if (regEx.IsMatch(line[position].ToString()))
                    {
                        start = position;
                        length = 0;
                        do
                        {
                            position++;
                            length++;
                        }
                        while (position < line.Length && regEx.IsMatch(line[position].ToString()));

                        subStrings.Add(line.Substring(start, length));
                    }
                }

                return subStrings.ToArray();
            }
        }

        public class DSA2InfoDialog
        {
            public int PIC = 0;
            public int TOLERANCE = 0;
            public string Name = String.Empty;

            public List<TOPIC> itsTopics = new List<TOPIC>();

            public class TOPIC
            {
                public string NAME = String.Empty;
                public List<TOPICLine> itsTopics = new List<TOPICLine>();

                public class TOPICLine
                {
                    public int value_1 = 0;
                    public int valie_2 = 0;
                    public string text = String.Empty;
                }
            }
        }

        public class CGesprächspartner
        {
            //DSA 1
            public UInt16 offsetStartLayoutZeile = 0;
            public UInt16 offsetStartString = 0;
            public string name = "";
            public UInt16 BildID_IN_HEADS_NVF = 0;

            //---------------------------------
            //DSA 2
            public byte[] DSA2_unknownBytes = new Byte[] { 0, 0, 0, 0 };
            public Int16 DSA2_IndexToText = 0;
            public Int16 DSA2_IndexToName = 0;
            public Int16 DSA2_PictureID = 0;
            public Int16 DSA2_Unknown = 0;

            //---------------------------------
            public CGesprächspartner(ref byte[] data, Int32 position, DSAVersion version)
            {
                switch (version)
                {
                    case DSAVersion.Blade:
                    case DSAVersion.Schick:
                        this.loadDSA1(ref data, position);
                        break;

                    case DSAVersion.Schweif:
                        this.loadDSA2(ref data, position);
                        break;
                }
            }

            private void loadDSA1(ref byte[] data, Int32 position)
            {
                this.offsetStartLayoutZeile = (UInt16)(CHelpFunctions.byteArrayToInt32(ref data, position) / 8);
                position += 4;
                this.offsetStartString = (UInt16)CHelpFunctions.byteArrayToInt16(ref data, position);
                position += 2;
                this.name = CHelpFunctions.readDSAString(ref data, position, 30);
                position += 30;
                this.BildID_IN_HEADS_NVF = (UInt16)CHelpFunctions.byteArrayToInt16(ref data, position);
            }
            private void loadDSA2(ref byte[] data, Int32 position)
            {
                if ((position + 12) > data.Length)
                    return;

                this.DSA2_unknownBytes[0] = data[position];
                this.DSA2_unknownBytes[1] = data[position + 1];
                this.DSA2_unknownBytes[2] = data[position + 2];
                this.DSA2_unknownBytes[3] = data[position + 3];

                this.DSA2_IndexToText = CHelpFunctions.byteArrayToInt16(ref data, position + 4);
                this.DSA2_IndexToName = CHelpFunctions.byteArrayToInt16(ref data, position + 6);
                this.DSA2_PictureID = CHelpFunctions.byteArrayToInt16(ref data, position + 8);
                this.DSA2_Unknown = CHelpFunctions.byteArrayToInt16(ref data, position + 10);
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

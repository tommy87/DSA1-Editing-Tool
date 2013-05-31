﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

namespace DSA_1_Editing_Tool.File_Loader
{
    public class CItemList
    {
        public List<CItem> itsItems = new List<CItem>();
        public List<string> itsItemNames = new List<string>();

        public void addItems(ref byte[] data, CDSAFileLoader.CFileSet items_dat, CDSAFileLoader.CFileSet itemname, DSAVersion version)
        {
            if (data == null)
                return;

            if (items_dat != null)
            {
                //blocklänge 12Bytes
                Int32 blockLength = 12;
                if (version == DSAVersion.Schweif)
                    blockLength = 14;

                Int32 position = items_dat.startOffset;
                while ((position + blockLength) < items_dat.endOffset)
                {
                    itsItems.Add(new CItem(ref data, position, version));
                    position += blockLength;
                }
                CDebugger.addDebugLine("Items: ITEM.DAT wurde erfolgreich extrahiert");
            }
            else
                CDebugger.addDebugLine("Items: ITEM.DAT konnte nicht extrahiert werden");

            if (itemname != null)
            {
                // alle Texte der Datei auslesen
                Int32 position = itemname.startOffset;

                string text = CHelpFunctions.readDSAString(ref data, ref position, 0, itemname.endOffset);
                itsItemNames.Add(text);
                position++;

                while (position < itemname.endOffset)
                {
                    text = CHelpFunctions.readDSAString(ref data, ref position, 0, itemname.endOffset);
                    itsItemNames.Add(text);
                    position++;
                }
                CDebugger.addDebugLine("Items: ITEMNAME wurde erfolgreich extrahiert");
            }
            else
                CDebugger.addDebugLine("Items: ITEMNAME konnte nicht extrahiert werden");
        }
        public void clear()
        {
            this.itsItemNames.Clear();
            this.itsItems.Clear();
        }

        public string getItemNameByID(Int16 ID)
        {
            if (ID < this.itsItemNames.Count)
                return this.itsItemNames[ID];

            return "???";
        }

        //////////////////
        //  XML export  //
        //////////////////
        
        public void exportTextXML(XmlTextWriter wr)
        {
            for (int i = 0; i < itsItems.Count; i++)
            {
                string name = itsItemNames[i];
                string basename = name.Substring(0, name.IndexOf("."));
                string singularname = basename + name.Substring(basename.Length + 1, name.LastIndexOf(".") - basename.Length - 1);
                string pluralname = basename + name.Substring(name.LastIndexOf(".")+1);

                wr.WriteStartElement("text");
                wr.WriteAttributeString("key", "item_"+ i.ToString()+"_sin");
                wr.WriteCData(singularname);
                wr.WriteEndElement();
                wr.WriteStartElement("text");
                wr.WriteAttributeString("key", "item_"+i.ToString()+"_plu");
                wr.WriteCData(pluralname);
                wr.WriteEndElement();
            }
        }
        public void exportXML(string filename)
        {
            XmlTextWriter wr = new XmlTextWriter(filename, Encoding.UTF8);
            wr.WriteStartDocument();
            wr.WriteStartElement("items");

            for (int i = 0; i < itsItems.Count; i++)
            {
                itsItems[i].writeXML(wr,i, itsItemNames[i]);
                // writeItem(wr, i, itsItems[i], itsItemNames[i]);
            }

            wr.WriteEndElement();
            wr.WriteEndDocument();
            wr.Close();
        }

        //--------------------------------------

        public class CItem
        {
            public Int16 IconID = 0;
            public byte ItemTyp = 0;
            public byte AnziehbarAnPosition = 0;
            public Int16 Gewicht = 0;
            public byte Preis_Grundeinheit = 0;
            public Int16 Preis = 0;
            public byte SortimentsID = 0;
            public byte Magisch = 0;

            public byte erweiterterTyp = 0;
            public byte unbekannt_2_DSA2 = 0;

            public CItem(ref byte[] data, int position, DSAVersion version)
            {
                switch (version)
                {
                    case DSAVersion.Blade:
                    case DSAVersion.Schick:
                        this.IconID = CHelpFunctions.byteArrayToInt16(ref data, position);
                        this.ItemTyp = data[position + 2];
                        this.AnziehbarAnPosition = data[position + 3];
                        this.Gewicht = CHelpFunctions.byteArrayToInt16(ref data, position + 5);
                        this.Preis_Grundeinheit = data[position + 7];
                        this.Preis = CHelpFunctions.byteArrayToInt16(ref data, position + 8);
                        this.SortimentsID = data[position + 10];
                        this.Magisch = data[position + 11];
                        break;

                    case DSAVersion.Schweif:
                        this.IconID = CHelpFunctions.byteArrayToInt16(ref data, position);
                        this.ItemTyp = data[position + 2];

                        //position 3 + 5 sind noch unbekannt
                        this.erweiterterTyp = data[position + 3];

                        this.AnziehbarAnPosition = data[position + 4];
                        
                        this.unbekannt_2_DSA2 = data[position + 5];

                        this.Gewicht = CHelpFunctions.byteArrayToInt16(ref data, position + 6);
                        this.Preis = CHelpFunctions.byteArrayToInt16(ref data, position + 8);                        
                        this.Preis_Grundeinheit = data[position + 10];
                        this.SortimentsID = data[position + 11];

                        this.Magisch = data[position + 12];
                        break;
                }
            }

            public void writeXML(XmlTextWriter wr, int origid, string name)
            {
                wr.WriteStartElement("item");

                string singlename = name.Substring(0, name.IndexOf("."));
                singlename += name.Substring(singlename.Length + 1, name.LastIndexOf(".") - singlename.Length - 1);

                wr.WriteAttributeString("origid", origid.ToString());
                wr.WriteAttributeString("origname", name);
                wr.WriteAttributeString("image", singlename.ToLower());
                wr.WriteAttributeString("value", (Preis * Preis_Grundeinheit).ToString());
                wr.WriteAttributeString("weight", Gewicht.ToString());
                string slot = "";
                if ((ItemTyp & 0x01) != 0)
                {
                    switch (this.AnziehbarAnPosition)
                    {
                        case 0: slot = "head"; break;
                        case 1: slot = "upperarm"; break;
                        case 2: slot = "chest"; break;
                        case 5: slot = "leg"; break;
                        case 6: slot = "shoe"; break;
                        case 9: slot = "shield"; break;
                        default: slot = "--tbd"; break;
                    }
                }
                if ((ItemTyp & 0x02) != 0)
                {
                    string skill = "";
                    slot = "weapon";
                    switch (this.AnziehbarAnPosition)
                    {
                        case 0: slot = "shield"; break;
                        case 1: skill = "hiebwaffen"; break;
                        case 2: skill = "stichwaffen"; break;
                        case 3: skill = "schwerter"; break;
                        case 4: skill = "aexte"; break;
                        case 5: skill = "speere"; break;
                        case 6: skill = "zweihaender"; break;
                        case 7: skill = "schusswaffen"; break;
                        case 8: skill = "wurfwaffen"; break;
                    }
                    if (skill != "")
                        wr.WriteAttributeString("skill", skill);
                }

                // & 0x04 Benutzbar ergibt sich aus den Effekten
                // & 0x08 Essbar ergibt sich aus den Effekten
                // & 0x10 Trank/Gift/Kraut ergibt sich aus den Effekten
                if ((ItemTyp & 0x20) != 0)
                    wr.WriteAttributeString("stackable", "1");

                if ((ItemTyp & 0x40) != 0)
                    wr.WriteAttributeString("personal", "1");

                if ((ItemTyp & 0x80) != 0)
                    wr.WriteAttributeString("unusable", "1");

                if (Magisch > 0)
                    wr.WriteAttributeString("magical", "1");

                if (slot != "")
                    wr.WriteAttributeString("slot", slot);

                wr.WriteEndElement();
            }

            public string AnziehbarAnPositionToString(DSAVersion version)
            {
                switch (version)
                {
                    case DSAVersion.Blade:
                    case DSAVersion.Schick:
                        if ((this.ItemTyp & 0x01) != 0)
                        {
                            switch (this.AnziehbarAnPosition)
                            {
                                case 0:
                                    return ("Kopf(" + AnziehbarAnPosition.ToString() + ")");
                                case 1:
                                    return ("Arme(" + AnziehbarAnPosition.ToString() + ")");
                                case 2:
                                    return ("Brust(" + AnziehbarAnPosition.ToString() + ")");
                                case 5:
                                    return ("Beine(" + AnziehbarAnPosition.ToString() + ")");
                                case 6:
                                    return ("Schuhe(" + AnziehbarAnPosition.ToString() + ")");
                                case 9:
                                    return ("Schildhand(" + AnziehbarAnPosition.ToString() + ")");
                            }
                        }
                        else if ((this.ItemTyp & 0x02) != 0)
                        {
                            switch (this.AnziehbarAnPosition)
                            {
                                case 0:
                                    return ("Waffenlos(Pfeile|Bolzen)(" + AnziehbarAnPosition.ToString() + ")");
                                case 1:
                                    return ("Hiebwaffe(" + AnziehbarAnPosition.ToString() + ")");
                                case 2:
                                    return ("Stichwaffe(" + AnziehbarAnPosition.ToString() + ")");
                                case 3:
                                    return ("Schwerter(" + AnziehbarAnPosition.ToString() + ")");
                                case 4:
                                    return ("Äxte(" + AnziehbarAnPosition.ToString() + ")");
                                case 5:
                                    return ("Speere(" + AnziehbarAnPosition.ToString() + ")");
                                case 6:
                                    return ("Zweihänder(" + AnziehbarAnPosition.ToString() + ")");
                                case 7:
                                    return ("Schusswaffe(" + AnziehbarAnPosition.ToString() + ")");
                                case 8:
                                    return ("Wurfwaffe(" + AnziehbarAnPosition.ToString() + ")");
                            }
                        }
                        else if (AnziehbarAnPosition == 0)
                            return ("Gegenstand(" + AnziehbarAnPosition.ToString() + ")");
                            
                        break;

                    //-------------------------------------------------------------
                    case DSAVersion.Schweif:
                        if ((this.ItemTyp & 0x01) != 0)
                        {
                            switch (this.AnziehbarAnPosition)
                            {
                                case 0:
                                    return ("Kopf(" + AnziehbarAnPosition.ToString() + ")");
                                case 1:
                                    return ("Arme(" + AnziehbarAnPosition.ToString() + ")");
                                //case 2:
                                //    return ("Brust(" + AnziehbarAnPosition.ToString() + ")");
                                case 5:
                                    return ("Beine(" + AnziehbarAnPosition.ToString() + ")");
                                //case 6:
                                //    return ("Schuhe(" + AnziehbarAnPosition.ToString() + ")");
                                case 9:
                                    return ("Schildhand(" + AnziehbarAnPosition.ToString() + ")");
                                case 10:
                                    return ("Brust(" + AnziehbarAnPosition.ToString() + ")");
                                case 14:
                                    return ("Schuhe(" + AnziehbarAnPosition.ToString() + ")");
                            }
                        }
                        else if ((this.ItemTyp & 0x02) != 0)
                        {
                            switch (this.AnziehbarAnPosition)
                            {
                                case 0:
                                    return ("Waffenlos(Pfeile|Bolzen)(" + AnziehbarAnPosition.ToString() + ")");
                                case 1:
                                    return ("Hiebwaffe(" + AnziehbarAnPosition.ToString() + ")");
                                case 2:
                                    return ("Stichwaffe(" + AnziehbarAnPosition.ToString() + ")");
                                case 3:
                                    return ("Schwerter(" + AnziehbarAnPosition.ToString() + ")");
                                case 4:
                                    return ("Äxte(" + AnziehbarAnPosition.ToString() + ")");
                                case 5:
                                    return ("Speere(" + AnziehbarAnPosition.ToString() + ")");
                                case 6:
                                    return ("Zweihänder(" + AnziehbarAnPosition.ToString() + ")");
                                case 7:
                                    return ("Schusswaffe(" + AnziehbarAnPosition.ToString() + ")");
                                case 8:
                                    return ("Wurfwaffe(" + AnziehbarAnPosition.ToString() + ")");
                            }
                        }
                        else if ((this.ItemTyp & 0x08) != 0)
                        {
                            switch (this.AnziehbarAnPosition)
                            {
                                case 0:
                                    return ("Trinken(" + AnziehbarAnPosition.ToString() + ")");
                                case 1:
                                    return ("Essen(" + AnziehbarAnPosition.ToString() + ")");
                            }
                        }
                        else if ((this.ItemTyp & 0x20) != 0)
                        {
                            switch (this.AnziehbarAnPosition)
                            {
                                case 0:
                                    return ("Kräuter(" + AnziehbarAnPosition.ToString() + ")");
                                case 1:
                                    return ("Trank(" + AnziehbarAnPosition.ToString() + ")");
                            }
                        }
                        else if (AnziehbarAnPosition == 0)
                            return ("Gegenstand(" + AnziehbarAnPosition.ToString() + ")");

                        break;
                }

                return ("???(" + AnziehbarAnPosition.ToString() + ")");
            }
            public string Preis_GrundeinheitToString()
            {
                switch (this.Preis_Grundeinheit)
                {
                    case 1:
                        return "Heller(1)";
                    case 10:
                        return "Silberlinge(10)";
                    case 100:
                        return "Dukaten(100)";
                }

                return ("???(" + Preis_Grundeinheit.ToString() + ")");
            }
            public string MagischToString()
            {
                switch (this.Magisch)
                {
                    case 0:
                        return "-";
                    case 1:
                        return "magisch";
                }

                return ("???(" + Magisch.ToString() + ")");
            }
            public string PreisToString()
            {
                int geld = this.Preis * this.Preis_Grundeinheit;

                int Heller = geld % 10;
                int Silberlinge = (geld / 10) % 10;
                int Dukaten = geld / 100;

                return (Dukaten.ToString() + "D " + Silberlinge.ToString() + "S " + Heller.ToString() + "H (" + this.Preis.ToString() + ")");
            }
        }
    }
}

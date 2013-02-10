using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace DSA_1_Editing_Tool.File_Loader
{
    public class CStädte
    {
        public List<KeyValuePair<string, CTown>> itsTowns = new List<KeyValuePair<string, CTown>>();

        public CStädte()
        {
        }

        public void addStädte(ref byte[] data, List<CDSAFileLoader.CFileSet> towns)
        {
            if (data == null)
                return;

            if (towns.Count == 0)
                CDebugger.addDebugLine("Städte: keine Städte Dateien gefunden");
            else
                CDebugger.addDebugLine("Städte: es wurden " + towns.Count.ToString() + " Städte gefunden");

            foreach (CDSAFileLoader.CFileSet fileSet in towns)
                this.itsTowns.Add(new KeyValuePair<string, CTown>(fileSet.filename, new CTown(ref data, fileSet)));
                
        }
        public void clear()
        {
            this.itsTowns.Clear();
        }

        public void exportStädteXML(string dir)
        {
            foreach (KeyValuePair<string, CTown> ct in itsTowns)
            {
                string name = ct.Key.Substring(0, ct.Key.Length - 4).ToLower();
                ct.Value.exportXML(dir + "\\" + name + ".xml", name);
            }
        }

        public class CTown
        {
            public int townLängeWO = 0;
            public int townLängeSN = 0; //läuft von Süden nach Norden
            public byte[,] townData = null;

            public List<CTownEvent> townEvents = new List<CTownEvent>();

            public CTown(ref byte[] data, CDSAFileLoader.CFileSet town)
            {
                this.townEvents.Clear();

                //schauen ob es eine große oder kleine Stadt ist
                bool BigCity = false;
                for (int i = town.startOffset + 256; i < (town.startOffset + 256 + 64); i += 4)	//64 leere Bytes
                {
                    if (data[i] != 0x00 && data[i] != 0xFF ||
                        data[i + 1] != 0x00 && data[i + 1] != 0xFF ||
                        data[i + 2] != 0x00 || data[i + 3] != 0x00)
                    {
                        BigCity = true;
                        break;
                    }
                }

                if (BigCity)
                {
                    this.townLängeWO = 32;
                    this.townLängeSN = 16;
                    this.townData = new byte[32, 16];
                }
                else
                {
                    this.townLängeWO = 16;
                    this.townLängeSN = 16;
                    this.townData = new byte[16, 16];
                }

                //Werte auslesen
                int position = town.startOffset;
                for (int y = 0; y < this.townLängeSN; y++)
                {
                    for (int x = 0; x < this.townLängeWO; x++)
                    {
                        this.townData[x, y] = data[position];
                        position++;
                    }
                }

                //bestimmen des offsets für die stadtevents
                if (BigCity)
                    position = town.startOffset + 576;
                else
                    position = town.startOffset + 320;

                Int32 blockLength = 6;

                while ((position + blockLength) < town.endOffset)
                {
                    this.townEvents.Add(new CTownEvent(ref data, position));
                    position += blockLength;
                }
            }

            public string TownByteToString(int x, int y)
            {
                try
                {
                    byte value = (byte)((this.townData[x, y] & 0xF0) >> 4);
                    switch (value)
                    {
                        case 0: return "Straße(" + value.ToString() + ")";
                        case 1: return "Tempel(" + value.ToString() + ")";
                        case 2: return "Haus 1a (" + value.ToString() + ")";
                        case 3: return "Haus 1b (" + value.ToString() + ")";
                        case 4: return "Haus 2a(" + value.ToString() + ")";
                        case 5: return "Haus 2b(" + value.ToString() + ")";
                        case 6: return "Haus 3a(" + value.ToString() + ")";
                        case 7: return "Haus 3b(" + value.ToString() + ")";
                        case 8: return "Haus 3c(" + value.ToString() + ")";
                        case 9: return "Haus 3d(" + value.ToString() + ")";
                        case 10: return "Wasser(" + value.ToString() + ")";
                        case 11: return "Gras(" + value.ToString() + ")";
                        case 12: return "Wegweiser(" + value.ToString() + ")";
                        case 13: return "Leuchtturm (dunkel)(" + value.ToString() + ")";
                        case 14: return "Leuchtturm (hell)(" + value.ToString() + ")";
                        case 15:
                            return "Straße/Unsichtbare Wand???(" + value.ToString() + ")";

                        default:
                            return "Fehler(";
                    }
                }
                catch (SystemException)
                {
                    return "Fehler";
                }
            }

            private CTownEvent getEventAtPos(int x, int y)
            {
                foreach (CTownEvent evt in townEvents)
                {
                    if (evt.Position_X == x && evt.Position_Y == y)
                        return evt;
                }
                return null;
            }

            public void exportXML(string filename, string intname)
            {
                XmlTextWriter wr = new XmlTextWriter(filename, Encoding.UTF8);
                wr.WriteStartDocument();
                wr.WriteStartElement("town");
                wr.WriteAttributeString("intname", intname);

                wr.WriteStartElement("buildings");

                float squarebld = 9f;

                List<int> rowBld = new List<int>(townLängeSN);
                List<int> colBld = new List<int>(townLängeWO);

                for (int i = 0; i < townLängeWO; i++) { colBld.Add(0); }
                for (int i = 0; i < townLängeSN; i++) { rowBld.Add(0); }
                Random r = new Random();

                for (int y = 0; y < townLängeSN; y++)
                {
                    for (int x = 0; x < townLängeWO; x++)
                    {
                        byte value = (byte)((this.townData[x, y] & 0xF0) >> 4);
                        byte align = (byte)((this.townData[x, y] & 0x0F));
                        string tp = "";

                        /*float posx = rowBld[y] * squarebld + (y - rowBld[y]) * squareoth;
                        float posy = colBld[x] * squarebld + (x - colBld[x]) * squareoth;*/
                        float posx = x * squarebld - (squarebld / 2);
                        float posy = (townLängeSN - y) * squarebld - squarebld * townLängeSN - (squarebld / 2);
                        CTownEvent evt = getEventAtPos(x, y);

                        if (((value == 0) || (value == 10) || (value == 11)) && evt == null)
                        {
                            switch (value)
                            {
                                case 0: tp = "road"; break;
                                case 10: tp = "water"; break;
                            }
                            if (tp != "")
                            {
                                wr.WriteStartElement("prop");
                                wr.WriteAttributeString("type", tp);
                            }
                            else
                            {
                                // don't export grass props
                                continue;
                            }
                        }
                        else
                        {
                            wr.WriteStartElement("building");
                            colBld[x]++;
                            rowBld[y]++;

                            string trigger = "";
                            switch (value)
                            {
                                case 1: tp = "tempel"; break;
                                case 2:
                                case 3:
                                case 4:
                                case 5:
                                case 6:
                                case 7:
                                case 8:
                                case 9: tp = "house_1"; break;
                                case 12: tp = "wegweiser"; break;     //wegweiser
                                case 13: tp = "house_1"; trigger = "questnpc"; break;
                                case 14: tp = "schwarzerfinger"; break;
                                case 15: tp = "schwarzerfinger"; trigger = "hell"; break;
                            }

                            if (evt != null)
                            {
                                switch (evt.Typ)
                                {
                                    case 2: trigger = "tempel"; break;
                                    case 3: trigger = "taverne"; break;
                                    case 4: tp = "heiler"; break;
                                    case 5: tp = "handel_gemischt"; trigger = "handel"; break;
                                    case 6: trigger = "wildnislager"; break;
                                    case 7: tp = "herberge_1"; break;
                                    case 8: tp = "schmiede"; break;
                                    case 9: tp = "marktplatz"; break;
                                    case 10: trigger = "10_normales_haus"; break;
                                    case 11: tp = "windmuehle"; trigger = "hafen"; break;
                                    case 12: tp = "wegweiser"; break;
                                    case 13: trigger = "quest"; break;
                                    case 14: tp = "zwingfeste"; trigger = "dungeon"; break;
                                    case 16: trigger = "16_leeres_haus"; break;
                                    case 17: if (value == 4) { tp = "herberge_2"; trigger = "tav+her"; } else { trigger = "special"; } break;
                                    case 18: trigger = "18_dings"; break;
                                }

                                wr.WriteAttributeString("typ", evt.Typ.ToString());
                                wr.WriteAttributeString("ut1", evt.Untertyp_1_Name_Icons_Angebot.ToString());
                                wr.WriteAttributeString("ut2", evt.Untertyp_2_unbekannte_Parameter.ToString());
                                wr.WriteAttributeString("ut3", evt.Untertyp_3_Reisen.ToString());
                            }

                            if (tp == "house_1")
                            {
                                tp = "house_" + (r.Next(3) + 1).ToString();
                            }

                            if (tp == "taverne" && (r.Next(2) == 1))
                            {
                                tp = "taverne_2";
                            }

                            wr.WriteAttributeString("type", tp);
                            if (trigger != "")
                                wr.WriteAttributeString("trigger", trigger);

                            wr.WriteAttributeString("align", align.ToString());
                        }

                        wr.WriteAttributeString("x", posx.ToString().Replace(",", "."));
                        wr.WriteAttributeString("y", posy.ToString().Replace(",", "."));
                        wr.WriteEndElement();
                    }
                }

                wr.WriteEndElement();
                wr.WriteEndElement();
                wr.WriteEndDocument();
                wr.Close();
            }
        }
        public class CTownEvent
        {
            public byte Position_Y = 0;
            public byte Position_X = 0;
            public byte Typ = 0;
            public byte Untertyp_1_Name_Icons_Angebot = 0;
            public byte Untertyp_2_unbekannte_Parameter = 0;
            public byte Untertyp_3_Reisen = 0;

            public CTownEvent(ref byte[] data, int offset)
            {
                if (data.Length < (offset + 6))
                    return;

                this.Position_Y = data[offset];
                this.Position_X = data[offset + 1];
                this.Typ = data[offset + 2];
                this.Untertyp_1_Name_Icons_Angebot = data[offset + 3];
                this.Untertyp_2_unbekannte_Parameter = data[offset + 4];
                this.Untertyp_3_Reisen = data[offset + 5];
            }

            public string EventTypToString()
            {
                switch (this.Typ)
                {
                    case 2:
                        return ("Tempel (" + this.Typ.ToString() + ")");
                    case 3:
                        return ("Taverne (" + this.Typ.ToString() + ")");
                    case 4:
                        return ("Heiler (" + this.Typ.ToString() + ")");
                    case 5:
                        return ("Geschäft (" + this.Typ.ToString() + ")");
                    case 6:
                        return ("Wildnislager (" + this.Typ.ToString() + ")");
                    case 7:
                        return ("Herberge (" + this.Typ.ToString() + ")");
                    case 8:
                        return ("Schmied (" + this.Typ.ToString() + ")");
                    case 9:
                        return ("Markt (" + this.Typ.ToString() + ")");
                    case 10:
                        return ("normales Haus? (" + this.Typ.ToString() + ")");
                    case 11:
                        return ("Hafen (" + this.Typ.ToString() + ")");
                    case 12:
                        return ("Wegweiser (" + this.Typ.ToString() + ")");
                    case 13:
                        return ("QuestNPC? (" + this.Typ.ToString() + ")");
                    case 14:
                        return ("Dungeon (" + this.Typ.ToString() + ")");
                    case 16:
                        return ("Haus zum einbrechen? (" + this.Typ.ToString() + ")");
                    case 17:
                        return ("Taverne UND Herberge (" + this.Typ.ToString() + ")");
                    case 18:
                        return ("Lager? (" + this.Typ.ToString() + ")");

                    default:
                        return ("??? (" + this.Typ.ToString() + ")");
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

namespace DSA_1_Editing_Tool.File_Loader
{
    public class CMonster
    {
        public List<CMonsterStats> itsMonsterStats = new List<CMonsterStats>();
        public List<string> itsMonsterNames = new List<string>();

        public void addMonsters(ref byte[] data, CDSAFileLoader.CFileSet monster_dat, CDSAFileLoader.CFileSet monstername, DSAVersion version)
        {
            itsMonsterStats.Clear();

            if (data == null)
                return;

            if (monster_dat != null)
            {
                //blocklänge 44Bytes
                Int32 blockLength = 44;

                if (version == DSAVersion.Schweif)
                    blockLength = 48;

                Int32 position = monster_dat.startOffset;
                while ((position + blockLength) < monster_dat.endOffset)
                {
                    itsMonsterStats.Add(new CMonsterStats(ref data, position, version));
                    position += blockLength;
                }
                CDebugger.addDebugLine("Monster: MONSTER.DAT wurde erfolgreich extrahiert");
            }
            else
                CDebugger.addDebugLine("Monster: MONSTER.DAT konnte nicht extrahiert werden");


            if (monstername != null)
            {
                itsMonsterNames.Clear();

                // alle Texte der Datei auslesen
                Int32 position = monstername.startOffset;

                string text = CHelpFunctions.readDSAString(ref data, ref position, 0, monstername.endOffset);
                itsMonsterNames.Add(text);
                position++;

                while ((position) < monstername.endOffset)
                {
                    text = CHelpFunctions.readDSAString(ref data, ref position, 0, monstername.endOffset);
                    itsMonsterNames.Add(text);
                    position++;
                }
                CDebugger.addDebugLine("Monster: MONSTERNAME wurde erfolgreich extrahiert");
            }
            else
                CDebugger.addDebugLine("Monster: MONSTERNAME konnte nicht extrahiert werden");
        }
        public void clear()
        {
            this.itsMonsterNames.Clear();
            this.itsMonsterStats.Clear();
        }

        public string getMonsterNameByID(Int16 ID)
        {
            for (int i = 0; i < this.itsMonsterStats.Count; i++)
            {
                if (this.itsMonsterStats[i].MonsterID == ID)
                {
                    if (i < this.itsMonsterNames.Count)
                        return this.itsMonsterNames[i];
                }
            }

            return "unknown";
        }
        public void exportMonsterXML(string filename)
        {
            XmlTextWriter wr = new XmlTextWriter(filename, Encoding.UTF8);
            wr.WriteStartDocument();
            wr.WriteStartElement("monsters");

            for (int i = 1; i < this.itsMonsterStats.Count; i++)
            {
                this.itsMonsterStats[i].writeXML(wr, this.itsMonsterNames[i]);
            }
            wr.WriteEndElement();
            wr.WriteEndDocument();
            wr.Close();
        }

        public class CMonsterStats
        {
            public byte MonsterID = 0;
            public byte MonsterGraphicID = 0;

            public sbyte RS = 0;

            public Byte[] MU_Würfel = { 0, 0 };
            public Byte[] KL_Würfel = { 0, 0 };
            public Byte[] CH_Würfel = { 0, 0 };
            public Byte[] FF_Würfel = { 0, 0 };
            public Byte[] GE_Würfel = { 0, 0 };
            public Byte[] IN_Würfel = { 0, 0 };
            public Byte[] KK_Würfel = { 0, 0 };

            public Byte[] LE_Würfel = { 0, 0 };    //das Ergebnis wird durch 6 geteilt und mit 5 multipliziert (war eine Last minute änderung der Entwickler)
            public Byte[] AE_Würfel = { 0, 0 };

            public Byte[] MR_Würfel = { 0, 0 };

            public byte erstAP = 0;
            public byte Anzahl_Attacken = 0;
            public sbyte AT = 0;
            public sbyte PA = 0;

            public Byte[] Schaden_1_Angriff_Würfel = { 0, 0 };
            public Byte[] Schaden_2_Angriff_Würfel = { 0, 0 };

            public byte BP = 0;

            public byte Immunität_gegen_Normale_Waffen = 0;
            public sbyte ID_Magierklasse = 0;
            public byte Stufe = 0;

            public byte Größenklasse = 0;
            public byte MonsterTyp = 0; //offenbar werden einzelne bits gesetzt

            public byte Anzahl_Geschosse = 0;
            public Byte[] Schaden_Schusswaffen_Würfel = { 0, 0 };
            public byte Anzahl_Wurfwaffen = 0;
            public Byte[] Schaden_Wurfwaffen_Würfel = { 0, 0 };

            public byte Flucht_Bei_XX_LP = 0;

            public byte unbekannterWert_1_DSA_2 = 0;
            public byte unbekannterWert_2_DSA_2 = 0;
            public byte unbekannterWert_3_DSA_2 = 0;
            public byte unbekannterWert_4_DSA_2 = 0;

            public CMonsterStats(ref byte[] data, Int32 position, DSAVersion version)
            {
                switch (version)
                {
                    case DSAVersion.Blade:
                    case DSAVersion.Schick:
                        this.MonsterID = data[position];
                        this.MonsterGraphicID = data[position + 1];
                        this.RS = (sbyte)data[position + 2];

                        this.MU_Würfel[0] = data[position + 3]; this.MU_Würfel[1] = data[position + 4];
                        this.KL_Würfel[0] = data[position + 5]; this.KL_Würfel[1] = data[position + 6];
                        this.CH_Würfel[0] = data[position + 7]; this.CH_Würfel[1] = data[position + 8];
                        this.FF_Würfel[0] = data[position + 9]; this.FF_Würfel[1] = data[position + 10];
                        this.GE_Würfel[0] = data[position + 11]; this.GE_Würfel[1] = data[position + 12];
                        this.IN_Würfel[0] = data[position + 13]; this.IN_Würfel[1] = data[position + 14];
                        this.KK_Würfel[0] = data[position + 15]; this.KK_Würfel[1] = data[position + 16];
                        this.LE_Würfel[0] = data[position + 17]; this.LE_Würfel[1] = data[position + 18];
                        this.AE_Würfel[0] = data[position + 19]; this.AE_Würfel[1] = data[position + 20];

                        this.MR_Würfel[0] = data[position + 21]; this.MR_Würfel[1] = data[position + 22];
                        this.erstAP = data[position + 23];
                        this.Anzahl_Attacken = data[position + 24];

                        this.AT = (sbyte)data[position + 25];
                        this.PA = (sbyte)data[position + 26];

                        this.Schaden_1_Angriff_Würfel[0] = data[position + 27]; this.Schaden_1_Angriff_Würfel[1] = data[position + 28];
                        this.Schaden_2_Angriff_Würfel[0] = data[position + 29]; this.Schaden_2_Angriff_Würfel[1] = data[position + 30];

                        this.BP = data[position + 31];

                        this.Immunität_gegen_Normale_Waffen = data[position + 32];
                        this.ID_Magierklasse = (sbyte)data[position + 33];
                        this.Stufe = data[position + 34];

                        this.Größenklasse = data[position + 35];
                        this.MonsterTyp = data[position + 36];

                        this.Anzahl_Geschosse = data[position + 37];
                        this.Schaden_Schusswaffen_Würfel[0] = data[position + 38]; this.Schaden_Schusswaffen_Würfel[1] = data[position + 39];
                        this.Anzahl_Wurfwaffen = data[position + 40];
                        this.Schaden_Wurfwaffen_Würfel[0] = data[position + 41]; this.Schaden_Wurfwaffen_Würfel[1] = data[position + 42];

                        this.Flucht_Bei_XX_LP = data[position + 43];
                        break;

                    case DSAVersion.Schweif:
                        this.MonsterID = data[position];
                        this.MonsterGraphicID = data[position + 1];
                        this.RS = (sbyte)data[position + 2];

                        this.unbekannterWert_1_DSA_2 = data[position + 3];

                        this.MU_Würfel[0] = data[position + 4]; this.MU_Würfel[1] = data[position + 5];
                        this.KL_Würfel[0] = data[position + 6]; this.KL_Würfel[1] = data[position + 7];
                        this.CH_Würfel[0] = data[position + 8]; this.CH_Würfel[1] = data[position + 9];
                        this.FF_Würfel[0] = data[position + 10]; this.FF_Würfel[1] = data[position + 11];
                        this.GE_Würfel[0] = data[position + 12]; this.GE_Würfel[1] = data[position + 13];
                        this.IN_Würfel[0] = data[position + 14]; this.IN_Würfel[1] = data[position + 15];
                        this.KK_Würfel[0] = data[position + 16]; this.KK_Würfel[1] = data[position + 17];
                        this.LE_Würfel[0] = data[position + 18]; this.LE_Würfel[1] = data[position + 19];
                        this.AE_Würfel[0] = data[position + 20]; this.AE_Würfel[1] = data[position + 21];

                        this.MR_Würfel[0] = data[position + 22]; this.MR_Würfel[1] = data[position + 23];
                        this.erstAP = data[position + 24];
                        this.Anzahl_Attacken = data[position + 25];

                        this.AT = (sbyte)data[position + 26];
                        this.PA = (sbyte)data[position + 27];

                        this.Schaden_1_Angriff_Würfel[0] = data[position + 28]; this.Schaden_1_Angriff_Würfel[1] = data[position + 29];
                        this.Schaden_2_Angriff_Würfel[0] = data[position + 30]; this.Schaden_2_Angriff_Würfel[1] = data[position + 31];
                        
                        this.BP = data[position + 32];

                        this.Immunität_gegen_Normale_Waffen = data[position + 33];
                        this.ID_Magierklasse = (sbyte)data[position + 34];
                        this.Stufe = data[position + 35];

                        this.Größenklasse = data[position + 36];
                        this.MonsterTyp = data[position + 37];

                        this.unbekannterWert_2_DSA_2 = data[position + 38];
                        this.unbekannterWert_3_DSA_2 = data[position + 39];

                        //-------------------------------------------
                        this.Anzahl_Geschosse = data[position + 40];
                        this.Schaden_Schusswaffen_Würfel[0] = data[position + 41]; this.Schaden_Schusswaffen_Würfel[1] = data[position + 42];
                        this.Anzahl_Wurfwaffen = data[position + 43];
                        this.Schaden_Wurfwaffen_Würfel[0] = data[position + 44]; this.Schaden_Wurfwaffen_Würfel[1] = data[position + 45];

                        this.Flucht_Bei_XX_LP = data[position + 46];

                        this.unbekannterWert_4_DSA_2 = data[position + 47];

                        break;
                }
            }

            public string größenklasseToString()
            {
                switch (this.Größenklasse)
                {
                    case 2:
                        return ("Klein(" + this.Größenklasse.ToString() + ")");
                    case 3:
                        return ("Normal(" + this.Größenklasse.ToString() + ")");
                    case 4:
                        return ("Groß(" + this.Größenklasse.ToString() + ")");
                    case 5:
                        return ("Riesig(" + this.Größenklasse.ToString() + ")");
                    default:
                        return ("???(" + this.Größenklasse.ToString() + ")");
                }
            }
            public string monsterTypToString()
            {
                switch (this.MonsterTyp)
                {
                    case 0:
                        return ("Normal(" + this.MonsterTyp.ToString() + ")");
                    case 1:
                        return ("Tier(" + this.MonsterTyp.ToString() + ")");
                    default:
                        return ("???(" + this.MonsterTyp.ToString() + ")");
                }
            }
            public string immunitätGegenNormaleWaffenToString()
            {
                switch (this.Immunität_gegen_Normale_Waffen)
                {
                    case 0:
                        return ("keine(" + this.Immunität_gegen_Normale_Waffen.ToString() + ")");
                    case 1:
                        return ("Immun(" + this.Immunität_gegen_Normale_Waffen.ToString() + ")");
                    default:
                        return ("???(" + this.Immunität_gegen_Normale_Waffen.ToString() + ")");
                }
            }

            /**
             * schreibt das Monster in einen bereits initialisierten XMLTextWriter
             * @input       wr  XMLTextWriter       das Ziel
             */
            public void writeXML( XmlTextWriter wr , string name) {
                wr.WriteStartElement("monster");
                wr.WriteAttributeString("id", this.MonsterID.ToString());
                wr.WriteAttributeString("img", this.MonsterGraphicID.ToString());
                wr.WriteAttributeString("name", name);
                wr.WriteStartElement("base");
                    wr.WriteAttributeString("level", this.Stufe.ToString());
                    wr.WriteAttributeString("firstap", this.erstAP.ToString());
                    wr.WriteAttributeString("immunetomundane", this.Immunität_gegen_Normale_Waffen.ToString());
                    wr.WriteAttributeString("magicclassid", this.ID_Magierklasse.ToString());
                    wr.WriteAttributeString("size", this.Größenklasse.ToString());
                    wr.WriteAttributeString("type", this.MonsterTyp.ToString());

                    wr.WriteStartElement("battlebase");
                        wr.WriteAttributeString("RS", this.RS.ToString());
                        wr.WriteAttributeString("AT", this.AT.ToString());
                        wr.WriteAttributeString("PA", this.PA.ToString());
                        wr.WriteAttributeString("BP", this.BP.ToString());
                        this.writeXMLDice(wr, "MR", MR_Würfel);
                    wr.WriteEndElement();
                wr.WriteEndElement();

                wr.WriteStartElement("attributes");
                    this.writeXMLDice(wr, "LE", LE_Würfel);
                    this.writeXMLDice(wr, "AE", AE_Würfel);
                    this.writeXMLDice(wr, "MU", MU_Würfel);
                    this.writeXMLDice(wr, "KL", KL_Würfel);
                    this.writeXMLDice(wr, "CH", CH_Würfel);
                    this.writeXMLDice(wr, "FF", FF_Würfel);
                    this.writeXMLDice(wr, "GE", GE_Würfel);
                    this.writeXMLDice(wr, "IN", IN_Würfel);
                    this.writeXMLDice(wr, "KK", KK_Würfel);
                wr.WriteEndElement();

                wr.WriteStartElement("battle");
                    wr.WriteAttributeString("escape", this.Flucht_Bei_XX_LP.ToString());
                    wr.WriteAttributeString("numatk", this.Anzahl_Attacken.ToString());
                    wr.WriteAttributeString("numshot", this.Anzahl_Geschosse.ToString());
                    wr.WriteAttributeString("numthrow", this.Anzahl_Wurfwaffen.ToString());
                    writeXMLDice(wr, "dmgatk1", this.Schaden_1_Angriff_Würfel);
                    writeXMLDice(wr, "dmgatk2", this.Schaden_2_Angriff_Würfel);
                    writeXMLDice(wr, "dmgshot", this.Schaden_Schusswaffen_Würfel);
                    writeXMLDice(wr, "dmgthrow", this.Schaden_Wurfwaffen_Würfel);
                wr.WriteEndElement();
                wr.WriteEndElement();
            }
            private void writeXMLDice(XmlTextWriter wr, string elname, byte[] data)
            {
                wr.WriteStartElement(elname);
                wr.WriteAttributeString("mod", ((sbyte)data[0]).ToString());

                // Datenfehler korrigieren, 15W4 bedeuted gar kein Würfelwurf
                if (((data[1] & 0xF0) > 0) && ((data[1] & 0xF0) != 0xF0))
                {
                    wr.WriteAttributeString("diecnt", ((data[1] & 0xF0) >> 4).ToString());
                    int dietype = 4;
                    switch (data[1] & 0x0F)
                    {
                        case 1: dietype = 6; break;
                        case 2: dietype = 20; break;
                        case 3: dietype = 3; break;
                    }
                    wr.WriteAttributeString("dietype", dietype.ToString());
                }
                wr.WriteEndElement();
            }
        }
    }
}

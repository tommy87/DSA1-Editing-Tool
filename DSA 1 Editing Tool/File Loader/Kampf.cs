using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace DSA_1_Editing_Tool.File_Loader
{
    public class CKampf
    {
        public List<CFight_LST> itsFight_LST = new List<CFight_LST>();

        public CKampf()
        {
        }

        public void addKämpfe(ref byte[] data, CDSAFileLoader.CFileSet fight_lst)
        {
            this.itsFight_LST.Clear();

            if (data == null)
                return;

            if (fight_lst != null)
            {
                Int32 blockLength = 216;

                Int32 AnzahlEinträge = CHelpFunctions.byteArrayToInt16(ref data, 0);
                Int32 counter = 0;
                Int32 position = fight_lst.startOffset + 2;

                while (((position + blockLength) < fight_lst.endOffset) && (counter < AnzahlEinträge))
                {
                    this.itsFight_LST.Add(new CFight_LST(ref data, position));
                    position += blockLength;
                    counter++;
                }

                CDebugger.addDebugLine("Kampf: FIGHT.LST wurde erfolgreich extrahiert");
            }
            else
                CDebugger.addDebugLine("Kampf: FIGHT.LST konnte nicht extrahiert werden");
        }
        public void clear()
        {
            this.itsFight_LST.Clear();
        }
    }

    public class CFight_LST
    {
        public List<CFight_MonsterInfo> itsMonsterInfos = new List<CFight_MonsterInfo>();
        public CFight_SpielerInfo[] itsSpielerInfos = new CFight_SpielerInfo[7];
        public List<CFight_HinterlassenesItem> itsBeute = new List<CFight_HinterlassenesItem>();

        public string name = "";    //20 Bytes
        public Int16 nummerDesScenarios = 0;

        public Int16 Beute_Dukaten = 0;
        public Int16 Beute_Silberstücke = 0;
        public Int16 Beute_Heller = 0;

        public CFight_LST(ref byte[] data, Int32 position)
        {
            Int32 helper = position;
            this.name = CHelpFunctions.readDSAString(ref data, ref helper, 20);
            this.nummerDesScenarios = (Int16)(data[position + 20] + ((Int16)data[position + 21] << 8));

            Int32 helpPosition = position + 22;
            Int32 blockLength = 5;

            while ((data[helpPosition] != 0) && (helpPosition < (position + 121)))   //Monsterinfos gehen bis byte 121 (0x79)
            {
                this.itsMonsterInfos.Add(new CFight_MonsterInfo(ref data, helpPosition));
                helpPosition += blockLength;
            }

            helpPosition = position + 122;
            blockLength = 4;
            for (int i = 0; i < 7; i++)     //Spieleinfos gehen bis 149 (0x95)
            {
                this.itsSpielerInfos[i] = new CFight_SpielerInfo(ref data, helpPosition);
                helpPosition += blockLength;
            }

            helpPosition = position + 150;
            blockLength = 2;
            while ((data[helpPosition] != 0) && (helpPosition < (position + 210)))   //122(0x7A) bis 209(0xD1)
            {
                this.itsBeute.Add(new CFight_HinterlassenesItem(ref data, helpPosition));
                helpPosition += blockLength;
            }

            this.Beute_Dukaten = CHelpFunctions.byteArrayToInt16(ref data, position + 210);
            this.Beute_Silberstücke = CHelpFunctions.byteArrayToInt16(ref data, position + 212);
            this.Beute_Heller = CHelpFunctions.byteArrayToInt16(ref data, position + 214);
        }

        public void exportXML(XmlTextWriter wr)
        {
            wr.WriteStartElement("fightdata");
            wr.WriteAttributeString("id", nummerDesScenarios.ToString());
            wr.WriteAttributeString("name", name);

            wr.WriteStartElement("enemy");
            foreach (CFight_MonsterInfo m in itsMonsterInfos)
            {
                wr.WriteStartElement("monster");
                wr.WriteAttributeString("id", m.GegnerID.ToString());
                wr.WriteAttributeString("startin", m.Startrunde.ToString());
                wr.WriteEndElement();
            }
            wr.WriteEndElement();

            wr.WriteStartElement("loot");
            int lootmoney = Beute_Dukaten * 100 + Beute_Silberstücke * 10 + Beute_Heller;
            if (lootmoney > 0)
            {
                wr.WriteStartElement("item");
                wr.WriteAttributeString("id", "254");
                wr.WriteAttributeString("count", lootmoney.ToString());
                CDebugger.addDebugLine("Exporting money " + lootmoney.ToString());
            }
            foreach (CFight_HinterlassenesItem i in itsBeute)
            {
                wr.WriteStartElement("item");
                if( i.Menge > 0 )
                    wr.WriteAttributeString("count", i.Menge.ToString());
                wr.WriteAttributeString("id", i.ItemID.ToString());
                wr.WriteEndElement();
            }
            wr.WriteEndElement();
            wr.WriteEndElement();
        }

    }
    public class CFight_MonsterInfo
    {
        public byte GegnerID = 0;
        public byte Position_X = 0;
        public byte Position_Y = 0;
        public byte Blickrichtung = 0;
        public byte Startrunde = 0;

        public CFight_MonsterInfo(ref byte[] data, Int32 position)
        {
            this.GegnerID = data[position];
            this.Position_X = data[position + 1];
            this.Position_Y = data[position + 2];
            this.Blickrichtung = data[position + 3];
            this.Startrunde = data[position + 4];
        }
    }
    public class CFight_SpielerInfo
    {
        public byte Position_X = 0;
        public byte Position_Y = 0;
        public byte Blickrichtung = 0;
        public byte Startrunde = 0;

        public CFight_SpielerInfo(ref byte[] data, Int32 position)
        {
            this.Position_X = data[position];
            this.Position_Y = data[position + 1];
            this.Blickrichtung = data[position + 2];
            this.Startrunde = data[position + 3];
        }
    }
    public class CFight_HinterlassenesItem
    {
        public byte ItemID = 0;
        public byte Menge = 0;

        public CFight_HinterlassenesItem(ref byte[] data, Int32 position)
        {
            this.ItemID = data[position];
            this.Menge = data[position + 1];
        }
    }
}

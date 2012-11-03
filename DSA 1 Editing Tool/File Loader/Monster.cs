using System;
using System.Collections.Generic;
using System.Text;

using System.IO;

namespace DSA_1_Editing_Tool.File_Loader
{
    public class CMonster
    {
        public List<CMonsterStats> itsMonsterStats = new List<CMonsterStats>();
        public List<string> itsMonsterNames = new List<string>();

        public void loadMonster(ref byte[] data, CDSAFileLoader.CFileSet monster_dat, CDSAFileLoader.CFileSet monstername)
        {
            itsMonsterStats.Clear();

            if (data == null)
                return;

            if (monster_dat != null)
            {
                //blocklänge 44Bytes
                Int32 blockLength = 44;

                Int32 position = monster_dat.startOffset;
                while ((position + blockLength) < monster_dat.endOffset)
                {
                    itsMonsterStats.Add(new CMonsterStats(ref data, position));
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

                string text = CHelpFunctions.readDSAString(ref data, position, 0);
                itsMonsterNames.Add(text);
                position += (text.Length + 1);

                while ((position) < monstername.endOffset)
                {
                    text = CHelpFunctions.readDSAString(ref data, position, 0);
                    itsMonsterNames.Add(text);
                    position += (text.Length + 1);
                }
                CDebugger.addDebugLine("Monster: MONSTERNAME wurde erfolgreich extrahiert");
            }
            else
                CDebugger.addDebugLine("Monster: MONSTERNAME konnte nicht extrahiert werden");
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

            public Byte[] LE_Würfel = { 0, 0 };    //das Ergebnis wird durch 6 geteilt und mit 5 multipliziert
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
            public byte MonsterTyp = 0; //offenbar werden einzelme bits gesetzt

            public byte Anzahl_Geschosse = 0;
            public Byte[] Schaden_Schusswaffen_Würfel = { 0, 0 };
            public byte Anzahl_Wurfwaffen = 0;
            public Byte[] Schaden_Wurfwaffen_Würfel = { 0, 0 };

            public byte Flucht_Bei_XX_LP = 0;

            public CMonsterStats(ref byte[] data, Int32 position)
            {
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

                this.Flucht_Bei_XX_LP = data[position + 34];
            }
        }
    }
}

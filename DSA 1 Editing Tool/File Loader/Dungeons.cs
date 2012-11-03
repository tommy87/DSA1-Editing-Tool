using System;
using System.Collections.Generic;
using System.Text;

namespace DSA_1_Editing_Tool.File_Loader
{
    public class CDungeons
    {
        public List<KeyValuePair<string, CDungeon>> itsDungeons = new List<KeyValuePair<string, CDungeon>>();

        public CDungeons() { }
        public void loadDungeons(ref byte[] data, List<CDSAFileLoader.CFileSet> dungeons_DNG, List<CDSAFileLoader.CFileSet> dungeonEvents_DDT)
        {
            this.itsDungeons.Clear();

            if (data == null)
                return;

            if (dungeons_DNG.Count == 0)
                CDebugger.addDebugLine("Dungeons: keine Dungeon Dateien(.DNG) gefunden");
            else
                CDebugger.addDebugLine("Dungeons: es wurden " + dungeons_DNG.Count.ToString() + " Dungeons gefunden");

            foreach (CDSAFileLoader.CFileSet dungeon in dungeons_DNG)
            {
                bool found = false;
                string helpString = dungeon.filename.Substring(0, dungeon.filename.Length - 4) + ".DDT";
                foreach (CDSAFileLoader.CFileSet dungeonEvent in dungeonEvents_DDT)
                {
                    if (dungeonEvent.filename == helpString)
                    {
                        found = true;
                        this.itsDungeons.Add(new KeyValuePair<string, CDungeon>(dungeon.filename, new CDungeon(ref data, dungeon, dungeonEvent)));
                        break;
                    }
                }

                if (!found)
                {
                    this.itsDungeons.Add(new KeyValuePair<string, CDungeon>(dungeon.filename, new CDungeon(ref data, dungeon, null)));
                    CDebugger.addDebugLine("Fehler: zum Dungeon " + dungeon.filename + " wurde keine .DDT datei gefunden");
                }
            }
        }

        public class CDungeon
        {
            public List<CFloor> floors = new List<CFloor>();
            public List<CDungeonFight> fights = new List<CDungeonFight>();
            public List<CDungeonDoor> doors = new List<CDungeonDoor>();
            public List<CDungeonStair> stairs = new List<CDungeonStair>();

            public CDungeon(ref byte[] data, CDSAFileLoader.CFileSet dungeon, CDSAFileLoader.CFileSet dungeonEvent)
            {
                this.floors.Clear();
                this.fights.Clear();
                this.doors.Clear();
                this.stairs.Clear();

                Int32 position = dungeon.startOffset;
                Int32 blockLength = 16*20;

                while ((position + blockLength) <= dungeon.endOffset)
                {
                    this.floors.Add(new CFloor(ref data, position));
                    position += blockLength;
                }

                //-------------Kämpfe-------
                position = dungeonEvent.startOffset + 4;
                blockLength = 14;

                while ((position + blockLength) <= dungeonEvent.endOffset)
                {
                    //auf ende Prüfen
                    if ((data[position] == 0xFF) && (data[position + 1] == 0xFF))
                    {
                        bool end = true;
                        for (int i = position + 2; i < (position + blockLength); i++)
                        {
                            if (data[i] != 0)
                                end = false;
                        }

                        if (end)
                        {
                            position += blockLength;
                            break;
                        }
                    }
                    //---------------------------

                    this.fights.Add(new CDungeonFight(ref data, position));
                    position += blockLength;
                }

                //-------------Türen-------
                blockLength = 5;

                while ((position + blockLength) <= dungeonEvent.endOffset)
                {
                    //auf ende Prüfen
                    if ((data[position] == 0xFF) && (data[position + 1] == 0xFF))
                    {
                        bool end = true;
                        for (int i = position + 2; i < (position + blockLength); i++)
                        {
                            if (data[i] != 0)
                                end = false;
                        }

                        if (end)
                        {
                            position += blockLength;
                            break;
                        }
                    }
                    //---------------------------

                    this.doors.Add(new CDungeonDoor(ref data, position));
                    position += blockLength;
                }

                //-------------Treppen-------
                blockLength = 4;

                while ((position + blockLength) <= dungeonEvent.endOffset)
                {
                    //auf ende Prüfen
                    if ((data[position] == 0xFF) && (data[position + 1] == 0xFF))
                    {
                        bool end = true;
                        for (int i = position + 2; i < (position + blockLength); i++)
                        {
                            if (data[i] != 0)
                                end = false;
                        }

                        if (end)
                        {
                            position += blockLength;
                            break;
                        }
                    }
                    //---------------------------

                    this.stairs.Add(new CDungeonStair(ref data, position));
                    position += blockLength;
                }
            }

            public class CFloor
            {
                public Byte[,] dungeonData = new byte[16, 16];

                public CFloor(ref byte[] data, Int32 offset)
                {
                    //Werte auslesen;
                    for (int y = 0; y < 16; y++)
                    {
                        for (int x = 0; x < 16; x++)
                        {
                            this.dungeonData[x, y] = data[offset];
                            offset++;
                        }
                    }
                }
            }
            public class CDungeonFight
            {
                public byte PositionX = 0;
                public byte PositionY = 0;

                public byte Ebene = 0;

                public Int16 KampfID = 0;

                public byte[] Flucht_Ebene = new byte[4];
                public byte[] Flucht_PosX = new byte[4];
                public byte[] Flucht_PosY = new byte[4];
                public byte[] Flucht_Blickrichtung = new byte[4];

                public Int16 extraAP = 0;

                public CDungeonFight(ref byte[] data, Int32 offset)
                {
                    this.PositionY = data[offset];
                    this.PositionX = (byte)(data[offset + 1] & 0x0F);
                    this.Ebene = (byte)((data[offset + 1] & 0xF0) >> 4);

                    this.KampfID = (Int16)(data[offset + 2] + (data[offset + 3] << 8));

                    for (int i = 0; i < 4; i++)
                    {
                        this.Flucht_Ebene[i] = (byte)(data[offset + 4 + 2 * i] & 0x0F);
                        this.Flucht_PosY[i] = (byte)((data[offset + 4 + 2 * i] & 0xF0) >> 4);

                        this.Flucht_Blickrichtung[i] = (byte)(data[offset + 4 + 2 * i + 1] & 0x0F);
                        this.Flucht_PosX[i] = (byte)((data[offset + 4 + 2 * i + 1] & 0xF0) >> 4); 
                    }

                    this.extraAP = (Int16)(data[offset + 12] + (data[offset + 13] << 8));
                }
            }
            public class CDungeonDoor
            {
                public byte PositionX = 0;
                public byte PositionY = 0;

                public byte Ebene = 0;

                public Int16 TürID = 0;
                public byte Status = 0;

                public CDungeonDoor(ref byte[] data, Int32 offset)
                {
                    this.PositionY = data[offset];

                    this.PositionX = (byte)(data[offset + 1] & 0x0F);
                    this.Ebene = (byte)((data[offset + 1] & 0xF0) >> 4); 

                    this.TürID = (Int16)(data[offset + 2] + (data[offset + 3] << 8));

                    this.Status = data[offset + 4];
                }
            }
            public class CDungeonStair
            {
                public sbyte PositionX = 0;
                public sbyte PositionY = 0;
                public sbyte Ebene = 0;

                public sbyte Zielebene = 0;
                public sbyte relXPos = 0;
                public sbyte relYPos = 0;
                public byte Blickrichtung = 0;

                public CDungeonStair(ref byte[] data, Int32 offset)
                {
                    this.PositionY = (sbyte)data[offset];

                    this.PositionX = (sbyte)(data[offset + 1] & 0x0F);
                    this.Ebene = (sbyte)((data[offset + 1] & 0xF0) >> 4);

                    this.relXPos = (sbyte)(data[offset + 2] & 0x0F);
                    this.Zielebene = (sbyte)((data[offset + 2] & 0xF0) >> 4);

                    this.relYPos = (sbyte)(data[offset + 3] & 0x0F);
                    this.Blickrichtung = (byte)((data[offset + 3] & 0xF0) >> 4); 
                }

                public string getZielebeneString()
                {
                    string ret = "";
                    switch (this.Zielebene)
                    {
                        case 0x0: ret = "-1 ("; break;
                        case 0x4: ret = "-2 ("; break;
                        case 0x8: ret = "+1 ("; break;
                        case 0xC: ret = "+2 ("; break;
                        default: ret = "??? ("; break;
                    }
                    ret += this.Zielebene.ToString() + ")";
                    return ret;
                }
            }
        }
    }
}

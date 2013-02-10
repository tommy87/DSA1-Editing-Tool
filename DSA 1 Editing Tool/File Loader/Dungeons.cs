using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace DSA_1_Editing_Tool.File_Loader
{
    public class CDungeon_list
    {
        public List<KeyValuePair<string, CDungeon>> itsDungeons = new List<KeyValuePair<string, CDungeon>>();

        public CDungeon_list() { }
        public void addDungeons(ref byte[] data, List<CDSAFileLoader.CFileSet> dungeons_DNG, List<CDSAFileLoader.CFileSet> dungeonEvents_DDT)
        {
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
        public void clear()
        {
            this.itsDungeons.Clear();
        }

        public void exportXML(string path, CKampf fightdata)
        {
            foreach (KeyValuePair<string, CDungeon> ct in itsDungeons)
            {
                string name = "dng"+ct.Key.Substring(0, ct.Key.Length - 4).ToLower();
                ct.Value.exportXML(path + "\\" + name + ".xml", name, fightdata);
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

            //////////////////
            //  XML export  //
            //////////////////

            List<CDungeonFight> filterFights(int Ebene)
            {
                List<CDungeonFight> ret = new List<CDungeonFight>();
                foreach( CDungeonFight fgt in fights ) {
                    if (fgt.Ebene == Ebene)
                        ret.Add(fgt);
                }
                return ret;
            }
            List<CDungeonDoor> filterDoors(int Ebene)
            {
                List<CDungeonDoor> ret = new List<CDungeonDoor>();
                foreach (CDungeonDoor fgt in doors)
                {
                    if (fgt.Ebene == Ebene)
                        ret.Add(fgt);
                }
                return ret;
            }
            List<CDungeonStair> filterStairs(int Ebene)
            {
                List<CDungeonStair> ret = new List<CDungeonStair>();
                foreach (CDungeonStair fgt in stairs)
                {
                    if (fgt.Ebene == Ebene)
                        ret.Add(fgt);
                }
                return ret;
            }
            Dictionary<int,CFight_LST> filterFightsData(List<CDungeonFight> dfights, CKampf fightdata)
            {
                Dictionary<int,CFight_LST> ret = new Dictionary<int,CFight_LST>(dfights.Count);
                foreach( CDungeonFight df in dfights )
                {
                    if( !ret.ContainsKey(df.KampfID) )
                        ret.Add(df.KampfID,fightdata.itsFight_LST[df.KampfID]);
                }
                return ret;
            }
            public void exportXML(string filename, string name, CKampf fightdata)
            {
                XmlTextWriter wr = new XmlTextWriter(filename, Encoding.UTF8);
                wr.WriteStartDocument();
                wr.WriteStartElement("dungeon");
                wr.WriteAttributeString("intname", name.ToLower());
                CDebugger.addDebugLine("Exporting " + name);
                int cnt = 0;
                foreach (CFloor fl in floors)
                {
                    List<CDungeonFight> dfights = filterFights( cnt );
                    fl.exportXML(wr, cnt, dfights, filterDoors( cnt ), filterStairs( cnt ), filterFightsData( dfights, fightdata ) );
                    cnt++;
                }
                wr.WriteStartElement("script");
                wr.WriteCData("function OnTrigger( which, floor ) {\n\tswitch( which ) {\n\t\tcase 'testtrigger': break;\n\t}\n}");
                wr.WriteEndElement();

                wr.WriteStartElement("itemsets");
                wr.WriteStartElement("itemset");
                wr.WriteAttributeString("id", "chest_one");
                wr.WriteComment("Same format as loot of the fights, <item id='xy' count='17'>, for chestloot and 'stuff lying around'");
                wr.WriteEndElement();
                wr.WriteEndElement();

                wr.WriteEndElement();
                wr.Close();
            }

            //------------------------------------

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

                public string FieldToString(int x, int y)
                {
                    int value = ((this.dungeonData[x,y] & 0xF0) >> 4);
                    switch (value)
                    {
                        case 0: return "normaler Boden(" + value.ToString() + ")";
                        case 1: return "Tür geschlossen(" + value.ToString() + ")";
                        case 2: return "Tür offen(" + value.ToString() + ")";
                        case 3: return "Treppe runter(" + value.ToString() + ")";
                        case 4: return "Treppe rauf(" + value.ToString() + ")";
                        case 5: return "Fallgrube nach(" + value.ToString() + ")";
                        case 6: return "Fallgrube von(" + value.ToString() + ")";
                        case 7: return "Sprite 51(" + value.ToString() + ")";
                        case 8: return "Schatztruhe(" + value.ToString() + ")";
                        case 10: return "Geheimtür(" + value.ToString() + ")";
                        case 11: return "Illusionswand(" + value.ToString() + ")";
                        case 12: return "Teleportziel(" + value.ToString() + ")";
                        case 15: return "Wand(" + value.ToString() + ")";

                        default:
                            return "???(" + value.ToString() + ")";
                    }
                }

                public bool[] checkSurrounding(int x, int y)
                {
                    bool[] ret = new bool[8];
                    int cnt = 0;
                    for (int yy = y - 1; yy <= y + 1; yy++)
                    {
                        for (int xx = x - 1; xx <= x + 1; xx++)
                        {
                            if (x == xx && y == yy) continue;
                            ret[cnt] = false;
                            if ((xx >= 0) && (xx < 16) && (yy >= 0) && (yy < 16))
                            {
                                if (dungeonData[xx, yy] != 15) ret[cnt] = true;
                            }
                            cnt++;
                        }
                    }
                    return ret;
                }

                public class CCoords
                {
                    public int x;
                    public int y;
                    public string name;
                    public CCoords(int _x, int _y, string _name)
                    {
                        x = _x;
                        y = _y;
                        name = _name;
                    }
                }

                public void exportXML(XmlTextWriter wr, int floorid, List<CDungeonFight> fights, List<CDungeonDoor> doors, List<CDungeonStair> stairs, Dictionary<int,CFight_LST> fightdata)
                {
                    wr.WriteStartElement("floor");
                    wr.WriteAttributeString("id", floorid.ToString());
                    wr.WriteComment("Tiles are Read-Only and just as reference for IDs of Doors and Chests");
                    wr.WriteStartElement("tiles");
                    int doorid = 1;
                    int chestid = 1;
                    for (int y = 0; y < 16; y++)
                    {
                        for (int x = 0; x < 16; x++)
                        {
                            // Skip if surrounded by walls
                            bool[] surr = checkSurrounding(x,y);
                            bool skip = true;
                            for (int i = 0; i < 8; i++)
                                if (surr[i]) skip = false;

                            if (skip) continue;

                            // determine tile type
                            string tt = "";

                            wr.WriteStartElement("tile");
                            
                            int ttint = dungeonData[x, y] >> 4;
                            switch (ttint)
                            {
                                case 0: tt = "floor"; break;
                                case 1: tt = "door"; wr.WriteAttributeString("cdoorid", (doorid++).ToString()); wr.WriteAttributeString("state", "closed"); break;
                                case 2: tt = "door"; wr.WriteAttributeString("cdoorid", (doorid++).ToString()); wr.WriteAttributeString("state", "open"); break;
                                case 3: tt = "stairDn"; break;
                                case 4: tt = "stairUp"; break;
                                case 5: tt = "floor"; wr.WriteAttributeString("special", "fallto"); break;
                                case 6: tt = "floor"; wr.WriteAttributeString("special", "fallfrom"); break;
                                case 7: tt = "floor"; wr.WriteAttributeString("special", "prop51"); break;
                                case 8: tt = "chest"; wr.WriteAttributeString("chestid", (chestid++).ToString() ); break;
                                case 10: tt = "secretdoor"; wr.WriteAttributeString("cdoorid", (doorid++).ToString()); break;
                                case 11: tt = "illusion"; break;
                                case 12: tt = "floor"; wr.WriteAttributeString("special", "teleporttarget"); break;
                                case 15: tt = "wall"; break;
                                default: tt = "floor"; 
                                    CDebugger.addDebugLine("unknown tiletype " + ttint.ToString() + " at floor " + floorid.ToString() + " " + x.ToString() + "/" + y.ToString()); break;
                            }

                            if( tt != "chest" && tt != "wall" ) {
                                for (int i = 0; i < doors.Count; i++)
                                {
                                    if (doors[i].PositionX == x && doors[i].PositionY == y)
                                    {
                                        tt = "door";
                                        wr.WriteAttributeString("doorid", doors[i].TürID.ToString());
                                        wr.WriteAttributeString("status", doors[i].Status.ToString());
                                        break;
                                    }
                                }
                            }
                   
                            if (tt == "stairUp" || tt == "stairDn")
                            {
                                for (int i = 0; i < stairs.Count; i++)
                                {
                                    if (stairs[i].PositionX == x && stairs[i].PositionY == y)
                                    {
                                        wr.WriteAttributeString("targetlevel", stairs[i].getZielebeneInt().ToString());
                                        wr.WriteAttributeString("targetX", stairs[i].relXPos.ToString());
                                        wr.WriteAttributeString("targetY", stairs[i].relYPos.ToString());
                                        wr.WriteAttributeString("lookdir", stairs[i].Blickrichtung.ToString());
                                    }
                                }
                            }


                            wr.WriteAttributeString("x", x.ToString());
                            wr.WriteAttributeString("y", y.ToString());
                            wr.WriteAttributeString("type", tt);
                            // /tile
                            wr.WriteEndElement();
                        }
                    }
                    // /tiles
                    wr.WriteEndElement();

                    wr.WriteComment("Any Changes from here affect the game directly");
                    List<CCoords> trigger = new List<CCoords>(fights.Count);

                    if( fights.Count > 0 ) {
                        wr.WriteStartElement("fights");
                        for (int i = 0; i < fights.Count; i++)
                        {
                            wr.WriteStartElement("fight");

                            trigger.Add(new CCoords(fights[i].PositionX, fights[i].PositionY, fightdata[fights[i].KampfID].name.ToLower()));

                            wr.WriteAttributeString("fightname", fightdata[fights[i].KampfID].name.ToLower());
                            wr.WriteAttributeString("extraAP", fights[i].extraAP.ToString());
                            for (int j = 0; j < 4; j++)
                            {
                                wr.WriteStartElement("escape");
                                wr.WriteAttributeString("dir",j.ToString());
                                wr.WriteAttributeString("x", fights[i].Flucht_PosX[j].ToString());
                                wr.WriteAttributeString("y", fights[i].Flucht_PosY[j].ToString());
                                wr.WriteAttributeString("lookdir", fights[i].Flucht_Blickrichtung[j].ToString());
                                wr.WriteAttributeString("floor", fights[i].Flucht_Ebene[j].ToString());
                                // /escape
                                wr.WriteEndElement();
                            }

                            // fetch monsters
                            fightdata[fights[i].KampfID].exportXML(wr);

                            // /fight
                            wr.WriteEndElement();
                        }
                        // /fights
                        wr.WriteEndElement();
                    }
                    wr.WriteStartElement("triggers");

                    foreach (CCoords t in trigger)
                    {
                        wr.WriteStartElement("trigger");
                        wr.WriteAttributeString("name", t.name);
                        wr.WriteAttributeString("x", t.x.ToString());
                        wr.WriteAttributeString("y", t.y.ToString());
                        wr.WriteEndElement();
                    }

                    wr.WriteEndElement();

                    // /floor
                    wr.WriteEndElement();
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
                        this.Flucht_PosY[i] = (byte)(data[offset + 4 + 2 * i] & 0x0F);
                        this.Flucht_PosX[i] = (byte)(data[offset + 4 + 2 * i + 1] & 0x0F);
                        this.Flucht_Blickrichtung[i] = (byte)((data[offset + 4 + 2 * i] & 0xF0) >> 4);
                        this.Flucht_Ebene[i] = (byte)((data[offset + 4 + 2 * i + 1] & 0xF0) >> 4); 
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

                public int getZielebeneInt()
                {
                    switch (this.Zielebene)
                    {
                        case 0x0: return this.Ebene-1;
                        case 0x4: return this.Ebene-2;
                        case 0x8: return this.Ebene+1;
                        case 0xC: return this.Ebene+2;
                        default: return this.Ebene;
                    }
                }
            }
        }
    }
}

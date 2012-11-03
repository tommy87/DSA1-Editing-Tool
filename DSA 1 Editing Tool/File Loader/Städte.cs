using System;
using System.Collections.Generic;
using System.Text;

namespace DSA_1_Editing_Tool.File_Loader
{
    public class CStädte
    {
        public List<KeyValuePair<string, CTown>> itsTowns = new List<KeyValuePair<string, CTown>>();

        public CStädte()
        {
        }

        public void loadStädte(ref byte[] data, List<CDSAFileLoader.CFileSet> towns)
        {
            this.itsTowns.Clear();

            if (data == null)
                return;

            if (towns.Count == 0)
                CDebugger.addDebugLine("Städte: keine Städte Dateien gefunden");
            else
                CDebugger.addDebugLine("Städte: es wurden " + towns.Count.ToString() + " Städte gefunden");

            foreach (CDSAFileLoader.CFileSet fileSet in towns)
                this.itsTowns.Add(new KeyValuePair<string, CTown>(fileSet.filename, new CTown(ref data, fileSet)));
                
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
                this.townData = new byte[32,16];
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

     
    }
    public class CTownEvent
    {
        public byte Position_Y = 0;
        public byte Position_X = 0;
        public byte Typ = 0;
        public byte Index_Lokal = 0;
        public byte Index_Global = 0;
        public byte unbekannt = 0;

        public CTownEvent(ref byte[] data, int offset)
        {
            if (data.Length < (offset + 6))
                return;

            this.Position_Y = data[offset];
            this.Position_X = data[offset + 1];
            this.Typ = data[offset + 2];
            this.Index_Lokal = data[offset + 3];
            this.Index_Global = data[offset + 4];
            this.unbekannt = data[offset + 5];
        }
    }
}

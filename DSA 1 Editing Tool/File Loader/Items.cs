using System;
using System.Collections.Generic;
using System.Text;

using System.IO;

namespace DSA_1_Editing_Tool.File_Loader
{
    public class CItemList
    {
        public List<CItem> itsItems = new List<CItem>();
        public List<string> itsItemNames = new List<string>();

        public void LoadItems(ref byte[] data, CDSAFileLoader.CFileSet items_dat, CDSAFileLoader.CFileSet itemname)
        {
            this.itsItems.Clear();
            this.itsItemNames.Clear();

            if (data == null)
                return;

            if (items_dat != null)
            {
                //blocklänge 12Bytes
                Int32 blockLength = 12;

                Int32 position = items_dat.startOffset;
                while ((position + blockLength) < items_dat.endOffset)
                {
                    itsItems.Add(new CItem((Int16)(data[position] + ((Int16)data[position + 1] << 8)), data[position + 2], data[position + 3], (Int16)(data[position + 5] + ((Int16)data[position + 6] << 8)), data[position + 7], (Int16)(data[position + 8] + ((Int16)data[position + 9] << 8)), data[position + 10], data[position + 11]));
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

                string text = CHelpFunctions.readDSAString(ref data, position, 0);
                itsItemNames.Add(text);
                position += (text.Length + 1);

                while ((position) < itemname.endOffset)
                {
                    text = CHelpFunctions.readDSAString(ref data, position, 0);
                    itsItemNames.Add(text);
                    position += (text.Length + 1);
                }
                CDebugger.addDebugLine("Items: ITEMNAME wurde erfolgreich extrahiert");
            }
            else
                CDebugger.addDebugLine("Items: ITEMNAME konnte nicht extrahiert werden");
        }

        public string getItemNameByID(Int16 ID)
        {
            if (ID < this.itsItemNames.Count)
                return this.itsItemNames[ID];

            return "???";
        }

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

            public CItem(Int16 IconID, byte ItemTyp, byte AnziehbarAnPosition, Int16 Gewicht, byte Preis_Grundeinheit, Int16 Preis, byte SortimentsID, byte Magisch)
            {
                this.IconID = IconID;
                this.ItemTyp = ItemTyp;
                this.AnziehbarAnPosition = AnziehbarAnPosition;
                this.Gewicht = Gewicht;
                this.Preis_Grundeinheit = Preis_Grundeinheit;
                this.Preis = Preis;
                this.SortimentsID = SortimentsID;
                this.Magisch = Magisch;
            }

            public string AnziehbarAnPositionToString()
            {
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
                else
                {
                    switch (this.AnziehbarAnPosition)
                    {
                        case 0:
                            return ("Gegenstand(" + AnziehbarAnPosition.ToString() + ")");
                    }
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
                int geld = this.Preis; // * this.Preis_Grundeinheit;

                int Heller = geld % 10;
                int Silberlinge = (geld / 10) % 10;
                int Dukaten = geld / 100;

                return (Dukaten.ToString() + "D " + Silberlinge.ToString() + "S " + Heller.ToString() + "H (" + this.Preis.ToString() + ")");
            }
        }
    }
}

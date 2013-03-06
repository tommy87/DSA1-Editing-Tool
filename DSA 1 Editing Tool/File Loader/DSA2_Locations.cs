using System;
using System.Collections.Generic;
using System.Text;

using System.Drawing;

namespace DSA_1_Editing_Tool.File_Loader
{
    public class CDSA2_Locations
    {
        public List<KeyValuePair<string, CDSALocation>> itsLocations = new List<KeyValuePair<string, CDSALocation>>();


        public CDSA2_Locations() { }

        public void addLocation(ref byte[] data, ref CBilder bilder, List<CDSAFileLoader.CFileSet> mapLayout_MADs, List<CDSAFileLoader.CFileSet> mapInfos_INFs)
        {
            foreach (var MAD in mapLayout_MADs)
            {
                CDSALocation location = new CDSALocation(ref bilder, MAD.filename.Substring(0, MAD.filename.LastIndexOf('.')));

                location.addMap(ref data, MAD);

                foreach (var INF in mapInfos_INFs)
                {
                    //String.Compare(,,true) wegen groß und kleinschreibung
                    if (0 == String.Compare(location.Name, INF.filename.Substring(0, INF.filename.LastIndexOf('.')), true))
                    {
                        location.addMapInfo(ref data, INF);
                        break;
                    }
                }

                this.itsLocations.Add(new KeyValuePair<string, CDSALocation>(location.Name, location));
            }
        }

        public void clear()
        {
            this.itsLocations.Clear();
        }



        public class CDSALocation
        {
            private List<Image> _MapImages = new List<Image>();
            private SMADLayout[,] _Map = null;
            private int _width = 0;
            private int _deepth = 0;
            private const int _KachelSize = 16;
            
            private string _Name = String.Empty;
            private String _usedNVF = String.Empty;

            public String Name { get { return this._Name; } }
            public String UsedNVF { get { return this._usedNVF; } }

            //TODO:
            //funktion get Map()
            //Karteninfos
            //Karten Indexe (2-Dimensionen)

            public CDSALocation(ref CBilder bilder, string name) 
            {
                this._Name = name;

                if ((0 == String.Compare(name, "BLUT1", true)) ||
                    (0 == String.Compare(name, "BLUT2", true)) ||
                    (0 == String.Compare(name, "BLUT3", true)))
                {
                        foreach (var pair in bilder.itsImages)
                        {
                            if (0 == String.Compare(pair.Key, "BLUT.NVF", true))
                            {
                                this._MapImages = pair.Value;
                                this._usedNVF = pair.Key;
                                break;
                            }
                        }
                }
                else if ((0 == String.Compare(name, "BINGE6A", true)) ||
                    (0 == String.Compare(name, "BINGE6B", true)))
                {
                        foreach (var pair in bilder.itsImages)
                        {
                            if (0 == String.Compare(pair.Key, "BINGE6.NVF", true))
                            {
                                this._MapImages = pair.Value;
                                this._usedNVF = pair.Key;
                                break;
                            }
                        }
                }
                else if ((0 == String.Compare(name, "TIEFHUS", true)))
                {
                    foreach (var pair in bilder.itsImages)
                    {
                        if (0 == String.Compare(pair.Key, "LOWANGEN.NVF", true))
                        {
                            this._MapImages = pair.Value;
                            this._usedNVF = pair.Key;
                            break;
                        }
                    }
                }
                else
                {
                    foreach (var pair in bilder.itsImages)
                    {
                        if (0 == String.Compare(name, pair.Key.Substring(0, pair.Key.LastIndexOf('.')), true))
                        {
                            this._MapImages = pair.Value;
                            this._usedNVF = pair.Key;
                            break;
                        }
                    }
                }

                if (this._MapImages.Count == 0)
                {
                    foreach (var pair in bilder.itsImages)
                    {
                        if (0 == String.Compare(pair.Key, "CITYPART.NVF", true))
                        {
                            this._MapImages = pair.Value;
                            this._usedNVF = pair.Key;
                            break;
                        }
                    }
                }
            }

            public void addMap(ref byte[] data, CDSAFileLoader.CFileSet mapLayout_MAD)
            {
                int position = mapLayout_MAD.startOffset;

                if (mapLayout_MAD.endOffset < (position + 4))
                    return;

                this._width = CHelpFunctions.byteArrayToInt16(ref data, position);
                position += 2;

                this._deepth = CHelpFunctions.byteArrayToInt16(ref data, position);
                position += 2;

                this._Map = new SMADLayout[this._width, this._deepth];

                for (int y = 0; y < this._deepth; y++)
                {
                    for (int x = 0; x < this._width; x++)
                    {
                        this._Map[x, y] = new SMADLayout(data[position], data[position + 1]);

                        position += 2;

                        if (mapLayout_MAD.endOffset < position)
                            break;
                    }

                    if (mapLayout_MAD.endOffset < position)
                        break;
                }
            }
            public void addMapInfo(ref byte[] data, CDSAFileLoader.CFileSet mapInfos_INF)
            {
            }

            public Bitmap getImage()
            {
                if (this._Map == null)
                    return null;

                Bitmap image = new Bitmap(this._width * _KachelSize, this._deepth * _KachelSize);
                Graphics g = Graphics.FromImage(image);

                for (int y = 0; y < this._deepth; y++)
                {
                    for (int x = 0; x < this._width; x++)
                    {
                        SMADLayout mapPiece = this._Map[x, y];
                        if (mapPiece.imageIndex < this._MapImages.Count)
                        {
                            g.DrawImage(this._MapImages[mapPiece.imageIndex], new Rectangle(x * _KachelSize, y * _KachelSize, _KachelSize, _KachelSize));

                            if (mapPiece.unknown != 0)
                                g.DrawRectangle(Pens.Red, new Rectangle(x * _KachelSize, y * _KachelSize, _KachelSize - 1, _KachelSize - 1));
                        }
                    }
                }

                return image;
            }

            public struct SMADLayout
            {
                public byte imageIndex;
                public byte unknown;

                public SMADLayout(byte imageIndex, byte unknown)
                {
                    this.imageIndex = imageIndex;
                    this.unknown = unknown;
                }
            }
        }
    }
}

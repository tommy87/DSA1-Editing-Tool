using System;
using System.Collections.Generic;
using System.Text;

using System.Drawing;

namespace DSA_1_Editing_Tool.File_Loader
{
    public class CRouten
    {
        public List<List<Point>> itsLRout = new List<List<Point>>();    //Land Routen
        public List<List<Point>> itsHSRout = new List<List<Point>>();   //Hochsee Routen
        public List<List<Point>> itsSRout = new List<List<Point>>();    //See Routen

        public CRouten()
        {
        }

        public void addRouten(ref byte[] data, CDSAFileLoader.CFileSet LROUT, CDSAFileLoader.CFileSet HSROUT, CDSAFileLoader.CFileSet SROUT)
        {
            this.itsLRout = this.loadRout(ref data, LROUT);
            this.itsHSRout = this.loadRout(ref data, HSROUT);
            this.itsSRout = this.loadRout(ref data, SROUT);

            CDebugger.addDebugLine("Ruten wurden erfolgreich geladen");
        }
        public void clear()
        {
            this.itsLRout.Clear();
            this.itsHSRout.Clear();
            this.itsSRout.Clear();
        }

        private List<List<Point>> loadRout(ref byte[] data, CDSAFileLoader.CFileSet ROUT)
        {
            List<Int32> offsets = new List<Int32>();
            List<List<Point>> rout = new List<List<Point>>();

            Int32 position = ROUT.startOffset;
            Int32 value = CHelpFunctions.byteArrayToInt32(ref data, position);
            position += 4;

            while (value >= 0 && position < ROUT.endOffset)
            {
                offsets.Add(value);
                value = CHelpFunctions.byteArrayToInt32(ref data, position);
                position += 4;
            }

            Int32 beginOfData = position;

            for (int i = 0; i < offsets.Count; i++)
            {
                rout.Add(new List<Point>());

                position = beginOfData + offsets[i];

                Int16 x = CHelpFunctions.byteArrayToInt16(ref data, position);
                position += 2;
                Int16 y = CHelpFunctions.byteArrayToInt16(ref data, position);
                position += 2;

                while (x >= 0 && y >= 0 && position < ROUT.endOffset)
                {
                    rout[i].Add(new Point(x, y));

                    x = CHelpFunctions.byteArrayToInt16(ref data, position);
                    position += 2;
                    y = CHelpFunctions.byteArrayToInt16(ref data, position);
                    position += 2;
                }
            }

            return rout;
        }
    }
}

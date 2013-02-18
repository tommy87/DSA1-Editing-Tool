using System;
using System.Collections.Generic;
using System.Text;

namespace DSA_1_Editing_Tool
{
    public class CHelpFunctions
    {
        public static string readDSAString(ref byte[] data, Int32 position, UInt32 length) //bei length = 0 wird ein 0 Terminierter string eingelesen
        {
            string s = "";

            if (length <= 0)    
            {
                //es wird ein 0 terminierter string gelesen
                while (position < data.Length && data[position] != 0)
                {
                    s += getCharFromData(data[position]);
                    position++;
                }
            }
            else
            {
                for (Int32 i = position; i < position + length; i++)
                {
                    if (data[i] == 0)
                        break;

                    s += getCharFromData(data[i]);
                }
            }

            return s;
        }
        public static string getCharFromData(byte data)
        {
            string s = "";
            switch (data)
            {
                case 60:
                    s += (char)0x22;
                    break;
                case 62:
                    s += (char)0x22;
                    break;
                case 64:
                    s += "\n";
                    break;
                case 129:
                    s += "ü";
                    break;
                case 132:
                    s += "ä";
                    break;
                case 142:
                    s += "Ä";
                    break;
                case 148:
                    s += "ö";
                    break;
                case 153:
                    s += "Ö";
                    break;
                case 154:
                    s += "Ü";
                    break;
                case 225:
                    s += "ß";
                    break;
                default:
                    s += (char)data;
                    break;
            }
            return s;
        }
        public static string dsaWürfelwertToString(byte[] data)
        {
            if (data.Length != 2)
                return "Fehler";

            string s = "";

            if (data[1] != 0)
            {
                s = ((data[1] & 0xF0) >> 4).ToString();

                switch (data[1] & 0x0F)
                {
                    case 0x01:
                        s += "W6";
                        break;
                    case 0x02:
                        s += "W20";
                        break;
                    case 0x03:
                        s += "W3";
                        break;
                    case 0x04:
                        s += "W4";
                        break;
                    case 0x05:
                        s += "W100";
                        break;

                    default:
                        s += "??";
                        break;
                }

                if (data[0] != 0)
                {
                    if (((sbyte)data[0]) >= 0)
                        s += (" + " + ((sbyte)data[0]).ToString());
                    else
                        s += (" " + ((sbyte)data[0]).ToString());
                }

            }
            else
            {
                s = ((sbyte)data[0]).ToString();
            }

            //s += "(" + data[0].ToString("X2") + "-" + data[1].ToString("X2") + ")";
            return s;
        }
        public static string dsaRichtungToString(byte data)
        {
            switch (data)
            {
                case 0: return ("Norden(" + data.ToString() + ")");
                case 1: return ("Osten(" + data.ToString() + ")");
                case 2: return ("Süden(" + data.ToString() + ")");
                case 3: return ("Westen(" + data.ToString() + ")");

                default: return ("?(" + data.ToString() + ")");
            }
        }

        public static Int16 byteArrayToInt16(ref byte[] data, Int32 position)
        {
            return (Int16)(data[position] + ((Int16)data[position + 1] << 8));
        }
        public static Int32 byteArrayToInt32(ref byte[] data, Int32 position)
        {
            return (Int32)(data[position] + ((Int32)data[position + 1] << 8) + ((Int32)data[position + 2] << 16) + ((Int32)data[position + 3] << 24));
        }   

        public static byte[] unpackAmiga2Data(ref byte[] sourceData, Int32 startPosition, Int32 dataLength)
        {
            if (sourceData == null || (startPosition + dataLength) >= sourceData.Length)
                return null;

            UInt32 unpackLength = sourceData[startPosition + dataLength - 2];
            unpackLength += (UInt32)(sourceData[startPosition + dataLength - 3] << 8);
            unpackLength += (UInt32)(sourceData[startPosition + dataLength - 4] << 16);

            byte[] returnData = new byte[unpackLength];
            UInt32 destinationPosition = (UInt32)(unpackLength);

            CAmigaUnpackData amiga = new CAmigaUnpackData(ref sourceData, startPosition + dataLength - 4);

            //---zum Entpacken---
            UInt32 anzahlWiederholungen = 0;

            byte[] offsetSizes = new byte[4];

            offsetSizes[0] = sourceData[startPosition + 4];
            offsetSizes[1] = sourceData[startPosition + 5];
            offsetSizes[2] = sourceData[startPosition + 6];
            offsetSizes[3] = sourceData[startPosition + 7];
            //-------------------

            UInt32 x = 0;

            //skip some bits
            readNBits(ref amiga, sourceData[startPosition + dataLength - 1]);

            while (destinationPosition != 0)
            {
                if (0 == readNBits(ref amiga, 1))
                {
                    //daten sind nicht gepackt
                    anzahlWiederholungen = 0;
                    do
                    {
                        x = readNBits(ref amiga, 2);
                        anzahlWiederholungen += x;
                    }
                    while (x == 3); // wenn nicht alle bits ge

                    for (int i = 0; i <= anzahlWiederholungen; i++)
                        returnData[--destinationPosition] = (byte)readNBits(ref amiga, 8);


                    if (destinationPosition == 0)
                        break;
                }


                //daten sind gepackt

                x = readNBits(ref amiga, 2);
                UInt32 n_bits = offsetSizes[x];

                UInt32 offset = 0;
                anzahlWiederholungen = x + 1;

                if (x == 3)
                {
                    if (readNBits(ref amiga, 1) == 0)
                        offset = readNBits(ref amiga, 7);
                    else
                        offset = readNBits(ref amiga, n_bits);

                    do
                    {
                        x = readNBits(ref amiga, 3);
                        anzahlWiederholungen += x;
                    }
                    while (x == 7);

                }
                else
                    offset = readNBits(ref amiga, n_bits);


                for (int i = 0; i <= anzahlWiederholungen; i++)
                {
                    try
                    {
                        returnData[destinationPosition - 1] = returnData[destinationPosition + offset];
                        destinationPosition--;
                    }
                    catch (SystemException)
                    {
                        return null;
                        //throw e;
                    }

                    
                }

                if (destinationPosition == 0)
                    return returnData;

            }

            return returnData;
        }
        private class CAmigaUnpackData
        {
            public sbyte counter = 0;
            public byte currentByte = 0;

            public byte[] data;
            public Int32 readPosition;

            public CAmigaUnpackData(ref byte[] data, Int32 readPosition)
            {
                //if (data == null || data.Length <= readPosition)
                //    return null;

                this.data = data;
                this.readPosition = readPosition;

                if (data != null && data.Length > readPosition)
                    this.currentByte = data[readPosition];

            }
        }
        private static UInt32 readNBits(ref CAmigaUnpackData amiga, UInt32 n)
        {
            if (amiga.data == null || amiga.data.Length <= amiga.readPosition)
                return 0;

            UInt32 returnValue = 0;

            try
            {
                for (Int32 i = 0; i < n; i++)
                {
                    if (amiga.counter <= 0)
                    {
                        amiga.counter = 8;
                        amiga.readPosition--;
                        amiga.currentByte = amiga.data[amiga.readPosition];
                    }
                    returnValue = (UInt32)((returnValue << 1) | (UInt32)(amiga.currentByte & 0x01));
                    amiga.currentByte >>= 1;
                    amiga.counter--;
                }
            }
            catch (SystemException)
            {
                return 0;
            }
            

            return returnValue;
        }

        public static byte[] unpackRLEFile(ref byte[] sourceData, Int32 startPosition, Int32 dataLength, UInt32 unpackedSize)
        {
            byte[] returnData = new byte[unpackedSize];
            Int32 sourcePointer = startPosition;
            Int32 destinyPointer = 0;

            try
            {
                while (sourcePointer < (startPosition + dataLength))
                {
                    if (sourceData[sourcePointer] != 0x7F)
                        returnData[destinyPointer++] = sourceData[sourcePointer++];
                    else
                    {
                        sourcePointer++;
                        byte wiederholungen = sourceData[sourcePointer++];
                        byte value = sourceData[sourcePointer++];

                        for (int i = 0; i < wiederholungen; i++)
                            returnData[destinyPointer++] = value;
                    }
                }
            }
            catch (SystemException)
            {
                //throw e;
                return null;
            }


            return returnData;
        }

        public static bool IsRunningOnMono()
        {
            return Type.GetType("Mono.Runtime") != null;
        }
    }
}

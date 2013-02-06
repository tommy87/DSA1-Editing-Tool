using System;
using System.Collections.Generic;
using System.Text;

using System.Drawing;

namespace DSA_1_Editing_Tool
{
    static class CFarbPalette
    {
        //Folgende Dateien fehlen mir noch:

        //    OBJECTS.NVF (Palettenbereich:0x00-0xCF)
        //    FIGHTOBJ.NVF (Palettenbereich:0x60-0x7F)

        //sollten beide nur im Kampf benutzt werden

        //    TEMPICON (Palettenbereich:0x00-0x1F)

        //die sollten nur im tempel zu finden sein

        //    Attic (Palettenbereich:0x00-0x1F)
        //    DSALOGO.DAT(Palettenbereich:0x00-0x2F)
        //    GENTIT.DAT (Palettenbereich:0x00-0x2F)
        //    ROALOGUS.DAT (Palettenbereich:0x80-0xCF)

        //sollten alle im intro verfügbar sein

        public enum palettenTyp { default_Pal, Town_Pal, CharMenü_Pal, Fight_Pal, Logo_Attic, GEN_Pal };

        static Color[] defaultPalette = new Color[256];
        static Color[] townPalette = null;
        static Color[] charMenüPalette = null;
        static Color[] fightPalette = null;
        static Color[] AtticPalette = null;
        static Color[] GENPalette = null;

        static CFarbPalette()
        {
            try
            {
                initDefaultPalette();

                initTownPalette();
                initCharMenüPalette();
                initFightPalette();
                initAtticPalette();
                initGENPalette();
            }
            catch (SystemException)
            {
                CDebugger.addErrorLine("Fehler beim initialisieren der Farbpaletten");
            }
        }
        static private void initDefaultPalette()
        {
            /*Die Palette kenne ich sehr wohl. Im Spiel gibt es insgesamt 256/0x100 Farben, welche in Bereiche eingeteilt sind.
Z.B. sind die Gesichter der Helden 0x20-0x3f, die Gegenstände 0x40-0x5f. Bei diesen speziellen Bereichen gibt es feste Paletten die für alle Bilder eines Typs gelten.*/

            //defaultPalette = new Color[256];

            defaultPalette[0] = Color.FromArgb(255, Color.FromArgb(0x000000));
            defaultPalette[1] = Color.FromArgb(255, Color.FromArgb(0x304020));
            defaultPalette[2] = Color.FromArgb(255, Color.FromArgb(0x502010));
            defaultPalette[3] = Color.FromArgb(255, Color.FromArgb(0x504010));
            defaultPalette[4] = Color.FromArgb(255, Color.FromArgb(0x404040));
            defaultPalette[5] = Color.FromArgb(255, Color.FromArgb(0x406040));
            defaultPalette[6] = Color.FromArgb(255, Color.FromArgb(0x803010));
            defaultPalette[7] = Color.FromArgb(255, Color.FromArgb(0x407060));
            defaultPalette[8] = Color.FromArgb(255, Color.FromArgb(0x806020));
            defaultPalette[9] = Color.FromArgb(255, Color.FromArgb(0x806040));
            defaultPalette[10] = Color.FromArgb(255, Color.FromArgb(0x509040));
            defaultPalette[11] = Color.FromArgb(255, Color.FromArgb(0x707060));
            defaultPalette[12] = Color.FromArgb(255, Color.FromArgb(0xb04010));
            defaultPalette[13] = Color.FromArgb(255, Color.FromArgb(0x307090));
            defaultPalette[14] = Color.FromArgb(255, Color.FromArgb(0x809030));
            defaultPalette[15] = Color.FromArgb(255, Color.FromArgb(0x509070));

            defaultPalette[16] = Color.FromArgb(255, Color.FromArgb(0xc06020));
            defaultPalette[17] = Color.FromArgb(255, Color.FromArgb(0x70a060));
            defaultPalette[18] = Color.FromArgb(255, Color.FromArgb(0x40b090));
            defaultPalette[19] = Color.FromArgb(255, Color.FromArgb(0xc07050));
            defaultPalette[20] = Color.FromArgb(255, Color.FromArgb(0xd07030));
            defaultPalette[21] = Color.FromArgb(255, Color.FromArgb(0xc09030));
            defaultPalette[22] = Color.FromArgb(255, Color.FromArgb(0x40b0a0));
            defaultPalette[23] = Color.FromArgb(255, Color.FromArgb(0x80b080));
            defaultPalette[24] = Color.FromArgb(255, Color.FromArgb(0xb0a060));
            defaultPalette[25] = Color.FromArgb(255, Color.FromArgb(0xe09030));
            defaultPalette[26] = Color.FromArgb(255, Color.FromArgb(0x90c080));
            defaultPalette[27] = Color.FromArgb(255, Color.FromArgb(0xc0b080));
            defaultPalette[28] = Color.FromArgb(255, Color.FromArgb(0xd0c060));
            defaultPalette[29] = Color.FromArgb(255, Color.FromArgb(0xd0d080));
            defaultPalette[30] = Color.FromArgb(255, Color.FromArgb(0xc0c0b0));
            defaultPalette[31] = Color.FromArgb(255, Color.FromArgb(0xe0e0c0));
            //---------------------------------
            //  Heldenportraits 0x20-0x3f
            defaultPalette[32] = Color.FromArgb(255, Color.FromArgb(0x000000));
            defaultPalette[33] = Color.FromArgb(255, Color.FromArgb(0x0000fc));
            defaultPalette[34] = Color.FromArgb(255, Color.FromArgb(0x000090));
            defaultPalette[35] = Color.FromArgb(255, Color.FromArgb(0xf0c0a0));
            defaultPalette[36] = Color.FromArgb(255, Color.FromArgb(0xf0b090));
            defaultPalette[37] = Color.FromArgb(255, Color.FromArgb(0xf0a070));
            defaultPalette[38] = Color.FromArgb(255, Color.FromArgb(0xe09060));
            defaultPalette[39] = Color.FromArgb(255, Color.FromArgb(0xd08050));
            defaultPalette[40] = Color.FromArgb(255, Color.FromArgb(0xc07050));
            defaultPalette[41] = Color.FromArgb(255, Color.FromArgb(0xa06040));
            defaultPalette[42] = Color.FromArgb(255, Color.FromArgb(0x905030));
            defaultPalette[43] = Color.FromArgb(255, Color.FromArgb(0x704030));
            defaultPalette[44] = Color.FromArgb(255, Color.FromArgb(0x603020));
            defaultPalette[45] = Color.FromArgb(255, Color.FromArgb(0x503020));
            defaultPalette[46] = Color.FromArgb(255, Color.FromArgb(0xe0e0e0));
            defaultPalette[47] = Color.FromArgb(255, Color.FromArgb(0xc0c0c0));

            defaultPalette[48] = Color.FromArgb(255, Color.FromArgb(0xb0b0b0));
            defaultPalette[49] = Color.FromArgb(255, Color.FromArgb(0xa0a0a0));
            defaultPalette[50] = Color.FromArgb(255, Color.FromArgb(0x808080));
            defaultPalette[51] = Color.FromArgb(255, Color.FromArgb(0x707070));
            defaultPalette[52] = Color.FromArgb(255, Color.FromArgb(0x505050));
            defaultPalette[53] = Color.FromArgb(255, Color.FromArgb(0x404040));
            defaultPalette[54] = Color.FromArgb(255, Color.FromArgb(0x00fc00));
            defaultPalette[55] = Color.FromArgb(255, Color.FromArgb(0x009000));
            defaultPalette[56] = Color.FromArgb(255, Color.FromArgb(0xf0f000));
            defaultPalette[57] = Color.FromArgb(255, Color.FromArgb(0xd0b000));
            defaultPalette[58] = Color.FromArgb(255, Color.FromArgb(0xa08000));
            defaultPalette[59] = Color.FromArgb(255, Color.FromArgb(0xf06040));
            defaultPalette[60] = Color.FromArgb(255, Color.FromArgb(0xc04020));
            defaultPalette[61] = Color.FromArgb(255, Color.FromArgb(0x903010));
            defaultPalette[62] = Color.FromArgb(255, Color.FromArgb(0x402010));
            defaultPalette[63] = Color.FromArgb(255, Color.FromArgb(0xf0f0f0));
            //---------------------------------
            //  Gegenstände 0x40-0x5f
            defaultPalette[64] = Color.FromArgb(255, Color.FromArgb(0x000000));
            defaultPalette[65] = Color.FromArgb(255, Color.FromArgb(0xe0e0e0));
            defaultPalette[66] = Color.FromArgb(255, Color.FromArgb(0xd0d0d0));
            defaultPalette[67] = Color.FromArgb(255, Color.FromArgb(0xc0c0c0));
            defaultPalette[68] = Color.FromArgb(255, Color.FromArgb(0xb0b0b0));
            defaultPalette[69] = Color.FromArgb(255, Color.FromArgb(0xa0a0a0));
            defaultPalette[70] = Color.FromArgb(255, Color.FromArgb(0x909090));
            defaultPalette[71] = Color.FromArgb(255, Color.FromArgb(0x808080));
            defaultPalette[72] = Color.FromArgb(255, Color.FromArgb(0x707070));
            defaultPalette[73] = Color.FromArgb(255, Color.FromArgb(0x606060));
            defaultPalette[74] = Color.FromArgb(255, Color.FromArgb(0x505050));
            defaultPalette[75] = Color.FromArgb(255, Color.FromArgb(0x404040));
            defaultPalette[76] = Color.FromArgb(255, Color.FromArgb(0x303030));
            defaultPalette[77] = Color.FromArgb(255, Color.FromArgb(0x202020));
            defaultPalette[78] = Color.FromArgb(255, Color.FromArgb(0xf0f0f0));
            defaultPalette[79] = Color.FromArgb(255, Color.FromArgb(0xf0d060));

            defaultPalette[80] = Color.FromArgb(255, Color.FromArgb(0xf0d020));
            defaultPalette[81] = Color.FromArgb(255, Color.FromArgb(0xf0d000));
            defaultPalette[82] = Color.FromArgb(255, Color.FromArgb(0xe0c000));
            defaultPalette[83] = Color.FromArgb(255, Color.FromArgb(0xd0b000));
            defaultPalette[84] = Color.FromArgb(255, Color.FromArgb(0xc0a000));
            defaultPalette[85] = Color.FromArgb(255, Color.FromArgb(0xb09000));
            defaultPalette[86] = Color.FromArgb(255, Color.FromArgb(0xa08000));
            defaultPalette[87] = Color.FromArgb(255, Color.FromArgb(0x907000));
            defaultPalette[88] = Color.FromArgb(255, Color.FromArgb(0x806000));
            defaultPalette[89] = Color.FromArgb(255, Color.FromArgb(0x705000));
            defaultPalette[90] = Color.FromArgb(255, Color.FromArgb(0xe05030));
            defaultPalette[91] = Color.FromArgb(255, Color.FromArgb(0xd03000));
            defaultPalette[92] = Color.FromArgb(255, Color.FromArgb(0xb02000));
            defaultPalette[93] = Color.FromArgb(255, Color.FromArgb(0x901000));
            defaultPalette[94] = Color.FromArgb(255, Color.FromArgb(0x700000));
            defaultPalette[95] = Color.FromArgb(255, Color.FromArgb(0x500000));

            defaultPalette[96] = Color.FromArgb(255, Color.FromArgb(0xb4fcb4));
            defaultPalette[97] = Color.FromArgb(255, Color.FromArgb(0xb4fcc4));
            defaultPalette[98] = Color.FromArgb(255, Color.FromArgb(0xb4fcd8));
            defaultPalette[99] = Color.FromArgb(255, Color.FromArgb(0xb4fce8));
            defaultPalette[100] = Color.FromArgb(255, Color.FromArgb(0xb4fcb4));
            defaultPalette[101] = Color.FromArgb(255, Color.FromArgb(0xb4e8fc));
            defaultPalette[102] = Color.FromArgb(255, Color.FromArgb(0xb4d8fc));
            defaultPalette[103] = Color.FromArgb(255, Color.FromArgb(0xb4c4fc));
            defaultPalette[104] = Color.FromArgb(255, Color.FromArgb(0x000070));
            defaultPalette[105] = Color.FromArgb(255, Color.FromArgb(0x1c0070));
            defaultPalette[106] = Color.FromArgb(255, Color.FromArgb(0x380070));
            defaultPalette[107] = Color.FromArgb(255, Color.FromArgb(0x540070));
            defaultPalette[108] = Color.FromArgb(255, Color.FromArgb(0x700070));
            defaultPalette[109] = Color.FromArgb(255, Color.FromArgb(0x700054));

            defaultPalette[110] = Color.FromArgb(255, Color.FromArgb(0x700038));
            defaultPalette[111] = Color.FromArgb(255, Color.FromArgb(0x70001c));
            defaultPalette[112] = Color.FromArgb(255, Color.FromArgb(0x700000));
            defaultPalette[113] = Color.FromArgb(255, Color.FromArgb(0x701c00));
            defaultPalette[114] = Color.FromArgb(255, Color.FromArgb(0x703800));
            defaultPalette[115] = Color.FromArgb(255, Color.FromArgb(0x705400));
            defaultPalette[116] = Color.FromArgb(255, Color.FromArgb(0x701000));
            defaultPalette[117] = Color.FromArgb(255, Color.FromArgb(0x547000));
            defaultPalette[118] = Color.FromArgb(255, Color.FromArgb(0x387000));
            defaultPalette[119] = Color.FromArgb(255, Color.FromArgb(0x1c7000));

            defaultPalette[120] = Color.FromArgb(255, Color.FromArgb(0x007000));
            defaultPalette[121] = Color.FromArgb(255, Color.FromArgb(0x00701c));
            defaultPalette[122] = Color.FromArgb(255, Color.FromArgb(0x007038));
            defaultPalette[123] = Color.FromArgb(255, Color.FromArgb(0x007054));
            defaultPalette[124] = Color.FromArgb(255, Color.FromArgb(0x007070));
            defaultPalette[125] = Color.FromArgb(255, Color.FromArgb(0x005470));
            defaultPalette[126] = Color.FromArgb(255, Color.FromArgb(0x003870));
            defaultPalette[127] = Color.FromArgb(255, Color.FromArgb(0x001c70));
            defaultPalette[128] = Color.FromArgb(255, Color.FromArgb(0x383870));
            defaultPalette[129] = Color.FromArgb(255, Color.FromArgb(0x443870));

            defaultPalette[130] = Color.FromArgb(255, Color.FromArgb(0x543870));
            defaultPalette[131] = Color.FromArgb(255, Color.FromArgb(0x603870));
            defaultPalette[132] = Color.FromArgb(255, Color.FromArgb(0x703870));
            defaultPalette[133] = Color.FromArgb(255, Color.FromArgb(0x703860));
            defaultPalette[134] = Color.FromArgb(255, Color.FromArgb(0x703854));
            defaultPalette[135] = Color.FromArgb(255, Color.FromArgb(0x703844));
            defaultPalette[136] = Color.FromArgb(255, Color.FromArgb(0x703838));
            defaultPalette[137] = Color.FromArgb(255, Color.FromArgb(0x704438));
            defaultPalette[138] = Color.FromArgb(255, Color.FromArgb(0x705438));
            defaultPalette[139] = Color.FromArgb(255, Color.FromArgb(0x706038));

            defaultPalette[140] = Color.FromArgb(255, Color.FromArgb(0x707038));
            defaultPalette[141] = Color.FromArgb(255, Color.FromArgb(0x607038));
            defaultPalette[142] = Color.FromArgb(255, Color.FromArgb(0x547038));
            defaultPalette[143] = Color.FromArgb(255, Color.FromArgb(0x447038));
            defaultPalette[144] = Color.FromArgb(255, Color.FromArgb(0x387038));
            defaultPalette[145] = Color.FromArgb(255, Color.FromArgb(0x387044));
            defaultPalette[146] = Color.FromArgb(255, Color.FromArgb(0x387054));
            defaultPalette[147] = Color.FromArgb(255, Color.FromArgb(0x387060));
            defaultPalette[148] = Color.FromArgb(255, Color.FromArgb(0x387070));
            defaultPalette[149] = Color.FromArgb(255, Color.FromArgb(0x386070));

            defaultPalette[150] = Color.FromArgb(255, Color.FromArgb(0x385470));
            defaultPalette[151] = Color.FromArgb(255, Color.FromArgb(0x384470));
            defaultPalette[152] = Color.FromArgb(255, Color.FromArgb(0x505070));
            defaultPalette[153] = Color.FromArgb(255, Color.FromArgb(0x585070));
            defaultPalette[154] = Color.FromArgb(255, Color.FromArgb(0x605070));
            defaultPalette[155] = Color.FromArgb(255, Color.FromArgb(0x685070));
            defaultPalette[156] = Color.FromArgb(255, Color.FromArgb(0x705070));
            defaultPalette[157] = Color.FromArgb(255, Color.FromArgb(0x705068));
            defaultPalette[158] = Color.FromArgb(255, Color.FromArgb(0x705060));
            defaultPalette[159] = Color.FromArgb(255, Color.FromArgb(0x705058));

            defaultPalette[160] = Color.FromArgb(255, Color.FromArgb(0x705050));
            defaultPalette[161] = Color.FromArgb(255, Color.FromArgb(0x705850));
            defaultPalette[162] = Color.FromArgb(255, Color.FromArgb(0x706050));
            defaultPalette[163] = Color.FromArgb(255, Color.FromArgb(0x706850));
            defaultPalette[164] = Color.FromArgb(255, Color.FromArgb(0x707050));
            defaultPalette[165] = Color.FromArgb(255, Color.FromArgb(0x687050));
            defaultPalette[166] = Color.FromArgb(255, Color.FromArgb(0x607050));
            defaultPalette[167] = Color.FromArgb(255, Color.FromArgb(0x587050));
            defaultPalette[168] = Color.FromArgb(255, Color.FromArgb(0x507050));
            defaultPalette[169] = Color.FromArgb(255, Color.FromArgb(0x507058));

            defaultPalette[170] = Color.FromArgb(255, Color.FromArgb(0x507060));
            defaultPalette[171] = Color.FromArgb(255, Color.FromArgb(0x507068));
            defaultPalette[172] = Color.FromArgb(255, Color.FromArgb(0x507070));
            defaultPalette[173] = Color.FromArgb(255, Color.FromArgb(0x506870));
            defaultPalette[174] = Color.FromArgb(255, Color.FromArgb(0x506070));
            defaultPalette[175] = Color.FromArgb(255, Color.FromArgb(0x505870));
            defaultPalette[176] = Color.FromArgb(255, Color.FromArgb(0x000040));
            defaultPalette[177] = Color.FromArgb(255, Color.FromArgb(0x100040));
            defaultPalette[178] = Color.FromArgb(255, Color.FromArgb(0x200040));
            defaultPalette[179] = Color.FromArgb(255, Color.FromArgb(0x300040));

            defaultPalette[180] = Color.FromArgb(255, Color.FromArgb(0x400040));
            defaultPalette[181] = Color.FromArgb(255, Color.FromArgb(0x400030));
            defaultPalette[182] = Color.FromArgb(255, Color.FromArgb(0x400020));
            defaultPalette[183] = Color.FromArgb(255, Color.FromArgb(0x400010));
            defaultPalette[184] = Color.FromArgb(255, Color.FromArgb(0x400000));
            defaultPalette[185] = Color.FromArgb(255, Color.FromArgb(0x401000));
            defaultPalette[186] = Color.FromArgb(255, Color.FromArgb(0x402000));
            defaultPalette[187] = Color.FromArgb(255, Color.FromArgb(0x403000));
            defaultPalette[188] = Color.FromArgb(255, Color.FromArgb(0x404000));
            defaultPalette[189] = Color.FromArgb(255, Color.FromArgb(0x304000));

            defaultPalette[190] = Color.FromArgb(255, Color.FromArgb(0x204000));
            defaultPalette[191] = Color.FromArgb(255, Color.FromArgb(0x104000));
            defaultPalette[192] = Color.FromArgb(255, Color.FromArgb(0x004000));
            defaultPalette[193] = Color.FromArgb(255, Color.FromArgb(0x004010));
            defaultPalette[194] = Color.FromArgb(255, Color.FromArgb(0x004020));
            defaultPalette[195] = Color.FromArgb(255, Color.FromArgb(0x004030));
            defaultPalette[196] = Color.FromArgb(255, Color.FromArgb(0x004040));
            defaultPalette[197] = Color.FromArgb(255, Color.FromArgb(0x003040));
            defaultPalette[198] = Color.FromArgb(255, Color.FromArgb(0x002040));
            defaultPalette[199] = Color.FromArgb(255, Color.FromArgb(0x001040));

            defaultPalette[200] = Color.FromArgb(255, Color.FromArgb(0xa00000));
            defaultPalette[201] = Color.FromArgb(255, Color.FromArgb(0xa0a000));
            defaultPalette[202] = Color.FromArgb(255, Color.FromArgb(0x0000a0));
            defaultPalette[203] = Color.FromArgb(255, Color.FromArgb(0x382040));
            defaultPalette[204] = Color.FromArgb(255, Color.FromArgb(0x402040));
            defaultPalette[205] = Color.FromArgb(255, Color.FromArgb(0x402038));
            defaultPalette[206] = Color.FromArgb(255, Color.FromArgb(0x402030));
            defaultPalette[207] = Color.FromArgb(255, Color.FromArgb(0x402028));
            defaultPalette[208] = Color.FromArgb(255, Color.FromArgb(0x402020));
            defaultPalette[209] = Color.FromArgb(255, Color.FromArgb(0x402820));

            defaultPalette[210] = Color.FromArgb(255, Color.FromArgb(0x403020));
            defaultPalette[211] = Color.FromArgb(255, Color.FromArgb(0x403820));
            defaultPalette[212] = Color.FromArgb(255, Color.FromArgb(0x404020));
            defaultPalette[213] = Color.FromArgb(255, Color.FromArgb(0x384020));
            defaultPalette[214] = Color.FromArgb(255, Color.FromArgb(0x304020));
            defaultPalette[215] = Color.FromArgb(255, Color.FromArgb(0x284020));
            defaultPalette[216] = Color.FromArgb(255, Color.FromArgb(0x000000));
            defaultPalette[217] = Color.FromArgb(255, Color.FromArgb(0xe0c0a0));
            defaultPalette[218] = Color.FromArgb(255, Color.FromArgb(0xe0c040));
            defaultPalette[219] = Color.FromArgb(255, Color.FromArgb(0xc0a030));

            defaultPalette[220] = Color.FromArgb(255, Color.FromArgb(0xb09020));
            defaultPalette[221] = Color.FromArgb(255, Color.FromArgb(0xa08010));
            defaultPalette[222] = Color.FromArgb(255, Color.FromArgb(0x605000));
            defaultPalette[223] = Color.FromArgb(255, Color.FromArgb(0x2c6430));
            defaultPalette[224] = Color.FromArgb(255, Color.FromArgb(0x2c2c40));
            defaultPalette[225] = Color.FromArgb(255, Color.FromArgb(0x302c40));
            defaultPalette[226] = Color.FromArgb(255, Color.FromArgb(0x342c40));
            defaultPalette[227] = Color.FromArgb(255, Color.FromArgb(0x3c2c40));
            defaultPalette[228] = Color.FromArgb(255, Color.FromArgb(0x402c40));
            defaultPalette[229] = Color.FromArgb(255, Color.FromArgb(0x402c3c));

            defaultPalette[230] = Color.FromArgb(255, Color.FromArgb(0x402c34));
            defaultPalette[231] = Color.FromArgb(255, Color.FromArgb(0x402c30));
            defaultPalette[232] = Color.FromArgb(255, Color.FromArgb(0x402c2c));
            defaultPalette[233] = Color.FromArgb(255, Color.FromArgb(0x40302c));
            defaultPalette[234] = Color.FromArgb(255, Color.FromArgb(0x40342c));
            defaultPalette[235] = Color.FromArgb(255, Color.FromArgb(0x403c2c));
            defaultPalette[236] = Color.FromArgb(255, Color.FromArgb(0x40402c));
            defaultPalette[237] = Color.FromArgb(255, Color.FromArgb(0x3c402c));
            defaultPalette[238] = Color.FromArgb(255, Color.FromArgb(0x34402c));
            defaultPalette[239] = Color.FromArgb(255, Color.FromArgb(0x30402c));

            defaultPalette[240] = Color.FromArgb(255, Color.FromArgb(0x2c402c));
            defaultPalette[241] = Color.FromArgb(255, Color.FromArgb(0x2c4030));
            defaultPalette[242] = Color.FromArgb(255, Color.FromArgb(0x2c4034));
            defaultPalette[243] = Color.FromArgb(255, Color.FromArgb(0x2c403c));
            defaultPalette[244] = Color.FromArgb(255, Color.FromArgb(0x2c4040));
            defaultPalette[245] = Color.FromArgb(255, Color.FromArgb(0x2c3c40));
            defaultPalette[246] = Color.FromArgb(255, Color.FromArgb(0x2c3440));
            defaultPalette[247] = Color.FromArgb(255, Color.FromArgb(0x2c3040));
            defaultPalette[248] = Color.FromArgb(255, Color.FromArgb(0x000000));
            defaultPalette[249] = Color.FromArgb(255, Color.FromArgb(0x000000));

            defaultPalette[250] = Color.FromArgb(255, Color.FromArgb(0x000000));
            defaultPalette[251] = Color.FromArgb(255, Color.FromArgb(0x000000));
            defaultPalette[252] = Color.FromArgb(255, Color.FromArgb(0x000000));
            defaultPalette[253] = Color.FromArgb(255, Color.FromArgb(0x000000));
            defaultPalette[254] = Color.FromArgb(255, Color.FromArgb(0x000000));
            defaultPalette[255] = Color.FromArgb(255, Color.FromArgb(0xfcfcfc));
        }
        static private void initTownPalette()
        {
            townPalette = (Color[])defaultPalette.Clone();

            townPalette[0x00] = Color.FromArgb(0x00, 0x00, 0x00);
            townPalette[0x01] = Color.FromArgb(0xd3, 0xd3, 0xd3);
            townPalette[0x02] = Color.FromArgb(0xc3, 0xc3, 0xc3);
            townPalette[0x03] = Color.FromArgb(0xb2, 0xb2, 0xb2);
            townPalette[0x04] = Color.FromArgb(0xa2, 0xa2, 0xa2);
            townPalette[0x05] = Color.FromArgb(0x92, 0x92, 0x92);
            townPalette[0x06] = Color.FromArgb(0x82, 0x82, 0x82);
            townPalette[0x07] = Color.FromArgb(0x71, 0x71, 0x71);

            townPalette[0x08] = Color.FromArgb(0x61, 0x61, 0x61);
            townPalette[0x09] = Color.FromArgb(0x51, 0x51, 0x51);
            townPalette[0x0A] = Color.FromArgb(0x41, 0x41, 0x41);
            townPalette[0x0B] = Color.FromArgb(0x30, 0x30, 0x30);
            townPalette[0x0C] = Color.FromArgb(0x20, 0x20, 0x20);
            townPalette[0x0D] = Color.FromArgb(0x10, 0x10, 0x10);
            townPalette[0x0E] = Color.FromArgb(0xe3, 0xa2, 0x82);
            townPalette[0x0F] = Color.FromArgb(0xd3, 0x92, 0x71);

            townPalette[0x10] = Color.FromArgb(0xc3, 0x82, 0x61);
            townPalette[0x11] = Color.FromArgb(0xa2, 0x61, 0x41);
            townPalette[0x12] = Color.FromArgb(0x92, 0x51, 0x41);
            townPalette[0x13] = Color.FromArgb(0x82, 0x41, 0x20);
            townPalette[0x14] = Color.FromArgb(0x71, 0x41, 0x30);
            townPalette[0x15] = Color.FromArgb(0x51, 0x30, 0x20);
            townPalette[0x16] = Color.FromArgb(0x41, 0x20, 0x20);
            townPalette[0x17] = Color.FromArgb(0xe3, 0xe3, 0xe3);

            townPalette[0x18] = Color.FromArgb(0xf3, 0xf3, 0xf3);
            townPalette[0x19] = Color.FromArgb(0xf3, 0xc3, 0xa2);
            townPalette[0x1A] = Color.FromArgb(0xb2, 0x82, 0x10);
            townPalette[0x1B] = Color.FromArgb(0xa2, 0x61, 0x20);
            townPalette[0x1C] = Color.FromArgb(0x82, 0x51, 0x20);
            townPalette[0x1D] = Color.FromArgb(0x51, 0x20, 0x00);
            townPalette[0x1E] = Color.FromArgb(0x61, 0x30, 0x00);
            townPalette[0x1F] = Color.FromArgb(0x20, 0x10, 0x10);

            townPalette[0x20] = Color.FromArgb(0x00, 0x00, 0x00);
            townPalette[0x21] = Color.FromArgb(0x00, 0x00, 0xff);
            townPalette[0x22] = Color.FromArgb(0x00, 0x00, 0x92);
            townPalette[0x23] = Color.FromArgb(0xf3, 0xc3, 0xa2);
            townPalette[0x24] = Color.FromArgb(0xf3, 0xb2, 0x92);
            townPalette[0x25] = Color.FromArgb(0xf3, 0xa2, 0x71);
            townPalette[0x26] = Color.FromArgb(0xe3, 0x92, 0x61);
            townPalette[0x27] = Color.FromArgb(0xd3, 0x82, 0x51);

            townPalette[0x28] = Color.FromArgb(0xc3, 0x71, 0x51);
            townPalette[0x29] = Color.FromArgb(0xa2, 0x61, 0x41);
            townPalette[0x2A] = Color.FromArgb(0x92, 0x51, 0x30);
            townPalette[0x2B] = Color.FromArgb(0x71, 0x41, 0x30);
            townPalette[0x2C] = Color.FromArgb(0x61, 0x30, 0x20);
            townPalette[0x2D] = Color.FromArgb(0x51, 0x30, 0x20);
            townPalette[0x2E] = Color.FromArgb(0xe3, 0xe3, 0xe3);
            townPalette[0x2F] = Color.FromArgb(0xc3, 0xc3, 0xc3);

            townPalette[0x30] = Color.FromArgb(0xb2, 0xb2, 0xb2);
            townPalette[0x31] = Color.FromArgb(0xa2, 0xa2, 0xa2);
            townPalette[0x32] = Color.FromArgb(0x82, 0x82, 0x82);
            townPalette[0x33] = Color.FromArgb(0x71, 0x71, 0x71);
            townPalette[0x34] = Color.FromArgb(0x51, 0x51, 0x51);
            townPalette[0x35] = Color.FromArgb(0x41, 0x41, 0x41);
            townPalette[0x36] = Color.FromArgb(0x00, 0xff, 0x00);
            townPalette[0x37] = Color.FromArgb(0x00, 0x92, 0x00);

            townPalette[0x38] = Color.FromArgb(0xf3, 0xe3, 0x00);
            townPalette[0x39] = Color.FromArgb(0xd3, 0xb2, 0x00);
            townPalette[0x3A] = Color.FromArgb(0xa2, 0x82, 0x00);
            townPalette[0x3B] = Color.FromArgb(0xf3, 0x61, 0x41);
            townPalette[0x3C] = Color.FromArgb(0xc3, 0x41, 0x20);
            townPalette[0x3D] = Color.FromArgb(0x92, 0x30, 0x10);
            townPalette[0x3E] = Color.FromArgb(0x41, 0x20, 0x10);
            townPalette[0x3F] = Color.FromArgb(0xf3, 0xf3, 0xf3);

            townPalette[0x40] = Color.FromArgb(0x00, 0x00, 0x00);
            townPalette[0x41] = Color.FromArgb(0xe3, 0xc3, 0xa2);
            townPalette[0x42] = Color.FromArgb(0xc3, 0x92, 0x71);
            townPalette[0x43] = Color.FromArgb(0x92, 0x61, 0x41);
            townPalette[0x44] = Color.FromArgb(0x82, 0x51, 0x30);
            townPalette[0x45] = Color.FromArgb(0x61, 0x30, 0x20);
            townPalette[0x46] = Color.FromArgb(0x51, 0x20, 0x10);
            townPalette[0x47] = Color.FromArgb(0x30, 0x10, 0x00);

            townPalette[0x48] = Color.FromArgb(0xf3, 0xe3, 0x00);
            townPalette[0x49] = Color.FromArgb(0xe3, 0xa2, 0x00);
            townPalette[0x4A] = Color.FromArgb(0xc3, 0x71, 0x00);
            townPalette[0x4B] = Color.FromArgb(0xb2, 0x51, 0x00);
            townPalette[0x4C] = Color.FromArgb(0xf3, 0x92, 0x00);
            townPalette[0x4D] = Color.FromArgb(0xf3, 0x30, 0x00);
            townPalette[0x4E] = Color.FromArgb(0xf3, 0x00, 0x20);
            townPalette[0x4F] = Color.FromArgb(0xf3, 0x00, 0x82);

            townPalette[0x50] = Color.FromArgb(0x00, 0x41, 0x00);
            townPalette[0x51] = Color.FromArgb(0x00, 0x51, 0x00);
            townPalette[0x52] = Color.FromArgb(0x00, 0x71, 0x00);
            townPalette[0x53] = Color.FromArgb(0x10, 0x82, 0x00);
            townPalette[0x54] = Color.FromArgb(0x10, 0xa2, 0x00);
            townPalette[0x55] = Color.FromArgb(0x71, 0xe3, 0xf3);
            townPalette[0x56] = Color.FromArgb(0x51, 0xb2, 0xd3);
            townPalette[0x57] = Color.FromArgb(0x30, 0x71, 0xc3);

            townPalette[0x58] = Color.FromArgb(0x10, 0x30, 0xa2);
            townPalette[0x59] = Color.FromArgb(0x00, 0x00, 0x92);
            townPalette[0x5A] = Color.FromArgb(0x41, 0x41, 0x41);
            townPalette[0x5B] = Color.FromArgb(0x51, 0x51, 0x51);
            townPalette[0x5C] = Color.FromArgb(0x71, 0x71, 0x71);
            townPalette[0x5D] = Color.FromArgb(0x92, 0x92, 0x92);
            townPalette[0x5E] = Color.FromArgb(0xc3, 0xc3, 0xc3);
            townPalette[0x5F] = Color.FromArgb(0xf3, 0xf3, 0xf3);

            townPalette[0x60] = Color.FromArgb(0x00, 0x00, 0x00);
            townPalette[0x61] = Color.FromArgb(0x00, 0x00, 0xa6);
            townPalette[0x62] = Color.FromArgb(0x00, 0x00, 0x38);
            townPalette[0x63] = Color.FromArgb(0x9a, 0x69, 0x49);
            townPalette[0x64] = Color.FromArgb(0x9a, 0x59, 0x38);
            townPalette[0x65] = Color.FromArgb(0x9a, 0x49, 0x18);
            townPalette[0x66] = Color.FromArgb(0x8a, 0x38, 0x08);
            townPalette[0x67] = Color.FromArgb(0x79, 0x28, 0x00);

            townPalette[0x68] = Color.FromArgb(0x69, 0x18, 0x00);
            townPalette[0x69] = Color.FromArgb(0x49, 0x08, 0x00);
            townPalette[0x6A] = Color.FromArgb(0x38, 0x00, 0x00);
            townPalette[0x6B] = Color.FromArgb(0x18, 0x00, 0x00);
            townPalette[0x6C] = Color.FromArgb(0x08, 0x00, 0x00);
            townPalette[0x6D] = Color.FromArgb(0x00, 0x00, 0x00);
            townPalette[0x6E] = Color.FromArgb(0x8a, 0x8a, 0x8a);
            townPalette[0x6F] = Color.FromArgb(0x69, 0x69, 0x69);

            townPalette[0x70] = Color.FromArgb(0x59, 0x59, 0x59);
            townPalette[0x71] = Color.FromArgb(0x49, 0x49, 0x49);
            townPalette[0x72] = Color.FromArgb(0x28, 0x28, 0x28);
            townPalette[0x73] = Color.FromArgb(0x18, 0x18, 0x18);
            townPalette[0x74] = Color.FromArgb(0x00, 0x00, 0x00);
            townPalette[0x75] = Color.FromArgb(0x00, 0x00, 0x00);
            townPalette[0x76] = Color.FromArgb(0x00, 0x82, 0x00);
            townPalette[0x77] = Color.FromArgb(0x00, 0x38, 0x00);

            townPalette[0x78] = Color.FromArgb(0x9a, 0x8a, 0x00);
            townPalette[0x79] = Color.FromArgb(0x79, 0x59, 0x00);
            townPalette[0x7A] = Color.FromArgb(0x49, 0x28, 0x00);
            townPalette[0x7B] = Color.FromArgb(0x9a, 0x08, 0x00);
            townPalette[0x7C] = Color.FromArgb(0x69, 0x00, 0x00);
            townPalette[0x7D] = Color.FromArgb(0x38, 0x00, 0x00);
            townPalette[0x7E] = Color.FromArgb(0x00, 0x00, 0x00);
            townPalette[0x7F] = Color.FromArgb(0x9a, 0x9a, 0x9a);

            //townPalette[0x80] = Color.FromArgb(0x383871);
            //townPalette[0x81] = Color.FromArgb(0x453871);
            //townPalette[0x82] = Color.FromArgb(0x553871);
            //townPalette[0x83] = Color.FromArgb(0x613871);
            //townPalette[0x84] = Color.FromArgb(0x713871
            //townPalette[0x85] = Color.FromArgb(0x713861
            //townPalette[0x86] = Color.FromArgb(0x713855
            //townPalette[0x87] = Color.FromArgb(0x713845
            //townPalette[0x88] = Color.FromArgb(0x713838
            //townPalette[0x89] = Color.FromArgb(0x714538
            //townPalette[0x8A] = Color.FromArgb(0x715538
            //townPalette[0x8B] = Color.FromArgb(0x716138
            //townPalette[0x8C] = Color.FromArgb(0x717138
            //townPalette[0x8D] = Color.FromArgb(0x617138
            //townPalette[0x8E] = Color.FromArgb(0x557138
            //townPalette[0x8F] = Color.FromArgb(0x457138

            //townPalette[0x90] = Color.FromArgb(0x387138
            //townPalette[0x91] = Color.FromArgb(0x387145
            //townPalette[0x92] = Color.FromArgb(0x387155
            //townPalette[0x93] = Color.FromArgb(0x387161
            //townPalette[0x94] = Color.FromArgb(0x387171
            //townPalette[0x95] = Color.FromArgb(0x386171
            //townPalette[0x96] = Color.FromArgb(0x385571
            //townPalette[0x97] = Color.FromArgb(0x384571
            //townPalette[0x98] = Color.FromArgb(0x515171
            //townPalette[0x99] = Color.FromArgb(0x595171
            //townPalette[0x9A] = Color.FromArgb(0x615171
            //townPalette[0x9B] = Color.FromArgb(0x695171
            //townPalette[0x9C] = Color.FromArgb(0x715171
            //townPalette[0x9D] = Color.FromArgb(0x715169
            //townPalette[0x9E] = Color.FromArgb(0x715161
            //townPalette[0x9F] = Color.FromArgb(0x715159
            
            //townPalette[0xA0] = Color.FromArgb(0x715151
            //townPalette[0xA1] = Color.FromArgb(0x715951
            //townPalette[0xA2] = Color.FromArgb(0x716151
            //townPalette[0xA3] = Color.FromArgb(0x716951
            //townPalette[0xA4] = Color.FromArgb(0x717151
            //townPalette[0xA5] = Color.FromArgb(0x697151
            //townPalette[0xA6] = Color.FromArgb(0x617151
            //townPalette[0xA7] = Color.FromArgb(0x597151
            //townPalette[0xA8] = Color.FromArgb(0x517151
            //townPalette[0xA9] = Color.FromArgb(0x517159
            //townPalette[0xAA] = Color.FromArgb(0x517161
            //townPalette[0xAB] = Color.FromArgb(0x517169
            //townPalette[0xAC] = Color.FromArgb(0x517171
            //townPalette[0xAD] = Color.FromArgb(0x516971
            //townPalette[0xAE] = Color.FromArgb(0x516171
            //townPalette[0xAF] = Color.FromArgb(0x515971
            
            //townPalette[0xB0] = Color.FromArgb(0x000041
            //townPalette[0xB1] = Color.FromArgb(0x100041
            //townPalette[0xB2] = Color.FromArgb(0x200041
            //townPalette[0xB3] = Color.FromArgb(0x300041
            //townPalette[0xB4] = Color.FromArgb(0x410041
            //townPalette[0xB5] = Color.FromArgb(0x410030
            //townPalette[0xB6] = Color.FromArgb(0x410020
            //townPalette[0xB7] = Color.FromArgb(0x410010
            //townPalette[0xB8] = Color.FromArgb(0x410000
            //townPalette[0xB9] = Color.FromArgb(0x411000
            //townPalette[0xBA] = Color.FromArgb(0x412000
            //townPalette[0xBB] = Color.FromArgb(0x413000
            //townPalette[0xBC] = Color.FromArgb(0x414100
            //townPalette[0xBD] = Color.FromArgb(0x304100
            //townPalette[0xBE] = Color.FromArgb(0x204100
            //townPalette[0xBF] = Color.FromArgb(0x104100
            

            // Gebäude (0x80 - 0xBF)
            townPalette[128] = Color.FromArgb(0x00 * 4, 0x00 * 4, 0x00 * 4);
            townPalette[129] = Color.FromArgb(0x39 * 4, 0x39 * 4, 0x39 * 4);
            townPalette[130] = Color.FromArgb(0x32 * 4, 0x32 * 4, 0x32 * 4);
            townPalette[131] = Color.FromArgb(0x2C * 4, 0x2C * 4, 0x2C * 4);
            townPalette[132] = Color.FromArgb(0x26 * 4, 0x26 * 4, 0x26 * 4);
            townPalette[133] = Color.FromArgb(0x20 * 4, 0x20 * 4, 0x20 * 4);
            townPalette[134] = Color.FromArgb(0x1A * 4, 0x1A * 4, 0x1A * 4);
            townPalette[135] = Color.FromArgb(0x13 * 4, 0x13 * 4, 0x13 * 4);

            townPalette[136] = Color.FromArgb(0x0D * 4, 0x0D * 4, 0x0D * 4);
            townPalette[137] = Color.FromArgb(0x37 * 4, 0x30 * 4, 0x2C * 4);
            townPalette[138] = Color.FromArgb(0x32 * 4, 0x29 * 4, 0x25 * 4);
            townPalette[139] = Color.FromArgb(0x2D * 4, 0x23 * 4, 0x1F * 4);
            townPalette[140] = Color.FromArgb(0x28 * 4, 0x1D * 4, 0x1A * 4);
            townPalette[141] = Color.FromArgb(0x22 * 4, 0x17 * 4, 0x15 * 4);
            townPalette[142] = Color.FromArgb(0x1E * 4, 0x12 * 4, 0x11 * 4);
            townPalette[143] = Color.FromArgb(0x18 * 4, 0x0D * 4, 0x0D * 4);

            townPalette[144] = Color.FromArgb(0x17 * 4, 0x09 * 4, 0x09 * 4);
            townPalette[145] = Color.FromArgb(0x21 * 4, 0x0D * 4, 0x0B * 4);
            townPalette[146] = Color.FromArgb(0x2C * 4, 0x11 * 4, 0x0D * 4);
            townPalette[147] = Color.FromArgb(0x37 * 4, 0x16 * 4, 0x0D * 4);
            townPalette[148] = Color.FromArgb(0x2A * 4, 0x2C * 4, 0x1C * 4);
            townPalette[149] = Color.FromArgb(0x20 * 4, 0x25 * 4, 0x14 * 4);
            townPalette[150] = Color.FromArgb(0x17 * 4, 0x1E * 4, 0x0E * 4);
            townPalette[151] = Color.FromArgb(0x0F * 4, 0x17 * 4, 0x09 * 4);

            townPalette[152] = Color.FromArgb(0x08 * 4, 0x10 * 4, 0x05 * 4);
            townPalette[153] = Color.FromArgb(0x32 * 4, 0x25 * 4, 0x03 * 4);
            townPalette[154] = Color.FromArgb(0x29 * 4, 0x1E * 4, 0x02 * 4);
            townPalette[155] = Color.FromArgb(0x20 * 4, 0x17 * 4, 0x02 * 4);
            townPalette[156] = Color.FromArgb(0x04 * 4, 0x0F * 4, 0x18 * 4);
            townPalette[157] = Color.FromArgb(0x05 * 4, 0x14 * 4, 0x1F * 4);
            townPalette[158] = Color.FromArgb(0x05 * 4, 0x1A * 4, 0x26 * 4);
            townPalette[159] = Color.FromArgb(0x06 * 4, 0x1F * 4, 0x2D * 4);

            //--------------------32-----------------
            townPalette[160] = Color.FromArgb(0x00 * 4, 0x00 * 4, 0x00 * 4);
            townPalette[161] = Color.FromArgb(0x05 * 4, 0x0D * 4, 0x28 * 4);
            townPalette[162] = Color.FromArgb(0x06 * 4, 0x10 * 4, 0x32 * 4);
            townPalette[163] = Color.FromArgb(0x3F * 4, 0x00 * 4, 0x3F * 4);
            townPalette[164] = Color.FromArgb(0x3F * 4, 0x00 * 4, 0x3F * 4);
            townPalette[165] = Color.FromArgb(0x2D * 4, 0x2D * 4, 0x38 * 4);
            townPalette[166] = Color.FromArgb(0x29 * 4, 0x29 * 4, 0x36 * 4);
            townPalette[167] = Color.FromArgb(0x26 * 4, 0x26 * 4, 0x34 * 4);

            townPalette[168] = Color.FromArgb(0x23 * 4, 0x23 * 4, 0x32 * 4);
            townPalette[169] = Color.FromArgb(0x21 * 4, 0x20 * 4, 0x31 * 4);
            townPalette[170] = Color.FromArgb(0x1F * 4, 0x1E * 4, 0x1F * 4);
            townPalette[171] = Color.FromArgb(0x1C * 4, 0x1B * 4, 0x2D * 4);
            townPalette[172] = Color.FromArgb(0x1A * 4, 0x19 * 4, 0x2C * 4);
            townPalette[173] = Color.FromArgb(0x19 * 4, 0x16 * 4, 0x2A * 4);
            townPalette[174] = Color.FromArgb(0x16 * 4, 0x14 * 4, 0x28 * 4);
            townPalette[175] = Color.FromArgb(0x15 * 4, 0x12 * 4, 0x27 * 4);

            townPalette[176] = Color.FromArgb(0x13 * 4, 0x10 * 4, 0x25 * 4);
            townPalette[177] = Color.FromArgb(0x11 * 4, 0x0E * 4, 0x22 * 4);
            townPalette[178] = Color.FromArgb(0x10 * 4, 0x0C * 4, 0x20 * 4);
            townPalette[179] = Color.FromArgb(0x0E * 4, 0x0B * 4, 0x1E * 4);
            townPalette[180] = Color.FromArgb(0x0E * 4, 0x09 * 4, 0x1B * 4);
            townPalette[181] = Color.FromArgb(0x0C * 4, 0x08 * 4, 0x19 * 4);
            townPalette[182] = Color.FromArgb(0x0B * 4, 0x06 * 4, 0x16 * 4);
            townPalette[183] = Color.FromArgb(0x3F * 4, 0x30 * 4, 0x3F * 4);

            townPalette[184] = Color.FromArgb(0x3F * 4, 0x30 * 4, 0x3F * 4);
            townPalette[185] = Color.FromArgb(0x3F * 4, 0x30 * 4, 0x3F * 4);
            townPalette[186] = Color.FromArgb(0x3F * 4, 0x30 * 4, 0x3F * 4);
            townPalette[187] = Color.FromArgb(0x3F * 4, 0x30 * 4, 0x3F * 4);
            townPalette[188] = Color.FromArgb(0x34 * 4, 0x30 * 4, 0x3A * 4);
            townPalette[189] = Color.FromArgb(0x3C * 4, 0x36 * 4, 0x3C * 4);
            townPalette[190] = Color.FromArgb(0x3F * 4, 0x3C * 4, 0x3C * 4);
            townPalette[191] = Color.FromArgb(0x3F * 4, 0x3F * 4, 0x3F * 4);
            //191 = 0xBF

            townPalette[0xC0] = Color.FromArgb(0x00, 0x41, 0x00);
            townPalette[0xC1] = Color.FromArgb(0x00, 0x41, 0x10);
            townPalette[0xC2] = Color.FromArgb(0x00, 0x41, 0x20);
            townPalette[0xC3] = Color.FromArgb(0x00, 0x41, 0x30);
            townPalette[0xC4] = Color.FromArgb(0x00, 0x41, 0x41);
            townPalette[0xC5] = Color.FromArgb(0x00, 0x30, 0x41);
            townPalette[0xC6] = Color.FromArgb(0x00, 0x20, 0x41);
            townPalette[0xC7] = Color.FromArgb(0x00, 0x10, 0x41);

            townPalette[0xC8] = Color.FromArgb(0xc3, 0x00, 0x00);
            townPalette[0xC9] = Color.FromArgb(0xc3, 0xc3, 0x00);
            townPalette[0xCA] = Color.FromArgb(0x00, 0x00, 0xc3);
            townPalette[0xCB] = Color.FromArgb(0x38, 0x20, 0x41);
            townPalette[0xCC] = Color.FromArgb(0x41, 0x20, 0x41);
            townPalette[0xCD] = Color.FromArgb(0x41, 0x20, 0x38);
            townPalette[0xCE] = Color.FromArgb(0x41, 0x20, 0x30);
            townPalette[0xCF] = Color.FromArgb(0x41, 0x20, 0x28);

            townPalette[0xD0] = Color.FromArgb(0x41, 0x20, 0x20);
            townPalette[0xD1] = Color.FromArgb(0x41, 0x28, 0x20);
            townPalette[0xD2] = Color.FromArgb(0x41, 0x30, 0x20);
            townPalette[0xD3] = Color.FromArgb(0x41, 0x38, 0x20);
            townPalette[0xD4] = Color.FromArgb(0x41, 0x41, 0x20);
            townPalette[0xD5] = Color.FromArgb(0x38, 0x41, 0x20);
            townPalette[0xD6] = Color.FromArgb(0x30, 0x41, 0x20);
            townPalette[0xD7] = Color.FromArgb(0x28, 0x41, 0x20);

            townPalette[0xD8] = Color.FromArgb(0x00, 0x00, 0x00);
            townPalette[0xD9] = Color.FromArgb(0xe3, 0xc3, 0xa2);
            townPalette[0xDA] = Color.FromArgb(0xe3, 0xc3, 0x41);
            townPalette[0xDB] = Color.FromArgb(0xc3, 0xa2, 0x30);
            townPalette[0xDC] = Color.FromArgb(0xb2, 0x92, 0x20);
            townPalette[0xDD] = Color.FromArgb(0xa2, 0x82, 0x10);
            townPalette[0xDE] = Color.FromArgb(0x61, 0x51, 0x00);
            townPalette[0xDF] = Color.FromArgb(0x2c, 0x65, 0x30);

            //townPalette[0xE0] = Color.FromArgb(0x000000
            //townPalette[0xE1] = Color.FromArgb(0xe3e3e3
            //townPalette[0xE2] = Color.FromArgb(0xd3d3d3
            //townPalette[0xE3] = Color.FromArgb(0xc3c3c3
            //townPalette[0xE4] = Color.FromArgb(0xb2b2b2
            //townPalette[0xE5] = Color.FromArgb(0xa2a2a2
            //townPalette[0xE6] = Color.FromArgb(0x929292
            //townPalette[0xE7] = Color.FromArgb(0x828282
            //townPalette[0xE8] = Color.FromArgb(0x717171
            //townPalette[0xE9] = Color.FromArgb(0x616161
            //townPalette[0xEA] = Color.FromArgb(0x515151
            //townPalette[0xEB] = Color.FromArgb(0x414141
            //townPalette[0xEC] = Color.FromArgb(0x303030
            //townPalette[0xED] = Color.FromArgb(0x202020
            //townPalette[0xEE] = Color.FromArgb(0x101010
            //townPalette[0xEF] = Color.FromArgb(0x000000

            //townPalette[0xF0] = Color.FromArgb(0x00f320
            //townPalette[0xF1] = Color.FromArgb(0xf3c3a2
            //townPalette[0xF2] = Color.FromArgb(0xf3b2a2
            //townPalette[0xF3] = Color.FromArgb(0xb27161
            //townPalette[0xF4] = Color.FromArgb(0x925141
            //townPalette[0xF5] = Color.FromArgb(0x714130
            //townPalette[0xF6] = Color.FromArgb(0x512020
            //townPalette[0xF7] = Color.FromArgb(0x301010
            //townPalette[0xF8] = Color.FromArgb(0x302000
            //townPalette[0xF9] = Color.FromArgb(0xb20000
            //townPalette[0xFA] = Color.FromArgb(0x4151f3
            //townPalette[0xFB] = Color.FromArgb(0x0020e3
            //townPalette[0xFC] = Color.FromArgb(0x0020d3
            //townPalette[0xFD] = Color.FromArgb(0x000061
            //townPalette[0xFE] = Color.FromArgb(0xf3f300
            //townPalette[0xFF] = Color.FromArgb(0xf3f3f3

            //Palette for Playmask. Colorspace is E0-FF (Tested by HenneNWH)
            townPalette[0xE0] = Color.FromArgb(00 * 4, 00 * 4, 00 * 4);
            townPalette[0xE1] = Color.FromArgb(56 * 4, 56 * 4, 56 * 4);
            townPalette[0xE2] = Color.FromArgb(52 * 4, 52 * 4, 52 * 4);
            townPalette[0xE3] = Color.FromArgb(48 * 4, 48 * 4, 48 * 4);
            townPalette[0xE4] = Color.FromArgb(44 * 4, 44 * 4, 44 * 4);
            townPalette[0xE5] = Color.FromArgb(40 * 4, 40 * 4, 40 * 4);
            townPalette[0xE6] = Color.FromArgb(36 * 4, 36 * 4, 36 * 4);
            townPalette[0xE7] = Color.FromArgb(32 * 4, 32 * 4, 32 * 4);

            townPalette[0xE8] = Color.FromArgb(28 * 4, 28 * 4, 28 * 4);
            townPalette[0xE9] = Color.FromArgb(24 * 4, 24 * 4, 24 * 4);
            townPalette[0xEA] = Color.FromArgb(20 * 4, 20 * 4, 20 * 4);
            townPalette[0xEB] = Color.FromArgb(16 * 4, 16 * 4, 16 * 4);
            townPalette[0xEC] = Color.FromArgb(12 * 4, 12 * 4, 12 * 4);
            townPalette[0xED] = Color.FromArgb(08 * 4, 08 * 4, 08 * 4);
            townPalette[0xEE] = Color.FromArgb(04 * 4, 04 * 4, 04 * 4);
            townPalette[0xEF] = Color.FromArgb(00 * 4, 00 * 4, 00 * 4);

            townPalette[0xF0] = Color.FromArgb(00 * 4, 60 * 4, 08 * 4);
            townPalette[0xF1] = Color.FromArgb(60 * 4, 48 * 4, 40 * 4);
            townPalette[0xF2] = Color.FromArgb(60 * 4, 44 * 4, 40 * 4);
            townPalette[0xF3] = Color.FromArgb(44 * 4, 28 * 4, 24 * 4);
            townPalette[0xF4] = Color.FromArgb(36 * 4, 20 * 4, 16 * 4);
            townPalette[0xF5] = Color.FromArgb(28 * 4, 16 * 4, 12 * 4);
            townPalette[0xF6] = Color.FromArgb(20 * 4, 08 * 4, 08 * 4);
            townPalette[0xF7] = Color.FromArgb(12 * 4, 04 * 4, 04 * 4);

            townPalette[0xF8] = Color.FromArgb(12 * 4, 08 * 4, 00 * 4);
            townPalette[0xF9] = Color.FromArgb(44 * 4, 00 * 4, 00 * 4);
            townPalette[0xFA] = Color.FromArgb(16 * 4, 20 * 4, 60 * 4);
            townPalette[0xFB] = Color.FromArgb(00 * 4, 08 * 4, 56 * 4);
            townPalette[0xFC] = Color.FromArgb(00 * 4, 08 * 4, 52 * 4);
            townPalette[0xFD] = Color.FromArgb(00 * 4, 00 * 4, 24 * 4);
            townPalette[0xFE] = Color.FromArgb(60 * 4, 60 * 4, 00 * 4);
            townPalette[0xFF] = Color.FromArgb(60 * 4, 60 * 4, 60 * 4);

        }
        static private void initCharMenüPalette()
        {
            charMenüPalette = (Color[])defaultPalette.Clone();
            //itemPalette = new Color[32];

            //Charaktermenü Hintergrund 0x00-0x1F
            charMenüPalette[0x00] = Color.FromArgb(00 * 4, 00 * 4, 00 * 4);
            charMenüPalette[0x01] = Color.FromArgb(06 * 4, 06 * 4, 06 * 4);
            charMenüPalette[0x02] = Color.FromArgb(63 * 4, 38 * 4, 16 * 4);
            charMenüPalette[0x03] = Color.FromArgb(63 * 4, 30 * 4, 00 * 4);
            charMenüPalette[0x04] = Color.FromArgb(51 * 4, 24 * 4, 00 * 4);
            charMenüPalette[0x05] = Color.FromArgb(39 * 4, 19 * 4, 00 * 4);
            charMenüPalette[0x06] = Color.FromArgb(12 * 4, 14 * 4, 00 * 4);
            charMenüPalette[0x07] = Color.FromArgb(16 * 4, 08 * 4, 00 * 4);

            charMenüPalette[0x08] = Color.FromArgb(63 * 4, 63 * 4, 00 * 4);
            charMenüPalette[0x09] = Color.FromArgb(60 * 4, 00 * 4, 00 * 4);
            charMenüPalette[0x0A] = Color.FromArgb(27 * 4, 00 * 4, 00 * 4);
            charMenüPalette[0x0B] = Color.FromArgb(00 * 4, 14 * 4, 63 * 4);
            charMenüPalette[0x0C] = Color.FromArgb(00 * 4, 00 * 4, 37 * 4);
            charMenüPalette[0x0D] = Color.FromArgb(60 * 4, 48 * 4, 33 * 4);
            charMenüPalette[0x0E] = Color.FromArgb(52 * 4, 40 * 4, 25 * 4);
            charMenüPalette[0x0F] = Color.FromArgb(44 * 4, 31 * 4, 18 * 4);

            charMenüPalette[0x10] = Color.FromArgb(36 * 4, 23 * 4, 10 * 4);
            charMenüPalette[0x11] = Color.FromArgb(60 * 4, 60 * 4, 60 * 4);
            charMenüPalette[0x12] = Color.FromArgb(56 * 4, 56 * 4, 56 * 4);
            charMenüPalette[0x13] = Color.FromArgb(52 * 4, 52 * 4, 52 * 4);
            charMenüPalette[0x14] = Color.FromArgb(48 * 4, 48 * 4, 48 * 4);
            charMenüPalette[0x15] = Color.FromArgb(44 * 4, 44 * 4, 44 * 4);
            charMenüPalette[0x16] = Color.FromArgb(40 * 4, 40 * 4, 40 * 4);
            charMenüPalette[0x17] = Color.FromArgb(36 * 4, 36 * 4, 36 * 4);

            charMenüPalette[0x18] = Color.FromArgb(32 * 4, 32 * 4, 32 * 4);
            charMenüPalette[0x19] = Color.FromArgb(28 * 4, 28 * 4, 28 * 4);
            charMenüPalette[0x1A] = Color.FromArgb(24 * 4, 24 * 4, 24 * 4);
            charMenüPalette[0x1B] = Color.FromArgb(20 * 4, 20 * 4, 20 * 4);
            charMenüPalette[0x1C] = Color.FromArgb(16 * 4, 16 * 4, 16 * 4);
            charMenüPalette[0x1D] = Color.FromArgb(12 * 4, 12 * 4, 12 * 4);
            charMenüPalette[0x1E] = Color.FromArgb(08 * 4, 08 * 4, 08 * 4);
            charMenüPalette[0x1F] = Color.FromArgb(63 * 4, 63 * 4, 63 * 4);

            //Gegenstände 0x40-0x5F
            charMenüPalette[0x40] = Color.FromArgb(00 * 4, 00 * 4, 00 * 4);
            charMenüPalette[0x41] = Color.FromArgb(56 * 4, 48 * 4, 40 * 4);
            charMenüPalette[0x42] = Color.FromArgb(48 * 4, 36 * 4, 28 * 4);
            charMenüPalette[0x43] = Color.FromArgb(36 * 4, 24 * 4, 16 * 4);
            charMenüPalette[0x44] = Color.FromArgb(32 * 4, 20 * 4, 12 * 4);
            charMenüPalette[0x45] = Color.FromArgb(24 * 4, 12 * 4, 08 * 4);
            charMenüPalette[0x46] = Color.FromArgb(20 * 4, 08 * 4, 04 * 4);
            charMenüPalette[0x47] = Color.FromArgb(12 * 4, 04 * 4, 00 * 4);

            charMenüPalette[0x48] = Color.FromArgb(60 * 4, 56 * 4, 00 * 4);
            charMenüPalette[0x49] = Color.FromArgb(25 * 4, 40 * 4, 00 * 4);
            charMenüPalette[0x4A] = Color.FromArgb(48 * 4, 28 * 4, 00 * 4);
            charMenüPalette[0x4B] = Color.FromArgb(44 * 4, 20 * 4, 00 * 4);
            charMenüPalette[0x4C] = Color.FromArgb(60 * 4, 36 * 4, 00 * 4);
            charMenüPalette[0x4D] = Color.FromArgb(60 * 4, 12 * 4, 00 * 4);
            charMenüPalette[0x4E] = Color.FromArgb(60 * 4, 00 * 4, 08 * 4);
            charMenüPalette[0x4F] = Color.FromArgb(60 * 4, 00 * 4, 32 * 4);

            charMenüPalette[0x50] = Color.FromArgb(00 * 4, 16 * 4, 00 * 4);
            charMenüPalette[0x51] = Color.FromArgb(00 * 4, 20 * 4, 00 * 4);
            charMenüPalette[0x52] = Color.FromArgb(00 * 4, 28 * 4, 00 * 4);
            charMenüPalette[0x53] = Color.FromArgb(04 * 4, 32 * 4, 00 * 4);
            charMenüPalette[0x54] = Color.FromArgb(04 * 4, 40 * 4, 00 * 4);
            charMenüPalette[0x55] = Color.FromArgb(28 * 4, 58 * 4, 60 * 4);
            charMenüPalette[0x56] = Color.FromArgb(20 * 4, 44 * 4, 52 * 4);
            charMenüPalette[0x57] = Color.FromArgb(12 * 4, 28 * 4, 48 * 4);

            charMenüPalette[0x58] = Color.FromArgb(04 * 4, 12 * 4, 40 * 4);
            charMenüPalette[0x59] = Color.FromArgb(00 * 4, 00 * 4, 36 * 4);
            charMenüPalette[0x5A] = Color.FromArgb(16 * 4, 16 * 4, 16 * 4);
            charMenüPalette[0x5B] = Color.FromArgb(20 * 4, 20 * 4, 20 * 4);
            charMenüPalette[0x5C] = Color.FromArgb(28 * 4, 28 * 4, 28 * 4);
            charMenüPalette[0x5D] = Color.FromArgb(36 * 4, 36 * 4, 36 * 4);
            charMenüPalette[0x5E] = Color.FromArgb(48 * 4, 48 * 4, 48 * 4);
            charMenüPalette[0x5F] = Color.FromArgb(60 * 4, 60 * 4, 60 * 4);
        }
        static private void initFightPalette()
        {
            fightPalette = (Color[])defaultPalette.Clone();

            fightPalette[0x00] = Color.FromArgb(0x00, 0x00, 0x00);
            fightPalette[0x01] = Color.FromArgb(0xf3, 0xb2, 0x92);
            fightPalette[0x02] = Color.FromArgb(0xf3, 0xa2, 0x71);
            fightPalette[0x03] = Color.FromArgb(0xd3, 0x82, 0x61);
            fightPalette[0x04] = Color.FromArgb(0xa2, 0x61, 0x51);
            fightPalette[0x05] = Color.FromArgb(0x82, 0x51, 0x41);
            fightPalette[0x06] = Color.FromArgb(0x61, 0x30, 0x20);
            fightPalette[0x07] = Color.FromArgb(0x41, 0x20, 0x20);

            fightPalette[0x08] = Color.FromArgb(0x30, 0x10, 0x10);
            fightPalette[0x09] = Color.FromArgb(0xd3, 0xd3, 0xd3);
            fightPalette[0x0A] = Color.FromArgb(0xa2, 0xa2, 0xa2);
            fightPalette[0x0B] = Color.FromArgb(0x82, 0x82, 0x82);
            fightPalette[0x0C] = Color.FromArgb(0x61, 0x61, 0x61);
            fightPalette[0x0D] = Color.FromArgb(0x51, 0x51, 0x51);
            fightPalette[0x0E] = Color.FromArgb(0x41, 0x41, 0x41);
            fightPalette[0x0F] = Color.FromArgb(0x30, 0x30, 0x30);

            fightPalette[0x10] = Color.FromArgb(0x20, 0x20, 0x20);
            fightPalette[0x11] = Color.FromArgb(0x51, 0x30, 0x20);
            fightPalette[0x12] = Color.FromArgb(0x00, 0x00, 0x00);
            fightPalette[0x13] = Color.FromArgb(0x61, 0x51, 0xf3);
            fightPalette[0x14] = Color.FromArgb(0x51, 0x00, 0x00);
            fightPalette[0x15] = Color.FromArgb(0x71, 0x00, 0x00);
            fightPalette[0x16] = Color.FromArgb(0x92, 0x00, 0x00);
            fightPalette[0x17] = Color.FromArgb(0xb2, 0x00, 0x00);

            fightPalette[0x18] = Color.FromArgb(0xf3, 0x00, 0x00);
            fightPalette[0x19] = Color.FromArgb(0x71, 0x41, 0x41);
            fightPalette[0x1A] = Color.FromArgb(0x00, 0x71, 0x00);
            fightPalette[0x1B] = Color.FromArgb(0x00, 0xa2, 0x00);
            fightPalette[0x1C] = Color.FromArgb(0x00, 0x10, 0x82);
            fightPalette[0x1D] = Color.FromArgb(0xb2, 0xb2, 0x30);
            fightPalette[0x1E] = Color.FromArgb(0xe3, 0xe3, 0x41);
            fightPalette[0x1F] = Color.FromArgb(0xf3, 0xf3, 0xf3);

            fightPalette[0x20] = Color.FromArgb(0x00, 0x00, 0x00);
            fightPalette[0x21] = Color.FromArgb(0x00, 0x00, 0xff);
            fightPalette[0x22] = Color.FromArgb(0x00, 0x00, 0x92);
            fightPalette[0x23] = Color.FromArgb(0xf3, 0xc3, 0xa2);
            fightPalette[0x24] = Color.FromArgb(0xf3, 0xb2, 0x92);
            fightPalette[0x25] = Color.FromArgb(0xf3, 0xa2, 0x71);
            fightPalette[0x26] = Color.FromArgb(0xe3, 0x92, 0x61);
            fightPalette[0x27] = Color.FromArgb(0xd3, 0x82, 0x51);

            fightPalette[0x28] = Color.FromArgb(0xc3, 0x71, 0x51);
            fightPalette[0x29] = Color.FromArgb(0xa2, 0x61, 0x41);
            fightPalette[0x2A] = Color.FromArgb(0x92, 0x51, 0x30);
            fightPalette[0x2B] = Color.FromArgb(0x71, 0x41, 0x30);
            fightPalette[0x2C] = Color.FromArgb(0x61, 0x30, 0x20);
            fightPalette[0x2D] = Color.FromArgb(0x51, 0x30, 0x20);
            fightPalette[0x2E] = Color.FromArgb(0xe3, 0xe3, 0xe3);
            fightPalette[0x2F] = Color.FromArgb(0xc3, 0xc3, 0xc3);

            fightPalette[0x30] = Color.FromArgb(0xb2, 0xb2, 0xb2);
            fightPalette[0x31] = Color.FromArgb(0xa2, 0xa2, 0xa2);
            fightPalette[0x32] = Color.FromArgb(0x82, 0x82, 0x82);
            fightPalette[0x33] = Color.FromArgb(0x71, 0x71, 0x71);
            fightPalette[0x34] = Color.FromArgb(0x51, 0x51, 0x51);
            fightPalette[0x35] = Color.FromArgb(0x41, 0x41, 0x41);
            fightPalette[0x36] = Color.FromArgb(0x00, 0xff, 0x00);
            fightPalette[0x37] = Color.FromArgb(0x00, 0x92, 0x00);

            fightPalette[0x38] = Color.FromArgb(0xf3, 0xe3, 0x00);
            fightPalette[0x39] = Color.FromArgb(0xd3, 0xb2, 0x00);
            fightPalette[0x3A] = Color.FromArgb(0xa2, 0x82, 0x00);
            fightPalette[0x3B] = Color.FromArgb(0xf3, 0x61, 0x41);
            fightPalette[0x3C] = Color.FromArgb(0xc3, 0x41, 0x20);
            fightPalette[0x3D] = Color.FromArgb(0x92, 0x30, 0x10);
            fightPalette[0x3E] = Color.FromArgb(0x41, 0x20, 0x10);
            fightPalette[0x3F] = Color.FromArgb(0xf3, 0xf3, 0xf3);

            fightPalette[0x40] = Color.FromArgb(0x00, 0x00, 0x00);
            fightPalette[0x41] = Color.FromArgb(0xe3, 0xc3, 0xa2);
            fightPalette[0x42] = Color.FromArgb(0xc3, 0x92, 0x71);
            fightPalette[0x43] = Color.FromArgb(0x92, 0x61, 0x41);
            fightPalette[0x44] = Color.FromArgb(0x82, 0x51, 0x30);
            fightPalette[0x45] = Color.FromArgb(0x61, 0x30, 0x20);
            fightPalette[0x46] = Color.FromArgb(0x51, 0x20, 0x10);
            fightPalette[0x47] = Color.FromArgb(0x30, 0x10, 0x00);

            fightPalette[0x48] = Color.FromArgb(0xf3, 0xe3, 0x00);
            fightPalette[0x49] = Color.FromArgb(0xe3, 0xa2, 0x00);
            fightPalette[0x4A] = Color.FromArgb(0xc3, 0x71, 0x00);
            fightPalette[0x4B] = Color.FromArgb(0xb2, 0x51, 0x00);
            fightPalette[0x4C] = Color.FromArgb(0xf3, 0x92, 0x00);
            fightPalette[0x4D] = Color.FromArgb(0xf3, 0x30, 0x00);
            fightPalette[0x4E] = Color.FromArgb(0xf3, 0x00, 0x20);
            fightPalette[0x4F] = Color.FromArgb(0xf3, 0x00, 0x82);

            fightPalette[0x50] = Color.FromArgb(0x00, 0x41, 0x00);
            fightPalette[0x51] = Color.FromArgb(0x00, 0x51, 0x00);
            fightPalette[0x52] = Color.FromArgb(0x00, 0x71, 0x00);
            fightPalette[0x53] = Color.FromArgb(0x10, 0x82, 0x00);
            fightPalette[0x54] = Color.FromArgb(0x10, 0xa2, 0x00);
            fightPalette[0x55] = Color.FromArgb(0x71, 0xe3, 0xf3);
            fightPalette[0x56] = Color.FromArgb(0x51, 0xb2, 0xd3);
            fightPalette[0x57] = Color.FromArgb(0x30, 0x71, 0xc3);

            fightPalette[0x58] = Color.FromArgb(0x10, 0x30, 0xa2);
            fightPalette[0x59] = Color.FromArgb(0x00, 0x00, 0x92);
            fightPalette[0x5A] = Color.FromArgb(0x41, 0x41, 0x41);
            fightPalette[0x5B] = Color.FromArgb(0x51, 0x51, 0x51);
            fightPalette[0x5C] = Color.FromArgb(0x71, 0x71, 0x71);
            fightPalette[0x5D] = Color.FromArgb(0x92, 0x92, 0x92);
            fightPalette[0x5E] = Color.FromArgb(0xc3, 0xc3, 0xc3);
            fightPalette[0x5F] = Color.FromArgb(0xf3, 0xf3, 0xf3);

            fightPalette[0x60] = Color.FromArgb(0x00, 0x00, 0x00);
            fightPalette[0x61] = Color.FromArgb(0x82, 0xb2, 0xb2);
            fightPalette[0x62] = Color.FromArgb(0x61, 0x82, 0x82);
            fightPalette[0x63] = Color.FromArgb(0x41, 0x61, 0x61);
            fightPalette[0x64] = Color.FromArgb(0x20, 0x41, 0x41);
            fightPalette[0x65] = Color.FromArgb(0x10, 0x20, 0x20);
            fightPalette[0x66] = Color.FromArgb(0x20, 0x10, 0x00);
            fightPalette[0x67] = Color.FromArgb(0xb2, 0x82, 0x41);

            fightPalette[0x68] = Color.FromArgb(0xa2, 0x71, 0x41);
            fightPalette[0x69] = Color.FromArgb(0x92, 0x71, 0x41);
            fightPalette[0x6A] = Color.FromArgb(0x92, 0x61, 0x30);
            fightPalette[0x6B] = Color.FromArgb(0x82, 0x51, 0x20);
            fightPalette[0x6C] = Color.FromArgb(0x82, 0x61, 0x30);
            fightPalette[0x6D] = Color.FromArgb(0x71, 0x51, 0x20);
            fightPalette[0x6E] = Color.FromArgb(0x61, 0x41, 0x20);
            fightPalette[0x6F] = Color.FromArgb(0x82, 0x30, 0x10);

            fightPalette[0x70] = Color.FromArgb(0x71, 0x30, 0x10);
            fightPalette[0x71] = Color.FromArgb(0x61, 0x30, 0x00);
            fightPalette[0x72] = Color.FromArgb(0x51, 0x20, 0x10);
            fightPalette[0x73] = Color.FromArgb(0x51, 0x41, 0x10);
            fightPalette[0x74] = Color.FromArgb(0x51, 0x30, 0x00);
            fightPalette[0x75] = Color.FromArgb(0x41, 0x10, 0x00);
            fightPalette[0x76] = Color.FromArgb(0x30, 0x10, 0x00);
            fightPalette[0x77] = Color.FromArgb(0x20, 0x20, 0x00);

            fightPalette[0x78] = Color.FromArgb(0x00, 0x82, 0x00);
            fightPalette[0x79] = Color.FromArgb(0x00, 0x71, 0x00);
            fightPalette[0x7A] = Color.FromArgb(0x00, 0x00, 0x00);
            fightPalette[0x7B] = Color.FromArgb(0x00, 0x61, 0x00);
            fightPalette[0x7C] = Color.FromArgb(0x30, 0x51, 0x00);
            fightPalette[0x7D] = Color.FromArgb(0x30, 0x41, 0x00);
            fightPalette[0x7E] = Color.FromArgb(0x30, 0x30, 0x00);
            fightPalette[0x7F] = Color.FromArgb(0x30, 0x20, 0x00);

            fightPalette[0x80] = Color.FromArgb(0x00, 0x00, 0x00);
            fightPalette[0x81] = Color.FromArgb(0xff, 0x00, 0x00);
            fightPalette[0x82] = Color.FromArgb(0x00, 0xff, 0x00);
            fightPalette[0x83] = Color.FromArgb(0x00, 0x00, 0xff);
            fightPalette[0x84] = Color.FromArgb(0xff, 0xff, 0x00);
            fightPalette[0x85] = Color.FromArgb(0xff, 0x00, 0xff);
            fightPalette[0x86] = Color.FromArgb(0x00, 0xff, 0xff);
            fightPalette[0x87] = Color.FromArgb(0xff, 0x7d, 0x7d);

            fightPalette[0x88] = Color.FromArgb(0x7d, 0x7d, 0xff);
            fightPalette[0x89] = Color.FromArgb(0x3c, 0x7d, 0x3c);
            fightPalette[0x8A] = Color.FromArgb(0x3c, 0x3c, 0x7d);
            fightPalette[0x8B] = Color.FromArgb(0x82, 0x14, 0x00);
            fightPalette[0x8C] = Color.FromArgb(0xff, 0x7d, 0x00);
            fightPalette[0x8D] = Color.FromArgb(0xff, 0x00, 0x7d);
            fightPalette[0x8E] = Color.FromArgb(0xa2, 0x8a, 0x00);
            fightPalette[0x8F] = Color.FromArgb(0x7d, 0x7d, 0x7d);

            fightPalette[0x90] = Color.FromArgb(0x82, 0x00, 0xcf);
            fightPalette[0x91] = Color.FromArgb(0x9e, 0x4d, 0x00);
            fightPalette[0x92] = Color.FromArgb(0x00, 0xc3, 0x00);
            fightPalette[0x93] = Color.FromArgb(0x28, 0x28, 0x28);
            fightPalette[0x94] = Color.FromArgb(0xaa, 0xb2, 0x71);
            fightPalette[0x95] = Color.FromArgb(0x82, 0x96, 0x51);
            fightPalette[0x96] = Color.FromArgb(0x5d, 0x79, 0x38);
            fightPalette[0x97] = Color.FromArgb(0x3c, 0x5d, 0x24);

            fightPalette[0x98] = Color.FromArgb(0x20, 0x41, 0x14);
            fightPalette[0x99] = Color.FromArgb(0xcb, 0x96, 0x0c);
            fightPalette[0x9A] = Color.FromArgb(0xa6, 0x79, 0x08);
            fightPalette[0x9B] = Color.FromArgb(0x82, 0x5d, 0x08);
            fightPalette[0x9C] = Color.FromArgb(0x10, 0x3c, 0x61);
            fightPalette[0x9D] = Color.FromArgb(0x14, 0x51, 0x7d);
            fightPalette[0x9E] = Color.FromArgb(0x14, 0x69, 0x9a);
            fightPalette[0x9F] = Color.FromArgb(0x18, 0x7d, 0xb6);

            fightPalette[0xA0] = Color.FromArgb(0x00, 0x00, 0x00);
            fightPalette[0xA1] = Color.FromArgb(0x14, 0x34, 0xa2);
            fightPalette[0xA2] = Color.FromArgb(0x18, 0x41, 0xcb);
            fightPalette[0xA3] = Color.FromArgb(0xff, 0x00, 0xff);
            fightPalette[0xA4] = Color.FromArgb(0xff, 0x00, 0xff);
            fightPalette[0xA5] = Color.FromArgb(0xb6, 0xb6, 0xe3);
            fightPalette[0xA6] = Color.FromArgb(0xa6, 0xa6, 0xdb);
            fightPalette[0xA7] = Color.FromArgb(0x9a, 0x9a, 0xd3);

            fightPalette[0xA8] = Color.FromArgb(0x8e, 0x8e, 0xcb);
            fightPalette[0xA9] = Color.FromArgb(0x86, 0x82, 0xc7);
            fightPalette[0xAA] = Color.FromArgb(0x7d, 0x79, 0xbe);
            fightPalette[0xAB] = Color.FromArgb(0x71, 0x6d, 0xb6);
            fightPalette[0xAC] = Color.FromArgb(0x69, 0x65, 0xb2);
            fightPalette[0xAD] = Color.FromArgb(0x65, 0x59, 0xaa);
            fightPalette[0xAE] = Color.FromArgb(0x59, 0x51, 0xa2);
            fightPalette[0xAF] = Color.FromArgb(0x55, 0x49, 0x9e);

            fightPalette[0xB0] = Color.FromArgb(0x4d, 0x41, 0x96);
            fightPalette[0xB1] = Color.FromArgb(0x45, 0x38, 0x8a);
            fightPalette[0xB2] = Color.FromArgb(0x41, 0x30, 0x82);
            fightPalette[0xB3] = Color.FromArgb(0x38, 0x2c, 0x79);
            fightPalette[0xB4] = Color.FromArgb(0x38, 0x24, 0x6d);
            fightPalette[0xB5] = Color.FromArgb(0x30, 0x20, 0x65);
            fightPalette[0xB6] = Color.FromArgb(0x2c, 0x18, 0x59);
            fightPalette[0xB7] = Color.FromArgb(0xff, 0x00, 0xff);

            fightPalette[0xB8] = Color.FromArgb(0xff, 0x00, 0xff);
            fightPalette[0xB9] = Color.FromArgb(0xff, 0x00, 0xff);
            fightPalette[0xBA] = Color.FromArgb(0xff, 0x00, 0xff);
            fightPalette[0xBB] = Color.FromArgb(0xff, 0x00, 0xff);
            fightPalette[0xBC] = Color.FromArgb(0xd3, 0xc3, 0xeb);
            fightPalette[0xBD] = Color.FromArgb(0xf3, 0xdb, 0xf3);
            fightPalette[0xBE] = Color.FromArgb(0xff, 0xf3, 0xf3);
            fightPalette[0xBF] = Color.FromArgb(0xff, 0xff, 0xff);

            fightPalette[0xC0] = Color.FromArgb(0x00, 0x41, 0x00);
            fightPalette[0xC1] = Color.FromArgb(0x00, 0x41, 0x10);
            fightPalette[0xC2] = Color.FromArgb(0x00, 0x41, 0x20);
            fightPalette[0xC3] = Color.FromArgb(0x00, 0x41, 0x30);
            fightPalette[0xC4] = Color.FromArgb(0x00, 0x41, 0x41);
            fightPalette[0xC5] = Color.FromArgb(0x00, 0x30, 0x41);
            fightPalette[0xC6] = Color.FromArgb(0x00, 0x20, 0x41);
            fightPalette[0xC7] = Color.FromArgb(0x00, 0x10, 0x41);

            fightPalette[0xC8] = Color.FromArgb(0xc3, 0x00, 0x00);
            fightPalette[0xC9] = Color.FromArgb(0xc3, 0xc3, 0x00);
            fightPalette[0xCA] = Color.FromArgb(0x00, 0x00, 0xc3);
            fightPalette[0xCB] = Color.FromArgb(0x38, 0x20, 0x41);
            fightPalette[0xCC] = Color.FromArgb(0x41, 0x20, 0x41);
            fightPalette[0xCD] = Color.FromArgb(0x41, 0x20, 0x38);
            fightPalette[0xCE] = Color.FromArgb(0x41, 0x20, 0x30);
            fightPalette[0xCF] = Color.FromArgb(0x41, 0x20, 0x28);

            //fightPalette[0x00] = Color.FromArgb(0x412020);
            //fightPalette[0x00] = Color.FromArgb(0x412820);
            //fightPalette[0x00] = Color.FromArgb(0x413020);
            //fightPalette[0x00] = Color.FromArgb(0x413820);
            //fightPalette[0x00] = Color.FromArgb(0x414120);
            //fightPalette[0x00] = Color.FromArgb(0x384120);
            //fightPalette[0x00] = Color.FromArgb(0x304120);
            //fightPalette[0x00] = Color.FromArgb(0x284120);
            //fightPalette[0x00] = Color.FromArgb(0x000000);
            //fightPalette[0x00] = Color.FromArgb(0xe3c3a2);
            //fightPalette[0x00] = Color.FromArgb(0xe3c341);
            //fightPalette[0x00] = Color.FromArgb(0xc3a230);
            //fightPalette[0x00] = Color.FromArgb(0xb29220);
            //fightPalette[0x00] = Color.FromArgb(0xa28210);
            //fightPalette[0x00] = Color.FromArgb(0x615100);
            //fightPalette[0x00] = Color.FromArgb(0x2c6530);
            //fightPalette[0x00] = Color.FromArgb(0x000000);
            //fightPalette[0x00] = Color.FromArgb(0xe3e3e3);
            //fightPalette[0x00] = Color.FromArgb(0xd3d3d3);
            //fightPalette[0x00] = Color.FromArgb(0xc3c3c3);
            //fightPalette[0x00] = Color.FromArgb(0xb2b2b2);
            //fightPalette[0x00] = Color.FromArgb(0xa2a2a2);
            //fightPalette[0x00] = Color.FromArgb(0x929292);
            //fightPalette[0x00] = Color.FromArgb(0x828282);
            //fightPalette[0x00] = Color.FromArgb(0x717171);
            //fightPalette[0x00] = Color.FromArgb(0x616161);
            //fightPalette[0x00] = Color.FromArgb(0x515151);
            //fightPalette[0x00] = Color.FromArgb(0x414141);
            //fightPalette[0x00] = Color.FromArgb(0x303030);
            //fightPalette[0x00] = Color.FromArgb(0x202020);
            //fightPalette[0x00] = Color.FromArgb(0x101010);
            //fightPalette[0x00] = Color.FromArgb(0x000000);
            //fightPalette[0x00] = Color.FromArgb(0x00f320);
            //fightPalette[0x00] = Color.FromArgb(0xf3c3a2);
            //fightPalette[0x00] = Color.FromArgb(0xf3b2a2);
            //fightPalette[0x00] = Color.FromArgb(0xb27161);
            //fightPalette[0x00] = Color.FromArgb(0x925141);
            //fightPalette[0x00] = Color.FromArgb(0x714130);
            //fightPalette[0x00] = Color.FromArgb(0x512020);
            //fightPalette[0x00] = Color.FromArgb(0x301010);
            //fightPalette[0x00] = Color.FromArgb(0x302000);
            //fightPalette[0x00] = Color.FromArgb(0xb20000);
            //fightPalette[0x00] = Color.FromArgb(0x000069);
            //fightPalette[0x00] = Color.FromArgb(0x000061);
            //fightPalette[0x00] = Color.FromArgb(0x000071);
            //fightPalette[0x00] = Color.FromArgb(0x000061);
            //fightPalette[0x00] = Color.FromArgb(0xf3f300);
            //fightPalette[0x00] = Color.FromArgb(0xf3f3f3);

            //for (int i = 0; i <= 255; i++)
            //    fightPalette[i] = Color.FromArgb(255, 0, 0);
        }
        static private void initAtticPalette()
        {
            //0x00 - 0x45 ist bei jedem logo anders + 0xF0-0xFF
            AtticPalette = (Color[])defaultPalette.Clone();

            AtticPalette[0x00] = Color.FromArgb(0x00, 0x00, 0x00);
            AtticPalette[0x01] = Color.FromArgb(0x92, 0x92, 0xf3);
            AtticPalette[0x02] = Color.FromArgb(0x71, 0x71, 0xe3);
            AtticPalette[0x03] = Color.FromArgb(0x61, 0x61, 0xd3);
            AtticPalette[0x04] = Color.FromArgb(0x51, 0x51, 0xc3);
            AtticPalette[0x05] = Color.FromArgb(0x30, 0x41, 0xa2);
            AtticPalette[0x06] = Color.FromArgb(0x30, 0x30, 0x92);
            AtticPalette[0x07] = Color.FromArgb(0x20, 0x20, 0x82);

            AtticPalette[0x08] = Color.FromArgb(0x10, 0x10, 0x71);
            AtticPalette[0x09] = Color.FromArgb(0x00, 0x00, 0x61);
            AtticPalette[0x0A] = Color.FromArgb(0x00, 0x00, 0x51);
            AtticPalette[0x0B] = Color.FromArgb(0xf3, 0xc3, 0xa2);
            AtticPalette[0x0C] = Color.FromArgb(0xd3, 0xd3, 0xf3);
            AtticPalette[0x0D] = Color.FromArgb(0xc3, 0xc3, 0xf3);
            AtticPalette[0x0E] = Color.FromArgb(0xa2, 0xa2, 0xf3);
            AtticPalette[0x0F] = Color.FromArgb(0x82, 0x9a, 0xf3);

            AtticPalette[0x10] = Color.FromArgb(0x00, 0x00, 0x00);
            AtticPalette[0x11] = Color.FromArgb(0x14, 0x14, 0x14);
            AtticPalette[0x12] = Color.FromArgb(0x20, 0x20, 0x20);
            AtticPalette[0x13] = Color.FromArgb(0x2c, 0x2c, 0x2c);
            AtticPalette[0x14] = Color.FromArgb(0x38, 0x38, 0x38);
            AtticPalette[0x15] = Color.FromArgb(0x45, 0x45, 0x45);
            AtticPalette[0x16] = Color.FromArgb(0x51, 0x51, 0x51);
            AtticPalette[0x17] = Color.FromArgb(0x61, 0x61, 0x61);

            AtticPalette[0x18] = Color.FromArgb(0x71, 0x71, 0x71);
            AtticPalette[0x19] = Color.FromArgb(0x82, 0x82, 0x82);
            AtticPalette[0x1A] = Color.FromArgb(0x92, 0x92, 0x92);
            AtticPalette[0x1B] = Color.FromArgb(0xa2, 0xa2, 0xa2);
            AtticPalette[0x1C] = Color.FromArgb(0xb6, 0xb6, 0xb6);
            AtticPalette[0x1D] = Color.FromArgb(0xcb, 0xcb, 0xcb);
            AtticPalette[0x1E] = Color.FromArgb(0xe3, 0xe3, 0xe3);
            AtticPalette[0x1F] = Color.FromArgb(0xff, 0xff, 0xff);
            
            //AtticPalette[0x20] = Color.FromArgb(0x00,0000
            //AtticPalette[0x00] = Color.FromArgb(0x00,00ff
            //AtticPalette[0x00] = Color.FromArgb(0x00,0092
            //AtticPalette[0x00] = Color.FromArgb(0xf3,c3a2
            //AtticPalette[0x00] = Color.FromArgb(0xf3,b292
            //AtticPalette[0x00] = Color.FromArgb(0xf3,a271
            //AtticPalette[0x00] = Color.FromArgb(0xe3,9261
            //AtticPalette[0x00] = Color.FromArgb(0xd3,8251
            //AtticPalette[0x00] = Color.FromArgb(0xc3,7151
            //AtticPalette[0x00] = Color.FromArgb(0xa2,6141
            //AtticPalette[0x00] = Color.FromArgb(0x92,5130
            //AtticPalette[0x00] = Color.FromArgb(0x71,4130
            //AtticPalette[0x00] = Color.FromArgb(0x61,3020
            //AtticPalette[0x00] = Color.FromArgb(0x51,3020
            //AtticPalette[0x00] = Color.FromArgb(0xe3,e3e3
            //AtticPalette[0x00] = Color.FromArgb(0xc3,c3c3
            //AtticPalette[0x00] = Color.FromArgb(0xb2,b2b2
            //AtticPalette[0x00] = Color.FromArgb(0xa2,a2a2
            //AtticPalette[0x00] = Color.FromArgb(0x828282
            //AtticPalette[0x00] = Color.FromArgb(0x717171
            //AtticPalette[0x00] = Color.FromArgb(0x515151
            //AtticPalette[0x00] = Color.FromArgb(0x414141
            //AtticPalette[0x00] = Color.FromArgb(0x00ff00
            //AtticPalette[0x00] = Color.FromArgb(0x009200
            //AtticPalette[0x00] = Color.FromArgb(0xf3e300
            //AtticPalette[0x00] = Color.FromArgb(0xd3b200
            //AtticPalette[0x00] = Color.FromArgb(0xa28200
            //AtticPalette[0x00] = Color.FromArgb(0xf36141
            //AtticPalette[0x00] = Color.FromArgb(0xc34120
            //AtticPalette[0x00] = Color.FromArgb(0x923010
            //AtticPalette[0x00] = Color.FromArgb(0x412010
            //AtticPalette[0x00] = Color.FromArgb(0xf3f3f3
            //AtticPalette[0x00] = Color.FromArgb(0x000000
            //AtticPalette[0x00] = Color.FromArgb(0xe3e3e3
            //AtticPalette[0x00] = Color.FromArgb(0xd3d3d3
            //AtticPalette[0x00] = Color.FromArgb(0xc3c3c3
            //AtticPalette[0x00] = Color.FromArgb(0xb2b2b2
            //AtticPalette[0x00] = Color.FromArgb(0xa2a2a2
            //AtticPalette[0x00] = Color.FromArgb(0x929292
            //AtticPalette[0x00] = Color.FromArgb(0x828282
            //AtticPalette[0x00] = Color.FromArgb(0x717171
            //AtticPalette[0x00] = Color.FromArgb(0x616161
            //AtticPalette[0x00] = Color.FromArgb(0x515151
            //AtticPalette[0x00] = Color.FromArgb(0x414141
            //AtticPalette[0x00] = Color.FromArgb(0x303030
            //AtticPalette[0x00] = Color.FromArgb(0x202020
            //AtticPalette[0x00] = Color.FromArgb(0xf3f3f3
            //AtticPalette[0x00] = Color.FromArgb(0xf3d361
            //AtticPalette[0x00] = Color.FromArgb(0xf3d320
            //AtticPalette[0x00] = Color.FromArgb(0xf3d300
            //AtticPalette[0x00] = Color.FromArgb(0xe3c300
            //AtticPalette[0x00] = Color.FromArgb(0xd3b200
            //AtticPalette[0x00] = Color.FromArgb(0xc3a200
            //AtticPalette[0x00] = Color.FromArgb(0xb29200
            //AtticPalette[0x00] = Color.FromArgb(0xa28200
            //AtticPalette[0x00] = Color.FromArgb(0x927100
            //AtticPalette[0x00] = Color.FromArgb(0x826100
            //AtticPalette[0x00] = Color.FromArgb(0x715100
            //AtticPalette[0x00] = Color.FromArgb(0xe35130
            //AtticPalette[0x00] = Color.FromArgb(0xd33000
            //AtticPalette[0x00] = Color.FromArgb(0xb22000
            //AtticPalette[0x00] = Color.FromArgb(0x921000
            //AtticPalette[0x00] = Color.FromArgb(0x710000
            //AtticPalette[0x00] = Color.FromArgb(0x510000
            //AtticPalette[0x00] = Color.FromArgb(0xb6ffb6
            //AtticPalette[0x00] = Color.FromArgb(0xb6ffc7
            //AtticPalette[0x00] = Color.FromArgb(0xb6ffdb
            //AtticPalette[0x00] = Color.FromArgb(0xb6ffeb
            //AtticPalette[0x00] = Color.FromArgb(0xb6ffff
            //AtticPalette[0x00] = Color.FromArgb(0xb6ebff
            //AtticPalette[0x00] = Color.FromArgb(0xb6dbff
            //AtticPalette[0x00] = Color.FromArgb(0xb6c7ff
            //AtticPalette[0x00] = Color.FromArgb(0x000071
            //AtticPalette[0x00] = Color.FromArgb(0x1c0071
            //AtticPalette[0x00] = Color.FromArgb(0x380071
            //AtticPalette[0x00] = Color.FromArgb(0x550071
            //AtticPalette[0x00] = Color.FromArgb(0x710071
            //AtticPalette[0x00] = Color.FromArgb(0x710055
            //AtticPalette[0x00] = Color.FromArgb(0x710038
            //AtticPalette[0x00] = Color.FromArgb(0x71001c
            //AtticPalette[0x00] = Color.FromArgb(0x710000
            //AtticPalette[0x00] = Color.FromArgb(0x711c00
            //AtticPalette[0x00] = Color.FromArgb(0x713800
            //AtticPalette[0x00] = Color.FromArgb(0x715500
            //AtticPalette[0x00] = Color.FromArgb(0x717100
            //AtticPalette[0x00] = Color.FromArgb(0x557100
            //AtticPalette[0x00] = Color.FromArgb(0x387100
            //AtticPalette[0x00] = Color.FromArgb(0x1c7100
            //AtticPalette[0x00] = Color.FromArgb(0x007100
            //AtticPalette[0x00] = Color.FromArgb(0x00711c
            //AtticPalette[0x00] = Color.FromArgb(0x007138
            //AtticPalette[0x00] = Color.FromArgb(0x007155
            //AtticPalette[0x00] = Color.FromArgb(0x007171
            //AtticPalette[0x00] = Color.FromArgb(0x005571
            //AtticPalette[0x00] = Color.FromArgb(0x003871
            //AtticPalette[0x00] = Color.FromArgb(0x001c71
            //AtticPalette[0x00] = Color.FromArgb(0x383871
            //AtticPalette[0x00] = Color.FromArgb(0x453871
            //AtticPalette[0x00] = Color.FromArgb(0x553871
            //AtticPalette[0x00] = Color.FromArgb(0x613871
            //AtticPalette[0x00] = Color.FromArgb(0x713871
            //AtticPalette[0x00] = Color.FromArgb(0x713861
            //AtticPalette[0x00] = Color.FromArgb(0x713855
            //AtticPalette[0x00] = Color.FromArgb(0x713845
            //AtticPalette[0x00] = Color.FromArgb(0x713838
            //AtticPalette[0x00] = Color.FromArgb(0x714538
            //AtticPalette[0x00] = Color.FromArgb(0x715538
            //AtticPalette[0x00] = Color.FromArgb(0x716138
            //AtticPalette[0x00] = Color.FromArgb(0x717138
            //AtticPalette[0x00] = Color.FromArgb(0x617138
            //AtticPalette[0x00] = Color.FromArgb(0x557138
            //AtticPalette[0x00] = Color.FromArgb(0x457138
            //AtticPalette[0x00] = Color.FromArgb(0x387138
            //AtticPalette[0x00] = Color.FromArgb(0x387145
            //AtticPalette[0x00] = Color.FromArgb(0x387155
            //AtticPalette[0x00] = Color.FromArgb(0x387161
            //AtticPalette[0x00] = Color.FromArgb(0x387171
            //AtticPalette[0x00] = Color.FromArgb(0x386171
            //AtticPalette[0x00] = Color.FromArgb(0x385571
            //AtticPalette[0x00] = Color.FromArgb(0x384571
            //AtticPalette[0x00] = Color.FromArgb(0x515171
            //AtticPalette[0x00] = Color.FromArgb(0x595171
            //AtticPalette[0x00] = Color.FromArgb(0x615171
            //AtticPalette[0x00] = Color.FromArgb(0x695171
            //AtticPalette[0x00] = Color.FromArgb(0x715171
            //AtticPalette[0x00] = Color.FromArgb(0x715169
            //AtticPalette[0x00] = Color.FromArgb(0x715161
            //AtticPalette[0x00] = Color.FromArgb(0x715159
            //AtticPalette[0x00] = Color.FromArgb(0x715151
            //AtticPalette[0x00] = Color.FromArgb(0x715951
            //AtticPalette[0x00] = Color.FromArgb(0x716151
            //AtticPalette[0x00] = Color.FromArgb(0x716951
            //AtticPalette[0x00] = Color.FromArgb(0x717151
            //AtticPalette[0x00] = Color.FromArgb(0x697151
            //AtticPalette[0x00] = Color.FromArgb(0x617151
            //AtticPalette[0x00] = Color.FromArgb(0x597151
            //AtticPalette[0x00] = Color.FromArgb(0x517151
            //AtticPalette[0x00] = Color.FromArgb(0x517159
            //AtticPalette[0x00] = Color.FromArgb(0x517161
            //AtticPalette[0x00] = Color.FromArgb(0x517169
            //AtticPalette[0x00] = Color.FromArgb(0x517171
            //AtticPalette[0x00] = Color.FromArgb(0x516971
            //AtticPalette[0x00] = Color.FromArgb(0x516171
            //AtticPalette[0x00] = Color.FromArgb(0x515971
            //AtticPalette[0x00] = Color.FromArgb(0x000041
            //AtticPalette[0x00] = Color.FromArgb(0x100041
            //AtticPalette[0x00] = Color.FromArgb(0x200041
            //AtticPalette[0x00] = Color.FromArgb(0x300041
            //AtticPalette[0x00] = Color.FromArgb(0x410041
            //AtticPalette[0x00] = Color.FromArgb(0x410030
            //AtticPalette[0x00] = Color.FromArgb(0x410020
            //AtticPalette[0x00] = Color.FromArgb(0x410010
            //AtticPalette[0x00] = Color.FromArgb(0x410000
            //AtticPalette[0x00] = Color.FromArgb(0x411000
            //AtticPalette[0x00] = Color.FromArgb(0x412000
            //AtticPalette[0x00] = Color.FromArgb(0x413000
            //AtticPalette[0x00] = Color.FromArgb(0x414100
            //AtticPalette[0x00] = Color.FromArgb(0x304100
            //AtticPalette[0x00] = Color.FromArgb(0x204100
            //AtticPalette[0x00] = Color.FromArgb(0x104100
            //AtticPalette[0x00] = Color.FromArgb(0x004100
            //AtticPalette[0x00] = Color.FromArgb(0x004110
            //AtticPalette[0x00] = Color.FromArgb(0x004120
            //AtticPalette[0x00] = Color.FromArgb(0x004130
            //AtticPalette[0x00] = Color.FromArgb(0x004141
            //AtticPalette[0x00] = Color.FromArgb(0x003041
            //AtticPalette[0x00] = Color.FromArgb(0x002041
            //AtticPalette[0x00] = Color.FromArgb(0x001041
            //AtticPalette[0x00] = Color.FromArgb(0xa20000
            //AtticPalette[0x00] = Color.FromArgb(0xa2a200
            //AtticPalette[0x00] = Color.FromArgb(0x0000a2
            //AtticPalette[0x00] = Color.FromArgb(0x382041
            //AtticPalette[0x00] = Color.FromArgb(0x412041
            //AtticPalette[0x00] = Color.FromArgb(0x412038
            //AtticPalette[0x00] = Color.FromArgb(0x412030
            //AtticPalette[0x00] = Color.FromArgb(0x412028
            //AtticPalette[0x00] = Color.FromArgb(0x412020
            //AtticPalette[0x00] = Color.FromArgb(0x412820
            //AtticPalette[0x00] = Color.FromArgb(0x413020
            //AtticPalette[0x00] = Color.FromArgb(0x413820
            //AtticPalette[0x00] = Color.FromArgb(0x414120
            //AtticPalette[0x00] = Color.FromArgb(0x384120
            //AtticPalette[0x00] = Color.FromArgb(0x304120
            //AtticPalette[0x00] = Color.FromArgb(0x284120
            //AtticPalette[0x00] = Color.FromArgb(0x000000
            //AtticPalette[0x00] = Color.FromArgb(0xe3c3a2
            //AtticPalette[0x00] = Color.FromArgb(0xe3c341
            //AtticPalette[0x00] = Color.FromArgb(0xc3a230
            //AtticPalette[0x00] = Color.FromArgb(0xb29220
            //AtticPalette[0x00] = Color.FromArgb(0xa28210
            //AtticPalette[0x00] = Color.FromArgb(0x615100
            //AtticPalette[0x00] = Color.FromArgb(0x2c6530
            //AtticPalette[0x00] = Color.FromArgb(0x2c2c41
            //AtticPalette[0x00] = Color.FromArgb(0x302c41
            //AtticPalette[0x00] = Color.FromArgb(0x342c41
            //AtticPalette[0x00] = Color.FromArgb(0x3c2c41
            //AtticPalette[0x00] = Color.FromArgb(0x412c41
            //AtticPalette[0x00] = Color.FromArgb(0x412c3c
            //AtticPalette[0x00] = Color.FromArgb(0x412c34
            //AtticPalette[0x00] = Color.FromArgb(0x412c30
            //AtticPalette[0x00] = Color.FromArgb(0x412c2c
            //AtticPalette[0x00] = Color.FromArgb(0x41302c
            //AtticPalette[0x00] = Color.FromArgb(0x41342c
            //AtticPalette[0x00] = Color.FromArgb(0x413c2c
            //AtticPalette[0x00] = Color.FromArgb(0x41412c
            //AtticPalette[0x00] = Color.FromArgb(0x3c412c
            //AtticPalette[0x00] = Color.FromArgb(0x34412c
            //AtticPalette[0x00] = Color.FromArgb(0x30412c
            //AtticPalette[0x00] = Color.FromArgb(0x2c412c
            //AtticPalette[0x00] = Color.FromArgb(0x2c4130
            //AtticPalette[0x00] = Color.FromArgb(0x2c4134
            //AtticPalette[0x00] = Color.FromArgb(0x2c413c
            //AtticPalette[0x00] = Color.FromArgb(0x2c4141
            //AtticPalette[0x00] = Color.FromArgb(0x2c3c41
            //AtticPalette[0x00] = Color.FromArgb(0x2c3441
            //AtticPalette[0x00] = Color.FromArgb(0x2c3041
            //AtticPalette[0x00] = Color.FromArgb(0x000000
            //AtticPalette[0x00] = Color.FromArgb(0x000000
            //AtticPalette[0x00] = Color.FromArgb(0x000000
            //AtticPalette[0x00] = Color.FromArgb(0x000000
            //AtticPalette[0x00] = Color.FromArgb(0x000000
            //AtticPalette[0x00] = Color.FromArgb(0x000000
            //AtticPalette[0x00] = Color.FromArgb(0x000000
            //AtticPalette[0x00] = Color.FromArgb(0xffffff
        }
        static private void initGENPalette()
        {
            //0x00 - 0x45 ist bei jedem logo anders + 0xF0-0xFF
            GENPalette = (Color[])defaultPalette.Clone();

            //-------------------------------------------------
            //    DSALOGO.DAT(Palettenbereich:0x00-0x2F)
            //    GENTIT.DAT (Palettenbereich:0x00-0x2F)
            //-------------------------------------------------
            GENPalette[0x00] = Color.FromArgb(0x00, 0x00, 0x00);
            GENPalette[0x01] = Color.FromArgb(0xe3, 0xe3, 0xe3);
            GENPalette[0x02] = Color.FromArgb(0xd3, 0xd3, 0xd3);
            GENPalette[0x03] = Color.FromArgb(0xc3, 0xc3, 0xc3);
            GENPalette[0x04] = Color.FromArgb(0xb2, 0xb2, 0xb2);
            GENPalette[0x05] = Color.FromArgb(0xa2, 0xa2, 0xa2);
            GENPalette[0x06] = Color.FromArgb(0x92, 0x92, 0x92);
            GENPalette[0x07] = Color.FromArgb(0x82, 0x82, 0x82);
            GENPalette[0x08] = Color.FromArgb(0x71, 0x71, 0x71);
            GENPalette[0x09] = Color.FromArgb(0x61, 0x61, 0x61);
            GENPalette[0x0A] = Color.FromArgb(0x51, 0x51, 0x51);
            GENPalette[0x0B] = Color.FromArgb(0x41, 0x41, 0x41);
            GENPalette[0x0C] = Color.FromArgb(0x30, 0x30, 0x30);
            GENPalette[0x0D] = Color.FromArgb(0x20, 0x20, 0x20);
            GENPalette[0x0E] = Color.FromArgb(0x10, 0x10, 0x10);
            GENPalette[0x0F] = Color.FromArgb(0xb2, 0x00, 0xb2);

            GENPalette[0x10] = Color.FromArgb(0xb2, 0x00, 0xb2);
            GENPalette[0x11] = Color.FromArgb(0xb2, 0x00, 0xb2);
            GENPalette[0x12] = Color.FromArgb(0xb2, 0x00, 0xb2);
            GENPalette[0x13] = Color.FromArgb(0xb2, 0x00, 0xb2);
            GENPalette[0x14] = Color.FromArgb(0xb2, 0x00, 0xb2);
            GENPalette[0x15] = Color.FromArgb(0xf3, 0xc3, 0xc3);
            GENPalette[0x16] = Color.FromArgb(0xe3, 0xa2, 0xa2);
            GENPalette[0x17] = Color.FromArgb(0xd3, 0x61, 0x61);
            GENPalette[0x18] = Color.FromArgb(0xc3, 0x30, 0x30);
            GENPalette[0x19] = Color.FromArgb(0xb2, 0x00, 0x00);
            GENPalette[0x1A] = Color.FromArgb(0xa2, 0x00, 0x00);
            GENPalette[0x1B] = Color.FromArgb(0x92, 0x00, 0x00);
            GENPalette[0x1C] = Color.FromArgb(0x71, 0x00, 0x00);
            GENPalette[0x1D] = Color.FromArgb(0x61, 0x00, 0x00);
            GENPalette[0x1E] = Color.FromArgb(0x51, 0x00, 0x00);
            GENPalette[0x1F] = Color.FromArgb(0xf3, 0xf3, 0xf3);

            GENPalette[0x20] = Color.FromArgb(0x00, 0x00, 0x00);
            GENPalette[0x21] = Color.FromArgb(0x00, 0x00, 0xff);
            GENPalette[0x22] = Color.FromArgb(0x00, 0x00, 0x92);
            GENPalette[0x23] = Color.FromArgb(0xf3, 0xc3, 0xa2);
            GENPalette[0x24] = Color.FromArgb(0xf3, 0xb2, 0x92);
            GENPalette[0x25] = Color.FromArgb(0xf3, 0xa2, 0x71);
            GENPalette[0x26] = Color.FromArgb(0xe3, 0x92, 0x61);
            GENPalette[0x27] = Color.FromArgb(0xd3, 0x82, 0x51);
            GENPalette[0x28] = Color.FromArgb(0xc3, 0x71, 0x51);
            GENPalette[0x29] = Color.FromArgb(0xa2, 0x61, 0x41);
            GENPalette[0x2A] = Color.FromArgb(0x92, 0x51, 0x30);
            GENPalette[0x2B] = Color.FromArgb(0x71, 0x41, 0x30);
            GENPalette[0x2C] = Color.FromArgb(0x61, 0x30, 0x20);
            GENPalette[0x2D] = Color.FromArgb(0x51, 0x30, 0x20);
            GENPalette[0x2E] = Color.FromArgb(0xe3, 0xe3, 0xe3);
            GENPalette[0x2F] = Color.FromArgb(0xc3, 0xc3, 0xc3);

            //-------------------------------------------------

            //GENPalette[0x30] = Color.FromArgb(0xb2b2b2
            //GENPalette[0x31] = Color.FromArgb(0xa2a2a2
            //GENPalette[0x32] = Color.FromArgb(0x828282
            //GENPalette[0x33] = Color.FromArgb(0x717171
            //GENPalette[0x34] = Color.FromArgb(0x515151
            //GENPalette[0x35] = Color.FromArgb(0x414141
            //GENPalette[0x36] = Color.FromArgb(0x00ff00
            //GENPalette[0x37] = Color.FromArgb(0x009200
            //GENPalette[0x38] = Color.FromArgb(0xf3e300
            //GENPalette[0x39] = Color.FromArgb(0xd3b200
            //GENPalette[0x3A] = Color.FromArgb(0xa28200
            //GENPalette[0x3B] = Color.FromArgb(0xf36141
            //GENPalette[0x3C] = Color.FromArgb(0xc34120
            //GENPalette[0x3D] = Color.FromArgb(0x923010
            //GENPalette[0x3E] = Color.FromArgb(0x412010
            //GENPalette[0x3F] = Color.FromArgb(0xf3f3f3
            
            //GENPalette[0x40] = Color.FromArgb(0x000000
            //GENPalette[0x41] = Color.FromArgb(0xe3e3e3
            //GENPalette[0x42] = Color.FromArgb(0xd3d3d3
            //GENPalette[0x43] = Color.FromArgb(0xc3c3c3
            //GENPalette[0x44] = Color.FromArgb(0xb2b2b2
            //GENPalette[0x45] = Color.FromArgb(0xa2a2a2
            //GENPalette[0x46] = Color.FromArgb(0x929292
            //GENPalette[0x47] = Color.FromArgb(0x828282
            //GENPalette[0x48] = Color.FromArgb(0x717171
            //GENPalette[0x49] = Color.FromArgb(0x616161
            //GENPalette[0x4A] = Color.FromArgb(0x515151
            //GENPalette[0x4B] = Color.FromArgb(0x414141
            //GENPalette[0x4C] = Color.FromArgb(0x303030
            //GENPalette[0x4D] = Color.FromArgb(0x202020
            //GENPalette[0x4E] = Color.FromArgb(0xf3f3f3
            //GENPalette[0x4F] = Color.FromArgb(0xf3d361
            
            //GENPalette[0x50] = Color.FromArgb(0xf3d320
            //GENPalette[0x51] = Color.FromArgb(0xf3d300
            //GENPalette[0x52] = Color.FromArgb(0xe3c300
            //GENPalette[0x53] = Color.FromArgb(0xd3b200
            //GENPalette[0x54] = Color.FromArgb(0xc3a200
            //GENPalette[0x55] = Color.FromArgb(0xb29200
            //GENPalette[0x56] = Color.FromArgb(0xa28200
            //GENPalette[0x57] = Color.FromArgb(0x927100
            //GENPalette[0x58] = Color.FromArgb(0x826100
            //GENPalette[0x59] = Color.FromArgb(0x715100
            //GENPalette[0x5A] = Color.FromArgb(0xe35130
            //GENPalette[0x5B] = Color.FromArgb(0xd33000
            //GENPalette[0x5C] = Color.FromArgb(0xb22000
            //GENPalette[0x5D] = Color.FromArgb(0x921000
            //GENPalette[0x5E] = Color.FromArgb(0x710000
            //GENPalette[0x5F] = Color.FromArgb(0x510000
            
            //GENPalette[0x60] = Color.FromArgb(0xb6ffb6
            //GENPalette[0x61] = Color.FromArgb(0xb6ffc7
            //GENPalette[0x62] = Color.FromArgb(0xb6ffdb
            //GENPalette[0x63] = Color.FromArgb(0xb6ffeb
            //GENPalette[0x64] = Color.FromArgb(0xb6ffff
            //GENPalette[0x65] = Color.FromArgb(0xb6ebff
            //GENPalette[0x66] = Color.FromArgb(0xb6dbff
            //GENPalette[0x67] = Color.FromArgb(0xb6c7ff
            //GENPalette[0x68] = Color.FromArgb(0x000071
            //GENPalette[0x69] = Color.FromArgb(0x1c0071
            //GENPalette[0x6A] = Color.FromArgb(0x380071
            //GENPalette[0x6B] = Color.FromArgb(0x550071
            //GENPalette[0x6C] = Color.FromArgb(0x710071
            //GENPalette[0x6D] = Color.FromArgb(0x710055
            //GENPalette[0x6E] = Color.FromArgb(0x710038
            //GENPalette[0x6F] = Color.FromArgb(0x71001c
            
            //GENPalette[0x70] = Color.FromArgb(0x710000
            //GENPalette[0x71] = Color.FromArgb(0x711c00
            //GENPalette[0x72] = Color.FromArgb(0x713800
            //GENPalette[0x73] = Color.FromArgb(0x715500
            //GENPalette[0x74] = Color.FromArgb(0x717100
            //GENPalette[0x75] = Color.FromArgb(0x557100
            //GENPalette[0x76] = Color.FromArgb(0x387100
            //GENPalette[0x77] = Color.FromArgb(0x1c7100
            //GENPalette[0x78] = Color.FromArgb(0x007100
            //GENPalette[0x79] = Color.FromArgb(0x00711c
            //GENPalette[0x7A] = Color.FromArgb(0x007138
            //GENPalette[0x7B] = Color.FromArgb(0x007155
            //GENPalette[0x7C] = Color.FromArgb(0x007171
            //GENPalette[0x7D] = Color.FromArgb(0x005571
            //GENPalette[0x7E] = Color.FromArgb(0x003871
            //GENPalette[0x7F] = Color.FromArgb(0x001c71
            
            //----------------------------------------------
            //  ROALOGUS.DAT (Palettenbereich:0x80-0xCF)
            //----------------------------------------------
            GENPalette[0x80] = Color.FromArgb(0x38, 0x38, 0x71);
            GENPalette[0x81] = Color.FromArgb(0x45, 0x38, 0x71);
            GENPalette[0x82] = Color.FromArgb(0x55, 0x38, 0x71);
            GENPalette[0x83] = Color.FromArgb(0x61, 0x38, 0x71);
            GENPalette[0x84] = Color.FromArgb(0x71, 0x38, 0x71);
            GENPalette[0x85] = Color.FromArgb(0x71, 0x38, 0x61);
            GENPalette[0x86] = Color.FromArgb(0x71, 0x38, 0x55);
            GENPalette[0x87] = Color.FromArgb(0x71, 0x38, 0x45);
            GENPalette[0x88] = Color.FromArgb(0x71, 0x38, 0x38);
            GENPalette[0x89] = Color.FromArgb(0x71, 0x45, 0x38);
            GENPalette[0x8A] = Color.FromArgb(0x71, 0x55, 0x38);
            GENPalette[0x8B] = Color.FromArgb(0x71, 0x61, 0x38);
            GENPalette[0x8C] = Color.FromArgb(0x71, 0x71, 0x38);
            GENPalette[0x8D] = Color.FromArgb(0x61, 0x71, 0x38);
            GENPalette[0x8E] = Color.FromArgb(0x55, 0x71, 0x38);
            GENPalette[0x8F] = Color.FromArgb(0x45, 0x71, 0x38);

            GENPalette[0x90] = Color.FromArgb(0x38, 0x71, 0x38);
            GENPalette[0x91] = Color.FromArgb(0x38, 0x71, 0x45);
            GENPalette[0x92] = Color.FromArgb(0x38, 0x71, 0x55);
            GENPalette[0x93] = Color.FromArgb(0x38, 0x71, 0x61);
            GENPalette[0x94] = Color.FromArgb(0x38, 0x71, 0x71);
            GENPalette[0x95] = Color.FromArgb(0x38, 0x61, 0x71);
            GENPalette[0x96] = Color.FromArgb(0x38, 0x55, 0x71);
            GENPalette[0x97] = Color.FromArgb(0x38, 0x45, 0x71);
            GENPalette[0x98] = Color.FromArgb(0x51, 0x51, 0x71);
            GENPalette[0x99] = Color.FromArgb(0x59, 0x51, 0x71);
            GENPalette[0x9A] = Color.FromArgb(0x61, 0x51, 0x71);
            GENPalette[0x9B] = Color.FromArgb(0x69, 0x51, 0x71);
            GENPalette[0x9C] = Color.FromArgb(0x71, 0x51, 0x71);
            GENPalette[0x9D] = Color.FromArgb(0x71, 0x51, 0x69);
            GENPalette[0x9E] = Color.FromArgb(0x71, 0x51, 0x61);
            GENPalette[0x9F] = Color.FromArgb(0x71, 0x51, 0x59);

            GENPalette[0xA0] = Color.FromArgb(0x71, 0x51, 0x51);
            GENPalette[0xA1] = Color.FromArgb(0x71, 0x59, 0x51);
            GENPalette[0xA2] = Color.FromArgb(0x71, 0x61, 0x51);
            GENPalette[0xA3] = Color.FromArgb(0x71, 0x69, 0x51);
            GENPalette[0xA4] = Color.FromArgb(0x71, 0x71, 0x51);
            GENPalette[0xA5] = Color.FromArgb(0x69, 0x71, 0x51);
            GENPalette[0xA6] = Color.FromArgb(0x61, 0x71, 0x51);
            GENPalette[0xA7] = Color.FromArgb(0x59, 0x71, 0x51);
            GENPalette[0xA8] = Color.FromArgb(0x51, 0x71, 0x51);
            GENPalette[0xA9] = Color.FromArgb(0x51, 0x71, 0x59);
            GENPalette[0xAA] = Color.FromArgb(0x51, 0x71, 0x61);
            GENPalette[0xAB] = Color.FromArgb(0x51, 0x71, 0x69);
            GENPalette[0xAC] = Color.FromArgb(0x51, 0x71, 0x71);
            GENPalette[0xAD] = Color.FromArgb(0x51, 0x69, 0x71);
            GENPalette[0xAE] = Color.FromArgb(0x51, 0x61, 0x71);
            GENPalette[0xAF] = Color.FromArgb(0x51, 0x59, 0x71);

            GENPalette[0xB0] = Color.FromArgb(0x00, 0x00, 0x41);
            GENPalette[0xB1] = Color.FromArgb(0x10, 0x00, 0x41);
            GENPalette[0xB2] = Color.FromArgb(0x20, 0x00, 0x41);
            GENPalette[0xB3] = Color.FromArgb(0x30, 0x00, 0x41);
            GENPalette[0xB4] = Color.FromArgb(0x41, 0x00, 0x41);
            GENPalette[0xB5] = Color.FromArgb(0x41, 0x00, 0x30);
            GENPalette[0xB6] = Color.FromArgb(0x41, 0x00, 0x20);
            GENPalette[0xB7] = Color.FromArgb(0x41, 0x00, 0x10);
            GENPalette[0xB8] = Color.FromArgb(0x41, 0x00, 0x00);
            GENPalette[0xB9] = Color.FromArgb(0x41, 0x10, 0x00);
            GENPalette[0xBA] = Color.FromArgb(0x41, 0x20, 0x00);
            GENPalette[0xBB] = Color.FromArgb(0x41, 0x30, 0x00);
            GENPalette[0xBC] = Color.FromArgb(0x41, 0x41, 0x00);
            GENPalette[0xBD] = Color.FromArgb(0x30, 0x41, 0x00);
            GENPalette[0xBE] = Color.FromArgb(0x20, 0x41, 0x00);
            GENPalette[0xBF] = Color.FromArgb(0x10, 0x41, 0x00);

            GENPalette[0xC0] = Color.FromArgb(0x00, 0x41, 0x00);
            GENPalette[0xC1] = Color.FromArgb(0x00, 0x41, 0x10);
            GENPalette[0xC2] = Color.FromArgb(0x00, 0x41, 0x20);
            GENPalette[0xC3] = Color.FromArgb(0x00, 0x41, 0x30);
            GENPalette[0xC4] = Color.FromArgb(0x00, 0x41, 0x41);
            GENPalette[0xC5] = Color.FromArgb(0x00, 0x30, 0x41);
            GENPalette[0xC6] = Color.FromArgb(0x00, 0x20, 0x41);
            GENPalette[0xC7] = Color.FromArgb(0x00, 0x10, 0x41);
            GENPalette[0xC8] = Color.FromArgb(0xa2, 0x00, 0x00);
            GENPalette[0xC9] = Color.FromArgb(0xa2, 0xa2, 0x00);
            GENPalette[0xCA] = Color.FromArgb(0x00, 0x00, 0xa2);
            GENPalette[0xCB] = Color.FromArgb(0x38, 0x20, 0x41);
            GENPalette[0xCC] = Color.FromArgb(0x41, 0x20, 0x41);
            GENPalette[0xCD] = Color.FromArgb(0x41, 0x20, 0x38);
            GENPalette[0xCE] = Color.FromArgb(0x41, 0x20, 0x30);
            GENPalette[0xCF] = Color.FromArgb(0x41, 0x20, 0x28);

            //----------------------------------------------

            //GENPalette[0xD0] = Color.FromArgb(0x412020
            //GENPalette[0x00] = Color.FromArgb(0x412820
            //GENPalette[0x00] = Color.FromArgb(0x413020
            //GENPalette[0x00] = Color.FromArgb(0x413820
            //GENPalette[0x00] = Color.FromArgb(0x414120
            //GENPalette[0x00] = Color.FromArgb(0x384120
            //GENPalette[0x00] = Color.FromArgb(0x304120
            //GENPalette[0x00] = Color.FromArgb(0x284120
            //GENPalette[0x00] = Color.FromArgb(0x000000
            //GENPalette[0x00] = Color.FromArgb(0xe3c3a2
            //GENPalette[0x00] = Color.FromArgb(0xe3c341
            //GENPalette[0x00] = Color.FromArgb(0xc3a230
            //GENPalette[0x00] = Color.FromArgb(0xb29220
            //GENPalette[0x00] = Color.FromArgb(0xa28210
            //GENPalette[0x00] = Color.FromArgb(0x615100
            //GENPalette[0x00] = Color.FromArgb(0x2c6530
            //GENPalette[0x00] = Color.FromArgb(0x2c2c41
            //GENPalette[0x00] = Color.FromArgb(0x302c41
            //GENPalette[0x00] = Color.FromArgb(0x342c41
            //GENPalette[0x00] = Color.FromArgb(0x3c2c41
            //GENPalette[0x00] = Color.FromArgb(0x412c41
            //GENPalette[0x00] = Color.FromArgb(0x412c3c
            //GENPalette[0x00] = Color.FromArgb(0x412c34
            //GENPalette[0x00] = Color.FromArgb(0x412c30
            //GENPalette[0x00] = Color.FromArgb(0x412c2c
            //GENPalette[0x00] = Color.FromArgb(0x41302c
            //GENPalette[0x00] = Color.FromArgb(0x41342c
            //GENPalette[0x00] = Color.FromArgb(0x413c2c
            //GENPalette[0x00] = Color.FromArgb(0x41412c
            //GENPalette[0x00] = Color.FromArgb(0x3c412c
            //GENPalette[0x00] = Color.FromArgb(0x34412c
            //GENPalette[0x00] = Color.FromArgb(0x30412c
            //GENPalette[0x00] = Color.FromArgb(0x2c412c
            //GENPalette[0x00] = Color.FromArgb(0x2c4130
            //GENPalette[0x00] = Color.FromArgb(0x2c4134
            //GENPalette[0x00] = Color.FromArgb(0x2c413c
            //GENPalette[0x00] = Color.FromArgb(0x2c4141
            //GENPalette[0x00] = Color.FromArgb(0x2c3c41
            //GENPalette[0x00] = Color.FromArgb(0x2c3441
            //GENPalette[0x00] = Color.FromArgb(0x2c3041
            //GENPalette[0x00] = Color.FromArgb(0x000000
            //GENPalette[0x00] = Color.FromArgb(0x000000
            //GENPalette[0x00] = Color.FromArgb(0x000000
            //GENPalette[0x00] = Color.FromArgb(0x000000
            //GENPalette[0x00] = Color.FromArgb(0x000000
            //GENPalette[0x00] = Color.FromArgb(0x000000
            //GENPalette[0x00] = Color.FromArgb(0x000000
            //GENPalette[0x00] = Color.FromArgb(0xffffff

        }

        static public Color getColor(palettenTyp typ, Byte input)
        {
            switch (typ)
            {
                case palettenTyp.Town_Pal:
                    return townPalette[input];

                case palettenTyp.CharMenü_Pal:
                    return charMenüPalette[input];

                case palettenTyp.Fight_Pal:
                    return fightPalette[input];

                case palettenTyp.Logo_Attic:
                    return AtticPalette[input];

                case palettenTyp.GEN_Pal:
                    return GENPalette[input];

                default:
                    return defaultPalette[input];
            }
        }
    }
}

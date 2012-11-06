using System;
using System.Collections.Generic;
using System.Text;

using System.Drawing;

namespace DSA_1_Editing_Tool
{
    static class CFarbPalette
    {
        public enum palettenTyp { default_Pal, Town_Pal, CharMenü_Pal, Fight_Pal, Logo_Pal, Test_Pal };

        static Color[] defaultPalette = new Color[256];
        static Color[] townPalette = null;
        static Color[] charMenüPalette = null;
        static Color[] fightPalette = null;
        static Color[] logoPalette = null;

        static Color[] testPalette = new Color[256];

        static CFarbPalette()
        {
            try
            {
                initDefaultPalette();

                initTownPalette();
                initCharMenüPalette();
                initFightPalette();
                initLogoPalette();

                initTestPalette();
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

            fightPalette[0x00] = Color.FromArgb(0x00 * 4, 0x00 * 4, 0x00 * 4);
            fightPalette[0x01] = Color.FromArgb(0x3C * 4, 0x2C * 4, 0x24 * 4);
            fightPalette[0x02] = Color.FromArgb(0x3C * 4, 0x28 * 4, 0x1C * 4);
            fightPalette[0x03] = Color.FromArgb(0x34 * 4, 0x20 * 4, 0x18 * 4);
            fightPalette[0x04] = Color.FromArgb(0x28 * 4, 0x18 * 4, 0x14 * 4);
            fightPalette[0x05] = Color.FromArgb(0x20 * 4, 0x14 * 4, 0x10 * 4);
            fightPalette[0x06] = Color.FromArgb(0x18 * 4, 0x0C * 4, 0x08 * 4);
            fightPalette[0x07] = Color.FromArgb(0x10 * 4, 0x08 * 4, 0x08 * 4);

            fightPalette[0x08] = Color.FromArgb(0x0C * 4, 0x04 * 4, 0x04 * 4);
            fightPalette[0x09] = Color.FromArgb(0x34 * 4, 0x34 * 4, 0x34 * 4);
            fightPalette[0x0A] = Color.FromArgb(0x28 * 4, 0x28 * 4, 0x28 * 4);
            fightPalette[0x0B] = Color.FromArgb(0x20 * 4, 0x20 * 4, 0x20 * 4);
            fightPalette[0x0C] = Color.FromArgb(0x18 * 4, 0x18 * 4, 0x18 * 4);
            fightPalette[0x0D] = Color.FromArgb(0x14 * 4, 0x14 * 4, 0x14 * 4);
            fightPalette[0x0E] = Color.FromArgb(0x10 * 4, 0x10 * 4, 0x10 * 4);
            fightPalette[0x0F] = Color.FromArgb(0x0C * 4, 0x0C * 4, 0x0C * 4);

            fightPalette[0x10] = Color.FromArgb(0x08 * 4, 0x08 * 4, 0x08 * 4);
            fightPalette[0x11] = Color.FromArgb(0x14 * 4, 0x0C * 4, 0x08 * 4);
            fightPalette[0x12] = Color.FromArgb(0x00 * 4, 0x00 * 4, 0x00 * 4);
            fightPalette[0x13] = Color.FromArgb(0x18 * 4, 0x14 * 4, 0x3C * 4);
            fightPalette[0x14] = Color.FromArgb(0x14 * 4, 0x00 * 4, 0x00 * 4);
            fightPalette[0x15] = Color.FromArgb(0x1C * 4, 0x00 * 4, 0x00 * 4);
            fightPalette[0x16] = Color.FromArgb(0x24 * 4, 0x00 * 4, 0x00 * 4);
            fightPalette[0x17] = Color.FromArgb(0x2C * 4, 0x00 * 4, 0x00 * 4);

            fightPalette[0x18] = Color.FromArgb(0x3C * 4, 0x00 * 4, 0x00 * 4);
            fightPalette[0x19] = Color.FromArgb(0x1C * 4, 0x10 * 4, 0x10 * 4);
            fightPalette[0x1A] = Color.FromArgb(0x00 * 4, 0x1C * 4, 0x00 * 4);
            fightPalette[0x1B] = Color.FromArgb(0x00 * 4, 0x28 * 4, 0x00 * 4);
            fightPalette[0x1C] = Color.FromArgb(0x00 * 4, 0x04 * 4, 0x20 * 4);
            fightPalette[0x1D] = Color.FromArgb(0x2C * 4, 0x2C * 4, 0x0C * 4);
            fightPalette[0x1E] = Color.FromArgb(0x38 * 4, 0x38 * 4, 0x10 * 4);
            fightPalette[0x1F] = Color.FromArgb(0x3C * 4, 0x3C * 4, 0x3C * 4);

        }
        static private void initLogoPalette()
        {
            logoPalette = (Color[])defaultPalette.Clone();


            //GENXX.NVF
            logoPalette[0x40] = Color.FromArgb(00 * 4, 00 * 4, 00 * 4);
            logoPalette[0x41] = Color.FromArgb(56 * 4, 56 * 4, 56 * 4);
            logoPalette[0x42] = Color.FromArgb(52 * 4, 52 * 4, 52 * 4);
            logoPalette[0x43] = Color.FromArgb(48 * 4, 48 * 4, 48 * 4);
            logoPalette[0x44] = Color.FromArgb(44 * 4, 44 * 4, 44 * 4);
            logoPalette[0x45] = Color.FromArgb(40 * 4, 40 * 4, 40 * 4);
            logoPalette[0x46] = Color.FromArgb(36 * 4, 36 * 4, 36 * 4);
            logoPalette[0x47] = Color.FromArgb(32 * 4, 32 * 4, 32 * 4);

            logoPalette[0x48] = Color.FromArgb(28 * 4, 28 * 4, 28 * 4);
            logoPalette[0x49] = Color.FromArgb(24 * 4, 24 * 4, 24 * 4);
            logoPalette[0x4A] = Color.FromArgb(20 * 4, 20 * 4, 20 * 4);
            logoPalette[0x4B] = Color.FromArgb(16 * 4, 16 * 4, 16 * 4);
            logoPalette[0x4C] = Color.FromArgb(12 * 4, 12 * 4, 12 * 4);
            logoPalette[0x4D] = Color.FromArgb(08 * 4, 08 * 4, 08 * 4);
            logoPalette[0x4E] = Color.FromArgb(60 * 4, 60 * 4, 60 * 4);
            logoPalette[0x4F] = Color.FromArgb(60 * 4, 52 * 4, 24 * 4);

            logoPalette[0x50] = Color.FromArgb(60 * 4, 52 * 4, 08 * 4);
            logoPalette[0x51] = Color.FromArgb(60 * 4, 52 * 4, 00 * 4);
            logoPalette[0x52] = Color.FromArgb(56 * 4, 48 * 4, 00 * 4);
            logoPalette[0x53] = Color.FromArgb(52 * 4, 44 * 4, 00 * 4);
            logoPalette[0x54] = Color.FromArgb(48 * 4, 40 * 4, 00 * 4);
            logoPalette[0x55] = Color.FromArgb(44 * 4, 36 * 4, 00 * 4);
            logoPalette[0x56] = Color.FromArgb(40 * 4, 32 * 4, 00 * 4);
            logoPalette[0x57] = Color.FromArgb(36 * 4, 28 * 4, 00 * 4);

            logoPalette[0x58] = Color.FromArgb(32 * 4, 24 * 4, 00 * 4);
            logoPalette[0x59] = Color.FromArgb(28 * 4, 20 * 4, 00 * 4);
            logoPalette[0x5A] = Color.FromArgb(56 * 4, 20 * 4, 12 * 4);
            logoPalette[0x5B] = Color.FromArgb(52 * 4, 12 * 4, 00 * 4);
            logoPalette[0x5C] = Color.FromArgb(44 * 4, 08 * 4, 00 * 4);
            logoPalette[0x5D] = Color.FromArgb(36 * 4, 04 * 4, 00 * 4);
            logoPalette[0x5E] = Color.FromArgb(28 * 4, 00 * 4, 00 * 4);
            logoPalette[0x5F] = Color.FromArgb(20 * 4, 00 * 4, 00 * 4);

            //GEN.EXE
            logoPalette[0xC8] = Color.FromArgb(40 * 4, 00 * 4, 00 * 4);
            logoPalette[0xC9] = Color.FromArgb(40 * 4, 40 * 4, 00 * 4);
            logoPalette[0xCA] = Color.FromArgb(00 * 4, 00 * 4, 40 * 4);
        }

        static private void initTestPalette()
        {
            int startwert = 0x01;
            int länge = 0x2F;

            testPalette[0] = Color.FromArgb(0x00, 0x60, 0x00);

            for (int i = startwert; i < (länge); i++)
                testPalette[i] = Color.FromArgb(0x60, 0x00, 0x00);
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

                case palettenTyp.Logo_Pal:
                    return logoPalette[input];

                case palettenTyp.Test_Pal:
                    return testPalette[input];

                default:
                    return defaultPalette[input];
            }
        }
    }
}

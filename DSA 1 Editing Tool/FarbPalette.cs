using System;
using System.Collections.Generic;
using System.Text;

using System.Drawing;

namespace DSA_1_Editing_Tool
{
    static class CFarbPalette
    {
        static Color[] palette_1 = null;
        static Color[] townColors = null;
        static Color[] itemColors = null;

        static CFarbPalette()
        {
            if (palette_1 == null)
            {
                /*Die Palette kenne ich sehr wohl. Im Spiel gibt es insgesamt 256/0x100 Farben, welche in Bereiche eingeteilt sind.
Z.B. sind die Gesichter der Helden 0x20-0x3f, die Gegenstände 0x40-0x5f. Bei diesen speziellen Bereichen gibt es feste Paletten die für alle Bilder eines Typs gelten.*/

                palette_1 = new Color[256];

                palette_1[0] = Color.FromArgb(255, Color.FromArgb(0x000000));
                palette_1[1] = Color.FromArgb(255, Color.FromArgb(0x304020));
                palette_1[2] = Color.FromArgb(255, Color.FromArgb(0x502010));
                palette_1[3] = Color.FromArgb(255, Color.FromArgb(0x504010));
                palette_1[4] = Color.FromArgb(255, Color.FromArgb(0x404040));
                palette_1[5] = Color.FromArgb(255, Color.FromArgb(0x406040));
                palette_1[6] = Color.FromArgb(255, Color.FromArgb(0x803010));
                palette_1[7] = Color.FromArgb(255, Color.FromArgb(0x407060));
                palette_1[8] = Color.FromArgb(255, Color.FromArgb(0x806020));
                palette_1[9] = Color.FromArgb(255, Color.FromArgb(0x806040));
                palette_1[10] = Color.FromArgb(255, Color.FromArgb(0x509040));
                palette_1[11] = Color.FromArgb(255, Color.FromArgb(0x707060));
                palette_1[12] = Color.FromArgb(255, Color.FromArgb(0xb04010));
                palette_1[13] = Color.FromArgb(255, Color.FromArgb(0x307090));
                palette_1[14] = Color.FromArgb(255, Color.FromArgb(0x809030));
                palette_1[15] = Color.FromArgb(255, Color.FromArgb(0x509070));

                palette_1[16] = Color.FromArgb(255, Color.FromArgb(0xc06020));
                palette_1[17] = Color.FromArgb(255, Color.FromArgb(0x70a060));
                palette_1[18] = Color.FromArgb(255, Color.FromArgb(0x40b090));
                palette_1[19] = Color.FromArgb(255, Color.FromArgb(0xc07050));
                palette_1[20] = Color.FromArgb(255, Color.FromArgb(0xd07030));
                palette_1[21] = Color.FromArgb(255, Color.FromArgb(0xc09030));
                palette_1[22] = Color.FromArgb(255, Color.FromArgb(0x40b0a0));
                palette_1[23] = Color.FromArgb(255, Color.FromArgb(0x80b080));
                palette_1[24] = Color.FromArgb(255, Color.FromArgb(0xb0a060));
                palette_1[25] = Color.FromArgb(255, Color.FromArgb(0xe09030));
                palette_1[26] = Color.FromArgb(255, Color.FromArgb(0x90c080));
                palette_1[27] = Color.FromArgb(255, Color.FromArgb(0xc0b080));
                palette_1[28] = Color.FromArgb(255, Color.FromArgb(0xd0c060));
                palette_1[29] = Color.FromArgb(255, Color.FromArgb(0xd0d080));
                palette_1[30] = Color.FromArgb(255, Color.FromArgb(0xc0c0b0));
                palette_1[31] = Color.FromArgb(255, Color.FromArgb(0xe0e0c0));
                //---------------------------------
                //  Heldenportraits 0x20-0x3f
                palette_1[32] = Color.FromArgb(255, Color.FromArgb(0x000000));
                palette_1[33] = Color.FromArgb(255, Color.FromArgb(0x0000fc));
                palette_1[34] = Color.FromArgb(255, Color.FromArgb(0x000090));
                palette_1[35] = Color.FromArgb(255, Color.FromArgb(0xf0c0a0));
                palette_1[36] = Color.FromArgb(255, Color.FromArgb(0xf0b090));
                palette_1[37] = Color.FromArgb(255, Color.FromArgb(0xf0a070));
                palette_1[38] = Color.FromArgb(255, Color.FromArgb(0xe09060));
                palette_1[39] = Color.FromArgb(255, Color.FromArgb(0xd08050));
                palette_1[40] = Color.FromArgb(255, Color.FromArgb(0xc07050));
                palette_1[41] = Color.FromArgb(255, Color.FromArgb(0xa06040));
                palette_1[42] = Color.FromArgb(255, Color.FromArgb(0x905030));
                palette_1[43] = Color.FromArgb(255, Color.FromArgb(0x704030));
                palette_1[44] = Color.FromArgb(255, Color.FromArgb(0x603020));
                palette_1[45] = Color.FromArgb(255, Color.FromArgb(0x503020));
                palette_1[46] = Color.FromArgb(255, Color.FromArgb(0xe0e0e0));
                palette_1[47] = Color.FromArgb(255, Color.FromArgb(0xc0c0c0));

                palette_1[48] = Color.FromArgb(255, Color.FromArgb(0xb0b0b0));
                palette_1[49] = Color.FromArgb(255, Color.FromArgb(0xa0a0a0));
                palette_1[50] = Color.FromArgb(255, Color.FromArgb(0x808080));
                palette_1[51] = Color.FromArgb(255, Color.FromArgb(0x707070));
                palette_1[52] = Color.FromArgb(255, Color.FromArgb(0x505050));
                palette_1[53] = Color.FromArgb(255, Color.FromArgb(0x404040));
                palette_1[54] = Color.FromArgb(255, Color.FromArgb(0x00fc00));
                palette_1[55] = Color.FromArgb(255, Color.FromArgb(0x009000));
                palette_1[56] = Color.FromArgb(255, Color.FromArgb(0xf0f000));
                palette_1[57] = Color.FromArgb(255, Color.FromArgb(0xd0b000));
                palette_1[58] = Color.FromArgb(255, Color.FromArgb(0xa08000));
                palette_1[59] = Color.FromArgb(255, Color.FromArgb(0xf06040));
                palette_1[60] = Color.FromArgb(255, Color.FromArgb(0xc04020));
                palette_1[61] = Color.FromArgb(255, Color.FromArgb(0x903010));
                palette_1[62] = Color.FromArgb(255, Color.FromArgb(0x402010));
                palette_1[63] = Color.FromArgb(255, Color.FromArgb(0xf0f0f0));
                //---------------------------------
                //  Gegenstände 0x40-0x5f
                palette_1[64] = Color.FromArgb(255, Color.FromArgb(0x000000));
                palette_1[65] = Color.FromArgb(255, Color.FromArgb(0xe0e0e0));
                palette_1[66] = Color.FromArgb(255, Color.FromArgb(0xd0d0d0));
                palette_1[67] = Color.FromArgb(255, Color.FromArgb(0xc0c0c0));
                palette_1[68] = Color.FromArgb(255, Color.FromArgb(0xb0b0b0));
                palette_1[69] = Color.FromArgb(255, Color.FromArgb(0xa0a0a0));
                palette_1[70] = Color.FromArgb(255, Color.FromArgb(0x909090));
                palette_1[71] = Color.FromArgb(255, Color.FromArgb(0x808080));
                palette_1[72] = Color.FromArgb(255, Color.FromArgb(0x707070));
                palette_1[73] = Color.FromArgb(255, Color.FromArgb(0x606060));
                palette_1[74] = Color.FromArgb(255, Color.FromArgb(0x505050));
                palette_1[75] = Color.FromArgb(255, Color.FromArgb(0x404040));
                palette_1[76] = Color.FromArgb(255, Color.FromArgb(0x303030));
                palette_1[77] = Color.FromArgb(255, Color.FromArgb(0x202020));
                palette_1[78] = Color.FromArgb(255, Color.FromArgb(0xf0f0f0));
                palette_1[79] = Color.FromArgb(255, Color.FromArgb(0xf0d060));

                palette_1[80] = Color.FromArgb(255, Color.FromArgb(0xf0d020));
                palette_1[81] = Color.FromArgb(255, Color.FromArgb(0xf0d000));
                palette_1[82] = Color.FromArgb(255, Color.FromArgb(0xe0c000));
                palette_1[83] = Color.FromArgb(255, Color.FromArgb(0xd0b000));
                palette_1[84] = Color.FromArgb(255, Color.FromArgb(0xc0a000));
                palette_1[85] = Color.FromArgb(255, Color.FromArgb(0xb09000));
                palette_1[86] = Color.FromArgb(255, Color.FromArgb(0xa08000));
                palette_1[87] = Color.FromArgb(255, Color.FromArgb(0x907000));
                palette_1[88] = Color.FromArgb(255, Color.FromArgb(0x806000));
                palette_1[89] = Color.FromArgb(255, Color.FromArgb(0x705000));
                palette_1[90] = Color.FromArgb(255, Color.FromArgb(0xe05030));
                palette_1[91] = Color.FromArgb(255, Color.FromArgb(0xd03000));
                palette_1[92] = Color.FromArgb(255, Color.FromArgb(0xb02000));
                palette_1[93] = Color.FromArgb(255, Color.FromArgb(0x901000));
                palette_1[94] = Color.FromArgb(255, Color.FromArgb(0x700000));
                palette_1[95] = Color.FromArgb(255, Color.FromArgb(0x500000));

                palette_1[96] = Color.FromArgb(255, Color.FromArgb(0xb4fcb4));
                palette_1[97] = Color.FromArgb(255, Color.FromArgb(0xb4fcc4));
                palette_1[98] = Color.FromArgb(255, Color.FromArgb(0xb4fcd8));
                palette_1[99] = Color.FromArgb(255, Color.FromArgb(0xb4fce8));
                palette_1[100] = Color.FromArgb(255, Color.FromArgb(0xb4fcb4));
                palette_1[101] = Color.FromArgb(255, Color.FromArgb(0xb4e8fc));
                palette_1[102] = Color.FromArgb(255, Color.FromArgb(0xb4d8fc));
                palette_1[103] = Color.FromArgb(255, Color.FromArgb(0xb4c4fc));
                palette_1[104] = Color.FromArgb(255, Color.FromArgb(0x000070));
                palette_1[105] = Color.FromArgb(255, Color.FromArgb(0x1c0070));
                palette_1[106] = Color.FromArgb(255, Color.FromArgb(0x380070));
                palette_1[107] = Color.FromArgb(255, Color.FromArgb(0x540070));
                palette_1[108] = Color.FromArgb(255, Color.FromArgb(0x700070));
                palette_1[109] = Color.FromArgb(255, Color.FromArgb(0x700054));

                palette_1[110] = Color.FromArgb(255, Color.FromArgb(0x700038));
                palette_1[111] = Color.FromArgb(255, Color.FromArgb(0x70001c));
                palette_1[112] = Color.FromArgb(255, Color.FromArgb(0x700000));
                palette_1[113] = Color.FromArgb(255, Color.FromArgb(0x701c00));
                palette_1[114] = Color.FromArgb(255, Color.FromArgb(0x703800));
                palette_1[115] = Color.FromArgb(255, Color.FromArgb(0x705400));
                palette_1[116] = Color.FromArgb(255, Color.FromArgb(0x701000));
                palette_1[117] = Color.FromArgb(255, Color.FromArgb(0x547000));
                palette_1[118] = Color.FromArgb(255, Color.FromArgb(0x387000));
                palette_1[119] = Color.FromArgb(255, Color.FromArgb(0x1c7000));

                palette_1[120] = Color.FromArgb(255, Color.FromArgb(0x007000));
                palette_1[121] = Color.FromArgb(255, Color.FromArgb(0x00701c));
                palette_1[122] = Color.FromArgb(255, Color.FromArgb(0x007038));
                palette_1[123] = Color.FromArgb(255, Color.FromArgb(0x007054));
                palette_1[124] = Color.FromArgb(255, Color.FromArgb(0x007070));
                palette_1[125] = Color.FromArgb(255, Color.FromArgb(0x005470));
                palette_1[126] = Color.FromArgb(255, Color.FromArgb(0x003870));
                palette_1[127] = Color.FromArgb(255, Color.FromArgb(0x001c70));
                palette_1[128] = Color.FromArgb(255, Color.FromArgb(0x383870));
                palette_1[129] = Color.FromArgb(255, Color.FromArgb(0x443870));

                palette_1[130] = Color.FromArgb(255, Color.FromArgb(0x543870));
                palette_1[131] = Color.FromArgb(255, Color.FromArgb(0x603870));
                palette_1[132] = Color.FromArgb(255, Color.FromArgb(0x703870));
                palette_1[133] = Color.FromArgb(255, Color.FromArgb(0x703860));
                palette_1[134] = Color.FromArgb(255, Color.FromArgb(0x703854));
                palette_1[135] = Color.FromArgb(255, Color.FromArgb(0x703844));
                palette_1[136] = Color.FromArgb(255, Color.FromArgb(0x703838));
                palette_1[137] = Color.FromArgb(255, Color.FromArgb(0x704438));
                palette_1[138] = Color.FromArgb(255, Color.FromArgb(0x705438));
                palette_1[139] = Color.FromArgb(255, Color.FromArgb(0x706038));

                palette_1[140] = Color.FromArgb(255, Color.FromArgb(0x707038));
                palette_1[141] = Color.FromArgb(255, Color.FromArgb(0x607038));
                palette_1[142] = Color.FromArgb(255, Color.FromArgb(0x547038));
                palette_1[143] = Color.FromArgb(255, Color.FromArgb(0x447038));
                palette_1[144] = Color.FromArgb(255, Color.FromArgb(0x387038));
                palette_1[145] = Color.FromArgb(255, Color.FromArgb(0x387044));
                palette_1[146] = Color.FromArgb(255, Color.FromArgb(0x387054));
                palette_1[147] = Color.FromArgb(255, Color.FromArgb(0x387060));
                palette_1[148] = Color.FromArgb(255, Color.FromArgb(0x387070));
                palette_1[149] = Color.FromArgb(255, Color.FromArgb(0x386070));

                palette_1[150] = Color.FromArgb(255, Color.FromArgb(0x385470));
                palette_1[151] = Color.FromArgb(255, Color.FromArgb(0x384470));
                palette_1[152] = Color.FromArgb(255, Color.FromArgb(0x505070));
                palette_1[153] = Color.FromArgb(255, Color.FromArgb(0x585070));
                palette_1[154] = Color.FromArgb(255, Color.FromArgb(0x605070));
                palette_1[155] = Color.FromArgb(255, Color.FromArgb(0x685070));
                palette_1[156] = Color.FromArgb(255, Color.FromArgb(0x705070));
                palette_1[157] = Color.FromArgb(255, Color.FromArgb(0x705068));
                palette_1[158] = Color.FromArgb(255, Color.FromArgb(0x705060));
                palette_1[159] = Color.FromArgb(255, Color.FromArgb(0x705058));

                palette_1[160] = Color.FromArgb(255, Color.FromArgb(0x705050));
                palette_1[161] = Color.FromArgb(255, Color.FromArgb(0x705850));
                palette_1[162] = Color.FromArgb(255, Color.FromArgb(0x706050));
                palette_1[163] = Color.FromArgb(255, Color.FromArgb(0x706850));
                palette_1[164] = Color.FromArgb(255, Color.FromArgb(0x707050));
                palette_1[165] = Color.FromArgb(255, Color.FromArgb(0x687050));
                palette_1[166] = Color.FromArgb(255, Color.FromArgb(0x607050));
                palette_1[167] = Color.FromArgb(255, Color.FromArgb(0x587050));
                palette_1[168] = Color.FromArgb(255, Color.FromArgb(0x507050));
                palette_1[169] = Color.FromArgb(255, Color.FromArgb(0x507058));

                palette_1[170] = Color.FromArgb(255, Color.FromArgb(0x507060));
                palette_1[171] = Color.FromArgb(255, Color.FromArgb(0x507068));
                palette_1[172] = Color.FromArgb(255, Color.FromArgb(0x507070));
                palette_1[173] = Color.FromArgb(255, Color.FromArgb(0x506870));
                palette_1[174] = Color.FromArgb(255, Color.FromArgb(0x506070));
                palette_1[175] = Color.FromArgb(255, Color.FromArgb(0x505870));
                palette_1[176] = Color.FromArgb(255, Color.FromArgb(0x000040));
                palette_1[177] = Color.FromArgb(255, Color.FromArgb(0x100040));
                palette_1[178] = Color.FromArgb(255, Color.FromArgb(0x200040));
                palette_1[179] = Color.FromArgb(255, Color.FromArgb(0x300040));

                palette_1[180] = Color.FromArgb(255, Color.FromArgb(0x400040));
                palette_1[181] = Color.FromArgb(255, Color.FromArgb(0x400030));
                palette_1[182] = Color.FromArgb(255, Color.FromArgb(0x400020));
                palette_1[183] = Color.FromArgb(255, Color.FromArgb(0x400010));
                palette_1[184] = Color.FromArgb(255, Color.FromArgb(0x400000));
                palette_1[185] = Color.FromArgb(255, Color.FromArgb(0x401000));
                palette_1[186] = Color.FromArgb(255, Color.FromArgb(0x402000));
                palette_1[187] = Color.FromArgb(255, Color.FromArgb(0x403000));
                palette_1[188] = Color.FromArgb(255, Color.FromArgb(0x404000));
                palette_1[189] = Color.FromArgb(255, Color.FromArgb(0x304000));

                palette_1[190] = Color.FromArgb(255, Color.FromArgb(0x204000));
                palette_1[191] = Color.FromArgb(255, Color.FromArgb(0x104000));
                palette_1[192] = Color.FromArgb(255, Color.FromArgb(0x004000));
                palette_1[193] = Color.FromArgb(255, Color.FromArgb(0x004010));
                palette_1[194] = Color.FromArgb(255, Color.FromArgb(0x004020));
                palette_1[195] = Color.FromArgb(255, Color.FromArgb(0x004030));
                palette_1[196] = Color.FromArgb(255, Color.FromArgb(0x004040));
                palette_1[197] = Color.FromArgb(255, Color.FromArgb(0x003040));
                palette_1[198] = Color.FromArgb(255, Color.FromArgb(0x002040));
                palette_1[199] = Color.FromArgb(255, Color.FromArgb(0x001040));

                palette_1[200] = Color.FromArgb(255, Color.FromArgb(0xa00000));
                palette_1[201] = Color.FromArgb(255, Color.FromArgb(0xa0a000));
                palette_1[202] = Color.FromArgb(255, Color.FromArgb(0x0000a0));
                palette_1[203] = Color.FromArgb(255, Color.FromArgb(0x382040));
                palette_1[204] = Color.FromArgb(255, Color.FromArgb(0x402040));
                palette_1[205] = Color.FromArgb(255, Color.FromArgb(0x402038));
                palette_1[206] = Color.FromArgb(255, Color.FromArgb(0x402030));
                palette_1[207] = Color.FromArgb(255, Color.FromArgb(0x402028));
                palette_1[208] = Color.FromArgb(255, Color.FromArgb(0x402020));
                palette_1[209] = Color.FromArgb(255, Color.FromArgb(0x402820));

                palette_1[210] = Color.FromArgb(255, Color.FromArgb(0x403020));
                palette_1[211] = Color.FromArgb(255, Color.FromArgb(0x403820));
                palette_1[212] = Color.FromArgb(255, Color.FromArgb(0x404020));
                palette_1[213] = Color.FromArgb(255, Color.FromArgb(0x384020));
                palette_1[214] = Color.FromArgb(255, Color.FromArgb(0x304020));
                palette_1[215] = Color.FromArgb(255, Color.FromArgb(0x284020));
                palette_1[216] = Color.FromArgb(255, Color.FromArgb(0x000000));
                palette_1[217] = Color.FromArgb(255, Color.FromArgb(0xe0c0a0));
                palette_1[218] = Color.FromArgb(255, Color.FromArgb(0xe0c040));
                palette_1[219] = Color.FromArgb(255, Color.FromArgb(0xc0a030));

                palette_1[220] = Color.FromArgb(255, Color.FromArgb(0xb09020));
                palette_1[221] = Color.FromArgb(255, Color.FromArgb(0xa08010));
                palette_1[222] = Color.FromArgb(255, Color.FromArgb(0x605000));
                palette_1[223] = Color.FromArgb(255, Color.FromArgb(0x2c6430));
                palette_1[224] = Color.FromArgb(255, Color.FromArgb(0x2c2c40));
                palette_1[225] = Color.FromArgb(255, Color.FromArgb(0x302c40));
                palette_1[226] = Color.FromArgb(255, Color.FromArgb(0x342c40));
                palette_1[227] = Color.FromArgb(255, Color.FromArgb(0x3c2c40));
                palette_1[228] = Color.FromArgb(255, Color.FromArgb(0x402c40));
                palette_1[229] = Color.FromArgb(255, Color.FromArgb(0x402c3c));

                palette_1[230] = Color.FromArgb(255, Color.FromArgb(0x402c34));
                palette_1[231] = Color.FromArgb(255, Color.FromArgb(0x402c30));
                palette_1[232] = Color.FromArgb(255, Color.FromArgb(0x402c2c));
                palette_1[233] = Color.FromArgb(255, Color.FromArgb(0x40302c));
                palette_1[234] = Color.FromArgb(255, Color.FromArgb(0x40342c));
                palette_1[235] = Color.FromArgb(255, Color.FromArgb(0x403c2c));
                palette_1[236] = Color.FromArgb(255, Color.FromArgb(0x40402c));
                palette_1[237] = Color.FromArgb(255, Color.FromArgb(0x3c402c));
                palette_1[238] = Color.FromArgb(255, Color.FromArgb(0x34402c));
                palette_1[239] = Color.FromArgb(255, Color.FromArgb(0x30402c));

                palette_1[240] = Color.FromArgb(255, Color.FromArgb(0x2c402c));
                palette_1[241] = Color.FromArgb(255, Color.FromArgb(0x2c4030));
                palette_1[242] = Color.FromArgb(255, Color.FromArgb(0x2c4034));
                palette_1[243] = Color.FromArgb(255, Color.FromArgb(0x2c403c));
                palette_1[244] = Color.FromArgb(255, Color.FromArgb(0x2c4040));
                palette_1[245] = Color.FromArgb(255, Color.FromArgb(0x2c3c40));
                palette_1[246] = Color.FromArgb(255, Color.FromArgb(0x2c3440));
                palette_1[247] = Color.FromArgb(255, Color.FromArgb(0x2c3040));
                palette_1[248] = Color.FromArgb(255, Color.FromArgb(0x000000));
                palette_1[249] = Color.FromArgb(255, Color.FromArgb(0x000000));

                palette_1[250] = Color.FromArgb(255, Color.FromArgb(0x000000));
                palette_1[251] = Color.FromArgb(255, Color.FromArgb(0x000000));
                palette_1[252] = Color.FromArgb(255, Color.FromArgb(0x000000));
                palette_1[253] = Color.FromArgb(255, Color.FromArgb(0x000000));
                palette_1[254] = Color.FromArgb(255, Color.FromArgb(0x000000));
                palette_1[255] = Color.FromArgb(255, Color.FromArgb(0xfcfcfc));
            }

            if (townColors == null)
            {
                townColors = new Color[64];

                townColors[0] = Color.FromArgb(0x00 * 4, 0x00 * 4, 0x00 * 4);
                townColors[1] = Color.FromArgb(0x39 * 4, 0x39 * 4, 0x39 * 4);
                townColors[2] = Color.FromArgb(0x32 * 4, 0x32 * 4, 0x32 * 4);
                townColors[3] = Color.FromArgb(0x2C * 4, 0x2C * 4, 0x2C * 4);
                townColors[4] = Color.FromArgb(0x26 * 4, 0x26 * 4, 0x26 * 4);
                townColors[5] = Color.FromArgb(0x20 * 4, 0x20 * 4, 0x20 * 4);
                townColors[6] = Color.FromArgb(0x1A * 4, 0x1A * 4, 0x1A * 4);
                townColors[7] = Color.FromArgb(0x13 * 4, 0x13 * 4, 0x13 * 4);

                townColors[8] = Color.FromArgb(0x0D * 4, 0x0D * 4, 0x0D * 4);
                townColors[9] = Color.FromArgb(0x37 * 4, 0x30 * 4, 0x2C * 4);
                townColors[10] = Color.FromArgb(0x32 * 4, 0x29 * 4, 0x25 * 4);
                townColors[11] = Color.FromArgb(0x2D * 4, 0x23 * 4, 0x1F * 4);
                townColors[12] = Color.FromArgb(0x28 * 4, 0x1D * 4, 0x1A * 4);
                townColors[13] = Color.FromArgb(0x22 * 4, 0x17 * 4, 0x15 * 4);
                townColors[14] = Color.FromArgb(0x1E * 4, 0x12 * 4, 0x11 * 4);
                townColors[15] = Color.FromArgb(0x18 * 4, 0x0D * 4, 0x0D * 4);

                townColors[16] = Color.FromArgb(0x17 * 4, 0x09 * 4, 0x09 * 4);
                townColors[17] = Color.FromArgb(0x21 * 4, 0x0D * 4, 0x0B * 4);
                townColors[18] = Color.FromArgb(0x2C * 4, 0x11 * 4, 0x0D * 4);
                townColors[19] = Color.FromArgb(0x37 * 4, 0x16 * 4, 0x0D * 4);
                townColors[20] = Color.FromArgb(0x2A * 4, 0x2C * 4, 0x1C * 4);
                townColors[21] = Color.FromArgb(0x20 * 4, 0x25 * 4, 0x14 * 4);
                townColors[22] = Color.FromArgb(0x17 * 4, 0x1E * 4, 0x0E * 4);
                townColors[23] = Color.FromArgb(0x0F * 4, 0x17 * 4, 0x09 * 4);

                townColors[24] = Color.FromArgb(0x08 * 4, 0x10 * 4, 0x05 * 4);
                townColors[25] = Color.FromArgb(0x32 * 4, 0x25 * 4, 0x03 * 4);
                townColors[26] = Color.FromArgb(0x29 * 4, 0x1E * 4, 0x02 * 4);
                townColors[27] = Color.FromArgb(0x20 * 4, 0x17 * 4, 0x02 * 4);
                townColors[28] = Color.FromArgb(0x04 * 4, 0x0F * 4, 0x18 * 4);
                townColors[29] = Color.FromArgb(0x05 * 4, 0x14 * 4, 0x1F * 4);
                townColors[30] = Color.FromArgb(0x05 * 4, 0x1A * 4, 0x26 * 4);
                townColors[31] = Color.FromArgb(0x06 * 4, 0x1F * 4, 0x2D * 4);

                //--------------------32-----------------
                townColors[32] = Color.FromArgb(0x00 * 4, 0x00 * 4, 0x00 * 4);
                townColors[33] = Color.FromArgb(0x05 * 4, 0x0D * 4, 0x28 * 4);
                townColors[34] = Color.FromArgb(0x06 * 4, 0x10 * 4, 0x32 * 4);
                townColors[35] = Color.FromArgb(0x3F * 4, 0x00 * 4, 0x3F * 4);
                townColors[36] = Color.FromArgb(0x3F * 4, 0x00 * 4, 0x3F * 4);
                townColors[37] = Color.FromArgb(0x2D * 4, 0x2D * 4, 0x38 * 4);
                townColors[38] = Color.FromArgb(0x29 * 4, 0x29 * 4, 0x36 * 4);
                townColors[39] = Color.FromArgb(0x26 * 4, 0x26 * 4, 0x34 * 4);

                townColors[40] = Color.FromArgb(0x23 * 4, 0x23 * 4, 0x32 * 4);
                townColors[41] = Color.FromArgb(0x21 * 4, 0x20 * 4, 0x31 * 4);
                townColors[42] = Color.FromArgb(0x1F * 4, 0x1E * 4, 0x1F * 4);
                townColors[43] = Color.FromArgb(0x1C * 4, 0x1B * 4, 0x2D * 4);
                townColors[44] = Color.FromArgb(0x1A * 4, 0x19 * 4, 0x2C * 4);
                townColors[45] = Color.FromArgb(0x19 * 4, 0x16 * 4, 0x2A * 4);
                townColors[46] = Color.FromArgb(0x16 * 4, 0x14 * 4, 0x28 * 4);
                townColors[47] = Color.FromArgb(0x15 * 4, 0x12 * 4, 0x27 * 4);

                townColors[48] = Color.FromArgb(0x13 * 4, 0x10 * 4, 0x25 * 4);
                townColors[49] = Color.FromArgb(0x11 * 4, 0x0E * 4, 0x22 * 4);
                townColors[50] = Color.FromArgb(0x10 * 4, 0x0C * 4, 0x20 * 4);
                townColors[51] = Color.FromArgb(0x0E * 4, 0x0B * 4, 0x1E * 4);
                townColors[52] = Color.FromArgb(0x0E * 4, 0x09 * 4, 0x1B * 4);
                townColors[53] = Color.FromArgb(0x0C * 4, 0x08 * 4, 0x19 * 4);
                townColors[54] = Color.FromArgb(0x0B * 4, 0x06 * 4, 0x16 * 4);
                townColors[55] = Color.FromArgb(0x3F * 4, 0x30 * 4, 0x3F * 4);

                townColors[56] = Color.FromArgb(0x3F * 4, 0x30 * 4, 0x3F * 4);
                townColors[57] = Color.FromArgb(0x3F * 4, 0x30 * 4, 0x3F * 4);
                townColors[58] = Color.FromArgb(0x3F * 4, 0x30 * 4, 0x3F * 4);
                townColors[59] = Color.FromArgb(0x3F * 4, 0x30 * 4, 0x3F * 4);
                townColors[60] = Color.FromArgb(0x34 * 4, 0x30 * 4, 0x3A * 4);
                townColors[61] = Color.FromArgb(0x3C * 4, 0x36 * 4, 0x3C * 4);
                townColors[62] = Color.FromArgb(0x3F * 4, 0x3C * 4, 0x3C * 4);
                townColors[63] = Color.FromArgb(0x3F * 4, 0x3F * 4, 0x3F * 4);
            }

            if (itemColors == null)
            {
                itemColors = new Color[32];

                itemColors[0] = Color.FromArgb(00*4, 00*4, 00*4);
                itemColors[1] = Color.FromArgb(56*4, 48*4, 40*4);
                itemColors[2] = Color.FromArgb(48*4, 36*4, 28*4);
                itemColors[3] = Color.FromArgb(36*4, 24*4, 16*4);
                itemColors[4] = Color.FromArgb(32*4, 20*4, 12*4);
                itemColors[5] = Color.FromArgb(24*4, 12*4, 08*4);
                itemColors[6] = Color.FromArgb(20*4, 08*4, 04*4);
                itemColors[7] = Color.FromArgb(12*4, 04*4, 00*4);

                itemColors[8] = Color.FromArgb(60*4, 56*4, 00*4);
                itemColors[9] = Color.FromArgb(25*4, 40*4, 00*4);
                itemColors[10] = Color.FromArgb(48*4, 28*4, 00*4);
                itemColors[11] = Color.FromArgb(44*4, 20*4, 00*4);
                itemColors[12] = Color.FromArgb(60*4, 36*4, 00*4);
                itemColors[13] = Color.FromArgb(60*4, 12*4, 00*4);
                itemColors[14] = Color.FromArgb(60*4, 00*4, 08*4);
                itemColors[15] = Color.FromArgb(60*4, 00*4, 32*4);

                itemColors[16] = Color.FromArgb(00*4, 16*4, 00*4);
                itemColors[17] = Color.FromArgb(00*4, 20*4, 00*4);
                itemColors[18] = Color.FromArgb(00*4, 28*4, 00*4);
                itemColors[19] = Color.FromArgb(04*4, 32*4, 00*4);
                itemColors[20] = Color.FromArgb(04*4, 40*4, 00*4);
                itemColors[21] = Color.FromArgb(28*4, 58*4, 60*4);
                itemColors[22] = Color.FromArgb(20*4, 44*4, 52*4);
                itemColors[23] = Color.FromArgb(12*4, 28*4, 48*4);

                itemColors[24] = Color.FromArgb(04*4, 12*4, 40*4);
                itemColors[25] = Color.FromArgb(00*4, 00*4, 36*4);
                itemColors[26] = Color.FromArgb(16*4, 16*4, 16*4);
                itemColors[27] = Color.FromArgb(20*4, 20*4, 20*4);
                itemColors[28] = Color.FromArgb(28*4, 28*4, 28*4);
                itemColors[29] = Color.FromArgb(36*4, 36*4, 36*4);
                itemColors[30] = Color.FromArgb(48*4, 48*4, 48*4);
                itemColors[31] = Color.FromArgb(60*4, 60*4, 60*4);
            }
        }

        static public Color getColor(palettenTyp typ, Byte input)
        {
            switch (typ)
            {
                case palettenTyp.Town_Pal:
                    return getTownColor(input);

                case palettenTyp.Item_Pal:
                    return getItemColor(input);

                default:
                    return getDefaultColor(input);
            }
        }

        static private Color getDefaultColor(Byte input)
        {
            return palette_1[input];
        }
        static private Color getTownColor(Byte input)
        {
            byte startValue = 128;
            if (input < startValue || input > (startValue + townColors.Length))
                return palette_1[input];
            else
                return townColors[input - startValue];
        }
        static private Color getItemColor(Byte input)
        {

            byte startValue = 64;
            if (input < startValue || input > (startValue + townColors.Length))
                return palette_1[input];
            else
                return itemColors[input - startValue];
        }

        public enum palettenTyp { default_Pal, Town_Pal, Item_Pal };
    }
}

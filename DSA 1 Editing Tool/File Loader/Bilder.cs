using System;
using System.Collections.Generic;
using System.Text;

using System.Drawing;

namespace DSA_1_Editing_Tool.File_Loader
{
    public class CBilder
    {
        public List<KeyValuePair<string, List<Image>>> itsImages = new List<KeyValuePair<string, List<Image>>>();
        public List<KeyValuePair<string, List<List<Image>>>> itsAnimations = new List<KeyValuePair<string,List<List<Image>>>>();

        //----------------------------------------------------------
        private List<KeyValuePair<string, CImageHeader>> itsSpezialFiles_SCHICK = new List<KeyValuePair<string, CImageHeader>>();
        private List<KeyValuePair<string, CImageHeader>> itsSpezialFiles_DSAGEN = new List<KeyValuePair<string, CImageHeader>>();
        private List<KeyValuePair<string, CImageHeader>> itsSpezialFiles_SCHWEIF = new List<KeyValuePair<string, CImageHeader>>();

        private List<string> itsTownPictures_SCHICK = new List<string>();
        private List<string> itsFightPictures_SCHICK = new List<string>();
        private List<string> itsCharMenüPictures_SCHICK = new List<string>();

        private List<string> itsAmigaPackedFiles_SCHICK = new List<string>();
        private List<string> itsAmigaPackedFiles_DSAGEN = new List<string>();
        private List<string> itsAmigaPackedFiles_SCHWEIF = new List<string>();

        private List<string> itsRLEPackedFiles_DSAGEN = new List<string>();
        private List<string> itsRLEPackedFiles_SCHWEIF = new List<string>();
        //----------------------------------------------------------

        public CBilder()
        {
            this.itsSpezialFiles_SCHICK.Add(new KeyValuePair<string, CImageHeader>("SKULL.NVF", new CImageHeader(320, 200, 64)));
            this.itsSpezialFiles_SCHICK.Add(new KeyValuePair<string, CImageHeader>("KARTE.DAT", new CImageHeader(320, 200, 32)));
            this.itsSpezialFiles_SCHICK.Add(new KeyValuePair<string, CImageHeader>("BICONS", new CImageHeader(24, 24, 0)));
            this.itsSpezialFiles_SCHICK.Add(new KeyValuePair<string, CImageHeader>("ICONS", new CImageHeader(24, 24, 0)));

            this.itsSpezialFiles_SCHICK.Add(new KeyValuePair<string, CImageHeader>("IN_HEADS.NVF", new CImageHeader(32, 32, 0)));
            this.itsSpezialFiles_SCHICK.Add(new KeyValuePair<string, CImageHeader>("SPSTAR.NVF", new CImageHeader(32, 32, 0)));

            this.itsSpezialFiles_SCHICK.Add(new KeyValuePair<string, CImageHeader>("PLAYM_UK", new CImageHeader(320, 200, 0)));
            this.itsSpezialFiles_SCHICK.Add(new KeyValuePair<string, CImageHeader>("PLAYM_US", new CImageHeader(320, 200, 0)));
            this.itsSpezialFiles_SCHICK.Add(new KeyValuePair<string, CImageHeader>("ZUSTA_UK", new CImageHeader(320, 200, 0)));
            this.itsSpezialFiles_SCHICK.Add(new KeyValuePair<string, CImageHeader>("ZUSTA_US", new CImageHeader(320, 200, 0)));

            this.itsSpezialFiles_SCHICK.Add(new KeyValuePair<string, CImageHeader>("BUCH.DAT", new CImageHeader(320, 200, 32)));
            this.itsSpezialFiles_SCHICK.Add(new KeyValuePair<string, CImageHeader>("KCBACK.DAT", new CImageHeader(320, 200, 32)));
            this.itsSpezialFiles_SCHICK.Add(new KeyValuePair<string, CImageHeader>("KCLBACK.DAT", new CImageHeader(320, 200, 32)));
            this.itsSpezialFiles_SCHICK.Add(new KeyValuePair<string, CImageHeader>("KDBACK.DAT", new CImageHeader(320, 200, 32)));
            this.itsSpezialFiles_SCHICK.Add(new KeyValuePair<string, CImageHeader>("KDLBACK.DAT", new CImageHeader(320, 200, 32)));
            this.itsSpezialFiles_SCHICK.Add(new KeyValuePair<string, CImageHeader>("KLBACK.DAT", new CImageHeader(320, 200, 32)));
            this.itsSpezialFiles_SCHICK.Add(new KeyValuePair<string, CImageHeader>("KLLBACK.DAT", new CImageHeader(320, 200, 32)));
            this.itsSpezialFiles_SCHICK.Add(new KeyValuePair<string, CImageHeader>("KSBACK.DAT", new CImageHeader(320, 200, 32)));
            this.itsSpezialFiles_SCHICK.Add(new KeyValuePair<string, CImageHeader>("KSLBACK.DAT", new CImageHeader(320, 200, 32)));

            this.itsTownPictures_SCHICK.Add("HOUSE1.NVF");
            this.itsTownPictures_SCHICK.Add("HOUSE2.NVF");
            this.itsTownPictures_SCHICK.Add("HOUSE3.NVF");
            this.itsTownPictures_SCHICK.Add("HOUSE4.NVF");
            this.itsTownPictures_SCHICK.Add("FINGER.NVF");
            this.itsTownPictures_SCHICK.Add("PLAYM_UK");
            this.itsTownPictures_SCHICK.Add("PLAYM_US");
            this.itsTownPictures_SCHICK.Add("COMPASS");
            this.itsTownPictures_SCHICK.Add("BICONS");
            this.itsTownPictures_SCHICK.Add("TEMPICON");
            this.itsTownPictures_SCHICK.Add("OBJECTS.NVF");

            this.itsCharMenüPictures_SCHICK.Add("GGSTS.NVF");
            this.itsCharMenüPictures_SCHICK.Add("ZUSTA_UK");
            this.itsCharMenüPictures_SCHICK.Add("ZUSTA_US");

            this.itsFightPictures_SCHICK.Add("WEAPONS.NVF");
            this.itsFightPictures_SCHICK.Add("SPELLOBJ.NVF");
            this.itsFightPictures_SCHICK.Add("FIGHTOBJ.NVF");
            this.itsFightPictures_SCHICK.Add("MONSTER");
            this.itsFightPictures_SCHICK.Add("MFIGS");
            this.itsFightPictures_SCHICK.Add("WFIGS");

            this.itsAmigaPackedFiles_SCHICK.Add("PLAYM_UK");
            this.itsAmigaPackedFiles_SCHICK.Add("PLAYM_US");
            this.itsAmigaPackedFiles_SCHICK.Add("ZUSTA_UK");
            this.itsAmigaPackedFiles_SCHICK.Add("ZUSTA_US");
            this.itsAmigaPackedFiles_SCHICK.Add("BUCH.DAT");
            this.itsAmigaPackedFiles_SCHICK.Add("KCBACK.DAT");
            this.itsAmigaPackedFiles_SCHICK.Add("KCLBACK.DAT");
            this.itsAmigaPackedFiles_SCHICK.Add("KDBACK.DAT");
            this.itsAmigaPackedFiles_SCHICK.Add("KDLBACK.DAT");
            this.itsAmigaPackedFiles_SCHICK.Add("KLBACK.DAT");
            this.itsAmigaPackedFiles_SCHICK.Add("KLLBACK.DAT");
            this.itsAmigaPackedFiles_SCHICK.Add("KSBACK.DAT");
            this.itsAmigaPackedFiles_SCHICK.Add("KSLBACK.DAT");
            this.itsAmigaPackedFiles_SCHICK.Add("POPUP.DAT");

            //-------DSAGEN----------------------
            this.itsSpezialFiles_DSAGEN.Add(new KeyValuePair<string, CImageHeader>("GEN1.NVF", new CImageHeader(320, 200, 0)));
            this.itsSpezialFiles_DSAGEN.Add(new KeyValuePair<string, CImageHeader>("GEN2.NVF", new CImageHeader(320, 200, 0)));
            this.itsSpezialFiles_DSAGEN.Add(new KeyValuePair<string, CImageHeader>("GEN3.NVF", new CImageHeader(320, 200, 0)));
            this.itsSpezialFiles_DSAGEN.Add(new KeyValuePair<string, CImageHeader>("GEN4.NVF", new CImageHeader(320, 200, 0)));
            this.itsSpezialFiles_DSAGEN.Add(new KeyValuePair<string, CImageHeader>("GEN5.NVF", new CImageHeader(320, 200, 0)));
            this.itsSpezialFiles_DSAGEN.Add(new KeyValuePair<string, CImageHeader>("GEN6.NVF", new CImageHeader(320, 200, 0)));
            this.itsSpezialFiles_DSAGEN.Add(new KeyValuePair<string, CImageHeader>("GEN7.NVF", new CImageHeader(320, 200, 0)));
            this.itsSpezialFiles_DSAGEN.Add(new KeyValuePair<string, CImageHeader>("GEN8.NVF", new CImageHeader(320, 200, 0)));
            this.itsSpezialFiles_DSAGEN.Add(new KeyValuePair<string, CImageHeader>("GEN9.NVF", new CImageHeader(320, 200, 0)));
            this.itsSpezialFiles_DSAGEN.Add(new KeyValuePair<string, CImageHeader>("GEN10.NVF", new CImageHeader(320, 200, 0)));
            this.itsSpezialFiles_DSAGEN.Add(new KeyValuePair<string, CImageHeader>("GEN11.NVF", new CImageHeader(320, 200, 0)));

            this.itsSpezialFiles_DSAGEN.Add(new KeyValuePair<string, CImageHeader>("DZWERG.DAT", new CImageHeader(128, 184, 32)));
            this.itsSpezialFiles_DSAGEN.Add(new KeyValuePair<string, CImageHeader>("DTHORWAL.DAT", new CImageHeader(128, 184, 32)));
            this.itsSpezialFiles_DSAGEN.Add(new KeyValuePair<string, CImageHeader>("DSTREUNE.DAT", new CImageHeader(128, 184, 32)));
            this.itsSpezialFiles_DSAGEN.Add(new KeyValuePair<string, CImageHeader>("DMENGE.DAT", new CImageHeader(128, 184, 32)));
            this.itsSpezialFiles_DSAGEN.Add(new KeyValuePair<string, CImageHeader>("DMAGIER.DAT", new CImageHeader(128, 184, 32)));
            this.itsSpezialFiles_DSAGEN.Add(new KeyValuePair<string, CImageHeader>("DKRIEGER.DAT", new CImageHeader(128, 184, 32)));
            this.itsSpezialFiles_DSAGEN.Add(new KeyValuePair<string, CImageHeader>("DDRUIDE.DAT", new CImageHeader(128, 184, 32)));
            this.itsSpezialFiles_DSAGEN.Add(new KeyValuePair<string, CImageHeader>("DAELF.DAT", new CImageHeader(128, 184, 32)));
            this.itsSpezialFiles_DSAGEN.Add(new KeyValuePair<string, CImageHeader>("DFELF.DAT", new CImageHeader(128, 184, 32)));
            this.itsSpezialFiles_DSAGEN.Add(new KeyValuePair<string, CImageHeader>("DWELF.DAT", new CImageHeader(128, 184, 32)));
            this.itsSpezialFiles_DSAGEN.Add(new KeyValuePair<string, CImageHeader>("DGAUKLER.DAT", new CImageHeader(128, 184, 32)));
            this.itsSpezialFiles_DSAGEN.Add(new KeyValuePair<string, CImageHeader>("DHEXE.DAT", new CImageHeader(128, 184, 32)));
            this.itsSpezialFiles_DSAGEN.Add(new KeyValuePair<string, CImageHeader>("DJAEGER.DAT", new CImageHeader(128, 184, 32)));

            this.itsSpezialFiles_DSAGEN.Add(new KeyValuePair<string, CImageHeader>("POPUP.DAT", new CImageHeader(16, 8, 0)));
            this.itsSpezialFiles_DSAGEN.Add(new KeyValuePair<string, CImageHeader>("SEX.DAT", new CImageHeader(16, 16, 0)));
            this.itsSpezialFiles_DSAGEN.Add(new KeyValuePair<string, CImageHeader>("ROALOGUS.DAT", new CImageHeader(320, 140, 0)));


            this.itsAmigaPackedFiles_DSAGEN.Add("DZWERG.DAT");
            this.itsAmigaPackedFiles_DSAGEN.Add("DTHORWAL.DAT");
            this.itsAmigaPackedFiles_DSAGEN.Add("DSTREUNE.DAT");
            this.itsAmigaPackedFiles_DSAGEN.Add("DMENGE.DAT");
            this.itsAmigaPackedFiles_DSAGEN.Add("DMAGIER.DAT");
            this.itsAmigaPackedFiles_DSAGEN.Add("DKRIEGER.DAT");
            this.itsAmigaPackedFiles_DSAGEN.Add("DDRUIDE.DAT");
            this.itsAmigaPackedFiles_DSAGEN.Add("DAELF.DAT");
            this.itsAmigaPackedFiles_DSAGEN.Add("DFELF.DAT");
            this.itsAmigaPackedFiles_DSAGEN.Add("DWELF.DAT");
            this.itsAmigaPackedFiles_DSAGEN.Add("DGAUKLER.DAT");
            this.itsAmigaPackedFiles_DSAGEN.Add("DHEXE.DAT");
            this.itsAmigaPackedFiles_DSAGEN.Add("DJAEGER.DAT");
            this.itsAmigaPackedFiles_DSAGEN.Add("POPUP.DAT");

            this.itsAmigaPackedFiles_DSAGEN.Add("ROALOGUS.DAT");

            this.itsRLEPackedFiles_DSAGEN.Add("GEN1.NVF");
            this.itsRLEPackedFiles_DSAGEN.Add("GEN2.NVF");
            this.itsRLEPackedFiles_DSAGEN.Add("GEN3.NVF");
            this.itsRLEPackedFiles_DSAGEN.Add("GEN4.NVF");
            this.itsRLEPackedFiles_DSAGEN.Add("GEN5.NVF");
            this.itsRLEPackedFiles_DSAGEN.Add("GEN6.NVF");
            this.itsRLEPackedFiles_DSAGEN.Add("GEN7.NVF");
            this.itsRLEPackedFiles_DSAGEN.Add("GEN8.NVF");
            this.itsRLEPackedFiles_DSAGEN.Add("GEN9.NVF");
            this.itsRLEPackedFiles_DSAGEN.Add("GEN10.NVF");
            this.itsRLEPackedFiles_DSAGEN.Add("GEN11.NVF");

            //-------------SCHWEIF-------------------------------------------

            //this.itsSpezialFiles_SCHWEIF.Add(new KeyValuePair<string, CImageHeader>("ITEMS.NVF", new CImageHeader(32, 32, 0)));
            //this.itsRLEPackedFiles_SCHWEIF.Add("ITEMS.NVF");
            //this.itsAmigaPackedFiles_SCHWEIF.Add("ITEMS.NVF");

            
        }
        //fügt den Bildern die angegebenen Bilder hinzu
        public void addPictures(ref byte[] BLADE_DAT, List<CDSAFileLoader.CFileSet> BLADE_NVFs, ref byte[] DSAGEN_DAT, List<CDSAFileLoader.CFileSet> DSAGEN_NVFs, DSAVersion version)
        {
            if (BLADE_DAT == null || BLADE_NVFs == null || DSAGEN_DAT == null || DSAGEN_NVFs == null)
                return;

            if (BLADE_NVFs.Count == 0 && DSAGEN_NVFs.Count == 0)
                CDebugger.addDebugLine("Bilder: keine NVF Dateien gefunden");
            else
                CDebugger.addDebugLine("Bilder: es wurden " + (BLADE_NVFs.Count + DSAGEN_NVFs.Count).ToString() + " NVF Dateien gefunden");

            foreach (CDSAFileLoader.CFileSet fileset in BLADE_NVFs)
            {
                this.itsImages.Add(new KeyValuePair<string, List<Image>>(fileset.filename, this.loadNVF(ref BLADE_DAT, fileset, version)));
            }
            foreach (CDSAFileLoader.CFileSet fileset in DSAGEN_NVFs)
            {
                this.itsImages.Add(new KeyValuePair<string, List<Image>>(fileset.filename, this.loadNVF(ref DSAGEN_DAT, fileset, version)));
            }
        }
        public void addPictures(ref byte[] MAIN_DAT, List<CDSAFileLoader.CFileSet> MAIN_NVFs, DSAVersion version)
        {
            if (MAIN_DAT == null || MAIN_NVFs == null)
                return;

            if (MAIN_NVFs.Count == 0)
                CDebugger.addDebugLine("Bilder: keine NVF Dateien gefunden");
            else
                CDebugger.addDebugLine("Bilder: es wurden " + MAIN_NVFs.Count.ToString() + " NVF Dateien gefunden");

            foreach (CDSAFileLoader.CFileSet fileset in MAIN_NVFs)
            {
                this.itsImages.Add(new KeyValuePair<string, List<Image>>(fileset.filename, this.loadNVF(ref MAIN_DAT, fileset, version)));
            }
        }
        //fügt den Animationen ein Archiv hinzu
        public void addArchivToList(ref byte[] data, CDSAFileLoader.CFileSet ARCHIV, CDSAFileLoader.CFileSet TAB, DSAVersion version)
        {
            if (data == null || ARCHIV == null || TAB == null)
                return;

            CDebugger.addDebugLine("Bild Archiv " + ARCHIV.filename + " wird geladen. Bitte warten...");

            List<Int32> offsets = new List<int>();

            //TAB enthält offsets mit Int32
            for (Int32 i = TAB.startOffset; i < TAB.endOffset; i += 4)
            {
                offsets.Add(CHelpFunctions.byteArrayToInt32(ref data, i));  //letzter eintrag in der TAB ist das offset des endes des letzten bildes 
            }

            CDSAFileLoader.CFileSet fileSet;
            List<List<Image>> list = new List<List<Image>>(); ;
            for (int i = 0; i < offsets.Count - 1; i++)
            {
                try
                {
                    fileSet = new CDSAFileLoader.CFileSet(ARCHIV.filename, ARCHIV.startOffset + offsets[i], ARCHIV.startOffset + offsets[i + 1]);                    
                    list.Add(this.loadNVF(ref data, fileSet, version));
                }
                catch (SystemException e)
                {
                    CDebugger.addErrorLine("Fehler beim Entpacken des Archivs " + ARCHIV.filename+" Bild "+i.ToString()+": "+e.Message);
                }
            }

            //this.itsImages.Add(new KeyValuePair<string, List<Image>>(ARCHIV.filename, images));
            this.itsAnimations.Add(new KeyValuePair<string, List<List<Image>>>(ARCHIV.filename, list));
            CDebugger.addDebugLine(list.Count.ToString() + " Animationen wurden aus dem Archiv " + ARCHIV.filename + " geladen");
        }
        //fügt den Bildern ein einzelnes Bild hinzu
        public void addPictureToList(ref byte[] data, CDSAFileLoader.CFileSet NVF, DSAVersion version)
        {
            if (data == null || NVF == null)
                return;

            this.itsImages.Add(new KeyValuePair<string, List<Image>>(NVF.filename, this.loadNVF(ref data, NVF, version)));
        }
        public void clear()
        {
            this.itsImages.Clear();
            this.itsAnimations.Clear();
        }

        //----------------------------------------------------------

        public Image getItemImageByID(Int32 ImageID)
        {
            if (ImageID < 0)
                return null;

            foreach (KeyValuePair<string, List<Image>> pair in itsImages)
            {
                if ((pair.Key == "GGSTS.NVF" || pair.Key == "ITEMS.NVF") && ImageID < pair.Value.Count)
                {
                    return new Bitmap(pair.Value[ImageID]);
                }
            }

            return null;
        }
        public Image getMonsterImageByID(Int32 MonsterBildID)
        {
            if (MonsterBildID < 0x01)
                return null;

            if (MonsterBildID < 8)//0x17) //0x17 == 23
            {
                MonsterBildID--;
                MonsterBildID *= 4;
                foreach (KeyValuePair<string, List<List<Image>>> pair in this.itsAnimations)
                {
                    if (pair.Key == "MFIGS")
                    {
                        if (pair.Value.Count > MonsterBildID && pair.Value[MonsterBildID].Count > 0)
                            return pair.Value[MonsterBildID][0];
                        else
                            return null;
                    }
                }
            }
            else if (MonsterBildID == 8)
            {
                //kleine anomalie, da ab ID 8 ein Monster mit 5 Animationen kommt, dann der Druide mit 4(kein Bogen aber Zauber) und ab 10 haben alle wieder 5 Animationen
                MonsterBildID = 29;
                foreach (KeyValuePair<string, List<List<Image>>> pair in this.itsAnimations)
                {
                    if (pair.Key == "MFIGS")
                    {
                        if (pair.Value.Count > MonsterBildID && pair.Value[MonsterBildID].Count > 0)
                            return pair.Value[MonsterBildID][0];
                        else
                            return null;
                    }
                }
            }
            else if (MonsterBildID < 0x17)
            {
                MonsterBildID = 33 + (MonsterBildID - 9) * 5;
                foreach (KeyValuePair<string, List<List<Image>>> pair in this.itsAnimations)
                {
                    if (pair.Key == "MFIGS")
                    {
                        if (pair.Value.Count > MonsterBildID && pair.Value[MonsterBildID].Count > 0)
                            return pair.Value[MonsterBildID][0];
                        else
                            return null;
                    }
                }
            }
            else
            {
                MonsterBildID -= 0x17;
                MonsterBildID *= 2;

                foreach (KeyValuePair<string, List<List<Image>>> pair in this.itsAnimations)
                {
                    if (pair.Key == "MONSTER")
                    {
                        if (pair.Value.Count > MonsterBildID && pair.Value[MonsterBildID].Count > 0)
                            return pair.Value[MonsterBildID][0];
                        else
                            return null;
                    }
                }
            }



            //if (MonsterBildID < this.itsMonsterImages.Count && this.itsMonsterImages[MonsterBildID].Count > 0)
            //    return this.itsMonsterImages[MonsterBildID][0];

            return null;
        }
        public Image getIn_HeadsImageByID(Int32 ImageID)
        {
            if (ImageID < 0)
                return null;

            foreach (KeyValuePair<string, List<Image>> pair in itsImages)
            {
                if (pair.Key == "IN_HEADS.NVF" && ImageID < pair.Value.Count)
                {
                    return new Bitmap(pair.Value[ImageID]);
                }
            }

            return null;
        }
        public Image getWoldMap()
        {
            foreach (KeyValuePair<string, List<Image>> pair in this.itsImages)
            {
                if (pair.Key == "KARTE.DAT")
                {
                    if (pair.Value.Count > 0)
                        return new Bitmap(pair.Value[0]);

                    return null;
                }
            }
            return null;
        }
        
        public void getImageCount(out Int32 fileCount, out Int32 imageCount)
        {
            fileCount = this.itsImages.Count;

            Int32 images = 0;

            foreach (KeyValuePair<string, List<Image>> pair in this.itsImages)
                images += pair.Value.Count;

            imageCount = images;
        }

        //----------------------------------------------------------

        private List<Image> loadNVF(ref byte[] data, CDSAFileLoader.CFileSet NVF, DSAVersion version)
        {
            List<Image> images = new List<Image>();
            byte[] unpackedData = null;

            CImageHeader header = this.checkForSpezialFile(NVF.filename, version); // header == null wenn es keine spezielle Datei ist und einen eigenen Header besitzt

            //----------------------------------------
            //  schauen ob das Bild gepackt ist
            if (checkForAmigaPackedFile(NVF.filename, version))
            {
                try
                {
                    unpackedData = CHelpFunctions.unpackAmiga2Data(ref data, NVF.startOffset, NVF.endOffset - NVF.startOffset);
                    NVF.endOffset = unpackedData.Length;
                    NVF.startOffset = 0;
                }
                catch (SystemException)
                {
                    CDebugger.addErrorLine("Fehler beim entpacken der Datei " + NVF.filename + " (amiga)");
                    return images;
                }
            }
            else if (checkForRLEPackedFile(NVF.filename, version))
            {
                if (header == null)
                {
                    CDebugger.addErrorLine("kein Header für die RLE gepackte Datei " + NVF.filename + " gefunden");
                    return images;
                }
                try
                {
                    unpackedData = CHelpFunctions.unpackRLEFile(ref data, NVF.startOffset, NVF.endOffset - NVF.startOffset, (UInt32)(header.height*header.width + 2 + 3*header.anzahlFarben));
                    NVF.endOffset = unpackedData.Length;
                    NVF.startOffset = 0;
                }
                catch (SystemException)
                {
                    CDebugger.addErrorLine("Fehler beim entpacken der Datei " + NVF.filename + " (RLE)");
                    return images;
                }
            }
            else
                unpackedData = data;
            //----------------------------------------

            int offset = NVF.startOffset;

            if (NVF.filename.Substring(0, 4) == "ANIS")
            {
                images.AddRange(this.loadANISImages(ref data, NVF));
                return images;
            }
            else if (header == null)
            {
                //header vorhanden
                byte crunchmode = unpackedData[offset];

                if (crunchmode <= 1)
                {
                    try
                    {
                        //unkomrimiert
                        images.AddRange(this.loadUncompressedImage(ref unpackedData, NVF, version));
                    }
                    catch (SystemException)
                    {
                        CDebugger.addErrorLine("Fehler beim laden des Bildes: " + NVF.filename + "(Unkomprimiert)");
                        return images;
                    }
                }
                else if (crunchmode == 2 || crunchmode == 3)
                {
                    try
                    {
                        //Amiga Power Pack 2.0 Kompression
                        images.AddRange(this.loadAmigaImage(ref unpackedData, NVF, version));
                    }
                    catch (SystemException)
                    {
                        CDebugger.addErrorLine("Fehler beim laden des Bildes: " + NVF.filename + "(Amiga)");
                        return images;
                    }
                }
                else if (crunchmode == 4 || crunchmode == 5)
                {
                    try
                    {
                        //RLE Kompression
                        images.AddRange(this.loadRLEImage(ref unpackedData, NVF, version));
                    }
                    catch (SystemException)
                    {
                        CDebugger.addErrorLine("Fehler beim laden des Bildes: " + NVF.filename + "(RLE)");
                        return images;
                    }
                }
                else
                {
                    CDebugger.addErrorLine("Unbekannter Crunchmode: " + crunchmode.ToString() + " in der Datei " + NVF.filename);
                    return images;
                }
            }
            else
            {
                //Bild ist nicht gepackt
                //besitzt aber auch keinen Header und beginnt direkt mit den Bilddaten
                try
                {
                    images.AddRange(this.loadImageWithoutHeader(ref unpackedData, NVF, header, version));
                }
                catch (SystemException)
                {
                    CDebugger.addErrorLine("Fehler beim laden des Bildes: " + NVF.filename + "(kein Header)");
                    return images;
                }
            }

            return images;
        }

        private CImageHeader checkForSpezialFile(string filename, DSAVersion version)
        {
            switch (version)
            {
                case DSAVersion.Blade:
                case DSAVersion.Schick:
                    foreach (KeyValuePair<string,CImageHeader> pair in this.itsSpezialFiles_SCHICK)
                    {
                        if (pair.Key == filename)
                            return pair.Value;
                    }
                    foreach (KeyValuePair<string, CImageHeader> pair in this.itsSpezialFiles_DSAGEN)
                    {
                        if (pair.Key == filename)
                            return pair.Value;
                    }
                    return null;

                case DSAVersion.Schweif:
                    foreach (KeyValuePair<string,CImageHeader> pair in this.itsSpezialFiles_SCHWEIF)
                    {
                        if (pair.Key == filename)
                            return pair.Value;
                    }
                    return null;

                default:
                    return null;
            }
        }
        private bool checkForAmigaPackedFile(string filename, DSAVersion version)
        {
            switch (version)
            {
                case DSAVersion.Blade:
                case DSAVersion.Schick:
                    foreach (string s in this.itsAmigaPackedFiles_SCHICK)
                    {
                        if (s == filename)
                            return true;
                    }

                    foreach (string s in this.itsAmigaPackedFiles_DSAGEN)
                    {
                        if (s == filename)
                            return true;
                    }

                    return false;

                case DSAVersion.Schweif:
                    foreach (string s in this.itsAmigaPackedFiles_SCHWEIF)
                    {
                        if (s == filename)
                            return true;
                    }
                    return false;

                default:
                    return false;
            }
        }
        private bool checkForRLEPackedFile(string filename, DSAVersion version)
        {
            switch(version)
            {
                case DSAVersion.Blade:
                case DSAVersion.Schick:
                    foreach (string s in this.itsRLEPackedFiles_DSAGEN)
                    {
                        if (s == filename)
                            return true;
                    }

                    return false;

                case DSAVersion.Schweif:
                    foreach (string s in this.itsRLEPackedFiles_SCHWEIF)
                    {
                        if (s == filename)
                            return true;
                    }

                    return false;

                default:
                    return false;
            }
        }
        private CFarbPalette.palettenTyp getPalettenTyp(string filename, DSAVersion version)
        {
            switch (version)
            {
                case DSAVersion.Blade:
                case DSAVersion.Schick:
                    foreach (string s in itsTownPictures_SCHICK)
                    {
                        if (s == filename)
                            return CFarbPalette.palettenTyp.Town_Pal;
                    }

                    foreach (string s in itsFightPictures_SCHICK)
                    {
                        if (s == filename)
                            return CFarbPalette.palettenTyp.Fight_Pal;
                    }

                    foreach (string s in itsCharMenüPictures_SCHICK)
                    {
                        if (s == filename)
                            return CFarbPalette.palettenTyp.CharMenü_Pal;
                    }

                    if (filename == "ATTIC")
                        return CFarbPalette.palettenTyp.Logo_Attic;

                    if (filename == "DSALOGO.DAT")
                        return CFarbPalette.palettenTyp.GEN_Pal;

                    if (filename == "GENTIT.DAT")
                        return CFarbPalette.palettenTyp.GEN_Pal;

                    if (filename == "ROALOGUS.DAT")
                        return CFarbPalette.palettenTyp.GEN_Pal;

                    return CFarbPalette.palettenTyp.default_Pal;

                case DSAVersion.Schweif:
                    return CFarbPalette.palettenTyp.default_Pal;

                default:
                    return CFarbPalette.palettenTyp.default_Pal;
            }
        }

        private List<Image> loadAmigaImage(ref byte[] data, CDSAFileLoader.CFileSet NVF, DSAVersion version)
        {
            List<Image> images = new List<Image>();
            int beginOfDataBlock;
            int dataBlocklength = 0;
            int headerblocklength;

            int offset = NVF.startOffset;

            //-------------Header auslesen----------------------------
            int anzahlBilder = CHelpFunctions.byteArrayToInt16(ref data, offset + 1);
            int[] width = new int[anzahlBilder];
            int[] height = new int[anzahlBilder];
            Int32[] depackLengths = new Int32[anzahlBilder];
            Int32 unpackesDataLength = 0;

            if ((data[offset] & 0x01) == 0)
                headerblocklength = 4;
            else
                headerblocklength = 8;

            int position = offset + 3;

            //int helpvalue = 0;  //gibt die Länge eines Datenblocks an
            if ((data[offset] & 0x01) != 0)
            {
                //unterschiedliche Auflösungen der Bilder
                for (int i = 0; i < anzahlBilder; i++)
                {
                    width[i] = CHelpFunctions.byteArrayToInt16(ref data, position);
                    height[i] = CHelpFunctions.byteArrayToInt16(ref data, position + 2);

                    unpackesDataLength += width[i]*height[i];

                    int value = CHelpFunctions.byteArrayToInt32(ref data, position + 4);
                    dataBlocklength += value;
                    depackLengths[i] = value;

                    position += headerblocklength;

                }
            }
            else
            {
                //gleiche Auflösungen der Bilder
                int tempwidth = CHelpFunctions.byteArrayToInt16(ref data, position);
                int tempheight = CHelpFunctions.byteArrayToInt16(ref data, position + 2);

                position += 4;

                for (int i = 0; i < anzahlBilder; i++)
                {
                    width[i] = tempwidth;
                    height[i] = tempheight;

                    unpackesDataLength += tempwidth*tempheight;

                    int value = CHelpFunctions.byteArrayToInt32(ref data, position);
                    dataBlocklength += value;
                    depackLengths[i] = value;

                    position += headerblocklength;
                }
            }

            beginOfDataBlock = position;    //am ende des headers beginnt der Datenblock

            //---------Prüfen ob Farbpalette am ende des Datenblocks vorhanden ist-----------------
            bool hasFarbpalette = ((beginOfDataBlock + dataBlocklength) < NVF.endOffset);
            Color[] colors = null;

            if (hasFarbpalette)
            {
                position = beginOfDataBlock + dataBlocklength;
                UInt32 anzahlFarben = (UInt16)CHelpFunctions.byteArrayToInt16(ref data, position);

                //---auslesen der Farbpalette---            
                try
                {
                    position += 2;
                    colors = new Color[anzahlFarben];
                    for (int i = 0; i < anzahlFarben; i++)
                    {
                        colors[i] = Color.FromArgb((byte)(data[position++] * 4), (byte)(data[position++] * 4), (byte)(data[position++] * 4));
                    }
                }
                catch (SystemException)
                {
                    CDebugger.addDebugLine("Fehler beim Laden der Farbpaltte in der Datei " + NVF.filename + " (Amiga)");
                    return images;
                }
            }

            position = beginOfDataBlock;
            CFarbPalette.palettenTyp typ = this.getPalettenTyp(NVF.filename, version);

            //---------Bilddaten auslesen-----------
            for (int i = 0; i < anzahlBilder; i++)
            {
                byte[] bytes = CHelpFunctions.unpackAmiga2Data(ref data, position, depackLengths[i]);
                
                Int32 bytePosition = 0;

                Bitmap image = new Bitmap(width[i], height[i]);

                for (int y = 0; y < image.Height; y++)
                {
                    for (int x = 0; x < image.Width; x++)
                    {
                        if (!hasFarbpalette)
                        {
                            image.SetPixel(x, y, CFarbPalette.getColor(typ, bytes[bytePosition]));
                        }
                        else
                            image.SetPixel(x, y, colors[bytes[bytePosition] % colors.Length]);

                        bytePosition++;
                    }
                }

                position += depackLengths[i];
                images.Add(image);
            }

            return images;
        }
        private List<Image> loadRLEImage(ref byte[] data, CDSAFileLoader.CFileSet NVF, DSAVersion version)
        {
            List<Image> images = new List<Image>();
            int beginOfDataBlock;
            int dataBlocklength = 0;
            int headerblocklength;

            int offset = NVF.startOffset;

            //-------------Header auslesen----------------------------
            int anzahlBilder = CHelpFunctions.byteArrayToInt16(ref data, offset + 1);
            int[] width = new int[anzahlBilder];
            int[] height = new int[anzahlBilder];

            if ((data[offset] & 0x01) == 0)
                headerblocklength = 4;
            else
                headerblocklength = 8;

            int position = offset + 3;

            //int helpvalue = 0;  //gibt die Länge eines Datenblocks an
            if ((data[offset] & 0x01) != 0)
            {
                //unterschiedliche Auflösungen der Bilder
                for (int i = 0; i < anzahlBilder; i++)
                {
                    width[i] = CHelpFunctions.byteArrayToInt16(ref data, position);
                    height[i] = CHelpFunctions.byteArrayToInt16(ref data, position + 2);

                    int value = CHelpFunctions.byteArrayToInt32(ref data, position + 4);
                    dataBlocklength += value;

                    position += headerblocklength;
                }
            }
            else
            {
                //gleiche Auflösungen der Bilder
                int tempwidth = CHelpFunctions.byteArrayToInt16(ref data, position);
                int tempheight = CHelpFunctions.byteArrayToInt16(ref data, position + 2);

                position += 4;

                for (int i = 0; i < anzahlBilder; i++)
                {
                    width[i] = tempwidth;
                    height[i] = tempheight;

                    int value = CHelpFunctions.byteArrayToInt32(ref data, position);
                    dataBlocklength += value;

                    position += headerblocklength;
                }
            }

            beginOfDataBlock = position;    //am ende des headers beginnt der Datenblock

            //---------Prüfen ob Farbpalette am ende des Datenblocks vorhanden ist-----------------
            bool hasFarbpalette = ((beginOfDataBlock + dataBlocklength) < NVF.endOffset);
            Color[] colors = null;

            if (hasFarbpalette)
            {
                position = beginOfDataBlock + dataBlocklength;
                UInt32 anzahlFarben = (UInt16)CHelpFunctions.byteArrayToInt16(ref data, position);

                //---auslesen der Farbpalette---            
                try
                {
                    position += 2;
                    colors = new Color[anzahlFarben];
                    for (int i = 0; i < anzahlFarben; i++)
                    {
                        colors[i] = Color.FromArgb((byte)(data[position++] * 4), (byte)(data[position++] * 4), (byte)(data[position++] * 4));
                    }
                }
                catch (SystemException)
                {
                    CDebugger.addDebugLine("Fehler beim Laden der Farbpaltte in der Datei " + NVF.filename + " (RLE)");
                    return images;
                }
            }

            position = beginOfDataBlock;
            CFarbPalette.palettenTyp typ = this.getPalettenTyp(NVF.filename, version);

            //---------Bilddaten auslesen-----------
            for (int i = 0; i < anzahlBilder; i++)
            {
                Bitmap image = new Bitmap(width[i], height[i]);

                //---zum Entpacken---
                bool unpacking = false; //gibt an, ob gerade entpackt wird
                byte wiederholungen = 0;
                byte aktuelleWiederholung = 0;
                byte value = 0;
                //-------------------

                for (int y = 0; y < height[i]; y++)
                {
                    for (int x = 0; x < width[i]; x++)
                    {
                        if (data[position] != 0x7F && !unpacking)
                        {
                            //hier ist keine komopression
                            if (!hasFarbpalette)
                                image.SetPixel(x, y, CFarbPalette.getColor(typ, data[position]));
                            else
                                image.SetPixel(x, y, colors[data[position] % colors.Length]);

                            position++;
                        }
                        else
                        {
                            //entpacken...
                            if (!unpacking)
                            {
                                // starten eines neuen entpackvorgangen
                                position++;
                                wiederholungen = data[position++];
                                aktuelleWiederholung = 0;
                                value = data[position++];

                                unpacking = true;

                                if (!hasFarbpalette)
                                    image.SetPixel(x, y, CFarbPalette.getColor(this.getPalettenTyp(NVF.filename, version), value));
                                else
                                    image.SetPixel(x, y, colors[value % colors.Length]);

                                aktuelleWiederholung++;
                            }
                            else
                            {
                                // es läuft bereits ein entpackvorgang

                                if (!hasFarbpalette)
                                    image.SetPixel(x, y, CFarbPalette.getColor(this.getPalettenTyp(NVF.filename, version), value));
                                else
                                    image.SetPixel(x, y, colors[value % colors.Length]);

                                if (++aktuelleWiederholung >= wiederholungen)
                                    unpacking = false;    
                            }
                        }
                    }
                }
                images.Add(image);
            }               

            return images;
        }
        private List<Image> loadUncompressedImage(ref byte[] data, CDSAFileLoader.CFileSet NVF, DSAVersion version)
        {
            List<Image> images = new List<Image>();

            int offset = NVF.startOffset;

            int anzahlBilder = CHelpFunctions.byteArrayToInt16(ref data, offset + 1);

            int[] width = new int[anzahlBilder];
            int[] height = new int[anzahlBilder];

            int headerblocklength = 0;  //die länge des Variablen Headerblock (Auflösung + gepackte Dateilänge)(8 Bytes) oder (gepackte Dateilänge)(4 Bytes)

            int beginOfDataBlock;
            int dataBlocklength = 0;

            
            if ((data[offset] & 0x01) == 0)
                headerblocklength = 0;
            else
                headerblocklength = 4;

            int position = offset + 3;

            //---------bestimmen der Datenblock und Bild Größen-----------------
            //int helpvalue = 0;  //gibt die Länge eines Datenblocks an
            if ((data[offset] & 0x01) != 0)
            {
                //unterschiedliche Auflösungen der Bilder
                for (int i = 0; i < anzahlBilder; i++)
                {

                    width[i] = CHelpFunctions.byteArrayToInt16(ref data, position);
                    height[i] = CHelpFunctions.byteArrayToInt16(ref data, position + 2);

                    dataBlocklength += width[i] * height[i];

                    position += headerblocklength;
                }
            }
            else
            {
                //gleiche Auflösungen der Bilder
                int tempwidth = CHelpFunctions.byteArrayToInt16(ref data, position);
                int tempheight = CHelpFunctions.byteArrayToInt16(ref data, position + 2);

                position += 4;

                for (int i = 0; i < anzahlBilder; i++)
                {
                    width[i] = tempwidth;
                    height[i] = tempheight;

                    dataBlocklength += tempwidth * tempheight;
                }
            }

            beginOfDataBlock = position;

            bool hasFarbPalette = ((beginOfDataBlock + dataBlocklength) < NVF.endOffset);
            position = beginOfDataBlock + dataBlocklength;

            Color[] colors = null;
            if (hasFarbPalette)
            {
                
                int anzahlFarben = CHelpFunctions.byteArrayToInt16(ref data, position);
                position += 2;
                colors = new Color[anzahlFarben];
                for (int i = 0; i < anzahlFarben; i++)
                {
                    //colors[i] = Color.FromArgb(data[position++], data[position++], data[position++]);
                    colors[i] = Color.FromArgb((byte)(data[position++] * 4), (byte)(data[position++] * 4), (byte)(data[position++] * 4));
                }
            }

            position = beginOfDataBlock;
            CFarbPalette.palettenTyp typ = this.getPalettenTyp(NVF.filename, version);

            for (int i = 0; i < anzahlBilder; i++)
            {
                Bitmap image = new Bitmap(width[i], height[i]);
                //keine farbpalette
                for (int y = 0; y < height[i]; y++)
                {
                    for (int x = 0; x < width[i]; x++)
                    {
                        if (hasFarbPalette)
                            image.SetPixel(x, y, colors[data[position]]);
                        else
                            image.SetPixel(x, y, CFarbPalette.getColor(typ, data[position]));
                        position++;
                    }
                }
                images.Add(image);
            }

            return images;
        }

        /**
         * Spezial-Ladefunktion für ANIS
         */
        private List<Image> loadANISImages(ref byte[] data, CDSAFileLoader.CFileSet NVF)
        {
            List<Image> images = new List<Image>();
            int position = NVF.startOffset;

            // ANIS-Header einlesen
            int imagedataoffset = CHelpFunctions.byteArrayToInt32(ref data, position);
            int paletteoffset = CHelpFunctions.byteArrayToInt32(ref data, position+4);
            int iwidth = CHelpFunctions.byteArrayToInt16(ref data, position+8);
            int iheight = (int)data[position + 10];

            int numelements = (int)data[position + 11]; //Anzahl der Subelemente auslesen

            //Offsets der Subelemente auslesen
            List<int> elementoffsets = new List<int>(numelements);
            position = NVF.startOffset + 12;
            for (int i = 0; i < numelements; i++)
            {
                elementoffsets.Add(CHelpFunctions.byteArrayToInt32(ref data, position));
                position += 4;
            }

            //Subelement infos auslesen
            List<CBOBElement> subElements = new List<CBOBElement>(numelements);
            foreach (int offset in elementoffsets)
            {
                subElements.Add(new CBOBElement(ref data, NVF.startOffset + offset));
            }

            // Farbpalette auslesen
            Color[] colors = null;
            position = NVF.startOffset + paletteoffset + 6;     //Anzahl der Farben steht nicht drin, sondern muss berechnet werden
            int anzahlFarben = (NVF.endOffset - position) / 3;
            try
            {
                colors = new Color[anzahlFarben];
                for (int i = 0; i < anzahlFarben; i++)
                {
                    colors[i] = Color.FromArgb(Math.Min(255, data[position++] * 4), Math.Min(255, data[position++] * 4), Math.Min(255, data[position++] * 4));
                }
            }
            catch (SystemException e)
            {
                CDebugger.addErrorLine("Fehler beim laden der Farbpalette der Datei " + NVF.filename + ": " + e.Message);
                return images;
            }

            //////////////////////////////////////
            //      Hauptbild entpacken         //
            //////////////////////////////////////
            position =  NVF.startOffset + imagedataoffset;

            int packedLength = CHelpFunctions.byteArrayToInt32(ref data, position);
            bool packed = true;
            byte[] bytes = null;
            if (packedLength > iwidth * iheight)
            {
                // daten dürften ungepackt sein
                bytes = new byte[iwidth * iheight];
                Buffer.BlockCopy(data, position, bytes, 0, iwidth * iheight);
                packed = false;
            }
            else
                bytes = CHelpFunctions.unpackAmiga2Data(ref data, position, packedLength);

            Bitmap image = new Bitmap(iwidth, iheight);
            int positionInUnpackedData = 0;
            int x = 0, y = 0;
            try
            {
                for (y = 0; y < iheight; y++)
                {
                    for (x = 0; x < iwidth; x++)
                    {
                        image.SetPixel(x, y, colors[bytes[positionInUnpackedData] % colors.Length]);
                        positionInUnpackedData++;
                    }
                }
            }
            catch (SystemException e)
            {
                CDebugger.addErrorLine("Fehler beim Bild befüllen auf " + x + "/" + y + ", position " + positionInUnpackedData + ", Größe " + bytes.Length + ": " + e.Message);
            }
            images.Add(image);

            if (packed)
                position += packedLength;
            else
                position += (iwidth * iheight);

            //////////////////////////////////////
            //      Subelemente entpacken       //
            //////////////////////////////////////
            //int bobCount = 0;
            foreach (CBOBElement bob in subElements)
            {
                //bobCount++;
                //CDebugger.addDebugLine("BobCount: " + bobCount.ToString() + "/" + subElements.Count);

                packedLength = CHelpFunctions.byteArrayToInt32(ref data, position);
                positionInUnpackedData = 0;

                //prüfen ob die Daten gepackt sind...falls es mal Probleme gibt, könnte man auch einfach Versuchen sie zu entpacken und dann auf "null" zu prüfen
                if (packedLength > bob.width * bob.height * bob.bilder.Count)
                {
                    // daten dürften ungepackt sein
                    bytes = new byte[bob.width * bob.height * bob.bilder.Count];
                    Buffer.BlockCopy(data, position, bytes, 0, bob.width * bob.height * bob.bilder.Count);
                    packed = false;
                }
                else
                    bytes = CHelpFunctions.unpackAmiga2Data(ref data, position, packedLength);
                    

                foreach (CBOBElement.CEinzelbild einzelbild in bob.bilder)
                {
                    image = new Bitmap(bob.width, bob.height);
                    try
                    {
                        for (y = 0; y < bob.height; y++)
                        {
                            for (x = 0; x < bob.width; x++)
                            {
                                image.SetPixel(x, y, colors[bytes[positionInUnpackedData++] % colors.Length]);
                            }
                        }
                        images.Add(image);
                    }
                    catch (SystemException e)
                    {
                        CDebugger.addErrorLine("Fehler beim Bild befüllen auf " + x.ToString() + "/" + y.ToString() + ", position " + positionInUnpackedData + ", Größe " + bytes.Length + ": " + e.Message);
                    }
                }

                if (packed)
                    position += packedLength;
                else
                    position += (bob.width * bob.height * bob.bilder.Count);
            }

            return images;
        }
        private class CBOBElement
        {
            public List<CEinzelbild> bilder = new List<CEinzelbild>();
            public List<CAnimation> animationen = new List<CAnimation>();

            public int width = 0;
            public int height = 0;

            public CBOBElement(ref byte[] data, int position)
            {
                height = data[position + 7];
                width = data[position + 8];
                position += 11; //die Verwendung der ersten 11 Elemente ist unbekannt

                int anzahlBilder = data[position++];
                for (int i = 0; i < anzahlBilder; i++)
                {
                    bilder.Add(new CEinzelbild(ref data, position));
                    position += 4;
                }

                int anzahlAnimationen = CHelpFunctions.byteArrayToInt16(ref data, position);
                position += 2;
                for (int i = 0; i < anzahlAnimationen; i++)
                {
                    animationen.Add(new CAnimation(ref data, position));
                    position += 4;
                }
            }

            public class CEinzelbild
            {
                public int posX = 0;
                public int posY = 0;

                public CEinzelbild(ref byte[] data, int position)
                {
                    this.posX = data[position++];
                    this.posY = data[position++];   
                }
            }

            public class CAnimation
            {
                public int BildIndex = 0;
                public int TimeDelay = 15;

                public CAnimation(ref byte[] data, int position)
                {
                    this.BildIndex = CHelpFunctions.byteArrayToInt16(ref data, position);
                    position += 2;
                    this.TimeDelay = CHelpFunctions.byteArrayToInt16(ref data, position);
                    position += 2;
                }
            }
        }

        private List<Image> loadImageWithoutHeader(ref byte[] data, CDSAFileLoader.CFileSet NVF, CImageHeader header, DSAVersion version)
        {
            List<Image> images = new List<Image>();

            if (header == null)
            {
                CDebugger.addErrorLine("Fehler beim laden der Datei " + NVF.filename + " (es wurde kein Header übergeben)");
                return images;
            }

            //int position = NVF.startOffset + header.height * header.width;
            int position = NVF.endOffset - header.anzahlFarben*3 - 2;

            Color[] colors = null;
            int helpvalue = 0;
            int anzahlFarben = 0;
            if (header.anzahlFarben != 0)
            {
                anzahlFarben = CHelpFunctions.byteArrayToInt16(ref data, position);

                if (anzahlFarben != header.anzahlFarben)
                    CDebugger.addErrorLine("Anzahl der Farben in der Datei " + NVF.filename + " wurde nicht korrekt angegeben (" + anzahlFarben.ToString() + ")");

                helpvalue = 2;
                position += 2;
                
                try
                {
                    colors = new Color[anzahlFarben];
                    for (int i = 0; i < anzahlFarben; i++)
                    {
                        colors[i] = Color.FromArgb(data[position++] * 4, data[position++] * 4, data[position++] * 4);
                    }
                }
                catch(SystemException)
                {
                    CDebugger.addErrorLine("Fehler beim Laden der Farbpaltte in der Datei " + NVF.filename + " (kein Header)");
                    return images;
                }
            }
            
            position = NVF.startOffset;
            CFarbPalette.palettenTyp typ = this.getPalettenTyp(NVF.filename, version);

            while ((position + header.height*header.width + anzahlFarben + helpvalue) <= NVF.endOffset)    //solange das ende der Datei nicht erreicht ist, sind noch bilder vorhanden
            {
                Bitmap image = new Bitmap(header.width, header.height);

                for (int y = 0; y < header.height; y++)
                {
                    for (int x = 0; x < header.width; x++)
                    {
                        if (header.anzahlFarben == 0)
                            image.SetPixel(x, y, CFarbPalette.getColor(typ, data[position]));
                        else
                            image.SetPixel(x, y, colors[data[position] % colors.Length]);

                        position++;
                    }
                }

                images.Add(image);
            }           

            return images;
        }       

        private class CImageHeader  //für Bilder ohne eigenen Header
        {
            public int width = 0;
            public int height = 0;
            public int anzahlFarben = 0;
            public bool isRLEPacked = false;

            public CImageHeader(int width, int height, int anzahlFarben)
            {
                this.width = width;
                this.height = height;
                this.anzahlFarben = anzahlFarben;
            }
            public CImageHeader(int width, int height, int anzahlFarben, bool isRLEPacked)
            {
                this.width = width;
                this.height = height;
                this.anzahlFarben = anzahlFarben;

                this.isRLEPacked = isRLEPacked;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

using DSA_1_Editing_Tool.File_Loader;
using System.IO;
using System.Drawing;

namespace DSA_1_Editing_Tool
{
    public class CDSAFileLoader
    {
        public string itsPathSign = "";

        // zum auslesens der .DAT und der ...
        List<string> itsFilenames = new List<string>();
        List<Int32> itsSCHICKOffsets = new List<Int32>();

        List<KeyValuePair<string, Int32>> itsDSAGENOffsets = new List<KeyValuePair<string, Int32>>();

        byte[] MAIN_DAT = null;
        byte[] DSAGEN_DAT = null;

        // zum auslesen der einzelnen Dateien
        public CItemList itemList = new CItemList();
        public CTextList texte = new CTextList();
        public CMonster monster = new CMonster();
        public CKampf kampf = new CKampf();
        public CStädte städte = new CStädte();
        public CDungeons dungeons = new CDungeons();
        public CBilder bilder = new CBilder();
        public CRouten routen = new CRouten();
        public CDialoge dialoge = new CDialoge();

        public class CFileSet
        {
            public Int32 startOffset = 0;
            public Int32 endOffset = 0;
            public string filename = "";

            public CFileSet(string filename, Int32 startOffset, Int32 endOffset)
            {
                this.filename = filename;
                this.startOffset = startOffset;
                this.endOffset = endOffset;
            }
        }

        public bool loadFiles(string filepath)
        {
            if (!this.unpackAll(filepath))
                return false;

            CFileSet fileset_1;
            CFileSet fileset_2;
            CFileSet fileset_3;
            List<CFileSet> filesetList_1;
            List<CFileSet> filesetList_2;

            fileset_1 = this.getFileByName("ITEMS.DAT", false);
            fileset_2 = this.getFileByName("ITEMNAME", false);
            this.itemList.LoadItems(ref this.MAIN_DAT, fileset_1, fileset_2);

            filesetList_1 = this.getFilesBySuffix(".LTX", false);
            filesetList_2 = this.getFilesBySuffix(".DTX", false);
            this.texte.loadTexte(ref this.MAIN_DAT, filesetList_1, filesetList_2);

            fileset_1 = this.getFileByName("MONSTER.DAT", false);
            fileset_2 = this.getFileByName("MONNAMES", false);
            this.monster.loadMonster(ref this.MAIN_DAT, fileset_1, fileset_2);

            fileset_1 = this.getFileByName("FIGHT.LST", false);
            this.kampf.loadKämpfe(ref this.MAIN_DAT, fileset_1);

            filesetList_1 = this.getTownFiles();
            this.städte.loadStädte(ref this.MAIN_DAT, filesetList_1);

            filesetList_1 = this.getFilesBySuffix(".DNG", false);
            filesetList_2 = this.getFilesBySuffix(".DDT", false);
            this.dungeons.loadDungeons(ref this.MAIN_DAT, filesetList_1, filesetList_2);

            filesetList_1 = this.getFilesBySuffix(".NVF", false);
            filesetList_2 = this.getFilesBySuffix(".NVF", true);
            this.bilder.loadPictures(ref this.MAIN_DAT, filesetList_1, ref this.DSAGEN_DAT, filesetList_2);
            //-------------Main Images------------------
            CDebugger.addDebugLine("weitere Bilder werden geladen, bitte warten...");

            fileset_1 = this.getFileByName("COMPASS", false);
            this.bilder.addPictureToList(ref this.MAIN_DAT, fileset_1);
            fileset_1 = this.getFileByName("SPLASHES.DAT", false);
            this.bilder.addPictureToList(ref this.MAIN_DAT, fileset_1);
            fileset_1 = this.getFileByName("TEMPICON", false);
            this.bilder.addPictureToList(ref this.MAIN_DAT, fileset_1);
            fileset_1 = this.getFileByName("KARTE.DAT", false);
            this.bilder.addPictureToList(ref this.MAIN_DAT, fileset_1);
            fileset_1 = this.getFileByName("BICONS", false);
            this.bilder.addPictureToList(ref this.MAIN_DAT, fileset_1);
            fileset_1 = this.getFileByName("ICONS", false);
            this.bilder.addPictureToList(ref this.MAIN_DAT, fileset_1);

            //-------------Main Power Pack--------------
            fileset_1 = this.getFileByName("PLAYM_UK", false);
            this.bilder.addPictureToList(ref this.MAIN_DAT, fileset_1);
            fileset_1 = this.getFileByName("PLAYM_US", false);
            this.bilder.addPictureToList(ref this.MAIN_DAT, fileset_1);
            fileset_1 = this.getFileByName("ZUSTA_UK", false);
            this.bilder.addPictureToList(ref this.MAIN_DAT, fileset_1);
            fileset_1 = this.getFileByName("ZUSTA_US", false);
            this.bilder.addPictureToList(ref this.MAIN_DAT, fileset_1);

            fileset_1 = this.getFileByName("BUCH.DAT", false);
            this.bilder.addPictureToList(ref this.MAIN_DAT, fileset_1);
            fileset_1 = this.getFileByName("KCBACK.DAT", false);
            this.bilder.addPictureToList(ref this.MAIN_DAT, fileset_1);
            fileset_1 = this.getFileByName("KCLBACK.DAT", false);
            this.bilder.addPictureToList(ref this.MAIN_DAT, fileset_1);
            fileset_1 = this.getFileByName("KDBACK.DAT", false);
            this.bilder.addPictureToList(ref this.MAIN_DAT, fileset_1);
            fileset_1 = this.getFileByName("KDLBACK.DAT", false);
            this.bilder.addPictureToList(ref this.MAIN_DAT, fileset_1);
            fileset_1 = this.getFileByName("KLBACK.DAT", false);
            this.bilder.addPictureToList(ref this.MAIN_DAT, fileset_1);
            fileset_1 = this.getFileByName("KLLBACK.DAT", false);
            this.bilder.addPictureToList(ref this.MAIN_DAT, fileset_1);
            fileset_1 = this.getFileByName("KSBACK.DAT", false);
            this.bilder.addPictureToList(ref this.MAIN_DAT, fileset_1);
            fileset_1 = this.getFileByName("KSLBACK.DAT", false);
            this.bilder.addPictureToList(ref this.MAIN_DAT, fileset_1);

            fileset_1 = this.getFileByName("BSKILLS.DAT", false);
            this.bilder.addPictureToList(ref this.MAIN_DAT, fileset_1);

            fileset_1 = this.getFileByName("POPUP.DAT", false);
            this.bilder.addPictureToList(ref this.MAIN_DAT, fileset_1);
            //-------------DSA GEN Images---------------
            fileset_1 = this.getFileByName("ATTIC", true);
            this.bilder.addPictureToList(ref this.DSAGEN_DAT, fileset_1);
            fileset_1 = this.getFileByName("DSALOGO.DAT", true);
            this.bilder.addPictureToList(ref this.DSAGEN_DAT, fileset_1);
            fileset_1 = this.getFileByName("GENTIT.DAT", true);
            this.bilder.addPictureToList(ref this.DSAGEN_DAT, fileset_1);
            fileset_1 = this.getFileByName("HEADS.DAT", true);
            this.bilder.addPictureToList(ref this.DSAGEN_DAT, fileset_1); //daten sind amiga komprimiert
            fileset_1 = this.getFileByName("SEX.DAT", true);
            this.bilder.addPictureToList(ref this.DSAGEN_DAT, fileset_1);
            //-------------DSA GEN Power Pack------------
            fileset_1 = this.getFileByName("DZWERG.DAT", true);
            this.bilder.addPictureToList(ref this.DSAGEN_DAT, fileset_1);
            fileset_1 = this.getFileByName("DTHORWAL.DAT", true);
            this.bilder.addPictureToList(ref this.DSAGEN_DAT, fileset_1);
            fileset_1 = this.getFileByName("DSTREUNE.DAT", true);
            this.bilder.addPictureToList(ref this.DSAGEN_DAT, fileset_1);
            fileset_1 = this.getFileByName("DMENGE.DAT", true);
            this.bilder.addPictureToList(ref this.DSAGEN_DAT, fileset_1);
            fileset_1 = this.getFileByName("DMAGIER.DAT", true);
            this.bilder.addPictureToList(ref this.DSAGEN_DAT, fileset_1);
            fileset_1 = this.getFileByName("DKRIEGER.DAT", true);
            this.bilder.addPictureToList(ref this.DSAGEN_DAT, fileset_1);
            fileset_1 = this.getFileByName("DDRUIDE.DAT", true);
            this.bilder.addPictureToList(ref this.DSAGEN_DAT, fileset_1);
            fileset_1 = this.getFileByName("DAELF.DAT", true);
            this.bilder.addPictureToList(ref this.DSAGEN_DAT, fileset_1);
            fileset_1 = this.getFileByName("DFELF.DAT", true);
            this.bilder.addPictureToList(ref this.DSAGEN_DAT, fileset_1);
            fileset_1 = this.getFileByName("DWELF.DAT", true);
            this.bilder.addPictureToList(ref this.DSAGEN_DAT, fileset_1);
            fileset_1 = this.getFileByName("DGAUKLER.DAT", true);
            this.bilder.addPictureToList(ref this.DSAGEN_DAT, fileset_1);
            fileset_1 = this.getFileByName("DHEXE.DAT", true);
            this.bilder.addPictureToList(ref this.DSAGEN_DAT, fileset_1);
            fileset_1 = this.getFileByName("DJAEGER.DAT", true);
            this.bilder.addPictureToList(ref this.DSAGEN_DAT, fileset_1);

            fileset_1 = this.getFileByName("POPUP.DAT", true);
            this.bilder.addPictureToList(ref this.DSAGEN_DAT, fileset_1);
            fileset_1 = this.getFileByName("ROALOGUS.DAT", true);
            this.bilder.addPictureToList(ref this.DSAGEN_DAT, fileset_1);

            //fileset_1 = this.getFileByName("ANIS", false);
            //this.bilder.addPictureToList(ref this.MAIN_DAT, fileset_1);
            
            //---------Bild Archive-----------------------
            fileset_1 = this.getFileByName("MONSTER", false);
            fileset_2 = this.getFileByName("MONSTER.TAB", false);
            this.bilder.addArchivToList(ref this.MAIN_DAT, fileset_1, fileset_2);
            fileset_1 = this.getFileByName("MFIGS", false);
            fileset_2 = this.getFileByName("MFIGS.TAB", false);
            this.bilder.addArchivToList(ref this.MAIN_DAT, fileset_1, fileset_2);
            fileset_1 = this.getFileByName("WFIGS", false);
            fileset_2 = this.getFileByName("WFIGS.TAB", false);
            this.bilder.addArchivToList(ref this.MAIN_DAT, fileset_1, fileset_2);
            
            //Anis fällt irgendwie aus der Reihe, verschoben zu den normalen Bildern
            fileset_1 = this.getFileByName("ANIS", false);
            fileset_2 = this.getFileByName("ANIS.TAB", false);
            this.bilder.addArchivToList(ref this.MAIN_DAT, fileset_1, fileset_2);

            int fileCount;
            int imageCount;
            this.bilder.getImageCount(out fileCount, out imageCount);
            CDebugger.addDebugLine("es wurden " + fileCount.ToString() + " Bilddatein mit insgesammt " + imageCount.ToString() + " Bildern geladen");

            //----------Routen--------------------
            fileset_1 = this.getFileByName("LROUT.DAT", false);
            fileset_2 = this.getFileByName("HSROUT.DAT", false);
            fileset_3 = this.getFileByName("SROUT.DAT", false);
            this.routen.loadRuten(ref this.MAIN_DAT, fileset_1, fileset_2, fileset_3);

            //----------Dialoge--------------------
            filesetList_1 = this.getFilesBySuffix("TLK", false);
            this.dialoge.loadDialoge(ref this.MAIN_DAT, filesetList_1);

            return true;
        }

        public bool unpackAll(string filepath)
        {
            CDebugger.clearDebugText();

            this.itsDSAGENOffsets.Clear();
            this.itsFilenames.Clear();
            this.itsSCHICKOffsets.Clear();
            this.MAIN_DAT = null;
            this.DSAGEN_DAT = null;

            string[] steuerungszeichen = { "\\", "/" }; //Windows, Linux
            bool found = false;

            foreach (string s in steuerungszeichen)
            {
                if (File.Exists(filepath + s + "SCHICKM.EXE"))
                {
                    Properties.Settings.Default.DefaultDSAPath = filepath;
                    Properties.Settings.Default.Save();

                    CDebugger.addDebugLine("SCHICKM.EXE wurde erkannt ");
                    this.loadFilenames(filepath + s +"SCHICKM.EXE");   //  dateinamen sind in der exe verankert
                    this.unpack_SCHICK(filepath + s +"SCHICK.DAT");

                    this.unpack_DSAGEN(filepath + s +"DSAGEN.DAT");
                    found = true;
                    this.itsPathSign = s;
                    break;
                }
                else if (File.Exists(filepath + s + "BLADEM.EXE"))
                {
                    Properties.Settings.Default.DefaultDSAPath = filepath;
                    Properties.Settings.Default.Save();

                    CDebugger.addDebugLine("BLADEM.EXE wurde erkannt ");
                    this.loadFilenames(filepath + s + "BLADEM.EXE");   //  dateinamen sind in der exe verankert
                    this.unpack_SCHICK(filepath + s + "BLADE.DAT");

                    this.unpack_DSAGEN(filepath + s + "DSAGEN.DAT");
                    found = true;
                    this.itsPathSign = s;
                    break;
                }
            }

            if (!found)
            {
                CDebugger.addErrorLine("DSA Version konnte nicht erkannt werden");
                string[] exe_Files = Directory.GetFiles(filepath, "*.exe");
                string[] EXE_Files = Directory.GetFiles(filepath, "*.EXE");
                CDebugger.addErrorLine("es wurden " + (exe_Files.Length + EXE_Files.Length).ToString() + " .exe Dateien gefunden:");
                if (exe_Files.Length > 0)
                {
                    foreach (string s in exe_Files)
                        CDebugger.addErrorLine("  - exe: " + s);
                }
                else
                {
                    foreach (string s in EXE_Files)
                        CDebugger.addErrorLine("  - EXE: " + s);
                }
                return false;
            }

            return true;
        }

        private void loadFilenames(string filename)
        {
            this.itsFilenames.Clear();

            if (!File.Exists(filename))
            {
                CDebugger.addErrorLine("die Datei \"" + filename + "\" konnte nicht geladen werden");
                return;
            }

            Byte[] data = File.ReadAllBytes(filename);

            Int32 offset = this.searchInByteStream(ref data, "TEMP\\%s");  //das Zeichen '\' kommt mehrfach vor wegen escapesequenz
            if (offset == -1)
            {
                CDebugger.addErrorLine("der suchterm wurde in \"" + filename + "\" nicht gefunden");
                CDebugger.addErrorLine("--- bitte lade die Datei \"" + filename + "\" im Forum hoch---");
                return;
            }
            offset += 2;    //hier beginnt der erste nullterminierte String

            //endet mit 0x00 0x2E
            while (data[offset] != 0x00 || data[offset + 1] != 0x2E)
            {
                offset++;
                string name = "";
                while (data[offset] != 0x00)
                {
                    name += (char)data[offset];
                    offset++;
                }
                this.itsFilenames.Add(name);
            }

            CDebugger.addDebugLine(this.itsFilenames.Count.ToString() + " Datei Namen wurden in \"" + filename + "\" gefunden");
        }
        private void unpack_SCHICK(string filename)
        {
            this.itsSCHICKOffsets.Clear();

            if (!File.Exists(filename))
            {
                CDebugger.addErrorLine("die Datei '" + filename + "' konnte nicht geladen werden");
                return;
            }

            this.MAIN_DAT = File.ReadAllBytes(filename);

            Int32 position = 0;
            Int32 value = 0;

            //offsets auslesen
            while (true)
            {
                value = (Int32)this.MAIN_DAT[position + 0] + ((Int32)this.MAIN_DAT[position + 1] << 8) + ((Int32)this.MAIN_DAT[position + 2] << 16) + ((Int32)this.MAIN_DAT[position + 3] << 24);
                if (value == 0)
                    break;
                else
                    this.itsSCHICKOffsets.Add(value);

                position += 4;
            }

            CDebugger.addDebugLine(this.itsSCHICKOffsets.Count.ToString() + " Datei Einträge wurden in \"" + filename + "\" gefunden");

            //Dateien entpacken
            //for (int i = 0; i < (this.itsSCHICKOffsets.Count - 1); i++)
            //{
            //    if (!Directory.Exists((this.path + CConfig.ExportFolder + "\\" + CConfig.ExportSubFolder_Schick)))
            //        Directory.CreateDirectory(this.path + CConfig.ExportFolder + "\\" + CConfig.ExportSubFolder_Schick);

            //    Byte[] temp = new byte[this.itsSCHICKOffsets[i + 1] - this.itsSCHICKOffsets[i]];
            //    if (temp.Length == 0)
            //        continue;

            //    System.Array.Copy(data, this.itsSCHICKOffsets[i], temp, 0, (this.itsSCHICKOffsets[i + 1] - this.itsSCHICKOffsets[i]));


            //    //Dateiname bestimmen
            //    string writeName;
            //    if (this.itsFilenames[i] == "" || this.itsFilenames.Count <= i)
            //        writeName = "unknownFile_" + i.ToString();
            //    else
            //        writeName = this.itsFilenames[i];

            //    //Unter Ordner bestimmen
            //    string SubDirectory = "unbekannt\\";
            //    if (writeName.Length > 4 && writeName.Contains("."))   //besitzt die datei eine Dateiendung?
            //    {
            //        int help = writeName.LastIndexOf('.');
            //        SubDirectory = writeName.Substring(help + 1, writeName.Length - help - 1) + "\\";
            //    }

            //    if (!Directory.Exists(this.path + CConfig.ExportFolder + "\\" + CConfig.ExportSubFolder_Schick + "\\" + SubDirectory))
            //        Directory.CreateDirectory(this.path + CConfig.ExportFolder + "\\" + CConfig.ExportSubFolder_Schick + "\\" + SubDirectory);

            //    //Datei schreiben
            //    File.WriteAllBytes(this.path + CConfig.ExportFolder + "\\" + CConfig.ExportSubFolder_Schick + "\\" + SubDirectory + writeName, temp);
            //}
        }
        
        private void unpack_DSAGEN(string filename)
        {
            this.itsDSAGENOffsets.Clear();

            if (!File.Exists(filename))
            {
                CDebugger.addErrorLine("die Datei '" + filename + "' konnte nicht geladen werden");
                return;
            }

            this.DSAGEN_DAT = File.ReadAllBytes(filename);

            UInt32 nextPosition = 0;
            while (this.DSAGEN_DAT[nextPosition] != 0)
            {
                UInt32 currentPos = nextPosition;

                string name = "";
                while ((this.DSAGEN_DAT[currentPos] != 0) && ((currentPos - nextPosition) < 0x0C))
                {
                    name += (char)this.DSAGEN_DAT[currentPos];
                    currentPos++;
                }

                Int32 value = (Int32)this.DSAGEN_DAT[nextPosition + 0x0C] + ((Int32)this.DSAGEN_DAT[nextPosition + 0x0D] << 8) + ((Int32)this.DSAGEN_DAT[nextPosition + 0x0E] << 16) + ((Int32)this.DSAGEN_DAT[nextPosition + 0x0F] << 24);

                itsDSAGENOffsets.Add(new KeyValuePair<string, Int32>(name, value));

                nextPosition += 16;
            }

            CDebugger.addDebugLine(this.itsDSAGENOffsets.Count.ToString() + " Dateien wurden in \"" + filename + "\" gefunden");

            //Dateien entpacken
            //for (int i = 0; i < (this.itsDSAGENOffsets.Count - 1); i++)
            //{
            //    if (!Directory.Exists((this.path + CConfig.ExportFolder + "\\" + CConfig.ExportSubFolder_DSAGEN)))
            //        Directory.CreateDirectory(this.path + CConfig.ExportFolder + "\\" + CConfig.ExportSubFolder_DSAGEN);

            //    Byte[] temp = new byte[this.itsDSAGENOffsets[i + 1].Value - this.itsDSAGENOffsets[i].Value];
            //    if (temp.Length == 0)
            //        continue;

            //    System.Array.Copy(data, this.itsDSAGENOffsets[i].Value, temp, 0, (this.itsDSAGENOffsets[i + 1].Value - this.itsDSAGENOffsets[i].Value));


            //    //Dateiname bestimmen
            //    string writeName = this.itsDSAGENOffsets[i].Key;

            //    //Unter Ordner bestimmen
            //    string SubDirectory = "unbekannt\\";
            //    if (writeName.Length > 4 && writeName.Contains("."))   //besitzt die datei eine Dateiendung?
            //    {
            //        int help = writeName.LastIndexOf('.');
            //        SubDirectory = writeName.Substring(help + 1, writeName.Length - help - 1) + "\\";
            //    }

            //    if (!Directory.Exists(this.path + CConfig.ExportFolder + "\\" + CConfig.ExportSubFolder_DSAGEN + "\\" + SubDirectory))
            //        Directory.CreateDirectory(this.path + CConfig.ExportFolder + "\\" + CConfig.ExportSubFolder_DSAGEN + "\\" + SubDirectory);

            //    //Datei schreiben
            //    File.WriteAllBytes(this.path + CConfig.ExportFolder + "\\" + CConfig.ExportSubFolder_DSAGEN + "\\" + SubDirectory + writeName, temp);
            //}
        }

        private CFileSet getFileByName(string filename, bool useDSAGenDat)
        {
            if (!useDSAGenDat)
            {
                if (this.MAIN_DAT != null)
                {
                    for (int i = 0; i < this.itsFilenames.Count; i++)
                    {
                        if (this.itsFilenames[i] == filename)
                        {
                            //Datei gefunden

                            if (i < (this.itsFilenames.Count - 1))
                            {
                                if (i < this.itsSCHICKOffsets.Count)
                                {
                                    return new CFileSet(filename, this.itsSCHICKOffsets[i], this.itsSCHICKOffsets[i + 1]);
                                }
                                else
                                    return null;   //zu dem namen existieren keine bytes
                            }
                            else
                            {
                                if (i < this.itsSCHICKOffsets.Count)
                                {
                                    return new CFileSet(filename, this.itsSCHICKOffsets[i], this.MAIN_DAT.Length); //datei geht bis zum ende des bytestreams
                                }
                                else
                                    return null;   //zu dem namen existieren keine bytes
                            }
                        }
                    }
                }
            }
            else
            {
                if (this.DSAGEN_DAT != null)
                {
                    for (int i = 0; i < this.itsDSAGENOffsets.Count; i++)
                    {
                        if (this.itsDSAGENOffsets[i].Key == filename)
                        {
                            if (i < (this.itsDSAGENOffsets.Count - 1))
                                return new CFileSet(this.itsDSAGENOffsets[i].Key, this.itsDSAGENOffsets[i].Value, this.itsDSAGENOffsets[i + 1].Value);
                            else
                                return new CFileSet(this.itsDSAGENOffsets[i].Key, this.itsDSAGENOffsets[i].Value, this.DSAGEN_DAT.Length);
                        }
                    }
                }
            }

            return null;
        }
        private List<CFileSet> getFilesBySuffix(string suffix, bool useDSAGenDat)
        {
            List<CFileSet> fileSet = new List<CFileSet>();

            if (!useDSAGenDat)
            {
                if (this.MAIN_DAT != null)
                {
                    for (int i = 0; i < this.itsFilenames.Count; i++)
                    {
                        if (this.itsFilenames[i].Contains(suffix))
                        {
                            if (i < (this.itsFilenames.Count - 1))
                            {
                                if (i < this.itsSCHICKOffsets.Count)
                                {
                                    fileSet.Add(new CFileSet(this.itsFilenames[i], this.itsSCHICKOffsets[i], this.itsSCHICKOffsets[i + 1]));
                                }
                            }
                            else
                            {
                                if (i < this.itsSCHICKOffsets.Count)
                                {
                                    fileSet.Add(new CFileSet(this.itsFilenames[i], this.itsSCHICKOffsets[i], this.MAIN_DAT.Length)); //datei geht bis zum ende des bytestreams
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                if (this.DSAGEN_DAT != null)
                {
                    for (int i = 0; i < this.itsDSAGENOffsets.Count; i++)
                    {
                        if (this.itsDSAGENOffsets[i].Key.Contains(suffix))
                        {
                            if (i < (this.itsDSAGENOffsets.Count - 1))
                                fileSet.Add(new CFileSet(this.itsDSAGENOffsets[i].Key, this.itsDSAGENOffsets[i].Value, this.itsDSAGENOffsets[i + 1].Value));
                            else
                                fileSet.Add(new CFileSet(this.itsDSAGENOffsets[i].Key, this.itsDSAGENOffsets[i].Value, this.DSAGEN_DAT.Length));
                        }
                    }
                }
            }

            return fileSet;
        }
        private List<CFileSet> getTownFiles()
        {
            string suffix = ".DAT";
            string[] citys = { "THORWAL.DAT", "SERSKE.DAT", "BREIDA.DAT", "PEILINEN.DAT", "ROVAMUND.DAT", "NORDVEST.DAT",
                             "KRAVIK.DAT", "SKELELLE.DAT", "MERSKE.DAT", "EFFERDUN.DAT", "TJOILA.DAT", "RUKIAN.DAT",
                             "ANGBODIRTAL.DAT", "AUPLOG.DAT", "VILNHEIM.DAT", "BODON.DAT", "OBERORKEN.DAT", "PHEXCAER.DAT",
                             "GROENVEL.DAT", "FELSTEYN.DAT", "EINSIEDL.DAT", "ORKANGER.DAT", "CLANEGH.DAT", "LISKOR.DAT",
                             "THOSS.DAT", "TJANSET.DAT", "ALA.DAT", "ORVIL.DAT", "OVERTHORN.DAT", "ROVIK.DAT", "HJALSING.DAT",
                             "GUDDASUN.DAT", "KORD.DAT", "TREBAN.DAT", "ARYN.DAT", "RUNINSHA.DAT", "OTTARJE.DAT", "SKJAL.DAT",
                             "PREM.DAT", "DASPOTA.DAT", "RYBON.DAT", "LJASDAHL.DAT", "VARNHEIM.DAT", "VAERMHAG.DAT", "TYLDON.DAT",
                             "VIDSAND.DAT", "BRENDHIL.DAT", "MANRIN.DAT", "FTJOILA.DAT", "FANGBODI.DAT", "HJALLAND.DAT", "RUNIN.DAT"};

            List<CFileSet> fileSet = new List<CFileSet>();

            if (this.MAIN_DAT != null)
            {
                for (int i = 0; i < this.itsFilenames.Count; i++)
                {
                    if (this.itsFilenames[i].Contains(suffix))
                    {
                        bool cityFound = false;
                        foreach (string s in citys)
                        {
                            if (s == this.itsFilenames[i])
                            {
                                cityFound = true;
                                break;
                            }
                        }

                        if (!cityFound)
                            continue;

                        if (i < (this.itsFilenames.Count - 1))
                        {
                            if (i < this.itsSCHICKOffsets.Count)
                            {
                                fileSet.Add(new CFileSet(this.itsFilenames[i], this.itsSCHICKOffsets[i], this.itsSCHICKOffsets[i + 1]));
                            }
                        }
                        else
                        {
                            if (i < this.itsSCHICKOffsets.Count)
                            {
                                fileSet.Add(new CFileSet(this.itsFilenames[i], this.itsSCHICKOffsets[i], this.MAIN_DAT.Length)); //datei geht bis zum ende des bytestreams
                            }
                        }
                    }
                }
            }

            
            return fileSet;
        }

        private Int32 searchInByteStream(ref byte[] data, string searchTerm)
        {
            int position = 0;
            for (Int32 i = 0; i < data.Length; i++)
            {
                if (data[i] == searchTerm[position])
                {
                    position++;
                    if (position >= searchTerm.Length)
                        return i;
                }
                else
                    position = 0;
            }
            return -1;  //suchtext wurde nicht gefunden
        }

        public void exportFiles(string filepath)
        {
            if (this.itsPathSign == "")
                return;

            if (!Directory.Exists(filepath + this.itsPathSign + "SCHICK"))
                Directory.CreateDirectory(filepath + this.itsPathSign + "SCHICK");

            for (int i = 0; i < this.itsSCHICKOffsets.Count; i++)
            {
                string typ;
                if (i < this.itsFilenames.Count)
                    typ = getFileTyp(this.itsFilenames[i]);
                else
                    typ = "unbekannt";

                string name;
                if (i < this.itsFilenames.Count && this.itsFilenames[i] != "")
                    name = this.itsFilenames[i];
                else
                    name = i.ToString();

                if (!Directory.Exists(filepath + this.itsPathSign + "SCHICK" + this.itsPathSign + typ))
                    Directory.CreateDirectory(filepath + this.itsPathSign + "SCHICK" + this.itsPathSign + typ);

                int end;
                if (i >= (this.itsSCHICKOffsets.Count - 1))
                    end = this.MAIN_DAT.Length;
                else
                    end = this.itsSCHICKOffsets[i + 1];

                byte[] data = new byte[end - this.itsSCHICKOffsets[i]];
                Array.Copy(this.MAIN_DAT, this.itsSCHICKOffsets[i], data, 0, data.Length);

                if (data.Length > 0)
                    File.WriteAllBytes(filepath + this.itsPathSign + "SCHICK" + this.itsPathSign + typ + this.itsPathSign + name, data);
            }

            //----------------------------------------------------

            if (!Directory.Exists(filepath + this.itsPathSign + "DSAGEN"))
                Directory.CreateDirectory(filepath + this.itsPathSign + "DSAGEN");

            for (int i = 0; i < this.itsDSAGENOffsets.Count; i++)
            {
                string typ = getFileTyp(this.itsDSAGENOffsets[i].Key);

                if (!Directory.Exists(filepath + this.itsPathSign + "DSAGEN" + this.itsPathSign + typ))
                    Directory.CreateDirectory(filepath + this.itsPathSign + "DSAGEN" + this.itsPathSign + typ);

                int end;
                if (i >= (this.itsDSAGENOffsets.Count - 1))
                    end = this.DSAGEN_DAT.Length;
                else
                    end = this.itsDSAGENOffsets[i+1].Value;

                string name;
                if (i < this.itsDSAGENOffsets.Count && this.itsDSAGENOffsets[i].Key != "")
                    name = this.itsDSAGENOffsets[i].Key;
                else
                    name = i.ToString();

                byte[] data = new byte[end - this.itsDSAGENOffsets[i].Value];
                Array.Copy(this.DSAGEN_DAT, this.itsDSAGENOffsets[i].Value, data, 0, data.Length);

                if (data.Length > 0)
                    File.WriteAllBytes(filepath + this.itsPathSign + "DSAGEN" + this.itsPathSign + typ + this.itsPathSign + name, data);
            }

            CDebugger.addDebugLine("entpacken erfolgreich beendet");
        }
        private string getFileTyp(string filename)
        {
            if (filename.Contains("."))
            {
                int i = filename.LastIndexOf('.');
                return filename.Substring(i + 1);
            }

            return "unbekannt";
        }

        public void exportPictures(string filepath)
        {
            if (this.itsPathSign == "")
                return;

            CDebugger.addDebugLine("Bilder werden exportiert...");
            foreach (KeyValuePair<string, List<Image>> pair in this.bilder.itsImages)
            {
                string name = getFileFront(pair.Key);
                string path = filepath + this.itsPathSign + "Bilder" + this.itsPathSign + name;

                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                for (int i = 0; i < pair.Value.Count; i++)
                    pair.Value[i].Save(path + this.itsPathSign + i.ToString() + ".png");
            }
            foreach (KeyValuePair<string, List<List<Image>>> pair_name in this.bilder.itsAnimations)
            {
                string name = getFileFront(pair_name.Key);
                int counter = 0;

                foreach (List<Image> Images in pair_name.Value)
                {
                    string path = filepath + this.itsPathSign + "Animationen" + this.itsPathSign + name + this.itsPathSign + counter;

                    if (!Directory.Exists(path))
                        Directory.CreateDirectory(path);

                    for (int i = 0; i < Images.Count; i++)
                        Images[i].Save(path + this.itsPathSign + i.ToString() + ".png");

                    counter++;
                }
            }
            CDebugger.addDebugLine("Bilder wurden erfolgreich exportiert");
        }
        private string getFileFront(string filename)
        {
            if (filename.Contains("."))
            {
                int i = filename.IndexOf('.');
                return filename.Substring(0, i);
            }

            return filename;
        }
    }
}

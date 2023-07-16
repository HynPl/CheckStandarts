using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.UI;
using System;
using System.IO;

namespace CheckStandarts {
    internal static class Setting {

        // Class with lang strings
        public static LangEnglish Lang;
        public static LangEnglish LangMessages;
        
        // Different laws by geo
        public static BuildingLocation BuildingLocation;

        // Settings
        public static AvaibleLang LangCode=AvaibleLang.ByRevit;
        public static AvaibleLang LangCodeMessages=AvaibleLang.Czech;

      //  public static AvaibleLang LangCodeExport=AvaibleLang.Czech;
        public static TypeBuilding DefBuildingType=TypeBuilding.NotSpecified;

        // Saving of global settings (lang, def buildingType)
        const string folderName="CheckApiRevit";
        const string settingFileName="Settings.ini";

        // Version of program
        public const string Version ="0.1";

        // Supporting langs
        public enum AvaibleLang { 
            ByRevit, // Default
            Czech,
            English,
            Slovak, // Not supported by revit
            Hanacke, // centrální haná
            Valasky, // kolem Rožnova
            Slovacky // moc neumím
                // možná později lašsky?
        }

        // Get lang
        public static void SolveLang(UIControlledApplication application) { 
            // Default language
            switch (LangCode) { 
                case AvaibleLang.Czech: 
                    Lang = new LangCzech();
                    break;

                // slovak not supported in Revit
                case AvaibleLang.Slovak: 
                    Lang = new LangSlovak();
                    break;

                case AvaibleLang.English: 
                    Lang = new LangEnglish();
                    break;

                case AvaibleLang.Hanacke: 
                    Lang = new LangHanacke();
                    break;

                case AvaibleLang.Valasky: 
                    Lang = new LangValašsky();
                    break;

                case AvaibleLang.Slovacky: 
                    Lang = new LangSlovácky();
                    break;

                // By revit
                default:
                    switch (application.ControlledApplication.Language) { 
                        case LanguageType.Czech: 
                            Lang = new LangCzech();
                            break;

                        // Revit not support slovak

                        default: 
                            Lang = new LangEnglish();
                            break;
                    }
                    break;
            }
                       

            // Message lang
            switch (LangCodeMessages) { 
                case AvaibleLang.Czech: 
                    LangMessages = new LangCzech();
                    break;

                // slovak not supported in Revit
                case AvaibleLang.Slovak: 
                    LangMessages = new LangSlovak();
                    break;

                case AvaibleLang.English: 
                    LangMessages = new LangEnglish();
                    break;
                                        
                case AvaibleLang.Hanacke: 
                    LangMessages = new LangHanacke();
                    break;

                case AvaibleLang.Valasky: 
                    LangMessages = new LangValašsky();
                    break;

                case AvaibleLang.Slovacky: 
                    LangMessages = new LangSlovácky();
                    break;

                // By default language
                default:
                    switch (LangCode) { 
                        case AvaibleLang.Czech: 
                            LangMessages = new LangCzech();
                            break;

                        // slovak not supported in Revit
                        case AvaibleLang.Slovak: 
                            LangMessages = new LangSlovak();
                            break;

                        case AvaibleLang.English: 
                            LangMessages = new LangEnglish();
                            break;
                                                        
                        case AvaibleLang.Hanacke: 
                            LangMessages = new LangHanacke();
                            break;

                        case AvaibleLang.Valasky: 
                            LangMessages = new LangValašsky();
                            break;

                        case AvaibleLang.Slovacky: 
                            LangMessages = new LangSlovácky();
                            break;

                        // By revit
                        default:
                            switch (application.ControlledApplication.Language) { 
                                case LanguageType.Czech: 
                                    LangMessages = new LangCzech();
                                    break;

                                // Revit not support slovak

                                default: 
                                    LangMessages = new LangEnglish();
                                    break;
                            }
                            break;
                    }
                    break;
            }
        }

        // Save settings
        public static void Save(){ 
            string pathDirParent=Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string folderFullPath=pathDirParent+"\\"+folderName;

            // Create folder for setting
            if (!Directory.Exists(folderFullPath)) { 
                Directory.CreateDirectory(folderFullPath);
            }

            if (Directory.Exists(folderFullPath)) { 
                File.WriteAllText(folderFullPath+"\\"+settingFileName,
                    "[CheckApiRevit]"+Environment.NewLine+
                    "Lang="+(int)LangCode+Environment.NewLine+
                  //  "LangExport="+(int)LangExportCode+Environment.NewLine+
                    "LangMessages="+(int)LangCodeMessages+Environment.NewLine+
                    "Location="+(int)BuildingLocation+Environment.NewLine+
                    "DefBuildingType="+(int)DefBuildingType);
            }
        }
        
        // Load settings
        public static void Load() { 
            string pathDirParent=Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            if (Directory.Exists(pathDirParent+"\\"+folderName)) { 
                
                string fullFilePath=pathDirParent+"\\"+folderName+"\\"+settingFileName;
                if (File.Exists(fullFilePath)) { 

                    // Read settings file
                    string[]lines = File.ReadAllLines(fullFilePath);
                    foreach (string line in lines) { 

                        // if is setting
                        if (line.Contains("=")) { 
                            string[] parts=line.Split('=');
                            switch (parts[0]) { 
                                case "Lang": {
                                        if (int.TryParse(parts[1], out int number)) { 
                                            LangCode=(AvaibleLang)number;
                                        } 
                                    }
                                    break;

                                //case "LangExport": {
                                //        if (int.TryParse(parts[1], out int number)) { 
                                //            LangExportCode=(AvaibleLang)number;
                                //        }
                                //    }
                                //    break;

                                case "LangMessages": {
                                        if (int.TryParse(parts[1], out int number)) { 
                                            LangCodeMessages=(AvaibleLang)number;
                                        }
                                    }
                                    break;

                                case "Location": {
                                        if (int.TryParse(parts[1], out int number)) { 
                                            BuildingLocation=(BuildingLocation)number;
                                        }
                                    }
                                    break;

                                case "DefBuildingType": {
                                        if (int.TryParse(parts[1], out int number)) { 
                                            DefBuildingType=(TypeBuilding)number;
                                        }
                                    }
                                    break;
                            }
                        }   
                    }
                }
                //File.WriteAllText(pathDirParent+"\\"+folderName+"\\"+settingFileName,
                //    "[CheckApiRevit]"+Environment.NewLine+
                //    "Lang="+(int)LangCode+Environment.NewLine+
                //    "LangMessages="+(int)LangCodeMessages+Environment.NewLine+
                //    "DefBuildingType="+(int)DefBuildingType);
            }
        }
    }
}
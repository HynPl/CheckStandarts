using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.UI;
using System;
using System.IO;

namespace CheckStandarts {
    internal static class Setting {

        // Class with lang strings
        public static Lang Lang;

        // Settings
        public static AvaibleLang LangCode=AvaibleLang.ByRevit;
        public static AvaibleLang LangExportCode=AvaibleLang.ByRevit;
        public static TypeBuilding DefBuildingType=TypeBuilding.NotSpecified;

        // Saving of global settings (lang, def buildingType)
        const string folderName="CheckApiRevit";
        const string settingFileName="Settings.ini";

        // Version of program
        public const string Version ="0.1";

        // Supporting langs
        public enum AvaibleLang { 
            ByRevit,
            Czech,
            Slovak,
            English
        }

        // Get lang
        public static void SolveLang(UIControlledApplication application) { 
            switch (LangCode) { 
                case AvaibleLang.Czech: 
                    Lang = new LangCzech();
                    break;

                // slovak not supported in Revit
                case AvaibleLang.Slovak: 
                    Lang = new LangCzech();
                    break;

                case AvaibleLang.English: 
                    Lang = new LangEnglish();
                    break;

                // By revit
                default:
                    switch (application.ControlledApplication.Language) { 
                        case LanguageType.Czech: 
                            Lang = new LangCzech();
                            break;

                        default: 
                            Lang = new LangEnglish();
                            break;
                    }
                    break;
            }
        }

        // Save settings
        public static void Save(){ 
            string pathDirParent=Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string folderFullPath=pathDirParent+"\\"+folderName;

            if (!Directory.Exists(folderFullPath)) { 
                Directory.CreateDirectory(folderFullPath);
            }

            if (Directory.Exists(folderFullPath)) { 
                File.WriteAllText(folderFullPath+"\\"+settingFileName,
                    "[CheckApiRevit]"+Environment.NewLine+
                    "Lang="+(int)LangCode+Environment.NewLine+
                    "LangExport="+(int)LangCode+Environment.NewLine+
                    "DefBuildingType="+(int)DefBuildingType);
            }
        }
        
        // Load settings
        public static void Load(){ 
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

                                case "LangExport": {
                                        if (int.TryParse(parts[1], out int number)) { 
                                            LangExportCode=(AvaibleLang)number;
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
                File.WriteAllText(pathDirParent+"\\"+folderName+"\\"+settingFileName,
                    "[CheckApiRevit]"+Environment.NewLine+
                    "Lang="+(int)LangCode+Environment.NewLine+
                    "LangExport="+(int)LangCode+Environment.NewLine+
                    "DefBuildingType="+(int)DefBuildingType);
            }
        }
    }
}
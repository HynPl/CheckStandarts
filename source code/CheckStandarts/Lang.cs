namespace CheckStandarts {
    abstract class Lang {
        public string 
            AppName,
            Version,
            Author,

            TabName,
            PanelName,
            OpenApp,

            StairLehman,
            StairHeight,
            StairDepth,
            StairAngle,

            Recheck,
            Export,
            Settings,
            HelpIcon,

            Show,

            RunWidthRD,
            StairsNumbersRD,
            RunWidthBD,
            
            StairsAngle,
            StairsWidth,
            StairsHeight,

            Done,
            Checking,
            NotFound,
            FoundOne,
            FoundTwo,
            FoundThree,
            FoundFour,
            FoundX,
            LangByRevit,
            LangCzech,
            LangEnglishGB,
            LangSlovak,
            Apartement,
            Administrative,
            InsideApartement,
            Technic,
            Exterier,
            UnknownBuilding,
            FamilyHouse,
            Stairs,       
            WidthOfRun,
            NumberOfStairs,
            DefaultBuilding,
            Run,
            TypeMark,
            Level,
            Using,
            Elevation,
            Type;

        public string ExportHeader => AppName + " - Export";
        public string Help { get; }
    }

    class LangEnglish :Lang{
        

        public LangEnglish() {
            AppName="Check Standarts";
            Version="v0.1";
            Author="HynPl";

            TabName="Check";
            PanelName="Checking";
            OpenApp="Open app for checking - standards; laws; regulations in Czech Republic";

            StairLehman="The Lehman formula";
            StairHeight ="Height of the step";
            StairDepth="Depth of the step";
            StairAngle="The slope of the stairs";

            Recheck="Recheck";
            Export="Export";
            Settings="Settings";
            HelpIcon="Help";
            Show="Show";
            Run="Run";

           

              RunWidthRD="ČSN 73 4130; The minimum clear width of the main staircase arms is 900 mm for RD. It is advisable to choose at least 1000mm. Other than that; must comply with fire escape requirements of CSN 73 0802 (fire is not considered in this programme).";
            StairsNumbersRD="Decree No.137/1998 Coll. on general technical requirements for construction; § 34 point 6: The number of stair treads in one stair arm of the main staircase may not exceed 16; for auxiliary staircases and staircases inside flats, not more than 18; the stair tread scale must be horizontal; without inclination in the transverse and longitudinal direction.";
            RunWidthBD="ČSN 73 4130; The minimum clear width of the main staircase arms is 1100mm for BD. It is advisable to choose at least 1200mm. Handrails need to be considered. Other than that; must comply with fire escape requirements of CSN 73 0802 (fire is not considered in this programme).";
            
            StairsAngle="Decree No.398/2009 Coll. 2.1.1.: The slope of the stair arm must not be greater than 28° and the height of the stair or balancing step must not be greater than 160 mm; this does not apply to apartment buildings with a lift.\r\n"+
                "ČSN 73 4130 Staircases and inclined ramps - Basic requirements: '6.1.1 The inclination of stair arms in apartment buildings; inside assembly areas and escape staircases should be within 25°< α ≤ 35°.\r\n"+
                "Staircases inside flats with a construction height of less than 3000mm and staircases to cellars and attics can be inclined up to 41°.";

            StairsWidth="The minimum permissible width of the stair tread of ladder staircases is 150 mm;\r\n"+
                "The minimum permissible width of the step is 210 mm; however, the platform must be at least 250 mm wide.\r\n"+
                "For barrier-free buildings, the width of the step must be at least 310 mm; the height must not exceed 160 mm. ";

            StairsHeight="A step height of more than 190 mm is not recommended for single-family homes; up to 180 mm is comfortable. The optimum step height is 150 to 180mm.";

            TypeMark="type mark";
            Done ="Done";
            Checking ="Checking...";
            NotFound="No object found";
            FoundOne="One object found";
            FoundTwo="Two objects found";
            FoundThree="Three objects found";
            FoundFour="Four objects found";
            FoundX="? objects found";
            LangByRevit="By revit";
            LangCzech="Czech";
            LangEnglishGB ="English";
            LangSlovak="Slovak";
            Apartement="Apartement";
            Administrative="Administrative";
            InsideApartement="Inside apartement";
            Technic="Technic rooms";
            Exterier="Exterior";
            UnknownBuilding="Unknown";
            FamilyHouse="Family House";
            Stairs="Stairs";        
            WidthOfRun ="Width of run";
            NumberOfStairs ="Number of stairs";
            DefaultBuilding ="By default";
            Type="Type";
            Level="level";
            Elevation="elevation";
            Using="Using"; 
            
           

        }

        public new string Help => AppName+"  "+Version+"\r\n"+
            "Author: "+Author+"\r\n"+
            "\r\n"+
            "What is checked?\r\n"+
            "The geometry of objects is checked - the height of the stairs, the depth of the step, whether it corresponds to the length of the step, the angle of the staircase, the width of the leg, the number of steps in the leg. Whether the geometry corresponds to laws, decrees, norms, standards.\r\n "+
            "\r\n"+
            "Where are global settings stored?\r\n"+
            "%appdata%\\CheckApiRevit\\Settings.ini.\r\n"+
            "\r\n"+
            "How can I display more information in the detections panel?\r\n"+
            "Set the type mark at the staircase family.\r\n";  

        public new string ExportHeader => AppName + " - Export";
    }

    class LangCzech : Lang {
         public LangCzech() {
            AppName="KOntrola standardů";
            Version="v0.1";
            Author="HynPl";
            Elevation="v rel. výšce";
            TabName="Kontrola";
            PanelName="Zkontrolovat";
            OpenApp="Otevřít aplikaci ke kontrole - zákonů, předpisů, vyhlášek, norem, standardů v České Republice";
            TypeMark="typ rodiny";
            StairLehman="Lehmanův vzorec";
            StairHeight ="Výška stupně";
            StairDepth="Šířka stupně";
            StairAngle="Sklon schodiště";
                Using="Pro";
            HelpIcon="Nápověda";
            Recheck="Nová kontrola";
            Export="Exportovat";
            Settings="Nastavení";
            NotFound="Nenalezen žádný objekt ke kontrole";
            FoundOne="Nalezen jeden objekt";
            FoundTwo="Nalezeny dva objekty";
            FoundThree="Nalezeny tři objekty";
            FoundFour="Nalezeny čtyři objekty";
            FoundX=" Nalezeno ? objektů";  
            Level="úroveň";              
            Show="Ukázat"; 
            Run="Rameno";
            Done ="Done";
            Checking ="Kontrola...";
            NotFound="Nebylo nic nalezeno";
          
            LangByRevit="Podle revitu";
            LangCzech="Čeština";
            LangEnglishGB ="Angličtina";
            LangSlovak="Slovenšina";

            Apartement="Bytový dům";
            Administrative="Administrativa";
            InsideApartement="Vnitřek bytu";
            Technic="Technické";
            Exterier="Exteriér";
            UnknownBuilding="Unknown";
            FamilyHouse="Rodinný dům";
            Stairs="Schody";        
            WidthOfRun ="Šířka ramena";
            NumberOfStairs ="Počet schodů v rameni";
            DefaultBuilding ="Výchozí";
            Type="Typ"; 
            
            RunWidthRD="ČSN 73 4130; Minimální průchodná šířka ramen hlavních schodišť je u RD 900mm. Vhodné zvolit aspoň 1000mm. Mimo to; musí vyhovovat požárnímu úniku ČSN 73 0802 (požár tento program nepočítá).";
            StairsNumbersRD="Vyhláška č. 137/1998 Sb. o obecných technických požadavcích na výstavbu; § 34 bod 6: Počet  výšek  schodišťových  stupňů  v  jednom schodišťovém rameni hlavního  schodiště  smí  být  nejvýše  16;  u  pomocných  schodišť a u schodišť uvnitř bytů nejvýše 18; stupnice schodišťového stupně musí být vodorovná; bez sklonu v příčném i podélném směru.";
            RunWidthBD="ČSN 73 4130; Minimální průchodná šířka ramen hlavních schodišť je u BD 1100mm. Vhodné zvolit aspoň 1200mm. Potřeba uvažovat se zábradlím. Mimo to; musí vyhovovat požárnímu úniku ČSN 73 0802 (požár tento program nepočítá).";
            
            StairsAngle="Vyhláška č. 398/2009 Sb. 2.1.1.: Sklon schodišťového ramene nesmí být větší než 28° a výška schodišťového nebo vyrovnávacího stupně větší než 160 mm; to neplatí pro stavby bytových domů s výtahem.\r\n"+
                "ČSN 73 4130 Schodiště a šikmé rampy – Základní požadavky: „6.1.1 Sklon schodišťových ramen v bytových domech; uvnitř prostorů určených ke shromažďování osob a únikových schodišť by měl být v rozmezí 25°< α ≤ 35°.\r\n"+
                "Schodište uvnitř bytů s konstrukční výškou menší než 3000mm a u schodišť do sklepů a na půdu je možno sklon zvýšit až na 41°.";

            StairsWidth="Nejmenší dovolená šířka schodišťového stupně žebříkových schodišť je 150 mm;\r\n"+
                "Minimální povolená šířka stupně je 210 mm; nástupnice však musí dosahovat alespoň šířky 250 mm.\r\n"+
                "U bezbariérových staveb musí šířka stupně dosahovat alespoň hodnoty 310 mm; výška nesmí překročit 160 mm. ";

            StairsHeight="Pro rodinné domy se nedoporučuje výška stupně vyšší jak 190 mm; pohodlné se dá uvažovat do 180 mm. Optimální výška stupně je 150 až 180mm.";
        }

        public new string Help => AppName+"  "+Version+"\r\n"+
            "Autor: "+Author+"\r\n"+
            "\r\n"+
            "Co se vše kontroluje?\r\n"+
            "Kontroluje se rozměry - schodišť výška stupně, hlouba schodu, zda odpovídá délce kroku, úhel schodiště, šířka ramene, počet stupňů v rameni. Zda geometrie odpovídá zákonům, vyhláškám, normám, standardům.\r\n "+
            "\r\n"+
            "Kam se ukládá globální nastavení?\r\n"+
            "%appdata%\\CheckApiRevit\\Settings.ini.\r\n"+
            "\r\n"+
            "Jak můžu zobrazit více informací v panelu detekcí?\r\n"+
            "Nastavit typ rodiny u schodiště (Type mark).\r\n";  
    }
    
    class LangSlovak : Lang {
        public LangSlovak() { 
            OpenApp="Otvoriť aplikáciu";
            TabName="Kontrola";
            PanelName="Kontrola";
            StairLehman="Lehmanov vzorec";
            StairHeight ="Výška stupňa";
            StairDepth="Šírka stupňa";
            StairAngle="Sklon schodiska";
            Show="Ukázať";
            Recheck="Nová kontrola";
            Export="Exportovať";
            Settings="Nastavenie";

            Done ="Hotovo";
            Checking ="Kontrola...";
            NotFound="Nebolo nič nájdené";
          
            LangByRevit="Podľa revitu";
            LangCzech="Čeština";
            LangEnglishGB ="Angličtina";
            LangSlovak="Slovenčina";

            Apartement="Bytový dom";
            Administrative="Administratíva";
            InsideApartement="Vnútro bytu";
            Technic="Technické";
            Exterier="Exteriér";
            UnknownBuilding="Neznámy";
            FamilyHouse="Rozinný dom";
            Stairs="Schody";        
            WidthOfRun ="Šírka ramena";
            NumberOfStairs ="Počet schodov v ramene";
            DefaultBuilding ="Predvolené";
            Type="Typ";
                        
            HelpIcon="Pomocník";
            Recheck="Nová kontrola";
            Export="Exportovať";
            Settings="Nastavenie";
            NotFound="Nenájdený žiadny objekt na kontrolu";
            FoundOne="Nájdený jeden objekt";
            FoundTwo="Nájdené dva objekty";
            FoundThree="Nájdené tri objekty";
            FoundFour="Nájdené štyri objekty";
            FoundX=" Nájdené ? objekty";  
                             
            RunWidthRD="ČSN 73 4130; minimálna svetlá šírka hlavných schodiskových ramien je 900 mm pre RD. Odporúča sa zvoliť aspoň 1000 mm. Ostatné; musí vyhovovať požiarnej tesnosti ČSN 73 0802 (v tomto programe sa neuvažuje s požiarom).";
            StairsNumbersRD="Vyhláška č. 137/1998 Z. z. o všeobecných technických požiadavkách na výstavbu; § 34 bod 6: Počet výšok schodiskových stupňov v jednom schodiskovom ramene hlavného schodiska nesmie byť väčší ako 16; pri pomocných schodiskách a schodiskách vo vnútri bytov najviac 18; stupnica schodiskových stupňov musí byť vodorovná; bez sklonu v priečnom a pozdĺžnom smere.";
            RunWidthBD="ČSN 73 4130; Minimálna svetlá šírka ramien hlavných schodísk v BD je 1100 mm. Odporúča sa zvoliť aspoň 1200mm. Je potrebné zvážiť zábradlia. Ostatné; musí vyhovovať požiarnej tesnosti ČSN 73 0802 (v tomto programe sa neuvažuje s požiarom).";
            
            StairsAngle="Vyhláška č. 398/2009 Z. z. 2.1.1: Sklon schodiskového ramena nesmie byť väčší ako 28° a výška schodiska alebo vyrovnávacieho stupňa väčšia ako 160 mm; neplatí pre bytové domy s výťahom.\r\n"+
                "ČSN 73 4130 Schodiská a šikmé rampy - Základné požiadavky: \"6.1.1 Sklon schodiskových ramien v bytových domoch; vo vnútorných zhromažďovacích priestoroch a únikových schodiskách má byť v rozmedzí 25°< α ≤ 35°.\r\n"+
                "Schodiská vo vnútri obytných budov s konštrukčnou výškou menšou ako 3000 mm a schodiská do pivníc a podkroví môžu mať sklon zvýšený až na 41°";

            StairsWidth="Minimálna povolená šírka schodiskového stupňa rebríkových schodísk je 150 mm;\r\n"+
                "Minimálna povolená šírka schodiska je 210 mm; stúpačky však musia byť široké najmenej 250 mm.\r\n"+
                "V prípade prístupných budov musí byť šírka schodiska minimálne 310 mm; výška schodiska nesmie presiahnuť 160 mm.";

            StairsHeight="V prípade rodinných domov sa neodporúča výška schodíka väčšia ako 190 mm; pohodlná je výška do 180 mm. Optimálna výška schodu je 150 až 180 mm.";
        }   
        
        public new string Help => AppName+"  "+Version+"\r\n"+
            "Autor: "+Author+"\r\n"+
            "\r\n"+
            "Čo sa všetko kontroluje?\r\n"+
            "Kontroluje sa rozmery - schodisko výška stupňa, hĺbka schodu, zodpovedá dĺžke kroku, uhol schodiska, šírka ramien, počet stupňov v ramene. Geometria zodpovedá zákonom, vyhláškám, normám, normám.\r\n "+
            "\r\n"+
            "Kam sa ukladá globálne nastavenie?\r\n"+
            "%appdata%\\CheckApiRevit\\Settings.ini.\r\n"+
            "\r\n"+
            "Jak můžu zobrazit více informací v paneli detekce?\r\n"+
            "Nastaviť typ rodiny u schodiska (Type mark).\r\n"; 
    }

    class LangHanacke : Lang {
        public LangHanacke() { 
            OpenApp="Otevřit aplêkacô";
            TabName="Kontrola";
            PanelName="Kontrola";
            StairLehman="Lehmanuv vzorec";
            StairHeight ="Véška schoda";
            StairDepth="Šéřka schoda";
            StairAngle="Sklon schodišťa";
            Show="Ôkázat"; 
            Recheck="Nová kontrola";
            Export="Exportovat";
            Settings="Nastaveňi"; 

            HelpIcon="Nápověda";
            Recheck="Nová kontrola";
            Export="Exportovat";
            Settings="Nastaveni";
            NotFound="Nenalezené žádné objekt ke kontrole";
            FoundOne="Nalezené jeden objekt";
            FoundTwo="Nalezené dva objektê";
            FoundThree="Nalezené třê objektê";
            FoundFour="Nalezené štêřê objektê";
            FoundX=" Nalezenéch ? objektu";  
            
            Apartement="Bêtové dum";
            Administrative="Administrativa";
            InsideApartement="Vnitřek bêtô";
            Technic="Technicky";
            Exterier="Exteriér";
            UnknownBuilding="Unknown";
            FamilyHouse="Rodinné dum";
            Stairs="Schodê";        
            WidthOfRun ="Šiřka ramena";
            NumberOfStairs ="Počet schodu v rameňô";
            DefaultBuilding ="Véchozi";
            Type="Têp";
        }           
    }
    
    class LangValašsky : Lang {
        public LangValašsky() { 
            OpenApp="Otevřiť aplikacu";
            TabName="Kontrola";
            PanelName="Kontrola";
            StairLehman="Lehmanúv vzorec";
            StairHeight ="Výška stupňa";
            StairDepth="Šířka stupňa";
            StairAngle="Sklon schodišťa";
            Show="Ukázať"; 
            Recheck="Nová kontrola";
            Export="Exportovať";
            Settings="Nastavení";           
        }           
    }

    class LangSlovácky : Lang {
        public LangSlovácky() { 
            OpenApp="Otevřit aplikacu";
            TabName="Kontrola";
            PanelName="Kontrola";
            StairLehman="Lehmanúv vzorec";
            StairHeight ="Výška stupňa";
            StairDepth="Šířka stupňa";
            StairAngle="Sklon schodišťa";
            Show="Ukázat"; 
            Recheck="Nová kontrola";
            Export="Exportovat";
            Settings="Nastavení";           
        }           
    }
}

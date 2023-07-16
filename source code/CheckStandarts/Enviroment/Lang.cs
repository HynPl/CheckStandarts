namespace CheckStandarts {
    class LangEnglish {   
      public string   
            AppName,
            Version,
            Author,

            TabName,
            PanelName,
            OpenApp,
            OpenAppToolTip,

            Recheck,
            Export,
            Settings,
            HelpIcon,

            StairLehman,
            StairHeight,
            StairDepth,
            StairAngle,
            StairsAngle,

            StairsWidthMessage,
            StairsHeightMessage,
            NumberOfStairs,

            // Error messages
            RunWidthMessage,
            RunWidthBD,
            StairsNumbersMessage,

            Show,            

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
            DefaultBuilding,
            Run,
            TypeMark,
            Level,
            Using,
            Elevation,
            ElevationRelative,
            Landing,
            Type,
            CorrentItems,
            WarlingItems,
            WrongItems;

        public string 
            UnknownLoc,
            GeneralWtithoutPrague,
            Prague,
            Location,
            LangExport,
            LangMessages,
            BuildingType,
            StairsLehmanMessage;

        public LangEnglish() {
            AppName="Check Standarts";
            Version="v0.1";
            Author="HynPl";

            TabName="Check";
            PanelName="Checking";
            OpenApp="Open app for checking";
            OpenAppToolTip="Open app for checking standards; laws; regulations in Czech Republic";

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
                 
            RunWidthMessage="ČSN 73 4130; The minimum clear width of the main staircase arms is 900 mm for RD. It is advisable to choose at least 1000mm. Other than that; must comply with fire escape requirements of CSN 73 0802 (fire is not considered in this programme).";
            StairsNumbersMessage="Decree No.137/1998 Coll. on general technical requirements for construction; § 34 point 6: The number of stair treads in one stair arm of the main staircase may not exceed 16; for auxiliary staircases and staircases inside flats, not more than 18; the stair tread scale must be horizontal; without inclination in the transverse and longitudinal direction.";
            RunWidthBD="ČSN 73 4130; The minimum clear width of the main staircase arms is 1100mm for BD. It is advisable to choose at least 1200mm. Handrails need to be considered. Other than that; must comply with fire escape requirements of CSN 73 0802 (fire is not considered in this programme).";
            
            StairsAngle="Decree No.398/2009 Coll. 2.1.1.: The slope of the stair arm must not be greater than 28° and the height of the stair or balancing step must not be greater than 160 mm; this does not apply to apartment buildings with a lift.\r\n"+
                "ČSN 73 4130 Staircases and inclined ramps - Basic requirements: '6.1.1 The inclination of stair arms in apartment buildings; inside assembly areas and escape staircases should be within 25°< α ≤ 35°.\r\n"+
                "Staircases inside flats with a construction height of less than 3000mm and staircases to cellars and attics can be inclined up to 41°.";

            StairsWidthMessage="The minimum permissible width of the stair tread of ladder staircases is 150 mm;\r\n"+
                "The minimum permissible width of the step is 210 mm; however, the platform must be at least 250 mm wide.\r\n"+
                "For barrier-free buildings, the width of the step must be at least 310 mm; the height must not exceed 160 mm. ";

            StairsHeightMessage="A step height of more than 190 mm is not recommended for single-family homes; up to 180 mm is comfortable. The optimum step height is 150 to 180mm.";
            StairsLehmanMessage="The length of the step at the staircase should be around 600 and 650 mm after rounding to tens, better between 630-610 mm.";

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
            ElevationRelative="rel. elevation";
            Using="Using";
                        
            CorrentItems="Good value";
            WarlingItems="Not recommended value";
            WrongItems="Bad value";
                        
            UnknownLoc="Unknown";
            GeneralWtithoutPrague="CZ without Prague";
            Prague="Prague";
            Location="Location";
            LangExport="Language export";
            LangMessages="Language messages";
            BuildingType="Type building";            
        }

        public string Help => AppName+"  "+Version+"\r\n"+
            "Author: "+Author+"\r\n"+
            "Github: https://github.com/HynPl/CheckStandarts\r\n"+
            "Supporting parts: PicoXLSX, Raphael Stoeckli, MIT License\r\n"+
            "\r\n"+
            "What is checked?\r\n"+
            "The geometry of objects is checked - the height of the stairs, the depth of the step, whether it corresponds to the length of the step, the angle of the staircase, the width of the leg, the number of steps in the leg. Whether the geometry corresponds to laws, decrees, norms, standards.\r\n "+
            "\r\n"+
            "Where are global settings stored?\r\n"+
            "%appdata%\\CheckApiRevit\\Settings.ini.\r\n"+
            "\r\n"+
            "How can I display more information in the detections panel?\r\n"+
            "Set the type mark at the staircase family.\r\n";  

        public string ExportHeader => AppName + " - Export";

        public string AfterClose ="Appling settings after reopen";
        public string SomeChangesAfterCloseAndOpen ="Language text will be applied after reopen aplication.";
    }

    class LangCzech : LangEnglish {
         public LangCzech() {
            AppName="Kontrola standardů";
            Version="v0.1";
            Author="HynPl";
            Elevation="ve výšce";
            ElevationRelative="v rel. výšce";
            TabName="Kontrola";
            PanelName="Zkontrolovat";
            OpenApp="Otevřít aplikaci ke kontrole";
            OpenAppToolTip="Otevřít aplikaci ke kontrole zákonů, předpisů, vyhlášek, norem, standardů v České Republice";
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
            StairsLehmanMessage="Délka kroku u schodiště by měla být kolem 600 a 650 mm po zaokrouhlení na desítky, lépe mezi 630-610 mm.";
            //https://profesis.ckait.cz/wp-content/uploads/2020/07/ts-ckait-02-2021.pdf
            RunWidthMessage="ČSN 73 4130; Minimální průchodná šířka ramen hlavních schodišť je u RD 900mm. \r\n"+
                "Minimální průchodná šířka ramen hlavních schodišť je u BD 1100mm. Vhodné zvolit aspoň 1200mm. \r\n"+
                "Vhodné zvolit aspoň 1000mm. Mimo to; musí vyhovovat požárnímu úniku ČSN 73 0802 (požár tento program nepočítá). Požární pruh je 550mm.\r\n"+
                "Nařízení č. 10/2016 Sb. hl. m. Prahy: Byty, inviduální bydlení ≥ 750 mm, ostatní ≥ 900 mm. Konstrukce zábradlí, popř. madel může do průchodné šířky ramene zasahovat nejvýše 100 mm";

            StairsNumbersMessage="Vyhláška č. 137/1998 Sb. o obecných technických požadavcích na výstavbu; § 34 bod 6: "+
                "Počet výšek schodišťových stupňů v jednom schodišťovém rameni hlavního schodiště smí být nejvýše 16;"+
                "u pomocných  schodišť a u schodišť uvnitř bytů nejvýše 18; stupnice schodišťového stupně musí být vodorovná; bez sklonu v příčném i podélném směru.";
            
            StairsAngle="Vyhláška č. 398/2009 Sb. 2.1.1.: Sklon schodišťového ramene nesmí být větší než 28° a výška schodišťového nebo vyrovnávacího stupně větší než 160 mm; to neplatí pro stavby bytových domů s výtahem.\r\n"+
                "ČSN 73 4130 Schodiště a šikmé rampy – Základní požadavky: „6.1.1 Sklon schodišťových ramen v bytových domech; uvnitř prostorů určených ke shromažďování osob a únikových schodišť by měl být v rozmezí 25°< α ≤ 35°.\r\n"+
                "Norma ČSN 73 4301: Schodište uvnitř bytů s konstrukční výškou menší než 3000mm a u schodišť do sklepů a na půdu je možno sklon zvýšit až na 41°.\r\n"+
                "Nařízení č. 10/2016 Sb. hl. m. Prahy: V případě bezbariérových staveb ≤ 35°.\r\n"+
                "Pražské stavební předpisy §56 Do prostor určených pro občasné používání omezeným počtem osob lze navrhnout žebříkové schodiště, jehož šířka musí být nejméně 0,55 m.";

            StairsWidthMessage="Nejmenší dovolená šířka schodišťového stupně žebříkových schodišť je 150 mm;\r\n"+
                "Minimální povolená šířka stupně je 210 mm; nástupnice však musí dosahovat alespoň šířky 250 mm.\r\n"+
                "U bezbariérových staveb musí šířka stupně dosahovat alespoň hodnoty 310 mm; výška nesmí překročit 160 mm.\r\n"+
                "Pražské předpisy příloha č. 1: Šířka schodišťového stupně na výstupní čáře musí být nejméně 0,21 m. V bytech,\r\n"+
                "ve stavbách individuálního bydlení a ve stavbách pro rodinnou rekreaci může být šířka"+
                "schodišťového stupně v odůvodněných případech snížena až na 0,18 m."+
                "— Šířka schodišťové stupnice na výstupní čáře musí být nejméně 0,25 m. V bytech,"+
                "ve stavbách individuálního bydlení a ve stavbách pro rodinnou rekreaci může být šířka"+
                "schodišťové stupnice v odůvodněných případech snížena až na 0,225 m.";

            StairsHeightMessage="Pro rodinné domy se nedoporučuje výška stupně vyšší jak 190 mm; pohodlné se dá uvažovat do 180 mm. Optimální výška stupně je 150 až 180mm.";

            CorrentItems="Dobrá hodnota";
            WarlingItems="Nedoporučená hodnota";
            WrongItems="Nevhodná hodnota";

            
            UnknownLoc="Neznámé";
            GeneralWtithoutPrague="ČR mimo Prahu";
            Prague="Praha";
            Location="Umístění";
            LangExport="Jazyk exportu";
            LangMessages="Jazyk zpráv";
            BuildingType="Typ budovy";
        }

        public new string Help => AppName+"  "+Version+"\r\n"+
            "Autor: "+Author+"\r\n"+
            "Github: https://github.com/HynPl/CheckStandarts\r\n"+
            "Podpůrné součásti: PicoXLSX, Raphael Stoeckli, MIT Licence\r\n"+
            "\r\n"+
            "Co se vše kontroluje?\r\n"+
            "Kontroluje se rozměry - schodišť výška stupně, hloubka schodu, zda odpovídá délce kroku, úhel schodiště, šířka ramene, počet stupňů v rameni. Zda geometrie odpovídá zákonům, vyhláškám, normám, standardům.\r\n "+
            "\r\n"+
            "Kam se ukládá globální nastavení?\r\n"+
            "%appdata%\\CheckApiRevit\\Settings.ini.\r\n"+
            "\r\n"+
            "Jak můžu zobrazit více informací v panelu detekcí?\r\n"+
            "Nastavit typ rodiny u schodiště (Type mark).\r\n";  
    }
    
    class LangSlovak : LangEnglish {
        public LangSlovak() { 
            OpenApp="Otvoriť aplikáciu na kontrolu";
            OpenAppToolTip="Otvoriť aplikáciu na kontrolu zákonov, predpisov, vyhlášok, noriem, štandardov v Českej republike";
            TabName="Kontrola";
            PanelName="Kontrola";
            StairLehman="Lehmanov vzorec";
            StairHeight ="Výška stupňa";
            StairDepth="Šírka stupňa";
            StairAngle="Sklon schodiska";
            Show="Ukázať";
            Recheck="Nová kontrola";
            Export="Exportovať";

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
                             
            RunWidthMessage="ČSN 73 4130; minimálna svetlá šírka hlavných schodiskových ramien je 900 mm pre RD. Odporúča sa zvoliť aspoň 1000 mm. Ostatné; musí vyhovovať požiarnej tesnosti ČSN 73 0802 (v tomto programe sa neuvažuje s požiarom).";
            StairsNumbersMessage="Vyhláška č. 137/1998 Z. z. o všeobecných technických požiadavkách na výstavbu; § 34 bod 6: Počet výšok schodiskových stupňov v jednom schodiskovom ramene hlavného schodiska nesmie byť väčší ako 16; pri pomocných schodiskách a schodiskách vo vnútri bytov najviac 18; stupnica schodiskových stupňov musí byť vodorovná; bez sklonu v priečnom a pozdĺžnom smere.";
            RunWidthBD="ČSN 73 4130; Minimálna svetlá šírka ramien hlavných schodísk v BD je 1100 mm. Odporúča sa zvoliť aspoň 1200mm. Je potrebné zvážiť zábradlia. Ostatné; musí vyhovovať požiarnej tesnosti ČSN 73 0802 (v tomto programe sa neuvažuje s požiarom).";
            
            StairsAngle="Vyhláška č. 398/2009 Z. z. 2.1.1: Sklon schodiskového ramena nesmie byť väčší ako 28° a výška schodiska alebo vyrovnávacieho stupňa väčšia ako 160 mm; neplatí pre bytové domy s výťahom.\r\n"+
                "ČSN 73 4130 Schodiská a šikmé rampy - Základné požiadavky: \"6.1.1 Sklon schodiskových ramien v bytových domoch; vo vnútorných zhromažďovacích priestoroch a únikových schodiskách má byť v rozmedzí 25°< α ≤ 35°.\r\n"+
                "Schodiská vo vnútri obytných budov s konštrukčnou výškou menšou ako 3000 mm a schodiská do pivníc a podkroví môžu mať sklon zvýšený až na 41°";

            StairsWidthMessage="Minimálna povolená šírka schodiskového stupňa rebríkových schodísk je 150 mm;\r\n"+
                "Minimálna povolená šírka schodiska je 210 mm; stúpačky však musia byť široké najmenej 250 mm.\r\n"+
                "V prípade prístupných budov musí byť šírka schodiska minimálne 310 mm; výška schodiska nesmie presiahnuť 160 mm.";

            StairsHeightMessage="V prípade rodinných domov sa neodporúča výška schodíka väčšia ako 190 mm; pohodlná je výška do 180 mm. Optimálna výška schodu je 150 až 180 mm.";
        }   
        
        public new string Help => AppName+"  "+Version+"\r\n"+
            "Autor: "+Author+"\r\n"+
            "Github: https://github.com/HynPl/CheckStandarts\r\n"+
            "Exportovanie do Excela: PicoXLSX, Raphael Stoeckli, MIT Licencia\r\n"+
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

    class LangHanacke : LangEnglish {
        public LangHanacke() { 
            OpenAppToolTip="Otevřit aplêkacô";
            TabName="Kontrola";
            PanelName="Kontrola";
            StairLehman="Lehmanu vzorec";
            StairHeight ="Véška schoda";
            StairDepth="Šéřka schoda";
            StairAngle="Sklon schodišťa";
            Show="Ôkázat"; 
            Recheck="Nová kontrola";
            Export="Exportovat";

            HelpIcon="Nápověda";
            Recheck="Nová kontrola";
            Export="Exportovat";
            Settings="Zeštelovat";
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
            UnknownBuilding="Neznámé";
            FamilyHouse="Rodinné dum";
            Stairs="Schodê";        
            WidthOfRun ="Šiřka ramena";
            NumberOfStairs ="Počet schodu v rameňô";
            DefaultBuilding ="Véchozi";
            Type="Têp";
            Landing="Odpočinek";
        }           

        public new string Help => AppName+"  "+Version+"\r\n"+
            "Autor: "+Author+"\r\n"+
            "Githôb: https://github.com/HynPl/CheckStandarts\r\n"+
            "Exportováni do Excela: PicoXLSX, Raphael Stoeckli, MIT Licenca\r\n"+
            "\r\n"+
            "Co se fšecko kontrolôje?\r\n"+
            "Kontrolôjó se velêkostě - ô schodišťa véška stôpňa, hlóbka schoda, ešle schodek odpovidá zdylce krokô, uhel schodišťa, šéřka ramene, počet stôpňu v rameňô. Ešle geometrija odpovidá zákonum, vêhláškám, normám, standardum.\r\n "+
            "\r\n"+
            "Gde se ôkládajó globálni nastaveni?\r\n"+
            "%appdata%\\CheckApiRevit\\Settings.ini.\r\n"+
            "\r\n"+
            "Jag mužô zobrazit vic informaci v panelô detekci?\r\n"+
            "Nastavit têp rodinê ô schodišťa (Type mark).\r\n";  
    }
    
    class LangValašsky : LangEnglish {
        public LangValašsky() { 
            OpenAppToolTip="Otevřiť aplikacu";
            TabName="Kontrola";
            PanelName="Kontrola";
            StairLehman="Lehmanú vzorec";
            StairHeight ="Zvýška stupňa";
            StairDepth="Šířka stupňa";
            StairAngle="Sklon schodišťa";
            Show="Ukázať"; 
            Recheck="Nová kontrola";
            Export="Exportovať";
            Settings="Zeštelovať";           
        }           

         public new string Help => AppName+"  "+Version+"\r\n"+
            "Autor: "+Author+"\r\n"+
            "Github: https://github.com/HynPl/CheckStandarts\r\n"+
            "Exportování do Excela: PicoXLSX, Raphael Stoeckli, MIT Licenca\r\n"+
            "\r\n"+
            "Co se všecko kontroluje?\r\n"+
            "Kontrolujú sa rozměry - schodišť zvýška stupňa, hłúbka schoda, či odpovídá schodek zdélce kroku, úhel schodišťa, šířka rameňa, počet stupňom v rameni. Či tvar odpovídá zákonom, vyhláškám, normám, standardom.\r\n "+
            "\r\n"+
            "Gde sa nakłádá globální nastavení?\r\n"+
            "%appdata%\\CheckApiRevit\\Settings.ini.\r\n"+
            "\r\n"+
            "Kerak možu zobraziť vjecéj informací v panely detekcí?\r\n"+
            "Nastaviť typ rodiny u schodú (Type mark).\r\n";  
    }

    class LangSlovácky : LangEnglish {
        public LangSlovácky() { 
            OpenAppToolTip="Otevřít aplikacu";
            TabName="Kontrola";
            PanelName="Kontrola";
            StairLehman="Lehmanúv vzorec";
            StairHeight ="Výška stupňa";
            StairDepth="Šířka stupňa";
            StairAngle="Sklon schodišťa";
            Show="Ukázat"; 
            Recheck="Nová kontrola";
            Export="Exportovat";
            Settings="Zeštelovat";           
        }           

        public new string Help => AppName+"  "+Version+"\r\n"+
            "Autor: "+Author+"\r\n"+
            "Github: https://github.com/HynPl/CheckStandarts\r\n"+
            "Exportování do Excela: PicoXLSX, Raphael Stoeckli, MIT Licenca\r\n"+
            "\r\n"+
            "Co se fšecko kontroluje?\r\n"+
            "Kontrolujú sa rozměry - u schodišť výška stupňa, húbka schoda, esi odpovídá schodek délce kroka, úhel schodišťa, šířka rameňa, počet stupňom v rameňu. Esi tvar odpovídá zákonom, vyhláškám, normám, standardom.\r\n "+
            "\r\n"+
            "Gde sa ukuádá globální nastavení?\r\n"+
            "%appdata%\\CheckApiRevit\\Settings.ini.\r\n"+
            "\r\n"+
            "Jag možu zobrazit víc informací v panelu detekcí?\r\n"+
            "Nastaviť typ rodiny u schodú (Type mark).\r\n";  
    }
}

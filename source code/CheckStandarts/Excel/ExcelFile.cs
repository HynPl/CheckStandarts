using CarlosAg.ExcelXmlWriter;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Mime;
using System.Text;

namespace CheckStandarts.Excel {
    public class ExcelFile {
        public Sheet Sheet;
        public List<ExcelStyle> ExcelStyles;
        public string Author;

        //public void Cre
        public ExcelFile(){ 
            Sheet=new Sheet();
            ExcelStyles=new List<ExcelStyle>();
        }

        public void Save(string path) { 
           // if (Sheet.Count==0) return;

            // Create temp Folder
            DateTime now=DateTime.Now;
            string nametmp=now.Year+""+now.Day+""+now.Month+""+now.Hour+""+now.Minute+""+now.Second+"_excelfile_tmp";

            string DirectoryTMP= Path.GetTempPath()+"\\"+nametmp;
            Directory.CreateDirectory(DirectoryTMP);

            // Calculate total cells
            List<Sheet.CellLoc> Cells=new List<Sheet.CellLoc>();
        //    foreach (Sheet sheet in Sheet) {
              //  foreach cells 
                foreach (Sheet.CellLoc c in Sheet.Cells) { 
                    Cells.Add(c);    
                }

                List<List<Sheet.CellLoc>> table =Sheet.GetRowsWithCells();
                int maxColumn=-1;
            int rowIndex=0;
            int cellIndex=0;
            string celldata="", cellStringValues="", fontsCellStyles="";
          //  string cellData="";
                foreach (List<Sheet.CellLoc> row in table) { 
                    if (row.Count>maxColumn) maxColumn=row.Count;

                     string rowData=@"<row r="""+rowIndex+@""" spans=""1:3"" x14ac:dyDescent=""0.25"">";
                    
                    foreach (Sheet.CellLoc cell in row) { 
                        if (cell==null) continue;
                        celldata=@"<c r="""+GetExcelCountingCell(cell.PosX, cell.PosY)+/*" s="1" t="s*/">";
                        celldata+="<v>"+cellIndex+"</v>";
                        celldata+="</c>";

                        cellStringValues="<si><t>"+cell.Cell.Text+"</t></si>";

                        cellIndex++;
                    }
                    rowData+="</row>";

                    rowIndex++;
                }
            //}
            string colData="";
            foreach ((Column, int) c in Sheet.Columns) { 
                colData+=c.Item1.GetData(c.Item2);
            }
                      

            // fontStyles.xml
            {
                
            }
            // Folder _rels
            { 
                Directory.CreateDirectory(DirectoryTMP+"\\_rels");

                // Write file _rels\.rels
                {
                    File.WriteAllText(DirectoryTMP+"\\_rels\\.rels",
                    @"<?xml version=""1.0"" encoding=""UTF-8"" standalone=""yes""?>"+"\n"+
                    @"<Relationships xmlns=""http://schemas.openxmlformats.org/package/2006/relationships""><Relationship Id=""rId3"" Type=""http://schemas.openxmlformats.org/officeDocument/2006/relationships/extended-properties"" Target=""docProps/app.xml""/><Relationship Id=""rId2"" Type=""http://schemas.openxmlformats.org/package/2006/relationships/metadata/core-properties"" Target=""docProps/core.xml""/><Relationship Id=""rId1"" Type=""http://schemas.openxmlformats.org/officeDocument/2006/relationships/officeDocument"" Target=""xl/workbook.xml""/></Relationships>");
                }
            }
            
            // Folder docProps
            { 
                Directory.CreateDirectory(DirectoryTMP+"\\docProps");

                // Write file docProps\\app.xml
                {
                    File.WriteAllText(DirectoryTMP+"\\docProps\\app.xml",
                    @"<?xml version=""1.0"" encoding=""UTF-8"" standalone=""yes""?>"+"\n"+
                    @"<Properties xmlns=""http://schemas.openxmlformats.org/officeDocument/2006/extended-properties"" xmlns:vt=""http://schemas.openxmlformats.org/officeDocument/2006/docPropsVTypes""><Application>Microsoft Excel</Application><DocSecurity>0</DocSecurity><ScaleCrop>false</ScaleCrop><HeadingPairs><vt:vector size=""2"" baseType=""variant""><vt:variant><vt:lpstr>Listy</vt:lpstr></vt:variant><vt:variant><vt:i4>1</vt:i4></vt:variant></vt:vector></HeadingPairs><TitlesOfParts><vt:vector size=""1"" baseType=""lpstr""><vt:lpstr>exported</vt:lpstr></vt:vector></TitlesOfParts><LinksUpToDate>false</LinksUpToDate><SharedDoc>false</SharedDoc><HyperlinksChanged>false</HyperlinksChanged><AppVersion>16.0300</AppVersion></Properties>");
                }

                // Write file docProps\\core.xml
                {
                    string edited=now.ToString("yyyy-MM-dd\'T\'HH:mm:ss.SSS\'Z\'");
                    File.WriteAllText(DirectoryTMP+"\\docProps\\core.xml",
                    @"<?xml version=""1.0"" encoding=""UTF-8"" standalone=""yes""?>"+"\n"+
                    @"<cp:coreProperties xmlns:cp=""http://schemas.openxmlformats.org/package/2006/metadata/core-properties"" xmlns:dc=""http://purl.org/dc/elements/1.1/"" xmlns:dcterms=""http://purl.org/dc/terms/"" xmlns:dcmitype=""http://purl.org/dc/dcmitype/"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance""><dc:creator>"+Author+@"</dc:creator><cp:lastModifiedBy>-</cp:lastModifiedBy><dcterms:created xsi:type=""dcterms:W3CDTF"">"+edited+@"</dcterms:created><dcterms:modified xsi:type=""dcterms:W3CDTF"">""+edited+@""</dcterms:modified></cp:coreProperties>");
                }
            }
            
            // Folder xl
            { 
                Directory.CreateDirectory(DirectoryTMP+"\\xl");
 
                // Folder xl\ _rels
                { 
                    Directory.CreateDirectory(DirectoryTMP+"\\xl\\_rels");

                    // Write worbook.xml.rels
                    {
                        File.WriteAllText(DirectoryTMP+"\\xl\\_rels\\worbook.xml.rels",
                        @"<?xml version=""1.0"" encoding=""UTF-8"" standalone=""yes""?>"+"\n"+
                        @"<Relationships xmlns=""http://schemas.openxmlformats.org/package/2006/relationships""><Relationship Id=""rId3"" Type=""http://schemas.openxmlformats.org/officeDocument/2006/relationships/fontStyles"" Target=""fontStyles.xml""/><Relationship Id=""rId2"" Type=""http://schemas.openxmlformats.org/officeDocument/2006/relationships/theme"" Target=""theme/theme1.xml""/><Relationship Id=""rId1"" Type=""http://schemas.openxmlformats.org/officeDocument/2006/relationships/worksheet"" Target=""worksheets/sheet1.xml""/><Relationship Id=""rId4"" Type=""http://schemas.openxmlformats.org/officeDocument/2006/relationships/sharedStrings"" Target=""sharedStrings.xml""/></Relationships>");
                    }
                }

                // Folder xl\theme
                { 
                    Directory.CreateDirectory(DirectoryTMP+"\\xl\\theme");

                    // Write theme1.xml
                    {
                      
                        File.WriteAllText(DirectoryTMP+"\\xl\\theme\\theme1.xml",
                        @"<?xml version=""1.0"" encoding=""UTF-8"" standalone=""yes""?>"+"\n"+
                                   
                            @"<a:theme xmlns:a=""http://schemas.openxmlformats.org/drawingml/2006/main"" name=""Motiv Office"">"+
                                @"<a:themeElements>"+
                                    @"<a:clrScheme name=""Office"">"+
                                        @"<a:dk1>"+
                                            @"<a:sysClr val=""windowText"" lastClr=""000000""/>"+
                                        @"</a:dk1>"+
                                        @"<a:lt1>"+
                                            @"<a:sysClr val=""window"" lastClr=""FFFFFF""/>"+
                                        @"</a:lt1>"+
                                        @"<a:dk2>"+
                                            @"<a:srgbClr val=""44546A""/>"+
                                        @"</a:dk2>"+
                                        @"<a:lt2>"+
                                            @"<a:srgbClr val=""E7E6E6""/>"+
                                        @"</a:lt2>"+
                                        @"<a:accent1>"+
                                            @"<a:srgbClr val=""4472C4""/>"+
                                        @"</a:accent1>"+
                                        @"<a:accent2>"+
                                            @"<a:srgbClr val=""ED7D31""/>"+
                                        @"</a:accent2>"+
                                        @"<a:accent3>"+
                                            @"<a:srgbClr val=""A5A5A5""/>"+
                                        @"</a:accent3>"+
                                        @"<a:accent4>"+
                                            @"<a:srgbClr val=""FFC000""/>"+
                                        @"</a:accent4>"+
                                        @"<a:accent5>"+
                                            @"<a:srgbClr val=""5B9BD5""/>"+
                                        @"</a:accent5>"+
                                        @"<a:accent6>"+
                                            @"<a:srgbClr val=""70AD47""/>"+
                                        @"</a:accent6>"+
                                        @"<a:hlink>"+
                                            @"<a:srgbClr val=""0563C1""/>"+
                                        @"</a:hlink>"+
                                        @"<a:folHlink>"+
                                            @"<a:srgbClr val=""954F72""/>"+
                                        @"</a:folHlink>"+
                                    @"</a:clrScheme>"+

                                    @"<a:fontScheme name=""Office"">"+
                                        @"<a:majorFont>"+
                                            @"<a:latin typeface=""Calibri Light"" panose=""020F0302020204030204""/>"+
                                            @"<a:ea typeface=""/>"+
                                            @"<a:cs typeface=""/>"+
                                            @"<a:font script=""Jpan"" typeface=""游ゴシック Light""/>"+
                                            @"<a:font script=""Hang"" typeface=""맑은 고딕""/>"+
                                            @"<a:font script=""Hans"" typeface=""等线 Light""/>"+
                                            @"<a:font script=""Hant"" typeface=""新細明體""/>"+
                                            @"<a:font script=""Arab"" typeface=""Times New Roman""/>"+
                                            @"<a:font script=""Hebr"" typeface=""Times New Roman""/>"+
                                            @"<a:font script=""Thai"" typeface=""Tahoma""/>"+
                                            @"<a:font script=""Ethi"" typeface=""Nyala""/>"+
                                            @"<a:font script=""Beng"" typeface=""Vrinda""/>"+
                                            @"<a:font script=""Gujr"" typeface=""Shruti""/>"+
                                            @"<a:font script=""Khmr"" typeface=""MoolBoran""/>"+
                                            @"<a:font script=""Knda"" typeface=""Tunga""/>"+
                                            @"<a:font script=""Guru"" typeface=""Raavi""/>"+
                                            @"<a:font script=""Cans"" typeface=""Euphemia""/>"+
                                            @"<a:font script=""Cher"" typeface=""Plantagenet Cherokee""/>"+
                                            @"<a:font script=""Yiii"" typeface=""Microsoft Yi Baiti""/>"+
                                            @"<a:font script=""Tibt"" typeface=""Microsoft Himalaya""/>"+
                                            @"<a:font script=""Thaa"" typeface=""MV Boli""/>"+
                                            @"<a:font script=""Deva"" typeface=""Mangal""/>"+
                                            @"<a:font script=""Telu"" typeface=""Gautami""/>"+
                                            @"<a:font script=""Taml"" typeface=""Latha""/>"+
                                            @"<a:font script=""Syrc"" typeface=""Estrangelo Edessa""/>"+
                                            @"<a:font script=""Orya"" typeface=""Kalinga""/>"+
                                            @"<a:font script=""Mlym"" typeface=""Kartika""/>"+
                                            @"<a:font script=""Laoo"" typeface=""DokChampa""/>"+
                                            @"<a:font script=""Sinh"" typeface=""Iskoola Pota""/>"+
                                            @"<a:font script=""Mong"" typeface=""Mongolian Baiti""/>"+
                                            @"<a:font script=""Viet"" typeface=""Times New Roman""/>"+
                                            @"<a:font script=""Uigh"" typeface=""Microsoft Uighur""/>"+
                                            @"<a:font script=""Geor"" typeface=""Sylfaen""/>"+
                                            @"<a:font script=""Armn"" typeface=""Arial""/>"+
                                            @"<a:font script=""Bugi"" typeface=""Leelawadee UI""/>"+
                                            @"<a:font script=""Bopo"" typeface=""Microsoft JhengHei""/>"+
                                            @"<a:font script=""Java"" typeface=""Javanese Text""/>"+
                                            @"<a:font script=""Lisu"" typeface=""Segoe UI""/>"+
                                            @"<a:font script=""Mymr"" typeface=""Myanmar Text""/>"+
                                            @"<a:font script=""Nkoo"" typeface=""Ebrima""/>"+
                                            @"<a:font script=""Olck"" typeface=""Nirmala UI""/>"+
                                            @"<a:font script=""Osma"" typeface=""Ebrima""/>"+
                                            @"<a:font script=""Phag"" typeface=""Phagspa""/>"+
                                            @"<a:font script=""Syrn"" typeface=""Estrangelo Edessa""/>"+
                                            @"<a:font script=""Syrj"" typeface=""Estrangelo Edessa""/>"+
                                            @"<a:font script=""Syre"" typeface=""Estrangelo Edessa""/>"+
                                            @"<a:font script=""Sora"" typeface=""Nirmala UI""/>"+
                                            @"<a:font script=""Tale"" typeface=""Microsoft Tai Le""/>"+
                                            @"<a:font script=""Talu"" typeface=""Microsoft New Tai Lue""/>"+
                                            @"<a:font script=""Tfng"" typeface=""Ebrima""/>"+
                                        @"</a:majorFont>"+
                                    @"<a:minorFont>"+

                                    @"<a:latin typeface=""Calibri"" panose=""020F0502020204030204""/>"+
                                        @"<a:ea typeface=""/>"+
                                        @"<a:cs typeface=""/>"+
                                        @"<a:font script=""Jpan"" typeface=""游ゴシック""/>"+
                                        @"<a:font script=""Hang"" typeface=""맑은 고딕""/>"+
                                        @"<a:font script=""Hans"" typeface=""等线""/>"+
                                        @"<a:font script=""Hant"" typeface=""新細明體""/>"+
                                        @"<a:font script=""Arab"" typeface=""Arial""/>"+
                                        @"<a:font script=""Hebr"" typeface=""Arial""/>"+
                                        @"<a:font script=""Thai"" typeface=""Tahoma""/>"+
                                        @"<a:font script=""Ethi"" typeface=""Nyala""/>"+
                                        @"<a:font script=""Beng"" typeface=""Vrinda""/>"+
                                        @"<a:font script=""Gujr"" typeface=""Shruti""/>"+
                                        @"<a:font script=""Khmr"" typeface=""DaunPenh""/>"+
                                        @"<a:font script=""Knda"" typeface=""Tunga""/>"+
                                        @"<a:font script=""Guru"" typeface=""Raavi""/>"+
                                        @"<a:font script=""Cans"" typeface=""Euphemia""/>"+
                                        @"<a:font script=""Cher"" typeface=""Plantagenet Cherokee""/>"+
                                        @"<a:font script=""Yiii"" typeface=""Microsoft Yi Baiti""/>"+
                                        @"<a:font script=""Tibt"" typeface=""Microsoft Himalaya""/>"+
                                        @"<a:font script=""Thaa"" typeface=""MV Boli""/>"+
                                        @"<a:font script=""Deva"" typeface=""Mangal""/>"+
                                        @"<a:font script=""Telu"" typeface=""Gautami""/>"+
                                        @"<a:font script=""Taml"" typeface=""Latha""/>"+
                                        @"<a:font script=""Syrc"" typeface=""Estrangelo Edessa""/>"+
                                        @"<a:font script=""Orya"" typeface=""Kalinga""/>"+
                                        @"<a:font script=""Mlym"" typeface=""Kartika""/>"+
                                        @"<a:font script=""Laoo"" typeface=""DokChampa""/>"+
                                        @"<a:font script=""Sinh"" typeface=""Iskoola Pota""/>"+
                                        @"<a:font script=""Mong"" typeface=""Mongolian Baiti""/>"+
                                        @"<a:font script=""Viet"" typeface=""Arial""/>"+
                                        @"<a:font script=""Uigh"" typeface=""Microsoft Uighur""/>"+
                                        @"<a:font script=""Geor"" typeface=""Sylfaen""/>"+
                                        @"<a:font script=""Armn"" typeface=""Arial""/>"+
                                        @"<a:font script=""Bugi"" typeface=""Leelawadee UI""/>"+
                                        @"<a:font script=""Bopo"" typeface=""Microsoft JhengHei""/>"+
                                        @"<a:font script=""Java"" typeface=""Javanese Text""/>"+
                                        @"<a:font script=""Lisu"" typeface=""Segoe UI""/>"+
                                        @"<a:font script=""Mymr"" typeface=""Myanmar Text""/>"+
                                        @"<a:font script=""Nkoo"" typeface=""Ebrima""/>"+
                                        @"<a:font script=""Olck"" typeface=""Nirmala UI""/>"+
                                        @"<a:font script=""Osma"" typeface=""Ebrima""/>"+
                                        @"<a:font script=""Phag"" typeface=""Phagspa""/>"+
                                        @"<a:font script=""Syrn"" typeface=""Estrangelo Edessa""/>"+
                                        @"<a:font script=""Syrj"" typeface=""Estrangelo Edessa""/>"+
                                        @"<a:font script=""Syre"" typeface=""Estrangelo Edessa""/>"+
                                        @"<a:font script=""Sora"" typeface=""Nirmala UI""/>"+
                                        @"<a:font script=""Tale"" typeface=""Microsoft Tai Le""/>"+
                                        @"<a:font script=""Talu"" typeface=""Microsoft New Tai Lue""/>"+
                                        @"<a:font script=""Tfng"" typeface=""Ebrima""/>"+
                                    @"</a:minorFont>"+
                                @"</a:fontScheme>"+

                                @"<a:fmtScheme name=""Office"">"+
                                    @"<a:fillStyleLst>"+
                                        @"<a:solidFill>"+
                                        @"<a:schemeClr val=""phClr""/>"+
                                            @"</a:solidFill>"+
                                        @"<a:gradFill rotWithShape=""1"">"+
                                            @"<a:gsLst>"+
                                                @"<a:gs pos=""0"">"+
                                                    @"<a:schemeClr val=""phClr"">"+
                                                        @"<a:lumMod val=""110000""/>"+
                                                        @"<a:satMod val=""105000""/>"+
                                                        @"<a:tint val=""67000""/>"+
                                                    @"</a:schemeClr>"+
                                                @"</a:gs>"+
                                                @"<a:gs pos=""50000"">"+
                                                    @"<a:schemeClr val=""phClr"">"+
                                                        @"<a:lumMod val=""105000""/>"+
                                                        @"<a:satMod val=""103000""/>"+
                                                        @"<a:tint val=""73000""/>"+
                                                    @"</a:schemeClr>"+
                                                @"</a:gs>"+
                                                @"<a:gs pos=""100000"">"+
                                                    @"<a:schemeClr val=""phClr"">"+
                                                        @"<a:lumMod val=""105000""/>"+
                                                        @"<a:satMod val=""109000""/>"+
                                                        @"<a:tint val=""81000""/>"+
                                                    @"</a:schemeClr>"+
                                                @"</a:gs>"+
                                            @"</a:gsLst>"+
                                            @"<a:lin ang=""5400000"" scaled=""0""/>"+
                                        @"</a:gradFill>"+

                                        @"<a:gradFill rotWithShape=""1"">"+
                                            @"<a:gsLst>"+
                                                @"<a:gs pos=""0"">"+
                                                    @"<a:schemeClr val=""phClr"">"+
                                                        @"<a:satMod val=""103000""/>"+
                                                        @"<a:lumMod val=""102000""/>"+
                                                        @"<a:tint val=""94000""/>"+
                                                    @"</a:schemeClr>"+
                                                @"</a:gs>"+
                                                @"<a:gs pos=""50000"">"+
                                                    @"<a:schemeClr val=""phClr"">"+
                                                        @"<a:satMod val=""110000""/>"+
                                                        @"<a:lumMod val=""100000""/>"+
                                                        @"<a:shade val=""100000""/>"+
                                                    @"</a:schemeClr>"+
                                                @"</a:gs>"+
                                                @"<a:gs pos=""100000"">"+
                                                    @"<a:schemeClr val=""phClr"">"+
                                                        @"<a:lumMod val=""99000""/>"+
                                                        @"<a:satMod val=""120000""/>"+
                                                        @"<a:shade val=""78000""/>"+
                                                    @"</a:schemeClr>"+
                                                @"</a:gs>"+
                                            @"</a:gsLst>"+
                                            @"<a:lin ang=""5400000"" scaled=""0""/>"+
                                        @"</a:gradFill>"+
                                    @"</a:fillStyleLst>"+
                            
                                    @"<a:lnStyleLst>"+
                                        @"<a:ln w=""6350"" cap=""flat"" cmpd=""sng"" algn=""ctr"">"+
                                            @"<a:solidFill>"+
                                                @"<a:schemeClr val=""phClr""/>"+
                                            @"</a:solidFill>"+
                                            @"<a:prstDash val=""solid""/>"+
                                            @"<a:miter lim=""800000""/>"+
                                        @"</a:ln>"+
                                        @"<a:ln w=""12700"" cap=""flat"" cmpd=""sng"" algn=""ctr"">"+
                                            @"<a:solidFill>"+
                                                @"<a:schemeClr val=""phClr""/>"+
                                            @"</a:solidFill>"+
                                            @"<a:prstDash val=""solid""/>"+
                                            @"<a:miter lim=""800000""/>"+
                                        @"</a:ln>"+
                                        @"<a:ln w=""19050"" cap=""flat"" cmpd=""sng"" algn=""ctr"">"+
                                            @"<a:solidFill>"+
                                                @"<a:schemeClr val=""phClr""/>"+
                                            @"</a:solidFill>"+
                                            @"<a:prstDash val=""solid""/>"+
                                            @"<a:miter lim=""800000""/>"+
                                        @"</a:ln>"+
                                    @"</a:lnStyleLst>"+
                                    @"<a:effectStyleLst>"+
                                        @"<a:effectStyle>"+
                                        @"<a:effectLst/>"+
                                        @"</a:effectStyle>"+
                                        @"<a:effectStyle>"+
                                        @"<a:effectLst/>"+
                                        @"</a:effectStyle>"+
                                        @"<a:effectStyle>"+
                                            @"<a:effectLst>"+
                                                @"<a:outerShdw blurRad=""57150"" dist=""19050"" dir=""5400000"" algn=""ctr"" rotWithShape=""0"">"+
                                                    @"<a:srgbClr val=""000000"">"+
                                                        @"<a:alpha val=""63000""/>"+
                                                    @"</a:srgbClr>"+
                                                @"</a:outerShdw>"+
                                            @"</a:effectLst>"+
                                        @"</a:effectStyle>"+
                                    @"</a:effectStyleLst>"+
                                    @"<a:bgFillStyleLst>"+
                                        @"<a:solidFill>"+
                                            @"<a:schemeClr val=""phClr""/>"+
                                            @"</a:solidFill>"+
                                            @"<a:solidFill>"+
                                            @"<a:schemeClr val=""phClr"">"+
                                                @"<a:tint val=""95000""/>"+
                                                @"<a:satMod val=""170000""/>"+
                                            @"</a:schemeClr>"+
                                        @"</a:solidFill>"+
                                        @"<a:gradFill rotWithShape=""1"">"+
                                            @"<a:gsLst>"+
                                                @"<a:gs pos=""0"">"+
                                                    @"<a:schemeClr val=""phClr"">"+
                                                    @"<a:tint val=""93000""/>"+
                                                    @"<a:satMod val=""150000""/>"+
                                                    @"<a:shade val=""98000""/>"+
                                                    @"<a:lumMod val=""102000""/>"+
                                                    @"</a:schemeClr>"+
                                                @"</a:gs>"+
                                                @"<a:gs pos=""50000"">"+
                                                    @"<a:schemeClr val=""phClr"">"+
                                                    @"<a:tint val=""98000""/>"+
                                                    @"<a:satMod val=""130000""/>"+
                                                    @"<a:shade val=""90000""/>"+
                                                    @"<a:lumMod val=""103000""/>"+
                                                    @"</a:schemeClr>"+
                                                @"</a:gs>"+
                                                @"<a:gs pos=""100000"">"+
                                                    @"<a:schemeClr val=""phClr"">"+
                                                    @"<a:shade val=""63000""/>"+
                                                    @"<a:satMod val=""120000""/>"+
                                                    @"</a:schemeClr>"+
                                                @"</a:gs>"+
                                            @"</a:gsLst>"+
                                            @"<a:lin ang=""5400000"" scaled=""0""/>"+
                                        @"</a:gradFill>"+
                                    @"</a:bgFillStyleLst>"+
                                @"</a:fmtScheme>"+
                            @"</a:themeElements>"+
                            @"<a:objectDefaults/>"+
                            @"<a:extraClrSchemeLst/>"+
                            @"<a:extLst>"+
                                @"<a:ext uri=""{05A4C25C-085E-4340-85A3-A5531E510DB2}"">"+
                                    @"<thm15:themeFamily xmlns:thm15=""http://schemas.microsoft.com/office/thememl/2012/main"" name=""Office Theme"" id=""{62F939B6-93AF-4DB8-9C6B-D6C7DFDC589F}"" vid=""{4A3C46E8-61CC-4603-A589-7422A47A8E4A}""/>"+
                                @"</a:ext>"+
                            @"</a:extLst>"+
                        @"</a:theme>");                            
                     }
                }  
                
                // Folder xl\worksheets
                { 
                    Directory.CreateDirectory(DirectoryTMP+"\\xl\\worksheets");

                    // Write xl\\worksheets\\sheet1.xml
                    {
                       File.WriteAllText(DirectoryTMP+"\\xl\\worksheets\\sheet1.xml",
                        @"<?xml version=""1.0"" encoding=""UTF-8"" standalone=""yes""?>"+"\n"+
                        @"<worksheet"+
	                            @"xmlns=""http://schemas.openxmlformats.org/spreadsheetml/2006/main"""+
	                            @"xmlns:r=""http://schemas.openxmlformats.org/officeDocument/2006/relationships"""+
	                            @"xmlns:mc=""http://schemas.openxmlformats.org/markup-compatibility/2006"" mc:Ignorable=""x14ac"""+
	                            @"xmlns:x14ac=""http://schemas.microsoft.com/office/spreadsheetml/2009/9/ac"">"+
                                @"<dimension ref=""A1:"+GetExcelCountingCell(maxColumn,table.Count)+@"""/>"+
                            @"<sheetViews>"+
                                @"<sheetView tabSelected=""1"" workbookViewId=""0""/>"+
                            @"</sheetViews>"+
                                @"<sheetFormatPr defaultRowHeight=""15"" x14ac:dyDescent=""0.25""/>"+
                            @"<cols>"+
                                colData+
                            @"</cols>"+
                                @"<sheetData>"+
                                    celldata+
                                @"</sheetData>"+
                            @"<pageMargins left=""0.78740157499999996"" right=""0.78740157499999996"" top=""0.984251969"" bottom=""0.984251969"" header=""0.4921259845"" footer=""0.4921259845""/>"+
                       @"</worksheet>");                            
                     }
                }
                  
                // create xl\\sharedStrings.xml
                {
                    string head="<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>\r\n<sst\r\n\txmlns=\"http://schemas.openxmlformats.org/spreadsheetml/2006/main\" count=\""+(cellIndex+1)+@""" uniqueCount="""+(cellIndex+1)+@""">";
                    head+=cellStringValues;
                    head+="</sst>";
                    File.WriteAllText(DirectoryTMP+"\\xl\\sharedStrings.xml", head);
                }

                // xl\\styles.xml
                {
                    string fontStyles="";
                    //string fontsCellStyles="";
                    int id=50;
                    foreach (ExcelStyle style in ExcelStyles) { 
                        fontStyles+=style.GenerateFontStyle();
                        fontsCellStyles+=style.GenerateCellStyle(id,id);
                        id++;
                    }

                    File.WriteAllText(DirectoryTMP+"\\xl\\styles.xml",
                        @"<?xml version=""1.0"" encoding=""UTF-8"" standalone=""yes""?>"+"\n"+                       
                        @"<styleSheet xmlns=""http://schemas.openxmlformats.org/spreadsheetml/2006/main"" xmlns:mc=""http://schemas.openxmlformats.org/markup-compatibility/2006"" mc:Ignorable=""x14ac x16r2"" xmlns:x14ac=""http://schemas.microsoft.com/office/spreadsheetml/2009/9/ac"" xmlns:x16r2=""http://schemas.microsoft.com/office/spreadsheetml/2015/02/main"">"+
                            @"<fonts count=""19"" x14ac:knownFonts=""1"">"+
                                @"<font>"+
                                    @"<sz val=""11""/>"+
                                    @"<color theme=""1""/>"+
                                    @"<name val=""Calibri""/>"+
                                    @"<family val=""2""/>"+
                                    @"<charset val=""238""/>"+
                                    @"<scheme val=""minor""/>"+
                                @"</font>"+
                                @"<font>"+
                                    @"<sz val=""11""/>"+
                                    @"<color theme=""1""/>"+
                                    @"<name val=""Calibri""/>"+
                                    @"<family val=""2""/>"+
                                    @"<charset val=""238""/>"+
                                    @"<scheme val=""minor""/>"+
                                @"</font>"+
                                @"<font>"+
                                    @"<sz val=""18""/>"+
                                    @"<color theme=""3""/>"+
                                    @"<name val=""Calibri Light""/>"+
                                    @"<family val=""2""/>"+
                                    @"<charset val=""238""/>"+
                                    @"<scheme val=""major""/>"+
                                @"</font>"+
                                @"<font>"+
                                @"<b/>"+
                                    @"<sz val=""15""/>"+
                                    @"<color theme=""3""/>"+
                                    @"<name val=""Calibri""/>"+
                                    @"<family val=""2""/>"+
                                    @"<charset val=""238""/>"+
                                    @"<scheme val=""minor""/>"+
                                @"</font>"+
                                @"<font>"+
                                @"<b/>"+
                                    @"<sz val=""13""/>"+
                                    @"<color theme=""3""/>"+
                                    @"<name val=""Calibri""/>"+
                                    @"<family val=""2""/>"+
                                    @"<charset val=""238""/>"+
                                    @"<scheme val=""minor""/>"+
                                @"</font>"+
                                @"<font>"+
                                @"<b/>"+
                                    @"<sz val=""11""/>"+
                                    @"<color theme=""3""/>"+
                                    @"<name val=""Calibri""/>"+
                                    @"<family val=""2""/>"+
                                    @"<charset val=""238""/>"+
                                    @"<scheme val=""minor""/>"+
                                @"</font>"+
                                @"<font>"+
                                    @"<sz val=""11""/>"+
                                    @"<color rgb=""FF006100""/>"+
                                    @"<name val=""Calibri""/>"+
                                    @"<family val=""2""/>"+
                                    @"<charset val=""238""/>"+
                                    @"<scheme val=""minor""/>"+
                                @"</font>"+
                                @"<font>"+
                                    @"<sz val=""11""/>"+
                                    @"<color rgb=""FF9C0006""/>"+
                                    @"<name val=""Calibri""/>"+
                                    @"<family val=""2""/>"+
                                    @"<charset val=""238""/>"+
                                    @"<scheme val=""minor""/>"+
                                @"</font>"+
                                @"<font>"+
                                @"<sz val=""11""/>"+
                                    @"<color rgb=""FF9C5700""/>"+
                                    @"<name val=""Calibri""/>"+
                                    @"<family val=""2""/>"+
                                    @"<charset val=""238""/>"+
                                    @"<scheme val=""minor""/>"+
                                @"</font>"+
                                @"<font>"+
                                    @"<sz val=""11""/>"+
                                    @"<color rgb=""FF3F3F76""/>"+
                                    @"<name val=""Calibri""/>"+
                                    @"<family val=""2""/>"+
                                    @"<charset val=""238""/>"+
                                    @"<scheme val=""minor""/>"+
                                @"</font>"+
                                @"<font>"+
                                    @"<b/>"+
                                    @"<sz val=""11""/>"+
                                    @"<color rgb=""FF3F3F3F""/>"+
                                    @"<name val=""Calibri""/>"+
                                    @"<family val=""2""/>"+
                                    @"<charset val=""238""/>"+
                                    @"<scheme val=""minor""/>"+
                                @"</font>"+
                                @"<font>"+
                                    @"<b/>"+
                                    @"<sz val=""11""/>"+
                                    @"<color rgb=""FFFA7D00""/>"+
                                    @"<name val=""Calibri""/>"+
                                    @"<family val=""2""/>"+
                                    @"<charset val=""238""/>"+
                                    @"<scheme val=""minor""/>"+
                                @"</font>"+
                                @"<font>"+
                                    @"<sz val=""11""/>"+
                                    @"<color rgb=""FFFA7D00""/>"+
                                    @"<name val=""Calibri""/>"+
                                    @"<family val=""2""/>"+
                                    @"<charset val=""238""/>"+
                                    @"<scheme val=""minor""/>"+
                                @"</font>"+
                                @"<font>"+
                                    @"<b/>"+
                                    @"<sz val=""11""/>"+
                                    @"<color theme=""0""/>"+
                                    @"<name val=""Calibri""/>"+
                                    @"<family val=""2""/>"+
                                    @"<charset val=""238""/>"+
                                    @"<scheme val=""minor""/>"+
                                @"</font>"+
                                @"<font>"+
                                    @"<sz val=""11""/>"+
                                    @"<color rgb=""FFFF0000""/>"+
                                    @"<name val=""Calibri""/>"+
                                    @"<family val=""2""/>"+
                                    @"<charset val=""238""/>"+
                                    @"<scheme val=""minor""/>"+
                                @"</font>"+
                                @"<font>"+
                                    @"<i/>"+
                                    @"<sz val=""11""/>"+
                                    @"<color rgb=""FF7F7F7F""/>"+
                                    @"<name val=""Calibri""/>"+
                                    @"<family val=""2""/>"+
                                    @"<charset val=""238""/>"+
                                    @"<scheme val=""minor""/>"+
                                @"</font>"+
                                @"<font>"+
                                    @"<b/>"+
                                    @"<sz val=""11""/>"+
                                    @"<color theme=""1""/>"+
                                    @"<name val=""Calibri""/>"+
                                    @"<family val=""2""/>"+
                                    @"<charset val=""238""/>"+
                                    @"<scheme val=""minor""/>"+
                                @"</font>"+
                                @"<font>"+
                                    @"<sz val=""11""/>"+
                                    @"<color theme=""0""/>"+
                                    @"<name val=""Calibri""/>"+
                                    @"<family val=""2""/>"+
                                    @"<charset val=""238""/>"+
                                    @"<scheme val=""minor""/>"+
                                @"</font>"+
                                @"<font>"+
                                    @"<b/>"+
                                    @"<sz val=""10""/>"+
                                    @"<name val=""Arial""/>"+
                                @"</font>"+
                                fontStyles+
                            @"</fonts>"+
                            @"<fills count=""33"">"+
                                @"<fill>"+
                                    @"<patternFill patternType=""none""/>"+
                                @"</fill>"+
                                @"<fill>"+
                                    @"<patternFill patternType=""gray125""/>"+
                                @"</fill>"+
                                @"<fill>"+
                                    @"<patternFill patternType=""solid"">"+
                                        @"<fgColor rgb=""FFC6EFCE""/>"+
                                    @"</patternFill>"+
                                @"</fill>"+
                                @"<fill>"+
                                    @"<patternFill patternType=""solid"">"+
                                        @"<fgColor rgb=""FFFFC7CE""/>"+
                                    @"</patternFill>"+
                                @"</fill>"+
                                @"<fill>"+
                                    @"<patternFill patternType=""solid"">"+
                                        @"<fgColor rgb=""FFFFEB9C""/>"+
                                    @"</patternFill>"+
                                @"</fill>"+
                                @"<fill>"+
                                    @"<patternFill patternType=""solid"">"+
                                        @"<fgColor rgb=""FFFFCC99""/>"+
                                    @"</patternFill>"+
                                @"</fill>"+
                                @"<fill>"+
                                    @"<patternFill patternType=""solid"">"+
                                        @"<fgColor rgb=""FFF2F2F2""/>"+
                                    @"</patternFill>"+
                                @"</fill>"+
                                @"<fill>"+
                                    @"<patternFill patternType=""solid"">"+
                                        @"<fgColor rgb=""FFA5A5A5""/>"+
                                    @"</patternFill>"+
                                @"</fill>"+
                                @"<fill>"+
                                    @"<patternFill patternType=""solid"">"+
                                        @"<fgColor rgb=""FFFFFFCC""/>"+
                                    @"</patternFill>"+
                                @"</fill>"+
                                @"<fill>"+
                                    @"<patternFill patternType=""solid"">"+
                                        @"<fgColor theme=""4""/>"+
                                    @"</patternFill>"+
                                @"</fill>"+
                                @"<fill>"+
                                    @"<patternFill patternType=""solid"">"+
                                        @"<fgColor theme=""4"" tint=""0.79998168889431442""/>"+
                                        @"<bgColor indexed=""65""/>"+
                                    @"</patternFill>"+
                                @"</fill>"+
                                @"<fill>"+
                                    @"<patternFill patternType=""solid"">"+
                                        @"<fgColor theme=""4"" tint=""0.59999389629810485""/>"+
                                        @"<bgColor indexed=""65""/>"+
                                    @"</patternFill>"+
                                @"</fill>"+
                                @"<fill>"+
                                    @"<patternFill patternType=""solid"">"+
                                        @"<fgColor theme=""4"" tint=""0.39997558519241921""/>"+
                                        @"<bgColor indexed=""65""/>"+
                                    @"</patternFill>"+
                                @"</fill>"+
                                @"<fill>"+
                                    @"<patternFill patternType=""solid"">"+
                                        @"<fgColor theme=""5""/>"+
                                    @"</patternFill>"+
                                @"</fill>"+
                                @"<fill>"+
                                    @"<patternFill patternType=""solid"">"+
                                        @"<fgColor theme=""5"" tint=""0.79998168889431442""/>"+
                                        @"<bgColor indexed=""65""/>"+
                                    @"</patternFill>"+
                                @"</fill>"+
                                @"<fill>"+
                                    @"<patternFill patternType=""solid"">"+
                                        @"<fgColor theme=""5"" tint=""0.59999389629810485""/>"+
                                        @"<bgColor indexed=""65""/>"+
                                    @"</patternFill>"+
                                @"</fill>"+
                                @"<fill>"+
                                    @"<patternFill patternType=""solid"">"+
                                        @"<fgColor theme=""5"" tint=""0.39997558519241921""/>"+
                                        @"<bgColor indexed=""65""/>"+
                                    @"</patternFill>"+
                                @"</fill>"+
                                @"<fill>"+
                                    @"<patternFill patternType=""solid"">"+
                                        @"<fgColor theme=""6""/>"+
                                    @"</patternFill>"+
                                @"</fill>"+
                                @"<fill>"+
                                    @"<patternFill patternType=""solid"">"+
                                        @"<fgColor theme=""6"" tint=""0.79998168889431442""/>"+
                                        @"<bgColor indexed=""65""/>"+
                                    @"</patternFill>"+
                                @"</fill>"+
                                @"<fill>"+
                                    @"<patternFill patternType=""solid"">"+
                                        @"<fgColor theme=""6"" tint=""0.59999389629810485""/>"+
                                        @"<bgColor indexed=""65""/>"+
                                    @"</patternFill>"+
                                @"</fill>"+
                                @"<fill>"+
                                    @"<patternFill patternType=""solid"">"+
                                        @"<fgColor theme=""6"" tint=""0.39997558519241921""/>"+
                                        @"<bgColor indexed=""65""/>"+
                                    @"</patternFill>"+
                                @"</fill>"+
                                @"<fill>"+
                                    @"<patternFill patternType=""solid"">"+
                                        @"<fgColor theme=""7""/>"+
                                    @"</patternFill>"+
                                @"</fill>"+
                                @"<fill>"+
                                    @"<patternFill patternType=""solid"">"+
                                        @"<fgColor theme=""7"" tint=""0.79998168889431442""/>"+
                                        @"<bgColor indexed=""65""/>"+
                                    @"</patternFill>"+
                                @"</fill>"+
                                @"<fill>"+
                                    @"<patternFill patternType=""solid"">"+
                                        @"<fgColor theme=""7"" tint=""0.59999389629810485""/>"+
                                        @"<bgColor indexed=""65""/>"+
                                    @"</patternFill>"+
                                @"</fill>"+
                                @"<fill>"+
                                    @"<patternFill patternType=""solid"">"+
                                        @"<fgColor theme=""7"" tint=""0.39997558519241921""/>"+
                                        @"<bgColor indexed=""65""/>"+
                                    @"</patternFill>"+
                                @"</fill>"+
                                @"<fill>"+
                                    @"<patternFill patternType=""solid"">"+
                                        @"<fgColor theme=""8""/>"+
                                    @"</patternFill>"+
                                @"</fill>"+
                                @"<fill>"+
                                    @"<patternFill patternType=""solid"">"+
                                        @"<fgColor theme=""8"" tint=""0.79998168889431442""/>"+
                                        @"<bgColor indexed=""65""/>"+
                                    @"</patternFill>"+
                                @"</fill>"+
                                @"<fill>"+
                                    @"<patternFill patternType=""solid"">"+
                                        @"<fgColor theme=""8"" tint=""0.59999389629810485""/>"+
                                        @"<bgColor indexed=""65""/>"+
                                    @"</patternFill>"+
                                @"</fill>"+
                                @"<fill>"+
                                    @"<patternFill patternType=""solid"">"+
                                        @"<fgColor theme=""8"" tint=""0.39997558519241921""/>"+
                                        @"<bgColor indexed=""65""/>"+
                                    @"</patternFill>"+
                                @"</fill>"+
                                @"<fill>"+
                                    @"<patternFill patternType=""solid"">"+
                                        @"<fgColor theme=""9""/>"+
                                    @"</patternFill>"+
                                @"</fill>"+
                                @"<fill>"+
                                    @"<patternFill patternType=""solid"">"+
                                        @"<fgColor theme=""9"" tint=""0.79998168889431442""/>"+
                                        @"<bgColor indexed=""65""/>"+
                                    @"</patternFill>"+
                                @"</fill>"+
                                @"<fill>"+
                                    @"<patternFill patternType=""solid"">"+
                                        @"<fgColor theme=""9"" tint=""0.59999389629810485""/>"+
                                        @"<bgColor indexed=""65""/>"+
                                    @"</patternFill>"+
                                @"</fill>"+
                                @"<fill>"+
                                    @"<patternFill patternType=""solid"">"+
                                        @"<fgColor theme=""9"" tint=""0.39997558519241921""/>"+
                                        @"<bgColor indexed=""65""/>"+
                                    @"</patternFill>"+
                                @"</fill>"+
                            @"</fills>"+
                            @"<borders count=""10"">"+
                                @"<border>"+
                                    @"<left/>"+
                                    @"<right/>"+
                                    @"<top/>"+
                                    @"<bottom/>"+
                                    @"<diagonal/>"+
                                @"</border>"+
                                @"<border>"+
                                    @"<left/>"+
                                    @"<right/>"+
                                    @"<top/>"+
                                    @"<bottom style=""thick"">"+
                                    @"<color theme=""4""/>"+
                                    @"</bottom>"+
                                    @"<diagonal/>"+
                                @"</border>"+
                                @"<border>"+
                                    @"<left/>"+
                                    @"<right/>"+
                                    @"<top/>"+
                                    @"<bottom style=""thick"">"+
                                    @"<color theme=""4"" tint=""0.499984740745262""/>"+
                                    @"</bottom>"+
                                    @"<diagonal/>"+
                                @"</border>"+
                                @"<border>"+
                                    @"<left/>"+
                                    @"<right/>"+
                                    @"<top/>"+
                                    @"<bottom style=""medium"">"+
                                    @"<color theme=""4"" tint=""0.39997558519241921""/>"+
                                    @"</bottom>"+
                                    @"<diagonal/>"+
                                @"</border>"+
                                @"<border>"+
                                    @"<left style=""thin"">"+
                                    @"<color rgb=""FF7F7F7F""/>"+
                                    @"</left>"+
                                    @"<right style=""thin"">"+
                                    @"<color rgb=""FF7F7F7F""/>"+
                                    @"</right>"+
                                    @"<top style=""thin"">"+
                                    @"<color rgb=""FF7F7F7F""/>"+
                                    @"</top>"+
                                    @"<bottom style=""thin"">"+
                                    @"<color rgb=""FF7F7F7F""/>"+
                                    @"</bottom>"+
                                    @"<diagonal/>"+
                                @"</border>"+
                                @"<border>"+
                                    @"<left style=""thin"">"+
                                    @"<color rgb=""FF3F3F3F""/>"+
                                    @"</left>"+
                                    @"<right style=""thin"">"+
                                    @"<color rgb=""FF3F3F3F""/>"+
                                    @"</right>"+
                                    @"<top style=""thin"">"+
                                    @"<color rgb=""FF3F3F3F""/>"+
                                    @"</top>"+
                                    @"<bottom style=""thin"">"+
                                    @"<color rgb=""FF3F3F3F""/>"+
                                    @"</bottom>"+
                                    @"<diagonal/>"+
                                @"</border>"+
                                @"<border>"+
                                    @"<left/>"+
                                    @"<right/>"+
                                    @"<top/>"+
                                    @"<bottom style=""double"">"+
                                    @"<color rgb=""FFFF8001""/>"+
                                    @"</bottom>"+
                                    @"<diagonal/>"+
                                @"</border>"+
                                @"<border>"+
                                    @"<left style=""double"">"+
                                    @"<color rgb=""FF3F3F3F""/>"+
                                    @"</left>"+
                                    @"<right style=""double"">"+
                                    @"<color rgb=""FF3F3F3F""/>"+
                                    @"</right>"+
                                    @"<top style=""double"">"+
                                    @"<color rgb=""FF3F3F3F""/>"+
                                    @"</top>"+
                                    @"<bottom style=""double"">"+
                                    @"<color rgb=""FF3F3F3F""/>"+
                                    @"</bottom>"+
                                    @"<diagonal/>"+
                                @"</border>"+
                                @"<border>"+
                                    @"<left style=""thin"">"+
                                    @"<color rgb=""FFB2B2B2""/>"+
                                    @"</left>"+
                                    @"<right style=""thin"">"+
                                    @"<color rgb=""FFB2B2B2""/>"+
                                    @"</right>"+
                                    @"<top style=""thin"">"+
                                    @"<color rgb=""FFB2B2B2""/>"+
                                    @"</top>"+
                                    @"<bottom style=""thin"">"+
                                    @"<color rgb=""FFB2B2B2""/>"+
                                    @"</bottom>"+
                                    @"<diagonal/>"+
                                @"</border>"+
                                @"<border>"+
                                    @"<left/>"+
                                    @"<right/>"+
                                    @"<top style=""thin"">"+
                                    @"<color theme=""4""/>"+
                                    @"</top>"+
                                    @"<bottom style=""double"">"+
                                    @"<color theme=""4""/>"+
                                    @"</bottom>"+
                                    @"<diagonal/>"+
                                @"</border>"+
                            @"</borders>"+
                                @"<cellStyleXfs count=""42"">"+
                                    @"<xf numFmtId=""0"" fontId=""0"" fillId=""0"" borderId=""0""/>"+
                                    @"<xf numFmtId=""0"" fontId=""2"" fillId=""0"" borderId=""0"" applyNumberFormat=""0"" applyFill=""0"" applyBorder=""0"" applyAlignment=""0"" applyProtection=""0""/>"+
                                    @"<xf numFmtId=""0"" fontId=""3"" fillId=""0"" borderId=""1"" applyNumberFormat=""0"" applyFill=""0"" applyAlignment=""0"" applyProtection=""0""/>"+
                                    @"<xf numFmtId=""0"" fontId=""4"" fillId=""0"" borderId=""2"" applyNumberFormat=""0"" applyFill=""0"" applyAlignment=""0"" applyProtection=""0""/>"+
                                    @"<xf numFmtId=""0"" fontId=""5"" fillId=""0"" borderId=""3"" applyNumberFormat=""0"" applyFill=""0"" applyAlignment=""0"" applyProtection=""0""/>"+
                                    @"<xf numFmtId=""0"" fontId=""5"" fillId=""0"" borderId=""0"" applyNumberFormat=""0"" applyFill=""0"" applyBorder=""0"" applyAlignment=""0"" applyProtection=""0""/>"+
                                    @"<xf numFmtId=""0"" fontId=""6"" fillId=""2"" borderId=""0"" applyNumberFormat=""0"" applyBorder=""0"" applyAlignment=""0"" applyProtection=""0""/>"+
                                    @"<xf numFmtId=""0"" fontId=""7"" fillId=""3"" borderId=""0"" applyNumberFormat=""0"" applyBorder=""0"" applyAlignment=""0"" applyProtection=""0""/>"+
                                    @"<xf numFmtId=""0"" fontId=""8"" fillId=""4"" borderId=""0"" applyNumberFormat=""0"" applyBorder=""0"" applyAlignment=""0"" applyProtection=""0""/>"+
                                    @"<xf numFmtId=""0"" fontId=""9"" fillId=""5"" borderId=""4"" applyNumberFormat=""0"" applyAlignment=""0"" applyProtection=""0""/>"+
                                    @"<xf numFmtId=""0"" fontId=""10"" fillId=""6"" borderId=""5"" applyNumberFormat=""0"" applyAlignment=""0"" applyProtection=""0""/>"+
                                    @"<xf numFmtId=""0"" fontId=""11"" fillId=""6"" borderId=""4"" applyNumberFormat=""0"" applyAlignment=""0"" applyProtection=""0""/>"+
                                    @"<xf numFmtId=""0"" fontId=""12"" fillId=""0"" borderId=""6"" applyNumberFormat=""0"" applyFill=""0"" applyAlignment=""0"" applyProtection=""0""/>"+
                                    @"<xf numFmtId=""0"" fontId=""13"" fillId=""7"" borderId=""7"" applyNumberFormat=""0"" applyAlignment=""0"" applyProtection=""0""/>"+
                                    @"<xf numFmtId=""0"" fontId=""14"" fillId=""0"" borderId=""0"" applyNumberFormat=""0"" applyFill=""0"" applyBorder=""0"" applyAlignment=""0"" applyProtection=""0""/>"+
                                    @"<xf numFmtId=""0"" fontId=""1"" fillId=""8"" borderId=""8"" applyNumberFormat=""0"" applyFont=""0"" applyAlignment=""0"" applyProtection=""0""/>"+
                                    @"<xf numFmtId=""0"" fontId=""15"" fillId=""0"" borderId=""0"" applyNumberFormat=""0"" applyFill=""0"" applyBorder=""0"" applyAlignment=""0"" applyProtection=""0""/>"+
                                    @"<xf numFmtId=""0"" fontId=""16"" fillId=""0"" borderId=""9"" applyNumberFormat=""0"" applyFill=""0"" applyAlignment=""0"" applyProtection=""0""/>"+
                                    @"<xf numFmtId=""0"" fontId=""17"" fillId=""9"" borderId=""0"" applyNumberFormat=""0"" applyBorder=""0"" applyAlignment=""0"" applyProtection=""0""/>"+
                                    @"<xf numFmtId=""0"" fontId=""1"" fillId=""10"" borderId=""0"" applyNumberFormat=""0"" applyBorder=""0"" applyAlignment=""0"" applyProtection=""0""/>"+
                                    @"<xf numFmtId=""0"" fontId=""1"" fillId=""11"" borderId=""0"" applyNumberFormat=""0"" applyBorder=""0"" applyAlignment=""0"" applyProtection=""0""/>"+
                                    @"<xf numFmtId=""0"" fontId=""1"" fillId=""12"" borderId=""0"" applyNumberFormat=""0"" applyBorder=""0"" applyAlignment=""0"" applyProtection=""0""/>"+
                                    @"<xf numFmtId=""0"" fontId=""17"" fillId=""13"" borderId=""0"" applyNumberFormat=""0"" applyBorder=""0"" applyAlignment=""0"" applyProtection=""0""/>"+
                                    @"<xf numFmtId=""0"" fontId=""1"" fillId=""14"" borderId=""0"" applyNumberFormat=""0"" applyBorder=""0"" applyAlignment=""0"" applyProtection=""0""/>"+
                                    @"<xf numFmtId=""0"" fontId=""1"" fillId=""15"" borderId=""0"" applyNumberFormat=""0"" applyBorder=""0"" applyAlignment=""0"" applyProtection=""0""/>"+
                                    @"<xf numFmtId=""0"" fontId=""1"" fillId=""16"" borderId=""0"" applyNumberFormat=""0"" applyBorder=""0"" applyAlignment=""0"" applyProtection=""0""/>"+
                                    @"<xf numFmtId=""0"" fontId=""17"" fillId=""17"" borderId=""0"" applyNumberFormat=""0"" applyBorder=""0"" applyAlignment=""0"" applyProtection=""0""/>"+
                                    @"<xf numFmtId=""0"" fontId=""1"" fillId=""18"" borderId=""0"" applyNumberFormat=""0"" applyBorder=""0"" applyAlignment=""0"" applyProtection=""0""/>"+
                                    @"<xf numFmtId=""0"" fontId=""1"" fillId=""19"" borderId=""0"" applyNumberFormat=""0"" applyBorder=""0"" applyAlignment=""0"" applyProtection=""0""/>"+
                                    @"<xf numFmtId=""0"" fontId=""1"" fillId=""20"" borderId=""0"" applyNumberFormat=""0"" applyBorder=""0"" applyAlignment=""0"" applyProtection=""0""/>"+
                                    @"<xf numFmtId=""0"" fontId=""17"" fillId=""21"" borderId=""0"" applyNumberFormat=""0"" applyBorder=""0"" applyAlignment=""0"" applyProtection=""0""/>"+
                                    @"<xf numFmtId=""0"" fontId=""1"" fillId=""22"" borderId=""0"" applyNumberFormat=""0"" applyBorder=""0"" applyAlignment=""0"" applyProtection=""0""/>"+
                                    @"<xf numFmtId=""0"" fontId=""1"" fillId=""23"" borderId=""0"" applyNumberFormat=""0"" applyBorder=""0"" applyAlignment=""0"" applyProtection=""0""/>"+
                                    @"<xf numFmtId=""0"" fontId=""1"" fillId=""24"" borderId=""0"" applyNumberFormat=""0"" applyBorder=""0"" applyAlignment=""0"" applyProtection=""0""/>"+
                                    @"<xf numFmtId=""0"" fontId=""17"" fillId=""25"" borderId=""0"" applyNumberFormat=""0"" applyBorder=""0"" applyAlignment=""0"" applyProtection=""0""/>"+
                                    @"<xf numFmtId=""0"" fontId=""1"" fillId=""26"" borderId=""0"" applyNumberFormat=""0"" applyBorder=""0"" applyAlignment=""0"" applyProtection=""0""/>"+
                                    @"<xf numFmtId=""0"" fontId=""1"" fillId=""27"" borderId=""0"" applyNumberFormat=""0"" applyBorder=""0"" applyAlignment=""0"" applyProtection=""0""/>"+
                                    @"<xf numFmtId=""0"" fontId=""1"" fillId=""28"" borderId=""0"" applyNumberFormat=""0"" applyBorder=""0"" applyAlignment=""0"" applyProtection=""0""/>"+
                                    @"<xf numFmtId=""0"" fontId=""17"" fillId=""29"" borderId=""0"" applyNumberFormat=""0"" applyBorder=""0"" applyAlignment=""0"" applyProtection=""0""/>"+
                                    @"<xf numFmtId=""0"" fontId=""1"" fillId=""30"" borderId=""0"" applyNumberFormat=""0"" applyBorder=""0"" applyAlignment=""0"" applyProtection=""0""/>"+
                                    @"<xf numFmtId=""0"" fontId=""1"" fillId=""31"" borderId=""0"" applyNumberFormat=""0"" applyBorder=""0"" applyAlignment=""0"" applyProtection=""0""/>"+
                                    @"<xf numFmtId=""0"" fontId=""1"" fillId=""32"" borderId=""0"" applyNumberFormat=""0"" applyBorder=""0"" applyAlignment=""0"" applyProtection=""0""/>"+
                                @"</cellStyleXfs>"+
                                @"<cellXfs count=""2"">"+
                                    @"<xf numFmtId=""0"" fontId=""0"" fillId=""0"" borderId=""0"" xfId=""0""/>"+
                                    @"<xf numFmtId=""0"" fontId=""18"" fillId=""0"" borderId=""0"" xfId=""0"" applyNumberFormat=""1"" applyFont=""1"" applyFill=""1"" applyBorder=""1"" applyAlignment=""1"" applyProtection=""1""/>"+
                                @"</cellXfs>"+
                                @"<cellStyles count=""42"">"+
                                    @"<cellStyle name=""20 % – Zvýraznění 1"" xfId=""19"" builtinId=""30"" customBuiltin=""1""/>"+
                                    @"<cellStyle name=""20 % – Zvýraznění 2"" xfId=""23"" builtinId=""34"" customBuiltin=""1""/>"+
                                    @"<cellStyle name=""20 % – Zvýraznění 3"" xfId=""27"" builtinId=""38"" customBuiltin=""1""/>"+
                                    @"<cellStyle name=""20 % – Zvýraznění 4"" xfId=""31"" builtinId=""42"" customBuiltin=""1""/>"+
                                    @"<cellStyle name=""20 % – Zvýraznění 5"" xfId=""35"" builtinId=""46"" customBuiltin=""1""/>"+
                                    @"<cellStyle name=""20 % – Zvýraznění 6"" xfId=""39"" builtinId=""50"" customBuiltin=""1""/>"+
                                    @"<cellStyle name=""40 % – Zvýraznění 1"" xfId=""20"" builtinId=""31"" customBuiltin=""1""/>"+
                                    @"<cellStyle name=""40 % – Zvýraznění 2"" xfId=""24"" builtinId=""35"" customBuiltin=""1""/>"+
                                    @"<cellStyle name=""40 % – Zvýraznění 3"" xfId=""28"" builtinId=""39"" customBuiltin=""1""/>"+
                                    @"<cellStyle name=""40 % – Zvýraznění 4"" xfId=""32"" builtinId=""43"" customBuiltin=""1""/>"+
                                    @"<cellStyle name=""40 % – Zvýraznění 5"" xfId=""36"" builtinId=""47"" customBuiltin=""1""/>"+
                                    @"<cellStyle name=""40 % – Zvýraznění 6"" xfId=""40"" builtinId=""51"" customBuiltin=""1""/>"+
                                    @"<cellStyle name=""60 % – Zvýraznění 1"" xfId=""21"" builtinId=""32"" customBuiltin=""1""/>"+
                                    @"<cellStyle name=""60 % – Zvýraznění 2"" xfId=""25"" builtinId=""36"" customBuiltin=""1""/>"+
                                    @"<cellStyle name=""60 % – Zvýraznění 3"" xfId=""29"" builtinId=""40"" customBuiltin=""1""/>"+
                                    @"<cellStyle name=""60 % – Zvýraznění 4"" xfId=""33"" builtinId=""44"" customBuiltin=""1""/>"+
                                    @"<cellStyle name=""60 % – Zvýraznění 5"" xfId=""37"" builtinId=""48"" customBuiltin=""1""/>"+
                                    @"<cellStyle name=""60 % – Zvýraznění 6"" xfId=""41"" builtinId=""52"" customBuiltin=""1""/>"+
                                    @"<cellStyle name=""Celkem"" xfId=""17"" builtinId=""25"" customBuiltin=""1""/>"+
                                    @"<cellStyle name=""Kontrolní buňka"" xfId=""13"" builtinId=""23"" customBuiltin=""1""/>"+
                                    @"<cellStyle name=""Nadpis 1"" xfId=""2"" builtinId=""16"" customBuiltin=""1""/>"+
                                    @"<cellStyle name=""Nadpis 2"" xfId=""3"" builtinId=""17"" customBuiltin=""1""/>"+
                                    @"<cellStyle name=""Nadpis 3"" xfId=""4"" builtinId=""18"" customBuiltin=""1""/>"+
                                    @"<cellStyle name=""Nadpis 4"" xfId=""5"" builtinId=""19"" customBuiltin=""1""/>"+
                                    @"<cellStyle name=""Název"" xfId=""1"" builtinId=""15"" customBuiltin=""1""/>"+
                                    @"<cellStyle name=""Neutrální"" xfId=""8"" builtinId=""28"" customBuiltin=""1""/>"+
                                    @"<cellStyle name=""Normální"" xfId=""0"" builtinId=""0""/>"+
                                    @"<cellStyle name=""Poznámka"" xfId=""15"" builtinId=""10"" customBuiltin=""1""/>"+
                                    @"<cellStyle name=""Propojená buňka"" xfId=""12"" builtinId=""24"" customBuiltin=""1""/>"+
                                    @"<cellStyle name=""Správně"" xfId=""6"" builtinId=""26"" customBuiltin=""1""/>"+
                                    @"<cellStyle name=""Špatně"" xfId=""7"" builtinId=""27"" customBuiltin=""1""/>"+
                                    @"<cellStyle name=""Text upozornění"" xfId=""14"" builtinId=""11"" customBuiltin=""1""/>"+
                                    @"<cellStyle name=""Vstup"" xfId=""9"" builtinId=""20"" customBuiltin=""1""/>"+
                                    @"<cellStyle name=""Výpočet"" xfId=""11"" builtinId=""22"" customBuiltin=""1""/>"+
                                    @"<cellStyle name=""Výstup"" xfId=""10"" builtinId=""21"" customBuiltin=""1""/>"+
                                    @"<cellStyle name=""Vysvětlující text"" xfId=""16"" builtinId=""53"" customBuiltin=""1""/>"+
                                    @"<cellStyle name=""Zvýraznění 1"" xfId=""18"" builtinId=""29"" customBuiltin=""1""/>"+
                                    @"<cellStyle name=""Zvýraznění 2"" xfId=""22"" builtinId=""33"" customBuiltin=""1""/>"+
                                    @"<cellStyle name=""Zvýraznění 3"" xfId=""26"" builtinId=""37"" customBuiltin=""1""/>"+
                                    @"<cellStyle name=""Zvýraznění 4"" xfId=""30"" builtinId=""41"" customBuiltin=""1""/>"+
                                    @"<cellStyle name=""Zvýraznění 5"" xfId=""34"" builtinId=""45"" customBuiltin=""1""/>"+
                                    @"<cellStyle name=""Zvýraznění 6"" xfId=""38"" builtinId=""49"" customBuiltin=""1""/>"+
                                    fontsCellStyles+    
                                @"</cellStyles>"+
                                @"<dxfs count=""0""/>"+
                                @"<tableStyles count=""0"" defaultTableStyle=""TableStyleMedium2"" defaultPivotStyle=""PivotStyleLight16""/>"+
                                @"<extLst>"+
                                    @"<ext uri=""{EB79DEF2-80B8-43e5-95BD-54CBDDF9020C}"" xmlns:x14=""http://schemas.microsoft.com/office/spreadsheetml/2009/9/main"">"+
                                        @"<x14:slicerStyles defaultSlicerStyle=""SlicerStyleLight1""/>"+
                                    @"</ext>"+
                                @"<ext uri=""{9260A510-F301-46a8-8635-F512D64BE5F5}"" xmlns:x15=""http://schemas.microsoft.com/office/spreadsheetml/2010/11/main"">"+
                                    @"<x15:timelineStyles defaultTimelineStyle=""TimeSlicerStyleLight1""/>"+
                                @"</ext>"+
                            @"</extLst>"+
                        @"</styleSheet>");
                }

                // xl\\workbook.xml
                { 
                    File.WriteAllText(DirectoryTMP+"\\xl\\workbook.xml",
                        @"<?xml version=""1.0"" encoding=""UTF-8"" standalone=""yes""?>"+"\n"+
                        "<workbook xmlns=\"http://schemas.openxmlformats.org/spreadsheetml/2006/main\" xmlns:r=\"http://schemas.openxmlformats.org/officeDocument/2006/relationships\">"+
                            //"<fileVersion appName=\"xl\" lastEdited=\"7\" lowestEdited=\"7\" rupBuild=\"25601\"/>"+
                            //"<workbookPr defaultThemeVersion=\"166925\"/>"+
                            //"<mc:AlternateContent xmlns:mc=\"http://schemas.openxmlformats.org/markup-compatibility/2006\">"+
                            //    "<mc:Choice Requires=\"x15\">"+
                            //        "<x15ac:absPath url=\"C:\\\" xmlns:x15ac=\"http://schemas.microsoft.com/office/spreadsheetml/2010/11/ac\"/>"+
                            //    "</mc:Choice>"+
                            //"</mc:AlternateContent>"+
                       //     "<xr:revisionPtr revIDLastSave=\"0\" documentId=\"8_{0A96C2FF-A72D-40FF-813D-6F8521D5C38C}\" xr6:coauthVersionLast=\"47\" xr6:coauthVersionMax=\"47\" xr10:uidLastSave=\"{00000000-0000-0000-0000-000000000000}\"/>"+
                            "<bookViews>"+
                                "<workbookView/>"+
                             //   "<workbookView xWindow=\"5430\" yWindow=\"0\" windowWidth=\"14400\" windowHeight=\"15600\"/>"+
                            "</bookViews>"+
                            "<sheets>"+
                                "<sheet name=\""+Sheet.Name+"\" sheetId=\"1\" r:id=\"rId1\"/>"+
                            "</sheets>"+
                           // "<calcPr calcId=\"0\"/>"+
                        "</workbook>");
                }


                //// Write file docProps\\core.xml
                //{
                //    string edited=now.ToString("yyyy-MM-dd\'T\'HH:mm:ss.SSS\'Z\'");
                //    File.WriteAllText(DirectoryTMP+"\\docProps\\core.xml",
                //    @"<?xml version=""1.0"" encoding=""UTF-8"" standalone=""yes""?>"+"\n"+
                //    @"<cp:coreProperties xmlns:cp=""http://schemas.openxmlformats.org/package/2006/metadata/core-properties"" xmlns:dc=""http://purl.org/dc/elements/1.1/"" xmlns:dcterms=""http://purl.org/dc/terms/"" xmlns:dcmitype=""http://purl.org/dc/dcmitype/"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance""><dc:creator>"+Author+@"</dc:creator><cp:lastModifiedBy>-</cp:lastModifiedBy><dcterms:created xsi:type=""dcterms:W3CDTF"">"+edited+@"</dcterms:created><dcterms:modified xsi:type=""dcterms:W3CDTF"">""+edited+@""</dcterms:modified></cp:coreProperties>");
                //}

                //[Content_Types].xml
                { 
                    File.WriteAllText(DirectoryTMP+"\\[Content_Types].xml",
                    @"<?xml version=""1.0"" encoding=""UTF-8""?>"+"\n"+
                    @"<Types xmlns=""http://schemas.openxmlformats.org/package/2006/content-types""><Default Extension=""rels"" ContentType=""application/vnd.openxmlformats-package.relationships+xml"" /><Default Extension=""xml"" ContentType=""application/xml"" /><Override PartName=""/docProps/app.xml"" ContentType=""application/vnd.openxmlformats-officedocument.extended-properties+xml"" /><Override PartName=""/docProps/core.xml"" ContentType=""application/vnd.openxmlformats-package.core-properties+xml"" /><Override PartName=""/docProps/custom.xml"" ContentType=""application/vnd.openxmlformats-officedocument.custom-properties+xml"" /><Override PartName=""/xl/sharedStrings.xml"" ContentType=""application/vnd.openxmlformats-officedocument.spreadsheetml.sharedStrings+xml"" /><Override PartName=""/xl/styles.xml"" ContentType=""application/vnd.openxmlformats-officedocument.spreadsheetml.styles+xml"" /><Override PartName=""/xl/workbook.xml"" ContentType=""application/vnd.openxmlformats-officedocument.spreadsheetml.sheet.main+xml"" /><Override PartName=""/xl/worksheets/sheet1.xml"" ContentType=""application/vnd.openxmlformats-officedocument.spreadsheetml.worksheet+xml"" /></Types>");
                }
            }

            //            <?xml version="1.0" encoding="UTF-8" standalone="yes"?>
            //<styleSheet
            //	xmlns="http://schemas.openxmlformats.org/spreadsheetml/2006/main"
            //	xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006" mc:Ignorable="x14ac x16r2"
            //	xmlns:x14ac="http://schemas.microsoft.com/office/spreadsheetml/2009/9/ac"
            //	xmlns:x16r2="http://schemas.microsoft.com/office/spreadsheetml/2015/02/main">
            //	<fonts count="19" x14ac:knownFonts="1">

            // Delete if exists
            if (File.Exists(path)) File.Delete(path);

            // Create zip
            System.IO.Compression.ZipFile.CreateFromDirectory(DirectoryTMP, path);

            // Delete folder
         //   Directory.Delete(DirectoryTMP,true);
            Debug.WriteLine(DirectoryTMP);
            // rename .xmls
            //File.Rename();

        }

        static string GetExcelCountingCell(int posX, int posY) { 
            return ToABCCounting(posX)+posY;

            /*static*/ string ToABCCounting(int pos) { 
                string letters= "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                if (pos<0) throw new Exception("pos is smaller than zero");
                if (pos<letters.Length) return letters[pos].ToString();

                #if DEBUG
                throw new Exception("pos is bigger than expected");
                #else
                return "AA";
                #endif
            }
        }
    }
}

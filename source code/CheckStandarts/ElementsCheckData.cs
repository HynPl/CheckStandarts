using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit.UI;
using CarlosAg.ExcelXmlWriter;
using System;
using System.Collections.Generic;

namespace CheckStandarts {
    static class ElementsCheckData {

        public static List<CheckObject> ElementChecks; 
        static ICollection<ElementId> stairsIds;

        public delegate void EventHandlerProgress(object sender, EventProgress e);
        public static event EventHandlerProgress Progress;

        static readonly bool First=false;

        public const string HeaderStyle="Header Style";

        public static void Init() { 
            ElementChecks = new List<CheckObject>();           
        }

        public static void PreCheck() {  
            UIApplication uiapp=Command.uiApp;
            UIDocument activeDoc = uiapp.ActiveUIDocument;
            Document doc = activeDoc.Document;
                  
            FilteredElementCollector collector = new FilteredElementCollector(doc);
            stairsIds=collector.WhereElementIsNotElementType().OfCategory(BuiltInCategory.OST_Stairs).ToElementIds();
        }       

        public static void RunCheck() {
            if (!First) Save();
            ElementChecks.Clear();
            int total=stairsIds.Count; 
            
            UIApplication uiapp=Command.uiApp;
            UIDocument activeDoc = uiapp.ActiveUIDocument;
            Document doc = activeDoc.Document;
      
            foreach (ElementId stairId in stairsIds) {
                if (Stairs.IsByComponent(doc, stairId) == true) {
                    Stairs s=doc.GetElement(stairId) as Stairs;                 
                    ElementCheckStairs stairs=new ElementCheckStairs(s);

                    // Can be Separated
                    stairs.Calculate();
                    stairs.Check();

                    ElementChecks.Add(stairs);

                    // Send progress
                    Progress.Invoke(null, new EventProgress(ElementChecks.Count/(float)total));
                }
            }
        }

        public static void Save(){
            //Schema schema = Schema.Lookup(guid);

            //if (null == schema) {
            //    SchemaBuilder schemaBuilder = new SchemaBuilder(SchemaGuid);
                
            //    // Allow anyone to read the object
            //    schemaBuilder.SetReadAccessLevel(AccessLevel.Public);

            //    // Restrict writing to this vendor only
            //    schemaBuilder.SetWriteAccessLevel(AccessLevel.Vendor);

            //    // Required because of restricted write-access
            //    schemaBuilder.SetVendorId("TBC_");
                        
            //    // Create a field to store an XYZ
            //    FieldBuilder fieldBuilder = schemaBuilder.AddSimpleField("WireSpliceLocation", typeof(XYZ));
            //  //  fieldBuilder.SetUnitType(UnitType.UT_Length);          
            //    fieldBuilder.SetDocumentation("A stored location value representing a wiring splice in a wall.");
            //    schemaBuilder.SetSchemaName("WireSpliceLocation");

            //    // Register the schema
            //    schema = schemaBuilder.Finish();
            //}

            //UIApplication uiapp=Command.uiApp;
            //UIDocument activeDoc = uiapp.ActiveUIDocument;
            //Document doc =activeDoc.Document;
            //if (doc.IsDetached) { 
            //    string path = doc.PathName;
            //    string filePath=path+"-check.chbd";

            //    List<byte> bytes=new List<byte>();
                foreach (CheckObject e in ElementChecks) { 
                  //  bytes.AddRange(e.SaveOptions());
                    e.Save();
                }
            //    File.WriteAllBytes(filePath, bytes.ToArray());
            //}
        }

        //public static void Load() { 
            //UIApplication uiapp=Command.uiApp;
            //UIDocument activeDoc = uiapp.ActiveUIDocument;
            //Document doc =activeDoc.Document;
            //if (doc.IsDetached) { 
            //    string path = doc.PathName;
            //    string filePath=path+"-check.chbd";

            //    if (File.Exists(filePath)) {                
            //        byte[] bytes=File.ReadAllBytes(filePath);
            //        int pos=0;

            //        while (pos<bytes.Length) { 
            //            // struct: Id [len of body] [body bytes]
            //            // bytes:  4       1         len of body
            //            int id=BitConverter.ToInt32(bytes, pos);
            //            pos+=4;

            //            int len = bytes[pos];
            //            pos++;

            //            byte[] bytesBody=new byte[len];
            //            Array.Copy(bytes, pos, bytesBody, 0, len);
            //            pos+=len;

            //            bool found=false;
            //            foreach (CheckObject o in ElementChecks) { 
            //                if (o.ObjectId==id) {
            //                    o.LoadOptions(bytesBody);
            //                    found=true;
            //                    break;
            //                }    
            //            }
            //            if (!found) { 
            //               // object was removed, do nothing
            //            }
            //        }
            //    }
            //}
     //  }

        public static void Export(string path) {         
            int pos=0;

            Workbook xlsWorkbook = new Workbook();
           // xlsWorkbook..Author = Command.doc.Document.ProjectInformation.Author;
            Worksheet sheet = xlsWorkbook.Worksheets.Add("exported");

            // Add some styles to the Workbook
            WorksheetStyle style = xlsWorkbook.Styles.Add(HeaderStyle);
            style.Font.Bold = true;

            // Create the Default Style to use for everyone
         //   style = xlsWorkbook.Styles.Add("Default");
            
            WorksheetRow row =  sheet.Table.Rows.Add();           
            row.Cells.Add(new WorksheetCell(Setting.Lang.ExportHeader, HeaderStyle));
          //  sheet.SetCellValue(pos, 0, Setting.Lang.ExportHeader);
          //  sheet.GetCellAt(pos, 0).Style.Font.Bold = true; 
            sheet.Table.Columns[0].Width=sheet.Table.Columns[0].Width*3;
          //  sheet.Columns[0].Width=sheet.Columns[0].Width*3;
            pos++;

            // Generate
            if (ElementChecks.Count==0){ 
              //  sheet.SetCellValue(pos, 0, Setting.Lang.NotFound);

                sheet.Table.Rows[pos].Cells[0]=new WorksheetCell(Setting.Lang.NotFound);
                //pos++;
            }else{
                foreach (CheckObject e in ElementChecks) { 
                    e.GenerateExcel(sheet, ref pos);
                    pos++;
                }
            }

            // Save
            DateTime now=DateTime.Now;
            string filename="Revit Export Check "+now.Year+" "+now.Day+"."+now.Month+".";
            
             
            xlsWorkbook.Save(path+"\\"+filename+".xlsx");
        }

        public static string GetStatus(ref int ok, ref int warling, ref int wrong) { 
            int count=0;
            if (ElementChecks!=null) count=ElementChecks.Count;
            else  if (stairsIds!=null) count=stairsIds.Count;

            string stats="";
            if (count==0) stats+=Setting.Lang.NotFound;
            else if (count==1) stats+=Setting.Lang.FoundOne;
            else if (count==2) stats+=Setting.Lang.FoundTwo;
            else if (count==3) stats+=Setting.Lang.FoundThree;
            else if (count==4) stats+=Setting.Lang.FoundFour;
            else stats+=Setting.Lang.FoundX.Replace("?", count.ToString());

           // int ok, warling=0, wrong=0;

            foreach (CheckObject ch in ElementChecks) { 
                ch.GetStats(ref ok, ref warling, ref wrong);  
                ch.Worst= wrong>0? GCheckState.State.Wrong: warling>0 ? GCheckState.State.Warling : GCheckState.State.OK;
            }

            return stats;
        }

       
    }

    //internal class LoadData{ 
    //    public int Id;
    //    public byte[] DataBody;
    //}    
    
    class EventProgress :EventArgs{ 
        public float Progress;

        public EventProgress(float progress) {
            Progress = progress;
        }
    }
}

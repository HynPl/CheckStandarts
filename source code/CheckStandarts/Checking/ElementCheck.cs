using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit.DB.ExtensibleStorage;
using PicoXLSX;
using System;
using System.Collections.Generic;
using System.Globalization;
using Parameter = Autodesk.Revit.DB.Parameter;

namespace CheckStandarts {
    
    // Jedna zkoumaná vlastnost u objektu 
    public class ElementCheck {
        public string Name;
        public string Value;
        public string Message;
        public CheckState State;

        public void GenerateExcel(Worksheet worksheet, ref int pos) {
            //worksheet.Table.Rows[pos].Cells[0] = new WorksheetCell(Name);
            //worksheet.Table.Rows[pos].Cells[1] = new WorksheetCell(Value);

            string value = "";
            switch (State) {
                case CheckState.OK:
                    value = "✔️";
                    break;

                case CheckState.Wrong:
                    value = "❌";
                    break;

                case CheckState.Warling:
                    value = "⚠️";
                    break;

                case CheckState.Unknown:
                    value = "?";
                    break;
            }
            worksheet.AddCell(Name,0,pos);
            worksheet.AddCell(Value,1,pos);
            worksheet.AddCell(value,2,pos);
            //  WorksheetRow row =  worksheet.Table.Rows.Add();  
            //row.Cells.Add(new WorksheetCell(Name));
            //row.Cells.Add(new WorksheetCell(Value));
            //row.Cells.Add(new WorksheetCell(value));

            //worksheet.Table.Rows[pos].Cells[2] = new WorksheetCell(value);
        }

        public void SetError(string message, string value) {
            Message = message;
            Value = value;
            State = CheckState.Wrong;
        }

        public void SetWarling(string message, string value) {
            Message = message;
            Value = value;
            State = CheckState.Warling;
        }

        public void SetOK(string message, string value) {
            Message = message;
            Value = value;
            State = CheckState.OK;
        }

        internal GCheckState.State GetState() {
            if (State == CheckState.OK)
                return GCheckState.State.OK;
            if (State == CheckState.Warling)
                return GCheckState.State.Warling;
            if (State == CheckState.Wrong)
                return GCheckState.State.Wrong;

            // Set default as warling, something missing in cheching?
            return GCheckState.State.Warling;
        }

        public void GetStats(ref int ok, ref int warling, ref int wrong) {
            switch (State) {
                case CheckState.OK:
                    ok++;
                    break;

                case CheckState.Warling:
                    warling++;
                    break;

                case CheckState.Wrong:
                    wrong++;
                    break;

                case CheckState.Unknown:
                    warling++;
                    break;
            }
        }
    }

    // Zkoumaný objekt
    public abstract class CheckObject {
        // UI
        public bool Ignored;
        internal bool ShowButton;
        internal bool InvidualSelect;
        public GCheckState.State Worst;
        public List<ElementCheck> CheckingValues;

        // Select option
        internal int SelectedIndex;
        internal virtual string[] SelectStrings(){ return new string[0]; }

        // Element
        public ElementId ElementId;
        internal static Guid SchemaGuid;
        internal string dataSavingName = "CheckApiRevitData_" + Setting.Version.Replace('.', '_');

        abstract public void Save();

        abstract public void Load();

        abstract public void Check();

        abstract public void GenerateExcel(Worksheet worksheet, ref int pos);

        abstract public void GetStats(ref int ok, ref int warling, ref int wrong);

        abstract public string GetInfo();
    }

    public class ElementCheckStairs : CheckObject {
        public Bezbarier Accessibility;
        public TypeBuilding stairsFor{
            get => (TypeBuilding)SelectedIndex; 
        }

        public TypeBuilding TypeBuilding {
            get {
                if (stairsFor <= 0) return Setting.DefBuildingType;
                return stairsFor;
            }
        }

        public Stairs Stairs;
        public ElementCheck ELehman;
        public ElementCheck EStairsWidth;
        public ElementCheck EStairsAngle;
        public ElementCheck EStairsHeight;
        public List<ElementCheckStairsRuns> Runs;

        public double StairHeight, StairWidth, StairLehman, StairsAngle;

        internal override string[] SelectStrings() => new string[]{ Setting.Lang.DefaultBuilding, Setting.Lang.FamilyHouse, Setting.Lang.Apartement, Setting.Lang.InsideApartement, Setting.Lang.Administrative, Setting.Lang.Technic, Setting.Lang.Exterier };

        public ElementCheckStairs(Stairs stairs) {
            SchemaGuid = new Guid("f30bf276-c4f5-4145-9674-8ac5414cc2de");
            Stairs = stairs;
            ElementId = stairs.Id;

            ShowButton=true;
            InvidualSelect=true;

            CheckingValues=new List<ElementCheck>{
                (ELehman = new ElementCheck()       { Name = Setting.Lang.StairLehman   }),
                (EStairsWidth = new ElementCheck()  { Name = Setting.Lang.StairDepth    }),
                (EStairsAngle = new ElementCheck()  { Name = Setting.Lang.StairAngle    }),
                (EStairsHeight = new ElementCheck() { Name = Setting.Lang.StairHeight   }),
            };
            Runs = new List<ElementCheckStairsRuns>();

            ICollection<ElementId> runs = stairs.GetStairsRuns();
            foreach (ElementId itemRun in runs) {
                StairsRun r = Command.doc.Document.GetElement(itemRun) as StairsRun;
                ElementCheckStairsRuns run = new ElementCheckStairsRuns(r);
                run.Calculate(TypeBuilding);
                run.Check();
                Runs.Add(run);
            }

            Load();
        }

        public override string GetInfo() {
            Parameter pTypeMark = Stairs.get_Parameter(BuiltInParameter.ALL_MODEL_TYPE_MARK);
            string typeMark = pTypeMark == null ? "" : pTypeMark.AsString();

            Parameter pLevel = Stairs.get_Parameter(BuiltInParameter.STAIRS_BASE_LEVEL_PARAM);
            Level level = Command.doc.Document.GetElement(pLevel.AsElementId()) as Level;

            string ret = Setting.Lang.Stairs+" - ";
            if (typeMark != "") ret += " " + Setting.Lang.TypeMark + ": " + typeMark;
            return ret + " " + Setting.Lang.Level + ": " + level.Name;
        }

        public override void GenerateExcel(Worksheet worksheet, ref int pos) {
            Parameter pTypeMark = Stairs.get_Parameter(BuiltInParameter.ALL_MODEL_TYPE_MARK);
            string typeMark = pTypeMark == null ? "" : pTypeMark.AsString();

            Parameter pLevel = Stairs.get_Parameter(BuiltInParameter.STAIRS_BASE_LEVEL_PARAM);
            Level level = Command.doc.Document.GetElement(pLevel.AsElementId()) as Level;

            string info = "(" + Setting.Lang.Using + ": " + TypeBuilding.ToString() + ", " + Setting.Lang.Level + ": '" + level.Name;
            if (typeMark != "") info += "', " + Setting.Lang.TypeMark + ": '" + typeMark + "'";

            worksheet.AddCell(Setting.Lang.Stairs,0,pos, ElementsCheckData.HeaderStyle);
            worksheet.AddCell(info + ")",1,pos);
            pos++;

            ELehman.GenerateExcel(worksheet, ref pos);
            pos++;

            EStairsWidth.GenerateExcel(worksheet, ref pos);
            pos++;

            EStairsAngle.GenerateExcel(worksheet, ref pos);
            pos++;

            EStairsHeight.GenerateExcel(worksheet, ref pos);
            pos++;

            foreach (ElementCheckStairsRuns run in Runs) {
                run.GenerateExcel(worksheet, ref pos);
            }
        }

        public override void Save() {
            // Create byte data
            List<byte> bytes = new List<byte> {
                (byte)Accessibility,
                (byte)SelectedIndex
            };

            // Find schema
            Schema schema = Schema.Lookup(SchemaGuid);
            if (schema == null) {
                schema = CreateSchema();
            }

            // Create an entity (object) for this schema (class)
            Entity entity = new Entity(schema);

            string data = Convert.ToBase64String(bytes.ToArray());
            // Console.WriteLine("Saved: "+data);
            entity.Set(dataSavingName, data);

            // Store the entity on the element
            Stairs.SetEntity(entity);
        }

        public override void Load() {
            Schema schema = Schema.Lookup(SchemaGuid);
            if (schema != null) {
                Entity retrievedEntity = Stairs.GetEntity(schema);
                if (retrievedEntity.IsValidObject) {
                    Field field=schema.GetField(dataSavingName);
                    string retrievedData = retrievedEntity.Get<string>(field);
                    //    Console.WriteLine("Loaded: "+retrievedData);
                    byte[] bytes = Convert.FromBase64String(retrievedData);
                    if (bytes.Length == 2) {
                        Accessibility = (Bezbarier)bytes[0];
                       // stairsFor = (TypeBuilding)bytes[1];
                        SelectedIndex = bytes[1];
                    }
                }
            }
        }

        Schema CreateSchema() {
            SchemaBuilder schemaBuilder = new SchemaBuilder(SchemaGuid);

            // Allow anyone to read the object
            schemaBuilder.SetReadAccessLevel(AccessLevel.Public);

            // Restrict writing to this vendor only
            schemaBuilder.SetWriteAccessLevel(AccessLevel.Public);

            // Required because of restricted write-access

            //var appGuid = Assembly.GetExecutingAssembly().GetCustomAttribute<GuidAttribute>().Value;

            //schemaBuilder.SetVendorId("Check Standarts");
            //   schemaBuilder.SetApplicationGUID(new Guid(appGuid));

            // Create a field to store an XYZ
            FieldBuilder fieldBuilder = schemaBuilder.AddSimpleField(dataSavingName, typeof(string));
            //  fieldBuilder.SetUnitType(UnitType.UT_Length);
            //      fieldBuilder.SetSpec(UnitTypeId.Custom);
            fieldBuilder.SetDocumentation("Check api revit byte data for custom definition using type");
            schemaBuilder.SetSchemaName(dataSavingName);

            // Register the schema
            Schema schema = schemaBuilder.Finish();

            return schema;
        }

        //public Level GetStairsLevel() {               
        //    Parameter pLevel = Ramp.get_Parameter(BuiltInParameter.STAIRS_BASE_LEVEL_PARAM);
        //    return document.GetElement(pLevel.AsElementId()) as Level;
        //}

        //public string GetStairsType() {   
        //    Parameter pTypeMark=Ramp.get_Parameter(BuiltInParameter.ALL_MODEL_TYPE_MARK);  
        //    return pTypeMark==null? "":pTypeMark.AsString(); 
        //}

        public void Calculate() {
            StairHeight = ClassUnitHelper.ConvertToMilimeters(Stairs.ActualRiserHeight);
            StairWidth = ClassUnitHelper.ConvertToMilimeters(Stairs.ActualTreadDepth);
            StairLehman = (StairWidth + StairHeight * 2);
            StairsAngle = Math.Atan(StairHeight / StairWidth) * 180 / Math.PI;
        }

        public override void Check() {
            // Sklon schodu
            if (TypeBuilding == TypeBuilding.FamilyHouse || TypeBuilding == TypeBuilding.InsideApartment) {
                // schodišť uvnitř bytů s konstrukční výškou menší než 3000mm a u schodišť do sklepů a na půdu je možno sklon zvýšit na 41°.
                if (StairHeight < 3000) {
                    if (StairsAngle > 41) EStairsAngle.SetError(Setting.LangMessages.StairsAngle, StairsAngle.ToString("0,0") + "°");
                    else  EStairsAngle.SetOK(Setting.LangMessages.StairsAngle, StairsAngle.ToString("0,0") + "°");
                } else {
                    if (StairsAngle > 35) EStairsAngle.SetError(Setting.LangMessages.StairsAngle, StairsAngle.ToString("0,0") + "°");
                    else if (StairsAngle < 25) EStairsAngle.SetError(Setting.LangMessages.StairsAngle, StairsAngle.ToString("0,0") + "°");
                    else  EStairsAngle.SetOK(Setting.LangMessages.StairsAngle, StairsAngle.ToString("0,0") + "°");
                }
            } else if (TypeBuilding == TypeBuilding.ApartmentBuildingWithoutElevator) {
                // ČSN 73 4130 Schodiště a šikmé rampy – Základní požadavky. „6.1.1 Sklon schodišťových ramen v bytových domech, uvnitř prostorů určených ke shromažďování osob a únikových schodišť by měl být v rozmezí 25°< α ≤ 35°.
                if (StairsAngle > 35) EStairsAngle.SetError(Setting.LangMessages.StairsAngle, StairsAngle.ToString("0,0") + "°");
                else if (StairsAngle < 25) EStairsAngle.SetError(Setting.LangMessages.StairsAngle, StairsAngle.ToString("0,0") + "°");
                else  EStairsAngle.SetOK(Setting.LangMessages.StairsAngle, StairsAngle.ToString("0,0") + "°");
            } else if (TypeBuilding == TypeBuilding.TechnicStairs) {
                if (Setting.BuildingLocation==BuildingLocation.Prague) {
                    // Do prostor určených pro občasné používání omezeným počtem osob lze navrhnout žebříkové schodiště, jehož šířka musí být nejméně 0,55 m.
                    if (StairsAngle > 58) EStairsAngle.SetError(Setting.LangMessages.StairsAngle, StairsAngle.ToString("0,0") + "°");
                    else  EStairsAngle.SetOK(Setting.LangMessages.StairsAngle, StairsAngle.ToString("0,0") + "°");
                } else { 
                    // schodišť uvnitř bytů s konstrukční výškou menší než 3000mm a u schodišť do sklepů a na půdu je možno sklon zvýšit na 41°.
                    if (StairsAngle > 41) EStairsAngle.SetError(Setting.LangMessages.StairsAngle, StairsAngle.ToString("0,0") + "°");
                    else  EStairsAngle.SetOK(Setting.LangMessages.StairsAngle, StairsAngle.ToString("0,0") + "°");
                }
            } else if (TypeBuilding == TypeBuilding.Administrative || TypeBuilding == TypeBuilding.ApartmentBuildingWithElevator || Accessibility == Bezbarier.Bezbarier) {
                // sklon schodišťového ramene nesmí být větší než 28 ° a výška schodišťového stupně větší než 160 mm; to neplatí pro bytové domy,
                if (StairsAngle > 28) EStairsAngle.SetError(Setting.LangMessages.StairsAngle, StairsAngle.ToString("0,0") + "°");
                else   EStairsAngle.SetOK(Setting.LangMessages.StairsAngle, StairsAngle.ToString("0,0") + "°");
            } else if (TypeBuilding==TypeBuilding.Exterier) {
                if (StairsAngle > 35) EStairsAngle.SetError(Setting.LangMessages.StairsAngle, StairsAngle.ToString("0,0") + "°");
                else if (StairsAngle < 25) EStairsAngle.SetError(Setting.LangMessages.StairsAngle, StairsAngle.ToString("0,0") + "°");
                else  EStairsAngle.SetOK(Setting.LangMessages.StairsAngle, StairsAngle.ToString("0,0") + "°");
            } else {
                #if DEBUG
                throw new Exception("Missing category"); 
                #else
                EStairsAngle.SetOK(Setting.LangMessages.StairsAngle, StairsAngle + "°");
                #endif
            }

            // Lehman
            // • vzájemný vztah mezi výškou h a šířkou b v mm schodišťového stupně musí být 2h + b = 630 mm (600 až 650mm).
            if (StairLehman < 600) ELehman.SetError(Setting.LangMessages.StairsLehmanMessage, StairLehman.ToString("0,0") + "mm");
            else if (StairLehman < 610) ELehman.SetWarling(Setting.LangMessages.StairsLehmanMessage, StairLehman.ToString("0,0") + "mm");
            else if (StairLehman > 650) ELehman.SetError(Setting.LangMessages.StairsLehmanMessage, StairLehman.ToString("0,0") + "mm");
            else  ELehman.SetOK(Setting.LangMessages.StairsLehmanMessage, StairLehman.ToString("0,0") + "mm");

            //width
            //U bezbariérových staveb musí šířka stupně dosahovat alespoň hodnoty 310 mm, výška nesmí překročit 160 mm. 
            if (Accessibility == Bezbarier.Bezbarier) {
                if (StairWidth < 310) EStairsWidth.SetError(Setting.LangMessages.StairsWidthMessage, StairWidth.ToString("0,0") + "mm");
                else EStairsWidth.SetOK(Setting.LangMessages.StairsWidthMessage, StairWidth.ToString("0,0") + "mm");
            } else {
                if (TypeBuilding.Exterier == TypeBuilding || TypeBuilding.TechnicStairs == TypeBuilding || TypeBuilding.InsideApartment == TypeBuilding || TypeBuilding.FamilyHouse == TypeBuilding) {
                    if ((TypeBuilding.FamilyHouse == TypeBuilding || TypeBuilding.InsideApartment == TypeBuilding) && Setting.BuildingLocation==BuildingLocation.Prague){ 
                        if (StairWidth < 180) EStairsWidth.SetError(Setting.LangMessages.StairsWidthMessage, StairWidth.ToString("0,0") + "mm");
                        else EStairsWidth.SetOK(Setting.LangMessages.StairsWidthMessage, StairWidth.ToString("0,0") + "mm");
                    } else {
                        // Nejmenší dovolená šířka schodišťového stupně žebříkových schodišť je 150 mm,
                        if (StairsAngle > 45) {
                            if (StairWidth < 150) EStairsWidth.SetError(Setting.LangMessages.StairsWidthMessage, StairWidth.ToString("0,0") + "mm");
                            else EStairsWidth.SetOK(Setting.LangMessages.StairsWidthMessage, StairWidth.ToString("0,0") + "mm");
                        } else {
                            // Minimální povolená šířka stupně je 210 mm, nástupnice však musí dosahovat alespoň šířky 250 mm.
                            if (StairWidth < 250) EStairsWidth.SetError(Setting.LangMessages.StairsWidthMessage, StairWidth.ToString("0,0") + "mm");
                            else EStairsWidth.SetOK(Setting.LangMessages.StairsWidthMessage, StairWidth.ToString("0,0") + "mm");
                        }
                    }
                } else {
                    // Minimální povolená šířka stupně je 210 mm, nástupnice však musí dosahovat alespoň šířky 250 mm.
                    if (StairWidth < 250) EStairsWidth.SetError(Setting.LangMessages.StairsWidthMessage, StairWidth.ToString("0,0") + "mm");
                    else EStairsWidth.SetOK(Setting.LangMessages.StairsWidthMessage, StairWidth.ToString("0,0") + "mm");
                }
            }

            // výška
            if (TypeBuilding.FamilyHouse == TypeBuilding) {
                //"Pro rodinné domy se nedoporučuje výška stupně vyšší jak 190 mm, pohodlné se dá uvažovat do 180 mm. Optimální výška stupně je 150 až 180mm.";
                if (StairHeight > 190)   EStairsHeight.SetError(Setting.LangMessages.StairsHeightMessage, StairHeight.ToString("0,0") + "mm");
                else if (StairHeight > 180)  EStairsHeight.SetWarling(Setting.LangMessages.StairsHeightMessage, StairHeight.ToString("0,0") + "mm");
                else if (StairHeight < 150)  EStairsHeight.SetWarling(Setting.LangMessages.StairsHeightMessage, StairHeight.ToString("0,0") + "mm");
                else   EStairsHeight.SetOK(Setting.LangMessages.StairsHeightMessage, StairHeight.ToString("0,0") + "mm");
            } else {
                // Optimální výška stupně je 150 až 180mm,
                if (StairHeight > 180)  EStairsHeight.SetWarling(Setting.LangMessages.StairsHeightMessage, StairHeight.ToString("0,0") + "mm");
                else if (StairHeight < 150)   EStairsHeight.SetWarling(Setting.LangMessages.StairsHeightMessage, StairHeight.ToString("0,0") + "mm");
                else  EStairsHeight.SetOK(Setting.LangMessages.StairsHeightMessage, StairHeight.ToString("0,0") + "mm");
            }
        }

        public override void GetStats(ref int ok, ref int warling, ref int wrong) {
            int _ok=0, _warling=0, _wrong=0;
            ELehman.GetStats(ref _ok, ref _warling, ref _wrong);
            EStairsAngle.GetStats(ref _ok, ref _warling, ref _wrong);
            EStairsHeight.GetStats(ref _ok, ref _warling, ref _wrong);
            EStairsWidth.GetStats(ref _ok, ref _warling, ref _wrong);

            Worst= _wrong>0? GCheckState.State.Wrong: (_warling>0 ? GCheckState.State.Warling : GCheckState.State.OK);
            ok+=_ok;
            warling+=_warling;
            wrong+=_wrong;

            foreach (ElementCheckStairsRuns r in Runs) r.GetStats(ref ok, ref warling, ref wrong);
        }
    }
    //public class ElementCheckRamp : CheckObject {
    //    public Bezbarier Accessibility;
    //    public TypeBuilding stairsFor;

    //    public TypeBuilding TypeBuilding {
    //        get {
    //            if (stairsFor <= 0) return Setting.DefBuildingType;
    //            return stairsFor;
    //        }
    //    }
        
    //    public Element Ramp;
    //    public ElementCheck ELehman;
    //    public ElementCheck EStairsWidth;
    //    public ElementCheck EStairsAngle;
    //    public ElementCheck EStairsHeight;
    //    public List<ElementCheckStairsRuns> Runs;

    //    public double StairHeight, StairWidth, StairLehman, StairsAngle;

    //    public ElementCheckRamp(Element ramp) {
    //        SchemaGuid = new Guid("f30bf276-c4f5-4145-9674-8ac5414cc2de");
    //        Ramp = ramp;
    //        ElementId = ramp.Id;

    //        ShowButton=true;
    //        InvidualSelect=true;

    //        CheckingValues=new List<ElementCheck>{  
    //            (ELehman        = new ElementCheck() { Name = Setting.Lang.StairLehman  }),
    //            (EStairsWidth   = new ElementCheck() { Name = Setting.Lang.StairDepth   }),
    //            (EStairsAngle   = new ElementCheck() { Name = Setting.Lang.StairAngle   }),
    //            (EStairsHeight  = new ElementCheck() { Name = Setting.Lang.StairHeight  })                
    //        };

    //        Runs = new List<ElementCheckStairsRuns>();

    //        ICollection<ElementId> runs = ramp.GetDependentElements(new ElementClassFilter(typeof(ElementType)));
    //        foreach (ElementId itemRun in runs) {
    //            Element r = Command.doc.Document.GetElement(itemRun) as Element;
    //            ElementCheckRampRuns run = new ElementCheckRampRuns(r);
    //            run.BuildingType=stairsFor;
    //            run.Calculate();
    //            run.Check();
    //            Runs.Add(run);
    //        }

    //        Load();
    //    }

    //    public override string GetInfo() {
    //        Parameter pTypeMark = Ramp.get_Parameter(BuiltInParameter.ALL_MODEL_TYPE_MARK);
    //        string typeMark = pTypeMark == null ? "" : pTypeMark.AsString();

    //        Parameter pLevel = Ramp.get_Parameter(BuiltInParameter.STAIRS_BASE_LEVEL_PARAM);
    //        Level level = Command.doc.Document.GetElement(pLevel.AsElementId()) as Level;

    //        string ret = Setting.Lang.Stairs+" - ";
    //        if (typeMark != "")
    //            ret += " " + Setting.Lang.TypeMark + ": " + typeMark;
    //        return ret + " " + Setting.Lang.Level + ": " + level.Name;
    //    }

    //    public override void GenerateExcel(Worksheet worksheet, ref int pos) {
    //        Parameter pTypeMark = Ramp.get_Parameter(BuiltInParameter.ALL_MODEL_TYPE_MARK);
    //        string typeMark = pTypeMark == null ? "" : pTypeMark.AsString();

    //        Parameter pLevel = Ramp.get_Parameter(BuiltInParameter.STAIRS_BASE_LEVEL_PARAM);
    //        Level level = Command.doc.Document.GetElement(pLevel.AsElementId()) as Level;

    //        string info = "(" + Setting.Lang.Using + ": " + TypeBuilding.ToString() + ", " + Setting.Lang.Level + ": '" + level.Name;
    //        if (typeMark != "") info += "', " + Setting.Lang.TypeMark + ": '" + typeMark + "'";

    //        worksheet.AddCell(Setting.Lang.Stairs,0,pos, ElementsCheckData.HeaderStyle);
    //        worksheet.AddCell(info + ")",1,pos);
    //        pos++;

    //        ELehman.GenerateExcel(worksheet, ref pos);
    //        pos++;

    //        EStairsWidth.GenerateExcel(worksheet, ref pos);
    //        pos++;

    //        EStairsAngle.GenerateExcel(worksheet, ref pos);
    //        pos++;

    //        EStairsHeight.GenerateExcel(worksheet, ref pos);
    //        pos++;

    //        foreach (ElementCheckStairsRuns run in Runs) {
    //            run.GenerateExcel(worksheet, ref pos);
    //        }
    //    }

    //    public override void Save() {
    //        // Create byte data
    //        List<byte> bytes = new List<byte> {
    //            (byte)Accessibility,
    //            (byte)stairsFor
    //        };

    //        // Find schema
    //        Schema schema = Schema.Lookup(SchemaGuid);
    //        if (schema == null) {
    //            schema = CreateSchema();
    //        }

    //        // Create an entity (object) for this schema (class)
    //        Entity entity = new Entity(schema);

    //        string data = Convert.ToBase64String(bytes.ToArray());
    //        // Console.WriteLine("Saved: "+data);
    //        entity.Set(dataSavingName, data);

    //        // Store the entity on the element
    //        Ramp.SetEntity(entity);
    //    }

    //    public override void Load() {
    //        Schema schema = Schema.Lookup(SchemaGuid);
    //        if (schema != null) {
    //            Entity retrievedEntity = Ramp.GetEntity(schema);
    //            if (retrievedEntity.IsValidObject) {
    //                string retrievedData = retrievedEntity.Get<string>(schema.GetField(dataSavingName));
    //                //    Console.WriteLine("Loaded: "+retrievedData);
    //                byte[] bytes = Convert.FromBase64String(retrievedData);
    //                if (bytes.Length == 2) {
    //                    Accessibility = (Bezbarier)bytes[0];
    //                    stairsFor = (TypeBuilding)bytes[1];
    //                }
    //            }
    //        }
    //    }

    //    Schema CreateSchema() {
    //        SchemaBuilder schemaBuilder = new SchemaBuilder(SchemaGuid);

    //        // Allow anyone to read the object
    //        schemaBuilder.SetReadAccessLevel(AccessLevel.Public);

    //        // Restrict writing to this vendor only
    //        schemaBuilder.SetWriteAccessLevel(AccessLevel.Public);

    //        // Required because of restricted write-access

    //        //var appGuid = Assembly.GetExecutingAssembly().GetCustomAttribute<GuidAttribute>().Value;

    //        //schemaBuilder.SetVendorId("Check Standarts");
    //        //   schemaBuilder.SetApplicationGUID(new Guid(appGuid));

    //        // Create a field to store an XYZ
    //        FieldBuilder fieldBuilder = schemaBuilder.AddSimpleField(dataSavingName, typeof(string));
    //        //  fieldBuilder.SetUnitType(UnitType.UT_Length);
    //        //      fieldBuilder.SetSpec(UnitTypeId.Custom);
    //        fieldBuilder.SetDocumentation("Check api revit byte data for custom definition using type");
    //        schemaBuilder.SetSchemaName(dataSavingName);

    //        // Register the schema
    //        Schema schema = schemaBuilder.Finish();

    //        return schema;
    //    }

    //    //public Level GetStairsLevel() {               
    //    //    Parameter pLevel = Ramp.get_Parameter(BuiltInParameter.STAIRS_BASE_LEVEL_PARAM);
    //    //    return document.GetElement(pLevel.AsElementId()) as Level;
    //    //}

    //    //public string GetStairsType() {   
    //    //    Parameter pTypeMark=Ramp.get_Parameter(BuiltInParameter.ALL_MODEL_TYPE_MARK);  
    //    //    return pTypeMark==null? "":pTypeMark.AsString(); 
    //    //}

    //    public void Calculate() {
    //        StairHeight = ClassUnitHelper.ConvertToMilimeters(Ramp.ActualRiserHeight);
    //        StairWidth = ClassUnitHelper.ConvertToMilimeters(Ramp.ActualTreadDepth);
    //        StairLehman = (StairWidth + StairHeight * 2);
    //        StairsAngle = Math.Atan(StairHeight / StairWidth) * 180 / Math.PI;
    //    }

    //    public override void Check() {
    //        // Pokud rampa nepřekročí svojí celkovou délkou 3 metry, pak může být ve sklonu až 1:8.
    //        //Nejdůležitějším parametrem je maximální možný sklon rampy s přihlédnutím k její délce. Doporučovaný sklon je 1:16 až 1:12.
    //         //   Proto zřizujeme vždy minimálně po 9 metrech podestu v délce 1,5 metru.
    //        //    šířka byty, inviduální ≥ 750 mm, ostatní ≥ 1500 mm  (pražské předpisy ≥ 900 mm))

    //        // Sklon schodu
    //        if (TypeBuilding == TypeBuilding.FamilyHouse || TypeBuilding == TypeBuilding.InsideApartment) {
    //            // schodišť uvnitř bytů s konstrukční výškou menší než 3000mm a u schodišť do sklepů a na půdu je možno sklon zvýšit na 41°.
    //            if (StairHeight < 3000) {
    //                if (StairsAngle > 41) EStairsAngle.SetError(Setting.Lang.StairsAngle, StairsAngle + "°");
    //                else  EStairsAngle.SetOK(Setting.Lang.StairsAngle, StairsAngle + "°");
    //            } else {
    //                if (StairsAngle > 35) EStairsAngle.SetError(Setting.Lang.StairsAngle, StairsAngle + "°");
    //                else if (StairsAngle < 25) EStairsAngle.SetError(Setting.Lang.StairsAngle, StairsAngle + "°");
    //                else  EStairsAngle.SetOK(Setting.Lang.StairsAngle, StairsAngle + "°");
    //            }
    //        } else if (TypeBuilding == TypeBuilding.ApartmentBuildingWithoutElevator) {
    //            // ČSN 73 4130 Schodiště a šikmé rampy – Základní požadavky. „6.1.1 Sklon schodišťových ramen v bytových domech, uvnitř prostorů určených ke shromažďování osob a únikových schodišť by měl být v rozmezí 25°< α ≤ 35°.
    //            if (StairsAngle > 35) EStairsAngle.SetError(Setting.Lang.StairsAngle, StairsAngle + "°");
    //            else if (StairsAngle < 25) EStairsAngle.SetError(Setting.Lang.StairsAngle, StairsAngle + "°");
    //            else  EStairsAngle.SetOK(Setting.Lang.StairsAngle, StairsAngle + "°");
    //        } else if (TypeBuilding == TypeBuilding.TechnicStairs) {
    //            // schodišť uvnitř bytů s konstrukční výškou menší než 3000mm a u schodišť do sklepů a na půdu je možno sklon zvýšit na 41°.
    //            if (StairsAngle > 41) EStairsAngle.SetError(Setting.Lang.StairsAngle, StairsAngle + "°");
    //            else  EStairsAngle.SetOK(Setting.Lang.StairsAngle, StairsAngle + "°");
    //        } else if (TypeBuilding == TypeBuilding.Administrative || TypeBuilding == TypeBuilding.ApartmentBuildingWithElevator || Accessibility == Bezbarier.Bezbarier) {
    //            // sklon schodišťového ramene nesmí být větší než 28 ° a výška schodišťového stupně větší než 160 mm; to neplatí pro bytové domy,
    //            if (StairsAngle > 28) EStairsAngle.SetError(Setting.Lang.StairsAngle, StairsAngle + "°");
    //            else   EStairsAngle.SetOK(Setting.Lang.StairsAngle, StairsAngle + "°");
    //        } else if (TypeBuilding==TypeBuilding.Exterier) {
    //            if (StairsAngle > 35) EStairsAngle.SetError(Setting.Lang.StairsAngle, StairsAngle + "°");
    //            else if (StairsAngle < 25) EStairsAngle.SetError(Setting.Lang.StairsAngle, StairsAngle + "°");
    //            else  EStairsAngle.SetOK(Setting.Lang.StairsAngle, StairsAngle + "°");
    //        } else {
    //            #if DEBUG
    //            throw new Exception("Missing category"); 
    //            #else
    //            EStairsAngle.SetOK(Setting.Lang.StairsAngle, StairsAngle + "°");
    //            #endif
    //        }

    //        // Lehman
    //        // • vzájemný vztah mezi výškou h a šířkou b v mm schodišťového stupně musí být 2h + b = 630 mm (600 až 650mm).
    //        if (StairLehman < 600) ELehman.SetError(Setting.Lang.StairLehman, StairLehman + "mm");
    //        else if (StairLehman < 610) ELehman.SetWarling(Setting.Lang.StairLehman, StairLehman + "mm");
    //        else if (StairLehman > 650) ELehman.SetError(Setting.Lang.StairLehman, StairLehman + "mm");
    //        else  ELehman.SetOK(Setting.Lang.StairLehman, StairLehman + "mm");

    //        //width
    //        //U bezbariérových staveb musí šířka stupně dosahovat alespoň hodnoty 310 mm, výška nesmí překročit 160 mm. 
    //        if (Accessibility == Bezbarier.Bezbarier) {
    //            if (StairWidth < 310)
    //                EStairsWidth.SetError(Setting.Lang.StairsWidthMessage, StairWidth + "mm");
    //            else
    //                EStairsWidth.SetOK(Setting.Lang.StairsWidthMessage, StairWidth + "mm");
    //        } else {
    //            if (TypeBuilding.Exterier == TypeBuilding || TypeBuilding.TechnicStairs == TypeBuilding || TypeBuilding.InsideApartment == TypeBuilding || TypeBuilding.FamilyHouse == TypeBuilding) {
    //                // Nejmenší dovolená šířka schodišťového stupně žebříkových schodišť je 150 mm,
    //                if (StairsAngle > 45) {
    //                    if (StairWidth < 150) EStairsWidth.SetError(Setting.Lang.StairsWidthMessage, StairWidth + "mm");
    //                    else   EStairsWidth.SetOK(Setting.Lang.StairsWidthMessage, StairWidth + "mm");
    //                } else {
    //                    // Minimální povolená šířka stupně je 210 mm, nástupnice však musí dosahovat alespoň šířky 250 mm.
    //                    if (StairWidth < 250) EStairsWidth.SetError(Setting.Lang.StairsWidthMessage, StairWidth + "mm");
    //                    else  EStairsWidth.SetOK(Setting.Lang.StairsWidthMessage, StairWidth + "mm");
    //                }
    //            } else {
    //                // Minimální povolená šířka stupně je 210 mm, nástupnice však musí dosahovat alespoň šířky 250 mm.
    //                if (StairWidth < 250) EStairsWidth.SetError(Setting.Lang.StairsWidthMessage, StairWidth + "mm");
    //                else EStairsWidth.SetOK(Setting.Lang.StairsWidthMessage, StairWidth + "mm");
    //            }
    //        }

    //        // výška
    //        if (TypeBuilding.FamilyHouse == TypeBuilding) {
    //            //"Pro rodinné domy se nedoporučuje výška stupně vyšší jak 190 mm, pohodlné se dá uvažovat do 180 mm. Optimální výška stupně je 150 až 180mm.";
    //            if (StairHeight > 190)   EStairsHeight.SetError(Setting.Lang.StairsHeightMessage, StairHeight + "mm");
    //            else if (StairHeight > 180)  EStairsHeight.SetWarling(Setting.Lang.StairsHeightMessage, StairHeight + "mm");
    //            else if (StairHeight < 150)  EStairsHeight.SetWarling(Setting.Lang.StairsHeightMessage, StairHeight + "mm");
    //            else   EStairsHeight.SetOK(Setting.Lang.StairsHeightMessage, StairHeight + "mm");
    //        } else {
    //            // Optimální výška stupně je 150 až 180mm,
    //            if (StairHeight > 180)  EStairsHeight.SetWarling(Setting.Lang.StairsHeightMessage, StairHeight + "mm");
    //            else if (StairHeight < 150)   EStairsHeight.SetWarling(Setting.Lang.StairsHeightMessage, StairHeight + "mm");
    //            else  EStairsHeight.SetOK(Setting.Lang.StairsHeightMessage, StairHeight + "mm");
    //        }
    //    }

    //    public override void GetStats(ref int ok, ref int warling, ref int wrong) {
    //        int _ok=0, _warling=0, _wrong=0;
    //        ELehman.GetStats(ref _ok, ref _warling, ref _wrong);
    //        EStairsAngle.GetStats(ref _ok, ref _warling, ref _wrong);
    //        EStairsHeight.GetStats(ref _ok, ref _warling, ref _wrong);
    //        EStairsWidth.GetStats(ref _ok, ref _warling, ref _wrong);

    //        Worst= _wrong>0? GCheckState.State.Wrong: (_warling>0 ? GCheckState.State.Warling : GCheckState.State.OK);
    //        ok+=_ok;
    //        warling+=_warling;
    //        wrong+=_wrong;

    //        foreach (ElementCheckStairsRuns r in Runs) r.GetStats(ref ok, ref warling, ref wrong);
    //    }
    //}

    public class ElementCheckStairsRuns : CheckObject {
        public ElementCheck EPocetSchodu;
        public ElementCheck ESirkaRamena;
        public StairsRun Run;

        public TypeBuilding BuildingType;

        public double PocetSchodu, SirkaRamena;

        public ElementCheckStairsRuns(StairsRun run) {
            CheckingValues=new List<ElementCheck>{
                (EPocetSchodu = new ElementCheck() { Name = Setting.Lang.NumberOfStairs }),
                (ESirkaRamena = new ElementCheck() { Name = Setting.Lang.WidthOfRun     }),
            };
            ShowButton=true;
            ElementId=run.Id;
            Run = run;
        }

        public override void GenerateExcel(Worksheet worksheet, ref int pos) {
            worksheet.AddCell(Setting.Lang.Run + " (" + Setting.Lang.ElevationRelative + " " + ClassUnitHelper.PrintableHeight(GetElevation()) + ")", 0, pos, ElementsCheckData.HeaderStyle);
           //  WorksheetRow row =  worksheet.Table.Rows.Add();           
          //  row.Cells.Add(new WorksheetCell();
      //      worksheet.Table.Rows[pos].Cells[0] = ;
            pos++;

            EPocetSchodu.GenerateExcel(worksheet, ref pos);
            pos++;

            ESirkaRamena.GenerateExcel(worksheet, ref pos);
            pos++;
        }

        public string GetMark() {
            return Run.LookupParameter("Mark").AsString();
        }

        public double GetElevation() {
            return  UnitUtils.ConvertFromInternalUnits(Run.BaseElevation, UnitTypeId.Meters);
        }

        public override string GetInfo() {
            string ret = Setting.Lang.Run;

            return ret + " - " + Setting.Lang.Elevation + ": " + GetElevation().ToString("F3",CultureInfo.InvariantCulture) + "m";
        }

        public void Calculate(TypeBuilding building) {
            SirkaRamena = ClassUnitHelper.ConvertToMilimeters(Run.ActualRunWidth);
            PocetSchodu = Run.ActualRisersNumber;

            BuildingType=building;
        }

        public override void Check() {
            switch (BuildingType) {
                case TypeBuilding.FamilyHouse:
                    if (SirkaRamena < 900) ESirkaRamena.SetError(Setting.LangMessages.RunWidthMessage, SirkaRamena + "mm");
                    else if (SirkaRamena < 1000) ESirkaRamena.SetWarling(Setting.LangMessages.RunWidthMessage, SirkaRamena + "mm");
                    else ESirkaRamena.SetOK(Setting.LangMessages.RunWidthMessage, SirkaRamena + "mm");

                    if (PocetSchodu > 18) EPocetSchodu.SetError(Setting.LangMessages.StairsNumbersMessage, PocetSchodu + "ks");
                    else EPocetSchodu.SetOK(Setting.LangMessages.StairsNumbersMessage, PocetSchodu + "ks");
                    break;

                case TypeBuilding.ApartmentBuildingWithElevator:
                case TypeBuilding.ApartmentBuildingWithoutElevator:
                    if (SirkaRamena < 1100) ESirkaRamena.SetError(Setting.LangMessages.RunWidthBD, SirkaRamena + "mm");
                    if (SirkaRamena < 1200) ESirkaRamena.SetWarling(Setting.LangMessages.RunWidthBD, SirkaRamena + "mm");
                    else ESirkaRamena.SetOK(Setting.LangMessages.RunWidthBD, SirkaRamena + "mm");

                    if (PocetSchodu > 16) EPocetSchodu.SetError(Setting.LangMessages.StairsNumbersMessage, PocetSchodu + "ks");
                    else EPocetSchodu.SetOK(Setting.LangMessages.StairsNumbersMessage, PocetSchodu + "ks");
                    break;

                case TypeBuilding.InsideApartment:
                    if (SirkaRamena < 900) ESirkaRamena.SetError(Setting.LangMessages.RunWidthMessage, SirkaRamena + "mm");
                    else if (SirkaRamena < 1000) ESirkaRamena.SetWarling(Setting.LangMessages.RunWidthMessage, SirkaRamena + "mm");
                    else ESirkaRamena.SetOK(Setting.LangMessages.RunWidthMessage, SirkaRamena + "mm");

                    if (PocetSchodu > 18) EPocetSchodu.SetError(Setting.LangMessages.StairsNumbersMessage, PocetSchodu + "ks");
                    else EPocetSchodu.SetOK(Setting.LangMessages.StairsNumbersMessage, PocetSchodu + "ks");
                    break;

                case TypeBuilding.Administrative:
                    if (SirkaRamena < 1200) ESirkaRamena.SetError(Setting.LangMessages.RunWidthBD, SirkaRamena + "mm");
                    else ESirkaRamena.SetOK(Setting.LangMessages.RunWidthBD, SirkaRamena + "mm");

                    if (PocetSchodu > 16) EPocetSchodu.SetError(Setting.LangMessages.StairsNumbersMessage, PocetSchodu + "ks");
                    else EPocetSchodu.SetOK(Setting.LangMessages.StairsNumbersMessage, PocetSchodu + "ks");
                    break;

                case TypeBuilding.TechnicStairs:
                    if (PocetSchodu > 16) EPocetSchodu.SetError(Setting.LangMessages.StairsNumbersMessage, PocetSchodu + "ks");
                    else EPocetSchodu.SetOK(Setting.LangMessages.StairsNumbersMessage, PocetSchodu + "ks");
                                        
                    if (SirkaRamena < 550) ESirkaRamena.SetError(Setting.LangMessages.RunWidthBD, SirkaRamena + "mm");
                    else ESirkaRamena.SetOK(Setting.LangMessages.RunWidthBD, SirkaRamena + "mm");
                    break;

                case TypeBuilding.Exterier:
                    if (PocetSchodu > 16) EPocetSchodu.SetError(Setting.LangMessages.StairsNumbersMessage, PocetSchodu + "ks");
                    else EPocetSchodu.SetOK(Setting.LangMessages.StairsNumbersMessage, PocetSchodu + "ks");
                                        
                    if (SirkaRamena < 550) ESirkaRamena.SetError(Setting.LangMessages.RunWidthBD, SirkaRamena + "mm");
                    else ESirkaRamena.SetOK(Setting.LangMessages.RunWidthBD, SirkaRamena + "mm");
                    break;

                #if DEBUG
                default:
                    throw new Exception("Missing category "+BuildingType.ToString());
                #endif
            }
        }

        public override void GetStats(ref int ok, ref int warling, ref int wrong) {
            int _ok=0, _warling=0, _wrong=0;
            EPocetSchodu.GetStats(ref _ok, ref _warling, ref _wrong);
            ESirkaRamena.GetStats(ref _ok, ref _warling, ref _wrong);

            Worst= _wrong>0? GCheckState.State.Wrong: (_warling>0 ? GCheckState.State.Warling : GCheckState.State.OK);

            ok+=_ok;
            warling+=_warling;
            wrong+=_wrong;
        }

        public override void Save() { }

        public override void Load() { }
    }
}
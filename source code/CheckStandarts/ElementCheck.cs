using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit.DB.ExtensibleStorage;
using CarlosAg.ExcelXmlWriter;
using System;
using System.Collections.Generic;
using Parameter = Autodesk.Revit.DB.Parameter;

namespace CheckStandarts {

    public enum TypeBuilding{ 
        NotSpecified,
        Exterier,
        FamilyHouse,
        ApartmentBuildingWithElevator,
        ApartmentBuildingWithoutElevator,
        InsideApartment,
        TechnicStairs,
        Administrative,
    }

    public class ElementCheck {
        public string Name;
        public string Value;
        public string Message;
        public CheckState State;


        public void GenerateExcel(Worksheet worksheet, ref int pos) {
            worksheet.Table.Rows[pos].Cells[0] = new WorksheetCell(Name);
            worksheet.Table.Rows[pos].Cells[1] = new WorksheetCell(Value);

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
            worksheet.Table.Rows[pos].Cells[2] = new WorksheetCell(value);
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

    public abstract class CheckObject {
        public int ObjectId;
        internal static Guid SchemaGuid;
        internal string dataSavingName = "CheckApiRevitData_" + Setting.Version.Replace('.', '_');

        public GCheckState.State Worst;

        abstract public void Save();

        abstract public void Load();

        abstract public void GenerateExcel(Worksheet worksheet, ref int pos);

        abstract public void GetStats(ref int ok, ref int warling, ref int wrong);

        abstract public string GetInfo();
    }

    public class ElementCheckStairs : CheckObject {
        public Bezbarier Accessibility;
        public TypeBuilding stairsFor;

        public TypeBuilding TypeBuilding {
            get {
                if (stairsFor <= 0)
                    return Setting.DefBuildingType;
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

        public ElementCheckStairs(Stairs stairs) {
            SchemaGuid = new Guid("f30bf276-c4f5-4145-9674-8ac5414cc2de");
            Stairs = stairs;
            ObjectId = stairs.Id.IntegerValue;

            ELehman = new ElementCheck() { Name = Setting.Lang.StairLehman };
            EStairsWidth = new ElementCheck() { Name = Setting.Lang.StairDepth };
            EStairsAngle = new ElementCheck() { Name = Setting.Lang.StairAngle };
            EStairsHeight = new ElementCheck() { Name = Setting.Lang.StairHeight };

            Runs = new List<ElementCheckStairsRuns>();

            ICollection<ElementId> runs = stairs.GetStairsRuns();
            foreach (ElementId itemRun in runs) {
                StairsRun r = Command.doc.Document.GetElement(itemRun) as StairsRun;
                ElementCheckStairsRuns run = new ElementCheckStairsRuns(r);
                run.Calculate(TypeBuilding);
                Runs.Add(run);
            }

            Load();
        }

        public override string GetInfo() {
            Parameter pTypeMark = Stairs.get_Parameter(BuiltInParameter.ALL_MODEL_TYPE_MARK);
            string typeMark = pTypeMark == null ? "" : pTypeMark.AsString();

            Parameter pLevel = Stairs.get_Parameter(BuiltInParameter.STAIRS_BASE_LEVEL_PARAM);
            Level level = Command.doc.Document.GetElement(pLevel.AsElementId()) as Level;

            string ret = Setting.Lang.Stairs;
            if (typeMark != "")
                ret += " " + Setting.Lang.TypeMark + ": '" + typeMark + "'";
            return ret + " " + Setting.Lang.Level + ": '" + level.Name + "'";
        }

        public override void GenerateExcel(Worksheet worksheet, ref int pos) {
            Parameter pTypeMark = Stairs.get_Parameter(BuiltInParameter.ALL_MODEL_TYPE_MARK);
            string typeMark = pTypeMark == null ? "" : pTypeMark.AsString();

            Parameter pLevel = Stairs.get_Parameter(BuiltInParameter.STAIRS_BASE_LEVEL_PARAM);
            Level level = Command.doc.Document.GetElement(pLevel.AsElementId()) as Level;

            worksheet.Table.Rows[pos].Cells[0] = new WorksheetCell(Setting.Lang.Stairs, ElementsCheckData.HeaderStyle);
            string info = "(" + Setting.Lang.Using + ": " + TypeBuilding.ToString() + ", " + Setting.Lang.Level + ": '" + level.Name;
            if (typeMark != "")
                info += "', " + Setting.Lang.TypeMark + ": '" + typeMark + "'";
            worksheet.Table.Rows[pos].Cells[1] = new WorksheetCell(info + ")", ElementsCheckData.HeaderStyle);
            //    worksheet.Table.Rows[pos].Cells[0].Style.Font.Bold = true; 

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
                (byte)stairsFor
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
                    string retrievedData = retrievedEntity.Get<string>(schema.GetField(dataSavingName));
                    //    Console.WriteLine("Loaded: "+retrievedData);
                    byte[] bytes = Convert.FromBase64String(retrievedData);
                    if (bytes.Length == 2) {
                        Accessibility = (Bezbarier)bytes[0];
                        stairsFor = (TypeBuilding)bytes[1];
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
        //    Parameter pLevel = Stairs.get_Parameter(BuiltInParameter.STAIRS_BASE_LEVEL_PARAM);
        //    return document.GetElement(pLevel.AsElementId()) as Level;
        //}

        //public string GetStairsType() {   
        //    Parameter pTypeMark=Stairs.get_Parameter(BuiltInParameter.ALL_MODEL_TYPE_MARK);  
        //    return pTypeMark==null? "":pTypeMark.AsString(); 
        //}

        public void Calculate() {
            StairHeight = ClassUnitHelper.ConvertToMilimeters(Stairs.ActualRiserHeight);
            StairWidth = ClassUnitHelper.ConvertToMilimeters(Stairs.ActualTreadDepth);
            StairLehman = (StairWidth + StairHeight * 2);
            StairsAngle = Math.Atan(StairHeight / StairWidth) * 180 / Math.PI;
        }

        public void Check() {
            // Sklon schodu
            if (TypeBuilding == TypeBuilding.FamilyHouse || TypeBuilding == TypeBuilding.InsideApartment) {
                // schodišť uvnitř bytů s konstrukční výškou menší než 3000mm a u schodišť do sklepů a na půdu je možno sklon zvýšit na 41°.
                if (StairHeight < 3000) {
                    if (StairsAngle > 41)
                        EStairsAngle.SetError(Setting.Lang.StairsAngle, StairsAngle + "°");
                    else
                        EStairsAngle.SetOK(Setting.Lang.StairsAngle, StairsAngle + "°");
                } else {
                    if (StairsAngle > 35)
                        EStairsAngle.SetError(Setting.Lang.StairsAngle, StairsAngle + "°");
                    else if (StairsAngle < 25)
                        EStairsAngle.SetError(Setting.Lang.StairsAngle, StairsAngle + "°");
                    else
                        EStairsAngle.SetOK(Setting.Lang.StairsAngle, StairsAngle + "°");
                }
            } else if (TypeBuilding == TypeBuilding.ApartmentBuildingWithoutElevator) {
                // ČSN 73 4130 Schodiště a šikmé rampy – Základní požadavky. „6.1.1 Sklon schodišťových ramen v bytových domech, uvnitř prostorů určených ke shromažďování osob a únikových schodišť by měl být v rozmezí 25°< α ≤ 35°.
                if (StairsAngle > 35)
                    EStairsAngle.SetError(Setting.Lang.StairsAngle, StairsAngle + "°");
                else if (StairsAngle < 25)
                    EStairsAngle.SetError(Setting.Lang.StairsAngle, StairsAngle + "°");
                else
                    EStairsAngle.SetOK(Setting.Lang.StairsAngle, StairsAngle + "°");
            } else if (TypeBuilding == TypeBuilding.TechnicStairs) {
                // schodišť uvnitř bytů s konstrukční výškou menší než 3000mm a u schodišť do sklepů a na půdu je možno sklon zvýšit na 41°.
                if (StairsAngle > 41)
                    EStairsAngle.SetError(Setting.Lang.StairsAngle, StairsAngle + "°");
                else
                    EStairsAngle.SetOK(Setting.Lang.StairsAngle, StairsAngle + "°");
            } else if (TypeBuilding == TypeBuilding.Administrative || TypeBuilding == TypeBuilding.ApartmentBuildingWithElevator || Accessibility == Bezbarier.Bezbarier) {
                // sklon schodišťového ramene nesmí být větší než 28 ° a výška schodišťového stupně větší než 160 mm; to neplatí pro bytové domy,
                if (StairsAngle > 28)
                    EStairsAngle.SetError(Setting.Lang.StairsAngle, StairsAngle + "°");
                else
                    EStairsAngle.SetOK(Setting.Lang.StairsAngle, StairsAngle + "°");
            } else {
                EStairsAngle.SetWarling("Unknown", StairsAngle + "°");
            }

            // Lehman
            // • vzájemný vztah mezi výškou h a šířkou b v mm schodišťového stupně musí být 2h + b = 630 mm (600 až 650mm).
            if (StairLehman < 600)
                ELehman.SetError(Setting.Lang.StairLehman, StairLehman + "mm");
            else if (StairLehman < 610)
                ELehman.SetWarling(Setting.Lang.StairLehman, StairLehman + "mm");
            else if (StairLehman > 650)
                ELehman.SetError(Setting.Lang.StairLehman, StairLehman + "mm");
            else
                ELehman.SetOK(Setting.Lang.StairLehman, StairLehman + "mm");

            //width
            //U bezbariérových staveb musí šířka stupně dosahovat alespoň hodnoty 310 mm, výška nesmí překročit 160 mm. 
            if (Accessibility == Bezbarier.Bezbarier) {
                if (StairWidth < 310)
                    EStairsWidth.SetError(Setting.Lang.StairsWidth, StairWidth + "mm");
                else
                    EStairsWidth.SetOK(Setting.Lang.StairsWidth, StairWidth + "mm");
            } else {
                if (TypeBuilding.Exterier == TypeBuilding || TypeBuilding.TechnicStairs == TypeBuilding || TypeBuilding.InsideApartment == TypeBuilding || TypeBuilding.FamilyHouse == TypeBuilding) {
                    // Nejmenší dovolená šířka schodišťového stupně žebříkových schodišť je 150 mm,
                    if (StairsAngle > 45) {
                        if (StairWidth < 150)
                            EStairsWidth.SetError(Setting.Lang.StairsWidth, StairWidth + "mm");
                        else
                            EStairsWidth.SetOK(Setting.Lang.StairsWidth, StairWidth + "mm");
                    } else {
                        // Minimální povolená šířka stupně je 210 mm, nástupnice však musí dosahovat alespoň šířky 250 mm.
                        if (StairWidth < 250)
                            EStairsWidth.SetError(Setting.Lang.StairsWidth, StairWidth + "mm");
                        else
                            EStairsWidth.SetOK(Setting.Lang.StairsWidth, StairWidth + "mm");
                    }
                } else {
                    // Minimální povolená šířka stupně je 210 mm, nástupnice však musí dosahovat alespoň šířky 250 mm.
                    if (StairWidth < 250)
                        EStairsWidth.SetError(Setting.Lang.StairsWidth, StairWidth + "mm");
                    else
                        EStairsWidth.SetOK(Setting.Lang.StairsWidth, StairWidth + "mm");
                }
            }

            // výška
            if (TypeBuilding.FamilyHouse == TypeBuilding) {
                //"Pro rodinné domy se nedoporučuje výška stupně vyšší jak 190 mm, pohodlné se dá uvažovat do 180 mm. Optimální výška stupně je 150 až 180mm.";
                if (StairHeight > 190)
                    EStairsHeight.SetError(Setting.Lang.StairsHeight, StairHeight + "mm");
                else if (StairHeight > 180)
                    EStairsHeight.SetWarling(Setting.Lang.StairsHeight, StairHeight + "mm");
                else if (StairHeight < 150)
                    EStairsHeight.SetWarling(Setting.Lang.StairsHeight, StairHeight + "mm");
                else
                    EStairsHeight.SetOK(Setting.Lang.StairsHeight, StairHeight + "mm");
            } else {
                // Optimální výška stupně je 150 až 180mm,
                if (StairHeight > 180)
                    EStairsHeight.SetWarling(Setting.Lang.StairsHeight, StairHeight + "mm");
                else if (StairHeight < 150)
                    EStairsHeight.SetWarling(Setting.Lang.StairsHeight, StairHeight + "mm");
                else
                    EStairsHeight.SetOK(Setting.Lang.StairsHeight, StairHeight + "mm");
            }

        }

        public override void GetStats(ref int ok, ref int warling, ref int wrong) {
            ELehman.GetStats(ref ok, ref warling, ref wrong);
            EStairsAngle.GetStats(ref ok, ref warling, ref wrong);
            EStairsHeight.GetStats(ref ok, ref warling, ref wrong);
            EStairsWidth.GetStats(ref ok, ref warling, ref wrong);

            foreach (ElementCheckStairsRuns r in Runs)
                r.GetStats(ref ok, ref warling, ref wrong);
        }
    }

    public class ElementCheckStairsRuns : CheckObject {
        public ElementCheck EPocetSchodu;
        public ElementCheck ESirkaRamena;
        public StairsRun Run;

        public double PocetSchodu, SirkaRamena;

        public ElementCheckStairsRuns(StairsRun run) {
            EPocetSchodu = new ElementCheck() { Name = Setting.Lang.NumberOfStairs };
            ESirkaRamena = new ElementCheck() { Name = Setting.Lang.WidthOfRun };
            Run = run;
        }

        public override void GenerateExcel(Worksheet worksheet, ref int pos) {
            worksheet.Table.Rows[pos].Cells[0] = new WorksheetCell(Setting.Lang.Run + " (" + Setting.Lang.Elevation + " " + ClassUnitHelper.PrintableHeight(GetElevation()) + ")");
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
            return ClassUnitHelper.ConvertToMeters(Run.BaseElevation);
        }

        public override string GetInfo() {
            string ret = Setting.Lang.Run;

            return ret + " " + Setting.Lang.Elevation + ": '" + GetElevation().ToString("0,000") + "m";
        }

        public void Calculate(TypeBuilding building) {
            SirkaRamena = ClassUnitHelper.ConvertToMilimeters(Run.ActualRunWidth);
            PocetSchodu = Run.ActualRisersNumber;

            switch (building) {
                case TypeBuilding.FamilyHouse:
                    if (SirkaRamena < 900)
                        ESirkaRamena.SetError(Setting.Lang.RunWidthRD, SirkaRamena + "mm");
                    else if (SirkaRamena < 1000)
                        ESirkaRamena.SetWarling(Setting.Lang.RunWidthRD, SirkaRamena + "mm");
                    else
                        ESirkaRamena.SetOK(Setting.Lang.RunWidthRD, SirkaRamena + "mm");

                    if (PocetSchodu > 18)
                        EPocetSchodu.SetError(Setting.Lang.StairsNumbersRD, PocetSchodu + "ks");
                    else
                        EPocetSchodu.SetOK(Setting.Lang.StairsNumbersRD, PocetSchodu + "ks");
                    break;

                case TypeBuilding.ApartmentBuildingWithElevator:
                case TypeBuilding.ApartmentBuildingWithoutElevator:
                    if (SirkaRamena < 1100)
                        ESirkaRamena.SetError(Setting.Lang.RunWidthBD, SirkaRamena + "mm");
                    if (SirkaRamena < 1200)
                        ESirkaRamena.SetWarling(Setting.Lang.RunWidthBD, SirkaRamena + "mm");
                    else
                        ESirkaRamena.SetOK(Setting.Lang.RunWidthBD, SirkaRamena + "mm");

                    if (PocetSchodu > 16)
                        EPocetSchodu.SetError(Setting.Lang.StairsNumbersRD, PocetSchodu + "ks");
                    else
                        EPocetSchodu.SetOK(Setting.Lang.StairsNumbersRD, PocetSchodu + "ks");
                    break;

                case TypeBuilding.InsideApartment:
                    if (SirkaRamena < 900)
                        ESirkaRamena.SetError(Setting.Lang.RunWidthRD, SirkaRamena + "mm");
                    else if (SirkaRamena < 1000)
                        ESirkaRamena.SetWarling(Setting.Lang.RunWidthRD, SirkaRamena + "mm");
                    else
                        ESirkaRamena.SetOK(Setting.Lang.RunWidthRD, SirkaRamena + "mm");

                    if (PocetSchodu > 18)
                        EPocetSchodu.SetError(Setting.Lang.StairsNumbersRD, PocetSchodu + "ks");
                    else
                        EPocetSchodu.SetOK(Setting.Lang.StairsNumbersRD, PocetSchodu + "ks");
                    break;

                case TypeBuilding.Administrative:
                    if (SirkaRamena < 1200)
                        ESirkaRamena.SetError("", SirkaRamena + "mm");
                    else
                        ESirkaRamena.SetOK("", SirkaRamena + "mm");

                    if (PocetSchodu > 16)
                        EPocetSchodu.SetError("", PocetSchodu + "ks");
                    else
                        EPocetSchodu.SetOK("", PocetSchodu + "ks");
                    break;

                case TypeBuilding.TechnicStairs:
                    if (PocetSchodu > 16)
                        EPocetSchodu.SetError("", PocetSchodu + "ks");
                    else
                        EPocetSchodu.SetOK("", PocetSchodu + "ks");
                    break;
            }
        }

        public override void GetStats(ref int ok, ref int warling, ref int wrong) {
            EPocetSchodu.GetStats(ref ok, ref warling, ref wrong);
            ESirkaRamena.GetStats(ref ok, ref warling, ref wrong);
        }

        public override void Save() { }

        public override void Load() { }
    }

    public enum CheckState {
        Unknown,
		OK,
        Warling,
		Wrong,
	}

    public enum Bezbarier{ 
        Unknown,
        NotBezbarier,
        Bezbarier,
    }
}

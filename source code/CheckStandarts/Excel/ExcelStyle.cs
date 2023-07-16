using Autodesk.Revit.DB;
using static CheckStandarts.Excel.Sheet;

namespace CheckStandarts.Excel {
    public class ExcelStyle {
        public string Name;

        public int Size;
        public bool Bold;
        public bool Italic;
        public bool Strike;
        public bool SubScript,SuperScript;
        public bool Underline;

        internal string GenerateFontStyle() { 
            string str="<font>";
            if (Size>0) str+="<sz val=\""+Size+"\"/>";
            if (Italic) str+="<i/>";
            if (Bold) str+="<b/>";
            if (Underline) str+="<u/>";
            if (Strike) str+="<strike/>";
            if (SubScript) str+="<vertAlign val=\"subscript\"/>"; 
            else if (SuperScript) str+="<vertAlign val=\"superscript\"/>"; 
		    str+="</font>";

            return str;
        }

        internal string GenerateCellStyle(int xfId, int builtinId) { 
            return @"<cellStyle name="""+Name+@""" xfId="""+xfId+@""" builtinId="""+builtinId+@""" customBuiltin=""1""/>";                
        }
     
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckStandarts.Excel {
    internal class Column {
        // default 27.42578125 ??64px
        public double Width=27.42578125;

        internal string GetData(int posX) { 
            if (Width>0 || Width!=27.42578125) { 
                return @"<cols>"+
                            @"<col min="""+(posX+1)+@""" max="""+(posX+1)+@""" maxColumn=""1"" width="""+Width+@""" bestFit=""1"" customWidth=""1""/>"+
                        @"</cols>";              
            }
            return "";
        }
    }
}

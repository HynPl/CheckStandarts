using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CheckStandarts {
    public partial class UcRun : UserControl, IControlReportedProblem {
        ElementCheckStairsRuns run;
        public EventHandler ChangedCollapsed;
        bool IsSet=false;

        public GCollapse gCollapse;

        public UcRun() {
            InitializeComponent();
            labelTextSirRamena.Text=Setting.Lang.WidthOfRun;
            labelTextPocStupnu.Text=Setting.Lang.NumberOfStairs;
            gButtonShow.Text=Setting.Lang.Show;
        }

        internal int GetHeight() { 
            return Height;
        }

        void DetailsSet() {  
            if (!IsSet) {  
                // vyska
                labelPocetSchodu.Text=run.PocetSchodu.ToString("0")+"ks";
                gCheckStatePocetSchodu.state=run.EPocetSchodu.GetState();
           
                //Lehman
                labelSirkaRamena.Text=run.SirkaRamena.ToString("0,0")+"mm";
                gCheckStateSirkaRamena.state=run.ESirkaRamena.GetState();
    
            }
            IsSet=true;
        }   

        public void SetCheckObject(CheckObject obj) { 
            run=obj as ElementCheckStairsRuns;

            DetailsSet();
        }

        // Show object
        void GButtonShow_Click(object sender, EventArgs e) {
            List<ElementId> list = new List<ElementId> { run.Run.Id };
            Command.uiApp.ActiveUIDocument.Selection.SetElementIds(list);
        }

        void GCheckStateSirRamena_Click(object sender, EventArgs e) {
            FormMessage form=new FormMessage(Setting.Lang.WidthOfRun, run.ESirkaRamena.Message);
            form.ShowDialog();
        }

        void GCheckStatePocStupnu_Click(object sender, EventArgs e) {
            FormMessage form=new FormMessage(Setting.Lang.NumberOfStairs, run.EPocetSchodu.Message);
            form.ShowDialog();
        }
    }
}
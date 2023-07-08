using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CheckStandarts {
    public partial class UcStairs : UserControl, IControlReportedProblem {
        ElementCheckStairs stairs;
        public EventHandler ChangedCollapsed;
        bool IsSet=false;

        public GCollapse gCollapse;

        public UcStairs() {
            InitializeComponent();
            labelTextLeh.Text=Setting.Lang.StairLehman;
            labelTextVys.Text=Setting.Lang.StairHeight;
            labelTextSir.Text=Setting.Lang.StairDepth;
            labelTextSkl.Text=Setting.Lang.StairAngle;
            gButtonShow.Text=Setting.Lang.Show;
            labelType.Text=Setting.Lang.Type;

            gComboBox1.SelectedIndexChanged += GComboBox1_SelectedIndexChanged;
        }

        void GComboBox1_SelectedIndexChanged(object sender, EventArgs e) {
            stairs.stairsFor=(TypeBuilding)gComboBox1.comboBox.SelectedIndex;
        }

        void DetailsSet() {  
            if (!IsSet) { 
           
                // vyska
                labelVys.Text=stairs.StairHeight.ToString("0,0")+"mm";
                gCheckStateVys.state=stairs.EStairsHeight.GetState();
             
                // Sirka
                labelSir.Text=stairs.StairWidth.ToString("0,0")+"mm";
                gCheckStateSir.state=stairs.EStairsWidth.GetState();
             
                //Lehman
                labelLeh.Text=stairs.StairLehman.ToString("0,0")+"mm";
                gCheckStateLeh.state=stairs.ELehman.GetState();
           
                // Sklon
                labelSkl.Text = stairs.StairsAngle.ToString("0,0")+"°";
                gCheckStateSkl.state=stairs.EStairsAngle.GetState();
           
            }
            IsSet=true;
        }   

        public void SetCheckObject(CheckObject obj) { 
            stairs=obj as ElementCheckStairs;

            gComboBox1.comboBox.Items=new string[]{Setting.Lang.DefaultBuilding, Setting.Lang.FamilyHouse, Setting.Lang.Apartement, Setting.Lang.InsideApartement, Setting.Lang.Administrative, Setting.Lang.Technic, Setting.Lang.Exterier };
            gComboBox1.comboBox.SelectedIndex=(int)stairs.stairsFor;

            DetailsSet();
        }

        // Show object
        void GButtonShow_Click(object sender, EventArgs e) {
            List<ElementId> list = new List<ElementId> { stairs.Stairs.Id };
            Command.uiApp.ActiveUIDocument.Selection.SetElementIds(list);
        }

        void GCheckStateLeh_Click(object sender, EventArgs e) {
            FormMessage form=new FormMessage(Setting.Lang.StairLehman, stairs.ELehman.Message);
            form.ShowDialog();
        }

        void GCheckStateVys_Click(object sender, EventArgs e) {
            FormMessage form=new FormMessage(Setting.Lang.StairsHeight, stairs.EStairsHeight.Message);
            form.ShowDialog();
        }

        void GCheckStateSir_Click(object sender, EventArgs e) {
            FormMessage form=new FormMessage(Setting.Lang.StairDepth, stairs.EStairsWidth.Message);
            form.ShowDialog();
        }

        void GCheckStateSkl_Click(object sender, EventArgs e) {
            FormMessage form=new FormMessage(Setting.Lang.StairAngle, stairs.EStairsAngle.Message);
            form.ShowDialog();
        }
    }
}
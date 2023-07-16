using System;
using System.Windows.Forms;

namespace CheckStandarts {
    public partial class FormSettings : Form {
      //  internal bool LangChanged;

        public FormSettings() {
            InitializeComponent();
            gComboBoxLang.comboBox.Items=new string[]{Setting.Lang.LangByRevit, Setting.Lang.LangCzech, Setting.Lang.LangEnglishGB, Setting.Lang.LangSlovak };
            gComboBoxLangMessages.comboBox.Items=new string[]{Setting.Lang.LangByRevit, Setting.Lang.LangCzech, Setting.Lang.LangEnglishGB, Setting.Lang.LangSlovak };
           // gComboBoxLangExport.comboBox.Items=new string[]{Setting.Lang.LangByRevit, Setting.Lang.LangCzech, Setting.Lang.LangEnglishGB, Setting.Lang.LangSlovak };
            gComboBoxBuilding.comboBox.Items=new string[]{Setting.Lang.UnknownBuilding, Setting.Lang.FamilyHouse, Setting.Lang.Apartement, Setting.Lang.InsideApartement, Setting.Lang.Administrative, Setting.Lang.Technic, Setting.Lang.Exterier };
            gComboBoxBuildingLocation.comboBox.Items=new string[]{Setting.Lang.UnknownLoc, Setting.Lang.GeneralWtithoutPrague, Setting.Lang.Prague };
            
            gComboBoxLang.comboBox.SelectedIndex=(int)Setting.LangCode;
         //   gComboBoxLangExport.comboBox.SelectedIndex=(int)Setting.LangExportCode;
            gComboBoxLangMessages.comboBox.SelectedIndex=(int)Setting.LangCodeMessages;
            gComboBoxBuilding.comboBox.SelectedIndex=(int)Setting.DefBuildingType;
            gComboBoxBuildingLocation.comboBox.SelectedIndex=(int)Setting.BuildingLocation;

            gLabelBuildingLocation.Text=Setting.Lang.Location;
          //  gLabelLang.Text=Setting.Lang.Language;
          //  gLabelLangExport.Text=Setting.Lang.LangExport;
            gLabelLangMessages.Text=Setting.Lang.LangMessages;
            gLabelBuildingType.Text=Setting.Lang.BuildingType;
        }

        private void GButton1_Click(object sender, EventArgs e) {   
            Hide();
            if (Setting.LangCode != (Setting.AvaibleLang)gComboBoxLang.comboBox.SelectedIndex 
            || Setting.LangCodeMessages != (Setting.AvaibleLang)gComboBoxLangMessages.comboBox.SelectedIndex)
                using (FormMessage message =new FormMessage(Setting.Lang.AfterClose,Setting.Lang.SomeChangesAfterCloseAndOpen)) message.ShowDialog();

            Setting.LangCode=(Setting.AvaibleLang)gComboBoxLang.comboBox.SelectedIndex;
            Setting.LangCodeMessages=(Setting.AvaibleLang)gComboBoxLangMessages.comboBox.SelectedIndex;
            Setting.DefBuildingType=(TypeBuilding)gComboBoxBuilding.comboBox.SelectedIndex;
         
          //  Setting.SolveLang(Command.app);
            Setting.Save();

            Close();
        }
    }
}

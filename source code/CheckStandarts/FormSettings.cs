using System;
using System.Windows.Forms;

namespace CheckStandarts {
    public partial class FormSettings : Form {
        public FormSettings() {
            InitializeComponent();
            gComboBoxLang.comboBox.Items=new string[]{Setting.Lang.LangByRevit, Setting.Lang.LangCzech, Setting.Lang.LangEnglishGB, Setting.Lang.LangSlovak };
            gComboBoxLangExport.comboBox.Items=new string[]{Setting.Lang.LangByRevit, Setting.Lang.LangCzech, Setting.Lang.LangEnglishGB, Setting.Lang.LangSlovak };
            gComboBoxBuilding.comboBox.Items=new string[]{Setting.Lang.UnknownBuilding, Setting.Lang.FamilyHouse, Setting.Lang.Apartement, Setting.Lang.InsideApartement, Setting.Lang.Administrative, Setting.Lang.Technic, Setting.Lang.Exterier };
            
            gComboBoxLang.comboBox.SelectedIndex=(int)Setting.LangCode;
            gComboBoxLangExport.comboBox.SelectedIndex=(int)Setting.LangExportCode;
            gComboBoxBuilding.comboBox.SelectedIndex=(int)Setting.DefBuildingType;
        }

        private void gButton1_Click(object sender, EventArgs e) {
            Close();
        }

        private void FormSettings_FormClosing(object sender, FormClosingEventArgs e) {
            Setting.LangCode=(Setting.AvaibleLang)gComboBoxLang.comboBox.SelectedIndex;
            Setting.LangExportCode=(Setting.AvaibleLang)gComboBoxLangExport.comboBox.SelectedIndex;
            Setting.DefBuildingType=(TypeBuilding)gComboBoxBuilding.comboBox.SelectedIndex;

            Setting.Save();
        }
    }
}

namespace CheckStandarts {
    partial class FormSettings {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSettings));
            this.label1 = new CheckStandarts.GLabel();
            this.gLabelBuildingType = new CheckStandarts.GLabel();
            this.gButtonOK = new CheckStandarts.GButton();
            this.gComboBoxLang = new CheckStandarts.GComboBox();
            this.gComboBoxBuilding = new CheckStandarts.GComboBox();
            this.label4 = new CheckStandarts.GLabel();
            this.gLabelLangMessages = new CheckStandarts.GLabel();
            this.gComboBoxLangMessages = new CheckStandarts.GComboBox();
            this.gLabelBuildingLocation = new CheckStandarts.GLabel();
            this.gComboBoxBuildingLocation = new CheckStandarts.GComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(14, 66);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 22);
            this.label1.TabIndex = 2;
            this.label1.Text = "Language";
            // 
            // gLabelBuildingType
            // 
            this.gLabelBuildingType.BackColor = System.Drawing.Color.Transparent;
            this.gLabelBuildingType.Location = new System.Drawing.Point(14, 156);
            this.gLabelBuildingType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gLabelBuildingType.Name = "gLabelBuildingType";
            this.gLabelBuildingType.Size = new System.Drawing.Size(106, 22);
            this.gLabelBuildingType.TabIndex = 2;
            this.gLabelBuildingType.Text = "Building Type";
            // 
            // gButtonOK
            // 
            this.gButtonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.gButtonOK.BackColor = System.Drawing.Color.Transparent;
            this.gButtonOK.Disamble = false;
            this.gButtonOK.Location = new System.Drawing.Point(263, 250);
            this.gButtonOK.Margin = new System.Windows.Forms.Padding(4);
            this.gButtonOK.Name = "gButtonOK";
            this.gButtonOK.SetOrientation = CheckStandarts.GButton.Orientation.Center;
            this.gButtonOK.Size = new System.Drawing.Size(112, 36);
            this.gButtonOK.TabIndex = 1;
            this.gButtonOK.Text = "OK";
            this.gButtonOK.Click += new System.EventHandler(this.GButton1_Click);
            // 
            // gComboBoxLang
            // 
            this.gComboBoxLang.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gComboBoxLang.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gComboBoxLang.Location = new System.Drawing.Point(178, 61);
            this.gComboBoxLang.Name = "gComboBoxLang";
            this.gComboBoxLang.Size = new System.Drawing.Size(197, 30);
            this.gComboBoxLang.TabIndex = 4;
            // 
            // gComboBoxBuilding
            // 
            this.gComboBoxBuilding.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gComboBoxBuilding.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gComboBoxBuilding.Location = new System.Drawing.Point(178, 152);
            this.gComboBoxBuilding.Name = "gComboBoxBuilding";
            this.gComboBoxBuilding.Size = new System.Drawing.Size(197, 30);
            this.gComboBoxBuilding.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(14, 15);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 29);
            this.label4.TabIndex = 2;
            this.label4.Text = "Settings";
            // 
            // gLabelLangMessages
            // 
            this.gLabelLangMessages.BackColor = System.Drawing.Color.Transparent;
            this.gLabelLangMessages.Location = new System.Drawing.Point(14, 101);
            this.gLabelLangMessages.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gLabelLangMessages.Name = "gLabelLangMessages";
            this.gLabelLangMessages.Size = new System.Drawing.Size(154, 22);
            this.gLabelLangMessages.TabIndex = 2;
            this.gLabelLangMessages.Text = "Language messages";
            // 
            // gComboBoxLangMessages
            // 
            this.gComboBoxLangMessages.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gComboBoxLangMessages.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gComboBoxLangMessages.Location = new System.Drawing.Point(178, 96);
            this.gComboBoxLangMessages.Name = "gComboBoxLangMessages";
            this.gComboBoxLangMessages.Size = new System.Drawing.Size(197, 30);
            this.gComboBoxLangMessages.TabIndex = 4;
            // 
            // gLabelBuildingLocation
            // 
            this.gLabelBuildingLocation.BackColor = System.Drawing.Color.Transparent;
            this.gLabelBuildingLocation.Location = new System.Drawing.Point(14, 196);
            this.gLabelBuildingLocation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gLabelBuildingLocation.Name = "gLabelBuildingLocation";
            this.gLabelBuildingLocation.Size = new System.Drawing.Size(73, 22);
            this.gLabelBuildingLocation.TabIndex = 2;
            this.gLabelBuildingLocation.Text = "Umístění";
            // 
            // gComboBoxBuildingLocation
            // 
            this.gComboBoxBuildingLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gComboBoxBuildingLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gComboBoxBuildingLocation.Location = new System.Drawing.Point(178, 192);
            this.gComboBoxBuildingLocation.Name = "gComboBoxBuildingLocation";
            this.gComboBoxBuildingLocation.Size = new System.Drawing.Size(197, 30);
            this.gComboBoxBuildingLocation.TabIndex = 4;
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(388, 299);
            this.Controls.Add(this.gComboBoxBuildingLocation);
            this.Controls.Add(this.gComboBoxBuilding);
            this.Controls.Add(this.gComboBoxLangMessages);
            this.Controls.Add(this.gComboBoxLang);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.gLabelBuildingLocation);
            this.Controls.Add(this.gLabelBuildingType);
            this.Controls.Add(this.gLabelLangMessages);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gButtonOK);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSettings";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.TopMost = true;
           // this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSettings_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion
        private GButton gButtonOK;
        private GLabel label1;
        private GLabel gLabelBuildingType;
        private GComboBox gComboBoxLang;
        private GComboBox gComboBoxBuilding;
        private GLabel label4;
        private GLabel gLabelLangMessages;
        private GComboBox gComboBoxLangMessages;
        private GLabel gLabelBuildingLocation;
        private GComboBox gComboBoxBuildingLocation;
    }
}
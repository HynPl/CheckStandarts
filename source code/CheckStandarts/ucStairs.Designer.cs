namespace CheckStandarts {
    partial class UcStairs {
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.labelTextLeh = new System.Windows.Forms.Label();
            this.labelTextVys = new System.Windows.Forms.Label();
            this.labelTextSir = new System.Windows.Forms.Label();
            this.labelTextSkl = new System.Windows.Forms.Label();
            this.labelLeh = new System.Windows.Forms.Label();
            this.labelVys = new System.Windows.Forms.Label();
            this.labelSir = new System.Windows.Forms.Label();
            this.labelSkl = new System.Windows.Forms.Label();
            this.gComboBox1 = new CheckStandarts.GComboBox();
            this.gCheckStateSkl = new CheckStandarts.GCheckState();
            this.gCheckStateSir = new CheckStandarts.GCheckState();
            this.gCheckStateVys = new CheckStandarts.GCheckState();
            this.gCheckStateLeh = new CheckStandarts.GCheckState();
            this.gButtonShow = new CheckStandarts.GButton();
            this.labelType = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelTextLeh
            // 
            this.labelTextLeh.AutoSize = true;
            this.labelTextLeh.Location = new System.Drawing.Point(188, 17);
            this.labelTextLeh.Name = "labelTextLeh";
            this.labelTextLeh.Size = new System.Drawing.Size(120, 17);
            this.labelTextLeh.TabIndex = 0;
            this.labelTextLeh.Text = "Lehmanův vzorec";
            // 
            // labelTextVys
            // 
            this.labelTextVys.AutoSize = true;
            this.labelTextVys.Location = new System.Drawing.Point(188, 55);
            this.labelTextVys.Name = "labelTextVys";
            this.labelTextVys.Size = new System.Drawing.Size(93, 17);
            this.labelTextVys.TabIndex = 0;
            this.labelTextVys.Text = "Výška stupně";
            // 
            // labelTextSir
            // 
            this.labelTextSir.AutoSize = true;
            this.labelTextSir.Location = new System.Drawing.Point(188, 93);
            this.labelTextSir.Name = "labelTextSir";
            this.labelTextSir.Size = new System.Drawing.Size(87, 17);
            this.labelTextSir.TabIndex = 0;
            this.labelTextSir.Text = "Šířka stupně";
            // 
            // labelTextSkl
            // 
            this.labelTextSkl.AutoSize = true;
            this.labelTextSkl.Location = new System.Drawing.Point(188, 131);
            this.labelTextSkl.Name = "labelTextSkl";
            this.labelTextSkl.Size = new System.Drawing.Size(107, 17);
            this.labelTextSkl.TabIndex = 0;
            this.labelTextSkl.Text = "Sklon schodiště";
            // 
            // labelLeh
            // 
            this.labelLeh.AutoSize = true;
            this.labelLeh.Location = new System.Drawing.Point(335, 17);
            this.labelLeh.Name = "labelLeh";
            this.labelLeh.Size = new System.Drawing.Size(120, 17);
            this.labelLeh.TabIndex = 0;
            this.labelLeh.Text = "Lehmanův vzorec";
            // 
            // labelVys
            // 
            this.labelVys.AutoSize = true;
            this.labelVys.Location = new System.Drawing.Point(335, 55);
            this.labelVys.Name = "labelVys";
            this.labelVys.Size = new System.Drawing.Size(93, 17);
            this.labelVys.TabIndex = 0;
            this.labelVys.Text = "Výška stupně";
            // 
            // labelSir
            // 
            this.labelSir.AutoSize = true;
            this.labelSir.Location = new System.Drawing.Point(335, 93);
            this.labelSir.Name = "labelSir";
            this.labelSir.Size = new System.Drawing.Size(87, 17);
            this.labelSir.TabIndex = 0;
            this.labelSir.Text = "Šířka stupně";
            // 
            // labelSkl
            // 
            this.labelSkl.AutoSize = true;
            this.labelSkl.Location = new System.Drawing.Point(335, 131);
            this.labelSkl.Name = "labelSkl";
            this.labelSkl.Size = new System.Drawing.Size(107, 17);
            this.labelSkl.TabIndex = 0;
            this.labelSkl.Text = "Sklon schodiště";
            // 
            // gComboBox1
            // 
            this.gComboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gComboBox1.Location = new System.Drawing.Point(13, 104);
            this.gComboBox1.Name = "gComboBox1";
            this.gComboBox1.Size = new System.Drawing.Size(165, 30);
            this.gComboBox1.TabIndex = 5;
            // 
            // gCheckStateSkl
            // 
            this.gCheckStateSkl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gCheckStateSkl.BackColor = System.Drawing.Color.Transparent;
            this.gCheckStateSkl.Location = new System.Drawing.Point(568, 122);
            this.gCheckStateSkl.Name = "gCheckStateSkl";
            this.gCheckStateSkl.Size = new System.Drawing.Size(32, 32);
            this.gCheckStateSkl.TabIndex = 2;
            this.gCheckStateSkl.TabStop = false;
            this.gCheckStateSkl.Click += new System.EventHandler(this.GCheckStateSkl_Click);
            // 
            // gCheckStateSir
            // 
            this.gCheckStateSir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gCheckStateSir.BackColor = System.Drawing.Color.Transparent;
            this.gCheckStateSir.Location = new System.Drawing.Point(568, 84);
            this.gCheckStateSir.Name = "gCheckStateSir";
            this.gCheckStateSir.Size = new System.Drawing.Size(32, 32);
            this.gCheckStateSir.TabIndex = 2;
            this.gCheckStateSir.TabStop = false;
            this.gCheckStateSir.Click += new System.EventHandler(this.GCheckStateSir_Click);
            // 
            // gCheckStateVys
            // 
            this.gCheckStateVys.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gCheckStateVys.BackColor = System.Drawing.Color.Transparent;
            this.gCheckStateVys.Location = new System.Drawing.Point(568, 46);
            this.gCheckStateVys.Name = "gCheckStateVys";
            this.gCheckStateVys.Size = new System.Drawing.Size(32, 32);
            this.gCheckStateVys.TabIndex = 2;
            this.gCheckStateVys.TabStop = false;
            this.gCheckStateVys.Click += new System.EventHandler(this.GCheckStateVys_Click);
            // 
            // gCheckStateLeh
            // 
            this.gCheckStateLeh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gCheckStateLeh.BackColor = System.Drawing.Color.Transparent;
            this.gCheckStateLeh.Location = new System.Drawing.Point(568, 8);
            this.gCheckStateLeh.Name = "gCheckStateLeh";
            this.gCheckStateLeh.Size = new System.Drawing.Size(32, 32);
            this.gCheckStateLeh.TabIndex = 2;
            this.gCheckStateLeh.TabStop = false;
            this.gCheckStateLeh.Click += new System.EventHandler(this.GCheckStateLeh_Click);
            // 
            // gButtonShow
            // 
            this.gButtonShow.BackColor = System.Drawing.Color.Transparent;
            this.gButtonShow.Disamble = false;
            this.gButtonShow.Location = new System.Drawing.Point(42, 36);
            this.gButtonShow.Name = "gButtonShow";
            this.gButtonShow.SetOrientation = CheckStandarts.GButton.Orientation.Center;
            this.gButtonShow.Size = new System.Drawing.Size(108, 36);
            this.gButtonShow.TabIndex = 1;
            this.gButtonShow.Text = "Show";
            this.gButtonShow.Click += new System.EventHandler(this.GButtonShow_Click);
            // 
            // labelType
            // 
            this.labelType.AutoSize = true;
            this.labelType.Location = new System.Drawing.Point(10, 84);
            this.labelType.Name = "labelType";
            this.labelType.Size = new System.Drawing.Size(40, 17);
            this.labelType.TabIndex = 0;
            this.labelType.Text = "Type";
            // 
            // UcStairs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gComboBox1);
            this.Controls.Add(this.gCheckStateSkl);
            this.Controls.Add(this.gCheckStateSir);
            this.Controls.Add(this.gCheckStateVys);
            this.Controls.Add(this.gCheckStateLeh);
            this.Controls.Add(this.gButtonShow);
            this.Controls.Add(this.labelSkl);
            this.Controls.Add(this.labelType);
            this.Controls.Add(this.labelTextSkl);
            this.Controls.Add(this.labelSir);
            this.Controls.Add(this.labelTextSir);
            this.Controls.Add(this.labelVys);
            this.Controls.Add(this.labelTextVys);
            this.Controls.Add(this.labelLeh);
            this.Controls.Add(this.labelTextLeh);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UcStairs";
            this.Size = new System.Drawing.Size(617, 159);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTextLeh;
        private GButton gButtonShow;
        private System.Windows.Forms.Label labelTextVys;
        private System.Windows.Forms.Label labelTextSir;
        private System.Windows.Forms.Label labelTextSkl;
        private GCheckState gCheckStateLeh;
        private GCheckState gCheckStateVys;
        private GCheckState gCheckStateSir;
        private GCheckState gCheckStateSkl;
        private System.Windows.Forms.Label labelLeh;
        private System.Windows.Forms.Label labelVys;
        private System.Windows.Forms.Label labelSir;
        private System.Windows.Forms.Label labelSkl;
        private GComboBox gComboBox1;
        private System.Windows.Forms.Label labelType;
    }
}

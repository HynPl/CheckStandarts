namespace CheckStandarts {
    partial class UcRun {
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
            this.labelTextSirRamena = new System.Windows.Forms.Label();
            this.labelTextPocStupnu = new System.Windows.Forms.Label();
            this.labelSirkaRamena = new System.Windows.Forms.Label();
            this.labelPocetSchodu = new System.Windows.Forms.Label();
            this.gCheckStatePocetSchodu = new CheckStandarts.GCheckState();
            this.gCheckStateSirkaRamena = new CheckStandarts.GCheckState();
            this.gButtonShow = new CheckStandarts.GButton();
            this.SuspendLayout();
            // 
            // labelTextSirRamena
            // 
            this.labelTextSirRamena.AutoSize = true;
            this.labelTextSirRamena.Location = new System.Drawing.Point(188, 12);
            this.labelTextSirRamena.Name = "labelTextSirRamena";
            this.labelTextSirRamena.Size = new System.Drawing.Size(92, 17);
            this.labelTextSirRamena.TabIndex = 0;
            this.labelTextSirRamena.Text = "Šířka ramena";
            // 
            // labelTextPocStupnu
            // 
            this.labelTextPocStupnu.AutoSize = true;
            this.labelTextPocStupnu.Location = new System.Drawing.Point(188, 50);
            this.labelTextPocStupnu.Name = "labelTextPocStupnu";
            this.labelTextPocStupnu.Size = new System.Drawing.Size(91, 17);
            this.labelTextPocStupnu.TabIndex = 0;
            this.labelTextPocStupnu.Text = "Počet stupňů";
            // 
            // labelSirkaRamena
            // 
            this.labelSirkaRamena.AutoSize = true;
            this.labelSirkaRamena.Location = new System.Drawing.Point(335, 12);
            this.labelSirkaRamena.Name = "labelSirkaRamena";
            this.labelSirkaRamena.Size = new System.Drawing.Size(92, 17);
            this.labelSirkaRamena.TabIndex = 0;
            this.labelSirkaRamena.Text = "Šířka ramena";
            // 
            // labelPocetSchodu
            // 
            this.labelPocetSchodu.AutoSize = true;
            this.labelPocetSchodu.Location = new System.Drawing.Point(335, 50);
            this.labelPocetSchodu.Name = "labelPocetSchodu";
            this.labelPocetSchodu.Size = new System.Drawing.Size(91, 17);
            this.labelPocetSchodu.TabIndex = 0;
            this.labelPocetSchodu.Text = "Počet stupňů";
            // 
            // gCheckStatePocetSchodu
            // 
            this.gCheckStatePocetSchodu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gCheckStatePocetSchodu.BackColor = System.Drawing.Color.Transparent;
            this.gCheckStatePocetSchodu.Location = new System.Drawing.Point(568, 41);
            this.gCheckStatePocetSchodu.Name = "gCheckStatePocetSchodu";
            this.gCheckStatePocetSchodu.Size = new System.Drawing.Size(32, 32);
            this.gCheckStatePocetSchodu.TabIndex = 2;
            this.gCheckStatePocetSchodu.TabStop = false;
            this.gCheckStatePocetSchodu.Click += new System.EventHandler(this.GCheckStatePocStupnu_Click);
            // 
            // gCheckStateSirkaRamena
            // 
            this.gCheckStateSirkaRamena.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gCheckStateSirkaRamena.BackColor = System.Drawing.Color.Transparent;
            this.gCheckStateSirkaRamena.Location = new System.Drawing.Point(568, 3);
            this.gCheckStateSirkaRamena.Name = "gCheckStateSirkaRamena";
            this.gCheckStateSirkaRamena.Size = new System.Drawing.Size(32, 32);
            this.gCheckStateSirkaRamena.TabIndex = 2;
            this.gCheckStateSirkaRamena.TabStop = false;
            this.gCheckStateSirkaRamena.Click += new System.EventHandler(this.GCheckStateSirRamena_Click);
            // 
            // gButtonShow
            // 
            this.gButtonShow.BackColor = System.Drawing.Color.Transparent;
            this.gButtonShow.Disamble = false;
            this.gButtonShow.Location = new System.Drawing.Point(37, 21);
            this.gButtonShow.Name = "gButtonShow";
            this.gButtonShow.SetOrientation = CheckStandarts.GButton.Orientation.Center;
            this.gButtonShow.Size = new System.Drawing.Size(108, 36);
            this.gButtonShow.TabIndex = 1;
            this.gButtonShow.Text = "Show";
            this.gButtonShow.Click += new System.EventHandler(this.GButtonShow_Click);
            // 
            // UcRun
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gCheckStatePocetSchodu);
            this.Controls.Add(this.gCheckStateSirkaRamena);
            this.Controls.Add(this.gButtonShow);
            this.Controls.Add(this.labelPocetSchodu);
            this.Controls.Add(this.labelTextPocStupnu);
            this.Controls.Add(this.labelSirkaRamena);
            this.Controls.Add(this.labelTextSirRamena);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UcRun";
            this.Size = new System.Drawing.Size(617, 78);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTextSirRamena;
        private GButton gButtonShow;
        private System.Windows.Forms.Label labelTextPocStupnu;
        private GCheckState gCheckStateSirkaRamena;
        private GCheckState gCheckStatePocetSchodu;
        private System.Windows.Forms.Label labelSirkaRamena;
        private System.Windows.Forms.Label labelPocetSchodu;
    }
}

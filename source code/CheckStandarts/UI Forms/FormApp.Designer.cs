namespace CheckStandarts {
    partial class FormApp {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormApp));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonRecheck = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonExport = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonHelp = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gBar1 = new CheckStandarts.GBar();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelOK = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelWarling = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelWrong = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonRecheck,
            this.toolStripButtonExport,
            this.toolStripButton1,
            this.toolStripButtonHelp});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(825, 50);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonRecheck
            // 
            this.toolStripButtonRecheck.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.toolStripButtonRecheck.Image = global::CheckStandarts.Properties.Resources.BigRefresh;
            this.toolStripButtonRecheck.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRecheck.Name = "toolStripButtonRecheck";
            this.toolStripButtonRecheck.Size = new System.Drawing.Size(62, 47);
            this.toolStripButtonRecheck.Text = "Recheck";
            this.toolStripButtonRecheck.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonRecheck.Click += new System.EventHandler(this.ToolStripButtonRecheck_Click);
            // 
            // toolStripButtonExport
            // 
            this.toolStripButtonExport.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.toolStripButtonExport.Image = global::CheckStandarts.Properties.Resources.excel;
            this.toolStripButtonExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonExport.Name = "toolStripButtonExport";
            this.toolStripButtonExport.Size = new System.Drawing.Size(52, 47);
            this.toolStripButtonExport.Text = "Export";
            this.toolStripButtonExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonExport.Click += new System.EventHandler(this.ToolStripButtonExport_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.toolStripButton1.Image = global::CheckStandarts.Properties.Resources.Setting;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(62, 47);
            this.toolStripButton1.Text = "Settings";
            this.toolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton1.Click += new System.EventHandler(this.ToolStripButton1_Click);
            // 
            // toolStripButtonHelp
            // 
            this.toolStripButtonHelp.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.toolStripButtonHelp.Image = global::CheckStandarts.Properties.Resources.Help;
            this.toolStripButtonHelp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonHelp.Name = "toolStripButtonHelp";
            this.toolStripButtonHelp.Size = new System.Drawing.Size(41, 47);
            this.toolStripButtonHelp.Text = "Help";
            this.toolStripButtonHelp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonHelp.Click += new System.EventHandler(this.ToolStripButtonSettings_Click_1);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel1.Controls.Add(this.gBar1);
            this.panel1.Location = new System.Drawing.Point(0, 50);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(825, 403);
            this.panel1.TabIndex = 1;
            // 
            // gBar1
            // 
            this.gBar1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gBar1.Location = new System.Drawing.Point(360, 182);
            this.gBar1.Margin = new System.Windows.Forms.Padding(4);
            this.gBar1.Name = "gBar1";
            this.gBar1.Size = new System.Drawing.Size(100, 28);
            this.gBar1.TabIndex = 2;
            this.gBar1.TabStop = false;
            this.gBar1.Text = "gBar1";
            this.gBar1.Value = 0F;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabelOK,
            this.toolStripStatusLabelWarling,
            this.toolStripStatusLabelWrong});
            this.statusStrip1.Location = new System.Drawing.Point(0, 454);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.ShowItemToolTips = true;
            this.statusStrip1.Size = new System.Drawing.Size(825, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(696, 17);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.Text = "Načítání";
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabelOK
            // 
            this.toolStripStatusLabelOK.AutoToolTip = true;
            this.toolStripStatusLabelOK.Image = global::CheckStandarts.Properties.Resources.Done;
            this.toolStripStatusLabelOK.Name = "toolStripStatusLabelOK";
            this.toolStripStatusLabelOK.Size = new System.Drawing.Size(26, 17);
            this.toolStripStatusLabelOK.Text = " ";
            this.toolStripStatusLabelOK.ToolTipText = "Correct";
            // 
            // toolStripStatusLabelWarling
            // 
            this.toolStripStatusLabelWarling.AutoToolTip = true;
            this.toolStripStatusLabelWarling.Image = global::CheckStandarts.Properties.Resources.Warning;
            this.toolStripStatusLabelWarling.Name = "toolStripStatusLabelWarling";
            this.toolStripStatusLabelWarling.Size = new System.Drawing.Size(26, 17);
            this.toolStripStatusLabelWarling.Text = " ";
            this.toolStripStatusLabelWarling.ToolTipText = "Warlings";
            // 
            // toolStripStatusLabelWrong
            // 
            this.toolStripStatusLabelWrong.AutoToolTip = true;
            this.toolStripStatusLabelWrong.Image = global::CheckStandarts.Properties.Resources.Wrong;
            this.toolStripStatusLabelWrong.Name = "toolStripStatusLabelWrong";
            this.toolStripStatusLabelWrong.Size = new System.Drawing.Size(26, 17);
            this.toolStripStatusLabelWrong.Text = " ";
            this.toolStripStatusLabelWrong.ToolTipText = "Wrong";
            // 
            // FormApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(825, 476);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(516, 222);
            this.Name = "FormApp";
            this.Text = "Checker";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormApp_FormClosing);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonRecheck;
        private System.Windows.Forms.ToolStripButton toolStripButtonHelp;
        private System.Windows.Forms.ToolStripButton toolStripButtonExport;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private GBar gBar1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelOK;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelWarling;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelWrong;
        public System.Windows.Forms.Panel panel1;
    }
}
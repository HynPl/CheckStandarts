namespace CheckStandarts {
    partial class GComboBox {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing&&(components!=null)) {
                //if (timer.Enabled)timer.Stop();
                //timer?.Dispose();
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
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.comboBox = new CheckStandarts.GPreComboBox();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // comboBox
            // 
            this.comboBox.BackColor = System.Drawing.Color.Transparent;
            this.comboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox.Items = new string[0];
            this.comboBox.Location = new System.Drawing.Point(0, 0);
            this.comboBox.Name = "comboBox";
            this.comboBox.SelectedIndex = -1;
            this.comboBox.Size = new System.Drawing.Size(227, 30);
            this.comboBox.TabIndex = 6;
            this.comboBox.TabStop = false;
            this.comboBox.Text = "comboBox";
            this.comboBox.Click += new System.EventHandler(this.GPreComboBox1_Click);
            // 
            // GComboBox
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.comboBox);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Name = "GComboBox";
            this.Size = new System.Drawing.Size(227, 30);
            this.Move += new System.EventHandler(this.AdvancedComboBox_Resize);
            this.Resize += new System.EventHandler(this.AdvancedComboBox_Resize);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        public GPreComboBox comboBox;
    }
}

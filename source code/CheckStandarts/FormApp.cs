using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Form = System.Windows.Forms.Form;

namespace CheckStandarts {
    public partial class FormApp : Form {

        // Controls display elements
       // readonly List<WarlingUserControl> ucWaringsPanel;

        // Background task
        BackgroundWorker backgroundWorkerCheck;

        // Background task finished, change controls
        public delegate void DelResetUI();
        public DelResetUI delUITread;

        // Form settings
        FormSettings fs;

        public FormApp() {
            InitializeComponent();

            // Set manager of warlings
          //  ucWaringsPanel=new List<WarlingUserControl>();
            WarlingUserControl.Init(panel1);

            // Set language
            toolStripButtonRecheck.Text=Setting.Lang.Recheck;
            toolStripButtonExport.Text=Setting.Lang.Export;
            toolStripButtonHelp.Text=Setting.Lang.Settings;
            toolStripButtonHelp.Text=Setting.Lang.HelpIcon;
            Text=Setting.Lang.AppName;
            toolStripStatusLabel1.Text=Setting.Lang.Done;
            NewCheck();

            delUITread = new DelResetUI(ResetVisibility);
        }

        // Start new check;
        public void NewCheck(){ 
            panel1.Visible=false;
            gBar1.Visible=true;

            // init and calculate elements number for progress
            ElementsCheckData.Init();
            ElementsCheckData.PreCheck();

            // Background task
            backgroundWorkerCheck=new BackgroundWorker();
            backgroundWorkerCheck.DoWork += BackgroundWorker_DoWork;
            backgroundWorkerCheck.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;
            ElementsCheckData.Progress+=ProgressReport;
            backgroundWorkerCheck.RunWorkerAsync();
            toolStripStatusLabel1.Text=Setting.Lang.Checking;
        }

        // recheck complete
        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            panel1.Invoke(delUITread);
        }

        void ResetVisibility() {
            panel1.Visible=true;
            gBar1.Visible=false;   
            
            int ok=0, wrong=0, warling=0;
            string stats=ElementsCheckData.GetStatus(ref ok, ref warling, ref wrong);

            toolStripStatusLabel1.Text=stats;
            toolStripStatusLabelOK.Text=ok.ToString()+" ";
            toolStripStatusLabelWarling.Text=warling.ToString()+" ";
            toolStripStatusLabelWrong.Text=wrong.ToString();

            // set on panel controls
            WarlingUserControl.ReSetControls();           
        }

        // Progress
        private void ProgressReport(object sender, EventProgress e) {
            gBar1.Value=e.Progress;
        }

        // Rechecking on the background
        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e) {
            ElementsCheckData.RunCheck();
        }

        // Set new controls base of check data
        //public void ReSetControls() { 
        //    ClearWarlings();
        //    int posY=1;
        //    panel1.SuspendLayout();
        //    foreach (CheckObject s in ElementsCheckData.ElementChecks) {
        //        if (s is ElementCheckStairs str) { 
        //            WarlingUserControl warling=new WarlingUserControl();
        //            warling.CreateCollapse(posY,s);

        //            //UcStairs conStairs = new UcStairs {
        //            //    Location = new System.Drawing.Point(0, posY),
        //            //    Size = new Size(Width-16, 166),
        //            //    Anchor=AnchorStyles.Left|AnchorStyles.Top|AnchorStyles.Right,
        //            //};

        //            //conStairs.SetCheckObject(str);
        //            //conStairs.ChangedCollapsed+= ChangedElement; 
        //            ucWaringsPanel.Add(warling);
        //            //panel1.Controls.Add(warling.gCollapse);
        //            //panel1.Controls.Add(warling.controlPanel as UserControl);

        //            posY+=warling.GetHeight();
        //        }                
        //    }
        //    panel1.AutoScrollMinSize=new Size(0,posY);
        //    panel1.ResumeLayout();
        //}

        //public void ReSetControlPos() { 
        //    int posY=1;
        //    foreach (WarlingUserControl s in ucWaringsPanel) {
        //        s.SetNewPosY(posY);             
        //        posY+=s.GetHeight();
        //    }
        //    panel1.AutoScrollMinSize=new Size(0,posY);
        //}

        //private void ChangedElement(object sender, System.EventArgs e) {
        //    ReSetControlPos();
        //}
        
        //public void ClearWarlings(){ 
        //    foreach (WarlingUserControl s in ucWaringsPanel) {
        //        s.Disponse();
        //        panel1.Controls.Remove(s.gCollapse);
        //        panel1.Controls.Remove(s.controlPanel as UserControl);
        //    }
        //    ucWaringsPanel.Clear();
        //}


        // Settings
        private void ToolStripButtonSettings_Click(object sender, System.EventArgs e) {
            if (fs==null) { 
                fs=new FormSettings();
            }
            
            fs.ShowDialog();
        }

        // Export
        private void ToolStripButtonExport_Click(object sender, System.EventArgs e) {
            FolderBrowserDialog sfd=new FolderBrowserDialog();
            DialogResult dr =sfd.ShowDialog();
            string path=sfd.SelectedPath;
            if (dr==DialogResult.OK) { 
                if (Directory.Exists(path)) { 
                    ElementsCheckData.Export(path);
                }   
            }
        }

        // Recheck
        private void ToolStripButtonRecheck_Click(object sender, EventArgs e) {
            NewCheck();
        }

        // Help button
        private void ToolStripButtonSettings_Click_1(object sender, System.EventArgs e) {
            FormMessage fm=new FormMessage("",Setting.Lang.Help);            
            fm.ShowDialog();
        }

        // Settings open
        private void ToolStripButton1_Click(object sender, EventArgs e) {
            FormSettings fs=new FormSettings();
            fs.ShowDialog();
        }

        // Save when close form
        private void FormApp_FormClosing(object sender, FormClosingEventArgs e) {
            ElementsCheckData.Save();
        }
    }
}
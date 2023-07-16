using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Panel = System.Windows.Forms.Panel;
using Point = System.Drawing.Point;

namespace CheckStandarts {
    class WarlingUserControl{ 
        public GCollapse gCollapse;
        public UcGeneralPanel controlPanel;
        public bool Collapse=true;
        CheckObject obj;
        event EventHandler ChangedHeight;
        WarlingUserControl Parent;
        const int Offset=16;
    //    int index;

        public void CreateCollapse(int posY, CheckObject obj) {
            int offset=Parent==null ? 0 : Offset;
            gCollapse = new GCollapse {
                Location = new Point(offset, posY),
                Size = new Size(panel.Width-1-offset, 37),
                Anchor=AnchorStyles.Left|AnchorStyles.Top|AnchorStyles.Right,
            };
            gCollapse.Click += GCollapse_Click;
            gCollapse.currentState=obj.Worst;
            gCollapse.Text=obj.GetInfo();                
                  
            panel.Controls.Add(gCollapse);
            this.obj=obj;
            ChangedHeight+=(object sender, EventArgs e)=> {
                ReSetControlPos(/*index,gCollapse.Location.Y-panel.AutoScrollOffset.Y*/);
            };
        }

        // Switch collapsed form
        void GCollapse_Click(object sender, EventArgs e) {
            if (Collapse) { 
                if (controlPanel==null) PanelCreate();
                else PanelOpen();
                Collapse=false;
            } else {    
                PanelClose();
                Collapse=true;                
            }
            gCollapse.SetCollapse=Collapse;
            ChangedHeight.Invoke(this, e);

            void PanelClose() {
                controlPanel.Visible=false;
            }

            void PanelOpen() {
                controlPanel.Visible=true;
            }

            void PanelCreate() {                
                switch (obj) {
                    case ElementCheckStairs _:
                        //UcStairs ucStairs = new UcStairs {
                        //    Location = new Point(0, gCollapse.Location.Y + gCollapse.Height),
                        //    Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right
                        //};
                        //ucStairs.Size = new Size(gCollapse.Width, ucStairs.Height);

                        //ucStairs.SetCheckObject(obj);
                        //controlPanel=ucStairs;
                        UcGeneralPanel ucStairs = new UcGeneralPanel(obj) {
                            Location = new Point(0, gCollapse.Location.Y + gCollapse.Height),
                            Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right
                        };
                        ucStairs.Size = new Size(gCollapse.Width, ucStairs.Height);

                       // ucStairs.SetCheckObject();
                        controlPanel=ucStairs;
                        break;

                    case ElementCheckStairsRuns _:
                        UcGeneralPanel panel=new UcGeneralPanel(obj){
                         Location = new Point(/*Offset*/0, gCollapse.Location.Y + gCollapse.Height),
                            Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right
                        };
                         panel.Size = new Size(gCollapse.Width, panel.Height);
                        //panel.butt=true;
                        //UcRun ucRun = new UcRun {
                        //    Location = new Point(Offset, gCollapse.Location.Y + gCollapse.Height),
                        //    Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right
                        //};
                        //ucRun.Size = new Size(gCollapse.Width, ucRun.Height);

                        //controlPanel=ucRun;
                        controlPanel=panel;
                        break;

                    default:
                        throw new Exception();

                }
                //controlPanel.SetCheckObject(obj);
                panel.Controls.Add(controlPanel as UserControl);
            }
        }

        public void SetNewPosY(int y) { 
            gCollapse.Location=new Point(gCollapse.Location.X,y);

            if (!Collapse) controlPanel.Location=new Point(gCollapse.Location.X, y+gCollapse.Height);
        }
        
        public int GetHeight() { 
            if (Collapse) return gCollapse.Height;
            else return gCollapse.Height + controlPanel.Height;
        }

        public void Disponse() { 
            gCollapse?.Dispose();
            controlPanel?.Dispose();
        }

        // Static management
        static List<WarlingUserControl> ucWaringsPanel;
        static Panel panel;

        public static void Init(Panel cPanel) { 
            ucWaringsPanel=new List<WarlingUserControl>();
            panel=cPanel;
        }

        public static void ReSetControlPos(/*int start, int posYStart*/) { 
            int posY=1/*+panel.AutoScrollOffset.Y*/;
            Point posScroll=panel.AutoScrollPosition;
            panel.AutoScrollPosition=Point.Empty;
            panel.AutoScrollOffset=Point.Empty;
            panel.AutoScrollMinSize=new Size(0, 0);
            for (int i=0; i<ucWaringsPanel.Count; i++){
                WarlingUserControl s = ucWaringsPanel[i];
                s.SetNewPosY(posY);             
                posY+=s.GetHeight();
            }
             panel.AutoScrollPosition=posScroll;
            panel.AutoScrollMinSize=new Size(0, posY);
        }

        public static void ClearWarlings(){ 
            foreach (WarlingUserControl s in ucWaringsPanel) {
                s.Disponse();
                panel.Controls.Remove(s.gCollapse);
                panel.Controls.Remove(s.controlPanel as UserControl);
            }
            ucWaringsPanel.Clear();
        }

        public static void ReSetControls() { 
            ClearWarlings();
            int posY=1;
            panel.AutoScrollOffset=Point.Empty;
            panel.AutoScrollMinSize=Size.Empty;//=new Size(0,0);
            panel.SuspendLayout();
          //  int index=0;

            foreach (CheckObject s in ElementsCheckData.ElementChecks) {
                if (s is ElementCheckStairs str) { 
                    WarlingUserControl warling=new WarlingUserControl();
                    warling.CreateCollapse(posY, s); 
                    ucWaringsPanel.Add(warling);
                   // warling.index=index;
                    posY+=warling.GetHeight();

                    foreach (ElementCheckStairsRuns run in str.Runs) {
                        WarlingUserControl warlingDep = new WarlingUserControl {
                            Parent = warling
                        };
                    //    warlingDep.index=index;  
                        warlingDep.CreateCollapse(posY, run);
                        ucWaringsPanel.Add(warlingDep);

                        posY+=warlingDep.GetHeight();
                    }
                }                
            }
            panel.ResumeLayout();
            panel.AutoScrollMinSize=new Size(0,posY);
        }

        //private void ChangedElementHeight(object sender, EventArgs e) {
        //    ReSetControlPos();
        //}
    }
}

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CheckStandarts {
    public partial class GComboBox:UserControl {

        public string PlaceHolder;
        public event EventHandler SelectedIndexChanged;

        // Is contextmenustrip shown
        bool Shown;

        public GComboBox() {
            InitializeComponent();
            DoubleBuffered=true;

            AdvancedComboBox_Resize(this,new EventArgs());
        }

        // Set minimum width
        void AdvancedComboBox_Resize(object sender, EventArgs e) {
            if (Width<7)Width=7;
        }

        // Show contextmenustrip
        private void GPreComboBox1_Click(object sender, EventArgs e) {
            if (!(LicenseManager.UsageMode == LicenseUsageMode.Designtime)) {
               if (!Shown) {
                    contextMenuStrip1.Items.Clear();
                    if (comboBox.Items.Length==0) {
                        ToolStripMenuItem item = new ToolStripMenuItem {
                            Text = "",
                            BackColor = Color.White
                        };
                        contextMenuStrip1.Items.Add(item);                  
                    } else {
                        for (int i=0; i<comboBox.Items.Length; i++){
                            string s = comboBox.Items[i] ;
                            ToolStripMenuItem item = new ToolStripMenuItem {
                                Text = s,
                                BackColor = Color.White
                            };
                            Font f=new Font(Font, FontStyle.Bold);
                    
                            if (i==0) item.Font=f;
                            else item.Font=Font;
                            contextMenuStrip1.Items.Add(item);
                            int ii=i;
                            item.Click += Item_Click;
                            void Item_Click(object sender2, EventArgs e2) {
                                comboBox.SelectedIndex=ii;
                                SelectedIndexChanged.Invoke(comboBox,e2);
                            }
                        }
                    }
       
                    Point ptLowerLeft = new Point(0+3, comboBox.Height-3);
                    ptLowerLeft = comboBox.PointToScreen(ptLowerLeft);
                    contextMenuStrip1.Closed += ContextMenuStrip1_Closed;
                    Shown=true;
                    contextMenuStrip1.Show(ptLowerLeft); 
                }
            }
        }

        void ContextMenuStrip1_Closed(object sender, ToolStripDropDownClosedEventArgs e) {
             Shown=false;
        }
    }
}
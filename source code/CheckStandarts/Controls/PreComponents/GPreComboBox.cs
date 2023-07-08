using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CheckStandarts {
    public class GPreComboBox : Control {

        // Items
        string[] items;
        int selectedIndex;

        public int SelectedIndex{ 
            get { return selectedIndex;}   
            set { 
                selectedIndex=value;
                if (items!=null) {
                    if (selectedIndex>=Items.Length) selectedIndex=Items.Length-1;
                }
                Invalidate();
            }
        }

        public string SelectedText{
            get { 
                //#if DEBUG
                //if (SelectedIndex<0) return "{SelectedIndex}";
                //if (Items.Length==0) return "{Items.Length==0}";
                //#else
                if (SelectedIndex<0) return "";
                if (Items.Length==0) return "";
               // #endif
               
                return Items[SelectedIndex]; 
            }    
        }

        public string[] Items{ 
            get { return items; }
            set { 
                items=value; 
                if (items!=null){
                    if (selectedIndex>=Items.Length) {
                        selectedIndex=Items.Length-1;
                    }
                }
                Invalidate();
            }
        }

        // Graphics
        float v;
        readonly Timer timer;
        public bool drawClearPix;
        public bool Selected=false;
        const int SizeBounds=20;
        readonly Image imageDown;

        public GPreComboBox() {
            items=new string[0];
            selectedIndex=-1;
            TabStop=false;
		    ResizeRedraw = true;
		    DoubleBuffered = true;
		    SetStyle(ControlStyles.UserPaint, true);
		    SetStyle(ControlStyles.SupportsTransparentBackColor,true);
		    BackColor=Color.Transparent;
            (timer=new Timer {
                Interval=35,
                Enabled=true
            }).Tick+=Timer_Tick;
            imageDown=Properties.Resources.down;
	    }

        private void Timer_Tick(object sender, EventArgs e) {
            if (IsDisposed) timer.Stop();
            float z=v;

            if (Selected) {
                if (v<1) v+=0.09f+v/6f;
            } else {
                if (v>0) v-=0.09f+v/6f;
            }

            if (v<0)v=0;
            if (v>1)v=1;

            if (v!=z) Invalidate();
        }

	    protected override void OnResize(EventArgs e) {
		    base.OnResize(e);
		    Refresh();
	    }

        protected override void OnMouseHover(EventArgs e) {
		    base.OnResize(e);
		    Selected=true;
	    }

        protected override void OnMouseLeave(EventArgs e) {
		    base.OnResize(e);
		    Selected=false;
	    }

	    protected override void OnPaint(PaintEventArgs e) {
		    Graphics g=e.Graphics;
            g.InterpolationMode=InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode=PixelOffsetMode.HighQuality;
            g.SmoothingMode=SmoothingMode.AntiAlias;
           // g.PixelOffsetMode=PixelOffsetMode.HighQuality;

            int grayIndex=200;
            Color c=Color.FromArgb(0/*(int)(159+(grayIndex-159)*v)*/, (int)((grayIndex)*v*136/255f), (int)(grayIndex*v));
                         

            for (float f=0; f<5; f+=0.25f) NativeMethods.FillRoundedRectangle(g,new SolidBrush(Color.FromArgb((int)((f*3+0.8f)*f+7+v),c)),new RectangleF(f, f, Size.Width-f*2-1, Size.Height-f*2-1),5);

          //  g.PixelOffsetMode=PixelOffsetMode.None;
          //  g.SmoothingMode=SmoothingMode.None;
          //  g.InterpolationMode=InterpolationMode.NearestNeighbor;

            // draw back

            NativeMethods.FillRoundedRectangle(g, new SolidBrush(Color.White),new Rectangle(3, 3, Size.Width-7, Size.Height-7),4);

      //      if (drawClearPix) {
      //          g.FillRectangle(new SolidBrush(Color.FromArgb(129,255,255,255)),new Rectangle(3,4,1,1));
      //          g.FillRectangle(new SolidBrush(Color.FromArgb(219,255,255,255)),new Rectangle(3,5,1,1));

      //          g.FillRectangle(new SolidBrush(Color.FromArgb(129,255,255,255)),new Rectangle(4,3,1,1));
      //          g.FillRectangle(new SolidBrush(Color.FromArgb(219,255,255,255)),new Rectangle(5,3,1,1));

      //          g.FillRectangle(new SolidBrush(Color.FromArgb(129,255,255,255)),new Rectangle(Width-3+2-1-3,4,1,1));
      //          g.FillRectangle(new SolidBrush(Color.FromArgb(219,255,255,255)),new Rectangle(Width-3-1+2-3,5,1,1));

      //          g.FillRectangle(new SolidBrush(Color.FromArgb(129,255,255,255)),new Rectangle(Width-4-1+2-3,3,1,1));
      //          g.FillRectangle(new SolidBrush(Color.FromArgb(219,255,255,255)),new Rectangle(Width-5-1+2-3,3,1,1));


      //          g.FillRectangle(new SolidBrush(Color.FromArgb(129,255,255,255)),new Rectangle(Width-3-1+2-3,Height-4+1-3,1,1));
      //          g.FillRectangle(new SolidBrush(Color.FromArgb(219,255,255,255)),new Rectangle(Width-3-1+2-3,Height-5+1-3,1,1));

      //          g.FillRectangle(new SolidBrush(Color.FromArgb(129,255,255,255)),new Rectangle(Width-4-1+2-3,Height-3+1-3,1,1));
      //          g.FillRectangle(new SolidBrush(Color.FromArgb(219,255,255,255)),new Rectangle(Width-5-1+2-3,Height-3+1-3,1,1));


      //          g.FillRectangle(new SolidBrush(Color.FromArgb(129,255,255,255)),new Rectangle(3,Height-4+1-3,1,1));
      //          g.FillRectangle(new SolidBrush(Color.FromArgb(219,255,255,255)),new Rectangle(3,Height-5+1-3,1,1));

      //          g.FillRectangle(new SolidBrush(Color.FromArgb(129,255,255,255)),new Rectangle(4,Height-3+1-3,1,1));
      //          g.FillRectangle(new SolidBrush(Color.FromArgb(219,255,255,255)),new Rectangle(5,Height-3+1-3,1,1));
		    //}
            //Brush b=new SolidBrush(Color.FromArgb(255, 255, 255));
            // SizeBounds3=SizeBounds/3,
            //    SizeBounds6=SizeBounds/6,
               int SizeBounds2=SizeBounds/2;
            //Rectangle buttonSize=new Rectangle(3,3,Width-6,Height-6);
            //int locX=3, locY=3;
              //Inside
            //g.FillEllipse(b, new Rectangle(buttonSize.Width-SizeBounds3-1+locX, 0+locY, SizeBounds3, SizeBounds3));
            //g.FillEllipse(b, new Rectangle(buttonSize.Width-SizeBounds3-1+locX, buttonSize.Height - SizeBounds3 - 1+locY, SizeBounds3, SizeBounds3));
            //g.FillRectangle(b, buttonSize.Width-SizeBounds3-1+locX, SizeBounds6+locY, SizeBounds2, buttonSize.Height-SizeBounds3);

            //g.FillEllipse(b, new Rectangle(0+locX, 0+locY, SizeBounds3, SizeBounds3));
            //g.FillEllipse(b, new Rectangle(0+locX, buttonSize.Height - SizeBounds3 - 1+locY, SizeBounds3, SizeBounds3));
            //g.FillRectangle(b, 0, SizeBounds6+locX, SizeBounds2+locY, buttonSize.Height-SizeBounds3);


            //g.FillRectangle(b, SizeBounds6+locX, 0+locY, buttonSize.Width-SizeBounds3, buttonSize.Height-1);

   //         // Bounds
   //         g.DrawLine(sb, SizeBounds6, 0, buttonSize.Width-SizeBounds6, 0);
			//g.DrawLine(sb, buttonSize.Width - 1, SizeBounds6, buttonSize.Width -1, buttonSize.Height-SizeBounds6);
			//g.DrawLine(sb, SizeBounds6, buttonSize.Height - 1, buttonSize.Width-SizeBounds6, buttonSize.Height - 1);
			//g.DrawLine(sb, 0, SizeBounds6, 0, buttonSize.Height - SizeBounds6 - 1);

   //         g.SmoothingMode = SmoothingMode.HighQuality;
   //         g.DrawArc(sb, new Rectangle(buttonSize.Width-SizeBounds3-1, 0, SizeBounds3, SizeBounds3/**/), 270F, 90F);
   //         g.DrawArc(sb, new Rectangle(buttonSize.Width-SizeBounds3-1, buttonSize.Height-SizeBounds3-1, SizeBounds3, SizeBounds3/**/),0F,  90F);
   //         g.DrawArc(sb, new Rectangle(0, 0, SizeBounds3, SizeBounds3/**/), 180F, 90F);
   //         g.DrawArc(sb, new Rectangle(0, buttonSize.Height-SizeBounds3-1, SizeBounds3, SizeBounds3/**/),90F,  90F);
            //break;

            NativeMethods.Text(g, SelectedText, SizeBounds2, 4,new SolidBrush(Color.Black));

            g.DrawImage(imageDown,new Point(Width-24,4));
        }
        protected override void Dispose(bool disposing) {
            if (timer.Enabled)timer.Stop();
            timer?.Dispose();
            //ms.Dispose();
            base.Dispose(disposing);
        }
    }
}
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CheckStandarts {
    public class GCheckState : Control {

        Point point=Point.Empty;
        public State state;

        public enum State :byte {
            Unknown,
		    OK,
            Warling,
		    Wrong,
	    }

        public GCheckState() {
            TabStop=false;
		    ResizeRedraw = true;
		    DoubleBuffered = true;
		    SetStyle(ControlStyles.UserPaint, true);
		    SetStyle(ControlStyles.SupportsTransparentBackColor,true);
            BackColor=Color.Transparent;  
      //      bool designMode = (LicenseManager.UsageMode == LicenseUsageMode.Designtime);
         //   if (designMode)BackColor=Color.Gray; 
		    //else 
            Width=32;
            Height=32;
	    }

	    protected override void OnResize(EventArgs e) {
            Width=32;
            Height=32;
		    base.OnResize(e);
		    Refresh();
	    }

	    protected override void OnPaint(PaintEventArgs e) {
		    Graphics g=e.Graphics;
          //  g.InterpolationMode=InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode=PixelOffsetMode.HighQuality;

            Image image=null;

            switch (state) {
                case State.Warling:
                    image=Properties.Resources.Warning;
                    break;

                case State.OK:
                    image=Properties.Resources.Done;
                    break;

                case State.Wrong:
                    image=Properties.Resources.Wrong;
                    break;
            }
            if (image!=null) g.DrawImage(image, new Rectangle (point.X,point.Y, 32,32));
        }

        protected override void Dispose(bool disposing) {
            base.Dispose(disposing);
        }
    }
}
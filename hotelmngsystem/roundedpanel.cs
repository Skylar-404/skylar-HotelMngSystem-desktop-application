using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace hotelmngsystem
{
        public class RoundedPanel : Panel
        {
            public int CornerRadius { get; set; } = 20;

            public RoundedPanel()
            {
                this.DoubleBuffered = true;
                this.ResizeRedraw = true;
            }

            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);

                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                using (GraphicsPath path = GetRoundedPath(ClientRectangle, CornerRadius))
                {
                    this.Region = new Region(path);

                    using (Pen pen = new Pen(Color.LightGray, 1))
                    {
                        e.Graphics.DrawPath(pen, path);
                    }
                }
            }

            private GraphicsPath GetRoundedPath(Rectangle rect, int radius)
            {
                GraphicsPath path = new GraphicsPath();

                int diameter = radius * 2;

                path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
                path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);
                path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
                path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);

                path.CloseFigure();

                return path;
            }
        }
    
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace hotelmngsystem
{
    public class RoundedButton : Button
    {
        private int borderRadius = 20;
        private int borderSize = 0;
        private Color borderColor = Color.Transparent;

        private Color normalColor = Color.DodgerBlue;
        private Color hoverColor = Color.RoyalBlue;
        private Color pressedColor = Color.MediumBlue;

        private bool isHovered = false;
        private bool isPressed = false;

        public int BorderRadius
        {
            get { return borderRadius; }
            set
            {
                borderRadius = value;
                UpdateRegion();
                Invalidate();
            }
        }

        public int BorderSize
        {
            get { return borderSize; }
            set
            {
                borderSize = value;
                Invalidate();
            }
        }

        public Color BorderColor
        {
            get { return borderColor; }
            set
            {
                borderColor = value;
                Invalidate();
            }
        }

        public Color NormalColor
        {
            get { return normalColor; }
            set
            {
                normalColor = value;
                Invalidate();
            }
        }

        public Color HoverColor
        {
            get { return hoverColor; }
            set
            {
                hoverColor = value;
                Invalidate();
            }
        }

        public Color PressedColor
        {
            get { return pressedColor; }
            set
            {
                pressedColor = value;
                Invalidate();
            }
        }

        public RoundedButton()
        {
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;

            BackColor = normalColor;
            ForeColor = Color.White;

            Font = new Font("Segoe UI", 10F, FontStyle.Regular);

            Cursor = Cursors.Hand;

            SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.ResizeRedraw,
                true
            );

            MouseEnter += RoundedButton_MouseEnter;
            MouseLeave += RoundedButton_MouseLeave;
            MouseDown += RoundedButton_MouseDown;
            MouseUp += RoundedButton_MouseUp;
        }

        private void RoundedButton_MouseEnter(object sender, EventArgs e)
        {
            isHovered = true;
            Invalidate();
        }

        private void RoundedButton_MouseLeave(object sender, EventArgs e)
        {
            isHovered = false;
            isPressed = false;
            Invalidate();
        }

        private void RoundedButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isPressed = true;
                Invalidate();
            }
        }

        private void RoundedButton_MouseUp(object sender, MouseEventArgs e)
        {
            isPressed = false;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = new Rectangle(
                0,
                0,
                Width - 1,
                Height - 1
            );

            using (GraphicsPath path = GetRoundedPath(rect, borderRadius))
            {
                // Background
                Color currentColor = normalColor;

                if (isPressed)
                    currentColor = pressedColor;
                else if (isHovered)
                    currentColor = hoverColor;

                using (SolidBrush brush = new SolidBrush(currentColor))
                {
                    e.Graphics.FillPath(brush, path);
                }

                // Border
                if (borderSize > 0)
                {
                    using (Pen pen = new Pen(borderColor, borderSize))
                    {
                        e.Graphics.DrawPath(pen, path);
                    }
                }
            }

            // Draw text
            TextRenderer.DrawText(
                e.Graphics,
                Text,
                Font,
                rect,
                ForeColor,
                TextFormatFlags.HorizontalCenter |
                TextFormatFlags.VerticalCenter |
                TextFormatFlags.SingleLine
            );
        }

        private GraphicsPath GetRoundedPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();

            int diameter = radius * 2;

            if (diameter > rect.Height)
                diameter = rect.Height;

            if (diameter > rect.Width)
                diameter = rect.Width;

            Rectangle arc = new Rectangle(
                rect.X,
                rect.Y,
                diameter,
                diameter
            );

            // Top-left
            path.AddArc(arc, 180, 90);

            // Top-right
            arc.X = rect.Right - diameter;
            path.AddArc(arc, 270, 90);

            // Bottom-right
            arc.Y = rect.Bottom - diameter;
            path.AddArc(arc, 0, 90);

            // Bottom-left
            arc.X = rect.Left;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();

            return path;
        }

        private void UpdateRegion()
        {
            if (Width <= 0 || Height <= 0)
                return;

            using (GraphicsPath path = GetRoundedPath(
                new Rectangle(0, 0, Width, Height),
                borderRadius))
            {
                Region = new Region(path);
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            UpdateRegion();
            Invalidate();
        }
    }
}

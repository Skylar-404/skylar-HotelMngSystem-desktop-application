using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using hotelmngsystem.DAL;
using hotelmngsystem.Helpers;
using hotelmngsystem.Models;

namespace hotelmngsystem.UI
{
    public partial class loginForm : Form
    {
        public loginForm()
        {
            InitializeComponent();

            FormBorderStyle = FormBorderStyle.None;

            StartPosition = FormStartPosition.CenterScreen;

            ApplyRoundedCorners();

            //this.WindowState = FormWindowState.Maximized;
            //this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private int borderRadius = 20;

        private void ApplyRoundedCorners()
        {
            using (GraphicsPath path = new GraphicsPath())
            {
                int radius = borderRadius;
                int diameter = radius * 2;

                Rectangle rect = new Rectangle(
                    0,
                    0,
                    Width,
                    Height
                );

                path.AddArc(
                    rect.X,
                    rect.Y,
                    diameter,
                    diameter,
                    180,
                    90
                );

                path.AddArc(
                    rect.Right - diameter,
                    rect.Y,
                    diameter,
                    diameter,
                    270,
                    90
                );

                path.AddArc(
                    rect.Right - diameter,
                    rect.Bottom - diameter,
                    diameter,
                    diameter,
                    0,
                    90
                );

                path.AddArc(
                    rect.X,
                    rect.Bottom - diameter,
                    diameter,
                    diameter,
                    90,
                    90
                );

                path.CloseFigure();

                Region = new Region(path);
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            ApplyRoundedCorners();
        }
        //===========================================

        private readonly UserDAL userDAL = new UserDAL();

        private void loginForm_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
            this.AcceptButton = roundedButton1;
        }

        private void roundedButton1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text.Trim();
            string password = textBox2.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                DialogHelper.Warn("Please enter your username and password.", "Sign In");
                return;
            }

            User user;
            try
            {
                user = userDAL.Authenticate(username, password);
            }
            catch (Exception ex)
            {
                DialogHelper.Error("Could not reach the database.\n" + ex.Message, "Sign In");
                return;
            }

            if (user == null)
            {
                DialogHelper.Warn("Invalid username or password.", "Sign In");
                textBox2.Text = "";
                textBox2.Focus();
                return;
            }

            SessionHelper.CurrentUser = user;

            MainForm main = new MainForm();
            main.FormClosed += (s, args) => this.Close();
            this.Hide();
            main.Show();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            //
        }

        private void roundedPanel1_Paint(object sender, PaintEventArgs e)
        {
            //
        }

        private void roundedTextBox1_TextChanged(object sender, EventArgs e)
        {
            //
        } 

        private void roundedButton21_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

using hotelmngsystem.Helpers;
using System;
using System.Windows.Forms;

namespace hotelmngsystem.UI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void roundedButton21_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void roundedButton22_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void roundedButton23_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            StartPosition = FormStartPosition.CenterScreen;
            CenterToScreen();

            // Role-based access: only an EMPLOYER-level account (this app's Admin
            // equivalent) can see and manage employee/user information.
            button7.Visible = SessionHelper.IsAdmin;

            ShowModule(new dashboard());
        }

        private void ShowModule(UserControl module)
        {
            containerPanel.Controls.Clear();
            module.Dock = DockStyle.Fill;
            module.AutoScroll = true;
            containerPanel.Controls.Add(module);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ShowModule(new dashboard());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ShowModule(new reservation());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ShowModule(new guests());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ShowModule(new roomOperation());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowModule(new payment());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ShowModule(new report());
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (!SessionHelper.IsAdmin)
            {
                DialogHelper.Warn("Only an administrator (Employer role) can access user management.");
                return;
            }

            ShowModule(new user());
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (!DialogHelper.Confirm("Are you sure you want to log out?", "Log Out"))
                return;

            SessionHelper.Clear();

            loginForm LoginForm = new loginForm();
            LoginForm.StartPosition = FormStartPosition.CenterScreen;
            LoginForm.FormClosed += (s, args) =>
            {
                Application.Exit();
            };
            LoginForm.Show();

            this.Hide();
        }

       
    }
}

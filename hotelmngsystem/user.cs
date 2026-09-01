using hotelmngsystem.DAL;
using hotelmngsystem.Helpers;
using hotelmngsystem.Models;
using hotelmngsystem.UI;
using System;
using System.Windows.Forms;

namespace hotelmngsystem
{
    public partial class user : UserControl
    {
        private readonly UserDAL userDAL = new UserDAL();

        public user()
        {
            InitializeComponent();

            this.Dock = DockStyle.Fill;
            this.AutoScroll = true;
        }

        private void User_Load(object sender, EventArgs e)
        {
            DataGridViewHelper.Configure(dgvUsers);
            LoadUsers();
        }

        private void LoadUsers()
        {
            dgvUsers.DataSource = userDAL.GetUsers(txtSearch.Text.Trim());

            if (dgvUsers.Columns.Contains("UserID"))
                dgvUsers.Columns["UserID"].Visible = false;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadUsers();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            LoadUsers();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (UserForm frm = new UserForm())
            {
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    LoadUsers();
                }
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int? id = GetSelectedUserId();
            if (id == null)
            {
                DialogHelper.Warn("Please select a user to edit.");
                return;
            }

            User u = userDAL.GetById(id.Value);
            using (UserForm frm = new UserForm(u))
            {
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    LoadUsers();
                }
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int? id = GetSelectedUserId();
            if (id == null)
            {
                DialogHelper.Warn("Please select a user to delete.");
                return;
            }

            if (SessionHelper.CurrentUser != null && SessionHelper.CurrentUser.UserID == id.Value)
            {
                DialogHelper.Warn("You cannot delete your own account while signed in.");
                return;
            }

            if (DialogHelper.Confirm("Delete this user account? This cannot be undone."))
            {
                userDAL.Delete(id.Value);
                LoadUsers();
                DialogHelper.Info("User deleted.");
            }
        }

        private void dgvUsers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                editToolStripMenuItem_Click(sender, e);
            }
        }

        private int? GetSelectedUserId()
        {
            if (dgvUsers.CurrentRow == null) return null;
            object value = dgvUsers.CurrentRow.Cells["UserID"].Value;
            if (value == null) return null;
            return Convert.ToInt32(value);
        }
    }
}

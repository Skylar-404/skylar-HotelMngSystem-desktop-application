using hotelmngsystem.DAL;
using hotelmngsystem.Helpers;
using hotelmngsystem.Models;
using hotelmngsystem.UI;
using System;
using System.Windows.Forms;

namespace hotelmngsystem
{
    public partial class guests : UserControl
    {
        private readonly GuestDAL guestDAL = new GuestDAL();

        public guests()
        {
            InitializeComponent();

            this.Dock = DockStyle.Fill;
            this.AutoScroll = true;
        }

        private void Guests_Load(object sender, EventArgs e)
        {
            DataGridViewHelper.Configure(dgvGuests);
            LoadGuests();
        }

        private void LoadGuests()
        {
            dgvGuests.DataSource = guestDAL.GetGuests(txtSearch.Text.Trim());

            if (dgvGuests.Columns.Contains("GuestID"))
                dgvGuests.Columns["GuestID"].Visible = false;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadGuests();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            LoadGuests();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (GuestForm frm = new GuestForm())
            {
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    LoadGuests();
                }
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int? id = GetSelectedGuestId();
            if (id == null)
            {
                DialogHelper.Warn("Please select a guest to edit.");
                return;
            }

            Guest guest = guestDAL.GetById(id.Value);
            using (GuestForm frm = new GuestForm(guest))
            {
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    LoadGuests();
                }
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int? id = GetSelectedGuestId();
            if (id == null)
            {
                DialogHelper.Warn("Please select a guest to delete.");
                return;
            }

            if (guestDAL.HasReservations(id.Value))
            {
                DialogHelper.Warn("This guest has existing reservations and cannot be deleted.");
                return;
            }

            if (DialogHelper.Confirm("Delete this guest? This cannot be undone."))
            {
                guestDAL.Delete(id.Value);
                LoadGuests();
                DialogHelper.Info("Guest deleted.");
            }
        }

        private void dgvGuests_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                editToolStripMenuItem_Click(sender, e);
            }
        }

        private int? GetSelectedGuestId()
        {
            if (dgvGuests.CurrentRow == null) return null;
            object value = dgvGuests.CurrentRow.Cells["GuestID"].Value;
            if (value == null) return null;
            return Convert.ToInt32(value);
        }
    }
}

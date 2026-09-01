using hotelmngsystem.DAL;
using hotelmngsystem.Helpers;
using hotelmngsystem.Models;
using hotelmngsystem.UI;
using System;
using System.Windows.Forms;

namespace hotelmngsystem
{
    public partial class reservation : UserControl
    {
        private readonly ReservationDAL reservationDAL = new ReservationDAL();

        public reservation()
        {
            InitializeComponent();

            this.Dock = DockStyle.Fill;
            this.AutoScroll = true;
        }

        private void Reservation_Load(object sender, EventArgs e)
        {
            DataGridViewHelper.Configure(dgvReservations);
            LoadReservations();
        }

        private void LoadReservations()
        {
            dgvReservations.DataSource = reservationDAL.GetReservations(txtSearch.Text.Trim());

            if (dgvReservations.Columns.Contains("ReservationID"))
                dgvReservations.Columns["ReservationID"].Visible = false;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadReservations();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            LoadReservations();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ReservationForm frm = new ReservationForm())
            {
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    LoadReservations();
                }
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int? id = GetSelectedReservationId();
            if (id == null)
            {
                DialogHelper.Warn("Please select a reservation to edit.");
                return;
            }

            Reservation res = reservationDAL.GetById(id.Value);
            using (ReservationForm frm = new ReservationForm(res))
            {
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    LoadReservations();
                }
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int? id = GetSelectedReservationId();
            if (id == null)
            {
                DialogHelper.Warn("Please select a reservation to delete.");
                return;
            }

            if (reservationDAL.HasPayments(id.Value))
            {
                DialogHelper.Warn("This reservation has payments recorded and cannot be deleted.");
                return;
            }

            if (DialogHelper.Confirm("Delete this reservation? This cannot be undone."))
            {
                reservationDAL.Delete(id.Value);
                LoadReservations();
                DialogHelper.Info("Reservation deleted.");
            }
        }

        private void checkInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeStatus("CHECKED_IN", "checked in");
        }

        private void checkOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeStatus("CHECKED_OUT", "checked out");
        }

        private void ChangeStatus(string newStatus, string friendlyLabel)
        {
            int? id = GetSelectedReservationId();
            if (id == null)
            {
                DialogHelper.Warn("Please select a reservation.");
                return;
            }

            Reservation res = reservationDAL.GetById(id.Value);
            if (res == null) return;

            if (!DialogHelper.Confirm($"Mark reservation {res.ReservationCode} as {friendlyLabel}?"))
                return;

            res.Status = newStatus;
            reservationDAL.Update(res);
            LoadReservations();
            DialogHelper.Info($"Reservation {friendlyLabel} successfully.");
        }

        private void dgvReservations_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                editToolStripMenuItem_Click(sender, e);
            }
        }

        private int? GetSelectedReservationId()
        {
            if (dgvReservations.CurrentRow == null) return null;
            object value = dgvReservations.CurrentRow.Cells["ReservationID"].Value;
            if (value == null) return null;
            return Convert.ToInt32(value);
        }
    }
}

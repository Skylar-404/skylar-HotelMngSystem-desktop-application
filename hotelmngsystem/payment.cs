using hotelmngsystem.DAL;
using hotelmngsystem.Helpers;
using hotelmngsystem.UI;
using System;
using System.Windows.Forms;

namespace hotelmngsystem
{
    public partial class payment : UserControl
    {
        private readonly PaymentDAL paymentDAL = new PaymentDAL();

        public payment()
        {
            InitializeComponent();

            this.Dock = DockStyle.Fill;
            this.AutoScroll = true;
        }

        private void Payment_Load(object sender, EventArgs e)
        {
            DataGridViewHelper.Configure(dgvPayments);
            LoadPayments();
        }

        private void LoadPayments()
        {
            dgvPayments.DataSource = paymentDAL.GetPayments(txtSearch.Text.Trim());

            if (dgvPayments.Columns.Contains("PaymentID"))
                dgvPayments.Columns["PaymentID"].Visible = false;
            if (dgvPayments.Columns.Contains("ReservationID"))
                dgvPayments.Columns["ReservationID"].Visible = false;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadPayments();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            LoadPayments();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (PaymentForm frm = new PaymentForm())
            {
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    LoadPayments();
                }
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int? id = GetSelectedPaymentId();
            if (id == null)
            {
                DialogHelper.Warn("Please select a payment to edit.");
                return;
            }

            // Grid is a projection (joined with reservation/guest), so re-read a light
            // Payment shell from the selected row rather than adding another DAL round trip.
            DataGridViewRow row = dgvPayments.CurrentRow;
            Models.Payment p = new Models.Payment
            {
                PaymentID = id.Value,
                ReservationID = Convert.ToInt32(row.Cells["ReservationID"].Value),
                Amount = Convert.ToDecimal(row.Cells["Amount"].Value),
                PaymentMethod = row.Cells["PaymentMethod"].Value?.ToString(),
                PaymentType = row.Cells["PaymentType"].Value?.ToString(),
                TransactionReference = row.Cells["TransactionReference"].Value?.ToString(),
                PaymentStatus = row.Cells["PaymentStatus"].Value?.ToString()
            };

            using (PaymentForm frm = new PaymentForm(p))
            {
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    LoadPayments();
                }
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int? id = GetSelectedPaymentId();
            if (id == null)
            {
                DialogHelper.Warn("Please select a payment to delete.");
                return;
            }

            if (DialogHelper.Confirm("Delete this payment record? This cannot be undone."))
            {
                paymentDAL.Delete(id.Value);
                LoadPayments();
                DialogHelper.Info("Payment deleted.");
            }
        }

        private void dgvPayments_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Intentionally not editable by double-click; see editToolStripMenuItem_Click note.
        }

        private int? GetSelectedPaymentId()
        {
            if (dgvPayments.CurrentRow == null) return null;
            object value = dgvPayments.CurrentRow.Cells["PaymentID"].Value;
            if (value == null) return null;
            return Convert.ToInt32(value);
        }
    }
}

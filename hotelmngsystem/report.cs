using hotelmngsystem.DAL;
using hotelmngsystem.Helpers;
using System;
using System.Data;
using System.Windows.Forms;

namespace hotelmngsystem
{
    public partial class report : UserControl
    {
        private readonly ReportDAL reportDAL = new ReportDAL();

        public report()
        {
            InitializeComponent();

            this.Dock = DockStyle.Fill;
            this.AutoScroll = true;
        }

        private void Report_Load(object sender, EventArgs e)
        {
            DataGridViewHelper.Configure(dgvReport);

            dtpFrom.Value = DateTime.Today.AddMonths(-1);
            dtpTo.Value = DateTime.Today;
            cmbReportType.SelectedIndex = 0;
        }

        private void cmbReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvReport.DataSource = null;
            lblSummary.Text = "Select a date range and click Run Report.";
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            if (dtpTo.Value.Date < dtpFrom.Value.Date)
            {
                MessageBox.Show("The end date must be on or after the start date.", "Invalid range",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime from = dtpFrom.Value.Date;
            DateTime to = dtpTo.Value.Date;

            switch (cmbReportType.SelectedIndex)
            {
                case 0:
                    RunGuestActivityReport(from, to);
                    break;
                case 1:
                    RunReservationReport(from, to);
                    break;
                case 2:
                    RunRevenueReport(from, to);
                    break;
            }
        }

        private void RunGuestActivityReport(DateTime from, DateTime to)
        {
            DataTable dt = reportDAL.GetGuestActivityReport(from, to);
            dgvReport.DataSource = dt;
            if (dgvReport.Columns.Contains("GuestID"))
                dgvReport.Columns["GuestID"].Visible = false;

            int guestCount = dt.Rows.Count;
            decimal totalPaid = 0;
            foreach (DataRow row in dt.Rows) totalPaid += Convert.ToDecimal(row["TotalPaid"]);

            lblSummary.Text = $"{guestCount} active guest(s) between {from:MM/dd/yyyy} and {to:MM/dd/yyyy} — total revenue from these guests: ${totalPaid:0.00}";
        }

        private void RunReservationReport(DateTime from, DateTime to)
        {
            DataTable dt = reportDAL.GetReservationReport(from, to);
            dgvReport.DataSource = dt;

            int total = dt.Rows.Count;
            decimal totalAmount = 0;
            int nights = 0;
            foreach (DataRow row in dt.Rows)
            {
                totalAmount += Convert.ToDecimal(row["TotalAmount"]);
                nights += Convert.ToInt32(row["Nights"]);
            }

            lblSummary.Text = $"{total} reservation(s), {nights} room-night(s), total booked value: ${totalAmount:0.00}";
        }

        private void RunRevenueReport(DateTime from, DateTime to)
        {
            DataTable dt = reportDAL.GetRevenueReport(from, to);
            dgvReport.DataSource = dt;

            decimal total = reportDAL.GetTotalRevenue(from, to);
            lblSummary.Text = $"Total completed revenue from {from:MM/dd/yyyy} to {to:MM/dd/yyyy}: ${total:0.00}";
        }
    }
}

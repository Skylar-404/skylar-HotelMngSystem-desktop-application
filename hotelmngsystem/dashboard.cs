using hotelmngsystem.DAL;
using hotelmngsystem.Helpers;
using System;
using System.Windows.Forms;

namespace hotelmngsystem.UI
{
    public partial class dashboard : UserControl
    {
        private readonly DashboardDAL dashboardDAL = new DashboardDAL();

        public dashboard()
        {
            InitializeComponent();

            this.Dock = DockStyle.Fill;
            this.AutoScroll = true;

            WireCardHoverEffect(cardGuests);
            WireCardHoverEffect(cardAvailable);
            WireCardHoverEffect(cardOccupied);
            WireCardHoverEffect(cardReservations);
            WireCardHoverEffect(cardArrivals);
            WireCardHoverEffect(cardRevenue);
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            string name = SessionHelper.CurrentUser?.FullName ?? "there";
            lblWelcome.Text = $"Welcome back, {name}";
            lblDate.Text = DateTime.Now.ToString("dddd, MMMM d, yyyy");

            LoadStats();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadStats();
        }

        private void LoadStats()
        {
            DashboardStats stats = dashboardDAL.GetStats();

            lblGuestsValue.Text = stats.TotalGuests.ToString();
            lblAvailableValue.Text = stats.AvailableRooms.ToString();
            lblOccupiedValue.Text = stats.OccupiedRooms.ToString();
            lblReservationsValue.Text = stats.ActiveReservations.ToString();
            lblArrivalsValue.Text = $"{stats.TodaysArrivals} / {stats.TodaysDepartures}";
            lblRevenueValue.Text = stats.TodaysRevenue.ToString("$0.00");
        }

        /// <summary>Subtle hover feedback on the stat cards — a slight tint, nothing flashy.</summary>
        private void WireCardHoverEffect(RoundedPanel card)
        {
            System.Drawing.Color original = card.BackColor;
            card.MouseEnter += (s, e) => card.BackColor = ControlPaint.Light(original, 0.15f);
            card.MouseLeave += (s, e) => card.BackColor = original;
        }
    }
}

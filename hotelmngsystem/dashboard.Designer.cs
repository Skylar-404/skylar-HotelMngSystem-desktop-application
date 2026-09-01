namespace hotelmngsystem.UI
{
    partial class dashboard
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.flowCards = new System.Windows.Forms.FlowLayoutPanel();
            this.cardGuests = new hotelmngsystem.RoundedPanel();
            this.lblGuestsValue = new System.Windows.Forms.Label();
            this.lblGuestsTitle = new System.Windows.Forms.Label();
            this.cardAvailable = new hotelmngsystem.RoundedPanel();
            this.lblAvailableValue = new System.Windows.Forms.Label();
            this.lblAvailableTitle = new System.Windows.Forms.Label();
            this.cardOccupied = new hotelmngsystem.RoundedPanel();
            this.lblOccupiedValue = new System.Windows.Forms.Label();
            this.lblOccupiedTitle = new System.Windows.Forms.Label();
            this.cardReservations = new hotelmngsystem.RoundedPanel();
            this.lblReservationsValue = new System.Windows.Forms.Label();
            this.lblReservationsTitle = new System.Windows.Forms.Label();
            this.cardArrivals = new hotelmngsystem.RoundedPanel();
            this.lblArrivalsValue = new System.Windows.Forms.Label();
            this.lblArrivalsTitle = new System.Windows.Forms.Label();
            this.cardRevenue = new hotelmngsystem.RoundedPanel();
            this.lblRevenueValue = new System.Windows.Forms.Label();
            this.lblRevenueTitle = new System.Windows.Forms.Label();
            this.btnRefresh = new hotelmngsystem.RoundedButton();
            this.pbGuests = new System.Windows.Forms.PictureBox();
            this.pbAvailable = new System.Windows.Forms.PictureBox();
            this.pbOccupied = new System.Windows.Forms.PictureBox();
            this.pbReservations = new System.Windows.Forms.PictureBox();
            this.pbArrivals = new System.Windows.Forms.PictureBox();
            this.pbRevenue = new System.Windows.Forms.PictureBox();
            this.flowCards.SuspendLayout();
            this.cardGuests.SuspendLayout();
            this.cardAvailable.SuspendLayout();
            this.cardOccupied.SuspendLayout();
            this.cardReservations.SuspendLayout();
            this.cardArrivals.SuspendLayout();
            this.cardRevenue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbGuests)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAvailable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbOccupied)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbReservations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbArrivals)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRevenue)).BeginInit();
            this.SuspendLayout();
            // 
            // lblWelcome
            // 
            this.lblWelcome.Font = new System.Drawing.Font("Limelight", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lblWelcome.Location = new System.Drawing.Point(24, 23);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(279, 42);
            this.lblWelcome.TabIndex = 5;
            this.lblWelcome.Text = "Welcome back";
            // 
            // lblDate
            // 
            this.lblDate.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblDate.ForeColor = System.Drawing.Color.Gray;
            this.lblDate.Location = new System.Drawing.Point(26, 58);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(400, 22);
            this.lblDate.TabIndex = 4;
            this.lblDate.Text = "Today";
            // 
            // flowCards
            // 
            this.flowCards.Controls.Add(this.cardGuests);
            this.flowCards.Controls.Add(this.cardAvailable);
            this.flowCards.Controls.Add(this.cardOccupied);
            this.flowCards.Controls.Add(this.cardReservations);
            this.flowCards.Controls.Add(this.cardArrivals);
            this.flowCards.Controls.Add(this.cardRevenue);
            this.flowCards.Location = new System.Drawing.Point(20, 96);
            this.flowCards.Name = "flowCards";
            this.flowCards.Size = new System.Drawing.Size(860, 380);
            this.flowCards.TabIndex = 2;
            // 
            // cardGuests
            // 
            this.cardGuests.BackColor = System.Drawing.Color.AliceBlue;
            this.cardGuests.Controls.Add(this.pbGuests);
            this.cardGuests.Controls.Add(this.lblGuestsValue);
            this.cardGuests.Controls.Add(this.lblGuestsTitle);
            this.cardGuests.CornerRadius = 16;
            this.cardGuests.Location = new System.Drawing.Point(3, 3);
            this.cardGuests.Margin = new System.Windows.Forms.Padding(3, 3, 15, 15);
            this.cardGuests.Name = "cardGuests";
            this.cardGuests.Size = new System.Drawing.Size(260, 165);
            this.cardGuests.TabIndex = 0;
            // 
            // lblGuestsValue
            // 
            this.lblGuestsValue.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblGuestsValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lblGuestsValue.Location = new System.Drawing.Point(16, 74);
            this.lblGuestsValue.Name = "lblGuestsValue";
            this.lblGuestsValue.Size = new System.Drawing.Size(120, 53);
            this.lblGuestsValue.TabIndex = 1;
            this.lblGuestsValue.Text = "0";
            // 
            // lblGuestsTitle
            // 
            this.lblGuestsTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblGuestsTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblGuestsTitle.Location = new System.Drawing.Point(140, 16);
            this.lblGuestsTitle.Name = "lblGuestsTitle";
            this.lblGuestsTitle.Size = new System.Drawing.Size(110, 40);
            this.lblGuestsTitle.TabIndex = 2;
            this.lblGuestsTitle.Text = "Total Guests";
            this.lblGuestsTitle.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cardAvailable
            // 
            this.cardAvailable.BackColor = System.Drawing.Color.Honeydew;
            this.cardAvailable.Controls.Add(this.pbAvailable);
            this.cardAvailable.Controls.Add(this.lblAvailableValue);
            this.cardAvailable.Controls.Add(this.lblAvailableTitle);
            this.cardAvailable.CornerRadius = 16;
            this.cardAvailable.Location = new System.Drawing.Point(281, 3);
            this.cardAvailable.Margin = new System.Windows.Forms.Padding(3, 3, 15, 15);
            this.cardAvailable.Name = "cardAvailable";
            this.cardAvailable.Size = new System.Drawing.Size(260, 165);
            this.cardAvailable.TabIndex = 1;
            // 
            // lblAvailableValue
            // 
            this.lblAvailableValue.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblAvailableValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lblAvailableValue.Location = new System.Drawing.Point(16, 74);
            this.lblAvailableValue.Name = "lblAvailableValue";
            this.lblAvailableValue.Size = new System.Drawing.Size(120, 53);
            this.lblAvailableValue.TabIndex = 1;
            this.lblAvailableValue.Text = "0";
            // 
            // lblAvailableTitle
            // 
            this.lblAvailableTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblAvailableTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblAvailableTitle.Location = new System.Drawing.Point(130, 16);
            this.lblAvailableTitle.Name = "lblAvailableTitle";
            this.lblAvailableTitle.Size = new System.Drawing.Size(120, 40);
            this.lblAvailableTitle.TabIndex = 2;
            this.lblAvailableTitle.Text = "Available Rooms";
            this.lblAvailableTitle.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cardOccupied
            // 
            this.cardOccupied.BackColor = System.Drawing.Color.Lavender;
            this.cardOccupied.Controls.Add(this.pbOccupied);
            this.cardOccupied.Controls.Add(this.lblOccupiedValue);
            this.cardOccupied.Controls.Add(this.lblOccupiedTitle);
            this.cardOccupied.CornerRadius = 16;
            this.cardOccupied.Location = new System.Drawing.Point(559, 3);
            this.cardOccupied.Margin = new System.Windows.Forms.Padding(3, 3, 15, 15);
            this.cardOccupied.Name = "cardOccupied";
            this.cardOccupied.Size = new System.Drawing.Size(260, 165);
            this.cardOccupied.TabIndex = 2;
            // 
            // lblOccupiedValue
            // 
            this.lblOccupiedValue.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblOccupiedValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lblOccupiedValue.Location = new System.Drawing.Point(16, 74);
            this.lblOccupiedValue.Name = "lblOccupiedValue";
            this.lblOccupiedValue.Size = new System.Drawing.Size(120, 53);
            this.lblOccupiedValue.TabIndex = 1;
            this.lblOccupiedValue.Text = "0";
            // 
            // lblOccupiedTitle
            // 
            this.lblOccupiedTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblOccupiedTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblOccupiedTitle.Location = new System.Drawing.Point(140, 16);
            this.lblOccupiedTitle.Name = "lblOccupiedTitle";
            this.lblOccupiedTitle.Size = new System.Drawing.Size(110, 40);
            this.lblOccupiedTitle.TabIndex = 2;
            this.lblOccupiedTitle.Text = "Occupied Rooms";
            this.lblOccupiedTitle.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cardReservations
            // 
            this.cardReservations.BackColor = System.Drawing.Color.Cornsilk;
            this.cardReservations.Controls.Add(this.pbReservations);
            this.cardReservations.Controls.Add(this.lblReservationsValue);
            this.cardReservations.Controls.Add(this.lblReservationsTitle);
            this.cardReservations.CornerRadius = 16;
            this.cardReservations.Location = new System.Drawing.Point(3, 186);
            this.cardReservations.Margin = new System.Windows.Forms.Padding(3, 3, 15, 15);
            this.cardReservations.Name = "cardReservations";
            this.cardReservations.Size = new System.Drawing.Size(260, 165);
            this.cardReservations.TabIndex = 3;
            // 
            // lblReservationsValue
            // 
            this.lblReservationsValue.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblReservationsValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lblReservationsValue.Location = new System.Drawing.Point(16, 74);
            this.lblReservationsValue.Name = "lblReservationsValue";
            this.lblReservationsValue.Size = new System.Drawing.Size(120, 53);
            this.lblReservationsValue.TabIndex = 1;
            this.lblReservationsValue.Text = "0";
            // 
            // lblReservationsTitle
            // 
            this.lblReservationsTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblReservationsTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblReservationsTitle.Location = new System.Drawing.Point(130, 16);
            this.lblReservationsTitle.Name = "lblReservationsTitle";
            this.lblReservationsTitle.Size = new System.Drawing.Size(120, 40);
            this.lblReservationsTitle.TabIndex = 2;
            this.lblReservationsTitle.Text = "Active Reservations";
            this.lblReservationsTitle.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cardArrivals
            // 
            this.cardArrivals.BackColor = System.Drawing.Color.MistyRose;
            this.cardArrivals.Controls.Add(this.pbArrivals);
            this.cardArrivals.Controls.Add(this.lblArrivalsValue);
            this.cardArrivals.Controls.Add(this.lblArrivalsTitle);
            this.cardArrivals.CornerRadius = 16;
            this.cardArrivals.Location = new System.Drawing.Point(281, 186);
            this.cardArrivals.Margin = new System.Windows.Forms.Padding(3, 3, 15, 15);
            this.cardArrivals.Name = "cardArrivals";
            this.cardArrivals.Size = new System.Drawing.Size(260, 165);
            this.cardArrivals.TabIndex = 4;
            // 
            // lblArrivalsValue
            // 
            this.lblArrivalsValue.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblArrivalsValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lblArrivalsValue.Location = new System.Drawing.Point(16, 78);
            this.lblArrivalsValue.Name = "lblArrivalsValue";
            this.lblArrivalsValue.Size = new System.Drawing.Size(180, 49);
            this.lblArrivalsValue.TabIndex = 1;
            this.lblArrivalsValue.Text = "0 / 0";
            // 
            // lblArrivalsTitle
            // 
            this.lblArrivalsTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblArrivalsTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblArrivalsTitle.Location = new System.Drawing.Point(130, 16);
            this.lblArrivalsTitle.Name = "lblArrivalsTitle";
            this.lblArrivalsTitle.Size = new System.Drawing.Size(120, 40);
            this.lblArrivalsTitle.TabIndex = 2;
            this.lblArrivalsTitle.Text = "Today Arrivals / Departures";
            this.lblArrivalsTitle.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cardRevenue
            // 
            this.cardRevenue.BackColor = System.Drawing.Color.Beige;
            this.cardRevenue.Controls.Add(this.pbRevenue);
            this.cardRevenue.Controls.Add(this.lblRevenueValue);
            this.cardRevenue.Controls.Add(this.lblRevenueTitle);
            this.cardRevenue.CornerRadius = 16;
            this.cardRevenue.Location = new System.Drawing.Point(559, 186);
            this.cardRevenue.Margin = new System.Windows.Forms.Padding(3, 3, 15, 15);
            this.cardRevenue.Name = "cardRevenue";
            this.cardRevenue.Size = new System.Drawing.Size(260, 165);
            this.cardRevenue.TabIndex = 5;
            // 
            // lblRevenueValue
            // 
            this.lblRevenueValue.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblRevenueValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lblRevenueValue.Location = new System.Drawing.Point(16, 76);
            this.lblRevenueValue.Name = "lblRevenueValue";
            this.lblRevenueValue.Size = new System.Drawing.Size(160, 51);
            this.lblRevenueValue.TabIndex = 1;
            this.lblRevenueValue.Text = "$0.00";
            // 
            // lblRevenueTitle
            // 
            this.lblRevenueTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblRevenueTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblRevenueTitle.Location = new System.Drawing.Point(150, 16);
            this.lblRevenueTitle.Name = "lblRevenueTitle";
            this.lblRevenueTitle.Size = new System.Drawing.Size(100, 40);
            this.lblRevenueTitle.TabIndex = 2;
            this.lblRevenueTitle.Text = "Today Revenue";
            this.lblRevenueTitle.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnRefresh.BorderColor = System.Drawing.Color.Transparent;
            this.btnRefresh.BorderRadius = 10;
            this.btnRefresh.BorderSize = 0;
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.HoverColor = System.Drawing.Color.RoyalBlue;
            this.btnRefresh.Location = new System.Drawing.Point(734, 23);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.NormalColor = System.Drawing.Color.DodgerBlue;
            this.btnRefresh.PressedColor = System.Drawing.Color.MediumBlue;
            this.btnRefresh.Size = new System.Drawing.Size(146, 36);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "⏳ Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // pbGuests
            // 
            this.pbGuests.BackColor = System.Drawing.Color.Transparent;
            this.pbGuests.Image = global::hotelmngsystem.Properties.Resources.user_heart_alt_1_svgrepo_com;
            this.pbGuests.Location = new System.Drawing.Point(16, 16);
            this.pbGuests.Name = "pbGuests";
            this.pbGuests.Size = new System.Drawing.Size(36, 36);
            this.pbGuests.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbGuests.TabIndex = 0;
            this.pbGuests.TabStop = false;
            // 
            // pbAvailable
            // 
            this.pbAvailable.BackColor = System.Drawing.Color.Transparent;
            this.pbAvailable.Image = global::hotelmngsystem.Properties.Resources.key_skeleton_svgrepo_com;
            this.pbAvailable.Location = new System.Drawing.Point(16, 16);
            this.pbAvailable.Name = "pbAvailable";
            this.pbAvailable.Size = new System.Drawing.Size(36, 36);
            this.pbAvailable.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbAvailable.TabIndex = 0;
            this.pbAvailable.TabStop = false;
            // 
            // pbOccupied
            // 
            this.pbOccupied.BackColor = System.Drawing.Color.Transparent;
            this.pbOccupied.Image = global::hotelmngsystem.Properties.Resources.house_medical_exclamation_svgrepo_com;
            this.pbOccupied.Location = new System.Drawing.Point(16, 16);
            this.pbOccupied.Name = "pbOccupied";
            this.pbOccupied.Size = new System.Drawing.Size(36, 36);
            this.pbOccupied.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbOccupied.TabIndex = 0;
            this.pbOccupied.TabStop = false;
            // 
            // pbReservations
            // 
            this.pbReservations.BackColor = System.Drawing.Color.Transparent;
            this.pbReservations.Image = global::hotelmngsystem.Properties.Resources.user_check_alt_1_svgrepo_com__1_;
            this.pbReservations.Location = new System.Drawing.Point(16, 16);
            this.pbReservations.Name = "pbReservations";
            this.pbReservations.Size = new System.Drawing.Size(36, 36);
            this.pbReservations.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbReservations.TabIndex = 0;
            this.pbReservations.TabStop = false;
            // 
            // pbArrivals
            // 
            this.pbArrivals.BackColor = System.Drawing.Color.Transparent;
            this.pbArrivals.Image = global::hotelmngsystem.Properties.Resources.key_svgrepo_com;
            this.pbArrivals.Location = new System.Drawing.Point(16, 16);
            this.pbArrivals.Name = "pbArrivals";
            this.pbArrivals.Size = new System.Drawing.Size(36, 36);
            this.pbArrivals.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbArrivals.TabIndex = 0;
            this.pbArrivals.TabStop = false;
            // 
            // pbRevenue
            // 
            this.pbRevenue.BackColor = System.Drawing.Color.Transparent;
            this.pbRevenue.Image = global::hotelmngsystem.Properties.Resources.payment;
            this.pbRevenue.Location = new System.Drawing.Point(16, 16);
            this.pbRevenue.Name = "pbRevenue";
            this.pbRevenue.Size = new System.Drawing.Size(36, 36);
            this.pbRevenue.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbRevenue.TabIndex = 0;
            this.pbRevenue.TabStop = false;
            // 
            // dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.flowCards);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblWelcome);
            this.Name = "dashboard";
            this.Size = new System.Drawing.Size(900, 536);
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.flowCards.ResumeLayout(false);
            this.cardGuests.ResumeLayout(false);
            this.cardAvailable.ResumeLayout(false);
            this.cardOccupied.ResumeLayout(false);
            this.cardReservations.ResumeLayout(false);
            this.cardArrivals.ResumeLayout(false);
            this.cardRevenue.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbGuests)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAvailable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbOccupied)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbReservations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbArrivals)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRevenue)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblDate;
        private hotelmngsystem.RoundedButton btnRefresh;
        private System.Windows.Forms.FlowLayoutPanel flowCards;
        private hotelmngsystem.RoundedPanel cardGuests;
        private System.Windows.Forms.PictureBox pbGuests;
        private System.Windows.Forms.Label lblGuestsValue;
        private System.Windows.Forms.Label lblGuestsTitle;
        private hotelmngsystem.RoundedPanel cardAvailable;
        private System.Windows.Forms.PictureBox pbAvailable;
        private System.Windows.Forms.Label lblAvailableValue;
        private System.Windows.Forms.Label lblAvailableTitle;
        private hotelmngsystem.RoundedPanel cardOccupied;
        private System.Windows.Forms.PictureBox pbOccupied;
        private System.Windows.Forms.Label lblOccupiedValue;
        private System.Windows.Forms.Label lblOccupiedTitle;
        private hotelmngsystem.RoundedPanel cardReservations;
        private System.Windows.Forms.PictureBox pbReservations;
        private System.Windows.Forms.Label lblReservationsValue;
        private System.Windows.Forms.Label lblReservationsTitle;
        private hotelmngsystem.RoundedPanel cardArrivals;
        private System.Windows.Forms.PictureBox pbArrivals;
        private System.Windows.Forms.Label lblArrivalsValue;
        private System.Windows.Forms.Label lblArrivalsTitle;
        private hotelmngsystem.RoundedPanel cardRevenue;
        private System.Windows.Forms.PictureBox pbRevenue;
        private System.Windows.Forms.Label lblRevenueValue;
        private System.Windows.Forms.Label lblRevenueTitle;
    }
}

using hotelmngsystem.DAL;
using hotelmngsystem.Helpers;
using hotelmngsystem.Models;
using System;
using System.Data;
using System.Windows.Forms;

namespace hotelmngsystem.UI
{
    public partial class ReservationForm : Form
    {
        private class ComboItem
        {
            public int Id;
            public string Display;
            public decimal Rate;
            public override string ToString() => Display;
        }

        private readonly ReservationDAL reservationDAL = new ReservationDAL();
        private readonly GuestDAL guestDAL = new GuestDAL();
        private readonly RoomDAL roomDAL = new RoomDAL();
        private readonly Reservation editingReservation;

        public ReservationForm(Reservation reservationToEdit = null)
        {
            InitializeComponent();

            editingReservation = reservationToEdit;

            cmbStatus.Items.AddRange(Reservation.AllStatuses);
            LoadGuests();
            LoadRooms();

            if (editingReservation != null)
            {
                lblTitle.Text = "Edit Reservation";
                Text = "Edit Reservation";
                PopulateFields(editingReservation);
            }
            else
            {
                lblTitle.Text = "New Reservation";
                Text = "New Reservation";
                dtpCheckIn.Value = DateTime.Today;
                dtpCheckOut.Value = DateTime.Today.AddDays(1);
                cmbStatus.SelectedItem = "PENDING";
                if (cmbRoom.Items.Count > 0) cmbRoom.SelectedIndex = 0;
            }
        }

        private void LoadGuests()
        {
            DataTable guests = guestDAL.GetGuests();
            foreach (DataRow row in guests.Rows)
            {
                cmbGuest.Items.Add(new ComboItem
                {
                    Id = (int)row["GuestID"],
                    Display = $"{row["FirstName"]} {row["LastName"]} - {row["Phone"]}"
                });
            }
        }

        private void LoadRooms(int? includeRoomId = null)
        {
            cmbRoom.Items.Clear();
            foreach (Room room in roomDAL.GetAvailableRooms(includeRoomId))
            {
                cmbRoom.Items.Add(new ComboItem
                {
                    Id = room.RoomID,
                    Display = $"{room.RoomNumber} - {room.TypeName} (${room.BasePrice}/night)",
                    Rate = room.BasePrice
                });
            }
        }

        private void PopulateFields(Reservation r)
        {
            LoadRooms(r.RoomID);

            foreach (ComboItem item in cmbGuest.Items)
            {
                if (item.Id == r.GuestID) { cmbGuest.SelectedItem = item; break; }
            }
            if (cmbGuest.SelectedItem == null)
            {
                cmbGuest.Text = r.GuestName;
            }

            foreach (ComboItem item in cmbRoom.Items)
            {
                if (item.Id == r.RoomID) { cmbRoom.SelectedItem = item; break; }
            }

            dtpCheckIn.Value = r.CheckInDate;
            dtpCheckOut.Value = r.CheckOutDate;
            nudAdults.Value = r.Adults <= 0 ? 1 : r.Adults;
            nudChildren.Value = r.Children < 0 ? 0 : r.Children;
            txtRoomRate.Text = r.RoomRate.ToString("0.00");
            cmbStatus.SelectedItem = r.Status;
            txtSpecialRequest.Text = r.SpecialRequest;
        }

        private void cmbRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Only auto-fill the rate for a brand-new reservation, don't overwrite a rate
            // that was already negotiated/edited on an existing one.
            ComboItem item = cmbRoom.SelectedItem as ComboItem;
            if (editingReservation == null && item != null)
            {
                txtRoomRate.Text = item.Rate.ToString("0.00");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ComboItem guestItem = cmbGuest.SelectedItem as ComboItem;
            ComboItem roomItem = cmbRoom.SelectedItem as ComboItem;

            if (guestItem == null)
            {
                DialogHelper.Warn("Please pick a guest from the list.");
                return;
            }
            if (roomItem == null)
            {
                DialogHelper.Warn("Please select a room.");
                return;
            }
            if (dtpCheckOut.Value.Date <= dtpCheckIn.Value.Date)
            {
                DialogHelper.Warn("Check-out date must be after the check-in date.");
                return;
            }
            decimal rate;
            if (!decimal.TryParse(txtRoomRate.Text, out rate) || rate < 0)
            {
                DialogHelper.Warn("Please enter a valid room rate.");
                return;
            }

            Reservation r = editingReservation ?? new Reservation();
            r.GuestID = guestItem.Id;
            r.RoomID = roomItem.Id;
            r.CheckInDate = dtpCheckIn.Value.Date;
            r.CheckOutDate = dtpCheckOut.Value.Date;
            r.Adults = (int)nudAdults.Value;
            r.Children = (int)nudChildren.Value;
            r.RoomRate = rate;
            r.Status = cmbStatus.SelectedItem?.ToString() ?? "PENDING";
            r.SpecialRequest = txtSpecialRequest.Text.Trim();
            r.CreatedBy = SessionHelper.CurrentUser?.UserID;

            try
            {
                if (editingReservation != null)
                {
                    reservationDAL.Update(r);
                    DialogHelper.Info("Reservation updated successfully.");
                }
                else
                {
                    reservationDAL.Insert(r);
                    DialogHelper.Info("Reservation created successfully.");
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                DialogHelper.Error("Could not save the reservation.\n" + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}

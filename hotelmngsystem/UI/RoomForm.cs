using hotelmngsystem.DAL;
using hotelmngsystem.Helpers;
using hotelmngsystem.Models;
using System;
using System.Windows.Forms;

namespace hotelmngsystem.UI
{
    public partial class RoomForm : Form
    {
        private class ComboItem
        {
            public int Id;
            public string Display;
            public override string ToString() => Display;
        }

        private readonly RoomDAL roomDAL = new RoomDAL();
        private readonly RoomTypeDAL roomTypeDAL = new RoomTypeDAL();
        private readonly Room editingRoom;

        public RoomForm(Room roomToEdit = null)
        {
            InitializeComponent();

            editingRoom = roomToEdit;

            cmbStatus.Items.AddRange(Room.AllStatuses);

            foreach (RoomType rt in roomTypeDAL.GetAll())
            {
                cmbRoomType.Items.Add(new ComboItem { Id = rt.RoomTypeID, Display = $"{rt.TypeName} (${rt.BasePrice}/night)" });
            }

            if (editingRoom != null)
            {
                lblTitle.Text = "Edit Room";
                Text = "Edit Room";
                PopulateFields(editingRoom);
            }
            else
            {
                lblTitle.Text = "Add Room";
                Text = "Add Room";
                cmbStatus.SelectedItem = "AVAILABLE";
                if (cmbRoomType.Items.Count > 0) cmbRoomType.SelectedIndex = 0;
            }
        }

        private void PopulateFields(Room r)
        {
            txtRoomNumber.Text = r.RoomNumber;
            foreach (object obj in cmbRoomType.Items)
            {
                ComboItem item = (ComboItem)obj;
                if (item.Id == r.RoomTypeID) { cmbRoomType.SelectedItem = item; break; }
            }
            nudFloor.Value = r.FloorNumber ?? 0;
            cmbStatus.SelectedItem = r.Status;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRoomNumber.Text))
            {
                DialogHelper.Warn("Room number is required.");
                return;
            }

            ComboItem typeItem = cmbRoomType.SelectedItem as ComboItem;
            if (typeItem == null)
            {
                DialogHelper.Warn("Please select a room type.");
                return;
            }

            Room room = editingRoom ?? new Room();
            room.RoomNumber = txtRoomNumber.Text.Trim();
            room.RoomTypeID = typeItem.Id;
            room.FloorNumber = (int)nudFloor.Value;
            room.Status = cmbStatus.SelectedItem?.ToString() ?? "AVAILABLE";

            try
            {
                if (editingRoom != null)
                {
                    roomDAL.Update(room);
                    DialogHelper.Info("Room updated successfully.");
                }
                else
                {
                    roomDAL.Insert(room);
                    DialogHelper.Info("Room added successfully.");
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                DialogHelper.Error("Could not save the room.\n" + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}

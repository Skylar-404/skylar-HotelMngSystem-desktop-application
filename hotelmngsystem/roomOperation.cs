using hotelmngsystem.DAL;
using hotelmngsystem.Helpers;
using hotelmngsystem.Models;
using hotelmngsystem.UI;
using System;
using System.Windows.Forms;

namespace hotelmngsystem
{
    public partial class roomOperation : UserControl
    {
        private readonly RoomDAL roomDAL = new RoomDAL();
        private readonly RoomOperationDAL operationDAL = new RoomOperationDAL();

        public roomOperation()
        {
            InitializeComponent();

            this.Dock = DockStyle.Fill;
            this.AutoScroll = true;
        }

        private void RoomOperation_Load(object sender, EventArgs e)
        {
            DataGridViewHelper.Configure(dgvRooms);
            LoadRooms();
        }

        private void LoadRooms()
        {
            dgvRooms.DataSource = roomDAL.GetRooms(txtSearch.Text.Trim());

            if (dgvRooms.Columns.Contains("RoomID"))
                dgvRooms.Columns["RoomID"].Visible = false;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadRooms();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            LoadRooms();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (RoomForm frm = new RoomForm())
            {
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    LoadRooms();
                }
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int? id = GetSelectedRoomId();
            if (id == null)
            {
                DialogHelper.Warn("Please select a room to edit.");
                return;
            }

            Room room = roomDAL.GetById(id.Value);
            using (RoomForm frm = new RoomForm(room))
            {
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    LoadRooms();
                }
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int? id = GetSelectedRoomId();
            if (id == null)
            {
                DialogHelper.Warn("Please select a room to delete.");
                return;
            }

            if (roomDAL.HasReservations(id.Value))
            {
                DialogHelper.Warn("This room has reservation history and cannot be deleted.");
                return;
            }

            if (DialogHelper.Confirm("Delete this room? This cannot be undone."))
            {
                roomDAL.Delete(id.Value);
                LoadRooms();
                DialogHelper.Info("Room deleted.");
            }
        }

        private void markCleanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeRoomStatus("AVAILABLE", "CLEANING", "marked as cleaned and available");
        }

        private void markMaintenanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeRoomStatus("MAINTENANCE", "MAINTENANCE", "sent to maintenance");
        }

        private void markOutOfOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeRoomStatus("OUT_OF_ORDER", "STATUS_CHANGE", "marked out of order");
        }

        private void ChangeRoomStatus(string newStatus, string operationType, string friendlyLabel)
        {
            int? id = GetSelectedRoomId();
            if (id == null)
            {
                DialogHelper.Warn("Please select a room.");
                return;
            }

            Room room = roomDAL.GetById(id.Value);
            if (room == null) return;

            if (!DialogHelper.Confirm($"Mark room {room.RoomNumber} as {friendlyLabel}?"))
                return;

            string oldStatus = room.Status;
            roomDAL.UpdateStatus(id.Value, newStatus);

            operationDAL.LogOperation(new RoomOperation
            {
                RoomID = id.Value,
                OperationType = operationType,
                OldStatus = oldStatus,
                NewStatus = newStatus,
                Description = $"Room {friendlyLabel} via Room Operation module.",
                PerformedBy = SessionHelper.CurrentUser?.UserID ?? 0
            });

            LoadRooms();
            DialogHelper.Info($"Room {friendlyLabel}.");
        }

        private void dgvRooms_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                editToolStripMenuItem_Click(sender, e);
            }
        }

        private int? GetSelectedRoomId()
        {
            if (dgvRooms.CurrentRow == null) return null;
            object value = dgvRooms.CurrentRow.Cells["RoomID"].Value;
            if (value == null) return null;
            return Convert.ToInt32(value);
        }
    }
}

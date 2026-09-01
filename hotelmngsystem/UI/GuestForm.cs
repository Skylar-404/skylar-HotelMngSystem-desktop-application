using hotelmngsystem.DAL;
using hotelmngsystem.Helpers;
using hotelmngsystem.Models;
using System;
using System.Windows.Forms;

namespace hotelmngsystem.UI
{
    public partial class GuestForm : Form
    {
        private readonly GuestDAL guestDAL = new GuestDAL();
        private readonly Guest editingGuest;

        public GuestForm(Guest guestToEdit = null)
        {
            InitializeComponent();

            editingGuest = guestToEdit;

            if (editingGuest != null)
            {
                lblTitle.Text = "Edit Guest";
                Text = "Edit Guest";
                PopulateFields(editingGuest);
            }
            else
            {
                lblTitle.Text = "Add Guest";
                Text = "Add Guest";
                cmbGender.SelectedIndex = 0;
                cmbStatus.SelectedItem = "ACTIVE";
            }
        }

        private void PopulateFields(Guest g)
        {
            txtFirstName.Text = g.FirstName;
            txtLastName.Text = g.LastName;
            cmbGender.Text = g.Gender;
            txtPhone.Text = g.Phone;
            txtEmail.Text = g.Email;
            txtAddress.Text = g.Address;
            txtIDNumber.Text = g.IDNumber;
            txtNationality.Text = g.Nationality;
            cmbStatus.SelectedItem = g.Status ?? "ACTIVE";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) || string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                DialogHelper.Warn("First name and last name are required.");
                return;
            }

            Guest guest = editingGuest ?? new Guest();
            guest.FirstName = txtFirstName.Text.Trim();
            guest.LastName = txtLastName.Text.Trim();
            guest.Gender = cmbGender.Text;
            guest.Phone = txtPhone.Text.Trim();
            guest.Email = txtEmail.Text.Trim();
            guest.Address = txtAddress.Text.Trim();
            guest.IDNumber = txtIDNumber.Text.Trim();
            guest.Nationality = txtNationality.Text.Trim();
            guest.Status = string.IsNullOrEmpty(cmbStatus.Text) ? "ACTIVE" : cmbStatus.Text;

            try
            {
                if (editingGuest != null)
                {
                    guestDAL.Update(guest);
                    DialogHelper.Info("Guest updated successfully.");
                }
                else
                {
                    guestDAL.Insert(guest);
                    DialogHelper.Info("Guest added successfully.");
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                DialogHelper.Error("Could not save the guest.\n" + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}

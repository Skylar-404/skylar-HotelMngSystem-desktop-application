using hotelmngsystem.DAL;
using hotelmngsystem.Helpers;
using hotelmngsystem.Models;
using System;
using System.Windows.Forms;

namespace hotelmngsystem.UI
{
    public partial class UserForm : Form
    {
        private readonly UserDAL userDAL = new UserDAL();
        private readonly User editingUser;

        public UserForm(User userToEdit = null)
        {
            InitializeComponent();

            editingUser = userToEdit;

            cmbRole.Items.AddRange(User.AllRoles);

            if (editingUser != null)
            {
                lblTitle.Text = "Edit User";
                Text = "Edit User";
                PopulateFields(editingUser);
            }
            else
            {
                lblTitle.Text = "Add User";
                Text = "Add User";
                cmbRole.SelectedItem = "EMPLOYEE";
                cmbStatus.SelectedItem = "ACTIVE";
            }
        }

        private void PopulateFields(User u)
        {
            txtUsername.Text = u.Username;
            txtFullName.Text = u.FullName;
            cmbRole.SelectedItem = u.Role;
            txtPhone.Text = u.Phone;
            txtEmail.Text = u.Email;
            cmbStatus.SelectedItem = u.Status;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                DialogHelper.Warn("Username and full name are required.");
                return;
            }

            if (editingUser == null && string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                DialogHelper.Warn("Please set a password for the new user.");
                return;
            }

            string username = txtUsername.Text.Trim();
            if (userDAL.UsernameExists(username, editingUser?.UserID))
            {
                DialogHelper.Warn("That username is already taken. Please choose another.");
                return;
            }

            User user = editingUser ?? new User();
            user.Username = username;
            user.FullName = txtFullName.Text.Trim();
            user.Role = cmbRole.SelectedItem?.ToString() ?? "EMPLOYEE";
            user.Phone = txtPhone.Text.Trim();
            user.Email = txtEmail.Text.Trim();
            user.Status = cmbStatus.SelectedItem?.ToString() ?? "ACTIVE";

            bool changePassword = !string.IsNullOrWhiteSpace(txtPassword.Text);
            if (changePassword)
            {
                user.PasswordHash = PasswordHelper.Hash(txtPassword.Text);
            }

            try
            {
                if (editingUser != null)
                {
                    userDAL.Update(user, changePassword);
                    DialogHelper.Info("User updated successfully.");
                }
                else
                {
                    userDAL.Insert(user);
                    DialogHelper.Info("User added successfully.");
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                DialogHelper.Error("Could not save the user.\n" + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}

using hotelmngsystem.DAL;
using hotelmngsystem.Helpers;
using hotelmngsystem.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace hotelmngsystem.UI
{
    public partial class PaymentForm : Form
    {
        private class ComboItem
        {
            public int Id;
            public string Display;
            public override string ToString() => Display;
        }

        private readonly PaymentDAL paymentDAL = new PaymentDAL();
        private readonly Payment editingPayment;

        public PaymentForm(Payment paymentToEdit = null)
        {
            InitializeComponent();

            editingPayment = paymentToEdit;

            cmbMethod.Items.AddRange(Payment.AllMethods);
            cmbType.Items.AddRange(Payment.AllTypes);
            cmbStatus.Items.AddRange(Payment.AllStatuses);

            foreach (KeyValuePair<int, string> kv in paymentDAL.GetReservationLookup())
            {
                cmbReservation.Items.Add(new ComboItem { Id = kv.Key, Display = kv.Value });
            }

            if (editingPayment != null)
            {
                lblTitle.Text = "Edit Payment";
                Text = "Edit Payment";
                PopulateFields(editingPayment);
            }
            else
            {
                lblTitle.Text = "Add Payment";
                Text = "Add Payment";
                cmbMethod.SelectedItem = "CASH";
                cmbType.SelectedItem = "ROOM_PAYMENT";
                cmbStatus.SelectedItem = "COMPLETED";
            }
        }

        private void PopulateFields(Payment p)
        {
            foreach (object obj in cmbReservation.Items)
            {
                ComboItem item = (ComboItem)obj;
                if (item.Id == p.ReservationID) { cmbReservation.SelectedItem = item; break; }
            }
            txtAmount.Text = p.Amount.ToString("0.00");
            cmbMethod.SelectedItem = p.PaymentMethod;
            cmbType.SelectedItem = p.PaymentType;
            txtReference.Text = p.TransactionReference;
            cmbStatus.SelectedItem = p.PaymentStatus;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ComboItem resItem = cmbReservation.SelectedItem as ComboItem;
            if (resItem == null)
            {
                DialogHelper.Warn("Please select the reservation this payment belongs to.");
                return;
            }

            decimal amount;
            if (!decimal.TryParse(txtAmount.Text, out amount) || amount <= 0)
            {
                DialogHelper.Warn("Please enter a valid amount greater than zero.");
                return;
            }

            Payment p = editingPayment ?? new Payment();
            p.ReservationID = resItem.Id;
            p.Amount = amount;
            p.PaymentMethod = cmbMethod.SelectedItem?.ToString() ?? "CASH";
            p.PaymentType = cmbType.SelectedItem?.ToString() ?? "ROOM_PAYMENT";
            p.TransactionReference = txtReference.Text.Trim();
            p.PaymentStatus = cmbStatus.SelectedItem?.ToString() ?? "COMPLETED";
            p.ReceivedBy = SessionHelper.CurrentUser?.UserID;

            try
            {
                if (editingPayment != null)
                {
                    paymentDAL.Update(p);
                    DialogHelper.Info("Payment updated successfully.");
                }
                else
                {
                    paymentDAL.Insert(p);
                    DialogHelper.Info("Payment recorded successfully.");
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                DialogHelper.Error("Could not save the payment.\n" + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void PaymentForm_Load(object sender, EventArgs e)
        {
            //
        }
    }
}

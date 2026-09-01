namespace hotelmngsystem.UI
{
    partial class PaymentForm
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblReservation = new System.Windows.Forms.Label();
            this.cmbReservation = new System.Windows.Forms.ComboBox();
            this.lblAmount = new System.Windows.Forms.Label();
            this.txtAmount = new hotelmngsystem.RoundedTextBox();
            this.lblMethod = new System.Windows.Forms.Label();
            this.cmbMethod = new System.Windows.Forms.ComboBox();
            this.lblType = new System.Windows.Forms.Label();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.lblReference = new System.Windows.Forms.Label();
            this.txtReference = new hotelmngsystem.RoundedTextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.btnSave = new hotelmngsystem.RoundedButton();
            this.btnCancel = new hotelmngsystem.RoundedButton();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Limelight", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lblTitle.Location = new System.Drawing.Point(30, 22);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(300, 48);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Add Payment";
            // 
            // lblReservation
            // 
            this.lblReservation.Font = new System.Drawing.Font("Roboto Mono", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReservation.Location = new System.Drawing.Point(30, 68);
            this.lblReservation.Name = "lblReservation";
            this.lblReservation.Size = new System.Drawing.Size(200, 26);
            this.lblReservation.TabIndex = 1;
            this.lblReservation.Text = "Reservation *";
            // 
            // cmbReservation
            // 
            this.cmbReservation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReservation.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbReservation.Location = new System.Drawing.Point(30, 97);
            this.cmbReservation.Name = "cmbReservation";
            this.cmbReservation.Size = new System.Drawing.Size(340, 36);
            this.cmbReservation.TabIndex = 2;
            // 
            // lblAmount
            // 
            this.lblAmount.Font = new System.Drawing.Font("Roboto Mono", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmount.Location = new System.Drawing.Point(30, 134);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(200, 26);
            this.lblAmount.TabIndex = 3;
            this.lblAmount.Text = "Amount *";
            // 
            // txtAmount
            // 
            this.txtAmount.BackColor = System.Drawing.Color.White;
            this.txtAmount.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtAmount.BorderFocusColor = System.Drawing.Color.DodgerBlue;
            this.txtAmount.BorderRadius = 10;
            this.txtAmount.BorderSize = 1;
            this.txtAmount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAmount.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtAmount.ForeColor = System.Drawing.Color.Black;
            this.txtAmount.Location = new System.Drawing.Point(30, 163);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(340, 27);
            this.txtAmount.TabIndex = 4;
            // 
            // lblMethod
            // 
            this.lblMethod.Font = new System.Drawing.Font("Roboto Mono", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMethod.Location = new System.Drawing.Point(30, 198);
            this.lblMethod.Name = "lblMethod";
            this.lblMethod.Size = new System.Drawing.Size(200, 30);
            this.lblMethod.TabIndex = 5;
            this.lblMethod.Text = "Payment Method";
            // 
            // cmbMethod
            // 
            this.cmbMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMethod.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbMethod.Location = new System.Drawing.Point(30, 231);
            this.cmbMethod.Name = "cmbMethod";
            this.cmbMethod.Size = new System.Drawing.Size(340, 36);
            this.cmbMethod.TabIndex = 6;
            // 
            // lblType
            // 
            this.lblType.Font = new System.Drawing.Font("Roboto Mono", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblType.Location = new System.Drawing.Point(30, 271);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(200, 29);
            this.lblType.TabIndex = 7;
            this.lblType.Text = "Payment Type";
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbType.Location = new System.Drawing.Point(30, 303);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(340, 36);
            this.cmbType.TabIndex = 8;
            // 
            // lblReference
            // 
            this.lblReference.Font = new System.Drawing.Font("Roboto Mono", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReference.Location = new System.Drawing.Point(30, 341);
            this.lblReference.Name = "lblReference";
            this.lblReference.Size = new System.Drawing.Size(200, 27);
            this.lblReference.TabIndex = 9;
            this.lblReference.Text = "Transaction Reference";
            // 
            // txtReference
            // 
            this.txtReference.BackColor = System.Drawing.Color.White;
            this.txtReference.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtReference.BorderFocusColor = System.Drawing.Color.DodgerBlue;
            this.txtReference.BorderRadius = 10;
            this.txtReference.BorderSize = 1;
            this.txtReference.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtReference.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtReference.ForeColor = System.Drawing.Color.Black;
            this.txtReference.Location = new System.Drawing.Point(30, 371);
            this.txtReference.Name = "txtReference";
            this.txtReference.Size = new System.Drawing.Size(340, 27);
            this.txtReference.TabIndex = 10;
            // 
            // lblStatus
            // 
            this.lblStatus.Font = new System.Drawing.Font("Roboto Mono", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(30, 403);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(200, 26);
            this.lblStatus.TabIndex = 11;
            this.lblStatus.Text = "Payment Status";
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbStatus.Location = new System.Drawing.Point(30, 433);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(340, 36);
            this.cmbStatus.TabIndex = 12;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSave.BorderColor = System.Drawing.Color.Transparent;
            this.btnSave.BorderRadius = 12;
            this.btnSave.BorderSize = 0;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.HoverColor = System.Drawing.Color.RoyalBlue;
            this.btnSave.Location = new System.Drawing.Point(30, 483);
            this.btnSave.Name = "btnSave";
            this.btnSave.NormalColor = System.Drawing.Color.DodgerBlue;
            this.btnSave.PressedColor = System.Drawing.Color.MediumBlue;
            this.btnSave.Size = new System.Drawing.Size(160, 40);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnCancel.BorderColor = System.Drawing.Color.Transparent;
            this.btnCancel.BorderRadius = 12;
            this.btnCancel.BorderSize = 0;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.HoverColor = System.Drawing.Color.Silver;
            this.btnCancel.Location = new System.Drawing.Point(210, 483);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.NormalColor = System.Drawing.Color.Gainsboro;
            this.btnCancel.PressedColor = System.Drawing.Color.DarkGray;
            this.btnCancel.Size = new System.Drawing.Size(160, 40);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // PaymentForm
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(400, 546);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblReservation);
            this.Controls.Add(this.cmbReservation);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.lblMethod);
            this.Controls.Add(this.cmbMethod);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.lblReference);
            this.Controls.Add(this.txtReference);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PaymentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Payment";
            this.Load += new System.EventHandler(this.PaymentForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblReservation;
        private System.Windows.Forms.ComboBox cmbReservation;
        private System.Windows.Forms.Label lblAmount;
        private hotelmngsystem.RoundedTextBox txtAmount;
        private System.Windows.Forms.Label lblMethod;
        private System.Windows.Forms.ComboBox cmbMethod;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Label lblReference;
        private hotelmngsystem.RoundedTextBox txtReference;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbStatus;
        private hotelmngsystem.RoundedButton btnSave;
        private hotelmngsystem.RoundedButton btnCancel;
    }
}

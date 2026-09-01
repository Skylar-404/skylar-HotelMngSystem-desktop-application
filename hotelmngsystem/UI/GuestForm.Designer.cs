namespace hotelmngsystem.UI
{
    partial class GuestForm
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
            this.lblFirstName = new System.Windows.Forms.Label();
            this.txtFirstName = new hotelmngsystem.RoundedTextBox();
            this.lblLastName = new System.Windows.Forms.Label();
            this.txtLastName = new hotelmngsystem.RoundedTextBox();
            this.lblGender = new System.Windows.Forms.Label();
            this.cmbGender = new System.Windows.Forms.ComboBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtPhone = new hotelmngsystem.RoundedTextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new hotelmngsystem.RoundedTextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtAddress = new hotelmngsystem.RoundedTextBox();
            this.lblIDNumber = new System.Windows.Forms.Label();
            this.txtIDNumber = new hotelmngsystem.RoundedTextBox();
            this.lblNationality = new System.Windows.Forms.Label();
            this.txtNationality = new hotelmngsystem.RoundedTextBox();
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
            this.lblTitle.Location = new System.Drawing.Point(27, 14);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(300, 43);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Add Guest";
            // 
            // lblFirstName
            // 
            this.lblFirstName.Font = new System.Drawing.Font("Roboto Mono", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFirstName.Location = new System.Drawing.Point(30, 62);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(150, 20);
            this.lblFirstName.TabIndex = 1;
            this.lblFirstName.Text = "First Name *";
            // 
            // txtFirstName
            // 
            this.txtFirstName.BackColor = System.Drawing.Color.White;
            this.txtFirstName.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtFirstName.BorderFocusColor = System.Drawing.Color.DodgerBlue;
            this.txtFirstName.BorderRadius = 10;
            this.txtFirstName.BorderSize = 1;
            this.txtFirstName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFirstName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtFirstName.ForeColor = System.Drawing.Color.Black;
            this.txtFirstName.Location = new System.Drawing.Point(30, 92);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(310, 27);
            this.txtFirstName.TabIndex = 2;
            // 
            // lblLastName
            // 
            this.lblLastName.Font = new System.Drawing.Font("Roboto Mono", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastName.Location = new System.Drawing.Point(30, 124);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(150, 20);
            this.lblLastName.TabIndex = 3;
            this.lblLastName.Text = "Last Name *";
            // 
            // txtLastName
            // 
            this.txtLastName.BackColor = System.Drawing.Color.White;
            this.txtLastName.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtLastName.BorderFocusColor = System.Drawing.Color.DodgerBlue;
            this.txtLastName.BorderRadius = 10;
            this.txtLastName.BorderSize = 1;
            this.txtLastName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLastName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtLastName.ForeColor = System.Drawing.Color.Black;
            this.txtLastName.Location = new System.Drawing.Point(30, 152);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(310, 27);
            this.txtLastName.TabIndex = 4;
            // 
            // lblGender
            // 
            this.lblGender.Font = new System.Drawing.Font("Roboto Mono", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGender.Location = new System.Drawing.Point(30, 186);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(150, 20);
            this.lblGender.TabIndex = 5;
            this.lblGender.Text = "Gender";
            // 
            // cmbGender
            // 
            this.cmbGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGender.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbGender.FormattingEnabled = true;
            this.cmbGender.Items.AddRange(new object[] {
            "Male",
            "Female",
            "Other"});
            this.cmbGender.Location = new System.Drawing.Point(30, 214);
            this.cmbGender.Name = "cmbGender";
            this.cmbGender.Size = new System.Drawing.Size(310, 36);
            this.cmbGender.TabIndex = 6;
            // 
            // lblPhone
            // 
            this.lblPhone.Font = new System.Drawing.Font("Roboto Mono", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhone.Location = new System.Drawing.Point(30, 250);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(150, 20);
            this.lblPhone.TabIndex = 7;
            this.lblPhone.Text = "Phone";
            // 
            // txtPhone
            // 
            this.txtPhone.BackColor = System.Drawing.Color.White;
            this.txtPhone.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtPhone.BorderFocusColor = System.Drawing.Color.DodgerBlue;
            this.txtPhone.BorderRadius = 10;
            this.txtPhone.BorderSize = 1;
            this.txtPhone.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPhone.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPhone.ForeColor = System.Drawing.Color.Black;
            this.txtPhone.Location = new System.Drawing.Point(30, 278);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(310, 27);
            this.txtPhone.TabIndex = 8;
            // 
            // lblEmail
            // 
            this.lblEmail.Font = new System.Drawing.Font("Roboto Mono", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(30, 311);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(150, 20);
            this.lblEmail.TabIndex = 9;
            this.lblEmail.Text = "Email";
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.White;
            this.txtEmail.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtEmail.BorderFocusColor = System.Drawing.Color.DodgerBlue;
            this.txtEmail.BorderRadius = 10;
            this.txtEmail.BorderSize = 1;
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtEmail.ForeColor = System.Drawing.Color.Black;
            this.txtEmail.Location = new System.Drawing.Point(30, 340);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(310, 27);
            this.txtEmail.TabIndex = 10;
            // 
            // lblAddress
            // 
            this.lblAddress.Font = new System.Drawing.Font("Roboto Mono", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress.Location = new System.Drawing.Point(30, 371);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(150, 20);
            this.lblAddress.TabIndex = 11;
            this.lblAddress.Text = "Address";
            // 
            // txtAddress
            // 
            this.txtAddress.BackColor = System.Drawing.Color.White;
            this.txtAddress.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtAddress.BorderFocusColor = System.Drawing.Color.DodgerBlue;
            this.txtAddress.BorderRadius = 10;
            this.txtAddress.BorderSize = 1;
            this.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAddress.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtAddress.ForeColor = System.Drawing.Color.Black;
            this.txtAddress.Location = new System.Drawing.Point(30, 400);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(310, 27);
            this.txtAddress.TabIndex = 12;
            // 
            // lblIDNumber
            // 
            this.lblIDNumber.Font = new System.Drawing.Font("Roboto Mono", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIDNumber.Location = new System.Drawing.Point(30, 433);
            this.lblIDNumber.Name = "lblIDNumber";
            this.lblIDNumber.Size = new System.Drawing.Size(150, 20);
            this.lblIDNumber.TabIndex = 13;
            this.lblIDNumber.Text = "ID / Passport No.";
            // 
            // txtIDNumber
            // 
            this.txtIDNumber.BackColor = System.Drawing.Color.White;
            this.txtIDNumber.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtIDNumber.BorderFocusColor = System.Drawing.Color.DodgerBlue;
            this.txtIDNumber.BorderRadius = 10;
            this.txtIDNumber.BorderSize = 1;
            this.txtIDNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtIDNumber.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtIDNumber.ForeColor = System.Drawing.Color.Black;
            this.txtIDNumber.Location = new System.Drawing.Point(30, 462);
            this.txtIDNumber.Name = "txtIDNumber";
            this.txtIDNumber.Size = new System.Drawing.Size(310, 27);
            this.txtIDNumber.TabIndex = 14;
            // 
            // lblNationality
            // 
            this.lblNationality.Font = new System.Drawing.Font("Roboto Mono", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNationality.Location = new System.Drawing.Point(30, 495);
            this.lblNationality.Name = "lblNationality";
            this.lblNationality.Size = new System.Drawing.Size(150, 20);
            this.lblNationality.TabIndex = 15;
            this.lblNationality.Text = "Nationality";
            // 
            // txtNationality
            // 
            this.txtNationality.BackColor = System.Drawing.Color.White;
            this.txtNationality.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtNationality.BorderFocusColor = System.Drawing.Color.DodgerBlue;
            this.txtNationality.BorderRadius = 10;
            this.txtNationality.BorderSize = 1;
            this.txtNationality.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNationality.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNationality.ForeColor = System.Drawing.Color.Black;
            this.txtNationality.Location = new System.Drawing.Point(30, 524);
            this.txtNationality.Name = "txtNationality";
            this.txtNationality.Size = new System.Drawing.Size(310, 27);
            this.txtNationality.TabIndex = 16;
            // 
            // lblStatus
            // 
            this.lblStatus.Font = new System.Drawing.Font("Roboto Mono", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(30, 557);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(150, 20);
            this.lblStatus.TabIndex = 17;
            this.lblStatus.Text = "Status";
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "ACTIVE",
            "INACTIVE"});
            this.cmbStatus.Location = new System.Drawing.Point(30, 590);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(310, 36);
            this.cmbStatus.TabIndex = 18;
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
            this.btnSave.Font = new System.Drawing.Font("Roboto Mono", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.HoverColor = System.Drawing.Color.RoyalBlue;
            this.btnSave.Location = new System.Drawing.Point(30, 643);
            this.btnSave.Name = "btnSave";
            this.btnSave.NormalColor = System.Drawing.Color.DodgerBlue;
            this.btnSave.PressedColor = System.Drawing.Color.MediumBlue;
            this.btnSave.Size = new System.Drawing.Size(150, 40);
            this.btnSave.TabIndex = 19;
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
            this.btnCancel.Font = new System.Drawing.Font("Roboto Mono", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.HoverColor = System.Drawing.Color.Silver;
            this.btnCancel.Location = new System.Drawing.Point(190, 643);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.NormalColor = System.Drawing.Color.Gainsboro;
            this.btnCancel.PressedColor = System.Drawing.Color.DarkGray;
            this.btnCancel.Size = new System.Drawing.Size(150, 40);
            this.btnCancel.TabIndex = 20;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // GuestForm
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(370, 700);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblFirstName);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.lblGender);
            this.Controls.Add(this.cmbGender);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.lblIDNumber);
            this.Controls.Add(this.txtIDNumber);
            this.Controls.Add(this.lblNationality);
            this.Controls.Add(this.txtNationality);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GuestForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Guest";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblFirstName;
        private hotelmngsystem.RoundedTextBox txtFirstName;
        private System.Windows.Forms.Label lblLastName;
        private hotelmngsystem.RoundedTextBox txtLastName;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.ComboBox cmbGender;
        private System.Windows.Forms.Label lblPhone;
        private hotelmngsystem.RoundedTextBox txtPhone;
        private System.Windows.Forms.Label lblEmail;
        private hotelmngsystem.RoundedTextBox txtEmail;
        private System.Windows.Forms.Label lblAddress;
        private hotelmngsystem.RoundedTextBox txtAddress;
        private System.Windows.Forms.Label lblIDNumber;
        private hotelmngsystem.RoundedTextBox txtIDNumber;
        private System.Windows.Forms.Label lblNationality;
        private hotelmngsystem.RoundedTextBox txtNationality;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbStatus;
        private hotelmngsystem.RoundedButton btnSave;
        private hotelmngsystem.RoundedButton btnCancel;
    }
}

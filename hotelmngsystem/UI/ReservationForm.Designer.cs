namespace hotelmngsystem.UI
{
    partial class ReservationForm
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
            this.lblGuest = new System.Windows.Forms.Label();
            this.cmbGuest = new System.Windows.Forms.ComboBox();
            this.lblRoom = new System.Windows.Forms.Label();
            this.cmbRoom = new System.Windows.Forms.ComboBox();
            this.lblCheckIn = new System.Windows.Forms.Label();
            this.dtpCheckIn = new System.Windows.Forms.DateTimePicker();
            this.lblCheckOut = new System.Windows.Forms.Label();
            this.dtpCheckOut = new System.Windows.Forms.DateTimePicker();
            this.lblAdults = new System.Windows.Forms.Label();
            this.nudAdults = new System.Windows.Forms.NumericUpDown();
            this.lblChildren = new System.Windows.Forms.Label();
            this.nudChildren = new System.Windows.Forms.NumericUpDown();
            this.lblRoomRate = new System.Windows.Forms.Label();
            this.txtRoomRate = new hotelmngsystem.RoundedTextBox();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lblSpecialRequest = new System.Windows.Forms.Label();
            this.txtSpecialRequest = new System.Windows.Forms.TextBox();
            this.btnSave = new hotelmngsystem.RoundedButton();
            this.btnCancel = new hotelmngsystem.RoundedButton();
            this.lblStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudAdults)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudChildren)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Limelight", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lblTitle.Location = new System.Drawing.Point(30, 17);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(340, 43);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "New Reservation";
            // 
            // lblGuest
            // 
            this.lblGuest.Font = new System.Drawing.Font("Roboto Mono", 9F);
            this.lblGuest.Location = new System.Drawing.Point(30, 68);
            this.lblGuest.Name = "lblGuest";
            this.lblGuest.Size = new System.Drawing.Size(200, 20);
            this.lblGuest.TabIndex = 1;
            this.lblGuest.Text = "Guest *";
            // 
            // cmbGuest
            // 
            this.cmbGuest.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbGuest.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbGuest.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbGuest.Location = new System.Drawing.Point(30, 99);
            this.cmbGuest.Name = "cmbGuest";
            this.cmbGuest.Size = new System.Drawing.Size(400, 36);
            this.cmbGuest.TabIndex = 2;
            // 
            // lblRoom
            // 
            this.lblRoom.Font = new System.Drawing.Font("Roboto Mono", 9F);
            this.lblRoom.Location = new System.Drawing.Point(30, 139);
            this.lblRoom.Name = "lblRoom";
            this.lblRoom.Size = new System.Drawing.Size(200, 20);
            this.lblRoom.TabIndex = 3;
            this.lblRoom.Text = "Room *";
            // 
            // cmbRoom
            // 
            this.cmbRoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRoom.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbRoom.Location = new System.Drawing.Point(30, 167);
            this.cmbRoom.Name = "cmbRoom";
            this.cmbRoom.Size = new System.Drawing.Size(400, 36);
            this.cmbRoom.TabIndex = 4;
            this.cmbRoom.SelectedIndexChanged += new System.EventHandler(this.cmbRoom_SelectedIndexChanged);
            // 
            // lblCheckIn
            // 
            this.lblCheckIn.Font = new System.Drawing.Font("Roboto Mono", 9F);
            this.lblCheckIn.Location = new System.Drawing.Point(30, 207);
            this.lblCheckIn.Name = "lblCheckIn";
            this.lblCheckIn.Size = new System.Drawing.Size(190, 20);
            this.lblCheckIn.TabIndex = 5;
            this.lblCheckIn.Text = "Check-in Date";
            // 
            // dtpCheckIn
            // 
            this.dtpCheckIn.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpCheckIn.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCheckIn.Location = new System.Drawing.Point(30, 234);
            this.dtpCheckIn.Name = "dtpCheckIn";
            this.dtpCheckIn.Size = new System.Drawing.Size(190, 34);
            this.dtpCheckIn.TabIndex = 6;
            // 
            // lblCheckOut
            // 
            this.lblCheckOut.Font = new System.Drawing.Font("Roboto Mono", 9F);
            this.lblCheckOut.Location = new System.Drawing.Point(240, 207);
            this.lblCheckOut.Name = "lblCheckOut";
            this.lblCheckOut.Size = new System.Drawing.Size(190, 20);
            this.lblCheckOut.TabIndex = 7;
            this.lblCheckOut.Text = "Check-out Date";
            // 
            // dtpCheckOut
            // 
            this.dtpCheckOut.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpCheckOut.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCheckOut.Location = new System.Drawing.Point(240, 234);
            this.dtpCheckOut.Name = "dtpCheckOut";
            this.dtpCheckOut.Size = new System.Drawing.Size(190, 34);
            this.dtpCheckOut.TabIndex = 8;
            // 
            // lblAdults
            // 
            this.lblAdults.Font = new System.Drawing.Font("Roboto Mono", 9F);
            this.lblAdults.Location = new System.Drawing.Point(30, 272);
            this.lblAdults.Name = "lblAdults";
            this.lblAdults.Size = new System.Drawing.Size(190, 20);
            this.lblAdults.TabIndex = 9;
            this.lblAdults.Text = "Adults";
            // 
            // nudAdults
            // 
            this.nudAdults.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.nudAdults.Location = new System.Drawing.Point(30, 301);
            this.nudAdults.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudAdults.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudAdults.Name = "nudAdults";
            this.nudAdults.Size = new System.Drawing.Size(190, 34);
            this.nudAdults.TabIndex = 10;
            this.nudAdults.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblChildren
            // 
            this.lblChildren.Font = new System.Drawing.Font("Roboto Mono", 9F);
            this.lblChildren.Location = new System.Drawing.Point(240, 272);
            this.lblChildren.Name = "lblChildren";
            this.lblChildren.Size = new System.Drawing.Size(190, 20);
            this.lblChildren.TabIndex = 11;
            this.lblChildren.Text = "Children";
            // 
            // nudChildren
            // 
            this.nudChildren.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.nudChildren.Location = new System.Drawing.Point(240, 301);
            this.nudChildren.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudChildren.Name = "nudChildren";
            this.nudChildren.Size = new System.Drawing.Size(190, 34);
            this.nudChildren.TabIndex = 12;
            // 
            // lblRoomRate
            // 
            this.lblRoomRate.Font = new System.Drawing.Font("Roboto Mono", 9F);
            this.lblRoomRate.Location = new System.Drawing.Point(30, 340);
            this.lblRoomRate.Name = "lblRoomRate";
            this.lblRoomRate.Size = new System.Drawing.Size(190, 20);
            this.lblRoomRate.TabIndex = 13;
            this.lblRoomRate.Text = "Room Rate";
            // 
            // txtRoomRate
            // 
            this.txtRoomRate.BackColor = System.Drawing.Color.White;
            this.txtRoomRate.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtRoomRate.BorderFocusColor = System.Drawing.Color.DodgerBlue;
            this.txtRoomRate.BorderRadius = 10;
            this.txtRoomRate.BorderSize = 1;
            this.txtRoomRate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRoomRate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtRoomRate.ForeColor = System.Drawing.Color.Black;
            this.txtRoomRate.Location = new System.Drawing.Point(30, 368);
            this.txtRoomRate.Multiline = true;
            this.txtRoomRate.Name = "txtRoomRate";
            this.txtRoomRate.Size = new System.Drawing.Size(190, 36);
            this.txtRoomRate.TabIndex = 14;
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(240, 368);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(190, 36);
            this.cmbStatus.TabIndex = 16;
            // 
            // lblSpecialRequest
            // 
            this.lblSpecialRequest.Font = new System.Drawing.Font("Roboto Mono", 9F);
            this.lblSpecialRequest.Location = new System.Drawing.Point(30, 408);
            this.lblSpecialRequest.Name = "lblSpecialRequest";
            this.lblSpecialRequest.Size = new System.Drawing.Size(200, 26);
            this.lblSpecialRequest.TabIndex = 17;
            this.lblSpecialRequest.Text = "Special Request";
            // 
            // txtSpecialRequest
            // 
            this.txtSpecialRequest.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSpecialRequest.Location = new System.Drawing.Point(30, 444);
            this.txtSpecialRequest.Multiline = true;
            this.txtSpecialRequest.Name = "txtSpecialRequest";
            this.txtSpecialRequest.Size = new System.Drawing.Size(400, 70);
            this.txtSpecialRequest.TabIndex = 18;
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
            this.btnSave.Font = new System.Drawing.Font("Roboto Mono", 9F);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.HoverColor = System.Drawing.Color.RoyalBlue;
            this.btnSave.Location = new System.Drawing.Point(30, 530);
            this.btnSave.Name = "btnSave";
            this.btnSave.NormalColor = System.Drawing.Color.DodgerBlue;
            this.btnSave.PressedColor = System.Drawing.Color.MediumBlue;
            this.btnSave.Size = new System.Drawing.Size(190, 40);
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
            this.btnCancel.Font = new System.Drawing.Font("Roboto Mono", 9F);
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.HoverColor = System.Drawing.Color.Silver;
            this.btnCancel.Location = new System.Drawing.Point(240, 530);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.NormalColor = System.Drawing.Color.Gainsboro;
            this.btnCancel.PressedColor = System.Drawing.Color.DarkGray;
            this.btnCancel.Size = new System.Drawing.Size(190, 40);
            this.btnCancel.TabIndex = 20;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.Font = new System.Drawing.Font("Roboto Mono", 9F);
            this.lblStatus.Location = new System.Drawing.Point(240, 340);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(190, 20);
            this.lblStatus.TabIndex = 15;
            this.lblStatus.Text = "Status";
            // 
            // ReservationForm
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(460, 593);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblGuest);
            this.Controls.Add(this.cmbGuest);
            this.Controls.Add(this.lblRoom);
            this.Controls.Add(this.cmbRoom);
            this.Controls.Add(this.lblCheckIn);
            this.Controls.Add(this.dtpCheckIn);
            this.Controls.Add(this.lblCheckOut);
            this.Controls.Add(this.dtpCheckOut);
            this.Controls.Add(this.lblAdults);
            this.Controls.Add(this.nudAdults);
            this.Controls.Add(this.lblChildren);
            this.Controls.Add(this.nudChildren);
            this.Controls.Add(this.lblRoomRate);
            this.Controls.Add(this.txtRoomRate);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.lblSpecialRequest);
            this.Controls.Add(this.txtSpecialRequest);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReservationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Reservation";
            ((System.ComponentModel.ISupportInitialize)(this.nudAdults)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudChildren)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblGuest;
        private System.Windows.Forms.ComboBox cmbGuest;
        private System.Windows.Forms.Label lblRoom;
        private System.Windows.Forms.ComboBox cmbRoom;
        private System.Windows.Forms.Label lblCheckIn;
        private System.Windows.Forms.DateTimePicker dtpCheckIn;
        private System.Windows.Forms.Label lblCheckOut;
        private System.Windows.Forms.DateTimePicker dtpCheckOut;
        private System.Windows.Forms.Label lblAdults;
        private System.Windows.Forms.NumericUpDown nudAdults;
        private System.Windows.Forms.Label lblChildren;
        private System.Windows.Forms.NumericUpDown nudChildren;
        private System.Windows.Forms.Label lblRoomRate;
        private hotelmngsystem.RoundedTextBox txtRoomRate;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label lblSpecialRequest;
        private System.Windows.Forms.TextBox txtSpecialRequest;
        private hotelmngsystem.RoundedButton btnSave;
        private hotelmngsystem.RoundedButton btnCancel;
        private System.Windows.Forms.Label lblStatus;
    }
}

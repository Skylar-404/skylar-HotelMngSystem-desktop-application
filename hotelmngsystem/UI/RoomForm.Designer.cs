namespace hotelmngsystem.UI
{
    partial class RoomForm
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
            this.lblRoomNumber = new System.Windows.Forms.Label();
            this.txtRoomNumber = new hotelmngsystem.RoundedTextBox();
            this.lblRoomType = new System.Windows.Forms.Label();
            this.cmbRoomType = new System.Windows.Forms.ComboBox();
            this.lblFloor = new System.Windows.Forms.Label();
            this.nudFloor = new System.Windows.Forms.NumericUpDown();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.btnSave = new hotelmngsystem.RoundedButton();
            this.btnCancel = new hotelmngsystem.RoundedButton();
            ((System.ComponentModel.ISupportInitialize)(this.nudFloor)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Limelight", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lblTitle.Location = new System.Drawing.Point(30, 23);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(300, 43);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Add Room";
            // 
            // lblRoomNumber
            // 
            this.lblRoomNumber.Font = new System.Drawing.Font("Roboto Mono", 9F);
            this.lblRoomNumber.Location = new System.Drawing.Point(30, 76);
            this.lblRoomNumber.Name = "lblRoomNumber";
            this.lblRoomNumber.Size = new System.Drawing.Size(200, 20);
            this.lblRoomNumber.TabIndex = 1;
            this.lblRoomNumber.Text = "Room Number *";
            // 
            // txtRoomNumber
            // 
            this.txtRoomNumber.BackColor = System.Drawing.Color.White;
            this.txtRoomNumber.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtRoomNumber.BorderFocusColor = System.Drawing.Color.DodgerBlue;
            this.txtRoomNumber.BorderRadius = 10;
            this.txtRoomNumber.BorderSize = 1;
            this.txtRoomNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRoomNumber.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtRoomNumber.ForeColor = System.Drawing.Color.Black;
            this.txtRoomNumber.Location = new System.Drawing.Point(30, 106);
            this.txtRoomNumber.Name = "txtRoomNumber";
            this.txtRoomNumber.Size = new System.Drawing.Size(300, 27);
            this.txtRoomNumber.TabIndex = 2;
            // 
            // lblRoomType
            // 
            this.lblRoomType.Font = new System.Drawing.Font("Roboto Mono", 9F);
            this.lblRoomType.Location = new System.Drawing.Point(30, 138);
            this.lblRoomType.Name = "lblRoomType";
            this.lblRoomType.Size = new System.Drawing.Size(200, 20);
            this.lblRoomType.TabIndex = 3;
            this.lblRoomType.Text = "Room Type *";
            // 
            // cmbRoomType
            // 
            this.cmbRoomType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRoomType.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbRoomType.Location = new System.Drawing.Point(30, 167);
            this.cmbRoomType.Name = "cmbRoomType";
            this.cmbRoomType.Size = new System.Drawing.Size(300, 36);
            this.cmbRoomType.TabIndex = 4;
            // 
            // lblFloor
            // 
            this.lblFloor.Font = new System.Drawing.Font("Roboto Mono", 9F);
            this.lblFloor.Location = new System.Drawing.Point(30, 209);
            this.lblFloor.Name = "lblFloor";
            this.lblFloor.Size = new System.Drawing.Size(200, 20);
            this.lblFloor.TabIndex = 5;
            this.lblFloor.Text = "Floor Number";
            // 
            // nudFloor
            // 
            this.nudFloor.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.nudFloor.Location = new System.Drawing.Point(30, 237);
            this.nudFloor.Name = "nudFloor";
            this.nudFloor.Size = new System.Drawing.Size(300, 34);
            this.nudFloor.TabIndex = 6;
            // 
            // lblStatus
            // 
            this.lblStatus.Font = new System.Drawing.Font("Roboto Mono", 9F);
            this.lblStatus.Location = new System.Drawing.Point(30, 276);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(200, 20);
            this.lblStatus.TabIndex = 7;
            this.lblStatus.Text = "Status";
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbStatus.Location = new System.Drawing.Point(30, 304);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(300, 36);
            this.cmbStatus.TabIndex = 8;
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
            this.btnSave.Location = new System.Drawing.Point(30, 354);
            this.btnSave.Name = "btnSave";
            this.btnSave.NormalColor = System.Drawing.Color.DodgerBlue;
            this.btnSave.PressedColor = System.Drawing.Color.MediumBlue;
            this.btnSave.Size = new System.Drawing.Size(140, 40);
            this.btnSave.TabIndex = 9;
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
            this.btnCancel.Location = new System.Drawing.Point(190, 354);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.NormalColor = System.Drawing.Color.Gainsboro;
            this.btnCancel.PressedColor = System.Drawing.Color.DarkGray;
            this.btnCancel.Size = new System.Drawing.Size(140, 40);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // RoomForm
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(360, 414);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblRoomNumber);
            this.Controls.Add(this.txtRoomNumber);
            this.Controls.Add(this.lblRoomType);
            this.Controls.Add(this.cmbRoomType);
            this.Controls.Add(this.lblFloor);
            this.Controls.Add(this.nudFloor);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RoomForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Room";
            ((System.ComponentModel.ISupportInitialize)(this.nudFloor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblRoomNumber;
        private hotelmngsystem.RoundedTextBox txtRoomNumber;
        private System.Windows.Forms.Label lblRoomType;
        private System.Windows.Forms.ComboBox cmbRoomType;
        private System.Windows.Forms.Label lblFloor;
        private System.Windows.Forms.NumericUpDown nudFloor;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbStatus;
        private hotelmngsystem.RoundedButton btnSave;
        private hotelmngsystem.RoundedButton btnCancel;
    }
}

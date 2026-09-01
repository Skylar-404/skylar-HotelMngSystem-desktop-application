namespace hotelmngsystem.UI
{
    partial class loginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.roundedButton1 = new hotelmngsystem.RoundedButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.roundedButton21 = new hotelmngsystem.RoundedButton2();
            this.roundedButton22 = new hotelmngsystem.RoundedButton2();
            this.roundedButton23 = new hotelmngsystem.RoundedButton2();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::hotelmngsystem.Properties.Resources.logo_icon;
            this.pictureBox1.Location = new System.Drawing.Point(147, 38);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(139, 113);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(66, 517);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(300, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "Forgot Password? Contact Administrator.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Roboto Mono", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(79, 235);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(270, 21);
            this.label4.TabIndex = 6;
            this.label4.Text = "Please Sign-in to continue";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Limelight", 22F);
            this.label3.Location = new System.Drawing.Point(36, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(361, 54);
            this.label3.TabIndex = 5;
            this.label3.Text = "Welcome Back";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Roboto Mono", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(37, 359);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto Mono", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(37, 279);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Username";
            // 
            // roundedButton1
            // 
            this.roundedButton1.BackColor = System.Drawing.Color.White;
            this.roundedButton1.BorderColor = System.Drawing.Color.Transparent;
            this.roundedButton1.BorderRadius = 20;
            this.roundedButton1.BorderSize = 0;
            this.roundedButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.roundedButton1.FlatAppearance.BorderSize = 0;
            this.roundedButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundedButton1.Font = new System.Drawing.Font("Roboto Mono", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roundedButton1.ForeColor = System.Drawing.Color.White;
            this.roundedButton1.HoverColor = System.Drawing.Color.RoyalBlue;
            this.roundedButton1.Location = new System.Drawing.Point(41, 445);
            this.roundedButton1.Name = "roundedButton1";
            this.roundedButton1.NormalColor = System.Drawing.Color.DodgerBlue;
            this.roundedButton1.PressedColor = System.Drawing.Color.MediumBlue;
            this.roundedButton1.Size = new System.Drawing.Size(349, 51);
            this.roundedButton1.TabIndex = 3;
            this.roundedButton1.Text = "Sign In";
            this.roundedButton1.UseVisualStyleBackColor = false;
            this.roundedButton1.Click += new System.EventHandler(this.roundedButton1_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox1.Location = new System.Drawing.Point(41, 311);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(349, 35);
            this.textBox1.TabIndex = 8;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox2.Location = new System.Drawing.Point(41, 390);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.PasswordChar = '●';
            this.textBox2.Size = new System.Drawing.Size(349, 35);
            this.textBox2.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(116, 552);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(191, 20);
            this.label6.TabIndex = 6;
            this.label6.Text = "Hotline 24/7: 023 334 443";
            // 
            // roundedButton21
            // 
            this.roundedButton21.BackColor = System.Drawing.Color.Red;
            this.roundedButton21.BorderColor = System.Drawing.Color.Transparent;
            this.roundedButton21.BorderRadius = 20;
            this.roundedButton21.BorderSize = 0;
            this.roundedButton21.Cursor = System.Windows.Forms.Cursors.Hand;
            this.roundedButton21.FlatAppearance.BorderSize = 0;
            this.roundedButton21.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundedButton21.ForeColor = System.Drawing.Color.Transparent;
            this.roundedButton21.Location = new System.Drawing.Point(70, 12);
            this.roundedButton21.Name = "roundedButton21";
            this.roundedButton21.Size = new System.Drawing.Size(20, 20);
            this.roundedButton21.TabIndex = 10;
            this.roundedButton21.UseVisualStyleBackColor = false;
            this.roundedButton21.Click += new System.EventHandler(this.roundedButton21_Click);
            // 
            // roundedButton22
            // 
            this.roundedButton22.BackColor = System.Drawing.Color.Lime;
            this.roundedButton22.BorderColor = System.Drawing.Color.Transparent;
            this.roundedButton22.BorderRadius = 20;
            this.roundedButton22.BorderSize = 0;
            this.roundedButton22.Cursor = System.Windows.Forms.Cursors.Hand;
            this.roundedButton22.FlatAppearance.BorderSize = 0;
            this.roundedButton22.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundedButton22.ForeColor = System.Drawing.Color.Transparent;
            this.roundedButton22.Location = new System.Drawing.Point(44, 12);
            this.roundedButton22.Name = "roundedButton22";
            this.roundedButton22.Size = new System.Drawing.Size(20, 20);
            this.roundedButton22.TabIndex = 10;
            this.roundedButton22.UseVisualStyleBackColor = false;
            // 
            // roundedButton23
            // 
            this.roundedButton23.BackColor = System.Drawing.Color.Orange;
            this.roundedButton23.BorderColor = System.Drawing.Color.Transparent;
            this.roundedButton23.BorderRadius = 20;
            this.roundedButton23.BorderSize = 0;
            this.roundedButton23.Cursor = System.Windows.Forms.Cursors.Hand;
            this.roundedButton23.FlatAppearance.BorderSize = 0;
            this.roundedButton23.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundedButton23.ForeColor = System.Drawing.Color.Transparent;
            this.roundedButton23.Location = new System.Drawing.Point(18, 12);
            this.roundedButton23.Name = "roundedButton23";
            this.roundedButton23.Size = new System.Drawing.Size(20, 20);
            this.roundedButton23.TabIndex = 10;
            this.roundedButton23.UseVisualStyleBackColor = false;
            // 
            // loginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 627);
            this.Controls.Add(this.roundedButton23);
            this.Controls.Add(this.roundedButton22);
            this.Controls.Add(this.roundedButton21);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.roundedButton1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "loginForm";
            this.Text = "loginForm";
            this.Load += new System.EventHandler(this.loginForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private RoundedButton roundedButton1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label6;
        private RoundedButton2 roundedButton21;
        private RoundedButton2 roundedButton22;
        private RoundedButton2 roundedButton23;
    }
}
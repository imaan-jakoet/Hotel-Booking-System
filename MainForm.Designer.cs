namespace PhumlaKamnandi.PresentationLayer.Forms
{
    partial class MainForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnMakeBooking = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnViewBookings = new System.Windows.Forms.Button();
            this.lblUsername = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(487, 170);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1085, 138);
            this.label1.TabIndex = 1;
            this.label1.Text = "Welcome To Phumla Kamnandi Hotels\r\nGuest Reservation";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnMakeBooking
            // 
            this.btnMakeBooking.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnMakeBooking.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMakeBooking.Location = new System.Drawing.Point(926, 499);
            this.btnMakeBooking.Name = "btnMakeBooking";
            this.btnMakeBooking.Size = new System.Drawing.Size(232, 111);
            this.btnMakeBooking.TabIndex = 2;
            this.btnMakeBooking.Text = "Make A Booking";
            this.btnMakeBooking.UseVisualStyleBackColor = false;
            this.btnMakeBooking.Click += new System.EventHandler(this.btnMakeBooking_Click);
            // 
            // btnReports
            // 
            this.btnReports.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnReports.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReports.Location = new System.Drawing.Point(495, 499);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(232, 111);
            this.btnReports.TabIndex = 3;
            this.btnReports.Text = "Reports";
            this.btnReports.UseVisualStyleBackColor = false;
            this.btnReports.Click += new System.EventHandler(this.btnGenerateReports_Click);
            // 
            // btnViewBookings
            // 
            this.btnViewBookings.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnViewBookings.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewBookings.Location = new System.Drawing.Point(1357, 499);
            this.btnViewBookings.Name = "btnViewBookings";
            this.btnViewBookings.Size = new System.Drawing.Size(232, 111);
            this.btnViewBookings.TabIndex = 4;
            this.btnViewBookings.Text = "View Bookings";
            this.btnViewBookings.UseVisualStyleBackColor = false;
            this.btnViewBookings.Click += new System.EventHandler(this.btnViewBookings_Click);
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.Location = new System.Drawing.Point(1249, 9);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(0, 25);
            this.lblUsername.TabIndex = 5;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1788, 810);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.btnViewBookings);
            this.Controls.Add(this.btnReports);
            this.Controls.Add(this.btnMakeBooking);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "HomePage";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnMakeBooking;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnViewBookings;
        private System.Windows.Forms.Label lblUsername;
    }
}
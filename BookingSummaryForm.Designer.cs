namespace PhumlaKamnandi.PresentationLayer.Forms
{
    partial class BookingSummaryForm
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
            this.btnClose = new System.Windows.Forms.Button();
            this.btnEmail = new System.Windows.Forms.Button();
            this.label20 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtDepositToPay = new System.Windows.Forms.TextBox();
            this.txtAccommodation = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtBalanceDue = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtRatePerNight = new System.Windows.Forms.TextBox();
            this.txtNumberOfNights = new System.Windows.Forms.TextBox();
            this.txtGuests = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtRoomType = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtCheckOutDate = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtCheckInDate = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtBookingDate = new System.Windows.Forms.TextBox();
            this.txtBookingReference = new System.Windows.Forms.TextBox();
            this.txtStatusConfirmed = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(998, 876);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(300, 66);
            this.btnClose.TabIndex = 50;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnEmail
            // 
            this.btnEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmail.Location = new System.Drawing.Point(528, 876);
            this.btnEmail.Name = "btnEmail";
            this.btnEmail.Size = new System.Drawing.Size(300, 66);
            this.btnEmail.TabIndex = 49;
            this.btnEmail.Text = "Email";
            this.btnEmail.UseVisualStyleBackColor = false;
            this.btnEmail.Click += new System.EventHandler(this.btnEmail_Click);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(660, 744);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(504, 100);
            this.label20.TabIndex = 48;
            this.label20.Text = "IMPORTANT INFORMATION\r\n* Check-In Time: 14:00 (2pm)\r\n* Check-Out Time: 11:00 (11a" +
    "m)\r\n* Deposit must be paid within 14 days before arrival";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtTotalAmount);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.txtDepositToPay);
            this.groupBox2.Controls.Add(this.txtAccommodation);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.txtBalanceDue);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(363, 523);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1036, 197);
            this.groupBox2.TabIndex = 47;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Financial Summary";
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalAmount.Location = new System.Drawing.Point(809, 165);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.Size = new System.Drawing.Size(183, 22);
            this.txtTotalAmount.TabIndex = 28;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(10, 165);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(152, 20);
            this.label19.TabIndex = 27;
            this.label19.Text = "TOTAL AMOUNT";
            // 
            // txtDepositToPay
            // 
            this.txtDepositToPay.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDepositToPay.Location = new System.Drawing.Point(809, 74);
            this.txtDepositToPay.Name = "txtDepositToPay";
            this.txtDepositToPay.Size = new System.Drawing.Size(183, 22);
            this.txtDepositToPay.TabIndex = 26;
            // 
            // txtAccommodation
            // 
            this.txtAccommodation.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccommodation.Location = new System.Drawing.Point(809, 32);
            this.txtAccommodation.Name = "txtAccommodation";
            this.txtAccommodation.Size = new System.Drawing.Size(183, 22);
            this.txtAccommodation.TabIndex = 24;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(10, 74);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(205, 20);
            this.label16.TabIndex = 16;
            this.label16.Text = "Deposit To Be Paid (10%)";
            // 
            // txtBalanceDue
            // 
            this.txtBalanceDue.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBalanceDue.Location = new System.Drawing.Point(809, 111);
            this.txtBalanceDue.Name = "txtBalanceDue";
            this.txtBalanceDue.Size = new System.Drawing.Size(183, 22);
            this.txtBalanceDue.TabIndex = 25;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(10, 32);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(330, 20);
            this.label17.TabIndex = 15;
            this.label17.Text = "Accommodation (Number of Nights x Rate)";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(10, 111);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(198, 20);
            this.label18.TabIndex = 17;
            this.label18.Text = "Balance Due At Check-in";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtRatePerNight);
            this.groupBox1.Controls.Add(this.txtNumberOfNights);
            this.groupBox1.Controls.Add(this.txtGuests);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.txtRoomType);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.txtCheckOutDate);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.txtCheckInDate);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(363, 324);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1036, 158);
            this.groupBox1.TabIndex = 46;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Accommodation Details";
            // 
            // txtRatePerNight
            // 
            this.txtRatePerNight.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRatePerNight.Location = new System.Drawing.Point(759, 75);
            this.txtRatePerNight.Name = "txtRatePerNight";
            this.txtRatePerNight.Size = new System.Drawing.Size(286, 22);
            this.txtRatePerNight.TabIndex = 26;
            // 
            // txtNumberOfNights
            // 
            this.txtNumberOfNights.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumberOfNights.Location = new System.Drawing.Point(206, 109);
            this.txtNumberOfNights.Name = "txtNumberOfNights";
            this.txtNumberOfNights.Size = new System.Drawing.Size(286, 22);
            this.txtNumberOfNights.TabIndex = 23;
            // 
            // txtGuests
            // 
            this.txtGuests.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGuests.Location = new System.Drawing.Point(759, 33);
            this.txtGuests.Name = "txtGuests";
            this.txtGuests.Size = new System.Drawing.Size(286, 22);
            this.txtGuests.TabIndex = 24;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(10, 74);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(131, 20);
            this.label15.TabIndex = 16;
            this.label15.Text = "Check-out Date:";
            // 
            // txtRoomType
            // 
            this.txtRoomType.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRoomType.Location = new System.Drawing.Point(759, 112);
            this.txtRoomType.Name = "txtRoomType";
            this.txtRoomType.Size = new System.Drawing.Size(286, 22);
            this.txtRoomType.TabIndex = 25;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(10, 32);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(121, 20);
            this.label14.TabIndex = 15;
            this.label14.Text = "Check-in Date:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(10, 111);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(145, 20);
            this.label13.TabIndex = 17;
            this.label13.Text = "Number of Nights:";
            // 
            // txtCheckOutDate
            // 
            this.txtCheckOutDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCheckOutDate.Location = new System.Drawing.Point(206, 72);
            this.txtCheckOutDate.Name = "txtCheckOutDate";
            this.txtCheckOutDate.Size = new System.Drawing.Size(286, 22);
            this.txtCheckOutDate.TabIndex = 22;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(548, 35);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(151, 20);
            this.label12.TabIndex = 18;
            this.label12.Text = "Number of Guests:";
            // 
            // txtCheckInDate
            // 
            this.txtCheckInDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCheckInDate.Location = new System.Drawing.Point(206, 30);
            this.txtCheckInDate.Name = "txtCheckInDate";
            this.txtCheckInDate.Size = new System.Drawing.Size(286, 22);
            this.txtCheckInDate.TabIndex = 21;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(548, 77);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(122, 20);
            this.label11.TabIndex = 19;
            this.label11.Text = "Rate per Night:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(548, 114);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(99, 20);
            this.label10.TabIndex = 20;
            this.label10.Text = "Room Type:";
            // 
            // txtBookingDate
            // 
            this.txtBookingDate.Location = new System.Drawing.Point(1122, 229);
            this.txtBookingDate.Name = "txtBookingDate";
            this.txtBookingDate.Size = new System.Drawing.Size(223, 22);
            this.txtBookingDate.TabIndex = 45;
            // 
            // txtBookingReference
            // 
            this.txtBookingReference.Location = new System.Drawing.Point(1122, 187);
            this.txtBookingReference.Name = "txtBookingReference";
            this.txtBookingReference.Size = new System.Drawing.Size(223, 22);
            this.txtBookingReference.TabIndex = 44;
            // 
            // txtStatusConfirmed
            // 
            this.txtStatusConfirmed.Location = new System.Drawing.Point(1122, 266);
            this.txtStatusConfirmed.Name = "txtStatusConfirmed";
            this.txtStatusConfirmed.Size = new System.Drawing.Size(223, 22);
            this.txtStatusConfirmed.TabIndex = 43;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(569, 264);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(223, 22);
            this.txtEmail.TabIndex = 42;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(569, 227);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(223, 22);
            this.txtPhone.TabIndex = 41;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(569, 185);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(223, 22);
            this.txtName.TabIndex = 40;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(911, 266);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(144, 20);
            this.label9.TabIndex = 39;
            this.label9.Text = "Status Confirmed:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(911, 229);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(115, 20);
            this.label8.TabIndex = 38;
            this.label8.Text = "Booking Date:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(911, 187);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(156, 20);
            this.label7.TabIndex = 37;
            this.label7.Text = "Booking Reference:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(436, 266);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 20);
            this.label6.TabIndex = 36;
            this.label6.Text = "Email:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(436, 187);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 20);
            this.label5.TabIndex = 35;
            this.label5.Text = "Name:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(436, 229);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 20);
            this.label4.TabIndex = 34;
            this.label4.Text = "Phone:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1050, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(197, 29);
            this.label3.TabIndex = 33;
            this.label3.Text = "Booking Details";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(565, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 29);
            this.label2.TabIndex = 32;
            this.label2.Text = "Guest Details";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(700, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(406, 76);
            this.label1.TabIndex = 31;
            this.label1.Text = "Phumla Kamnandi Hotels\r\nBooking Confirmation";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BookingSummaryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1760, 1044);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnEmail);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtBookingDate);
            this.Controls.Add(this.txtBookingReference);
            this.Controls.Add(this.txtStatusConfirmed);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "BookingSummaryForm";
            this.Text = "BookingSummaryForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnEmail;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtTotalAmount;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtDepositToPay;
        private System.Windows.Forms.TextBox txtAccommodation;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtBalanceDue;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtRatePerNight;
        private System.Windows.Forms.TextBox txtNumberOfNights;
        private System.Windows.Forms.TextBox txtGuests;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtRoomType;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtCheckOutDate;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtCheckInDate;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtBookingDate;
        private System.Windows.Forms.TextBox txtBookingReference;
        private System.Windows.Forms.TextBox txtStatusConfirmed;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
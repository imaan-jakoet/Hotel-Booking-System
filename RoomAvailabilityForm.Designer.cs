namespace PhumlaKamnandi.PresentationLayer.Forms
{
    partial class RoomAvailabilityForm
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
            this.btnCancelBooking = new System.Windows.Forms.Button();
            this.btnReturnToRoomSelection = new System.Windows.Forms.Button();
            this.btnBookRoom = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTotalDeposit = new System.Windows.Forms.TextBox();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.txtTotalNights = new System.Windows.Forms.TextBox();
            this.txtRatePerNight = new System.Windows.Forms.TextBox();
            this.txtSeason = new System.Windows.Forms.TextBox();
            this.txtRoomsAvailable = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lstAvailableRooms = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancelBooking
            // 
            this.btnCancelBooking.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnCancelBooking.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelBooking.Location = new System.Drawing.Point(833, 391);
            this.btnCancelBooking.Name = "btnCancelBooking";
            this.btnCancelBooking.Size = new System.Drawing.Size(194, 92);
            this.btnCancelBooking.TabIndex = 18;
            this.btnCancelBooking.Text = "Cancel Booking";
            this.btnCancelBooking.UseVisualStyleBackColor = false;
            this.btnCancelBooking.Click += new System.EventHandler(this.btnCancelBooking_Click);
            // 
            // btnReturnToRoomSelection
            // 
            this.btnReturnToRoomSelection.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnReturnToRoomSelection.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReturnToRoomSelection.Location = new System.Drawing.Point(1063, 391);
            this.btnReturnToRoomSelection.Name = "btnReturnToRoomSelection";
            this.btnReturnToRoomSelection.Size = new System.Drawing.Size(194, 92);
            this.btnReturnToRoomSelection.TabIndex = 17;
            this.btnReturnToRoomSelection.Text = "Return To Room Selection";
            this.btnReturnToRoomSelection.UseVisualStyleBackColor = false;
            this.btnReturnToRoomSelection.Click += new System.EventHandler(this.btnReturnToRoomSelection_Click);
            // 
            // btnBookRoom
            // 
            this.btnBookRoom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnBookRoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBookRoom.Location = new System.Drawing.Point(1308, 391);
            this.btnBookRoom.Name = "btnBookRoom";
            this.btnBookRoom.Size = new System.Drawing.Size(194, 92);
            this.btnBookRoom.TabIndex = 16;
            this.btnBookRoom.Text = "Book Room";
            this.btnBookRoom.UseVisualStyleBackColor = false;
            this.btnBookRoom.Click += new System.EventHandler(this.btnBookRoom_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCancelBooking);
            this.groupBox1.Controls.Add(this.lstAvailableRooms);
            this.groupBox1.Controls.Add(this.btnReturnToRoomSelection);
            this.groupBox1.Controls.Add(this.txtTotalDeposit);
            this.groupBox1.Controls.Add(this.btnBookRoom);
            this.groupBox1.Controls.Add(this.txtTotalAmount);
            this.groupBox1.Controls.Add(this.txtTotalNights);
            this.groupBox1.Controls.Add(this.txtRatePerNight);
            this.groupBox1.Controls.Add(this.txtSeason);
            this.groupBox1.Controls.Add(this.txtRoomsAvailable);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(73, 114);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1564, 544);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Room Availability";
            // 
            // txtTotalDeposit
            // 
            this.txtTotalDeposit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalDeposit.Location = new System.Drawing.Point(251, 459);
            this.txtTotalDeposit.Name = "txtTotalDeposit";
            this.txtTotalDeposit.Size = new System.Drawing.Size(483, 27);
            this.txtTotalDeposit.TabIndex = 11;
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalAmount.Location = new System.Drawing.Point(251, 376);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.Size = new System.Drawing.Size(483, 27);
            this.txtTotalAmount.TabIndex = 10;
            // 
            // txtTotalNights
            // 
            this.txtTotalNights.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalNights.Location = new System.Drawing.Point(251, 303);
            this.txtTotalNights.Name = "txtTotalNights";
            this.txtTotalNights.Size = new System.Drawing.Size(483, 27);
            this.txtTotalNights.TabIndex = 9;
            // 
            // txtRatePerNight
            // 
            this.txtRatePerNight.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRatePerNight.Location = new System.Drawing.Point(251, 234);
            this.txtRatePerNight.Name = "txtRatePerNight";
            this.txtRatePerNight.Size = new System.Drawing.Size(483, 27);
            this.txtRatePerNight.TabIndex = 8;
            // 
            // txtSeason
            // 
            this.txtSeason.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSeason.Location = new System.Drawing.Point(251, 151);
            this.txtSeason.Name = "txtSeason";
            this.txtSeason.Size = new System.Drawing.Size(483, 27);
            this.txtSeason.TabIndex = 7;
            // 
            // txtRoomsAvailable
            // 
            this.txtRoomsAvailable.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRoomsAvailable.Location = new System.Drawing.Point(251, 89);
            this.txtRoomsAvailable.Name = "txtRoomsAvailable";
            this.txtRoomsAvailable.Size = new System.Drawing.Size(483, 27);
            this.txtRoomsAvailable.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(28, 458);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(133, 25);
            this.label6.TabIndex = 5;
            this.label6.Text = "Total Deposit:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(28, 375);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 25);
            this.label5.TabIndex = 4;
            this.label5.Text = "Total Amount:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(28, 302);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "Total Nights:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(28, 240);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Rate per Night:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(28, 157);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Season:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Rooms Available:";
            // 
            // lstAvailableRooms
            // 
            this.lstAvailableRooms.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstAvailableRooms.FormattingEnabled = true;
            this.lstAvailableRooms.ItemHeight = 25;
            this.lstAvailableRooms.Location = new System.Drawing.Point(861, 57);
            this.lstAvailableRooms.Name = "lstAvailableRooms";
            this.lstAvailableRooms.Size = new System.Drawing.Size(657, 254);
            this.lstAvailableRooms.TabIndex = 19;
            // 
            // RoomAvailabilityForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1713, 1094);
            this.Controls.Add(this.groupBox1);
            this.Name = "RoomAvailabilityForm";
            this.Text = "RoomAvailabilityForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancelBooking;
        private System.Windows.Forms.Button btnReturnToRoomSelection;
        private System.Windows.Forms.Button btnBookRoom;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtTotalDeposit;
        private System.Windows.Forms.TextBox txtTotalAmount;
        private System.Windows.Forms.TextBox txtTotalNights;
        private System.Windows.Forms.TextBox txtRatePerNight;
        private System.Windows.Forms.TextBox txtSeason;
        private System.Windows.Forms.TextBox txtRoomsAvailable;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstAvailableRooms;
    }
}
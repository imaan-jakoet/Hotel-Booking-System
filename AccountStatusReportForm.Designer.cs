namespace PhumlaKamnandi.PresentationLayer.Forms
{
    partial class AccountStatusReportForm
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
            this.btnGenerateReport = new System.Windows.Forms.Button();
            this.btnBackToHome = new System.Windows.Forms.Button();
            this.txtCorporateAccounts = new System.Windows.Forms.TextBox();
            this.txtPendingDeposits = new System.Windows.Forms.TextBox();
            this.txtConfirmedBookings = new System.Windows.Forms.TextBox();
            this.txtTotalOutstanding = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvReport = new System.Windows.Forms.DataGridView();
            this.txtOverdueAccounts = new System.Windows.Forms.TextBox();
            this.txtTotalAccounts = new System.Windows.Forms.TextBox();
            this.txtOutstandingDeposits = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblReportDate = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGenerateReport
            // 
            this.btnGenerateReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnGenerateReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateReport.Location = new System.Drawing.Point(1486, 185);
            this.btnGenerateReport.Name = "btnGenerateReport";
            this.btnGenerateReport.Size = new System.Drawing.Size(204, 72);
            this.btnGenerateReport.TabIndex = 46;
            this.btnGenerateReport.Text = "Generate Report";
            this.btnGenerateReport.UseVisualStyleBackColor = false;
            this.btnGenerateReport.Click += new System.EventHandler(this.btnGenerateReport_Click);
            // 
            // btnBackToHome
            // 
            this.btnBackToHome.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnBackToHome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackToHome.Location = new System.Drawing.Point(1486, 269);
            this.btnBackToHome.Name = "btnBackToHome";
            this.btnBackToHome.Size = new System.Drawing.Size(204, 75);
            this.btnBackToHome.TabIndex = 45;
            this.btnBackToHome.Text = "Back To Home";
            this.btnBackToHome.UseVisualStyleBackColor = false;
            this.btnBackToHome.Click += new System.EventHandler(this.btnBackToHome_Click);
            // 
            // txtCorporateAccounts
            // 
            this.txtCorporateAccounts.Location = new System.Drawing.Point(1222, 858);
            this.txtCorporateAccounts.Name = "txtCorporateAccounts";
            this.txtCorporateAccounts.Size = new System.Drawing.Size(224, 22);
            this.txtCorporateAccounts.TabIndex = 44;
            // 
            // txtPendingDeposits
            // 
            this.txtPendingDeposits.Location = new System.Drawing.Point(1222, 797);
            this.txtPendingDeposits.Name = "txtPendingDeposits";
            this.txtPendingDeposits.Size = new System.Drawing.Size(224, 22);
            this.txtPendingDeposits.TabIndex = 43;
            // 
            // txtConfirmedBookings
            // 
            this.txtConfirmedBookings.Location = new System.Drawing.Point(494, 797);
            this.txtConfirmedBookings.Name = "txtConfirmedBookings";
            this.txtConfirmedBookings.Size = new System.Drawing.Size(224, 22);
            this.txtConfirmedBookings.TabIndex = 42;
            // 
            // txtTotalOutstanding
            // 
            this.txtTotalOutstanding.Location = new System.Drawing.Point(494, 857);
            this.txtTotalOutstanding.Name = "txtTotalOutstanding";
            this.txtTotalOutstanding.Size = new System.Drawing.Size(224, 22);
            this.txtTotalOutstanding.TabIndex = 40;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(933, 853);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(192, 25);
            this.label11.TabIndex = 39;
            this.label11.Text = "Corporate Accounts:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(933, 792);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(171, 25);
            this.label12.TabIndex = 38;
            this.label12.Text = "Pending Deposits:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(184, 852);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(173, 25);
            this.label9.TabIndex = 37;
            this.label9.Text = "Total Outstanding:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(184, 792);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(194, 25);
            this.label7.TabIndex = 35;
            this.label7.Text = "Confirmed Bookings:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(725, 715);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(273, 38);
            this.label6.TabIndex = 34;
            this.label6.Text = "Status Summary";
            // 
            // dgvReport
            // 
            this.dgvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReport.Location = new System.Drawing.Point(188, 361);
            this.dgvReport.Name = "dgvReport";
            this.dgvReport.RowHeadersWidth = 51;
            this.dgvReport.RowTemplate.Height = 24;
            this.dgvReport.Size = new System.Drawing.Size(1365, 338);
            this.dgvReport.TabIndex = 33;
            // 
            // txtOverdueAccounts
            // 
            this.txtOverdueAccounts.Location = new System.Drawing.Point(1177, 275);
            this.txtOverdueAccounts.Name = "txtOverdueAccounts";
            this.txtOverdueAccounts.Size = new System.Drawing.Size(236, 22);
            this.txtOverdueAccounts.TabIndex = 32;
            // 
            // txtTotalAccounts
            // 
            this.txtTotalAccounts.Location = new System.Drawing.Point(1177, 213);
            this.txtTotalAccounts.Name = "txtTotalAccounts";
            this.txtTotalAccounts.Size = new System.Drawing.Size(236, 22);
            this.txtTotalAccounts.TabIndex = 31;
            // 
            // txtOutstandingDeposits
            // 
            this.txtOutstandingDeposits.Location = new System.Drawing.Point(599, 275);
            this.txtOutstandingDeposits.Name = "txtOutstandingDeposits";
            this.txtOutstandingDeposits.Size = new System.Drawing.Size(236, 22);
            this.txtOutstandingDeposits.TabIndex = 30;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(895, 275);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(181, 25);
            this.label5.TabIndex = 28;
            this.label5.Text = "Overdue Accounts:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(895, 213);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(149, 25);
            this.label4.TabIndex = 27;
            this.label4.Text = "Total Accounts:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(291, 275);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(205, 25);
            this.label3.TabIndex = 26;
            this.label3.Text = "Outstanding Deposits:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(291, 213);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 25);
            this.label2.TabIndex = 25;
            this.label2.Text = "Report Date:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(619, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(663, 102);
            this.label1.TabIndex = 24;
            this.label1.Text = "Phumla Kamnandi Hotels\r\nGuest Account Status Summary";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblReportDate
            // 
            this.lblReportDate.AutoSize = true;
            this.lblReportDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReportDate.Location = new System.Drawing.Point(830, 213);
            this.lblReportDate.Name = "lblReportDate";
            this.lblReportDate.Size = new System.Drawing.Size(0, 25);
            this.lblReportDate.TabIndex = 47;
            // 
            // AccountStatusReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1759, 923);
            this.Controls.Add(this.lblReportDate);
            this.Controls.Add(this.btnGenerateReport);
            this.Controls.Add(this.btnBackToHome);
            this.Controls.Add(this.txtCorporateAccounts);
            this.Controls.Add(this.txtPendingDeposits);
            this.Controls.Add(this.txtConfirmedBookings);
            this.Controls.Add(this.txtTotalOutstanding);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dgvReport);
            this.Controls.Add(this.txtOverdueAccounts);
            this.Controls.Add(this.txtTotalAccounts);
            this.Controls.Add(this.txtOutstandingDeposits);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AccountStatusReportForm";
            this.Text = "AccountStatusReportForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGenerateReport;
        private System.Windows.Forms.Button btnBackToHome;
        private System.Windows.Forms.TextBox txtCorporateAccounts;
        private System.Windows.Forms.TextBox txtPendingDeposits;
        private System.Windows.Forms.TextBox txtConfirmedBookings;
        private System.Windows.Forms.TextBox txtTotalOutstanding;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvReport;
        private System.Windows.Forms.TextBox txtOverdueAccounts;
        private System.Windows.Forms.TextBox txtTotalAccounts;
        private System.Windows.Forms.TextBox txtOutstandingDeposits;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblReportDate;
    }
}
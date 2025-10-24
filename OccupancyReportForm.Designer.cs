namespace PhumlaKamnandi.PresentationLayer.Forms
{
    partial class OccupancyReportForm
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
            this.btnBackToHome = new System.Windows.Forms.Button();
            this.dgvReport = new System.Windows.Forms.DataGridView();
            this.btnGenerateReport = new System.Windows.Forms.Button();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblGeneratedDate = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblAverageOccupancy = new System.Windows.Forms.Label();
            this.lblPeakOccupancy = new System.Windows.Forms.Label();
            this.lblPeriodRevenue = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBackToHome
            // 
            this.btnBackToHome.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnBackToHome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackToHome.Location = new System.Drawing.Point(1476, 379);
            this.btnBackToHome.Name = "btnBackToHome";
            this.btnBackToHome.Size = new System.Drawing.Size(142, 74);
            this.btnBackToHome.TabIndex = 30;
            this.btnBackToHome.Text = "Back To Home";
            this.btnBackToHome.UseVisualStyleBackColor = false;
            this.btnBackToHome.Click += new System.EventHandler(this.btnBackToHome_Click);
            // 
            // dgvReport
            // 
            this.dgvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReport.Location = new System.Drawing.Point(197, 325);
            this.dgvReport.Name = "dgvReport";
            this.dgvReport.RowHeadersWidth = 51;
            this.dgvReport.RowTemplate.Height = 24;
            this.dgvReport.Size = new System.Drawing.Size(1237, 283);
            this.dgvReport.TabIndex = 29;
            // 
            // btnGenerateReport
            // 
            this.btnGenerateReport.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnGenerateReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateReport.Location = new System.Drawing.Point(1476, 489);
            this.btnGenerateReport.Name = "btnGenerateReport";
            this.btnGenerateReport.Size = new System.Drawing.Size(142, 74);
            this.btnGenerateReport.TabIndex = 28;
            this.btnGenerateReport.Text = "Generate Report";
            this.btnGenerateReport.UseVisualStyleBackColor = false;
            this.btnGenerateReport.Click += new System.EventHandler(this.btnGenerateReport_Click);
            // 
            // dtpToDate
            // 
            this.dtpToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpToDate.Location = new System.Drawing.Point(1123, 253);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(311, 27);
            this.dtpToDate.TabIndex = 27;
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFromDate.Location = new System.Drawing.Point(525, 253);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(311, 27);
            this.dtpFromDate.TabIndex = 26;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(997, 232);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 50);
            this.label5.TabIndex = 25;
            this.label5.Text = "To\r\nDate:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(323, 232);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 50);
            this.label4.TabIndex = 24;
            this.label4.Text = "From \r\nDate:";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.Location = new System.Drawing.Point(1108, 182);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(0, 25);
            this.lblUsername.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(955, 182);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 25);
            this.label3.TabIndex = 22;
            this.label3.Text = "| User:";
            // 
            // lblGeneratedDate
            // 
            this.lblGeneratedDate.AutoSize = true;
            this.lblGeneratedDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGeneratedDate.Location = new System.Drawing.Point(747, 182);
            this.lblGeneratedDate.Name = "lblGeneratedDate";
            this.lblGeneratedDate.Size = new System.Drawing.Size(0, 25);
            this.lblGeneratedDate.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(528, 182);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 25);
            this.label2.TabIndex = 20;
            this.label2.Text = "Generated:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(555, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(704, 102);
            this.label1.TabIndex = 19;
            this.label1.Text = "Phumla Kamnandi Hotels\r\nDynamic Occupancy Level Report";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(1326, 655);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(201, 29);
            this.label8.TabIndex = 33;
            this.label8.Text = "Period Revenue";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(253, 655);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(244, 29);
            this.label7.TabIndex = 32;
            this.label7.Text = "Average Occupancy";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(792, 655);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(207, 29);
            this.label6.TabIndex = 31;
            this.label6.Text = "Peak Occupancy";
            // 
            // lblAverageOccupancy
            // 
            this.lblAverageOccupancy.AutoSize = true;
            this.lblAverageOccupancy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAverageOccupancy.Location = new System.Drawing.Point(319, 710);
            this.lblAverageOccupancy.Name = "lblAverageOccupancy";
            this.lblAverageOccupancy.Size = new System.Drawing.Size(0, 25);
            this.lblAverageOccupancy.TabIndex = 34;
            // 
            // lblPeakOccupancy
            // 
            this.lblPeakOccupancy.AutoSize = true;
            this.lblPeakOccupancy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPeakOccupancy.Location = new System.Drawing.Point(854, 710);
            this.lblPeakOccupancy.Name = "lblPeakOccupancy";
            this.lblPeakOccupancy.Size = new System.Drawing.Size(0, 25);
            this.lblPeakOccupancy.TabIndex = 35;
            // 
            // lblPeriodRevenue
            // 
            this.lblPeriodRevenue.AutoSize = true;
            this.lblPeriodRevenue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPeriodRevenue.Location = new System.Drawing.Point(1399, 710);
            this.lblPeriodRevenue.Name = "lblPeriodRevenue";
            this.lblPeriodRevenue.Size = new System.Drawing.Size(0, 25);
            this.lblPeriodRevenue.TabIndex = 36;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(-94, 319);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(0, 16);
            this.lblUser.TabIndex = 37;
            // 
            // OccupancyReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1649, 874);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.lblPeriodRevenue);
            this.Controls.Add(this.lblPeakOccupancy);
            this.Controls.Add(this.lblAverageOccupancy);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnBackToHome);
            this.Controls.Add(this.dgvReport);
            this.Controls.Add(this.btnGenerateReport);
            this.Controls.Add(this.dtpToDate);
            this.Controls.Add(this.dtpFromDate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblGeneratedDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "OccupancyReportForm";
            this.Text = "OccupancyReportForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBackToHome;
        private System.Windows.Forms.DataGridView dgvReport;
        private System.Windows.Forms.Button btnGenerateReport;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblGeneratedDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblAverageOccupancy;
        private System.Windows.Forms.Label lblPeakOccupancy;
        private System.Windows.Forms.Label lblPeriodRevenue;
        private System.Windows.Forms.Label lblUser;
    }
}
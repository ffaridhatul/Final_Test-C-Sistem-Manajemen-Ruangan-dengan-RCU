namespace CSharpTest.View
{
    partial class frmCheckInList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvCheckInList = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCheckInList)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCheckInList
            // 
            this.dgvCheckInList.AllowUserToAddRows = false;
            this.dgvCheckInList.AllowUserToDeleteRows = false;
            this.dgvCheckInList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCheckInList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dgvCheckInList.Location = new System.Drawing.Point(-68, 53);
            this.dgvCheckInList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvCheckInList.MultiSelect = false;
            this.dgvCheckInList.Name = "dgvCheckInList";
            this.dgvCheckInList.ReadOnly = true;
            this.dgvCheckInList.RowHeadersWidth = 62;
            this.dgvCheckInList.RowTemplate.Height = 27;
            this.dgvCheckInList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCheckInList.Size = new System.Drawing.Size(1088, 784);
            this.dgvCheckInList.TabIndex = 1;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "RoomNo";
            this.Column1.HeaderText = "Nomor kamar tamu";
            this.Column1.MinimumWidth = 8;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 150;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "CheckInDate";
            dataGridViewCellStyle16.Format = "g";
            dataGridViewCellStyle16.NullValue = null;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle16;
            this.Column2.FillWeight = 140F;
            this.Column2.HeaderText = "Tanggal dan waktu check-in";
            this.Column2.MinimumWidth = 8;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 140;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "CheckInDays";
            this.Column3.FillWeight = 80F;
            this.Column3.HeaderText = "tanggal menginap";
            this.Column3.MinimumWidth = 8;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 80;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "CheckOutDate";
            dataGridViewCellStyle17.Format = "g";
            dataGridViewCellStyle17.NullValue = "(Undefined)";
            this.Column4.DefaultCellStyle = dataGridViewCellStyle17;
            this.Column4.FillWeight = 140F;
            this.Column4.HeaderText = "tanggal dan waktu check-out";
            this.Column4.MinimumWidth = 8;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 140;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "Payment";
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle18.Format = "N0";
            dataGridViewCellStyle18.NullValue = null;
            this.Column5.DefaultCellStyle = dataGridViewCellStyle18;
            this.Column5.HeaderText = "jumlah pembayaran";
            this.Column5.MinimumWidth = 8;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 150;
            // 
            // frmCheckInList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1023, 840);
            this.Controls.Add(this.dgvCheckInList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCheckInList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Check-in/Check-out daftar";
            this.Load += new System.EventHandler(this.frmCheckInList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCheckInList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCheckInList;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
    }
}
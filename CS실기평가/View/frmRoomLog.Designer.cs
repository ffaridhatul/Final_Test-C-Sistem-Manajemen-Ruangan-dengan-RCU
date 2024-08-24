namespace CSharpTest.View
{
    partial class frmRoomLog
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
            this.dgvSystemLog = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnClose = new System.Windows.Forms.Button();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSystemLog)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvSystemLog
            // 
            this.dgvSystemLog.AllowUserToAddRows = false;
            this.dgvSystemLog.AllowUserToDeleteRows = false;
            this.dgvSystemLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSystemLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSystemLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dgvSystemLog.Location = new System.Drawing.Point(14, 133);
            this.dgvSystemLog.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvSystemLog.MultiSelect = false;
            this.dgvSystemLog.Name = "dgvSystemLog";
            this.dgvSystemLog.ReadOnly = true;
            this.dgvSystemLog.RowHeadersWidth = 62;
            this.dgvSystemLog.RowTemplate.Height = 27;
            this.dgvSystemLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSystemLog.Size = new System.Drawing.Size(754, 761);
            this.dgvSystemLog.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "LogDate";
            this.Column1.FillWeight = 160F;
            this.Column1.HeaderText = "waktu perekaman";
            this.Column1.MinimumWidth = 8;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 160;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "RoomNo";
            this.Column2.HeaderText = "Nomor kamar tamu";
            this.Column2.MinimumWidth = 8;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 150;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Message";
            this.Column3.FillWeight = 150F;
            this.Column3.HeaderText = "isi";
            this.Column3.MinimumWidth = 8;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 150;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(277, 916);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(116, 61);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dtFromDate
            // 
            this.dtFromDate.Location = new System.Drawing.Point(12, 33);
            this.dtFromDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(224, 26);
            this.dtFromDate.TabIndex = 6;
            // 
            // dtToDate
            // 
            this.dtToDate.Location = new System.Drawing.Point(273, 32);
            this.dtToDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(224, 26);
            this.dtToDate.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(245, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "~";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.dtToDate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtFromDate);
            this.groupBox1.Location = new System.Drawing.Point(11, 16);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(640, 87);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Periode pencarian";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(510, 32);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(111, 37);
            this.btnSearch.TabIndex = 10;
            this.btnSearch.Text = "Pencarian";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // frmRoomLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(781, 995);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvSystemLog);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmRoomLog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Riwayat kamar tamu";
            this.Load += new System.EventHandler(this.frmRoomLog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSystemLog)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSystemLog;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DateTimePicker dtFromDate;
        private System.Windows.Forms.DateTimePicker dtToDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    }
}
namespace RoomControlUnit
{
    partial class frmMain
    {
        /// <summary>
        /// Ini adalah variabel desainer yang diperlukan.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Bersihkan semua sumber daya yang digunakan.
        /// </summary>
        /// <param name="disposing">benar jika sumber daya yang dikelola harus dihapus; jika tidak, salah.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Kode yang dibuat oleh desainer

        /// <summary>
        /// Metode ini diperlukan untuk dukungan desainer. 
        /// Jangan ubah konten metode ini dengan editor kode.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numRcuId = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtPortNo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtServerIP = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTemperature = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdoClose = new System.Windows.Forms.RadioButton();
            this.rdoOpen = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rdoMasterKey = new System.Windows.Forms.RadioButton();
            this.rdoGuestKey = new System.Windows.Forms.RadioButton();
            this.rdoNone = new System.Windows.Forms.RadioButton();
            this.tmrSend = new System.Windows.Forms.Timer(this.components);
            this.lblMessage = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRcuId)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numRcuId);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnConnect);
            this.groupBox1.Controls.Add(this.txtPortNo);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtServerIP);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(194, 14);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(443, 212);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Informasi koneksi";
            // 
            // numRcuId
            // 
            this.numRcuId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.numRcuId.Location = new System.Drawing.Point(128, 67);
            this.numRcuId.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numRcuId.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numRcuId.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numRcuId.Name = "numRcuId";
            this.numRcuId.Size = new System.Drawing.Size(86, 30);
            this.numRcuId.TabIndex = 11;
            this.numRcuId.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(25, 68);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 34);
            this.label2.TabIndex = 10;
            this.label2.Text = "RCU ID";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(290, 85);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(131, 103);
            this.btnConnect.TabIndex = 9;
            this.btnConnect.Text = "terhubung";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtPortNo
            // 
            this.txtPortNo.Location = new System.Drawing.Point(371, 28);
            this.txtPortNo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPortNo.Name = "txtPortNo";
            this.txtPortNo.Size = new System.Drawing.Size(50, 26);
            this.txtPortNo.TabIndex = 8;
            this.txtPortNo.Text = "9999";
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(268, 28);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 26);
            this.label5.TabIndex = 7;
            this.label5.Text = "nomor port";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtServerIP
            // 
            this.txtServerIP.Location = new System.Drawing.Point(128, 28);
            this.txtServerIP.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtServerIP.Name = "txtServerIP";
            this.txtServerIP.Size = new System.Drawing.Size(85, 26);
            this.txtServerIP.TabIndex = 6;
            this.txtServerIP.Text = "127.0.0.1";
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.Location = new System.Drawing.Point(25, 28);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 34);
            this.label6.TabIndex = 5;
            this.label6.Text = "alamat server";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(429, 157);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 45);
            this.label3.TabIndex = 8;
            this.label3.Text = "derajat";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTemperature
            // 
            this.lblTemperature.BackColor = System.Drawing.Color.AliceBlue;
            this.lblTemperature.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTemperature.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTemperature.Location = new System.Drawing.Point(354, 157);
            this.lblTemperature.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTemperature.Name = "lblTemperature";
            this.lblTemperature.Size = new System.Drawing.Size(74, 44);
            this.lblTemperature.TabIndex = 7;
            this.lblTemperature.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Honeydew;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(219, 157);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 44);
            this.label1.TabIndex = 6;
            this.label1.Text = "suhu ruangan kamar tamu";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdoClose);
            this.groupBox2.Controls.Add(this.rdoOpen);
            this.groupBox2.Location = new System.Drawing.Point(-1, 225);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(263, 92);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "status pintu";
            // 
            // rdoClose
            // 
            this.rdoClose.AutoSize = true;
            this.rdoClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rdoClose.Location = new System.Drawing.Point(133, 38);
            this.rdoClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rdoClose.Name = "rdoClose";
            this.rdoClose.Size = new System.Drawing.Size(104, 26);
            this.rdoClose.TabIndex = 1;
            this.rdoClose.Text = "tertutup";
            this.rdoClose.UseVisualStyleBackColor = true;
            // 
            // rdoOpen
            // 
            this.rdoOpen.AutoSize = true;
            this.rdoOpen.Checked = true;
            this.rdoOpen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rdoOpen.Location = new System.Drawing.Point(29, 38);
            this.rdoOpen.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rdoOpen.Name = "rdoOpen";
            this.rdoOpen.Size = new System.Drawing.Size(102, 26);
            this.rdoOpen.TabIndex = 0;
            this.rdoOpen.TabStop = true;
            this.rdoOpen.Text = "terbuka";
            this.rdoOpen.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rdoMasterKey);
            this.groupBox3.Controls.Add(this.rdoGuestKey);
            this.groupBox3.Controls.Add(this.rdoNone);
            this.groupBox3.Location = new System.Drawing.Point(292, 225);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Size = new System.Drawing.Size(488, 92);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "status pemegang kunci";
            // 
            // rdoMasterKey
            // 
            this.rdoMasterKey.AutoSize = true;
            this.rdoMasterKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rdoMasterKey.Location = new System.Drawing.Point(304, 39);
            this.rdoMasterKey.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rdoMasterKey.Name = "rdoMasterKey";
            this.rdoMasterKey.Size = new System.Drawing.Size(148, 26);
            this.rdoMasterKey.TabIndex = 2;
            this.rdoMasterKey.Text = "kunci master";
            this.rdoMasterKey.UseVisualStyleBackColor = true;
            // 
            // rdoGuestKey
            // 
            this.rdoGuestKey.AutoSize = true;
            this.rdoGuestKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rdoGuestKey.Location = new System.Drawing.Point(162, 39);
            this.rdoGuestKey.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rdoGuestKey.Name = "rdoGuestKey";
            this.rdoGuestKey.Size = new System.Drawing.Size(131, 26);
            this.rdoGuestKey.TabIndex = 1;
            this.rdoGuestKey.Text = "kunci tamu";
            this.rdoGuestKey.UseVisualStyleBackColor = true;
            // 
            // rdoNone
            // 
            this.rdoNone.AutoSize = true;
            this.rdoNone.Checked = true;
            this.rdoNone.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rdoNone.Location = new System.Drawing.Point(37, 39);
            this.rdoNone.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rdoNone.Name = "rdoNone";
            this.rdoNone.Size = new System.Drawing.Size(117, 26);
            this.rdoNone.TabIndex = 0;
            this.rdoNone.TabStop = true;
            this.rdoNone.Text = "tidak ada";
            this.rdoNone.UseVisualStyleBackColor = true;
            // 
            // tmrSend
            // 
            this.tmrSend.Enabled = true;
            this.tmrSend.Interval = 1000;
            this.tmrSend.Tick += new System.EventHandler(this.tmrSend_Tick);
            // 
            // lblMessage
            // 
            this.lblMessage.BackColor = System.Drawing.Color.Black;
            this.lblMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblMessage.ForeColor = System.Drawing.Color.Yellow;
            this.lblMessage.Location = new System.Drawing.Point(-1, 327);
            this.lblMessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(781, 34);
            this.lblMessage.TabIndex = 13;
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMessage.Click += new System.EventHandler(this.lblMessage_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 360);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblTemperature);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Room Control Unit";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRcuId)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTemperature;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdoClose;
        private System.Windows.Forms.RadioButton rdoOpen;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rdoMasterKey;
        private System.Windows.Forms.RadioButton rdoGuestKey;
        private System.Windows.Forms.RadioButton rdoNone;
        private System.Windows.Forms.Timer tmrSend;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.NumericUpDown numRcuId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPortNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtServerIP;
        private System.Windows.Forms.Label label6;
    }
}


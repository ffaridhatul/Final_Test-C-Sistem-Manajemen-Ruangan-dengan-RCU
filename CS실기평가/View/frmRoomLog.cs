using CSharpTest.Business;
using CSharpTest.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpTest.View
{
    public partial class frmRoomLog : Form
    {
        public frmRoomLog()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            RefreshRoomLogGrid();
        }

        private void RefreshRoomLogGrid()
        {
            dgvSystemLog.AutoGenerateColumns = false;

            DateTime fromDate = dtFromDate.Value;
            DateTime toDate = dtToDate.Value.AddDays(1);

            //TODO
            //Menggunakan nilai tanggal dari variabel lokal fromDate dan toDate yang dideklarasikan di atas, semua catatan ruangan yang dibuat dalam dua rentang tanggal akan ditampilkan. 
            //Dapatkan dalam format List<RoomLog> .
            //(Saat memanggil metode GetSystemLog() objek RoomManagementBiz, tulis ekspresi lambda dan teruskan sebagai parameter)

            // Menggunakan GetSystemLog dari RoomManagementBiz dengan filter tanggal
            List<RoomLog> roomLogs = RoomManagementBiz.GetInstance().GetSystemLog(log =>
                log.LogDate >= fromDate && log.LogDate < toDate);
            //Daftar ini tercermin dalam Grid. (lihat kode di bawah)

            //dgvSystemLog.DataSource = XXX;
            dgvSystemLog.DataSource = roomLogs;
        }

        private void frmRoomLog_Load(object sender, EventArgs e)
        {
            dtFromDate.Value = DateTime.Today.AddDays(-7);
            dtToDate.Value = DateTime.Today;

            RefreshRoomLogGrid();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

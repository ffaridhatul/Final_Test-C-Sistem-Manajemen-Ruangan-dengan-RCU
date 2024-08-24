using CSharpTest.Business;
using CSharpTest.Model;
using System;
using System.Linq;
using System.Windows.Forms;

namespace CSharpTest.View
{
    public partial class frmMain : Form
    {
        RoomManagementBiz roomManagerBiz;
        RcuComManager rcuComManager;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            roomManagerBiz = RoomManagementBiz.GetInstance();
            roomManagerBiz.SetSystemLogFile(new RoomLogFile());
            roomManagerBiz.LoadData();

            rcuComManager = new RcuComManager(9999);
            rcuComManager.RcuPacketArrived += RcuComManager_rcuPacketArrived;
            rcuComManager.Start();


            RefreshRoomList();
        }

        private void RefreshRoomList()
        {
            dgvRooms.AutoGenerateColumns = false;
            var roomList = RoomManagementBiz.GetInstance().GetRoomList();
            dgvRooms.DataSource = null;
            dgvRooms.DataSource = roomList;
        }

        private void RcuComManager_rcuPacketArrived(RcuPacket rcuPacket)
        {
            this.Invoke(new Action(() => { ProcessRoomPacket(rcuPacket); }));
        }

        //----------------------------------------------------------------------------------------------------
        //Metode dipanggil setiap kali informasi kamar tamu dikirimkan dari RCU kamar tamu
        //----------------------------------------------------------------------------------------------------
        private void ProcessRoomPacket(RcuPacket rcuPacket)
        {
            //TODO
            //Silakan lihat persyaratan di halaman 7 spesifikasi untuk melengkapi fungsionalitasnya.
            // Dapatkan Room berdasarkan RcuId dari rcuPacket
            var room = roomManagerBiz.GetRoom(rcuPacket.RcuId);

            if (room != null)
            {
                // Cek perubahan status kunci
                if (room.KeyStatus != rcuPacket.KeyStatus)
                {
                    string message = "";
                    switch (rcuPacket.KeyStatus)
                    {
                        case KeyStatusEnum.Empty:
                            message = "Hapus kunci";
                            break;
                        case KeyStatusEnum.GuestKey:
                            message = "Masukkan kunci tamu";
                            break;
                        case KeyStatusEnum.MasterKey:
                            message = "Masukkan kunci pembersih";
                            break;
                        default:
                            message = "Status kunci tidak dikenal";
                            break;
                    }

                    var roomLog = new RoomLog
                    {
                        LogDate = DateTime.Now,
                        RoomNo = room.RoomNo,
                        Message = message
                    };

                    roomManagerBiz.AddRoomLog(roomLog);

                    // Perbarui status kunci pada objek Room yang ada
                    room.KeyStatus = rcuPacket.KeyStatus; // Update KeyStatus
                }

                // Cek perubahan status pintu
                if (room.DoorStatus != rcuPacket.DoorStatus)
                {
                    string message = "";
                    switch (rcuPacket.DoorStatus)
                    {
                        case DoorStatusEnum.Opened:
                            message = "Pintu terbuka";
                            break;
                        case DoorStatusEnum.Closed:
                            message = "Pintu tertutup";
                            break;
                        default:
                            message = "Status pintu tidak dikenal";
                            break;
                    }

                    var roomLog = new RoomLog
                    {
                        LogDate = DateTime.Now,
                        RoomNo = room.RoomNo,
                        Message = message
                    };

                    roomManagerBiz.AddRoomLog(roomLog);
                    room.DoorStatus = rcuPacket.DoorStatus; // Update DoorStatus
                }

                // Simpan perubahan pada Room di RoomManagementBiz
                // Tidak perlu menambahkan kembali ke roomMap atau roomList karena perubahan langsung pada objek Room.
                // Jika menggunakan database, simpan perubahan ke database di sini.
            }

            // Perbarui tampilan daftar kamar
            RefreshRoomList();
        }
        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //TODO
            //Kotak pesan ditampilkan ketika program berakhir dan pengguna menekan tombol [Tidak]. 
            //Tulis kode Anda untuk menghindari penghentian. (Lihat spesifikasi untuk bentuk kotak pesan)
            // Menampilkan kotak pesan ketika pengguna mencoba untuk menutup aplikasi
            var result = MessageBox.Show("Apakah Anda yakin ingin keluar dari program?", "Konfirmasi Keluar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                e.Cancel = true; // Batalkan penghentian aplikasi jika pengguna menekan "Tidak"
            }
            //Done

        }

        private void lblShowSystemLog_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var form = new frmRoomLog();
            form.ShowDialog();
        }

        private void dgvRooms_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rcuId = dgvRooms.GetSelectedRcuId();    //Dapatkan nilai RcuId dari baris yang dipilih

            if (rcuId >= 0)
            {
                var room = RoomManagementBiz.GetInstance().GetRoom(rcuId); //Mengambil objek entitas Rcu yang sesuai dari peta

                var form = new frmCheckInOut();
                form.Room = room;   //Teruskan objek entitas Room yang melakukan operasi check-in atau check-out ke frmCheckInOut.

                if (form.ShowDialog() == DialogResult.OK)
                {
                    RefreshRoomList();  //Perbarui dengan informasi terbaru
                }
                //Done
            }
        }

        private void lblShowCheckInList_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var form = new frmCheckInList();
            form.ShowDialog();
        }
    }
}

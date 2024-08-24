using CSharpTest.Model;
using System;
using System.Windows.Forms;


namespace CSharpTest.View
{
    public partial class frmCheckInOut : Form
    {
        public Room Room { get; set; }  // Objek kamar (Room) yang berfungsi untuk check-in atau Check-out.

        public frmCheckInOut()
        {
            InitializeComponent();
        }

        //Metode untuk menginisialisasi kontrol dalam bentuk sebelum layar ditampilkan
        private void frmCheckInOut_Load(object sender, EventArgs e) 
        {
            //TODO
            //Jika CheckInId objek Kamar yang direferensikan oleh properti anggota Kamar bukan nol, layar ditampilkan untuk “check-out” karena ini adalah kamar yang sedang digunakan, 
            //Jika CheckInId adalah null, kamar tersedia untuk dihuni, jadi Anda harus menulis kode untuk menampilkan layar “check-in”.
            //Lihat penjelasannya di bawah ini.

            //1. Saat layar check-in terbuka, hanya tombol [Enter] dan tombol [Close] yang terlihat, 
            //   Saat membuka layar checkout, tombol [Check out], tombol [Simpan], dan tombol [Tutup] ditampilkan di atas formulir. (Atur properti Enabled tombol ke benar atau salah.)

            //2. Jika ini adalah layar check-in, tampilkan “Check-in” di judul formulir (properti Teks). 
            //   Jika ini adalah layar checkout, tampilkan “Checkout” di judul formulir.

            //3. Dalam hal layar check-in, tanggal dan waktu check-in (lblCheckInDate) menunjukkan tanggal hari ini (DateTime.Today), dan jumlah hari menginap (numDays) menunjukkan 1 hari.

            //4. Hitung dan tampilkan jumlah total (lblPayment) berdasarkan jumlah hari menginap (numDays) dan biaya akomodasi.

            //5. Perkiraan tanggal check-out (lblDueDate) di layar dihitung dengan menambahkan jumlah hari menginap (CheckInDays) ke tanggal check-in (CheckInDate). (Gunakan metode AddDays() dari format tanggal)
            // Jika CheckInId dari objek Room tidak null, berarti kamar sedang ditempati, buka layar "check-out"
            //-------------------------------------------------------------------------------------------------------------------------------------------
            if (Room.CheckInId.HasValue)
            {
                // Mode "check-out"
                lblRoomNo.Text = Room.RoomNo;
                btnCheckIn.Enabled = false;
                btnCheckOut.Enabled = true;
                btnSave.Enabled = true;
                btnClose.Enabled = true;
                this.Text = "Checkout";

                lblCheckInDate.Text = DateTime.Today.ToShortDateString();
                numDays.Value = 1;

                decimal nightlyRate = Room.NightlyRate;
                lblPayment.Text = (numDays.Value * nightlyRate).ToString("C");

                // Calculate the estimated check-out date
                DateTime checkInDate = DateTime.Parse(lblCheckInDate.Text);
                DateTime dueDate = checkInDate.AddDays((int)numDays.Value);
                lblDueDate.Text = dueDate.ToShortDateString();
                lblNightlyRate.Text = nightlyRate.ToString("C");
            }
            else
            {
                // Mode "check-in"
                lblRoomNo.Text = Room.RoomNo;
                btnCheckIn.Enabled = true;
                btnCheckOut.Enabled = false;
                btnSave.Enabled = false;
                btnClose.Enabled = true;
                this.Text = "Check-in";

                lblCheckInDate.Text = DateTime.Today.ToShortDateString();
                numDays.Value = 1;

                decimal nightlyRate = Room.NightlyRate;
                lblPayment.Text = (numDays.Value * nightlyRate).ToString("C");

                DateTime checkInDate = DateTime.Today;
                DateTime dueDate = checkInDate.AddDays((int)numDays.Value);
                lblDueDate.Text = dueDate.ToShortDateString();
                lblNightlyRate.Text = nightlyRate.ToString("C");
            }

        }
        // frmCheckInOut_Load Done

        //Metode untuk memproses Check-in
        private void btnCheckIn_Click(object sender, EventArgs e)   
        {
            //TODO
            //1. Buat objek CheckIn, inisialisasi properti (nomor kamar, tanggal check-in, waktu, jumlah malam, tarif kamar) dengan tepat, lalu masukkan ke dalam DB menggunakan DAO.
            //   (Penting: Saat memasukkan, properti Id dari objek CheckIn tidak ditentukan, tetapi jika nilai Id dibaca segera setelah dimasukkan, itu berisi nilai Id (PK) dari baris CheckIn yang diisi oleh DAO.)  
            //2. Properti Room di kelas mengacu pada objek Room yang sedang dikerjakan. 
            //   Tentukan nilai Id dari baris CheckIn yang ditambahkan di atas pada properti CheckIn objek Kamar ini, 
            //   Ubah properti RoomStatus menjadi status InUse lalu perbarui di DB menggunakan DAO.
            //---------------------------------------------------------------------------------------------------------------


            // 1. Buat objek CheckIn dan inisialisasi propertinya
            var checkIn = new CheckIn
        {
            RoomNo = Room.RoomNo,                               // Nomor kamar
            CheckInDate = DateTime.Today,                       // Tanggal check-in (hari ini)
            CheckInDays = (int)numDays.Value,                   // Jumlah malam menginap
            Payment = Room.NightlyRate * (int)numDays.Value     // Tarif kamar total berdasarkan jumlah malam
        };

        // Masukkan objek CheckIn ke dalam DB menggunakan DAO
        var result = CheckInDAO.GetInstance().Add(checkIn);

        if (result == DAOResult.Success)
        {
            // 2. Update properti Room dengan nilai Id dari baris CheckIn yang baru saja ditambahkan
            Room.CheckInId = checkIn.Id;
            Room.RoomStatus = RoomStatusEnum.InUse;  // Ubah status kamar menjadi 'InUse'

            // Perbarui objek Room di DB menggunakan DAO
            RoomDAO.GetInstance().Update(Room);

            DialogResult = DialogResult.OK;  // Kode untuk menutup formulir Anda sambil meneruskan nilai ke frmMain
        }
        else
        {
            // Handle error if needed, for example:
            MessageBox.Show("Failed to check in. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }



    }

        //Metode untuk check out
        private void btnCheckOut_Click(object sender, EventArgs e)  
        {
            //TODO
            //(Penting: CheckInId.Value properti Kamar berisi nilai Id(PK) dari baris CheckIn yang berisi informasi masuk kamar saat ini)

            //1. Setelah menggunakan DAO untuk mengambil objek CheckIn terbaru untuk ruangan menggunakan Room.CheckInId.Value sebagai kuncinya, 
            //   Atur properti CheckOutDate dari objek CheckIn ke tanggal saat ini (DateTime.Now) dan perbarui di DB menggunakan DAO. 

            //2. Ruangan yang direferensikan oleh properti Room sekarang menjadi ruangan yang tersedia dan tidak memiliki objek CheckIn yang terkait, jadi ubah properti Room.CheckInId menjadi null;
            //   Ubah properti RoomStatus menjadi Tersedia, lalu:
            //   DAO digunakan untuk memperbarui informasi ruangan di DB. 

            // Pastikan Room diinisialisasi dan memiliki CheckInId yang valid
            if (Room == null || !Room.CheckInId.HasValue)
            {
                MessageBox.Show("Room data is missing or invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 1. Ambil objek CheckIn terbaru menggunakan DAO dengan Room.CheckInId sebagai kunci
            var checkIn = CheckInDAO.GetInstance().Get(Room.CheckInId.Value);

            if (checkIn == null)
            {
                MessageBox.Show("Check-in data not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Atur properti CheckOutDate dari objek CheckIn ke tanggal dan waktu saat ini
            checkIn.CheckOutDate = DateTime.Now;

            // Perbarui objek CheckIn di DB menggunakan DAO
            var result = CheckInDAO.GetInstance().Update(checkIn);

            if (result == DAOResult.Success)
            {
                // 2. Update objek Room untuk menandakan bahwa kamar sekarang tersedia
                Room.CheckInId = null;  // Tidak ada CheckIn terkait
                Room.RoomStatus = RoomStatusEnum.Available;  // Ubah status kamar menjadi 'Available'

                // Perbarui objek Room di DB menggunakan DAO
                RoomDAO.GetInstance().Update(Room);

                MessageBox.Show("Check-out successful.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;  // Menutup formulir dan mengembalikan nilai OK
            }
            else
            {
                MessageBox.Show("Failed to check out. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //TODO 
            //(Penting: Room.CheckInId.Value berisi nilai Id(PK) dari baris CheckIn terbaru)
            //1. Berikan Room.CheckInId.Value sebagai Kunci untuk mengambil objek CheckIn terbaru untuk ruangan tersebut menggunakan DAO, 
            //   Ubah hari check-in (CheckInDays) dan biaya akomodasi (Pembayaran) untuk mengontrol nilai tampilan di UI dan memperbaruinya di DB menggunakan DAO.

            // Pastikan Room diinisialisasi dan memiliki CheckInId yang valid
            if (Room == null || !Room.CheckInId.HasValue)
            {
                MessageBox.Show("Room data is missing or invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 1. Ambil objek CheckIn terbaru menggunakan DAO dengan Room.CheckInId sebagai kunci
            var checkIn = CheckInDAO.GetInstance().Get(Room.CheckInId.Value);

            if (checkIn == null)
            {
                MessageBox.Show("Check-in data not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Ubah hari check-in (CheckInDays) dan biaya akomodasi (Payment) berdasarkan nilai kontrol di UI
            checkIn.CheckInDays = (int)numDays.Value;
            checkIn.Payment = Room.NightlyRate * checkIn.CheckInDays;

            // Perbarui data CheckIn di DB menggunakan DAO
            var result = CheckInDAO.GetInstance().Update(checkIn);

            if (result == DAOResult.Success)
            {
                MessageBox.Show("Check-in information updated successfully.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;  // Menutup formulir dan mengembalikan nilai OK
            }
            else
            {
                MessageBox.Show("Failed to update check-in information. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;     //Melakukan fungsi menutup formulir.
        }

        //Pengendali peristiwa dipanggil setiap kali nilai kontrol jumlah malam berubah.
        private void numDays_ValueChanged(object sender, EventArgs e)
        {
            //TODO
            //Bergantung pada nilai kontrol numDays, perkiraan tanggal check-out (lblDueDate) dan jumlah total (lblPayment) yang ditampilkan di UI formulir adalah 
            //Tulis kode untuk membuat perubahan.

            // Pastikan Room diinisialisasi dan valid
            if (Room == null)
            {
                MessageBox.Show("Room data is missing.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Hitung ulang tanggal check-out berdasarkan jumlah malam menginap (numDays.Value)
            DateTime checkOutDate = DateTime.Today.AddDays((double)numDays.Value);
            lblDueDate.Text = checkOutDate.ToShortDateString();

            // Hitung ulang total biaya akomodasi berdasarkan tarif kamar dan jumlah malam menginap
            decimal totalPayment = Room.NightlyRate * numDays.Value;
            lblPayment.Text = totalPayment.ToString("C");  // Format sebagai mata uang



        }
    }
}
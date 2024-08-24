using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Text;

namespace CSharpTest.Model
{
    public class CheckInDAO : IDAO<CheckIn>
    {
        private static CheckInDAO checkInDAO;

        private CheckInDAO()
        {
        }

        public static CheckInDAO GetInstance()
        {
            //Lengkapi kode di bawah ini untuk membuat objek CheckInDAO dengan TODO Singleton.
            if (checkInDAO == null)
            {
                checkInDAO = new CheckInDAO();
            }  // Singleton Done.
            //kode Sudah dilengkapi
            return checkInDAO;
        }

        public DAOResult Add(CheckIn checkIn)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("INSERT INTO CheckIn(RoomNo, CheckInDate, CheckOutDate, CheckInDays, Payment) ");
            sql.Append("VALUES(@RoomNo, @CheckInDate, @CheckOutDate, @CheckInDays, @Payment); ");
            sql.Append("SELECT SCOPE_IDENTITY() "); //Kueri untuk mengambil nilai ID yang baru saja ditetapkan 

            try
            {
                using (var db = new DBHelper())
                {
                    var con = db.Connection;
                    con.Open();

                    var cmd = new SqlCommand(sql.ToString(), con);

                    cmd.Parameters.Add("@RoomNo", SqlDbType.NVarChar).Value = checkIn.RoomNo;
                    cmd.Parameters.Add("@CheckInDate", SqlDbType.DateTime).Value = checkIn.CheckInDate;
                    cmd.Parameters.Add("@CheckOutDate", SqlDbType.DateTime).Value = checkIn.CheckOutDate.HasValue ? checkIn.CheckOutDate.Value : SqlDateTime.Null;
                    cmd.Parameters.Add("@CheckInDays", SqlDbType.Int).Value = checkIn.CheckInDays;
                    cmd.Parameters.Add("@Payment", SqlDbType.Int).Value = checkIn.Payment;

                    checkIn.Id = Convert.ToInt32(cmd.ExecuteScalar());  //Catat nilai ID yang baru saja ditetapkan pada objek 

                    return DAOResult.Success;
                }
            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.StackTrace);
                return DAOResult.SqlError;
            }
        }

        public DAOResult Delete(int id)
        {
            StringBuilder sql = new StringBuilder("DELETE FROM checkIn WHERE Id = @Id");

            try
            {
                using (var db = new DBHelper())
                {
                    //Selesaikan kode di bawah ini untuk menghapus informasi check-in yang sesuai dengan id parameter TODO dari tabel CheckIn.

                    var con = db.Connection;
                    con.Open();

                    var cmd = new SqlCommand(sql.ToString(), con);
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;

                    cmd.ExecuteNonQuery(); // Eksekusi perintah untuk menghapus
                    //done

                    return DAOResult.Success;
                }
            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.StackTrace);
                return DAOResult.SqlError;
            }
        }

        public CheckIn Get(int id)
        {
            CheckIn checkIn = null;
            StringBuilder sql = new StringBuilder("SELECT Id, RoomNo, CheckInDate, CheckOutDate, CheckInDays, Payment FROM CheckIn WHERE Id = @Id");

            using (var db = new DBHelper())
            {
                var con = db.Connection;
                con.Open();

                var cmd = new SqlCommand(sql.ToString(), con);
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                var reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    checkIn = new CheckIn
                    {
                        Id = Convert.ToInt32(reader["Id"]),                         //PK
                        RoomNo = reader["RoomNo"].ToString(),                       //Nomor kamar tamu
                        CheckInDate = Convert.ToDateTime(reader["CheckInDate"]),    //Tanggal dan waktu check-in
                        CheckOutDate = reader["CheckOutDate"] as DateTime?,         //Tanggal dan waktu check-out
                        CheckInDays = Convert.ToInt32(reader["CheckInDays"]),       //Jumlah hari menginap
                        Payment = Convert.ToInt32(reader["Payment"])                //biaya akomodasi
                    };
                }

                reader.Close();
            }

            return checkIn;
        }

        public List<CheckIn> GetAll()
        {
            List<CheckIn> checkInList = new List<CheckIn>();

            StringBuilder sql = new StringBuilder("SELECT Id, RoomNo, CheckInDate, CheckOutDate, CheckInDays, Payment FROM CheckIn");

            using (var db = new DBHelper())
            {
                //TODO Lengkapi kode di bawah ini untuk mengambil seluruh informasi Check-in/Check-out dari tabel CheckIn dan memasukkannya ke dalam checkInList.

                var con = db.Connection;
                con.Open();

                var cmd = new SqlCommand(sql.ToString(), con);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var checkIn = new CheckIn
                    {
                        Id = Convert.ToInt32(reader["Id"]),                         // PK
                        RoomNo = reader["RoomNo"].ToString(),                       // Nomor kamar tamu
                        CheckInDate = Convert.ToDateTime(reader["CheckInDate"]),    // Tanggal dan waktu check-in
                        CheckOutDate = reader["CheckOutDate"] as DateTime?,         // Tanggal dan waktu check-out
                        CheckInDays = Convert.ToInt32(reader["CheckInDays"]),       // Jumlah hari menginap
                        Payment = Convert.ToInt32(reader["Payment"])                // Biaya akomodasi
                    };
                    checkInList.Add(checkIn);
                }

                reader.Close();  //done

            }

            return checkInList;
        }

        public DAOResult Update(CheckIn checkIn)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("UPDATE CheckIn ");
            sql.Append("SET   RoomNo = @RoomNo, ");
            sql.Append("      CheckInDate = @CheckInDate, ");
            sql.Append("      CheckOutDate = @CheckOutDate, ");
            sql.Append("      CheckInDays = @CheckInDays, ");
            sql.Append("      Payment =  @Payment ");
            sql.Append("WHERE Id = @Id");

            try
            {
                using (var db = new DBHelper())
                {
                    //Lengkapi kode untuk memperbarui catatan terkait di tabel CheckIn dengan konten parameter TODO checkIn.

                    var con = db.Connection;
                    con.Open();

                    var cmd = new SqlCommand(sql.ToString(), con);

                    cmd.Parameters.Add("@RoomNo", SqlDbType.NVarChar).Value = checkIn.RoomNo;
                    cmd.Parameters.Add("@CheckInDate", SqlDbType.DateTime).Value = checkIn.CheckInDate;
                    cmd.Parameters.Add("@CheckOutDate", SqlDbType.DateTime).Value = checkIn.CheckOutDate.HasValue ? checkIn.CheckOutDate.Value : SqlDateTime.Null;
                    cmd.Parameters.Add("@CheckInDays", SqlDbType.Int).Value = checkIn.CheckInDays;
                    cmd.Parameters.Add("@Payment", SqlDbType.Int).Value = checkIn.Payment;
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = checkIn.Id;

                    cmd.ExecuteNonQuery(); // Eksekusi perintah untuk memperbarui
                    //done


                }

                return DAOResult.Success;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.StackTrace);
                return DAOResult.SqlError;
            }
        }
    }
}

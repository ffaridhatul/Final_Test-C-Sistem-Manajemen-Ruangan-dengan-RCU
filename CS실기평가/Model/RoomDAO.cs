using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTest.Model
{
    public class RoomDAO : IDAO<Room>
    {
        private static RoomDAO roomDAO;

        private RoomDAO()
        {
        }

        public static RoomDAO GetInstance()
        {
            //Lengkapi kode di bawah ini untuk membuat objek RoomDAO dengan TODO Singleton.
            if (roomDAO == null)
            {
                roomDAO = new RoomDAO();
            }
            //done
            return roomDAO;
        }

        public DAOResult Add(Room room)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("INSERT INTO Room(RcuId, RoomNo, Floor, RoomStatus, KeyStatus, DoorStatus, NightlyRate) ");
            sql.Append("VALUES(@RcuId, @RoomNo, @Floor, @RoomStatus, @KeyStatus, @DoorStatus, @NightlyRate);");
            sql.Append("SELECT SCOPE_IDENTITY() ");

            try
            {
                using (var db = new DBHelper())
                {
                    var con = db.Connection;
                    con.Open();

                    var cmd = new SqlCommand(sql.ToString(), con);

                    cmd.Parameters.Add("@RcuId", SqlDbType.Int).Value = room.RcuId;                 //RCU ID
                    cmd.Parameters.Add("@RoomNo", SqlDbType.Int).Value = room.RoomNo;               //Nomor kamar tamu
                    cmd.Parameters.Add("@Floor", SqlDbType.Int).Value = room.Floor;                 //Nomor lantai
                    cmd.Parameters.Add("@RoomStatus", SqlDbType.Int).Value = (int)room.RoomStatus;  //Status kamar
                    cmd.Parameters.Add("@KeyStatus", SqlDbType.Int).Value = (int)room.KeyStatus;    //Status kunci
                    cmd.Parameters.Add("@DoorStatus", SqlDbType.Int).Value = (int)room.DoorStatus;  //Status pintu
                    cmd.Parameters.Add("@NightlyRate", SqlDbType.Int).Value = room.NightlyRate;     //Biaya akomodasi harian

                    room.Id = Convert.ToInt32(cmd.ExecuteScalar());

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
            StringBuilder sql = new StringBuilder("DELETE FROM Room WHERE Id = @Id");

            try
            {
                using (var db = new DBHelper())
                {
                    //TODO lengkapi kode untuk menghapus ruangan yang sesuai dengan parameter id dari tabel Room.
                    var con = db.Connection;
                    con.Open();

                    var cmd = new SqlCommand(sql.ToString(), con);
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;

                    cmd.ExecuteNonQuery(); // Eksekusi perintah untuk menghapus ruangan
                    //Done
                    return DAOResult.Success;
                }
            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.StackTrace);
                return DAOResult.SqlError;
            }
        }

        public Room Get(int id)
        {
            Room room = null;
            StringBuilder sql = new StringBuilder("SELECT Id, RcuId, RoomNo, Floor, RoomStatus, KeyStatus, DoorStatus, NightlyRate, Temperature, CheckInId FROM Room WHERE Id = @Id");

            using (var db = new DBHelper())
            {
                //Lengkapi kode di bawah ini untuk mencari tabel Room untuk ruangan yang sesuai dengan ID yang diterima sebagai parameter TODO.
                var con = db.Connection;
                con.Open();

                var cmd = new SqlCommand(sql.ToString(), con);
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;

                var reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    room = new Room
                    {
                        Id = Convert.ToInt32(reader["Id"]),                         // PK
                        RcuId = Convert.ToInt32(reader["RcuId"]),                   // RCU ID
                        RoomNo = reader["RoomNo"].ToString(),                       // Nomor kamar tamu
                        Floor = Convert.ToInt32(reader["Floor"]),                   // Nomor lantai
                        RoomStatus = (RoomStatusEnum)Convert.ToInt32(reader["RoomStatus"]), // Status kamar
                        KeyStatus = (KeyStatusEnum)Convert.ToInt32(reader["KeyStatus"]),    // Status kunci
                        DoorStatus = (DoorStatusEnum)Convert.ToInt32(reader["DoorStatus"]), // Status pintu
                        NightlyRate = Convert.ToInt32(reader["NightlyRate"]),       // Biaya akomodasi harian
                        Temperature = reader["Temperature"] != DBNull.Value ? Convert.ToInt32(reader["Temperature"]) : (int?)null, // Suhu kamar
                        CheckInId = reader["CheckInId"] != DBNull.Value ? Convert.ToInt32(reader["CheckInId"]) : (int?)null // CheckIn ID
                    };
                }

                reader.Close();
                //Done
            }

            return room;
        }

        public List<Room> GetAll()
        {
            List<Room> roomList = new List<Room>();

            StringBuilder sql = new StringBuilder("SELECT Id, RcuId, RoomNo, Floor, RoomStatus, KeyStatus, DoorStatus, NightlyRate, Temperature, CheckInId FROM Room");

            using (var db = new DBHelper())
            {
                //TODO Lengkapi kode di bawah ini untuk mengambil semua informasi ruangan dari tabel Room dan menambahkannya ke roomList.
                var con = db.Connection;
                con.Open();

                var cmd = new SqlCommand(sql.ToString(), con);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var room = new Room
                    {
                        Id = Convert.ToInt32(reader["Id"]),                         // PK
                        RcuId = Convert.ToInt32(reader["RcuId"]),                   // RCU ID
                        RoomNo = reader["RoomNo"].ToString(),                       // Nomor kamar tamu sebagai string
                        Floor = Convert.ToInt32(reader["Floor"]),                   // Nomor lantai
                        RoomStatus = (RoomStatusEnum)Convert.ToInt32(reader["RoomStatus"]), // Status kamar sebagai enum
                        KeyStatus = (KeyStatusEnum)Convert.ToInt32(reader["KeyStatus"]),    // Status kunci sebagai enum
                        DoorStatus = (DoorStatusEnum)Convert.ToInt32(reader["DoorStatus"]), // Status pintu sebagai enum
                        NightlyRate = Convert.ToInt32(reader["NightlyRate"]),       // Biaya akomodasi harian
                        Temperature = reader["Temperature"] != DBNull.Value ? Convert.ToInt32(reader["Temperature"]) : (int?)null, // Suhu kamar
                        CheckInId = reader["CheckInId"] != DBNull.Value ? Convert.ToInt32(reader["CheckInId"]) : (int?)null // CheckIn ID
                    };

                    roomList.Add(room);
                }

                reader.Close();
                //Done
            }

            return roomList;
        }

        public DAOResult Update(Room room)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("UPDATE Room ");
            sql.Append("SET    RcuId = @RcuId, ");
            sql.Append("       RoomNo = @RoomNo, ");
            sql.Append("       Floor = @Floor, ");
            sql.Append("       RoomStatus = @RoomStatus, ");
            sql.Append("       KeyStatus = @KeyStatus, ");
            sql.Append("       DoorStatus = @DoorStatus, ");
            sql.Append("       Temperature = @Temperature, ");
            sql.Append("       NightlyRate = @NightlyRate, ");
            sql.Append("       CheckInId = @CheckInId ");
            sql.Append("WHERE Id = @Id");

            try
            {
                using (var db = new DBHelper())
                {
                    //Selesaikan kode di bawah ini untuk memperbarui konten objek room yang diterima sebagai parameter TODO ke tabel Room.
                    var con = db.Connection;
                    con.Open();

                    var cmd = new SqlCommand(sql.ToString(), con);

                    cmd.Parameters.Add("@RcuId", SqlDbType.Int).Value = room.RcuId;
                    cmd.Parameters.Add("@RoomNo", SqlDbType.Int).Value = room.RoomNo;
                    cmd.Parameters.Add("@Floor", SqlDbType.Int).Value = room.Floor;
                    cmd.Parameters.Add("@RoomStatus", SqlDbType.Int).Value = (int)room.RoomStatus;
                    cmd.Parameters.Add("@KeyStatus", SqlDbType.Int).Value = (int)room.KeyStatus;
                    cmd.Parameters.Add("@DoorStatus", SqlDbType.Int).Value = (int)room.DoorStatus;
                    cmd.Parameters.Add("@Temperature", SqlDbType.Int).Value = room.Temperature.HasValue ? room.Temperature.Value : SqlInt32.Null;
                    cmd.Parameters.Add("@NightlyRate", SqlDbType.Int).Value = room.NightlyRate;
                    cmd.Parameters.Add("@CheckInId", SqlDbType.Int).Value = room.CheckInId.HasValue ? room.CheckInId.Value : SqlInt32.Null;
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = room.Id;

                    cmd.ExecuteNonQuery(); // Eksekusi perintah untuk memperbarui ruangan
                    //Done
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

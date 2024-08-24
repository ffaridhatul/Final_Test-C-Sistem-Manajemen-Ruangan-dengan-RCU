using CSharpTest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTest.Business
{
    public class RoomManagementBiz
    {
        private static RoomManagementBiz sensorMonitoringBiz;

        private List<Room> roomList;
        private Dictionary<int, Room> roomMap;
        private List<RoomLog> roomLogList;
        private IDataSource<RoomLog> roomLogFile;

        private RoomManagementBiz() { }

        public static RoomManagementBiz GetInstance()
        {
            if (sensorMonitoringBiz == null)
                sensorMonitoringBiz = new RoomManagementBiz();

            return sensorMonitoringBiz;
        }

        public void SetSystemLogFile(IDataSource<RoomLog> dataSource)
        {
            roomLogFile = dataSource;
        }

        public void LoadData()
        {
            roomList = RoomDAO.GetInstance().GetAll();

            if (roomLogFile != null)
                roomLogList = roomLogFile.Load();

            roomMap = PutToRoomMap(roomList);
        }

        private Dictionary<int, Room> PutToRoomMap(List<Room> roomList)
        {
            var roomMap = new Dictionary<int, Room>();

            //TODO
            //Mengulangi pernyataan foreach untuk parameter roomList, menentukan objek Room sebagai kunci untuk nilai properti RcuId
            //Tambahkan ke roomMap.
            foreach (var room in roomList)
            {
                if (!roomMap.ContainsKey(room.RcuId))
                {
                    roomMap.Add(room.RcuId, room);
                }
            }       //done

            return roomMap;
        }

        public List<RoomLog> GetSystemLog(Func<RoomLog, Boolean> filter)
        {
            var list = new List<RoomLog>();

            //TODO
            //Untuk koleksi roomLogList yang berisi semua informasi ruangan, setiap objek Room yang disimpan dalam koleksi tersebut adalah 
            //Saat mencari dengan foreach, panggil metode yang ditunjuk oleh variabel delegasi filter dan

            //Jika nilai return metode ini benar, kembalikan metode tersebut dalam koleksi daftar.
            foreach (var log in roomLogList)
            {
                if (filter(log))
                {
                    list.Add(log);
                }
            }                                   //done


            return list;
        }

        public void AddRoomLog(RoomLog roomLog)
        {
            roomLogFile.Add(roomLog);
            roomLogList.Add(roomLog);
        }

        public void AddRoom(Room room)
        {
            roomList.Add(room);
            roomMap.Add(room.RcuId, room);

            RoomDAO.GetInstance().Add(room);
        }

        public List<Room> GetRoomList()
        {
            return roomList;
        }

        public Room GetRoom(int rcuId)
        {
            //TODO
            //Gunakan metode ContentKey() untuk memeriksa apakah objek Room dengan nilai rcuId sebagai kuncinya ada di roomMap.
            //Mengembalikan objek Room terkait jika ada, atau null jika tidak ada.
            if (roomMap.ContainsKey(rcuId))
            {
                return roomMap[rcuId];
            }
            return null; //done
        }

        public async void SaveToDataSource()
        {
            await roomLogFile.SaveAsync(roomLogList);
        }
    }
}

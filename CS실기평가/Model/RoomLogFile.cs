using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTest.Model
{
    public class RoomLogFile : IDataSource<RoomLog>
    {
        public void Add(RoomLog entity)
        {
            using (var writer = new StreamWriter(new FileStream("RoomLog.txt", FileMode.OpenOrCreate | FileMode.Append), Encoding.Default))
            {
                string jsonStr = JsonConvert.SerializeObject(entity);
                writer.WriteLine(jsonStr);
            }
        }

        public List<RoomLog> Load()
        {
            var list = new List<RoomLog>();

            using (var reader = new StreamReader(new FileStream("RoomLog.txt", FileMode.OpenOrCreate), Encoding.Default))
            {
                string jsonStr;

                while ((jsonStr = reader.ReadLine()) != null)
                {
                    var roomLog = JsonConvert.DeserializeObject<RoomLog>(jsonStr);
                    list.Add(roomLog);
                }
            }

            return list;
        }

        // Menyimpan semua RoomLog ke dalam file RoomLog.txt
        public void Save(List<RoomLog> list)
        {
            using (var writer = new StreamWriter(new FileStream("RoomLog.txt", FileMode.Open), Encoding.Default))
            {
                //TODO
                //Mengulangi semua objek RoomLog dalam koleksi list (menggunakan foreach)
                //Dalam loop, gunakan kelas JsonConvert untuk membuat serialisasi (Serialize) menjadi string JSON., 
                //Simpan baris demi baris di file. (Menggunakan metode WriteLine)
                // Serialisasi objek RoomLog menjadi string JSON
                foreach (var roomLog in list)
                {
                    // Serialisasi objek RoomLog menjadi string JSON
                    string jsonStr = JsonConvert.SerializeObject(roomLog);

                    // Menulis string JSON ke dalam file
                    writer.WriteLine(jsonStr);
                }
            }
        }

        public Task SaveAsync(List<RoomLog> list)
        {
            //TODO
            //Kode yang menjalankan metode Save() di atas secara asinkron menggunakan metode Task.StartNew()Tulislah.

            //return Task.Run(Ekspresi Lambda);
            return Task.Run(() => Save(list));
        }
    }
}